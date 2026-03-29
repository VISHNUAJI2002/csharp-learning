// Topic: Stack<T> and LIFO Processing
// Goal: Understand stack behavior using an undo system
// Key Idea: Stack follows Last-In-First-Out (LIFO) order

using System;
using System.Collections.Generic;

namespace Collections.QueueStack
{
    internal class StackExample
    {
        static void Main()
        {
            Console.WriteLine("Stack<T> Demonstration (Undo System)\n");

            Stack<string> actionStack = new Stack<string>();

            Console.Write("Enter actions separated by comma: ");
            string input = Console.ReadLine();

            string[] actions = input.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            // Push actions to stack
            foreach (string action in actions)
            {
                actionStack.Push(action.Trim());
            }

            Console.WriteLine("\nActions stored in stack:");
            PrintStack(actionStack);

            // Undo operations (LIFO)
            Console.WriteLine("\nPerforming undo operations:\n");

            while (actionStack.Count > 0)
            {
                string lastAction = actionStack.Pop();

                Console.WriteLine($"Undo: {lastAction}");
                Console.WriteLine($"Remaining actions: {actionStack.Count}\n");
                
                if (actionStack.Count > 0)
                {
                    Console.WriteLine("Current stack state:");
                    PrintStack(actionStack);
                }
            
                Console.WriteLine();
            }

            // Peek demonstration
            Console.WriteLine("Stack is now empty.\n");

            Console.Write("Add one action: ");
            string newAction = Console.ReadLine();

            actionStack.Push(newAction);

            Console.WriteLine($"Next action to undo (Peek): {actionStack.Peek()}");
        }

        static void PrintStack(Stack<string> stack)
        {
            Console.WriteLine("(Top → Bottom)");

            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }
        }
    }
}

/*

Sample Output:

Stack<T> Demonstration (Undo System)

Enter actions separated by comma: 5 10 15

Actions stored in stack:
(Top → Bottom)
15
10
5

Performing undo operations:

Undo: 15
Remaining actions: 2

Current stack state:
(Top → Bottom)
10
5

Undo: 10
Remaining actions: 1

Current stack state:
(Top → Bottom)
5

Undo: 5
Remaining actions: 0


Stack is now empty.

Add one action: 20
Next action to undo (Peek): 20
*/

/*
Key Concepts:

Stack<T>:
    A collection that follows LIFO (Last-In-First-Out)

Core Operations:

Push() → Add item to top
Pop()  → Remove top item
Peek() → View top item without removing it

Behavior:

Last added → First removed

Real-World Use Cases:

- Undo/Redo systems
- Browser history (back navigation)
- Expression evaluation
- Call stack in recursion

Time Complexity:

Push → O(1)
Pop  → O(1)
Peek → O(1)

Important Note:

Stack reverses order of processing compared to Queue,
making it ideal for undo and backtracking scenarios.
*/
