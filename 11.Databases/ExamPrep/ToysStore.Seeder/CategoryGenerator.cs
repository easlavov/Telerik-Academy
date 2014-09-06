namespace ToysStore.Seeder
{
    using ToysStore.Models;

    public class CategoryGenerator : Generator<Category>
    {
        public CategoryGenerator()
            : base()
        {
        }

        protected override Category GetNewItem()
        {
            var category = new Category();
            category.Name = this.generator.GetString(MIN_STRING_LENGTH, MAX_STRING_LENGTH);
            return category;
        }
    }
}
