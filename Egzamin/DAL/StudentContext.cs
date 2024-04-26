using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
namespace DAL
{
    public class StudentContext : DbContext
    {

        public DbSet<Student> students { get; set; }
        public DbSet<Models.Group> groups { get; set; }
        public DbSet<History> history { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=PUKOL1;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                 .HasOne(s => s.Grupa)
                 .WithMany()
                 .HasForeignKey(s => s.GrupaId)
                 .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<History>()
                .HasOne(h => h.Grupa)
                .WithMany()
                .HasForeignKey(h => h.GrupaId)
                .OnDelete(DeleteBehavior.Restrict);
        }

    }
}
