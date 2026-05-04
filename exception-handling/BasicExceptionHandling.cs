/*
Topic: Exception Handling Fundamentals
Goal: Handle runtime errors in a controlled and meaningful way
Key Concepts:
    - try / catch / finally
    - input validation vs exception handling
    - handling specific exceptions
    - maintaining program stability

What this file demonstrates:
    - Safe parsing of user input
    - Preventing application crashes
    - Handling different exception types explicitly
    - Using finally for cleanup logic

Why it matters:
    Proper exception handling ensures:
    - Robust applications
    - Better user experience
    - Easier debugging and maintenance
*/

using System;

namespace ExceptionHandling
{
    internal class BasicExceptionHandling
    {
        static void Main()
        {
            Console.WriteLine("Basic Exception Handling Demonstration\n");
            try
            {
                int number = ReadInteger("Enter a number: ");
                int divisor = ReadInteger("Enter a divisor: ");
                int result = Divide(number, divisor);
                Console.WriteLine($"\nResult: {result}");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine($"Error: Cannot divide by zero. ({ex.Message})");
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Error: Invalid input format. ({ex.Message})");
            }
            catch (OverflowException ex)
            {
                Console.WriteLine($"Error: Number too large or too small. ({ex.Message})");
            }
            catch (Exception ex)
            {
                // Fallback for unexpected errors
                Console.WriteLine($"Unexpected error: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("\nExecution completed.");
            }
        }
        static int ReadInteger(string message)
        {
            Console.Write(message);
            string input = Console.ReadLine();
            // Using int.Parse to intentionally allow exceptions
            return int.Parse(input);
        }

        static int Divide(int a, int b)
        {
            // Let DivideByZeroException occur naturally
            return a / b;
        }
    }
}
