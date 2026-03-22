// Topic: Searching and Filtering in List<T>
// Goal: Learn how to retrieve and manipulate elements using predicate-based methods
// Key Idea: List<T> provides built-in methods that use predicates for flexible querying

using System;
using System.Collections.Generic;

namespace Collections.List
{
    internal class ListSearchAndFilter
    {
        static void Main()
        {
            Console.WriteLine("Searching and Filtering with List<T>\n");

            List<int> numbers = new List<int> { 5, 12, 7, 20, 3, 15, 8 };

            Console.WriteLine("Original List:");
            PrintList(numbers);

            // Find: returns first match
            int firstGreaterThan10 = numbers.Find(n => n > 10);
            Console.WriteLine($"\nFirst number > 10: {firstGreaterThan10}");

            // FindLast: returns last match
            int lastEven = numbers.FindLast(n => n % 2 == 0);
            Console.WriteLine($"Last even number: {lastEven}");

            // FindAll: returns all matches
            List<int> evenNumbers = numbers.FindAll(n => n % 2 == 0);

            Console.WriteLine("\nEven numbers:");
            PrintList(evenNumbers);

            // Exists: checks if any match exists
            bool hasNegative = numbers.Exists(n => n < 0);
            Console.WriteLine($"\nContains negative numbers? {hasNegative}");

            // TrueForAll: checks if all elements match condition
            bool allPositive = numbers.TrueForAll(n => n > 0);
            Console.WriteLine($"All numbers are positive? {allPositive}");

            // FindIndex: position of first match
            int indexOfGreaterThan15 = numbers.FindIndex(n => n > 15);
            Console.WriteLine($"Index of first number > 15: {indexOfGreaterThan15}");

            // Edge case: no match found
            int notFound = numbers.Find(n => n > 100);

            if (notFound == default)
            {
                Console.WriteLine("\nNo element found greater than 100.");
            }

            // RemoveAll: remove matching elements
            numbers.RemoveAll(n => n < 10);

            Console.WriteLine("\nAfter removing numbers < 10:");
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
2. Find() retrieves the first element matching a condition.
3. FindLast() retrieves the last matching element.
4. FindAll() retrieves all matching elements.
5. Exists() checks if any element satisfies a condition.
6. TrueForAll() verifies if all elements satisfy a condition.
7. FindIndex() returns the index of the first matching element.
8. An edge case demonstrates behavior when no match is found.
9. RemoveAll() removes elements based on a condition.
*/
