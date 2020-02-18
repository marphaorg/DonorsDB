using System;
using DTO;
using Microsoft.EntityFrameworkCore;
namespace DataLayer
{
    public class DonorsDBContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=SQL5041.site4now.net;Initial Catalog=DB_9E3EC8_donorsdb;User Id=DB_9E3EC8_donorsdb_admin;Password=iamDb2020;");
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Donor> Donors { get; set; }
        public DbSet<Donation> Donations { get; set; }
        public DbSet<Campaign> Campaigns { get; set; }

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

            modelBuilder.Entity<Donation>()
                .HasOne(r => r.DonationFor)
                .WithMany(r => r.Donations)
                .HasForeignKey(r => r.DonationForID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Campaign>()
                .HasOne(r => r.ManagedBy)
                .WithMany(r => r.CampaignsManaged)
                .HasForeignKey(r => r.CampaignID)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
