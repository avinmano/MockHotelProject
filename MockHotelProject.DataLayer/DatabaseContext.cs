using Microsoft.EntityFrameworkCore;
using MockHotelProject.DataLayer.Models;

namespace MockHotelProject.DataLayer
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Accomodations> Accomodations { get; set; }

        public DbSet<RoomType> RoomTypes { get; set; }

        public DbSet<Rules> Rules { get; set; }

        public DbSet<PriceList> PriceList { get; set; }

        public DatabaseContext(DbContextOptions options) : base(options)
        {

        }
    }
}