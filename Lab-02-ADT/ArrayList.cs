using System;
using System.Collections.Generic;
using System.Text;

public class ArrayList<T> : IMyList<T>
{
    // ── Private fields ──────────────────────────────────────
    private T[] _data;          // the internal storage array
    private int _count;         // how many elements are actually stored
    private const int INIT_CAP = 4;   // starting capacity

    // ── Constructor ──────────────────────────────────────────
    public ArrayList()
    {
        _data = new T[INIT_CAP];
        _count = 0;
    }

    // ── Properties ──────────────────────────────────────────
    public int Count => _count;
    public bool IsEmpty => _count == 0;

    // ── Private helper: resize when full ────────────────────
    private void EnsureCapacity()
    {
        if (_count < _data.Length) return;   // still room — do nothing

        // Double the capacity
        T[] newData = new T[_data.Length * 2];
        Array.Copy(_data, newData, _count);  // copy existing elements
        _data = newData;
        Console.WriteLine($"  [ArrayList] Resized → capacity now {_data.Length}");
    }


    // Add to end — O(1) amortized  (O(n) on resize, but rare)
    public void Add(T item)
    {
        EnsureCapacity();
        _data[_count] = item;
        _count++;
    }


    // Random access by index — O(1)
    public T Get(int index)
    {
        if (index < 0 || index >= _count)
            throw new IndexOutOfRangeException($"Index {index} out of range (count={_count})");
       
        return _data[index];
    }

    // Insert at position — O(n) because of shifting
    public void Insert(int index, T item)
    {
        if (index < 0 || index > _count)
            throw new IndexOutOfRangeException($"Index {index} out of range");
        EnsureCapacity();

        // Shift elements RIGHT to open a gap at `index`
        //  Before: [ A | B | C | D | _ ]   insert X at index 1
        //   After: [ A | X | B | C | D ]
        for (int i = _count; i > index; i--)
            _data[i] = _data[i - 1];

        _data[index] = item;
        _count++;
    }

    // Remove at position — O(n) because of shifting
    public void RemoveAt(int index)
    {
        if (index < 0 || index >= _count)
            throw new IndexOutOfRangeException($"Index {index} out of range");

        // Shift elements LEFT to fill the gap
        //  Before: [ A | B | C | D ]   remove index 1 (B)
        //   After: [ A | C | D | _ ]
        for (int i = index; i < _count - 1; i++)
            _data[i] = _data[i + 1];

        _data[--_count] = default!;   // clear the last slot (GC-friendly)
    }

    // Linear scan — O(n)
    public bool Contains(T item)
    {
        return IndexOf(item) >= 0;
    }

    // First occurrence index or -1 — O(n)
    public int IndexOf(T item)
    {
        for (int i = 0; i < _count; i++)
            if (Equals(_data[i], item)) return i;
        return -1;
    }

    // Discard all elements — O(1)
    public void Clear()
    {
        Array.Clear(_data, 0, _count);
        _count = 0;
    }

    // Print the list contents
    public void Print()
    {
        Console.Write($"List (n={_count}, cap={_data.Length}): [ ");
        for (int i = 0; i < _count; i++)
            Console.Write(i < _count - 1 ? $"{_data[i]}, " : $"{_data[i]}");
        Console.WriteLine(" ]");
    }
}  // end of ArrayList<T>

