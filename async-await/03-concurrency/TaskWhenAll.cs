// Topic: Task.WhenAll for Concurrent Execution
// Goal: Execute multiple asynchronous operations concurrently
// Key Idea: Task.WhenAll awaits completion of multiple tasks running in parallel

using System;
using System.Threading.Tasks;

namespace AsyncAwait.Concurrency
{
    internal class TaskWhenAll
    {
        static async Task Main()
        {
            Console.WriteLine("Starting concurrent operations...\n");

            Task<string> task1 = FetchDataAsync("Service A", 2000);
            Task<string> task2 = FetchDataAsync("Service B", 3000);
            Task<string> task3 = FetchDataAsync("Service C", 1500);

            string[] results = await Task.WhenAll(task1, task2, task3);

            Console.WriteLine("\nAll services completed. Results:");

            foreach (string result in results)
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

1. All three async operations start nearly at the same time.
2. Each task completes independently based on its delay.
3. Task.WhenAll waits until all tasks are finished.
4. Results from each task are returned as an array.
*/
