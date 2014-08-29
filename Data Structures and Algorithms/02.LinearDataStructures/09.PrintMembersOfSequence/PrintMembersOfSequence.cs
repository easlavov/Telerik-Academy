/*We are given the following sequence:
S1 = N;
S2 = S1 + 1;
S3 = 2*S1 + 1;
S4 = S1 + 2;
S5 = S2 + 1;
S6 = 2*S2 + 1;
S7 = S2 + 2;
...
Using the Queue<T> class write a program to print its first 50 members for given N.
Example: N=2 -> 2, 3, 5, 4, 4, 7, 5, 6, 11, 7, 5, 9, 6, ...*/

using System;
using System.Collections.Generic;
using System.Linq;

class PrintMembersOfSequence
{
    static void Main()
    {
        Console.Write("Please, enter n: ");
        int n = int.Parse(Console.ReadLine());
        PrintSequence(n);
    }

    private static void PrintSequence(int n)
    {
        List<int> result = new List<int>();
        Queue<int> numbers = new Queue<int>();
        numbers.Enqueue(n);
        result.Add(n);
        while (result.Count < 50)
        {
            int s = numbers.Dequeue();

            int firstMember = s + 1;
            result.Add(firstMember);
            numbers.Enqueue(firstMember);

            int secondMember = s * 2 + 1;
            result.Add(secondMember);
            numbers.Enqueue(secondMember);

            int thirdMember = s + 2;
            result.Add(thirdMember);
            numbers.Enqueue(thirdMember);
        }

        result.RemoveRange(49, 2); // ensure there are 50 elements in total

        Console.Write("The first 50 elements in the sequence are: ");
        Console.WriteLine(string.Join(", ", result));
    }
}