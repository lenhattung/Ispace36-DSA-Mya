using System;
using System.Collections.Generic;

Queue<string> queue = new Queue<string>();

// -- Enqueue: add items to the Back ----
queue.Enqueue("Aung"); // Aou
queue.Enqueue("Aye");
queue.Enqueue("Cho"); // Chu
queue.Enqueue("Htike"); // Thai
queue.Enqueue("Kyaw"); // Kieu
queue.Enqueue("Naing"); // Nai
queue.Enqueue("Oo"); // U
queue.Enqueue("Paing"); // Pai
queue.Enqueue("Phyo"); // Phieu
queue.Enqueue("Sin"); // Sin
queue.Enqueue("Zaw"); // So
queue.Enqueue("Lin"); // Lin
queue.Enqueue("Linn"); // Lin

Console.WriteLine($"Count: {queue.Count}");
Console.WriteLine($"Peek (front, not rmoved): {queue.Peek()}");

// - Print all (foreach does NOT remove items) 
Console.WriteLine();
Console.WriteLine("Queue (front -> back): ");
foreach (string name in queue)
    Console.Write(name + " ");
Console.WriteLine();

// Dequeue: remove from the FRONT
Console.WriteLine($"Dequue: {queue.Dequeue()}");
Console.WriteLine($"Dequue: {queue.Dequeue()}");

Console.WriteLine();
Console.WriteLine($"Count after 2 dequeues: {queue.Count}");
Console.Write("Remaining: ");
foreach (string name in queue)
    Console.Write(name + "  ");

// ── TryDequeue: safe removal ────────────────────────────
while (queue.TryDequeue(out string person))
    Console.WriteLine($"Served: {person}");

Console.WriteLine($"Empty? {queue.Count == 0}");



// ==================

Queue<int> q = new Queue<int>();
int[] seed = { 10, 20, 30, 40, 50 };
foreach (int n in seed) q.Enqueue(n);

// ── Contains ────────────────────────────────────────────
Console.WriteLine($"Contains(30): {q.Contains(30)}");   // True
Console.WriteLine($"Contains(99): {q.Contains(99)}");   // False


// ── ToArray: snapshot, does NOT dequeue ─────────────────
int[] snap = q.ToArray();
Console.Write("ToArray: ");
foreach (int n in snap) Console.Write(n + "  ");
Console.WriteLine($"  | Queue still has {q.Count} items");

// ── CopyTo: copy into an existing array from index 1 ────
int[] dest = new int[7];
q.CopyTo(dest, 1);    // leaves dest[0] = 0
Console.Write("CopyTo (offset 1): ");
foreach (int n in dest) Console.Write(n + "  ");
Console.WriteLine();

// ── Clear ───────────────────────────────────────────────
q.Clear();
Console.WriteLine($"After Clear — Count: {q.Count}");

// ── Exception handling ───────────────────────────────────
try { q.Dequeue(); }
catch (InvalidOperationException ex)
{ Console.WriteLine($"Error: {ex.Message}"); }
