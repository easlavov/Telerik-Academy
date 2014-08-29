// Create a DAO class with static methods which 
// provide functionality for inserting, modifying and 
// deleting customers. Write a testing class.
namespace Northwind.DataAccessObject
{
    using System;
    using System.Linq;
    using Northwind.Data;

    public static class DataAcessObject
    {
        private const int CUSTOMER_ID_LENGTH = 5;

        /// <summary>
        /// Inserts a customer in the Northwind database.
        /// </summary>
        /// <param name="name">The name of the customer/</param>
        public static void InsertCustomer(string name, string id)
        {
            ValidateCustomerIdLength(id);

            var db = new NorthwindEntities();
            var customer = new Customer();
            customer.CompanyName = name;
            customer.CustomerID = id;
            db.Customers.Add(customer);
            db.SaveChanges();
        }

        /// <summary>
        /// Changes the company name of a selected customer in the Northwind database.
        /// </summary>
        /// <param name="customerId">The id of the customer.</param>
        /// <param name="newName">The customers' new name.</param>
        public static void ModifyCustomerName(string customerId, string newName)
        {
            ValidateCustomerIdLength(customerId);

            var db = new NorthwindEntities();
            var customer = db.Customers.First(x => x.CustomerID == customerId);
            customer.CompanyName = newName;
            db.SaveChanges();
        }

        /// <summary>
        /// Deletes a customer from the Northwind database.
        /// </summary>
        /// <param name="customerId">The id of the customer.</param>
        public static void DeleteCustomer(string customerId)
        {
            ValidateCustomerIdLength(customerId);

            var db = new NorthwindEntities();
            var customer = db.Customers.First(x => x.CustomerID == customerId);
            db.Customers.Remove(customer);
            db.SaveChanges();
        }

        private static bool ValidateCustomerIdLength(string customerId)
        {
            if (customerId.Length != CUSTOMER_ID_LENGTH)
            {
                string message = string.Format("CustomerId must be {0} characters", CUSTOMER_ID_LENGTH);
                throw new ArgumentOutOfRangeException(message);
            }

            return true;
        }
    }
}
