using MvcSiteMapProvider;
using Stuff_Library.DAL;
using Stuff_Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Stuff_Library.Infrastructure
{
	public class ProductDetailsDynamicNodeProvider : DynamicNodeProviderBase
	{
		private StoreContext db = new StoreContext();

		public override IEnumerable<DynamicNode> GetDynamicNodeCollection(ISiteMapNode node)
		{
			var returnValue = new List<DynamicNode>();

			foreach (Course a in db.Courses)
			{
				DynamicNode n = new DynamicNode();
				n.Title = a.CourseTitle;
				n.Key = "Course_" + a.CourseID;
				n.ParentKey = "Category_" + a.CategoryID;
				n.RouteValues.Add("id", a.CourseID);
				returnValue.Add(n);
			}

			return returnValue;
		}
	}
}