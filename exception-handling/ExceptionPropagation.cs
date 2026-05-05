/*
Topic: Exception Propagation Across Methods
Goal: Understand how exceptions travel through call stacks and where they should be handled
Key Concepts:
    - Exception propagation (bubbling up)
    - Layered method design
    - Responsibility of handling exceptions
    - Avoiding unnecessary try-catch blocks

What this file demonstrates:
    - Exceptions originating in lower-level methods
    - Propagation through intermediate layers
    - Centralized handling at the top level
    - Preserving stack trace and context

Why it matters:
    In real applications:
    - Lower layers should NOT always handle exceptions
    - Exceptions should be handled at the appropriate level
    - Improper handling can hide bugs or lose context
*/

using System;

namespace ExceptionHandling
{
    internal class ExceptionPropagation
    {
        static void Main()
        {
            Console.WriteLine("Exception Propagation Demonstration\n");

            try
            {
                ProcessData();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught in Main()");
                Console.WriteLine($"Message: {ex.Message}");
                Console.WriteLine($"Source: {ex.Source}");
            }
        }

        // Top-level business method
        static void ProcessData()
        {
            Console.WriteLine("Processing data...\n");
            // No try-catch here → let exception propagate
            int result = PerformCalculation();
            Console.WriteLine($"Result: {result}");
        }
        // Intermediate method (still does NOT handle exception)
        static int PerformCalculation()
        {
            Console.WriteLine("Performing calculation...");
            int value = GetInput();
            // Potential exception point (DivideByZero)
            return 100 / value;
        }

        // Lowest-level method (source of error)
        static int GetInput()
        {
            Console.Write("Enter a number: ");
            string input = Console.ReadLine();
            // This can throw FormatException or OverflowException
            return int.Parse(input);
        }
    }
}
