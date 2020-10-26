using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text.RegularExpressions;
using LibraryBooksClient.Model;

namespace LibraryBooksClient.LibraryDbContext
{
    public class PropertySnakeCaseConvention : IStoreModelConvention<EdmProperty>
    {
        public void Apply(EdmProperty item, DbModel model)
        {
            item.Name = ToSnakeCase(item.Name);
        }

        private string ToSnakeCase(string input)
        {
            if (string.IsNullOrEmpty(input)) { return input; }

            var startUnderscores = Regex.Match(input, @"^_+");
            return startUnderscores + Regex.Replace(input, @"([a-z0-9])([A-Z])", "$1_$2").ToLower();
        }

    }

    public class LibraryContext : DbContext
    {
        public LibraryContext(string nameOrConnectionString) : base("name=LibraryBooks") { }

        public LibraryContext() : base("name=LibraryBooks") { }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Properties()
                .Where(x => x.Name.EndsWith("ID", System.StringComparison.OrdinalIgnoreCase))
                .Configure(x => x.IsKey());

            modelBuilder.Properties()
                .Where(x => x.PropertyType == typeof(string))
                .Configure(x => x.HasMaxLength(50));

            modelBuilder.Conventions.Add<PropertySnakeCaseConvention>();

            modelBuilder.Configurations.Add(new BookConfig());
            modelBuilder.Configurations.Add(new AuthorConfig());
            modelBuilder.Configurations.Add(new SubjectConfig());
            modelBuilder.Configurations.Add(new CategoryConfig());
        }
    }
}