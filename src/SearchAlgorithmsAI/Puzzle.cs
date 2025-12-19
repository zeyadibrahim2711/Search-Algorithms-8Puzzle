using System;
using System.Linq;

namespace SearchAlgorithmsAI
{
    public class Puzzle
    {
        public int[] State;
        public Puzzle Parent;
        public int Cost;

        private static readonly int[] GoalState = { 1, 2, 3, 4, 5, 6, 7, 8, 0 };

        public Puzzle(int[] state, Puzzle parent = null, int cost = 0)
        {
            State = state;
            Parent = parent;
            Cost = cost;
        }

        public bool IsGoal()
        {
            return State.SequenceEqual(GoalState);
        }

        public Puzzle[] GetChildren()
        {
            Puzzle[] children = new Puzzle[4];
            int count = 0;

            int zero = Array.IndexOf(State, 0);
            int r = zero / 3;
            int c = zero % 3;

            if (r > 0) children[count++] = CreateState(zero, zero - 3); // Up
            if (r < 2) children[count++] = CreateState(zero, zero + 3); // Down
            if (c > 0) children[count++] = CreateState(zero, zero - 1); // Left
            if (c < 2) children[count++] = CreateState(zero, zero + 1); // Right

            return children;
        }

        private Puzzle CreateState(int zero, int target)
        {
            int[] newState = (int[])State.Clone();
            newState[zero] = newState[target];
            newState[target] = 0;

            return new Puzzle(newState, this, Cost + 1);
        }

        public int ManhattanDistance()
        {
            int d = 0;
            for (int i = 0; i < State.Length; i++)
            {
                if (State[i] == 0) continue;

                int g = Array.IndexOf(GoalState, State[i]);
                d += Math.Abs(i / 3 - g / 3) + Math.Abs(i % 3 - g % 3);
            }
            return d;
        }

        public void PrintState()
        {
            for (int i = 0; i < State.Length; i++)
            {
                Console.Write(State[i] + " ");
                if ((i + 1) % 3 == 0) Console.WriteLine();
            }
            Console.WriteLine("-----");
        }
    }
}
