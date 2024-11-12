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
            Frontier.Push(StartingState);
        }
        public void ExpandNode()
        {
            
        }

    }
}
