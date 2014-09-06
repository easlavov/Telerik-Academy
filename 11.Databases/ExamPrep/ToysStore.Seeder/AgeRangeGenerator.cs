namespace ToysStore.Seeder
{
    using System.Linq;
    using ToysStore.Models;

    public class AgeRangeGenerator : Generator<AgeRange>
    {
        protected override AgeRange GetNewItem()
        {
            var ageRange = new AgeRange();
            int[] values =
            {
                this.generator.GetInt(0, 120),
                this.generator.GetInt(0, 120)
            };
            ageRange.Lower = values.Min();
            ageRange.Upper = values.Max();
            return ageRange;
        }
    }
}
