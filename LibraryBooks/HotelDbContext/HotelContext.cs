using System.Data.Entity;
using LibraryBooksClient.Model;

namespace LibraryBooksClient.HotelDbContext
{
    public class HotelContext : DbContext
    {
        public HotelContext()
            : base("name=LibraryBooksNewVMVConnectionString")
        {
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<HotelContext, LibraryBooksClient.Migrations.Configuration>());
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Room> Rooms { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new PersonConfig());
            modelBuilder.Configurations.Add(new ClientConfig());
            modelBuilder.Configurations.Add(new RoomConfig());
        }
    }
}