using System;
using DTO;
using Microsoft.EntityFrameworkCore;
namespace DataLayer
{
    public class DonorsDBContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("DonorsDBContext");
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Donor> Donors { get; set; }
        public DbSet<Donation> Donations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Donation>()
                .HasOne(r => r.DonationRecognizedBy)
                .WithMany(r => r.DonationsRecognized)
                .HasForeignKey(r => r.DonationRecognizedByID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Donation>()
                .HasOne(r => r.DonationReviewedBy)
                .WithMany(r => r.DonationsReviewed)
                .HasForeignKey(r => r.DonationReviewedByID)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
