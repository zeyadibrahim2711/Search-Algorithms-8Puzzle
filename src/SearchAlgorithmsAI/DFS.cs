using System;
using System.Collections.Generic;
using System.Linq;

namespace SearchAlgorithmsAI
{
    public class DFS
    {
        public static int Nodes;

        public static Puzzle ExploreStateSpaceDFS(Puzzle start)
        {
            Stack<Puzzle> stack = new Stack<Puzzle>();
            HashSet<string> visited = new HashSet<string>();

            Nodes = 0;
            stack.Push(start);

            while (stack.Count > 0)
            {
                Puzzle current = stack.Pop();
                Nodes++;

                string key = string.Join(",", current.State);
                if (visited.Contains(key))
                    continue;

                visited.Add(key);

                if (current.IsGoal())
                    return current;

                foreach (Puzzle child in current.GetChildren())
                {
                    if (child != null)
                        stack.Push(child);
                }
            }
            return null;
        }
    }
}
