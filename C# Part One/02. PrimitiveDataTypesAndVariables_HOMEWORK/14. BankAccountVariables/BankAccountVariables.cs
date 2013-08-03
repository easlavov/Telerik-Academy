// A bank account has a holder name (first name, middle name and last name),
// available amount of money (balance), bank name, IBAN, BIC code and 3 credit
// card numbers associated with the account. Declare the variables needed to
// keep the information for a single bank account 

using System;

class BankAccountVariables
{
    static void Main()
    {
        // Declare the variables needed to keep the information for a single bank account:
        string firstName = "Petar";
        string middleName = "Petrov";
        string lastName = "Petrov";
        string holderName = firstName + " " + middleName+ " " + lastName;
        decimal balance = 35551.58m;
        string bankName = "Raiffeisen Bank";
        string IBAN = "BG10RZBB91558120002006";
        string bicCode = "RZBBBGSF";
        long creditCardOne = 4801254031801273;
        long creditCardTwo = 4556763475107481;
        long creditCardThree = 4929642792058561;

        // Check:

        Console.WriteLine("Account holder: " + holderName);
        Console.WriteLine("Bank: " + bankName);
        Console.WriteLine("IBAN: " + IBAN);
        Console.WriteLine("BIC:  " + bicCode);
        Console.WriteLine("Balance: $" + balance);
        Console.WriteLine("Credit card #1: " + creditCardOne);
        Console.WriteLine("Credit card #2: " + creditCardTwo);
        Console.WriteLine("Credit card #3: " + creditCardThree);
    }
}