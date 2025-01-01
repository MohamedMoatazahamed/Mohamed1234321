using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Options;
using schoolsystem.Models.viewmodel;

namespace schoolsystem.Models
{
    public class appdbcontext : DbContext
    {

        public appdbcontext(DbContextOptions<appdbcontext> options) :base (options) {  }
        
     
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Class> Classs { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Enrollment>().HasOne(u => u.student).WithMany(j => j.Enrollments).HasForeignKey(k=>k.studentId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Enrollment>().HasOne(u=>u.Teacher).WithMany(i=>i.Enrollments).HasForeignKey(o=>o.teatherID).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Enrollment>().HasOne(w=>w.class1).WithMany(m=>m.Enrollments).HasForeignKey(y=>y.classId).OnDelete(DeleteBehavior.Restrict);
            base.OnModelCreating(modelBuilder);
        }
     


    }
}
