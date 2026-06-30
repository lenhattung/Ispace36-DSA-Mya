using System.Collections;

ArrayList list = new ArrayList();

// Can store different types (but should not!)
list.Add(42); // int
list.Add("Hello"); // string
list.Add(3.14); // double
list.Add(true); // bool

Console.WriteLine($"Count: {list.Count}");

// Must cast when reading — easy source of runtime errors!
int num = (int)list[0];
string str = (string)list[1];
Console.WriteLine($"[0] = {num},  [1] = {str}");

// Practical ArrayList: store same type so Sort() works
ArrayList scores = new ArrayList { 55, 72, 88, 61, 94, 45 };
scores.Sort();
Console.Write("Sau Sort(): ");
foreach (object s in scores)
    Console.Write(s + "  ");
Console.WriteLine();

// Convert to int[]
int[] arr = (int[])scores.ToArray(typeof(int));
Console.WriteLine($"ToArray — last element: {arr[arr.Length - 1]}");
