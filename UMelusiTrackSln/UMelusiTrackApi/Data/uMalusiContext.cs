using Microsoft.EntityFrameworkCore;
using UMelusiTrackApi.Models;

namespace UMelusiTrackApi.Data
{
    public class uMalusiContext : DbContext
    {
        public uMalusiContext(DbContextOptions options)
          : base(options)
        {



        }

        public DbSet<Farmer> Farmers { get; set; }
        public DbSet<Livestock> Livestocks { get; set; }

        public DbSet<LivestockPosition> LivestockPositions { get; set; }
     //   public DbSet<Authentication> Authentications { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Tracker> Trackers { get; set; }
        public DbSet<LivestockType> LivestockTypes { get; set; }

    }
}
