using Microsoft.EntityFrameworkCore;

namespace LibraryMAngeSystem.Models
{
    public class appdbcontext:DbContext
    {
        public appdbcontext(DbContextOptions<appdbcontext> options) : base (options) { }
        public DbSet<Book> books { get; set; }
        public DbSet<Member> members { get; set; }
        public DbSet<BorrowRecord> borrowRecords { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BorrowRecord>().HasKey(i => i.BorrowId);
            modelBuilder.Entity<BorrowRecord>().HasOne(u=>u.Book).WithMany(o=>o.BorrowRecords).HasForeignKey(y=>y.Booid).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<BorrowRecord>().HasOne(i=>i.Member).WithMany(u=>u.BorrowRecords).HasForeignKey(h=>h.MemID).OnDelete(DeleteBehavior.Cascade);
            base.OnModelCreating(modelBuilder);
        }

    }
}
