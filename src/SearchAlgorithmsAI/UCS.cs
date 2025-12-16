using System;
using System.Collections.Generic;

namespace SearchAlgorithmsAI
{
    public class UCS
    {
        public static Puzzle Search(Puzzle start)
        {
         
            SortedDictionary<int, Queue<Puzzle>> frontier =
                new SortedDictionary<int, Queue<Puzzle>>();

            HashSet<Puzzle> visited = new HashSet<Puzzle>();

            Enqueue(frontier, start, start.Cost);

            while (frontier.Count > 0)
            {
                Puzzle current = Dequeue(frontier);

                if (current.IsGoal())
                    return current;

                if (visited.Contains(current))
                    continue;

                visited.Add(current);

                foreach (Puzzle child in current.GetSuccessors())
                {
                    if (!visited.Contains(child))
                    {
                        Enqueue(frontier, child, child.Cost);
                    }
                }
            }
            return null;
        }

        private static void Enqueue(
            SortedDictionary<int, Queue<Puzzle>> frontier,
            Puzzle node,
            int priority)
        {
            if (!frontier.ContainsKey(priority))
                frontier[priority] = new Queue<Puzzle>();

            frontier[priority].Enqueue(node);
        }

        private static Puzzle Dequeue(
            SortedDictionary<int, Queue<Puzzle>> frontier)
        {
            var firstKey = new List<int>(frontier.Keys)[0];
            var queue = frontier[firstKey];
            Puzzle node = queue.Dequeue();

            if (queue.Count == 0)
                frontier.Remove(firstKey);

            return node;
        }
    }
}
