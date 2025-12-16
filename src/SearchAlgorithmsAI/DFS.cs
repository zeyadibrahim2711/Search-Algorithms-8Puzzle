using System;
using System.Collections.Generic;

namespace SearchAlgorithmsAI
{
    public class DFS
    {
        public static Puzzle Search(Puzzle start)
        {
            Stack<Puzzle> stack = new Stack<Puzzle>();
            HashSet<Puzzle> visited = new HashSet<Puzzle>();

            stack.Push(start);

            while (stack.Count > 0)
            {
                Puzzle current = stack.Pop();

                if (current.IsGoal())
                    return current;

                if (!visited.Contains(current))
                {
                    visited.Add(current);

                    foreach (Puzzle child in current.GetSuccessors())
                    {
                        stack.Push(child);
                    }
                }
            }
            return null;
        }
    }
}
