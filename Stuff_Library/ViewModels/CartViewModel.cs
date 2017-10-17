using Stuff_Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Stuff_Library.ViewModels
{
	public class CartViewModel
	{
		public List<CartItem> CartItems { get; set; }
		public decimal TotalPrice { get; set; }


	}
}