// A company has name, address, phone number, fax number, web site 
// and manager. The manager has first name, last name, age and a
// phone number. Write a program that reads the information about a
// company and its manager and prints them on the console.

using System;

class CompanyAndManagerInfo
{
    static void Main()
    {
        Console.WriteLine("This program reads the information about a company and its manager" + 
        "and prints them on the console.");

        // Declare data types for the company
        Console.Write("Enter company name: ");
        string companyName = Console.ReadLine();
        Console.Write("Enter company address: ");
        string companyAddres = Console.ReadLine();
        Console.Write("Enter company phone number: ");
        string companyPhoneNumber = Console.ReadLine();
        Console.Write("Enter company fax number: ");
        string companyFaxNumber = Console.ReadLine();
        Console.Write("Enter company web site: ");
        string companyWebSite = Console.ReadLine();
        Console.Write("Enter company manager: ");
        string companyManager = Console.ReadLine();
        Console.WriteLine();

        // Declare data types for the manager
        Console.Write("Enter manager first name: ");
        string managerFirstName = Console.ReadLine();
        Console.Write("Enter manager last name: ");
        string managerLastName = Console.ReadLine();
        Console.Write("Enter manager age: ");
        string managerAge = Console.ReadLine();
        Console.Write("Enter manager phone number: ");
        string managerPhoneNumber = Console.ReadLine();

        // There is no need to convert any numerical data to integers.

        // Print information about the company and the manager.
        Console.WriteLine("{0}'s address is {1}. You can contact {0} by phone ({2}) or fax ({3}). " + 
            "{0}'s manager is {4}. Website: {5}.", companyName, companyAddres, companyPhoneNumber, companyFaxNumber,
            companyManager, companyWebSite);
        Console.WriteLine();
        Console.WriteLine("{0} {1} is the manager of the company. He/She is {2} old. His/Her phone number is {3}.",
            managerFirstName, managerLastName, managerAge,  managerPhoneNumber);
        Console.WriteLine();
    }
}