using System.Diagnostics;

class Program
{
    static void Main()
    {
        int n = 50000;
        Console.WriteLine($"Generating a random array of {n} elements...\n");

        // Create the base array to ensure all algorithms sort the exact same data
        int[] originalArray = ArrayHelper.Random(n, seed: 42, max: 10000);

        Console.WriteLine($"{"Algorithm",-15} | {"Time (ms)",-15} | {"Ticks",-10} | {"Status"}");
        Console.WriteLine(new string('-', 60));

        MeasureAndRun("Bubble Sort", () =>
        {
            int[] arr = ArrayHelper.Copy(originalArray);
            ArrayHelper.BubbleSort(arr);
            return arr;
        });

        MeasureAndRun("Selection Sort", () =>
        {
            int[] arr = ArrayHelper.Copy(originalArray);
            ArrayHelper.SelectionSort(arr);
            return arr;
        });

        MeasureAndRun("Insertion Sort", () =>
        {
            int[] arr = ArrayHelper.Copy(originalArray);
            ArrayHelper.InsertionSort(arr);
            return arr;
        });

        MeasureAndRun("Merge Sort", () =>
        {
            int[] arr = ArrayHelper.Copy(originalArray);
            ArrayHelper.MergeSort(arr, 0, arr.Length - 1);
            return arr;
        });

        MeasureAndRun("Quick Sort", () =>
        {
            int[] arr = ArrayHelper.Copy(originalArray);
            ArrayHelper.QuickSort(arr, 0, arr.Length - 1);
            return arr;
        });
    }

    // Helper function to encapsulate the timing logic
    static void MeasureAndRun(string algoName, Func<int[]> sortFunc)
    {
        Stopwatch sw = Stopwatch.StartNew();

        int[] sortedArray = sortFunc(); // Execute the sorting algorithm

        sw.Stop();

        // Verify that the array was actually sorted
        string status = ArrayHelper.IsSorted(sortedArray) ? "OK" : "Failed";

        Console.WriteLine($"{algoName,-15} | {sw.Elapsed.TotalMilliseconds,-15:F4} | {sw.ElapsedTicks,-10} | {status}");
    }
}