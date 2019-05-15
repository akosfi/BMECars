﻿// <auto-generated />
using System;
using BMECars.Dal;
using BMECars.Dal.Entities;
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

                    b.Property<string>("Plate");

                    b.Property<int>("Price");

                    b.Property<int>("Seat");

                    b.Property<int>("Transmission");

                    b.Property<int>("Year");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("PickUpLocationId");

                    b.ToTable("Cars");

                    b.HasData(
                        new { Id = 1, Bag = 2, Brand = "Audi", Category = 5, Climate = true, CompanyId = 1, Door = 2, IsFuelFull = true, PickUpLocationId = 1, Plate = "MBD-234", Price = 10000, Seat = 2, Transmission = 0, Year = 2018 },
                        new { Id = 2, Bag = 3, Brand = "BMW", Category = 3, Climate = true, CompanyId = 1, Door = 4, IsFuelFull = true, PickUpLocationId = 1, Plate = "XAD-113", Price = 15000, Seat = 5, Transmission = 0, Year = 2019 },
                        new { Id = 3, Bag = 5, Brand = "Toyota", Category = 2, Climate = true, CompanyId = 2, Door = 6, IsFuelFull = false, PickUpLocationId = 2, Plate = "AEF-532", Price = 6000, Seat = 7, Transmission = 1, Year = 2006 },
                        new { Id = 4, Bag = 5, Brand = "BMW", Category = 2, Climate = true, CompanyId = 2, Door = 6, IsFuelFull = false, PickUpLocationId = 2, Plate = "XVF-532", Price = 6000, Seat = 7, Transmission = 1, Year = 2006 },
                        new { Id = 5, Bag = 5, Brand = "Porsche", Category = 5, Climate = true, CompanyId = 1, Door = 6, IsFuelFull = false, PickUpLocationId = 2, Plate = "XXX-532", Price = 6000, Seat = 7, Transmission = 1, Year = 2006 },
                        new { Id = 6, Bag = 5, Brand = "Mercedes", Category = 1, Climate = true, CompanyId = 2, Door = 6, IsFuelFull = false, PickUpLocationId = 2, Plate = "AAA-111", Price = 6000, Seat = 7, Transmission = 1, Year = 2006 }
                    );
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

                    b.Property<string>("Name");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Companies");

                    b.HasData(
                        new { Id = 1, Name = "Avis Cars", UserId = "fbc5fe4c-7f97-4969-9937-23a191322bfd" },
                        new { Id = 2, Name = "Bárdi Autó", UserId = "fbc5fe4c-7f97-4969-9937-23a191322bfd" },
                        new { Id = 3, Name = "Hertz", UserId = "fbc5fe4c-7f97-4969-9937-23a191322bfd" },
                        new { Id = 4, Name = "Europcar", UserId = "fbc5fe4c-7f97-4969-9937-23a191322bfd" }
                    );
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

                    b.HasData(
                        new { Id = 1, Address = "Ferihegy Repülőtér", City = "Budapest", CompanyId = 1, Country = "Hungary", IsGlobal = true },
                        new { Id = 2, Address = "Vasútállomás", City = "Gyor", CompanyId = 2, Country = "Hungary", IsGlobal = true },
                        new { Id = 3, Address = "Vasútállomás", City = "Szeged", CompanyId = 3, Country = "Hungary", IsGlobal = true },
                        new { Id = 4, Address = "Vasútállomás", City = "Pécs", CompanyId = 4, Country = "Hungary", IsGlobal = true }
                    );
                });

            modelBuilder.Entity("BMECars.Dal.Entities.Reservation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Accepted")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(1);

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

                    b.HasData(
                        new { Id = "fbc5fe4c-7f97-4969-9937-23a191322bfd", AccessFailedCount = 0, BirthDate = new DateTime(1997, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), ConcurrencyStamp = "c1992773-b941-40af-87f3-9991892bae19", Email = "fiakos1997@gmail.com", EmailConfirmed = false, FullName = "Ákos Fi", LockoutEnabled = true, NormalizedEmail = "FIAKOS1997@GMAIL.COM", NormalizedUserName = "FIAKOS1997@GMAIL.COM", PasswordHash = "AQAAAAEAACcQAAAAEHEccHu8dGLfeafq8WjGtG0F8F0LB9v0VOgzHkOmHawqpk6CECLVSzW4KrnZshyddQ==", PhoneNumber = "+232323232", PhoneNumberConfirmed = false, SecurityStamp = "GKE4DV6AXE77LQKJ46VVDCQBJFO63FKT", TwoFactorEnabled = false, UserName = "fiakos1997@gmail.com" }
                    );
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
