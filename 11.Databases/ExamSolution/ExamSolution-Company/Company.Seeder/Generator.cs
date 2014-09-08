namespace Company.Seeder
{
    using System.Collections.Generic;

    public abstract class Generator<T> : IGenerator<T> where T: class
    {
        protected RandomDataGenerator generator;
        protected const int MIN_STRING_LENGTH = 3;
        protected const int MAX_STRING_LENGTH = 20;

        public Generator()
        {
            this.generator = new RandomDataGenerator();
        }

        public ICollection<T> GetGeneratedItems(int count)
        {
            IList<T> items = new List<T>();
            for (int i = 0; i < count; i++)
            {
                T newItem = GetNewItem();
                items.Add(newItem);
            }

            return items;
        }

        protected abstract T GetNewItem(); 
    }
}
