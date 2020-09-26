using System.Data.Entity;
using LibraryBooksClient.Model;

namespace LibraryBooksClient.LibraryDbContext
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(): base("name=LibraryBooks")
        {
            
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<HotelContext, LibraryBooksClient.Migrations.Configuration>());
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new BookConfig());
            modelBuilder.Configurations.Add(new AuthorConfig());
            modelBuilder.Configurations.Add(new SubjectConfig());
        }
    }
}