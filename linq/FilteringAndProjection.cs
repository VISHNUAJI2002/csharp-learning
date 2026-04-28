/*
Topic: LINQ Filtering and Projection
Goal: Demonstrate how to filter and transform collections using LINQ
Key Concepts:
    - Where(): filters elements based on conditions
    - Select(): projects specific fields from objects
    - Distinct(): removes duplicate values
    - Method chaining: combining multiple operations

What this file demonstrates:
    - Filtering students based on criteria (e.g., high scorers)
    - Extracting specific fields like names
    - Combining filtering and projection
    - Retrieving unique values from a dataset

Why it matters:
    These operations form the foundation of LINQ and are widely used in:
    - Data querying (databases, APIs)
    - Business logic filtering
    - Transforming data for UI or reporting
*/

using System;
using System.Collections.Generic;
using System.Linq;
using Linq.Models;

namespace Linq
{
    internal class FilteringAndProjection
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

            Console.WriteLine("All Students:\n");
            PrintStudents(students);

            var topScorers = students.Where(s => s.Grade >= 90);

            Console.WriteLine("\nStudents with Grade >= 90:\n");
            PrintStudents(topScorers);

            var studentNames = students.Select(s => s.Name);

            Console.WriteLine("\nStudent Names:");
            foreach (var name in studentNames)
            {
                Console.WriteLine(name);
            }

            var csStudentNames = students
                .Where(s => s.Department == "Computer Science")
                .Select(s => s.Name);

            Console.WriteLine("\nComputer Science Students:");
            foreach (var name in csStudentNames)
            {
                Console.WriteLine(name);
            }

            var departments = students
                .Select(s => s.Department)
                .Distinct();

            Console.WriteLine("\nDistinct Departments:");
            foreach (var dept in departments)
            {
                Console.WriteLine(dept);
            }
        }

        static void PrintStudents(IEnumerable<Student> students)
        {
            foreach (var student in students)
            {
                Console.WriteLine(
                    $"{student.Id} | {student.Name} | Age: {student.Age} | Grade: {student.Grade} | Dept: {student.Department}");
            }
        }
    }
}
