using System;
using System.Collections.Generic;
using System.Text;

class BullsandCows
{
    static void Main()
    {
        // Read input
        string secretNumber = Console.ReadLine();
        int bulls = int.Parse(Console.ReadLine());
        int cows = int.Parse(Console.ReadLine());

        // Search for numbers
        StringBuilder result = new StringBuilder();

        int number = 1111;
        while (number < 10000)
        {
            int tempNumber = number;
            int zeroes = 0;
            // Check if there are zeroes
            for (int i = 0; i < 4; i++)
            {
                int currentDigit = tempNumber % 10;
                if (currentDigit == 0)
                {
                    zeroes++;
                    break;
                }
                tempNumber /= 10;
            }
            if (zeroes > 0)
            {
                number++;
                continue;
            }

            List<int> cowCandidatesTop = new List<int>();
            List<int> cowCandidatesBottom = new List<int>();
            int currentBulls = 0;
            int currentCows = 0;
            string numberAsString = number.ToString();
            for (int digit = 0; digit < 4; digit++)
            {
                if (secretNumber[digit] == numberAsString[digit])
                {
                    currentBulls++;
                }
                else
                {
                    cowCandidatesTop.Add(int.Parse(secretNumber[digit].ToString()));
                    cowCandidatesBottom.Add(int.Parse(numberAsString[digit].ToString()));
                }
            }
            for (int i = 0; i < cowCandidatesTop.Count; i++)
            {
                for (int p = 0; p < cowCandidatesBottom.Count; p++)
                {
                    if (cowCandidatesTop[i] == cowCandidatesBottom[p])
                    {
                        currentCows++;
                        cowCandidatesTop.RemoveAt(i);
                        cowCandidatesBottom.RemoveAt(p);
                        i = -1;
                        break;
                    }
                }
            }

            if (currentBulls == bulls && currentCows == cows)
            {
                if (result.Length == 0)
                {
                    result.Append(number);
                }
                else
                {
                    result.Append(" " + number);
                }                
            }
            number++;
        }

        if (result.Length > 0)
        {
            Console.WriteLine(result.ToString());
        }
        else
        {
            Console.WriteLine("No");
        }        
    }
}