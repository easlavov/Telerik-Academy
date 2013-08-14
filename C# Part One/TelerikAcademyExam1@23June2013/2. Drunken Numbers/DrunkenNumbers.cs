using System;

class DrunkenNumbers
{
    static void Main()
    {
        // Declare variables
        int vladkoBeers = 0, mitkoBeers = 0;

        // Read N from the console
        int rounds = int.Parse(Console.ReadLine());

        // Initiate a loop for each round
        for (int round = 0; round < rounds; round++)
        {
            // Read number and remove minus sign and leading zeroes
            string drunkenNumber = Console.ReadLine().TrimStart('-').TrimStart('0');
            // Get Length
            int numberLength = drunkenNumber.Length;
            // Parse digits and add them to each contestants beer count
            int middle = numberLength / 2;
            for (int digit = 0; digit < numberLength; digit++)
            {
                int beers = int.Parse(drunkenNumber[digit].ToString());
                // Ensures correct functionality if drunken number has odd number of digits
                if (numberLength % 2 != 0 && digit == middle)
                {
                    vladkoBeers += beers;
                    mitkoBeers += beers;
                    continue;
                }
                else if (digit < middle)
                {
                    mitkoBeers += beers;
                }
                else
                {
                    vladkoBeers += beers;
                }
            }
        }

        // Calculate result and choose winner
        int differenceInDrunkBeers = Math.Abs(vladkoBeers - mitkoBeers);

        if (vladkoBeers > mitkoBeers)
        {
            Console.WriteLine("V {0}", differenceInDrunkBeers);
        }
        if (vladkoBeers < mitkoBeers)
        {
            Console.WriteLine("M {0}", differenceInDrunkBeers);
        }
        if (vladkoBeers == mitkoBeers)
        {
            Console.WriteLine("No {0}", vladkoBeers + mitkoBeers);
        }
    }
}