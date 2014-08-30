using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Northwind.DataAccessObject;
using Northwind.Data;

namespace Northwind.DataAccessObjectTestApplication
{
    class TestApplication
    {
        static void Main()
        {
            string welcomeMessage = "Hello! This app will guide you through the" +
                                    " test I made to the DAO for the Nortwhind database." +
                                    " Press a key to continue.";
            Console.WriteLine(welcomeMessage);
            Console.ReadKey();

            AddTelerikAsCustomer();
            ModifyTelerikName();
            RemoveTelerikFromDatabase();
            FindCustomers();
            FindCustomersNativeSql();
            FindOrdersByRegionAndDates();
            DataAcessObject.CreateNorthwindTwin();

            Console.WriteLine("Testing has finished.");
        }

        private static void AddTelerikAsCustomer()
        {
            string addCustomerMessage = "A customer with the name Telerik will be added to the" +
                                           " Northwind database. Press a key to continue.";
            Console.WriteLine(addCustomerMessage);
            Console.ReadKey();
            string name = "Telerik";
            string id = "TELER";
            DataAcessObject.InsertCustomer(name, id);
        }

        private static void ModifyTelerikName()
        {
            string modifyCustomerMessage = "The Telerik customers' name will be changed to Nakov" +
                                           " in the Northwind database. Press a key to continue.";
            Console.WriteLine(modifyCustomerMessage);
            Console.ReadKey();
            string name = "Nakov";
            string id = "TELER";
            DataAcessObject.ModifyCustomerName(id, name);
        }

        private static void RemoveTelerikFromDatabase()
        {
            string deleteCustomerMessage = "The Telerik customer will be deleted from" +
                                           " the Northwind database. Press a key to continue.";
            Console.WriteLine(deleteCustomerMessage);
            Console.ReadKey();
            string id = "TELER";
            DataAcessObject.DeleteCustomer(id);
        }

        private static void FindCustomers()
        {
            string findCustomerMessage = "Find all customers who have orders made in 1997 and" +
                                           " shipped to Canada from" +
                                           " the Northwind database. Press a key to continue.";
            Console.WriteLine(findCustomerMessage);
            Console.ReadKey();
            var customersList = DataAcessObject.FindCustomers();
            foreach (var customer in customersList)
            {
                Console.WriteLine(customer);
            }
        }

        private static void FindCustomersNativeSql()
        {
            string findCustomerMessage = "Find all customers who have orders made in 1997 and" +
                                           " shipped to Canada from" +
                                           " the Northwind database. Using native SQL. Press a key to continue.";
            Console.WriteLine(findCustomerMessage);
            Console.ReadKey();
            var customersList = DataAcessObject.FindCustomersNativeSql();
            foreach (var customer in customersList)
            {
                Console.WriteLine(customer);
            }
        }

        private static void FindOrdersByRegionAndDates()
        {
            string findOrdersMessage = "Finds all the sales from NM region and between 1997 and 2000" +
                                           " from" +
                                           " the Northwind database. Press a key to continue.";
            Console.WriteLine(findOrdersMessage);
            Console.ReadKey();
            DateTime from = DateTime.Parse("1.1.1997");
            DateTime to = DateTime.Parse("1.1.2000");
            var orders = DataAcessObject.FindSalesByRegionAndPeriod("NM", from, to);
            foreach (var order in orders)
            {
                Console.WriteLine(order);
            }
        }
    }
}
