using Stuff_Library.DAL;
using Stuff_Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Stuff_Library.Infrastructure
{
	public class ShoppingCartManager
	{
		private StoreContext db;

		private ISessionManager session;

		public const string CartSessionKey = "CartData";

		public ShoppingCartManager(ISessionManager session, StoreContext db)
		{
			this.session = session;
			this.db = db;

		}




		public void AddToCart(int courseId)
		{
			var cart = this.GetCart();

			var cartItem = cart.Find(c => c.Course.CourseID == courseId);

			if (cartItem != null)
				cartItem.Quantity++;
			else
			{
				// Find course and add it to cart
				var courseToAdd = db.Courses.Where(a => a.CourseID == courseId).SingleOrDefault();
				if (courseToAdd != null)
				{
					var newCartItem = new CartItem()
					{
						Course = courseToAdd,
						Quantity = 1,

					};

					cart.Add(newCartItem);
				}
			}

			session.Set(CartSessionKey, cart);
		}



		public int RemoveFromCart(int courseId)
		{
			var cart = this.GetCart();

			var cartItem = cart.Find(c => c.Course.CourseID == courseId);

			if (cartItem != null)
			{
				if (cartItem.Quantity > 1)
				{
					cartItem.Quantity--;
					return cartItem.Quantity;
				}
				else
					cart.Remove(cartItem);
			}

			// Return count of removed item currently inside cart
			return 0;
		}


		public List<CartItem> GetCart()
		{
			List<CartItem> cart;

			if (session.Get<List<CartItem>>(CartSessionKey) == null)
			{
				cart = new List<CartItem>();
			}
			else
			{
				cart = session.Get<List<CartItem>>(CartSessionKey) as List<CartItem>;
			}

			return cart;
		}


		public decimal GetCartTotalPrice()
		{
			var cart = this.GetCart();
			return cart.Sum(c => (c.Quantity * c.Course.Votes));
		}

		public int GetCartItemsCount()
		{
			var cart = this.GetCart();
			int count = cart.Sum(c => c.Quantity);

			return count;
		}



		public Order CreateOrder(Order newOrder, string userId)
		{
			var cart = this.GetCart();

			newOrder.DateCreated = DateTime.Now;
			//newOrder.UserId = userId;

			this.db.Orders.Add(newOrder);

			if (newOrder.OrderItem == null)
				newOrder.OrderItem = new List<OrderItem>();

			decimal cartTotal = 0;

			foreach (var cartItem in cart)
			{
				var newOrderItem = new OrderItem()
				{
					CourseID = cartItem.Course.CourseID,


				};

				cartTotal += (cartItem.Quantity);

				newOrder.OrderItem.Add(newOrderItem);
			}



			this.db.SaveChanges();

			return newOrder;
		}


		public void EmptyCart()
		{
			session.Set<List<CartItem>>(CartSessionKey, null);
		}


	}
}