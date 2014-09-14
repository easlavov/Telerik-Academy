using System;

class Solution
{
    static bool[,] employees;
    static int count;
    static long[] salaries;

    static void Main()
    {
        count = int.Parse(Console.ReadLine());
        employees = new bool[count, count];
        salaries = new long[count];

        for (int i = 0; i < count; i++)
        {
            string input = Console.ReadLine();
            for (int j = 0; j < count; j++)
            {
                if (input[j] == 'Y')
                {
                    employees[i, j] = true;
                }
            }
        }

        long totalSalary = 0;
        for (int i = 0; i < count; i++)
        {
            totalSalary += CalcSalary(i);
        }

        Console.WriteLine(totalSalary);
    }

    static long CalcSalary(int employee)
    {
        if (salaries[employee] > 0)
        {
            return salaries[employee];
        }

        long salary = 0;
        for (int i = 0; i < count; i++)
        {
            if (employees[employee, i])
            {
                salary += CalcSalary(i);
            }
        }

        salary = (salary != 0 ? salary : 1);
        salaries[employee] = salary;
        return salary;
    }
}