using Microsoft.EntityFrameworkCore;
using MockHotelProject.DataLayer.Models;

namespace MockHotelProject.DataLayer
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Accomodations> Accomodations { get; set; }

        public DbSet<RoomType> RoomTypes { get; set; }

        public DbSet<PriceList> PriceLists { get; set; }

        public DbSet<AccomodationRoomType> AccomodationRoomTypes { get; set; }

        public DbSet<Booking> Bookings { get; set; }

        public DbSet<Rules> Rules { get; set; }

        public DatabaseContext(DbContextOptions options) : base(options)
        {

        }
    }
}