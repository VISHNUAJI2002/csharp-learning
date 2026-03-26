// Topic: HashSet<T> Usage and Set Operations
// Goal: Understand how HashSet ensures uniqueness and supports fast lookups
// Key Idea: HashSet provides O(1) average-time operations and is ideal for uniqueness-based problems

using System;
using System.Collections.Generic;

namespace Collections.HashSet
{
    internal class HashSetUsage
    {
        static void Main()
        {
            Console.WriteLine("HashSet<T> Demonstration\n");

            // User input
            Console.Write("Enter numbers separated by space: ");
            string input = Console.ReadLine();

            string[] parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            List<int> numbers = new List<int>();
            foreach (string part in parts)
            {
                numbers.Add(int.Parse(part));
            }

            Console.WriteLine("\nOriginal List:");
            PrintCollection(numbers);

            // Removing duplicates using HashSet
            HashSet<int> uniqueNumbers = new HashSet<int>(numbers);

            Console.WriteLine("\nAfter removing duplicates (HashSet):");
            PrintCollection(uniqueNumbers);


            // Fast lookup demonstration
            Console.Write("\nEnter a number to search: ");
            int target = int.Parse(Console.ReadLine());

            bool foundInList = numbers.Contains(target);
            bool foundInSet = uniqueNumbers.Contains(target);

            Console.WriteLine($"\nFound in List? {foundInList}");
            Console.WriteLine($"Found in HashSet? {foundInSet}");

            // Set operations
            Console.WriteLine("\nSet Operations:\n");

            HashSet<int> setA = new HashSet<int> { 1, 2, 3, 4 };
            HashSet<int> setB = new HashSet<int> { 3, 4, 5, 6 };
            
            Console.WriteLine("Set A:");
            PrintCollection(setA);
            Console.WriteLine("Set B:");
            PrintCollection(setB);
            
            // Union
            HashSet<int> union = new HashSet<int>(setA);
            union.UnionWith(setB);

            Console.WriteLine("\nUnion (A ∪ B):");
            PrintCollection(union);

            // Intersection
            HashSet<int> intersection = new HashSet<int>(setA);
            intersection.IntersectWith(setB);

            Console.WriteLine("\nIntersection (A ∩ B):");
            PrintCollection(intersection);

            // Difference
            HashSet<int> difference = new HashSet<int>(setA);
            difference.ExceptWith(setB);

            Console.WriteLine("\nDifference (A - B):");
            PrintCollection(difference);
        }

        static void PrintCollection(IEnumerable<int> collection)
        {
            foreach (var item in collection)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
    }
}

/*
Sample Output:

HashSet<T> Demonstration

Enter numbers separated by space: 5 10 5 15 20 10

Original List:
5 10 5 15 20 10 

After removing duplicates (HashSet):
5 10 15 20 

Enter a number to search: 10

Found in List? True
Found in HashSet? True

Set Operations:

Set A:
1 2 3 4 
Set B:
3 4 5 6 

Union (A ∪ B):
1 2 3 4 5 6 

Intersection (A ∩ B):
3 4 

Difference (A - B):
1 2 


Key Concepts:

HashSet<T>:
    Stores unique elements (no duplicates allowed)

Why use HashSet?

- Automatic duplicate removal
- Fast lookup (O(1) average)
- Ideal for membership checks

Comparison with List:

List:
    Allows duplicates
    Lookup → O(n)

HashSet:
    No duplicates
    Lookup → O(1)

Set Operations:

Union:
    Combines elements from both sets

Intersection:
    Common elements between sets

Difference:
    Elements in one set but not in another
*/
