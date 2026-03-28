// Topic: Queue<T> and FIFO Processing
// Goal: Understand how Queue works using a task-processing scenario
// Key Idea: Queue follows First-In-First-Out (FIFO) order

using System;
using System.Collections.Generic;

namespace Collections.QueueStack
{
    internal class QueueExample
    {
        static void Main()
        {
            Console.WriteLine("Queue<T> Demonstration (FIFO Processing)\n");

            Queue<string> taskQueue = new Queue<string>();

            Console.Write("Enter tasks separated by comma or space: ");
            string input = Console.ReadLine();

            string[] tasks = input.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string task in tasks)
            {
                taskQueue.Enqueue(task.Trim());
            }

            Console.WriteLine("\nTasks added to queue:");
            PrintQueue(taskQueue);

            // Processing tasks (FIFO)
            Console.WriteLine("\nProcessing tasks:\n");

            while (taskQueue.Count > 0)
            {
                string currentTask = taskQueue.Dequeue();

                Console.WriteLine($"Processing: {currentTask}");
                Console.WriteLine($"Remaining tasks: {taskQueue.Count}\n");
            }

            // -------------------------------
            // Peek example
            // -------------------------------
            Console.WriteLine("Queue is now empty.\n");

            Console.Write("Add one more task: ");
            string newTask = Console.ReadLine();

            taskQueue.Enqueue(newTask);

            Console.WriteLine($"Next task to process (Peek): {taskQueue.Peek()}");
        }

        static void PrintQueue(Queue<string> queue)
        {
            foreach (var item in queue)
            {
                Console.Write(item + " -> ");
            }
            Console.WriteLine("END");
        }
    }
}

/*
Sample Output:

Queue<T> Demonstration (FIFO Processing)

Enter tasks separated by comma or space: 5 10 15 

Tasks added to queue:
5 -> 10 -> 15 -> END

Processing tasks:

Processing: 5
Remaining tasks: 2

Processing: 10
Remaining tasks: 1

Processing: 15
Remaining tasks: 0

Queue is now empty.

Add one more task: 30
Next task to process (Peek): 30
*/

/*
Key Concepts:

Queue<T>:
    A collection that follows FIFO (First-In-First-Out)

Core Operations:

Enqueue() → Add item to the end
Dequeue() → Remove item from the front
Peek()    → View front item without removing it

Behavior:

First added → First processed

Real-World Use Cases:

- Task scheduling
- Print queue systems
- Message processing systems
- Request handling (servers)

Time Complexity:

Enqueue → O(1)
Dequeue → O(1)
Peek    → O(1)

Important Note:

Queue processes elements in strict order,
making it ideal for sequential workflows.
*/
