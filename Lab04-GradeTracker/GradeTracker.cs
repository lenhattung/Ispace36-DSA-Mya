// File: GradeTracker.cs
using System;
using System.Collections.Generic;

namespace GradeTracker;

public class GradeTracker
{
    // HashSet: O(1) duplicate check for student IDs
    private HashSet<string> _registered = new HashSet<string>();

    // Dictionary: studentId → list of scores
    private Dictionary<string, List<int>> _grades = new Dictionary<string, List<int>>();


    // ── 1. Register student ────────────────────────────────
    public void Register(string id, string name)
    {
        if (!_registered.Add(id))   // Add returns false if duplicate
        {
            Console.WriteLine($"  ✘ ID {id} already registered."); 
            return;
                }
        _grades[id] = new List<int>();
        Console.WriteLine($"  ✔ Registered: [{id}] {name}");
    }

    // ── 2. Add grade ───────────────────────────────────────
    public void AddGrade(string id, int score)
    {
        if (!_registered.Contains(id))
        { 
            Console.WriteLine($"  ✘ Student {id} not found."); 
            return; 
        }

        if (score < 0 || score > 10)
        { 
            Console.WriteLine("  ✘ Score must be 0–10."); 
            return; 
        }

        _grades[id].Add(score);
        Console.WriteLine($"  ✔ Added score {score} for [{id}]");
    }

    // ── 3. Show all students ───────────────────────────────
    public void ShowAll()
    {
        if (_registered.Count == 0)
        { Console.WriteLine("  No students registered."); return; }
        Console.WriteLine($"  Registered students ({_registered.Count}):");
        foreach (string id in _registered)
        {
            var list = _grades[id];
            string avg = list.Count > 0
                ? $"avg={list.Average():F1}" : "no grades";
            Console.WriteLine($"    [{id}]  grades: {list.Count}  {avg}");
        }
    }

    // ── 4. Show student detail ─────────────────────────────
    public void ShowStudent(string id)
    {
        if (!_grades.TryGetValue(id, out List<int> list))
        { Console.WriteLine($"  ✘ {id} not found."); return; }
        if (list.Count == 0)
        { Console.WriteLine($"  [{id}] has no grades yet."); return; }
        Console.WriteLine($"  [{id}] — {list.Count} grade(s):");
        Console.WriteLine($"    Scores : {string.Join(", ", list)}");
        Console.WriteLine($"    Average: {list.Average():F2}");
        Console.WriteLine($"    Highest: {list.Max()}   Lowest: {list.Min()}");
        Console.WriteLine($"    Result : {(list.Average() >= 5.0 ? "PASS" : "FAIL")}");
    }

    // ── 5. Top scorer ─────────────────────────────────────
    public void TopScorer()
    {
        string topId = null; double topAvg = -1;
        foreach (var (id, list) in _grades)
        {
            if (list.Count == 0) continue;
            double avg = list.Average();
            if (avg > topAvg) { topId = id; topAvg = avg; }
        }
        if (topId == null) Console.WriteLine("  No grades recorded yet.");
        else Console.WriteLine($"  Top scorer: [{topId}] — average {topAvg:F2}");
    }

    // ── 6. Filter by score range ───────────────────────────
    public void FilterByAverage(double lo, double hi)
    {
        Console.WriteLine($"  Students with average in [{lo:F1} – {hi:F1}]:");
        bool found = false;
        foreach (var (id, list) in _grades)
        {
            if (list.Count == 0) continue;
            double avg = list.Average();
            if (avg >= lo && avg <= hi)
            { Console.WriteLine($"    [{id}] avg={avg:F2}"); found = true; }
        }
        if (!found) Console.WriteLine("    (none)");
    }

    // ── 7. Remove student ─────────────────────────────────
    public void Remove(string id)
    {
        bool r1 = _registered.Remove(id);
        bool r2 = _grades.Remove(id);
        if (r1 && r2) Console.WriteLine($"  ✔ Removed [{id}]");
        else Console.WriteLine($"  ✘ [{id}] not found.");
    }

    // ── 8. Class statistics ────────────────────────────────
    public void Statistics()
    {
        int total = 0, graded = 0, pass = 0, fail = 0;
        double sumAvg = 0;
        foreach (var (id, list) in _grades)
        {
            total++;
            if (list.Count == 0) continue;
            graded++;
            double avg = list.Average();
            sumAvg += avg;
            if (avg >= 5.0) pass++; else fail++;
        }
        Console.WriteLine($"  Total registered : {total}");
        Console.WriteLine($"  Students graded  : {graded}");
        if (graded == 0) return;
        Console.WriteLine($"  Class average    : {sumAvg / graded:F2}");
        Console.WriteLine($"  Pass (avg >= 5.0): {pass}");
        Console.WriteLine($"  Fail (avg < 5.0) : {fail}");
    }



}