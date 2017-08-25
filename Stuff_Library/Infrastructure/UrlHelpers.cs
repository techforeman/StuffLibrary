using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.IO;

namespace Stuff_Library.Infrastructure
{
	public static class UrlHelpers
	{

		public static string CategoryIconPath (this UrlHelper helper, string categoryIconFilename)
		{
			var categoryIconFolder = AppConfig.CategoryIconsFolderRelative;
			var path = Path.Combine(categoryIconFolder, categoryIconFilename);
			var absolutePath = helper.Content(path);
			return absolutePath;
		}


		public static string CoursIconPath(this UrlHelper helper, string coursIconFilename)
		{
			var coursIconFolder = AppConfig.PhotosFolderRelative;
			var path = Path.Combine(coursIconFolder, coursIconFilename);
			var absolutePath = helper.Content(path);
			return absolutePath;
		}

	}
}