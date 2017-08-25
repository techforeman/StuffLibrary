using Stuff_Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Stuff_Library.ViewModels
{
	public class HomeViewModel
	{


		public IEnumerable<Course> BestVoted { get; set; }
		public IEnumerable<Course> NewArrivals { get; set; }
		public IEnumerable<Category> Categories { get; set; }

	}
}