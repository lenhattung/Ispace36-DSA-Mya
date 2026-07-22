// File: Program.cs
var tracker = new GradeTracker.GradeTracker();

// ── Sample data ──────────────────────────────────────────
tracker.Register("SE001", "Alice");
tracker.Register("SE002", "Bob");
tracker.Register("IT001", "Charlie");
tracker.Register("IT002", "Diana");
tracker.Register("SE003", "Eve");
tracker.Register("SE001", "Duplicate!");  // rejected

tracker.AddGrade("SE001", 9); tracker.AddGrade("SE001", 8);
tracker.AddGrade("SE002", 6); tracker.AddGrade("SE002", 5);
tracker.AddGrade("IT001", 10); tracker.AddGrade("IT001", 9);
tracker.AddGrade("IT002", 4); tracker.AddGrade("IT002", 3);
Console.Clear();

// ── Menu loop ────────────────────────────────────────────
bool running = true;
while (running)
{
    Console.WriteLine();
    Console.WriteLine("╔══════════════════════════════════════╗");
    Console.WriteLine("║   📊  STUDENT GRADE TRACKER          ║");
    Console.WriteLine("╠══════════════════════════════════════╣");
    Console.WriteLine("║  -- HashSet --                       ║");
    Console.WriteLine("║  1. Register student                 ║");
    Console.WriteLine("║  7. Remove student                   ║");
    Console.WriteLine("║  -- Dictionary --                    ║");
    Console.WriteLine("║  2. Add grade                        ║");
    Console.WriteLine("║  3. Show all students                ║");
    Console.WriteLine("║  4. Show student detail              ║");
    Console.WriteLine("║  5. Top scorer                       ║");
    Console.WriteLine("║  6. Filter by average range          ║");
    Console.WriteLine("║  8. Class statistics                 ║");
    Console.WriteLine("║  0. Exit                             ║");
    Console.WriteLine("╚══════════════════════════════════════╝");
    Console.Write("  Choose option: ");
    string opt = Console.ReadLine()?.Trim() ?? "0";
    Console.WriteLine();

    switch (opt)
    {
        case "1":
            Console.Write("  Student ID: "); string id = Console.ReadLine();
            Console.Write("  Name: "); string name = Console.ReadLine();
            tracker.Register(id, name); break;
        case "2":
            Console.Write("  Student ID: "); string sid = Console.ReadLine();
            Console.Write("  Score (0-10): "); int sc = int.Parse(Console.ReadLine());
            tracker.AddGrade(sid, sc); break;
        case "3": tracker.ShowAll(); break;
        case "4":
            Console.Write("  Student ID: ");
            tracker.ShowStudent(Console.ReadLine()); break;
        case "5": tracker.TopScorer(); break;
        case "6":
            Console.Write("  Average from: "); double lo = double.Parse(Console.ReadLine());
            Console.Write("  Average to: "); double hi = double.Parse(Console.ReadLine());
            tracker.FilterByAverage(lo, hi); break;
        case "7":
            Console.Write("  Student ID to remove: ");
            tracker.Remove(Console.ReadLine()); break;
        case "8": tracker.Statistics(); break;
        case "0": Console.WriteLine("  Goodbye!"); running = false; break;
        default: Console.WriteLine("  Invalid option."); break;
    }
}


// CTRL + K =>Ctrl + E

// CTRL K, Ctrl F