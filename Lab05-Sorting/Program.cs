// Test
int[] data = { 64, 34, 25, 12, 22 };
ArrayHelper.Print("Input", data);
var (c, s) = ArrayHelper.SelectionSort(data, showTrace: true);
ArrayHelper.Print("Sorted", data);
Console.WriteLine($"  Comparisons: {c}   Swaps: {s}");