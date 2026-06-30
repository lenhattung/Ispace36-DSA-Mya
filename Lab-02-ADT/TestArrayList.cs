
public class Test
{
    static void Main()
    {

        Console.WriteLine("\n=== ArrayList<T> Test ===");
        IMyList<int> list = new ArrayList<int>();   // use the interface type!

        // Add 4 elements (fills initial capacity of 4)
        list.Add(10); list.Add(20); list.Add(30); list.Add(40);
        list.Print();   // should show: [ 10, 20, 30, 40 ]

        // Add a 5th — triggers resize from 4 → 8
        list.Add(50);
        list.Print();   // should show: [ 10, 20, 30, 40, 50 ]

        // Insert 99 at index 2
        list.Insert(2, 99);
        list.Print();   // should show: [ 10, 20, 99, 30, 40, 50 ]

        // Remove the first element (index 0)
        list.RemoveAt(0);
        list.Print();   // should show: [ 20, 99, 30, 40, 50 ]

        // Search
        Console.WriteLine($"Contains(99): {list.Contains(99)}");
        Console.WriteLine($"IndexOf(40):  {list.IndexOf(40)}");
        Console.WriteLine($"Get(1):       {list.Get(1)}");

        // Clear
        list.Clear();
        Console.WriteLine($"After Clear — IsEmpty: {list.IsEmpty}, Count: {list.Count}");

    }
}