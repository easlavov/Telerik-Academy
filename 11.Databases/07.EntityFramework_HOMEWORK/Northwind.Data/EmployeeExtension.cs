namespace Northwind.Data
{
    using System;
    using System.Data.Linq;
    using System.Linq;

    public partial class Employee
    {
        // By inheriting the Employee entity class create a class 
        // which allows employees to access their 
        // corresponding territories as property of type 
        // EntitySet<T>.
        public EntitySet<Territory> TerritoriesEntitySet
        {
            get
            {                
                var territories = new EntitySet<Territory>();
                territories.AddRange(this.Territories);
                return territories;
            }
        }
    }
}
