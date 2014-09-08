namespace Company.Seeder
{
    using Company.Data;

    public class ProjectGenerator : Generator<Project>
    {
        private const int MIN_NAME_LENGTH = 5;
        private const int MAX_NAME_LENGTH = 50;

        public ProjectGenerator()
            : base()
        {
        }

        protected override Project GetNewItem()
        {
            var project = new Project();
            project.Name = this.generator.GetString(MIN_NAME_LENGTH, MAX_NAME_LENGTH);
            return project;
        }
    }
}
