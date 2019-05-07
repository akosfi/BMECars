using System;
using System.Collections.Generic;
using System.Text;
using BMECars.Dal.Entities;

namespace BMECars.Dal.SeedService
{
    public class SeedService : ISeedService
    {
        private string userId = "fbc5fe4c-7f97-4969-9937-23a191322bfd";

        public IList<Company> Companies { get; }
        public IList<Location> Locations { get; }
        public IList<Car> Cars { get; }
        public IList<User> Users { get; }
        public IList<Reservation> Reservations { get; }


        public SeedService()
        {
            Companies = new List<Company>()
            {
                new Company { Id = 1, Name = "Avis Cars", UserId = userId },
                new Company { Id = 2, Name = "Bárdi Autó", UserId = userId },
                new Company { Id = 3, Name = "Hertz", UserId = userId },
                new Company { Id = 4, Name = "Europcar", UserId = userId }
            };

            Locations = new List<Location>()
            {
                new Location {
                    Id = 1,
                    Country = "Hungary",
                    City = "Budapest",
                    Address = "Ferihegy Repülőtér",
                    IsGlobal = true,
                    CompanyId = 1
                },
                new Location {
                    Id = 2,
                    Country = "Hungary",
                    City = "Gyor",
                    Address = "Vasútállomás",
                    IsGlobal = true,
                    CompanyId = 2
                },
                new Location {
                    Id = 3,
                    Country = "Hungary",
                    City = "Szeged",
                    Address = "Vasútállomás",
                    IsGlobal = true,
                    CompanyId = 3
                },
                new Location {
                    Id = 4,
                    Country = "Hungary",
                    City = "Pécs",
                    Address = "Vasútállomás",
                    IsGlobal = true,
                    CompanyId = 4
                }
            };

            Cars = new List<Car>()
            {
                new Car
                {
                    Id = 1,
                    Brand = "Audi",
                    Bag = 2,
                    Climate = true,
                    Category = Category.Coupe,
                    CompanyId = 1,
                    Door = 2,
                    IsFuelFull = true,
                    PickUpLocationId = 1,
                    Plate = "MBD-234",
                    Price = 10000,
                    Seat = 2,
                    Transmission = Transmission.Automatic,
                    Year = 2018
                },
                new Car
                {
                    Id = 2,
                    Brand = "BMW",
                    Bag = 3,
                    Climate = true,
                    Category = Category.SUV,
                    CompanyId = 1,
                    Door = 4,
                    IsFuelFull = true,
                    PickUpLocationId = 1,
                    Plate = "XAD-113",
                    Price = 15000,
                    Seat = 5,
                    Transmission = Transmission.Automatic,
                    Year = 2019
                },
                new Car
                {
                    Id = 3,
                    Brand = "Toyota",
                    Bag = 5,
                    Climate = true,
                    Category = Category.MPV,
                    CompanyId = 2,
                    Door = 6,
                    IsFuelFull = false,
                    PickUpLocationId = 2,
                    Plate = "AEF-532",
                    Price = 6000,
                    Seat = 7,
                    Transmission = Transmission.Manual,
                    Year = 2006
                },
                new Car
                {
                    Id = 4,
                    Brand = "BMW",
                    Bag = 5,
                    Climate = true,
                    Category = Category.MPV,
                    CompanyId = 2,
                    Door = 6,
                    IsFuelFull = false,
                    PickUpLocationId = 2,
                    Plate = "XVF-532",
                    Price = 6000,
                    Seat = 7,
                    Transmission = Transmission.Manual,
                    Year = 2006
                },
                new Car
                {
                    Id = 5,
                    Brand = "Porsche",
                    Bag = 5,
                    Climate = true,
                    Category = Category.Coupe,
                    CompanyId = 1,
                    Door = 6,
                    IsFuelFull = false,
                    PickUpLocationId = 2,
                    Plate = "XXX-532",
                    Price = 6000,
                    Seat = 7,
                    Transmission = Transmission.Manual,
                    Year = 2006
                },
                new Car
                {
                    Id = 6,
                    Brand = "Mercedes",
                    Bag = 5,
                    Climate = true,
                    Category = Category.Sedan,
                    CompanyId = 2,
                    Door = 6,
                    IsFuelFull = false,
                    PickUpLocationId = 2,
                    Plate = "AAA-111",
                    Price = 6000,
                    Seat = 7,
                    Transmission = Transmission.Manual,
                    Year = 2006
                }
            };

            Users = new List<User>()
            {
                new User
                {
                    Id = userId,
                    Email = "fiakos1997@gmail.com",
                    UserName = "fiakos1997@gmail.com",
                    NormalizedUserName = "FIAKOS1997@GMAIL.COM",
                    NormalizedEmail = "FIAKOS1997@GMAIL.COM",
                    EmailConfirmed = false,
                    PasswordHash = "AQAAAAEAACcQAAAAEHEccHu8dGLfeafq8WjGtG0F8F0LB9v0VOgzHkOmHawqpk6CECLVSzW4KrnZshyddQ==",
                    SecurityStamp = "GKE4DV6AXE77LQKJ46VVDCQBJFO63FKT",
                    ConcurrencyStamp = "c1992773-b941-40af-87f3-9991892bae19",
                    PhoneNumber = "+232323232",
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false,
                    LockoutEnabled = true,
                    AccessFailedCount = 0,
                    BirthDate = new DateTime(1997,11,25),
                    FullName = "Ákos Fi"
                }
            };

            Reservations = new List<Reservation>()
            {
               
            };
        }
    }
}
