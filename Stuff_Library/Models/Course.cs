using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Stuff_Library.Models
{
	public class Course
	{
		public int CourseID { get; set; }
		public int CategoryID { get; set; }
		public string CourseTitle { get; set; }
		public string AuthorName { get; set; }
		public DateTime DateAdded { get; set; }
		public string CovertFileName { get; set; }
		public string Description { get; set; }
		public decimal Votes { get; set; }
		public bool IsHidden { get; set; }
		public bool IsBestVoted { get; set; }
		
		public virtual Category Category { get; set; }

	}
}