using Stuff_Library.Migrations;
using Stuff_Library.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace Stuff_Library.DAL
{
	public class StoreInitializer : MigrateDatabaseToLatestVersion<StoreContext, Configuration>
	{
		//protected override void Seed(StoreContext context)
		//{
		//	SeedStoreData(context);
		//	base.Seed(context);

		//}

		public static void SeedStoreData(StoreContext context)
		{
			var categories = new List<Category>
			{
				new Category() { CategoryID = 1, Name = "C#", IconFilename = "Cdesktop.png"},
				new Category() { CategoryID = 2, Name = "C#-web", IconFilename = "Cweb.png"},
				new Category() { CategoryID = 3, Name = "Excel-VBA", IconFilename = "VBA.png"},
				new Category() { CategoryID = 4, Name = "Python", IconFilename = "Python.png"},
				new Category() { CategoryID = 5, Name = "HTML-CSS-JS", IconFilename = "HtmlCSSjs.png"},
				new Category() { CategoryID = 6, Name = "SQL", IconFilename = "SQL.png"},
				new Category() { CategoryID = 7, Name = "Design", IconFilename = "Design.png"},
				new Category() { CategoryID = 8, Name = "Self-dev", IconFilename = "SelfDev.png"},
				new Category() { CategoryID = 9, Name = "Others", IconFilename = "Others.png"}
			};

			categories.ForEach(g => context.Categories.AddOrUpdate(g));
			context.SaveChanges();

			var courses = new List<Course>
			{
				new Course() { CourseID = 1, AuthorName = "The Reds", CourseTitle = "More Way", CovertFileName = "1.png", IsBestVoted = true, DateAdded = new DateTime(2014, 02, 1), CategoryID = 1 },
				new Course() { CourseID = 2, AuthorName = "Dillusion", CourseTitle = "All that nothing",  CovertFileName = "2.png", IsBestVoted = true, DateAdded = new DateTime(2013, 08, 15), CategoryID = 1 },
				new Course() { CourseID = 3, AuthorName = "Allfor", CourseTitle = "Golden suffering",  CovertFileName = "3.png", IsBestVoted = true, DateAdded = new DateTime(2014, 01, 5), CategoryID = 3 },
				new Course() { CourseID = 4, AuthorName = "Stasik", CourseTitle = "Pole samo się nie orze",  CovertFileName = "4.jpg", IsBestVoted = true, DateAdded = new DateTime(2014, 03, 11), CategoryID = 3 },
			};
			courses.ForEach(a => context.Courses.AddOrUpdate(a));
			context.SaveChanges();
		}
	}
}