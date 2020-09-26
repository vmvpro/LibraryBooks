namespace LibraryBooksClient
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>()
                .HasMany(e => e.Books)
                .WithOptional(e => e.Author)
                .HasForeignKey(e => e.id_author);

            modelBuilder.Entity<Book>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.Subjects)
                .WithOptional(e => e.Category)
                .HasForeignKey(e => e.id_category);

            modelBuilder.Entity<Subject>()
                .Property(e => e.comment)
                .IsFixedLength();

            modelBuilder.Entity<Subject>()
                .HasMany(e => e.Books)
                .WithOptional(e => e.Subject)
                .HasForeignKey(e => e.id_subject);
        }
    }
}
