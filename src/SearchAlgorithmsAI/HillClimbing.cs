using System;
using System.Collections.Generic;
using System.Linq;

namespace SearchAlgorithmsAI
{
    public class HillClimbing
    {
        public static int Nodes;

        public static Puzzle ExploreStateSpaceHillClimbing(Puzzle start)
        {
            Puzzle current = start;
            Nodes = 0;

            for (int i = 0; i < 50; i++)
            {
                Nodes++;

                if (current.IsGoal())
                    return current;

                Puzzle best = null;
                int bestH = int.MaxValue;

                foreach (Puzzle n in current.GetChildren())
                {
                    if (n == null) continue;

                    int h = n.ManhattanDistance();
                    if (h < bestH)
                    {
                        bestH = h;
                        best = n;
                    }
                }

                if (best == null || bestH >= current.ManhattanDistance())
                    return null;

                best.Parent = current;
                current = best;
            }
            return null;
        }
    }
}
