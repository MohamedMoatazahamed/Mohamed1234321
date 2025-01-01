using Microsoft.EntityFrameworkCore;

namespace Hospitall.Models
{
    public class appdbcontext:DbContext
    {
        public appdbcontext(DbContextOptions<appdbcontext> options)
    : base(options) { }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Appointment> appointments  { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>().HasKey(i => i.PatId);
            modelBuilder.Entity<Doctor>().HasKey(i => i.DocID);
            modelBuilder.Entity<Appointment>().HasKey(i => i.Id);
            modelBuilder.Entity<Appointment>().HasOne(y => y.Patient).WithMany(i => i.Appointments).HasForeignKey(u=>u.PatId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Appointment>().HasOne(i => i.Doctor).WithMany(o => o.Appointments).HasForeignKey(y => y.DoctId).OnDelete(DeleteBehavior.Cascade);
            base.OnModelCreating(modelBuilder);
        }

    }
}
