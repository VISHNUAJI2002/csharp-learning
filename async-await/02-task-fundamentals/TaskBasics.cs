// Topic: Task Basics
// Goal: Understand what a Task represents
// Key Idea: A Task represents an asynchronous operation that may run concurrently

using System;
using System.Threading.Tasks;

namespace AsyncAwait.TaskFundamentals
{
    internal class TaskBasics
    {
        static async Task Main()
        {
            Console.WriteLine("Main started");

            Task workTask = DoWorkAsync();

            Console.WriteLine("Main continues while task runs...");

            await workTask;

            Console.WriteLine("Main finished");
        }

        static async Task DoWorkAsync()
        {
            Console.WriteLine("Task started");

            await Task.Delay(2000);

            Console.WriteLine("Task completed");
        }
    }
}

/*
Expected Behavior:

1. A Task represents an ongoing asynchronous operation.
2. The task starts executing immediately after it is created.
3. The caller can continue execution until it chooses to await the task.
*/
