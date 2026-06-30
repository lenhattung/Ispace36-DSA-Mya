using System;
using System.Diagnostics;

class Program
{
    // ─────────────────────────────────────────────────────────
    // Algorithm 1: Loop-based sum   Complexity: O(n)
    // We visit every integer from 1 to n exactly once.
    // ─────────────────────────────────────────────────────────
    static long SumLoop(int n)
    {
        long total = 0;
        for (int i = 1; i <= n; i++)
        {
            total += i;       // one addition per iteration
            // total = total + i;
        }
        return total;
    }

    // ─────────────────────────────────────────────────────────
    // Algorithm 2: Gauss formula   Complexity: O(1)
    // Carl Friedrich Gauss discovered this at age 10.
    // 1+2+…+n = n*(n+1)/2  — always two multiplications, one add.
    // ─────────────────────────────────────────────────────────
    static long SumGauss(int n)
    {
        return (long)n * (n + 1) / 2;
    }

    static void Main1()
    {
        //int n = 100000000;

        //Console.WriteLine("=== Sum Algorithms Demo ===");
        //Console.WriteLine($"n = {n}");
        //Console.WriteLine($"SumLoop  = {SumLoop(n)}");
        //Console.WriteLine($"SumGauss = {SumGauss(n)}");


        int n = 1000_000_000;    // 100 million  (underscores = digit separators, same as 100000000)

        var sw = new Stopwatch();    // create the timer

        // ── Measure SumLoop ──────────────────────────────────────
        sw.Restart();               // reset to 0 and start counting
        long r1 = SumLoop(n);
        sw.Stop();                  // stop the timer
        double ms1 = sw.Elapsed.TotalMilliseconds;

        // ── Measure SumGauss ─────────────────────────────────────
        sw.Restart();
        long r2 = SumGauss(n);
        sw.Stop();
        double ms2 = sw.Elapsed.TotalMilliseconds;

        // ── Print results ─────────────────────────────────────────
        Console.WriteLine($"n = {n:N0}");
        Console.WriteLine($"SumLoop  result: {r1}  |  Time: {ms1,10:F3} ms");
        Console.WriteLine($"SumGauss result: {r2}  |  Time: {ms2,10:F4} ms");
        Console.WriteLine($"Speedup: {ms1 / ms2:F0}x faster with Gauss formula");



    }
}
