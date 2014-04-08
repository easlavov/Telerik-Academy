using System;

public class LoopSimulator
{
    private int[] nums;
    private int n;

    public LoopSimulator(int n)
    {
        this.nums = new int[n];
        this.n = n;
    }

    public void SimulateLoop()
    {
        Loop(0);
    }

    private void Loop(int index)
    {
        if (index == n)
        {
            Console.WriteLine(string.Join(" ", nums));
            return;
        }
        for (int i = 1; i <= n; i++)
        {
            nums[index] = i;
            Loop(index + 1);
        }
    }
}