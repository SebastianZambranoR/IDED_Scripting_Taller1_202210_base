using System;
using System.Collections.Generic;

namespace TestProject1
{
    internal class Sandbox
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello world");
            Console.WriteLine("Here you can write console prints to test your implementation outside the testing environment");
        }

        public static void PrintStack(Stack<int> giveStack)
        {
            int count = giveStack.Count;
            Console.WriteLine("Imprimiendo stack");
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine(giveStack.Pop());
            }
        }
    }
}