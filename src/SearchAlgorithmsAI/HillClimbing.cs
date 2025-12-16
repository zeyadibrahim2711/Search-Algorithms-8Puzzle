using System;
using System.Collections.Generic;
using System.Linq;

namespace SearchAlgorithmsAI
{
    public class HillClimbing
    {
        public static Puzzle Search(Puzzle start)
        {
            Puzzle current = start;

            while (true)
            {
                if (current.IsGoal())
                    return current;

                var neighbors = current.GetSuccessors();
                Puzzle bestNeighbor = neighbors
                    .OrderBy(n => n.ManhattanDistance())
                    .FirstOrDefault();

                if (bestNeighbor == null ||
                    bestNeighbor.ManhattanDistance() >= current.ManhattanDistance())
                {
                    return null; // Local optimum
                }

                current = bestNeighbor;
            }
        }
    }
}
