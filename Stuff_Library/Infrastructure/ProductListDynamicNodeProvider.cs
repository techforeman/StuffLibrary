using MvcSiteMapProvider;
using Stuff_Library.DAL;
using Stuff_Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Stuff_Library.Infrastructure
{
	public class ProductListDynamicNodeProvider : DynamicNodeProviderBase
	{
		private StoreContext db = new StoreContext();

		public override IEnumerable<DynamicNode> GetDynamicNodeCollection(ISiteMapNode node)
		{
			var returnValue = new List<DynamicNode>();

			foreach (Category a in db.Categories)
			{
				DynamicNode n = new DynamicNode();
				n.Title = a.Name;
				n.Key = "Category_" + a.CategoryID;
				n.RouteValues.Add("categoryname", a.Name);
				returnValue.Add(n);
			}

			return returnValue;
		}
	}
}