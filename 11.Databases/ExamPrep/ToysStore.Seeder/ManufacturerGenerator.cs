namespace ToysStore.Seeder
{
    using System;
    using ToysStore.Models;

    public class ManufacturerGenerator : Generator<Manufacturer>
    {
        public ManufacturerGenerator()
            : base()
        {
        }

        protected override Manufacturer GetNewItem()
        {
            var manufacturer = new Manufacturer();
            manufacturer.Name = Guid.NewGuid();
            manufacturer.Country = this.generator.GetString(MIN_STRING_LENGTH, MAX_STRING_LENGTH);
            return manufacturer;
        }
    }
}
