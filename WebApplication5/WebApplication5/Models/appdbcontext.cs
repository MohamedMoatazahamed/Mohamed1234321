using Microsoft.EntityFrameworkCore;

namespace WebApplication5.Models
{
    public class appdbcontext :DbContext
    {
        public appdbcontext(DbContextOptions<appdbcontext> options) : base(options) { }
      public DbSet<task> tasks { get; set; }
        public DbSet<Project> projects { get; set; }
        public DbSet<TeamMember> teamMembers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<task>().HasOne(i=>i.Project).WithMany(p=>p.Tasks).HasForeignKey(i=>i.projectID).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<task>().HasOne(h=>h.TeamMember).WithMany(u=>u.Tasks).HasForeignKey(i=>i.TeamId).OnDelete(DeleteBehavior.Cascade);
            base.OnModelCreating(modelBuilder);
        }
    }
}
