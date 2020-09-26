using System;
using System.Data.Entity.ModelConfiguration;
using LibraryBooksClient.Model;

namespace LibraryBooksClient.LibraryDbContext
{
    public class BookConfig : EntityTypeConfiguration<Book>
    {
        public BookConfig()
        {
            HasKey(field => field.BookId);
            Property(field => field.Name).IsRequired().HasMaxLength(50);
            //HasRequired(field => field.IdAuthor).WithMany(field => field.Books).WillCascadeOnDelete(false);
            //HasMany(field => field.IdSubject).WithOptional();
            //Property(field => field.Name).
            //Property(client => client.Account).IsOptional().HasMaxLength(20);
            //HasRequired(client => client.Room).WithMany(room => room.Clients).WillCascadeOnDelete(true);

            ToTable("Books");
        }

    }

    public class AuthorConfig : EntityTypeConfiguration<Author>
    {
        public AuthorConfig()
        {
            HasKey(field => field.AuthorId);
            Property(field => field.FirstName).HasMaxLength(50);
            Property(field => field.LastName).HasMaxLength(50);
            
            //HasRequired(field => field.Author).WithMany(field => field.Books).WillCascadeOnDelete(false);
            //Property(client => client.Account).IsOptional().HasMaxLength(20);
            //HasRequired(client => client.Room).WithMany(room => room.Clients).WillCascadeOnDelete(true);

            ToTable("Authors");
        }

    }

    public class SubjectConfig : EntityTypeConfiguration<Subject>
    {
        public SubjectConfig()
        {
            //HasKey(field => field.SubjectId);
            //Property(field => field.Name).IsRequired().HasMaxLength(50);
            //HasMany(field => field.Books).WithOptional(field => field.IdSubject);
            
            //Property(field => field.LastName).HasMaxLength(50);

            //HasRequired(field => field.Author).WithMany(field => field.Books).WillCascadeOnDelete(false);
            //Property(client => client.Account).IsOptional().HasMaxLength(20);
            //HasRequired(client => client.Room).WithMany(room => room.Clients).WillCascadeOnDelete(true);

            ToTable("Subjects");
        }

    }
}