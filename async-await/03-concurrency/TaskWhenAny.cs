// Topic: Task.WhenAny for First-Completed Task
// Goal: Continue execution when the earliest task finishes
// Key Idea: Task.WhenAny returns the task that completes first

using System;
using System.Threading.Tasks;

namespace AsyncAwait.Concurrency
{
    internal class TaskWhenAny
    {
        static async Task Main()
        {
            Console.WriteLine("Starting multiple service requests...\n");

            Task<string> serviceA = FetchDataAsync("Service A", 3000);
            Task<string> serviceB = FetchDataAsync("Service B", 1500);
            Task<string> serviceC = FetchDataAsync("Service C", 2000);

            Task<string> firstCompleted = await Task.WhenAny(serviceA, serviceB, serviceC);

            Console.WriteLine($"\nFirst completed task result: {await firstCompleted}");

            Console.WriteLine("\nWaiting for the remaining tasks to complete...");

            string[] allResults = await Task.WhenAll(serviceA, serviceB, serviceC);

            Console.WriteLine("\nAll services finished:");
            foreach (var result in allResults)
            {
                Console.WriteLine(result);
            }
        }

        static async Task<string> FetchDataAsync(string serviceName, int delay)
        {
            Console.WriteLine($"{serviceName} request started.");

            await Task.Delay(delay);

            Console.WriteLine($"{serviceName} response received.");

            return $"{serviceName} data processed.";
        }
    }
}

/*
Expected Behavior:

1. All service requests start nearly simultaneously.
2. Task.WhenAny returns as soon as the fastest task completes.
3. The result of that first completed task is processed immediately.
4. Task.WhenAll is then used to wait for the remaining tasks.
*/
