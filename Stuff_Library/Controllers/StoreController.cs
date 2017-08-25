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
			return View();
		}

		public ActionResult List(string categoryname)
		{
			return View();
		}


		[ChildActionOnly]
		public ActionResult CategoryMenu()
		{
			var categories = db.Categories.ToList();


			return PartialView("_CategoryMenu", categories);
		}


	}
}

