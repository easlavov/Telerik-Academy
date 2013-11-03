// Your task is to write a program to model the bank system by classes and interfaces. 
// You should identify the classes, interfaces, base classes and abstract actions and 
// implement the calculation of the interest functionality through overridden methods.

using System;
using System.Linq;

class TestProgram
{
    static void Main()
    {
        Console.WriteLine("This program tests the Bank project. It will run a few tests to determine if the code has been written correctly.");
        Console.WriteLine();

        Individual ind1 = new Individual("Petar Atanasov");
        Company comp1 = new Company("Telerik");

        Deposit depInd = new Deposit(ind1, 500, 5, 12);
        Deposit depComp = new Deposit(comp1, 40000, 100, 6);

        Loan loanInd = new Loan(ind1, -5000, 50, 25);
        Loan loanComp = new Loan(comp1, -2000000, 1000, 20);

        Mortgage mortInd = new Mortgage(ind1, -50000, 150, 36);
        Mortgage mortComp = new Mortgage(comp1, -500000, 200, 48);

        Account[] accounts = 
        {
            depInd, depComp, loanInd, loanComp, mortInd, mortComp
        };

        foreach (var acc in accounts)
        {
            Console.WriteLine(acc.ToString());
            Console.WriteLine("Interest amount is {0}", acc.InterestAmount());
            Console.WriteLine();
        }
        Console.Write("Press any key to continue testing:");
        Console.ReadKey();
        Console.WriteLine();

        Console.WriteLine("Trying to deposit 100 in each account:");
        foreach (var acc in accounts)
        {
            Console.WriteLine("Account balance before: {0}", acc.Balance);
            acc.Deposit(100);
            Console.WriteLine("Account balance after: {0}", acc.Balance);
            Console.WriteLine();
        }

        Console.WriteLine("Withdrawing 200 from individual deposit:");
        Console.WriteLine("Account balance before: {0}", depInd.Balance);
        depInd.Withdraw(200);
        Console.WriteLine("Account balance after: {0}", depInd.Balance);
        Console.WriteLine();

        Console.WriteLine("Testing is complete.");
    }
}