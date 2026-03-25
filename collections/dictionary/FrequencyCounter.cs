// Topic: Frequency Counting using Dictionary<TKey, TValue>
// Goal: Use Dictionary to count occurrences of elements efficiently
// Key Idea: Dictionary enables O(1) updates for counting patterns

using System;
using System.Collections.Generic;

namespace Collections.Dictionary
{
    internal class FrequencyCounter
    {
        static void Main()
        {
            Console.WriteLine("Frequency Counter using Dictionary\n");

            Console.Write("Enter a string: ");
            
            string input = Console.ReadLine();
            
            Dictionary<char, int> frequencyMap = new Dictionary<char, int>();

            foreach (char ch in input)
            {
                if (frequencyMap.ContainsKey(ch))
                {
                    frequencyMap[ch]++;
                }
                else
                {
                    frequencyMap[ch] = 1;
                }
            }

            Console.WriteLine("Character frequencies:");

            foreach (var pair in frequencyMap)
            {
                Console.WriteLine($"{pair.Key} : {pair.Value}");
            }

            //  word frequency example
            Console.WriteLine("\nWord frequency example:\n");

            string sentence = "this is a test this is only a test";
            string[] words = sentence.Split(' ');

            Dictionary<string, int> wordFrequency = new Dictionary<string, int>();

            foreach (string word in words)
            {
                if (wordFrequency.ContainsKey(word))
                {
                    wordFrequency[word]++;
                }
                else
                {
                    wordFrequency[word] = 1;
                }
            }

            foreach (var pair in wordFrequency)
            {
                Console.WriteLine($"{pair.Key} : {pair.Value}");
            }
        }
    }
}

/*
Key Insight:

Frequency counting is a common pattern where:

- Keys represent unique elements
- Values represent counts

Dictionary is ideal because:

- Lookup is O(1) on average
- Updates are efficient
- Avoids nested loops (which would be O(n^2))

Sample Output:

Frequency Counter using Dictionary

Enter a string: Programming
Character frequencies:
P : 1
r : 2
o : 1
g : 2
a : 1
m : 2
i : 1
n : 1

Word frequency example:

this : 2
is : 2
a : 2
test : 2
only : 1

*/
