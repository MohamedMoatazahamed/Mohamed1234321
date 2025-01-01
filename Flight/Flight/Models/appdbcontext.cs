using Microsoft.EntityFrameworkCore;

namespace FlightSystem.Models
{
    public class appdbcontext:DbContext
    {
        public appdbcontext(DbContextOptions<appdbcontext> options):base(options) { }
         public DbSet<Flight> flights { get; set; }
        public DbSet<Passenger> passengers { get; set; }
        public DbSet<Reservation> reservations { get; set; }
     


    }
}
