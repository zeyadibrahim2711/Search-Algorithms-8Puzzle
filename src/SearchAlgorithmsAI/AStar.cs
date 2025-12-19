using System;
using System.Collections.Generic;


namespace SearchAlgorithmsAI
{
    public class AStar
    {
        public static int Nodes;

        public static Puzzle ExploreStateSpaceAStar(Puzzle start)
        {
            Puzzle[] open = new Puzzle[1000];
            int size = 0;
            Nodes = 0;

            open[size++] = start;

            while (size > 0)
            {
                int best = 0;
                int bestF = open[0].Cost + open[0].ManhattanDistance();

                for (int i = 1; i < size; i++)
                {
                    int f = open[i].Cost + open[i].ManhattanDistance();
                    if (f < bestF)
                    {
                        bestF = f;
                        best = i;
                    }
                }

                Puzzle current = open[best];
                open[best] = open[--size];
                Nodes++;

                if (current.IsGoal())
                    return current;

                foreach (Puzzle child in current.GetChildren())
                {
                    if (child != null)
                        open[size++] = child;
                }
            }
            return null;
        }
    }
}
