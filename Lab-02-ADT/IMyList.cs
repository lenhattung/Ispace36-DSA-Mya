using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// ADT: a sequence of elements supporting positional access.
/// The interface defines WHAT but never HOW.
/// </summary>
public interface IMyList<T> 
{
    // ── Mutators (change the list) ──────────────────────────
    void Add(T item);                   // append to end         O(?)
    void Insert(int index, T item);     // insert at position    O(?)
    void RemoveAt(int index);           // delete at position    O(?)
    void Clear();                       // remove all elements   O(?)

    // ── Accessors (read without modifying) ──────────────────
    T Get(int index);                // retrieve by position  O(?)
    bool Contains(T item);              // membership test       O(?)
    int IndexOf(T item);               // first occurrence      O(?)

    // ── Properties ──────────────────────────────────────────
    int Count { get; }               // current number of elements
    bool IsEmpty { get; }               // true when Count == 0

    // ── Display ─────────────────────────────────────────────
    void Print();                       // print all elements
}
