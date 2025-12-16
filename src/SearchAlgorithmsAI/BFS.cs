using System;
using System.Collections.Generic;

namespace SearchAlgorithmsAI
{
    public class BFS
    {
        public static Puzzle Search(Puzzle start)
        {
            Queue<Puzzle> queue = new Queue<Puzzle>();
            HashSet<Puzzle> visited = new HashSet<Puzzle>();

            queue.Enqueue(start);
            visited.Add(start);

            while (queue.Count > 0)
            {
                Puzzle current = queue.Dequeue();

                if (current.IsGoal())
                    return current;

                foreach (Puzzle child in current.GetSuccessors())
                {
                    if (!visited.Contains(child))
                    {
                        visited.Add(child);
                        queue.Enqueue(child);
                    }
                }
            }
            return null;
        }
    }
}
