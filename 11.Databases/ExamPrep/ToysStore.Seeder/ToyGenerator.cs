namespace ToysStore.Seeder
{
    using System.Collections.Generic;
    using System.Linq;
    using ToysStore.Models;

    public class ToyGenerator : Generator<Toy>
    {
        private ICollection<Category> categories;
        private ICollection<Manufacturer> manufacturers;
        private ICollection<AgeRange> ageRanges;

        public ToyGenerator(ICollection<Category> categories, ICollection<Manufacturer> manufacturer, ICollection<AgeRange> ageRanges)
            : base()
        {
            this.categories = categories;
            this.manufacturers = manufacturer;
            this.ageRanges = ageRanges;
        }

        protected override Toy GetNewItem()
        {
            var toy = new Toy();
            toy.Name = this.generator.GetString(MIN_STRING_LENGTH, MAX_STRING_LENGTH);
            toy.Type = this.generator.GetString(MIN_STRING_LENGTH, MAX_STRING_LENGTH);

            toy.Category = this.categories.First(
                cat => cat.ID == this.generator.GetInt(1, this.categories.Count));

            toy.Manufacturer = this.manufacturers.First(
                cat => cat.ID == this.generator.GetInt(1, this.manufacturers.Count));

            toy.Price = (decimal)this.generator.GetDouble(); // Possible exception
            toy.Color = this.generator.GetString(MIN_STRING_LENGTH, MAX_STRING_LENGTH);
            toy.AgeRanx = this.ageRanges.First(
                ar => ar.ID == this.generator.GetInt(1, this.ageRanges.Count));

            return toy;
        }
    }
}
