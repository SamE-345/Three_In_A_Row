using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeInARowAI
{
    internal class Opponent
    {
        // AIChar is always O
        char AIChar = 'O';
        Stack <TicTacToe> Frontier;
        HashSet<TicTacToe > CheckedNodes;
        public Opponent(char[,] InitialState)
        {
            TicTacToe StartingState = new TicTacToe(InitialState);
            Stack<TicTacToe> Frontier = new Stack<TicTacToe>();
            Frontier.Push(StartingState); // Adds the starting state onto the frontier
        }
        public void ExpandNode()
        {
            while (Frontier.Count > 0)
            {
                TicTacToe node = Frontier.Pop();
                Action Expand = new Action(node.grid);
                // Receive the stack from Expand.TryALL and and all of the nodes onto the frontier.
                Stack<char[,]> ChildNodes = Expand.TryAll(AIChar);
                for (int i = 0; i < ChildNodes.Count; i++)
                {
                    TicTacToe newState = new TicTacToe(ChildNodes.Pop());
                    Frontier.Push(newState);

                }
            }
        }

    }
}
