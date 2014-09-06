namespace ToysStore.ConsoleClient
{
    using System.Linq;
    using System.Data.Entity;

    using ToysStore.Data;
    using ToysStore.Models;
    using ToysStore.Seeder;

    class Program
    {
        static void Main(string[] args)
        {
            var toyStoreModel = new ToyStoreModel();
            //SeedDatabase(toyStoreModel);

            var count = toyStoreModel.Manufacturers.Select(man => new
            {
                Name = man.Name,
                Count = toyStoreModel.Toys.Where(toy => toy.Manufacturer.Name == man.Name
                                                 && toy.AgeRanx.Lower > 15
                                                 && toy.AgeRanx.Upper < 60).Count()
            });

            foreach (var item in count)
            {
                System.Console.WriteLine("{0} - {1}", item.Name, item.Count);
            }
        }
 
        private static void SeedDatabase(ToyStoreModel toyStoreModel)
        {
            toyStoreModel.Configuration.AutoDetectChangesEnabled = false;

            var manufGener = new ManufacturerGenerator();
            var catGener = new CategoryGenerator();
            var aRGener = new AgeRangeGenerator();

            var manufacturers = manufGener.GetGeneratedItems(50);
            var categories = catGener.GetGeneratedItems(100);
            var ageRanges = aRGener.GetGeneratedItems(99);

            var manSeeder = new Seeder<Manufacturer>(toyStoreModel.Manufacturers, manufacturers, toyStoreModel);
            manSeeder.Seed();

            var catSeeder = new Seeder<Category>(toyStoreModel.Categories, categories, toyStoreModel);
            catSeeder.Seed();

            var aRSeeder = new Seeder<AgeRange>(toyStoreModel.AgeRanges, ageRanges, toyStoreModel);
            aRSeeder.Seed();

            var toysGener = new ToyGenerator(
                categories, manufacturers, ageRanges);
            var toys = toysGener.GetGeneratedItems(20000);
            var toysSeeder = new Seeder<Toy>(toyStoreModel.Toys, toys, toyStoreModel);
            toysSeeder.Seed();

            toyStoreModel.Configuration.AutoDetectChangesEnabled = true;
        }
    }
}
