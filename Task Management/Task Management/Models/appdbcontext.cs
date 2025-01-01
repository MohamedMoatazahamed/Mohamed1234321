using Microsoft.EntityFrameworkCore;

namespace Task_Management.Models
{
    public class appdbcontext:DbContext
    {
        public appdbcontext(DbContextOptions<appdbcontext> options) :base(options) { }  
        public DbSet<User> Users { get; set; }
        public DbSet<Task1> tasks { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Task1>().HasKey(i => i.TaskId);
            modelBuilder.Entity<Task1>().HasOne(i=>i.User).WithMany(u=>u.Tasks).HasForeignKey(i=>i.TaskId).OnDelete(DeleteBehavior.Restrict);
            base.OnModelCreating(modelBuilder);
        }



    }
}
