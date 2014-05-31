using System;
using System.Collections.Generic;

class ExceptionsHomework
{
    static void Main()
    {
        var substr = Methods.Subsequence("Hello!".ToCharArray(), 2, 3);
        Console.WriteLine(substr);

        var subarr = Methods.Subsequence(new int[] { -1, 3, 2, 1 }, 0, 2);
        Console.WriteLine(String.Join(" ", subarr));

        var allarr = Methods.Subsequence(new int[] { -1, 3, 2, 1 }, 0, 4);
        Console.WriteLine(String.Join(" ", allarr));

        var emptyarr = Methods.Subsequence(new int[] { -1, 3, 2, 1 }, 0, 0);
        Console.WriteLine(String.Join(" ", emptyarr));

        Console.WriteLine(Methods.ExtractEnding("I love C#", 2));
        Console.WriteLine(Methods.ExtractEnding("Nakov", 4));
        Console.WriteLine(Methods.ExtractEnding("beer", 4));
        try
        {
            Console.WriteLine(Methods.ExtractEnding("Hi", 100));
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine(ex.Message);
        }

        int primeCandidate1 = 23;
        Methods.CheckPrime(primeCandidate1);

        int primeCandidate2 = 33;
        Methods.CheckPrime(primeCandidate2);

        List<Exam> peterExams = new List<Exam>()
        {
            new SimpleMathExam(2),
            new CSharpExam(55),
            new CSharpExam(100),
            new SimpleMathExam(1),
            new CSharpExam(0),
        };
        Student peter = new Student("Peter", "Petrov", peterExams);
        double peterAverageResult = peter.CalcAverageExamResultInPercents();
        Console.WriteLine("Average results = {0:p0}", peterAverageResult);
    }
}
