namespace Cars.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    using Cars.Models;

    public class CarsDataContext : DbContext
    {
        public CarsDataContext()
            : base("Cars")
        {
        }

        public IDbSet<Car> Cars { get; set; }

        public IDbSet<Manufacturer> Manufacturers { get; set; }

        public IDbSet<City> Cities { get; set; }

        public IDbSet<Dealer> Dealers { get; set; }
    }
}
