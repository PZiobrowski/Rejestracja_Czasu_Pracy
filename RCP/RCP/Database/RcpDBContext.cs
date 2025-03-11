using Microsoft.EntityFrameworkCore;
using RCP.Model;

namespace RCP.Database
{
    public partial class RcpDbContext : DbContext
    {
        public RcpDbContext(DbContextOptions<RcpDbContext> options) : base(options)
        {
        }
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(eb =>
            {
                eb.HasKey(w => w.Id);
                eb.Property(w => w.Id).HasComment("Identyfikator");
                eb.Property(w => w.FirstName).HasComment("Imię");
                eb.Property(w => w.Lastname).HasComment("Nazwisko");
            });

            modelBuilder.Entity<Work>(eb =>
            {
                eb.HasKey(w => w.Id);
                eb.HasOne<User>()
                    .WithMany()
                    .HasForeignKey(w => w.UserId)
                    .OnDelete(DeleteBehavior.Cascade);

                eb.Property(w => w.Id).HasComment("Identyfikator");
                eb.Property(w => w.StartTime).HasComment("Czas rozpoczęcia pracy");
                eb.Property(w => w.EndTime).HasComment("Czas zakończenia pracy");
                eb.Property(w => w.UserId).HasComment("Identyfikator użytkownika");
            });

            modelBuilder.Entity<Break>(eb =>
            {
                eb.HasKey(w => w.Id);
                eb.HasOne<User>()
                    .WithMany()
                    .HasForeignKey(w => w.UserId)
                    .OnDelete(DeleteBehavior.Cascade);

                eb.Property(w => w.Id).HasComment("Identyfikator");
                eb.Property(w => w.StartTime).HasComment("Czas rozpoczęcia pracy");
                eb.Property(w => w.EndTime).HasComment("Czas zakończenia pracy");
                eb.Property(w => w.UserId).HasComment("Identyfikator użytkownika");
            });
        }

    }
}
