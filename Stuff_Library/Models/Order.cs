using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Stuff_Library.Models
{
	public class Order
	{
		public int OrderID { get; set; }
		public string UserID { get; set; }
		[StringLength(150)]
		public string FirstName { get; set; }
		[StringLength(150)]
		public string LastName { get; set; }
		public string Email { get; set; }
		public string Comment { get; set; }
		public DateTime DateCreated { get; set; }
		public OrderState OrderState { get; set; }

		public List<OrderItem> OrderItem { get; set; }
	}

	public enum OrderState
	{
		New,
		Shipped
	}
}