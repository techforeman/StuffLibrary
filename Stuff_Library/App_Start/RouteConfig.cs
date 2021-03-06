﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Stuff_Library
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


			routes.MapRoute(
				name: "ProductDetail",
				url: "kurs-{id}.html",
				defaults: new { controller = "Store", action = "Details" }
			);


			routes.MapRoute(
				name: "StaticPage",
				url: "strony/{viewname}.html",
				defaults: new {controller="Home", action = "StaticContent"}
			);

			routes.MapRoute(
				name:"ProductList",
				url: "kategoria-{categoryname}.html",
				defaults: new {controller ="Store", action = "List"},
				constraints: new { categoryname = @"[\w& ] +"}
			);


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
						


            );
        }
    }
}
