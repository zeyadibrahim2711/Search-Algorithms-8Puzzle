using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace SearchAlgorithmsAI
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] startState = { 1, 2, 3, 4, 0, 6, 7, 5, 8 };
            Puzzle start = new Puzzle(startState);

            Console.WriteLine("8-Puzzle Search Algorithms");
            Console.WriteLine("1. BFS");
            Console.WriteLine("2. DFS");
            Console.WriteLine("3. UCS");
            Console.WriteLine("4. IDS");
            Console.WriteLine("5. A* (Manhattan)");
            Console.WriteLine("6. Hill Climbing");
            Console.Write("Choose algorithm: ");

            int choice = int.Parse(Console.ReadLine());
            Puzzle result = null;

            Stopwatch sw = new Stopwatch();
            sw.Start();

            switch (choice)
            {
                case 1: result = BFS.Search(start); break;
                case 2: result = DFS.Search(start); break;
                case 3: result = UCS.Search(start); break;
                case 4: result = IDS.Search(start); break;
                case 5: result = AStar.Search(start); break;
                case 6: result = HillClimbing.Search(start); break;
                default: Console.WriteLine("Invalid choice"); return;
            }

            sw.Stop();

            if (result == null)
            {
                Console.WriteLine("No solution found.");
                return;
            }

            PrintSolution(result);

            Console.WriteLine($"Time (ms): {sw.ElapsedMilliseconds}");
            Console.ReadLine();
        }

        static void PrintSolution(Puzzle goal)
        {
            Stack<Puzzle> path = new Stack<Puzzle>();
            Puzzle current = goal;

            while (current != null)
            {
                path.Push(current);
                current = current.Parent;
            }

            int steps = path.Count - 1;

            Console.WriteLine("\nSolution Path:\n");

            while (path.Count > 0)
            {
                path.Pop().Print();
            }

            Console.WriteLine($"Steps: {steps}");
        }

    }
}
