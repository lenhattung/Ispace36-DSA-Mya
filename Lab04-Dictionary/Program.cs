using System;
using System.Collections.Generic;

Dictionary<string, int> scores = new Dictionary<string, int>();

// ── Add: throws if key exists ────────────────────────────
scores.Add("Alice", 92);
scores.Add("Bob", 85);
scores.Add("Charlie", 78);

// ── Indexer: add OR update, never throws ─────────────────
scores["Diana"] = 95;   // new entry
scores["Bob"] = 90;   // update Bob's score

// ── TryAdd: add only if key is new ──────────────────────
bool added = scores.TryAdd("Alice", 99);   // Alice already exists
Console.WriteLine($"TryAdd Alice=99: {added}  (Alice stays {scores["Alice"]})");

// ── Read by key: throws KeyNotFoundException if missing ──
Console.WriteLine($"Alice: {scores["Alice"]}");


// ── TryGetValue: safe read ───────────────────────────────
if (scores.TryGetValue("Eve", out int eveScore))
    Console.WriteLine($"Eve: {eveScore}");
else
    Console.WriteLine("Eve not found");

// ── ContainsKey ──────────────────────────────────────────
Console.WriteLine($"ContainsKey Bob:  {scores.ContainsKey("Bob")}");    // True
Console.WriteLine($"ContainsKey Zara: {scores.ContainsKey("Zara")}");   // False

// ── Remove ───────────────────────────────────────────────
scores.Remove("Charlie");
Console.WriteLine($"After Remove(Charlie) — Count: {scores.Count}");

// ── Remove and retrieve at once ──────────────────────────
if (scores.Remove("Bob", out int bobScore))
    Console.WriteLine($"Removed Bob, his score was {bobScore}");

// ── Print all entries ─────────────────────────────────────
Console.WriteLine("Remaining entries:");
foreach (KeyValuePair<string, int> kv in scores)
    Console.WriteLine($"  {kv.Key,-12} → {kv.Value}");


/// =====
var inventory = new Dictionary<string, int>
{
    ["apple"] = 50,
    ["banana"] = 30,
    ["cherry"] = 120,
    ["date"] = 15,
    ["elderberry"] = 8,
};

// ── Iterate over KeyValuePairs ────────────────────────────
Console.WriteLine("All inventory:");
foreach (var (item, qty) in inventory)   // deconstruct KeyValuePair
    Console.WriteLine($"  {item,-12} : {qty,4} units");

// ── Iterate over Keys only ───────────────────────────────
Console.Write("Items: ");
foreach (string item in inventory.Keys)
    Console.Write(item + "  ");
Console.WriteLine();

// ── Iterate over Values only ─────────────────────────────
int total = 0;
foreach (int qty in inventory.Values) total += qty;
Console.WriteLine($"Total units in stock: {total}");

// ── GetValueOrDefault: safe access without try-catch ─────
int mangos = inventory.GetValueOrDefault("mango", 0);
int apples = inventory.GetValueOrDefault("apple", 0);
Console.WriteLine($"mango stock: {mangos}   apple stock: {apples}");

// ── Convert Keys/Values to List for sorting ───────────────
var sortedKeys = new List<string>(inventory.Keys);
sortedKeys.Sort();
Console.WriteLine("Sorted alphabetically:");
foreach (string k in sortedKeys)
    Console.WriteLine($"  {k,-12} : {inventory[k]}");

// ── Find items with low stock (< 20 units) ────────────────
Console.WriteLine("Low stock alerts:");
foreach (var (item, qty) in inventory)
    if (qty < 20) Console.WriteLine($"  ⚠  {item}: only {qty} left");

