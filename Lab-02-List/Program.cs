using System;
using System.Collections.Generic;

// Create a List and add elements
List<int> scores = new List<int>();

scores.Add(85);
scores.Add(92);
scores.Add(78);
scores.Add(95);
scores.Add(88);

Console.WriteLine($"Element count: {scores.Count}");
Console.WriteLine($"Capacity:   {scores.Capacity}");   // always >= Count

// - Print the list
Console.Write("List: ");
foreach (int e in scores)
    Console.Write(e + " ");
Console.WriteLine();

// - Access by index
Console.WriteLine($"Element [0]: {scores[0]}");
Console.WriteLine($"Element [1]: {scores[1]}");

// - Modify an lement
scores[1] = 99;
Console.WriteLine($"Element [1]: {scores[1]}");
