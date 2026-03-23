// Topic: List<T> vs Array
// Goal: Understand the differences between List<T> and arrays and when to use each
// Key Idea: Arrays are fixed-size and efficient, while List<T> is flexible and feature-rich

using System;
using System.Collections.Generic;

namespace Collections.List
{
    internal class ListVsArray
    {
        static void Main()
        {
            Console.WriteLine("List<T> vs Array\n");

            // Array Example
            int[] array = new int[3] { 10, 20, 30 };

            Console.WriteLine("Array:");
            PrintArray(array);

            // Arrays have fixed size
            // To add more elements, a new array must be created
            Console.WriteLine("\nResizing array (manual process)...");

            int[] resizedArray = new int[5];

            for (int i = 0; i < array.Length; i++)
            {
                resizedArray[i] = array[i];
            }

            resizedArray[3] = 40;
            resizedArray[4] = 50;

            Console.WriteLine("Resized Array:");
            PrintArray(resizedArray);


            // List<T> Example
            List<int> list = new List<int> { 10, 20, 30 };

            Console.WriteLine("\nList<T>:");
            PrintList(list);

            // Capacity demonstration (internal resizing)
            Console.WriteLine($"\nInitial List Capacity: {list.Capacity}");

            list.Add(40);
            list.Add(50);

            Console.WriteLine($"Capacity after adding elements: {list.Capacity}");
            Console.WriteLine("List after adding elements:");
            PrintList(list);


            // Built-in features of List<T>
            Console.WriteLine("\nList<T> features:");

            Console.WriteLine($"Contains 20? {list.Contains(20)}");
            Console.WriteLine($"Index of 30: {list.IndexOf(30)}");

            list.Remove(10);
            Console.WriteLine("After removing 10:");
            PrintList(list);

            // Conversion between Array and List
            List<int> listFromArray = new List<int>(array);
            Console.WriteLine("\nList created from array:");
            PrintList(listFromArray);

            int[] arrayFromList = list.ToArray();
            Console.WriteLine("Array created from list:");
            PrintArray(arrayFromList);

            // Iteration comparison
            Console.WriteLine("\nIteration comparison:");

            Console.WriteLine("Array using index:");
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();

            Console.WriteLine("List using foreach:");
            foreach (var item in list)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();

            // Access comparison
            Console.WriteLine("\nAccess comparison:");
            Console.WriteLine($"Array access [1]: {array[1]}");
            Console.WriteLine($"List access [1]: {list[1]}");
        }

        static void PrintArray(int[] arr)
        {
            foreach (int item in arr)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }

        static void PrintList(List<int> list)
        {
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

1. An array is created with a fixed size.
2. To "resize" the array, a new array is created and elements are copied manually.
3. A List<T> is created and elements are added dynamically.
4. Capacity is observed to understand internal resizing.
5. Built-in methods like Contains(), IndexOf(), and Remove() are demonstrated.
6. Conversion between Array and List is shown.
7. Iteration using index and foreach is compared.
8. Both structures are accessed using index.

Important Differences:

Array:
    Fixed size
    Continuous memory allocation
    Slightly faster in tight loops
    Requires manual resizing

List<T>:
    Dynamic size
    Uses an internal array
    Automatically resizes when capacity is exceeded
    Rich built-in methods (Add, Remove, Find, etc.)
    Easier to use in most applications

When to use Array:

- Size is known and fixed
- Performance-critical scenarios
- Low-level or memory-sensitive operations

When to use List<T>:

- Size changes frequently
- Need built-in operations (search, remove, etc.)
- General application development

Time Complexity:

Access (Array/List) → O(1)
Add (List)         → O(1) amortized
Insert/Remove      → O(n)
*/
