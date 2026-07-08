using System.Collections.Generic;

LinkedList<string> list = new LinkedList<string>();

// ── Add elements ──────────────────────────────────────────
list.AddLast("B");
list.AddLast("D");
list.AddFirst("A");

// Find node "B" then insert "C" after it
LinkedListNode<string> nodeB = list.Find("B");
list.AddAfter(nodeB, "C");

// Add "E" to the end
list.AddLast("E");

PrintList(list, "Initial list");

// ── Traverse in reverse direction ────────────────────────
Console.Write("Reverse order:   ");
LinkedListNode<string> cur = list.Last;
while (cur != null)
{
    Console.Write(cur.Value + "  ");
    cur = cur.Previous;
}
Console.WriteLine();

// ── Remove elements ──────────────────────────────────────
list.Remove("C");
list.RemoveFirst();
PrintList(list, "After Remove(C) and RemoveFirst()");

// ── Access First / Last ────────────────────────────────────
Console.WriteLine($"First: {list.First.Value}   Last: {list.Last.Value}");

// Helper method
static void PrintList(LinkedList<string> ll, string label)
{
    Console.Write($"{label,-40}: ");
    foreach (string item in ll) Console.Write(item + "  ");
    Console.WriteLine($"  (Count={ll.Count})");
}
