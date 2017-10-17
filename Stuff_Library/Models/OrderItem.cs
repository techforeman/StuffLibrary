using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Stuff_Library.Models
{
	public class OrderItem
	{
		public int OrderItemID { get; set; }
		public int OrderID { get; set; }
		public int CourseID { get; set; }
		
		public virtual Course Course { get; set; }
		public virtual Order Order { get; set; }
		
	}
}