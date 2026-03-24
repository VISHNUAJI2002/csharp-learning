// Topic: Dictionary<TKey, TValue> Basics
// Goal: Understand how to store and retrieve data using key-value pairs
// Key Idea: Dictionary provides fast lookup using keys (average O(1) time complexity)

using System;
using System.Collections.Generic;

namespace Collections.Dictionary
{
    internal class DictionaryBasics
    {
        static void Main()
        {
            Console.WriteLine("Working with Dictionary<TKey, TValue>\n");

            // Creating a dictionary
            Dictionary<string, int> studentMarks = new Dictionary<string, int>();

            // Adding elements
            studentMarks.Add("Alfred", 85);
            studentMarks.Add("Borden", 90);
            studentMarks.Add("Caine", 78);

            Console.WriteLine("Initial Dictionary:");
            PrintDictionary(studentMarks);

            // Accessing values
            Console.WriteLine($"\nMarks of Borden: {studentMarks["Borden"]}");

            // Safe access using TryGetValue
            if (studentMarks.TryGetValue("David", out int marks))
            {
                Console.WriteLine($"Marks of David: {marks}");
            }
            else
            {
                Console.WriteLine("David not found in dictionary.");
            }

            // Updating values
            studentMarks["Alfred"] = 95;

            Console.WriteLine("\nAfter updating Alfred's marks:");
            PrintDictionary(studentMarks);

            // Checking existence
            Console.WriteLine($"\nContains key 'Caine'? {studentMarks.ContainsKey("Caine")}");
            Console.WriteLine($"Contains value 90? {studentMarks.ContainsValue(90)}");

            // Removing elements
            studentMarks.Remove("Borden");

            Console.WriteLine("\nAfter removing Borden:");
            PrintDictionary(studentMarks);

            // Iterating through dictionary
            Console.WriteLine("\nIterating using foreach:");

            foreach (var pair in studentMarks)
            {
                Console.WriteLine($"Key: {pair.Key}, Value: {pair.Value}");
            }

            // Count
            Console.WriteLine($"\nTotal entries: {studentMarks.Count}");
        }

        static void PrintDictionary(Dictionary<string, int> dict)
        {
            if (dict.Count == 0)
            {
                Console.WriteLine("(empty)");
                return;
            }

            foreach (var pair in dict)
            {
                Console.WriteLine($"{pair.Key} : {pair.Value}");
            }
        }
    }
}

/*
Important Concepts:

Dictionary<TKey, TValue>:
    Stores data as key-value pairs.

Key Properties:
    Each key must be unique.
    Values can be duplicated.

Access Patterns:
    dict[key]           → direct access (throws exception if key not found)
    TryGetValue()       → safe access

Time Complexity:

Lookup (by key) → O(1) average
Insert          → O(1) average
Remove          → O(1) average
*/
