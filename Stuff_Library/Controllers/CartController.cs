using Stuff_Library.DAL;
using Stuff_Library.Models;
using Stuff_Library.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.Owin;
using Stuff_Library.Infrastructure;
using System.Web.Hosting;
using System.Net;
using Hangfire;
using NLog;



namespace Stuff_Library.Controllers
{
	public class CartController : Controller
	{

		private ShoppingCartManager shoppingCartManager;
		private StoreContext db = new StoreContext();

		private ISessionManager sessionManager { get; set; }
		private ApplicationUserManager _userManager;

		public CartController()
		{
			this.sessionManager = new SessionManager();
			this.shoppingCartManager = new ShoppingCartManager(this.sessionManager, this.db);
		}



		public ApplicationUserManager UserManager
		{
			get
			{
				return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
			}
			private set
			{
				_userManager = value;
			}
		}

		public ActionResult Index()
		{

			var cartItems = shoppingCartManager.GetCart();
			var cartTotalPrice = shoppingCartManager.GetCartTotalPrice();

			CartViewModel cartVM = new CartViewModel() { CartItems = cartItems, TotalPrice = cartTotalPrice };

			return View(cartVM);
		}

		public ActionResult AddToCart(int id)
		{

			shoppingCartManager.AddToCart(id);
			return RedirectToAction("Index", "Cart");
		}


		public int GetCartItemsCount()
		{


			//  shoppingCartManager.GetCartItemsCount();

			return 0;


		}

		public ActionResult RemoveFromCart(int courseId)
		{


			int itemCount = shoppingCartManager.RemoveFromCart(courseId);
			int cartItemsCount = shoppingCartManager.GetCartItemsCount();
			decimal cartTotal = shoppingCartManager.GetCartTotalPrice();

			// Return JSON to process it in JavaScript
			var result = new CartRemoveViewModel
			{
				RemoveItemId = courseId,
				RemovedItemCount = itemCount,
				CartTotal = cartTotal,
				CartItemCount = cartItemsCount
			};

			return Json(result);
		}

		public async Task<ActionResult> Checkout()
		{
			if (Request.IsAuthenticated)
			{
				var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());

				var order = new Order
				{
					FirstName = user.UserData.FirstName,
					LastName = user.UserData.LastName,
					Email = user.UserData.Email

				};

				return View(order);
			}
			else
				return RedirectToAction("Login", "Account", new { returnUrl = Url.Action("Checkout", "Cart") });
		}

		[HttpPost]
		public async Task<ActionResult> Checkout(Order orderdetails)
		{
			if (ModelState.IsValid)
			{


				// Get user
				var userId = User.Identity.GetUserId();

				// Save Order
				ShoppingCartManager shoppingCartManager = new ShoppingCartManager(this.sessionManager, this.db);
				var newOrder = shoppingCartManager.CreateOrder(orderdetails, userId);

				// Update profile information
				var user = await UserManager.FindByIdAsync(userId);
				TryUpdateModel(user.UserData);
				await UserManager.UpdateAsync(user);

				// Empty cart
				shoppingCartManager.EmptyCart();






				return RedirectToAction("OrderConfirmation");
			}
			else
				return View(orderdetails);
		}

		public ActionResult OrderConfirmation()
		{
			return View();
		}


	}
};