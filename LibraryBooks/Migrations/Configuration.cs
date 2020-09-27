namespace LibraryBooksClient.Migrations
{
    using LibraryBooksClient.LibraryDbContext;
    using LibraryBooksClient.Model;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Windows.Documents;

    internal sealed class Configuration : DbMigrationsConfiguration<LibraryContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }



        protected override void Seed(LibraryContext context)
        {
            context.Books.AddRange(new List<Book>()
            {
                new Book() { Name = "CLR via C# .NET 4.5", Year=2012 },
                new Book() { Name = "VB 6.0 (Intuit)", Year=2010 }
            });

            context.SaveChanges();
            //

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
