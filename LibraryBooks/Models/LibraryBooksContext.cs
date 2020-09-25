﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace LibraryBooks.Model
{
    class LibraryBooksContext: DbContext
    {
	    //public DbSet<Book> Books { get; set; }
	    //public DbSet<Author> Authors { get; set; }
	    //public DbSet<Category> Categories { get; set; }
	    //public DbSet<Subject> Subjects { get; set; }

	    public DbSet<Student> Students { get; set; }
	    public DbSet<Grade> Grades { get; set; }

		//public LibraryBooksContext() :base("LibraryBooksConnectionString")
		//   {
		//	Database.SetInitializer(new MigrateDatabaseToLatestVersion<LibraryBooksContext, Migrations.Configuration>());
		//}

		public LibraryBooksContext() : base("LibraryBooksTest")
	    {
		    //Database.SetInitializer(new MigrateDatabaseToLatestVersion<LibraryBooksContext, Migrations.Configuration>());
	    }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
	    {
		    base.OnModelCreating(modelBuilder);
	    }
	}
}