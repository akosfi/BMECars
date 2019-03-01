using System;
using System.Collections.Generic;
using System.Text;

namespace BMECars.Dal.Entities
{
    public class Car
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Image { get; set; }
        public int Price { get; set; }
        public int Year { get; set; }
        public int Seat { get; set; }
        public int Bag { get; set; }
        public int Door { get; set; }
        public Category Category { get; set; }
        public Transmission Transmission { get; set; }
        public Boolean IsFuelFull { get; set; }
        public Boolean Climate { get; set; }

        public int CompanyId { get; set; }
        public Company Company { get; set; }

        public ICollection<Reservation> Reservations { get; set; }
        public ICollection<CarExtra> CarExtras { get; set; }

        public int PickUpLocationId { get; set; }
        public Location PickUpLocation { get; set; }

    }
    public enum Category
    {
        Hatchback,
        Sedan,
        MPV,
        SUV,
        Crossover,
        Coupe,
        Convertible
    }
    public enum Transmission
    {
        Automatic,
        Manual
    }

}
