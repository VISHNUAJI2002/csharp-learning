// Topic: Exception Propagation in Async Methods
// Goal: Demonstrate how exceptions thrown in async methods propagate through 'await'
// Key Idea: Exceptions inside async tasks are captured by the Task and re-thrown when awaited

using System;
using System.Threading.Tasks;

namespace AsyncAwait.ErrorHandling
{
    internal class AsyncExceptionHandling
    {
        static async Task Main()
        {
            Console.WriteLine("Starting async operation...\n");

            try
            {
                // Start the async operation but do not await immediately
                Task<int> task = PerformRiskyOperationAsync();

                Console.WriteLine("Main continues while the task is running...\n");

                // Await the task result (exception will surface here if the task failed)
                int result = await task;

                Console.WriteLine($"Result: {result}");
            }
            catch (InvalidOperationException ex)
            {
                // Exception thrown inside the async method is caught here
                Console.WriteLine($"Exception caught in Main: {ex.Message}");
            }

            Console.WriteLine("\nProgram completed.");
        }

        static async Task<int> PerformRiskyOperationAsync()
        {
            Console.WriteLine("Async operation started.");

            // Simulate asynchronous work (e.g., API call, database request)
            await Task.Delay(1500);

            Console.WriteLine("Simulating failure...");

            // The exception is not thrown directly to the caller.
            // It is captured inside the Task returned by this method.
            throw new InvalidOperationException("Operation failed during async processing.");
        }
    }
}

/*
Execution Flow:

1. Main starts and initiates the async operation.
2. PerformRiskyOperationAsync begins executing immediately.
3. Main continues execution before awaiting the task.
4. The async method pauses during Task.Delay().
5. After the delay, the async method throws an exception.
6. The exception is captured inside the Task.
7. When 'await task' executes, the exception is re-thrown.
8. The try/catch block in Main catches the exception.

Important Concept:

Async Method Exception Flow:

throw  → exception stored inside Task
await  → exception re-thrown to caller

Note:
If the task is never awaited, the exception remains inside the Task
and may not be observed until the Task is inspected or awaited later.
*/
