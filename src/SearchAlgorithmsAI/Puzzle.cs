using System;
using System.Collections.Generic;
using System.Linq;

namespace SearchAlgorithmsAI
{
    public class Puzzle
    {
        public int[] State { get; }
        public Puzzle Parent { get; }
        public string Action { get; }
        public int Cost { get; }

        private static readonly int[] GoalState = { 1, 2, 3, 4, 5, 6, 7, 8, 0 };

        public Puzzle(int[] state, Puzzle parent = null, string action = "", int cost = 0)
        {
            State = state;
            Parent = parent;
            Action = action;
            Cost = cost;
        }

        public bool IsGoal()
        {
            return State.SequenceEqual(GoalState);
        }

        public List<Puzzle> GetSuccessors()
        {
            List<Puzzle> successors = new List<Puzzle>();
            int zeroIndex = Array.IndexOf(State, 0);
            int row = zeroIndex / 3;
            int col = zeroIndex % 3;

            int[,] moves =
            {
                { -1, 0, "Up".Length },
                { 1, 0, "Down".Length },
                { 0, -1, "Left".Length },
                { 0, 1, "Right".Length }
            };

            foreach (var move in new[] { "Up", "Down", "Left", "Right" })
            {
                int newRow = row, newCol = col;

                if (move == "Up") newRow--;
                if (move == "Down") newRow++;
                if (move == "Left") newCol--;
                if (move == "Right") newCol++;

                if (newRow >= 0 && newRow < 3 && newCol >= 0 && newCol < 3)
                {
                    int newIndex = newRow * 3 + newCol;
                    int[] newState = (int[])State.Clone();
                    newState[zeroIndex] = newState[newIndex];
                    newState[newIndex] = 0;

                    successors.Add(new Puzzle(newState, this, move, Cost + 1));
                }
            }
            return successors;
        }

        public int ManhattanDistance()
        {
            int distance = 0;
            for (int i = 0; i < State.Length; i++)
            {
                if (State[i] == 0) continue;
                int goalIndex = Array.IndexOf(GoalState, State[i]);
                distance += Math.Abs(i / 3 - goalIndex / 3)
                          + Math.Abs(i % 3 - goalIndex % 3);
            }
            return distance;
        }

        public override int GetHashCode()
        {
            return string.Join(",", State).GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj is Puzzle other)
                return State.SequenceEqual(other.State);
            return false;
        }

        public void Print()
        {
            for (int i = 0; i < State.Length; i++)
            {
                Console.Write(State[i] == 0 ? "  " : State[i] + " ");
                if ((i + 1) % 3 == 0)
                    Console.WriteLine();
            }
            Console.WriteLine("-----");
        }
    }
}
