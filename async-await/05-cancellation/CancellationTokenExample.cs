// Topic: Cooperative Cancellation with CancellationToken
// Goal: Demonstrate how multiple asynchronous operations can be cancelled gracefully using CancellationToken
// Key Idea: Cancellation in async programming is cooperative — tasks must observe the token

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAwait.Cancellation
{
    internal class CancellationTokenExample
    {
        static async Task Main()
        {
            Console.WriteLine("Starting cancellable background operations...\n");

            // Create a cancellation source to control all workers
            using CancellationTokenSource cts = new CancellationTokenSource();

            Console.WriteLine("Starting workers...\n");

            // Each worker receives the same CancellationToken so they can observe cancellation
            List<Task> workers = new List<Task>
            {
                ProcessWorkerAsync("Worker A", cts.Token),
                ProcessWorkerAsync("Worker B", cts.Token),
                ProcessWorkerAsync("Worker C", cts.Token)
            };

            Console.WriteLine("Main continues doing its own work while workers run...\n");

            // Simulate Main doing other work while background tasks are running
            await Task.Delay(3500);

            Console.WriteLine("\nCancellation requested.\n");

            // Send cancellation signal to all workers
            cts.Cancel();

            try
            {
                // Wait for all workers to complete (or cancel)
                await Task.WhenAll(workers);
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("One or more operations were cancelled.");
            }

            Console.WriteLine("\nProgram finished.");
        }

        static async Task ProcessWorkerAsync(string workerName, CancellationToken token)
        {
            try
            {
                for (int step = 1; step <= 10; step++)
                {
                    // Check whether cancellation has been requested
                    token.ThrowIfCancellationRequested();

                    Console.WriteLine($"{workerName} processing step {step}");

                    // Simulate work while also observing cancellation
                    await Task.Delay(1000, token);
                }

                Console.WriteLine($"{workerName} completed all steps.");
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine($"{workerName} stopped due to cancellation.");

                // Rethrow so cancellation propagates to Task.WhenAll
                throw;
            }
        }
    }
}

/*
Execution Flow:

1. Main creates a CancellationTokenSource (cts).
2. A CancellationToken from cts is passed to multiple worker tasks.
3. All workers start executing concurrently.
4. Main continues doing its own work while workers run in the background.
5. After a delay, Main requests cancellation using cts.Cancel().
6. The cancellation signal is sent to all workers.
7. Workers detect cancellation via:
     - token.ThrowIfCancellationRequested()
     - Task.Delay(..., token)
8. Each worker throws OperationCanceledException and stops execution.
9. Task.WhenAll observes the cancellation and propagates the exception.
10. Main catches the exception and completes gracefully.

Important Concepts:

CancellationTokenSource
    Responsible for issuing the cancellation signal.

CancellationToken
    Passed to tasks so they can observe and respond to cancellation.

Cooperative Cancellation
    Tasks must explicitly check the token and decide when to stop.

Cancellation-aware APIs
    Methods like Task.Delay(token) automatically respond to cancellation.

Exception Flow:
    throw → exception stored in Task
    await → exception re-thrown to caller

Note:
Cancellation does NOT forcibly terminate a task.
The task must cooperate by observing the token and exiting gracefully.

Sample Output (approximate):

Starting cancellable background operations...

Starting workers...

Worker A processing step 1
Worker B processing step 1
Worker C processing step 1
...

Main continues doing its own work while workers run...

Worker A processing step 2
Worker B processing step 2
Worker C processing step 2
...

Cancellation requested.

Worker A stopped due to cancellation.
Worker B stopped due to cancellation.
Worker C stopped due to cancellation.

One or more operations were cancelled.

Program finished.
*/
