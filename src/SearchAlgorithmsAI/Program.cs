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
            int[] goalState = { 1, 2, 3, 4, 5, 6, 7, 8, 0 };

            Puzzle start = new Puzzle(startState);

            Console.WriteLine("8-Puzzle Search Algorithms\n");
            Console.WriteLine("1. BFS");
            Console.WriteLine("2. DFS");
            Console.WriteLine("3. A* (Manhattan Distance)");
            Console.WriteLine("4. Hill Climbing");
            Console.Write("\nChoose algorithm: ");

            int choice = int.Parse(Console.ReadLine());

            Puzzle result = null;
            string algorithmName = "";
            bool isOptimal = false;
            int nodesExplored = 0;

            Console.WriteLine("\nInitial State:");
            start.PrintState();

            Console.WriteLine("Goal State:");
            new Puzzle(goalState).PrintState();

            Stopwatch sw = Stopwatch.StartNew();

            if (choice == 1)
            {
                algorithmName = "BFS";
                isOptimal = true;
                result = BFS.ExploreStateSpaceBFS(start);
                nodesExplored = BFS.Nodes;
            }
            else if (choice == 2)
            {
                algorithmName = "DFS";
                isOptimal = false;
                result = DFS.ExploreStateSpaceDFS(start);
                nodesExplored = DFS.Nodes;
            }
            else if (choice == 3)
            {
                algorithmName = "A* (Manhattan Distance)";
                isOptimal = true;
                result = AStar.ExploreStateSpaceAStar(start);
                nodesExplored = AStar.Nodes;
            }
            else if (choice == 4)
            {
                algorithmName = "Hill Climbing";
                isOptimal = false;
                result = HillClimbing.ExploreStateSpaceHillClimbing(start);
                nodesExplored = HillClimbing.Nodes;
            }
            else
            {
                Console.WriteLine("Invalid choice");
                return;
            }

            sw.Stop();

            Console.WriteLine($"\nAlgorithm: {algorithmName}");

            if (result == null)
            {
                Console.WriteLine("No solution found.");
                Console.WriteLine($"Nodes Explored: {nodesExplored}");
                Console.WriteLine($"Time (ms): {sw.ElapsedMilliseconds}");
                return;
            }

            PrintSolution(result);

            Console.WriteLine($"Nodes Explored: {nodesExplored}");
            Console.WriteLine($"Optimal Solution: {(isOptimal ? "Yes" : "No")}");
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
                path.Pop().PrintState();
            }

            Console.WriteLine($"Steps: {steps}\n");
        }
    }
}
