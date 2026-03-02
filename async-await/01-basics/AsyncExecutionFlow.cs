// Topic: Async Execution Flow
// Goal: Start an async task and await it later
// Key Idea: async work can run while Main continues

using System;
using System.Threading.Tasks;

namespace AsyncAwait.Basics
{
    internal class AsyncExecutionFlow
    {
        static async Task Main()
        {
            Console.WriteLine("=== Async Demonstration ===");

            // Start async work but DO NOT wait immediately
            var task = RunAsync();

            Console.WriteLine("Main continues doing other work...");

            // Wait later
            await task;

            Console.WriteLine("Main finished");
        }

        // Asynchronous version (non-blocking)
        static async Task RunAsync()
        {
            Console.WriteLine("Async Start");

            await SimulateWorkAsync();

            Console.WriteLine("Async End");
        }

        static async Task SimulateWorkAsync()
        {
            Console.WriteLine("Async Working...");
            await Task.Delay(2000); // non-blocking delay
        }
    }
}

// Expected Behavior:
// - Async task starts immediately.
// - Main continues execution before await.
// - Program waits only at 'await task'.
