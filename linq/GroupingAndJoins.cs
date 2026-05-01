/*
Topic: LINQ Grouping and Joins
Goal: Analyze structured data using grouping and combine datasets using joins
Key Concepts:
    - GroupBy()
    - Projection after grouping
    - Aggregation per group
    - Join()

What this file demonstrates:
    - Grouping students by department
    - Calculating aggregates (count, average) per group
    - Transforming grouped data into structured output
    - Joining two datasets based on a key

Why it matters:
    These patterns are widely used in:
    - Reporting and dashboards
    - Data analysis pipelines
    - Backend data shaping (DTO construction)
*/

using System;
using System.Collections.Generic;
using System.Linq;
using Linq.Models;

namespace Linq
{
    internal class GroupingAndJoins
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
            Console.WriteLine("Grouping by Department\n");
            // GroupBy
            var groupedByDept = students.GroupBy(s => s.Department);

            foreach (var group in groupedByDept)
            {
                Console.WriteLine($"Department: {group.Key}");

                foreach (var student in group)
                {
                    Console.WriteLine($"  {student.Name} ({student.Grade})");
                }

                Console.WriteLine();
            }

            // Aggregation per group
            var deptSummary = students
                .GroupBy(s => s.Department)
                .Select(g => new
                {
                    Department = g.Key,
                    Count = g.Count(),
                    AverageGrade = g.Average(s => s.Grade)
                });

            Console.WriteLine("Department Summary:\n");

            foreach (var dept in deptSummary)
            {
                Console.WriteLine(
                    $"{dept.Department} | Students: {dept.Count} | Avg Grade: {dept.AverageGrade:F2}");
            }

            // Join example
            Console.WriteLine("\nJoining Students with Departments:\n");
            List<Department> departments = new List<Department>
            {
                new Department { Name = "Computer Science", Head = "Dr. Kumar" },
                new Department { Name = "Mathematics", Head = "Dr. Iyer" },
                new Department { Name = "Physics", Head = "Dr. Nair" }
            };
            var joinedData = students.Join(
                departments,
                student => student.Department,
                dept => dept.Name,
                (student, dept) => new
                {
                    student.Name,
                    student.Department,
                    dept.Head
                });
            foreach (var item in joinedData)
            {
                Console.WriteLine(
                    $"{item.Name} | Dept: {item.Department} | Head: {item.Head}");
            }
        }
    }
    internal class Department
    {
        public string Name { get; set; }
        public string Head { get; set; }
    }
}
