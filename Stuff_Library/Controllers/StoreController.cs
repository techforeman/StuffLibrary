using Stuff_Library.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Stuff_Library.Controllers
{
	public class StoreController : Controller
	{

		StoreContext db = new StoreContext();

		// GET: Store
		public ActionResult Index()
		{
			return View();
		}


		public ActionResult Details(int id)
		{
			var course = db.Courses.Find(id);
			return View(course);
		}

		public ActionResult List(string categoryname, string searchQuery = null)
		{
			var category = db.Categories.Include("Courses").Where(g => g.Name.ToUpper() == categoryname.ToUpper()).Single();

			var course = category.Courses.Where(a => (searchQuery == null ||
			a.CourseTitle.ToLower().Contains(searchQuery.ToLower()) ||
			a.AuthorName.ToLower().Contains(searchQuery.ToLower())) &&
			!a.IsHidden);

			if (Request.IsAjaxRequest())
			{
				return PartialView("_ProductList", course);
			}
				
								
			
			return View(course);
		}


		[ChildActionOnly]
		[OutputCache(Duration = 80000)]
		public ActionResult CategoryMenu()
		{


			var categories = db.Categories.ToList();


			return PartialView("_CategoryMenu", categories);
		}

		public ActionResult AlbumsSuggestions(string term)
		{
			var course = this.db.Courses.Where(a => a.CourseTitle.ToLower().Contains(term.ToLower()) && !a.IsHidden).Take(5).Select(a => new { label = a.CourseTitle });

			return Json(course, JsonRequestBehavior.AllowGet);
		}
	}
}

