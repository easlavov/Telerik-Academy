// A marketing firm wants to keep record of its employees. Each 
// record would have the following characteristics – first name,
// family name, age, gender (m or f), ID number, unique employee
// number (27560000 to 27569999). Declare the variables needed to
// keep the information for a single employee using appropriate
// data types and descriptive names.

using System;

class EmployeesRecords
{
    static void Main()
    {
        string firstName = "Jon";
        string familyName = "Doe";
        byte age = 33;
        char gender = 'm';
        int idNumber = 10000547;
        int uniqueEmpNum = 27560547;

        // Check:

        Console.WriteLine(
            "First name: {0}\nFamily name: {1}\nAge: {2}\nGender: {3}\nID Number: {4}\nUnique employee number: {5}",
            firstName,familyName,age,gender,idNumber,uniqueEmpNum);
    }
}