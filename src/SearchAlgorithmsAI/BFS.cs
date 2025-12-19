using System;
using System.Collections.Generic;

namespace SearchAlgorithmsAI
{
    public class BFS
    {
        public static int Nodes;

        public static Puzzle ExploreStateSpaceBFS(Puzzle start)
        {
            Queue<Puzzle> q = new Queue<Puzzle>();
            Nodes = 0;

            q.Enqueue(start);

            while (q.Count > 0)
            {
                Puzzle current = q.Dequeue();
                Nodes++;

                if (current.IsGoal())
                    return current;

                foreach (Puzzle child in current.GetChildren())
                {
                    if (child != null)
                        q.Enqueue(child);
                }
            }
            return null;
        }
    }
}
