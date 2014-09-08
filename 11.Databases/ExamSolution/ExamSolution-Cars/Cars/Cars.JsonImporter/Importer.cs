namespace Cars.JsonImporter
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    using Cars.Data;
    using Cars.Models;
    using Newtonsoft.Json;

    public class Importer
    {
        private const int FLUSH_TRESHOLD = 100;
        private string path;
        private CarsDataContext context;

        public Importer(string folderPath, CarsDataContext carsContext)
        {
            this.path = folderPath;
            this.context = carsContext;
        }

        public void Import()
        {
            this.context.Configuration.AutoDetectChangesEnabled = false;
            var filePaths = Directory.GetFiles(this.path);
            foreach (var file in filePaths)
            {
                StreamReader sr = new StreamReader(file);
                string json = sr.ReadToEnd();
                var cars = ParseJson(json);
                this.ImportCarInfo(cars);
            }

            this.context.Configuration.AutoDetectChangesEnabled = false;
        }

        private CarInfo[] ParseJson(string json)
        {
            var carsArray = JsonConvert.DeserializeObject<CarInfo[]>(json);
            return carsArray;
        }

        private void ImportCarInfo(ICollection<CarInfo> cars)
        {
            int counter = 0;
            foreach (var car in cars)
            {
                // Manufacturer and city are unique
                var newCar = new Car();
                newCar.Year = car.Year;

                if (car.TransmissionType == 0)
                {
                    newCar.TransmissionType = TransmissionType.Manual;
                }
                else
                {
                    newCar.TransmissionType = TransmissionType.Automatic;
                }

                newCar.Model = car.Model;
                newCar.Price = decimal.Parse(car.Price);

                newCar.Dealer = GetDealer(car.Dealer);

                newCar.ManufacturerName = GetManufacturer(car.ManufacturerName);

                this.context.Cars.Add(newCar);
                counter++;

                if (counter == FLUSH_TRESHOLD)
                {
                    this.context.SaveChanges();
                    counter = 0;
                }

                Console.Write('.');
            }

            this.context.SaveChanges();
            Console.WriteLine();
        }

        private Manufacturer GetManufacturer(string manufacturerName)
        {
            Manufacturer manufacturer;
            int isPresent = this.context.Manufacturers.Count(man => man.Name == manufacturerName);
            if (isPresent == 1)
            {
                manufacturer = this.context.Manufacturers.First(man => man.Name == manufacturerName);
            }
            else
            {
                manufacturer = new Manufacturer();
                manufacturer.Name = manufacturerName;
                this.context.Manufacturers.Add(manufacturer);
            }

            return manufacturer;
        }

        private Dealer GetDealer(DealerInfo dealerInfo)
        {
            string dealerName = dealerInfo.Name;
            Dealer dealer;
            int isDealerPresent = this.context.Dealers.Count(deal => deal.Name == dealerName);
            if (isDealerPresent == 1)
            {
                dealer = this.context.Dealers.First(deal => deal.Name == dealerName);
            }
            else
            {
                dealer = new Dealer();
                dealer.Name = dealerName;
            }

            string cityName = dealerInfo.City;
            City city;
            int isCityPresent = this.context.Cities.Count(cit => cit.Name == cityName);
            if (isCityPresent == 1)
            {
                city = this.context.Cities.First(cit => cit.Name == cityName);
                dealer.Cities.Add(city);
            }
            else
            {
                city = new City();
                city.Name = cityName;
            }

            if (isDealerPresent == 0)
            {
                this.context.Dealers.Add(dealer);
            }

            if (isCityPresent == 0)
            {
                this.context.Cities.Add(city);
            }

            city.Dealers.Add(dealer);
            dealer.Cities.Add(city);

            return dealer;
        }
    }
}
