/* Topic: Async vs Synchronous Execution
 Goal: Understand how async/await changes execution flow
 Key Idea: async methods do NOT block the main thread */

using System;
using System.Threading.Tasks;

namespace AsyncAwait.Basics
{
    internal class AsyncVsSync
    {
        static async Task Main()
        {
            Console.WriteLine("=== Synchronous Example ===");
            RunSync();

            Console.WriteLine("\n=== Asynchronous Example ===");
            await RunAsync();
        }

        // Synchronous version (blocking)
        static void RunSync()
        {
            Console.WriteLine("Sync Start");

            SimulateWorkSync();

            Console.WriteLine("Sync End");
        }

        static void SimulateWorkSync()
        {
            Console.WriteLine("Sync Working...");
            Task.Delay(2000).Wait(); // blocks thread
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
            await Task.Delay(2000); // non-blocking wait
        }
    }
}
