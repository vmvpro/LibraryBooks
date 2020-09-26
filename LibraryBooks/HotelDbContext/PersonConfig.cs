using System.Data.Entity.ModelConfiguration;
using LibraryBooksClient.Model;

namespace LibraryBooksClient.HotelDbContext
{
    public class PersonConfig : EntityTypeConfiguration<Person>
    {
        public PersonConfig()
        {
            HasKey(person => person.PersonId);
            Property(person => person.FirstName).IsRequired().HasMaxLength(50);
            Property(person => person.LastName).IsRequired().HasMaxLength(50);
            Property(person => person.Birthdate).HasColumnType("datetime2").IsOptional();

            ToTable("People");
        }
    }
}