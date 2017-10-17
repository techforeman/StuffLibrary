using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Stuff_Library.ViewModels
{
	public class CartRemoveViewModel
	{
		public decimal CartTotal
		{
			get;
			set;
		}
		public int CartItemCount
		{
			get;
			set;
		}
		public int RemovedItemCount
		{
			get;
			set;
		}
		public int RemoveItemId
		{
			get;
			set;
		}


	}
}