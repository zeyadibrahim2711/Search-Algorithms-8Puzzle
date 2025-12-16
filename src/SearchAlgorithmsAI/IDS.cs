using System;
using System.Collections.Generic;

namespace SearchAlgorithmsAI
{
    public class IDS
    {
        public static Puzzle Search(Puzzle start)
        {
            for (int depth = 0; depth < 50; depth++)
            {
                HashSet<Puzzle> visited = new HashSet<Puzzle>();
                Puzzle result = DLS(start, depth, visited);
                if (result != null)
                    return result;
            }
            return null;
        }

        private static Puzzle DLS(
            Puzzle node,
            int limit,
            HashSet<Puzzle> visited)
        {
            if (node.IsGoal())
                return node;

            if (limit == 0)
                return null;

            visited.Add(node);

            foreach (Puzzle child in node.GetSuccessors())
            {
                if (!visited.Contains(child))
                {
                    Puzzle result = DLS(child, limit - 1, visited);
                    if (result != null)
                        return result;
                }
            }
            return null;
        }
    }
}
