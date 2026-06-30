using System;
using System.Diagnostics;
class ComplexityDemo
{
    // Count how many comparisons a NESTED loop makes — O(n²)
    static long CountQuadratic(int n)
    {
        long ops = 0;
        for (int i = 0; i < n; i++)
            for (int j = 0; j < n; j++)
                ops++;
        return ops;            // should equal n * n
    }

    // Count how many times we can halve n before reaching 1 — O(log n)
    static int CountLogarithmic(int n)
    {
        int steps = 0;
        while (n > 1)
        {
            n /= 2;            // halve n each step
            steps++;
        }
        return steps;          // should equal floor(log2(n))
    }
    

    static void Main()
    {
        Console.WriteLine();
        Console.WriteLine("Big-O Comparison Table");
        Console.WriteLine($"{"n",-10} {"O(n²) ops",-16} {"O(log n) steps",-18} {"Ratio",-10}");
        Console.WriteLine(new string('-', 56));

        int[] testSizes = { 10, 100, 500, 1000, 5000, 5000000};
        foreach (int n in testSizes)
        {
            long quad = CountQuadratic(n);
            int logn = CountLogarithmic(n);
            Console.WriteLine($"{n,-10} {quad,-16} {logn,-18} {quad / logn,-10:N0}");
        }
    }
}
