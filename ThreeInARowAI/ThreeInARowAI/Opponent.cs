using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeInARowAI
{
    internal class Opponent
    {
        Stack <TicTacToe> Frontier;
        public Opponent(char[,] InitialState)
        {
            TicTacToe StartingState = new TicTacToe(InitialState);
            Frontier.Push(StartingState);
        }

    }
}
