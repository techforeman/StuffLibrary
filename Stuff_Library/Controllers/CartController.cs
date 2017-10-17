using SpodIglyMVC.Infrastructure;
using Stuff_Library.DAL;
using Stuff_Library.Infrastructure;
using Stuff_Library.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Stuff_Library.Controllers
{
	

	public class CartController : Controller
	{

		private ShoppingCartManager shoppingCartManager;
		private ISessionManager sessionManager { get; set; }
		private StoreContext db = new StoreContext();

		public CartController()
		{
			this.sessionManager = new SessionManager();
			this.shoppingCartManager = new ShoppingCartManager(this.sessionManager, this.db);
		}


		// GET: Cart
		public ActionResult Index()
		{
			var cartItems = shoppingCartManager.GetCart();
			var cartTotalPrice = shoppingCartManager.GetCartTotalPrice();

			CartViewModel cartVM = new CartViewModel()
			{
				CartItems = cartItems, TotalPrice = cartTotalPrice
			};

			return View(cartVM);
		}

		public ActionResult AddToCart(int id)
		{
			shoppingCartManager.AddToCart(id);
			return RedirectToAction("Index");
		}

		public int GetCartItemsCount()
		{
			return shoppingCartManager.GetCartItemsCount();
		}

		public ActionResult RemoveFromCart(int courseID)
		{
			int itemCount = shoppingCartManager.RemoveFromCart(courseID);
			int cartItemCount = shoppingCartManager.GetCartItemsCount();

			//return JSON to process it in JavaScript
			var result = new CartRemoveViewModel
			{
				RemoveItemId = courseID,
				RemovedItemCount=itemCount,
				CartTotal = 59,
				CartItemCount = cartItemCount
					
			};

			return Json(result);
		}
	}
} 