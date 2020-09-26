using System.Data.Entity.ModelConfiguration;
using LibraryBooksClient.Model;

namespace LibraryBooksClient.HotelDbContext
{
    public class RoomConfig : EntityTypeConfiguration<Room>
    {
        public RoomConfig()
        {
            HasKey(room => room.RoomId);
            Property(room => room.Number).IsRequired().HasMaxLength(5);
            Property(room => room.Type).IsRequired();

            ToTable("Rooms");
        }
    }
}