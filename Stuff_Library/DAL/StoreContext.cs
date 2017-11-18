using Microsoft.AspNet.Identity.EntityFramework;
using Stuff_Library.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Stuff_Library.DAL
{


	public class StoreContext : IdentityDbContext<ApplicationUser>
	{
		public StoreContext() : base("StoreContext")
		{

		}

		static StoreContext()
		{
			Database.SetInitializer<StoreContext>(new StoreInitializer());
		}


		public static StoreContext Create()
		{
			return new StoreContext();
		}

		public DbSet<Course> Courses { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<OrderItem> OrderItems { get; set; }
		
	}
}