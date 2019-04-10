using BMECars.Dal.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BMECars.Dal.SeedService
{
    public interface ISeedService
    {
        IList<Company> Companies { get; }
        IList<Location> Locations { get; }
        IList<Car> Cars { get; }
        IList<User> Users { get; }
        IList<Reservation> Reservations { get; }
    }
}
