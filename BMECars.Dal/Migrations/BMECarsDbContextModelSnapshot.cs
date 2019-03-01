﻿// <auto-generated />
using System;
using BMECars.Dal;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BMECars.Dal.Migrations
{
    [DbContext(typeof(BMECarsDbContext))]
    partial class BMECarsDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BMECars.Dal.Entities.BillingData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<string>("City");

                    b.Property<string>("Company");

                    b.Property<string>("Country");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("Postal");

                    b.Property<string>("State");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique()
                        .HasFilter("[UserId] IS NOT NULL");

                    b.ToTable("BillingDatas");
                });

            modelBuilder.Entity("BMECars.Dal.Entities.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Bag");

                    b.Property<string>("Brand");

                    b.Property<int>("Category");

                    b.Property<bool>("Climate");

                    b.Property<int>("CompanyId");

                    b.Property<int>("Door");

                    b.Property<string>("Image");

                    b.Property<bool>("IsFuelFull");

                    b.Property<int>("PickUpLocationId");

                    b.Property<int>("Price");

                    b.Property<int>("Seat");

                    b.Property<int>("Transmission");

                    b.Property<int>("Year");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("PickUpLocationId");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("BMECars.Dal.Entities.CarExtra", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CarId");

                    b.Property<int>("ExtraId");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.HasIndex("ExtraId");

                    b.ToTable("CarExtras");
                });

            modelBuilder.Entity("BMECars.Dal.Entities.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Name");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("BMECars.Dal.Entities.CompanyAdmin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CompanyId");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("UserId");

                    b.ToTable("CompanyAdmins");
                });

            modelBuilder.Entity("BMECars.Dal.Entities.Extra", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Extras");
                });

            modelBuilder.Entity("BMECars.Dal.Entities.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<string>("City");

                    b.Property<int?>("CompanyId");

                    b.Property<string>("Country");

                    b.Property<bool>("IsGlobal");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("BMECars.Dal.Entities.Reservation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CarId");

                    b.Property<int>("DropDownLocationId");

                    b.Property<int>("PickUpLocationId");

                    b.Property<int>("ReservationPrice");

                    b.Property<DateTime>("ReserveFrom");

                    b.Property<DateTime>("ReserveTo");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.HasIndex("DropDownLocationId");

                    b.HasIndex("PickUpLocationId");

                    b.HasIndex("UserId");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("BMECars.Dal.Entities.User", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<DateTime>("BirthDate");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FullName");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("Password");

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasMaxLength(128);

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("BMECars.Dal.Entities.BillingData", b =>
                {
                    b.HasOne("BMECars.Dal.Entities.User", "User")
                        .WithOne("BillingData")
                        .HasForeignKey("BMECars.Dal.Entities.BillingData", "UserId");
                });

            modelBuilder.Entity("BMECars.Dal.Entities.Car", b =>
                {
                    b.HasOne("BMECars.Dal.Entities.Company", "Company")
                        .WithMany("Cars")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("BMECars.Dal.Entities.Location", "PickUpLocation")
                        .WithMany("Cars")
                        .HasForeignKey("PickUpLocationId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("BMECars.Dal.Entities.CarExtra", b =>
                {
                    b.HasOne("BMECars.Dal.Entities.Car", "Car")
                        .WithMany("CarExtras")
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("BMECars.Dal.Entities.Extra", "Extra")
                        .WithMany("CarExtras")
                        .HasForeignKey("ExtraId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("BMECars.Dal.Entities.Company", b =>
                {
                    b.HasOne("BMECars.Dal.Entities.User", "Owner")
                        .WithMany("Companies")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("BMECars.Dal.Entities.CompanyAdmin", b =>
                {
                    b.HasOne("BMECars.Dal.Entities.Company", "Company")
                        .WithMany("CompanyAdmins")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("BMECars.Dal.Entities.User", "User")
                        .WithMany("CompanyAdmins")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("BMECars.Dal.Entities.Location", b =>
                {
                    b.HasOne("BMECars.Dal.Entities.Company", "Company")
                        .WithMany("PickUpLocations")
                        .HasForeignKey("CompanyId");
                });

            modelBuilder.Entity("BMECars.Dal.Entities.Reservation", b =>
                {
                    b.HasOne("BMECars.Dal.Entities.Car", "Car")
                        .WithMany("Reservations")
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("BMECars.Dal.Entities.Location", "DropDownLocation")
                        .WithMany("ReservationsDropDown")
                        .HasForeignKey("DropDownLocationId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("BMECars.Dal.Entities.Location", "PickUpLocation")
                        .WithMany("ReservationsPickUp")
                        .HasForeignKey("PickUpLocationId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("BMECars.Dal.Entities.User", "User")
                        .WithMany("Reservations")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("BMECars.Dal.Entities.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("BMECars.Dal.Entities.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BMECars.Dal.Entities.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("BMECars.Dal.Entities.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
