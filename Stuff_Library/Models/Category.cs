using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Stuff_Library.Models
{
	public class Category
	{
		public int CategoryID { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public string IconFilename { get; set; }

		public virtual ICollection<Course> Courses { get; set; }
	}
}