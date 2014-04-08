using System;

class CoffeeMachine
{
    static void Main()
    {
        // Read input
        // Read amount of coins in trays
        int n1 = int.Parse(Console.ReadLine());
        int n2 = int.Parse(Console.ReadLine());
        int n3 = int.Parse(Console.ReadLine());
        int n4 = int.Parse(Console.ReadLine());
        int n5 = int.Parse(Console.ReadLine());

        // Read A - amount of money inserted
        decimal money = decimal.Parse(Console.ReadLine());

        // Read P - price of selected drink
        decimal price = decimal.Parse(Console.ReadLine());

        // Calculate sum in trays
        decimal sumInTrays = 0;
        sumInTrays += n1 * 0.05m;
        sumInTrays += n2 * 0.1m;
        sumInTrays += n3 * 0.2m;
        sumInTrays += n4 * 0.5m;
        sumInTrays += n5 * 1m;

        // Calculate difference between A and P
        decimal difference = money - price;

        if (difference < 0)
        {
            Console.WriteLine("More {0}", Math.Abs(Math.Round(difference, 2)));
        }
        else if (sumInTrays >= difference)
        {
            Console.WriteLine("Yes {0}", Math.Round(sumInTrays - difference, 2));
        }
        else if (sumInTrays < difference)
        {
            Console.WriteLine("No {0}", Math.Round(difference - sumInTrays, 2));
        }
    }
}