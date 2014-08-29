using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Northwind.DataAccessObject;

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
    }
}
