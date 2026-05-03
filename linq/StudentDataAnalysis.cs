/*
Topic: Real-World Student Data Analysis using LINQ
Goal: Combine multiple LINQ operations to analyze a dataset
Key Concepts:
    - Filtering, sorting, grouping, aggregation
    - Quantifiers and safe retrieval
    - Combining multiple queries for insights

What this file demonstrates:
    - Extracting meaningful insights from a dataset
    - Identifying top performers and underperformers
    - Department-wise analysis
    - Real-world query composition

Why it matters:
    This reflects how LINQ is actually used in:
    - Backend services
    - Reporting systems
    - Data transformation layers
*/

using System;
using System.Collections.Generic;
using System.Linq;
using Linq.Models;

namespace Linq
{
    internal class StudentDataAnalysis
    {
        static void Main()
        {
            List<Student> students = new List<Student>
            {
                new Student { Id = 1, Name = "Anu", Age = 20, Grade = 85, Department = "Computer Science" },
                new Student { Id = 2, Name = "Rahul", Age = 22, Grade = 91, Department = "Mathematics" },
                new Student { Id = 3, Name = "Maya", Age = 19, Grade = 78, Department = "Computer Science" },
                new Student { Id = 4, Name = "Vishnu", Age = 21, Grade = 95, Department = "Physics" },
                new Student { Id = 5, Name = "Devika", Age = 20, Grade = 88, Department = "Mathematics" },
                new Student { Id = 6, Name = "Arun", Age = 23, Grade = 34, Department = "Physics" },
                new Student { Id = 7, Name = "Meera", Age = 21, Grade = 67, Department = "Computer Science" }
            };

            Console.WriteLine("Student Data Analysis\n");

          // 1. Top performers (>= 90)
            var topStudents = students
                .Where(s => s.Grade >= 90)
                .OrderByDescending(s => s.Grade);
            Console.WriteLine("Top Performers:");
            PrintStudents(topStudents);

            // 2. Failed students (< 35)
            var failedStudents = students
                .Where(s => s.Grade < 35);
            Console.WriteLine("\nFailed Students:");
            PrintStudents(failedStudents);

            // 3. Department-wise average
          var deptAverages = students
                .GroupBy(s => s.Department)
                .Select(g => new
                {
                    Department = g.Key,
                    AvgGrade = g.Average(s => s.Grade)
                });
            Console.WriteLine("\nDepartment-wise Average Grades:");
            foreach (var dept in deptAverages)
            {
                Console.WriteLine($"{dept.Department} : {dept.AvgGrade:F2}");
            }

            // 4. Highest scorer per department
            var topByDept = students
                .GroupBy(s => s.Department)
                .Select(g => g.OrderByDescending(s => s.Grade).First());
            Console.WriteLine("\nTop Student per Department:");
            PrintStudents(topByDept);

            // 5. Overall class insights
            double avgGrade = students.Average(s => s.Grade);
            int totalStudents = students.Count();
            Console.WriteLine("\nClass Insights:");
            Console.WriteLine($"Total Students: {totalStudents}");
            Console.WriteLine($"Average Grade: {avgGrade:F2}");

            // 6. Above average students
            var aboveAverage = students
                .Where(s => s.Grade > avgGrade);
            Console.WriteLine("\nStudents Above Average:");
            PrintStudents(aboveAverage);

            // 7. Validation checks
            bool allPassed = students.All(s => s.Grade >= 35);
            bool anyTopper = students.Any(s => s.Grade >= 95);
            Console.WriteLine("\nValidation:");
            Console.WriteLine($"All students passed? {allPassed}");
            Console.WriteLine($"Any student scored >= 95? {anyTopper}");
        }
        static void PrintStudents(IEnumerable<Student> students)
        {
            foreach (var student in students)
            {
                Console.WriteLine(
                    $"{student.Name} | Grade: {student.Grade} | Dept: {student.Department}");
            }
        }
    }
}
