// Topic: Task<T> Returning Values
// Goal: Understand how async methods return results
// Key Idea: Task<T> represents an asynchronous operation that produces a value

using System;
using System.Threading.Tasks;

namespace AsyncAwait.TaskFundamentals
{
    internal class TaskReturningValue
    {
        static async Task Main()
        {
            int x = 3;
            int y = 2;
            
            Console.WriteLine($"Calculating sum of {x} and {y}...");
            Console.WriteLine("Requesting result...");

            int result = await CalculateAsync(x,y);
            Console.WriteLine($"Result received: {result}");
        }

        static async Task<int> CalculateAsync(int a, int b)
        {
            Console.WriteLine("Processing calculation...");
            await Task.Delay(2000);
            return a+b;
        }
    }
}

/*
Expected Behavior:

1. The async method starts execution.
2. The method pauses at 'await Task.Delay'.
3. After the delay, execution resumes.
4. The result is returned through Task<int>.
*/
