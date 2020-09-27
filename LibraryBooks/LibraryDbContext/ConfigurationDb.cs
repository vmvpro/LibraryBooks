using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Windows.Documents;
using LibraryBooksClient.Model;

namespace LibraryBooksClient.LibraryDbContext
{

    public class Config
    {
        public void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Properties().Configure(p => p.HasColumnAnnotation("", ""));
            //.Configure(p => p.Ha);
        }
    }

    public class LibraryContextConfig : EntityTypeConfiguration<LibraryContext>
    {
        void BookConfig()
        {
            HasKey(f => f.Books.Select(x => x.BookId));
        }
    }

    public class BookConfig : EntityTypeConfiguration<Book>
    {


        public BookConfig()
        {
            HasKey(field => field.BookId);
            Property(field => field.Name).IsRequired();
            Property(field => field.Description).HasColumnType("nvarchar(max)");
            Property(field => field.Image).HasColumnType((DbType.Binary).ToString());


            ToTable("Books");
        }

    }

    public class AuthorConfig : EntityTypeConfiguration<Author>
    {
        public AuthorConfig()
        {
            HasKey(field => field.AuthorId);
            HasMany(e => e.Books)
                .WithOptional(e => e.Author)
                .HasForeignKey(e => e.IdAuthor)
                .WillCascadeOnDelete(false);

            //var indexAnnotation = new IndexAnnotation();
            var indexAttr = new IndexAttribute("IX_FullName");
            
            Property(field => field.FirstName).
                HasColumnAnnotation("annotationIx", 
                new IndexAnnotation(new IndexAttribute("IX_FullName") { IsClustered = false, IsUnique =true, Order = 1 }));
            
            Property(field => field.LastName).
                HasColumnAnnotation("annotationIx", 
                new IndexAnnotation(new IndexAttribute("IX_FullName") { IsClustered=false, IsUnique = true, Order = 2 }));

            Property(field => field.Comment).HasMaxLength(255);
            ToTable("Authors");
        }

    }

    public class SubjectConfig : EntityTypeConfiguration<Subject>
    {
        public SubjectConfig()
        {
            HasMany(e => e.Books)
                .WithOptional(e => e.Subject)
                .HasForeignKey(e => e.IdSubject)
                .WillCascadeOnDelete(false);
            Property(e => e.Comment).HasMaxLength(255);
            ToTable("Subjects");
        }

    }

    public class CategoryConfig : EntityTypeConfiguration<Category>
    {
        public CategoryConfig()
        {
            Property(field => field.Name).IsRequired();
            HasMany(field => field.Subjects)
                .WithOptional(field => field.Category)
                .HasForeignKey(field => field.IdCategory);
            Property(field => field.Comment).HasMaxLength(255);
            ToTable("Categories");
        }

    }
}