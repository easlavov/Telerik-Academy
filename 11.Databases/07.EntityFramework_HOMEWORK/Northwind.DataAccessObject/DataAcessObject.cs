// Create a DAO class with static methods which 
// provide functionality for inserting, modifying and 
// deleting customers. Write a testing class.
namespace Northwind.DataAccessObject
{
    using System;
    using System.Linq;
    using Northwind.Data;
    using System.Text;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data.Entity.Core.Objects;

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

        // Task 3: Write a method that finds all customers who have 
        // orders made in 1997 and shipped to Canada.
        public static IEnumerable<Customer> FindCustomers()
        {
            var db = new NorthwindEntities();
            var customers = db.Customers.Where(x => x.Orders.Any(o => o.ShipCountry == "Canada") &&
                                                    x.Orders.Any(o => ((DateTime)o.OrderDate).Year == 1997))
                                        .ToList();
            return customers;
        }

        // Task 4:
        public static IEnumerable FindCustomersNativeSql()
        {
            string query = "select distinct c.CompanyName from Customers c join" +
                           " Orders o on c.CustomerID = o.CustomerID where o.ShipCountry" +
                           " = {0} AND YEAR(o.OrderDate) = {1}";
            var db = new NorthwindEntities();
            object[] parameters = { "Canada", 1997 };
            var customers = db.Database.SqlQuery<string>(query, parameters).ToList();
            return customers;
        }

        // Task 5: Write a method that finds all the sales by specified 
        // region and period (start / end dates).
        public static IEnumerable<Order> FindSalesByRegionAndPeriod(string region, DateTime from, DateTime to)
        {
            var db = new NorthwindEntities();
            var result = db.Orders
                           .Where(x => x.ShipRegion == region)
                           .Where(x => x.OrderDate >= from)
                           .Where(x => x.OrderDate <= to)
                           .ToList();
            return result;
        }

        // Task 6:
        public static void CreateNorthwindTwin()
        {
            var db = new NorthwindEntities();
            var connection = db.Database.Connection;
            var connstring = connection.ConnectionString;
            connection.Open();
            var schema = connection.GetSchema();
            connection.Close();
            ObjectContext context = new ObjectContext(connstring);
            var str = context.CreateDatabaseScript();

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
