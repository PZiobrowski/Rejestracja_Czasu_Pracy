using Microsoft.EntityFrameworkCore;
using RCP.Model;

namespace RCP.Database
{
    public class RcpDBContext : DbContext
    {
        public RcpDBContext(DbContextOptions<RcpDBContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Work> Works { get; set; }

        public DbSet<Break> Breaks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Work>(eb =>
            {
                eb.HasKey(w => w.Id);
                eb.HasOne<User>()
                    .WithMany()
                    .HasForeignKey(w => w.UserId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Break>(eb =>
            {
                eb.HasKey(w => w.Id);
                eb.HasOne<User>()
                    .WithMany()
                    .HasForeignKey(w => w.UserId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }

    }
}
