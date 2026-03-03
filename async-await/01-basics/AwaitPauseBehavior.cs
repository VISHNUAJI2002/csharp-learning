// Topic: Await Pause Behavior
// Goal: Understand that 'await' pauses only the current method
// Key Idea: Control returns to the caller until awaited task completes

using System;
using System.Threading.Tasks;

namespace AsyncAwait.Basics
{
    internal class AwaitPauseBehavior
    {
        static async Task Main()
        {
            Console.WriteLine("Main started");

            var task = DoWorkAsync();

            Console.WriteLine("Main continues after calling DoWorkAsync");

            await task;

            Console.WriteLine("Main finished");
        }

        static async Task DoWorkAsync()
        {
            Console.WriteLine("DoWorkAsync started");

            await Task.Delay(2000);

            Console.WriteLine("DoWorkAsync resumed after await");
        }
    }
}

// Expected Behavior:
// - DoWorkAsync starts.
// - Execution reaches await and returns control to Main.
// - Main continues.
// - After delay, DoWorkAsync resumes.
