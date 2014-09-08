namespace Cars.JsonImporter
{
    internal class CarInfo
    {

        public string Model { get; set; }

        public int Year { get; set; }

        public string Price { get; set; }

        public int TransmissionType { get; set; }

        public string ManufacturerName { get; set; }

        public DealerInfo Dealer { get; set; }
    }
}
