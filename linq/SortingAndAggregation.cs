/*
Topic: LINQ Sorting and Aggregation
Goal: Demonstrate how to order and analyze data using LINQ
Key Concepts:
    - OrderBy(), OrderByDescending(), ThenBy()
    - Count(), Average(), Max(), Min(), Sum()

What this file demonstrates:
    - Sorting data based on single and multiple fields
    - Extracting top-performing records
    - Performing aggregate calculations on datasets

Why it matters:
    These operations are essential for:
    - Reporting and analytics
    - Ranking and filtering results
    - Summarizing large datasets efficiently
*/

using System;
using System.Collections.Generic;
using System.Linq;
using Linq.Models;

namespace Linq
{
    internal class SortingAndAggregation
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
            Console.WriteLine("Original Data:\n");
            PrintStudents(students);

            // Sorting
            var sortedByGradeDesc = students
                .OrderByDescending(s => s.Grade);
            Console.WriteLine("\nStudents sorted by Grade (Descending):\n");
            PrintStudents(sortedByGradeDesc);
            var sortedByDeptThenGrade = students
                .OrderBy(s => s.Department)
                .ThenByDescending(s => s.Grade);
            Console.WriteLine("\nSorted by Department, then Grade:\n");
            PrintStudents(sortedByDeptThenGrade);

            // Top performer
            var topStudent = students
                .OrderByDescending(s => s.Grade)
                .First();

            Console.WriteLine($"\nTop Performer: {topStudent.Name} ({topStudent.Grade})");
            // Aggregation
            int totalStudents = students.Count();
            double averageGrade = students.Average(s => s.Grade);
            double maxGrade = students.Max(s => s.Grade);
            double minGrade = students.Min(s => s.Grade);
            double totalGrades = students.Sum(s => s.Grade);
          
            Console.WriteLine("\nAggregate Data:");
            Console.WriteLine($"Total Students: {totalStudents}");
            Console.WriteLine($"Average Grade: {averageGrade:F2}");
            Console.WriteLine($"Max Grade: {maxGrade}");
            Console.WriteLine($"Min Grade: {minGrade}");
            Console.WriteLine($"Sum of Grades: {totalGrades}");
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
