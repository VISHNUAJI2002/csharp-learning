// Topic: List<T> Basics
// Goal: Understand how to use List<T> for dynamic collections
// Key Idea: List<T> is a resizable array with rich built-in methods

using System;
using System.Collections.Generic;

namespace Collections.List
{
    internal class ListBasics
    {
        static void Main()
        {
            Console.WriteLine("Working with List<T>\n");
            // Initialization
            // Method 1: Empty list
            List<int> numbers = new List<int>();

            // Method 2: Collection initializer
            numbers = new List<int> { 10, 20, 30 };

            Console.WriteLine("Initial List:");
            PrintList(numbers);

            // Dynamic resizing (Capacity)
            Console.WriteLine($"\nInitial Capacity: {numbers.Capacity}");

            numbers.Add(40);
            numbers.Add(50);

            Console.WriteLine($"Capacity after adding elements: {numbers.Capacity}");
            Console.WriteLine("List after adding elements:");
            PrintList(numbers);

            // Insert operation
            numbers.Insert(1, 15);

            Console.WriteLine("\nAfter inserting 15 at index 1:");
            PrintList(numbers);

            // Remove operations
            numbers.Remove(20);     // removes first occurrence
            numbers.RemoveAt(0);    // removes element at index

            Console.WriteLine("\nAfter removing elements:");
            PrintList(numbers);

            // Accessing elements
            Console.WriteLine($"\nElement at index 1: {numbers[1]}");

            // Searching
            Console.WriteLine($"Contains 30? {numbers.Contains(30)}");

            Console.WriteLine($"Total elements: {numbers.Count}");

            Console.WriteLine("\nIterating using foreach:");
            foreach (int num in numbers)
            {
                Console.WriteLine(num);
            }
            numbers.Clear();

            Console.WriteLine("\nAfter clearing the list:");
            PrintList(numbers);
        }

        static void PrintList(List<int> list)
        {
            if (list.Count == 0)
            {
                Console.WriteLine("(empty)");
                return;
            }

            foreach (int item in list)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
    }
}

/*
Execution Flow:

1. A List<int> is created using both empty and initializer approaches.
2. Elements are added dynamically using Add().
3. Capacity is observed to understand internal resizing.
4. Insert() adds an element at a specific index.
5. Remove() and RemoveAt() delete elements.
6. Elements are accessed using index.
7. Contains() checks existence.
8. Count gives total elements.
9. The list is iterated using foreach.
10. Clear() removes all elements.

Important Concepts:

List<T>
    A dynamic array that automatically resizes as elements are added.

Key Operations:
    Add()       → append element
    Insert()    → insert at index
    Remove()    → remove by value
    RemoveAt()  → remove by index
    Contains()  → check existence
    Clear()     → remove all elements

Capacity vs Count:
    Count     → number of elements in the list
    Capacity  → internal array size

    Capacity grows automatically when needed.

Why List<T> over Array?

Array:
    Fixed size
    Faster in low-level scenarios
    Less flexible

List<T>:
    Dynamic size
    Rich built-in methods
    Easier to work with in most applications

Time Complexity:

Add()       → O(1) (amortized)
Insert()    → O(n)
Remove()    → O(n)
Access      → O(1)

Note:

List<T> internally uses an array.
When capacity is exceeded, a larger array is allocated
and elements are copied over.
*/
