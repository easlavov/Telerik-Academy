namespace Company.Seeder
{
    using Company.Models;

    public class DepartmentGenerator : Generator<Department>
    {
        private const int MIN_NAME_LENGTH = 10;
        private const int MAX_NAME_LENGTH = 47;
        private int counter;

        public DepartmentGenerator()
            : base()
        {
            this.counter = 0;
        }

        protected override Department GetNewItem()
        {
            var dept = new Department();

            // Adding counter ensures an unique name
            dept.Name = this.generator.GetString(MIN_NAME_LENGTH, MAX_NAME_LENGTH) + this.counter;
            this.counter++;
            return dept;
        }
    }
}
