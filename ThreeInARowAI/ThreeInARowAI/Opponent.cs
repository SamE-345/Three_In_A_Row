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
            Action action = new Action(Gamestate.grid);
            Console.WriteLine("Displaying grid");
            
            char[,] BMove = null;
            int BestVal = int.MinValue;
            Stack<char[,]> InitialMoves = action.TryAll('X');
            
            int len = InitialMoves.Count;
            for (int i = 0; i<len; i++)
            {
                char[,] Move = InitialMoves.Pop();
                int val = Minimax(Move ,1, false);
                if (val > BestVal)
                {
                    BestVal = val;
                    BMove = Move;
                }
            }
            
            TicTacToe BestNextMove = new TicTacToe(BMove);
            return BestNextMove;
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
                Console.WriteLine("Success");
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
    }

}
