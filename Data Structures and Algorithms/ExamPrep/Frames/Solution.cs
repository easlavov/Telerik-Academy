using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Solution
{

    static SortedSet<string> permutations = new SortedSet<string>();

    static Frame[] frames;

    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        frames = new Frame[n];
        for (int i = 0; i < n; i++)
        {
            string[] frameAsString = Console.ReadLine().Split(' ');
            int x = int.Parse(frameAsString[0]);
            int y = int.Parse(frameAsString[1]);
            var frame = new Frame(x, y);
            frames[i] = frame;
        }
        
        GeneratePermutations(frames, 0);
        Console.WriteLine(permutations.Count);
        foreach (var item in permutations)
        {
            Console.WriteLine(item);
        }
    }

    static void GeneratePermutations<T>(T[] arr, int k)
    {
        if (k >= arr.Length)
        {
            string perm = string.Join(" | ", arr);
            permutations.Add(perm);
        }
        else
        {
            GeneratePermutations(arr, k + 1);
            FlipFrame(k);
            GeneratePermutations(arr, k + 1);
            FlipFrame(k);
            for (int i = k + 1; i < arr.Length; i++)
            {
                Swap(ref arr[k], ref arr[i]);
                GeneratePermutations(arr, k + 1);

                FlipFrame(k);
                GeneratePermutations(arr, k + 1);
                FlipFrame(k);

                Swap(ref arr[k], ref arr[i]);
            }
        }
    }

    static void FlipFrame(int k)
    {
        frames[k] = new Frame(frames[k].Y, frames[k].X);
    }

    static void Swap<T>(ref T first, ref T second)
    {
        T oldFirst = first;
        first = second;
        second = oldFirst;
    }

    class Frame
    {
        public Frame(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public int X { get; set; }

        public int Y { get; set; }

        public override string ToString()
        {
            string format = "({0}, {1})";
            return string.Format(format, this.X, this.Y);
        }
    }
}