using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ThreeInARowAI
{
    internal class Opponent
    {

        public Opponent()
        {

        }

        public TicTacToe BestMove(TicTacToe Gamestate)
        {
            TicTacToe newOne = Gamestate;
            char[,] tempGrid = newOne.grid;
            Action action = new Action(tempGrid);
          
            //Could the assigning tempGrid be a pointer in memory rather than new array
            // Array.copy function?

            char[,] BMove = null;
            int BestVal = int.MinValue;


            Console.WriteLine("Gamestate.grid pre action"); // Gamestate is being modified
            ShowGrid(newOne.grid);

            Stack<char[,]> InitialMoves = action.TryAll('X');

            Console.WriteLine("Gamestate.grid post action"); // Gamestate is being modified
            ShowGrid(newOne.grid);
            
            
            int len = InitialMoves.Count;
           // Console.WriteLine(len + "Length");
            for (int i = 0; i < len; i++)
            {
                //Console.WriteLine("loop " + i);
                char[,] Move = InitialMoves.Pop();
                //ShowGrid(Move);
                int val = Minimax(Move, 1, false);
                if (val > BestVal)
                {
                    BestVal = val;
                    BMove = Move;
                }

            }
            if (BMove != null)
            {
                Console.WriteLine("NotNull");
                TicTacToe BestNextMove = new TicTacToe(BMove);
                return BestNextMove;
            }
            else if (BMove == null)
            {
                Console.WriteLine("BMOVE is null");
            }
            
            return newOne;

        }
            
        
        private int Minimax(char[,] grid, int depth, bool MaxPlayer)
        {
            Action Moves = new Action(grid);
            TicTacToe checkWinner = new TicTacToe(grid);
            if (grid == null)
            {
                return 0;
            }
            else
            {
                //Console.WriteLine("Success");
            }
            if (checkWinner.winner() != -2)
            {
                return checkWinner.winner();
            }
            else
            {
                if (MaxPlayer)
                {
                    int bestVal = int.MinValue;
                    Stack<char[,]> PMoves = Moves.TryAll('X');
                    while (PMoves.Count > 0)
                    {
                        int Outcome = Minimax(PMoves.Pop(), depth + 1, false);
                        bestVal = int.Max(Outcome, bestVal);
                    }
                    return bestVal;
                }
                else
                {
                    int bestVal = int.MaxValue;
                    Stack<char[,]> PMoves = Moves.TryAll('O');
                    while (PMoves.Count > 0)
                    {
                        int Outcome = Minimax(PMoves.Pop(), depth + 1, true);
                        bestVal = int.Min(Outcome, bestVal);
                    }
                    return bestVal;
                }
            }
        }
        private void ShowGrid(char[,] grid)
        {
            if (grid != null)
            {
                for (int i = 0; i < 3; i++)
                {
                    for (int ii = 0; ii < 3; ii++)
                    {
                        Console.Write(grid[i, ii]);
                    }
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Grid was null");
            }
        }
    }

}
