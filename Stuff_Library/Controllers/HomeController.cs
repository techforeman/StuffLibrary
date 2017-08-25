using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Stuff_Library.DAL;
using Stuff_Library.Models;
using Stuff_Library.ViewModels;

namespace Stuff_Library.Controllers
{
    public class HomeController : Controller
    {
		private StoreContext db = new StoreContext();

		// GET: Home
		public ActionResult Index()
		{
			var categories = db.Categories;
			var newArrivals = db.Courses.Where(a => !a.IsHidden).OrderByDescending(a => a.DateAdded).Take(3).ToList();
			var bestVoted = db.Courses.Where(a => !a.IsHidden && a.IsBestVoted).OrderBy(g => Guid.NewGuid()).Take(3).ToList();

			var vm = new HomeViewModel()
			{
				Categories = categories, 
				BestVoted = bestVoted,
				NewArrivals = newArrivals
			};




			return View(vm);
		}




		public ActionResult StaticContent(string viewname)
        {
			
            return View(viewname);
        }




		

	}
}