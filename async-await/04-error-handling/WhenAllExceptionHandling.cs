// Topic: Exception Handling with Task.WhenAll
// Goal: Demonstrate how multiple exceptions behave when awaiting Task.WhenAll
// Key Idea: When multiple tasks fail, their exceptions are aggregated

using System;
using System.Threading.Tasks;

namespace AsyncAwait.ErrorHandling
{
    internal class WhenAllExceptionHandling
    {
        static async Task Main()
        {
            Console.WriteLine("Starting multiple async operations...\n");

            Task task1 = FailingOperationAsync("Operation A", 1500);
            Task task2 = FailingOperationAsync("Operation B", 1000);
            Task task3 = SuccessfulOperationAsync("Operation C", 2000);

            Task allTasks = Task.WhenAll(task1, task2, task3);

            try
            {
                await allTasks;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception caught in Main: {ex.Message}\n");

                if (allTasks.Exception != null)
                {
                    Console.WriteLine("All captured exceptions:");

                    foreach (var inner in allTasks.Exception.InnerExceptions)
                    {
                        Console.WriteLine($" - {inner.Message}");
                    }
                }
            }

            Console.WriteLine("\nProgram completed.");
        }

        static async Task FailingOperationAsync(string name, int delay)
        {
            Console.WriteLine($"{name} started.");

            await Task.Delay(delay);

            Console.WriteLine($"{name} failed.");

            throw new InvalidOperationException($"{name} encountered an error.");
        }

        static async Task SuccessfulOperationAsync(string name, int delay)
        {
            Console.WriteLine($"{name} started.");

            await Task.Delay(delay);

            Console.WriteLine($"{name} completed successfully.");
        }
    }
}

/*
Execution Flow:

1. Three async operations start concurrently.
2. Operation A and Operation B throw exceptions.
3. Task.WhenAll waits for all tasks to complete.
4. Multiple exceptions are captured inside the Task.WhenAll task.
5. When awaited, one exception is thrown to the caller.(first occured exception)
6. The full set of exceptions can be accessed through Task.Exception.InnerExceptions.

Important Concept:

Multiple async failures → AggregateException inside Task.WhenAll

await Task.WhenAll(...) throws one exception
but the Task still contains all exceptions.

*/
