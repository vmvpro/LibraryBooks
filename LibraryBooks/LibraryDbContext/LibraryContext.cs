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

            //VmvConvention

            //foreach (var entity in modelBuilder.Types)
            //{
            //    // Replace table names
            //    entity.Relational().TableName = entity.Relational().TableName.ToSnakeCase();

            //    // Replace column names            
            //    foreach (var property in entity.GetProperties())
            //    {
            //        property.Relational().ColumnName = property.Relational().ColumnName.ToSnakeCase();
            //    }

            //    foreach (var key in entity.GetKeys())
            //    {
            //        key.Relational().Name = key.Relational().Name.ToSnakeCase();
            //    }

            //    foreach (var key in entity.GetForeignKeys())
            //    {
            //        key.Relational().Name = key.Relational().Name.ToSnakeCase();
            //    }

            //    foreach (var index in entity.GetIndexes())
            //    {
            //        index.Relational().Name = index.Relational().Name.ToSnakeCase();
            //    }
            //}

            //modelBuilder.Entity<Author>()
            //    .HasMany(e => e.Books)
            //    .WithOptional(e => e.Author)
            //    .HasForeignKey(e => e.id_author);

            //modelBuilder.Entity<Book>()
            //    .Property(e => e.description)
            //    .IsUnicode(false);

            //modelBuilder.Entity<Category>()
            //    .HasMany(e => e.Subjects)
            //    .WithOptional(e => e.Category)
            //    .HasForeignKey(e => e.id_category);

            //modelBuilder.Entity<Subject>()
            //    .Property(e => e.comment)
            //    .IsFixedLength();

            //modelBuilder.Entity<Subject>()
            //    .HasMany(e => e.Books)
            //    .WithOptional(e => e.Subject)
            //    .HasForeignKey(e => e.id_subject);

            //modelBuilder.Entity<Author>().Property(x=>x.FirstName).HasColumnAnnotation(new )

            modelBuilder.Configurations.Add(new BookConfig());
            modelBuilder.Configurations.Add(new AuthorConfig());
            modelBuilder.Configurations.Add(new SubjectConfig());
            modelBuilder.Configurations.Add(new CategoryConfig());
        }
    }
}