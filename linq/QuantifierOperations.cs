/*
Topic: LINQ Quantifier and Element Operators
Goal: Understand how to evaluate conditions and safely retrieve elements
Key Concepts:
    - Any(), All()
    - First(), FirstOrDefault()
    - Single(), SingleOrDefault()

What this file demonstrates:
    - Checking existence of elements based on conditions
    - Validating constraints across datasets
    - Safely retrieving elements without runtime exceptions
    - Understanding when different element operators should be used

Why it matters:
    These operators are critical in:
    - Business rule validation
    - Defensive programming
    - Avoiding runtime errors in real-world applications
*/

using System;
using System.Collections.Generic;
using System.Linq;
using Linq.Models;

namespace Linq
{
    internal class QuantifierOperations
    {
        static void Main()
        {
            List<Student> students = new List<Student>
            {
                new Student { Id = 1, Name = "Anu", Age = 20, Grade = 85, Department = "Computer Science" },
                new Student { Id = 2, Name = "Rahul", Age = 22, Grade = 91, Department = "Mathematics" },
                new Student { Id = 3, Name = "Maya", Age = 19, Grade = 78, Department = "Computer Science" },
                new Student { Id = 4, Name = "Vishnu", Age = 21, Grade = 95, Department = "Physics" },
                new Student { Id = 5, Name = "Devika", Age = 20, Grade = 88, Department = "Mathematics" }
            };
            Console.WriteLine("Quantifier Operations\n");

            // Any(): check existence
            bool hasHighScorer = students.Any(s => s.Grade >= 90);
            Console.WriteLine($"Any student with grade >= 90? {hasHighScorer}");
            bool hasPhysics = students.Any(s => s.Department == "Physics");
            Console.WriteLine($"Any student in Physics? {hasPhysics}");

            // All(): validate all elements
            bool allPassed = students.All(s => s.Grade >= 35);
            Console.WriteLine($"\nAll students passed (>=35)? {allPassed}");

            bool allAdults = students.All(s => s.Age >= 18);
            Console.WriteLine($"All students are adults? {allAdults}");

            // First() vs FirstOrDefault()
            var firstTopper = students.First(s => s.Grade >= 90);
            Console.WriteLine($"\nFirst student with grade >= 90: {firstTopper.Name}");
            var firstFromBiology = students.FirstOrDefault(s => s.Department == "Biology");
            if (firstFromBiology == null)
            {
                Console.WriteLine("No student found in Biology (FirstOrDefault returned null)");
            }

            // Single() vs SingleOrDefault()
            try
            {
                var uniqueIdStudent = students.Single(s => s.Id == 3);
                Console.WriteLine($"\nStudent with ID 3: {uniqueIdStudent.Name}");
            }
            catch (Exception)
            {
                Console.WriteLine("Single() failed: more than one or no match found");
            }

            var nonExisting = students.SingleOrDefault(s => s.Id == 100);
            if (nonExisting == null)
            {
                Console.WriteLine("No student found with ID 100 (SingleOrDefault returned null)");
            }
        }
    }
}
