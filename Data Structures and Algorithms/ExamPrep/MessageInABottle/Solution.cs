using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Solution
{
    static void Main()
    {
        Pair[] pairs =
        {
            new Pair(1, 'A'),
            new Pair(12, 'B'),
            new Pair(11, 'C'),
            new Pair(2, 'D'),
        };

        int[] arr = new int[4];
    }


    class Pair
    {
        public Pair(int number, char letter)
        {
            this.Number = number;
            this.Letter = letter;
            this.Length = this.Number.ToString().Length;
        }

        public int Length { get; set; }

        public int Number { get; set; }

        public char Letter { get; set; }
    }
}