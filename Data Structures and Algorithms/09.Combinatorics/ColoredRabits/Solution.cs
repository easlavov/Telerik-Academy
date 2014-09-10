namespace ColoredRabits
{
    using System;
    using System.Collections.Generic;

    class Solution
    {
        static void Main()
        {
            int rabitsAsked = int.Parse(Console.ReadLine());
            int rabitsInTown = CalculateRabits(rabitsAsked);
            Console.WriteLine(rabitsInTown);
        }

        private static int CalculateRabits(int rabitsAsked)
        {
            var answers = GetAnswers(rabitsAsked);
            int count = 0;
            foreach (var digits in answers)
            {
                int actualValue = digits.Key + 1;
                int repetitionsOfCurrentAnswer = digits.Value;
                int groups = (int)Math.Ceiling(repetitionsOfCurrentAnswer / (double)actualValue);
                int rabits = groups * actualValue;
                count += rabits;
            }

            return count;
        }

        private static IDictionary<int, int> GetAnswers(int rabitsAsked)
        {
            var answers = new Dictionary<int, int>();
            for (int i = 0; i < rabitsAsked; i++)
            {
                int answer = int.Parse(Console.ReadLine());
                if (answers.ContainsKey(answer))
                {
                    answers[answer] += 1;
                }
                else
                {
                    answers.Add(answer, 1);
                }
            }

            return answers;
        }
    }
}
