﻿// <auto-generated />
using System;
using DataLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataLayer.Migrations
{
    [DbContext(typeof(DonorsDBContext))]
    partial class DonorsDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DTO.Address", b =>
                {
                    b.Property<Guid>("AddressID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Address2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsPrimary")
                        .HasColumnType("bit");

                    b.Property<Guid>("PersonID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.Property<short>("ZIPCode")
                        .HasColumnType("smallint");

                    b.HasKey("AddressID");

                    b.HasIndex("PersonID");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("DTO.Campaign", b =>
                {
                    b.Property<Guid>("CampaignID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CampaignTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("CreatedBYID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CampaignID");

                    b.HasIndex("CreatedBYID");

                    b.ToTable("Campaign");
                });

            modelBuilder.Entity("DTO.Contact", b =>
                {
                    b.Property<Guid>("ContactID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsPrimary")
                        .HasColumnType("bit");

                    b.Property<Guid>("PersonID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ContactID");

                    b.HasIndex("PersonID");

                    b.ToTable("Contact");
                });

            modelBuilder.Entity("DTO.Donation", b =>
                {
                    b.Property<Guid>("DonationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateDonated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateReviewed")
                        .HasColumnType("datetime2");

                    b.Property<string>("DonationDesc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("DonationForID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<short>("DonationMethod")
                        .HasColumnType("smallint");

                    b.Property<Guid>("DonationRecognizedByID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DonationReviewedByID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<short>("DonationType")
                        .HasColumnType("smallint");

                    b.Property<double>("DonationValue")
                        .HasColumnType("float");

                    b.Property<Guid>("DonorID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsReviewed")
                        .HasColumnType("bit");

                    b.Property<bool>("IsVerified")
                        .HasColumnType("bit");

                    b.Property<string>("Remarks")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DonationID");

                    b.HasIndex("DonationForID");

                    b.HasIndex("DonationRecognizedByID");

                    b.HasIndex("DonationReviewedByID");

                    b.HasIndex("DonorID");

                    b.ToTable("Donations");
                });

            modelBuilder.Entity("DTO.Donor", b =>
                {
                    b.Property<Guid>("DonorID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("PersonID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("DonorID");

                    b.HasIndex("PersonID");

                    b.ToTable("Donors");
                });

            modelBuilder.Entity("DTO.Person", b =>
                {
                    b.Property<Guid>("PersonID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DOB")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("DisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<short?>("Gender")
                        .HasColumnType("smallint");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MiddleName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PersonID");

                    b.ToTable("Person");
                });

            modelBuilder.Entity("DTO.User", b =>
                {
                    b.Property<Guid>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("PersonID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<short>("UserRole")
                        .HasColumnType("smallint");

                    b.HasKey("UserID");

                    b.HasIndex("PersonID")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DTO.Address", b =>
                {
                    b.HasOne("DTO.Person", "Person")
                        .WithMany("Addresses")
                        .HasForeignKey("PersonID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DTO.Campaign", b =>
                {
                    b.HasOne("DTO.User", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedBYID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DTO.Contact", b =>
                {
                    b.HasOne("DTO.Person", "Person")
                        .WithMany("Contacts")
                        .HasForeignKey("PersonID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DTO.Donation", b =>
                {
                    b.HasOne("DTO.Campaign", "DonationFor")
                        .WithMany("Donations")
                        .HasForeignKey("DonationForID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("DTO.User", "DonationRecognizedBy")
                        .WithMany("DonationsRecognized")
                        .HasForeignKey("DonationRecognizedByID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("DTO.User", "DonationReviewedBy")
                        .WithMany("DonationsReviewed")
                        .HasForeignKey("DonationReviewedByID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("DTO.Donor", "Donor")
                        .WithMany("Donations")
                        .HasForeignKey("DonorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DTO.Donor", b =>
                {
                    b.HasOne("DTO.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DTO.User", b =>
                {
                    b.HasOne("DTO.Person", "Person")
                        .WithOne("User")
                        .HasForeignKey("DTO.User", "PersonID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
