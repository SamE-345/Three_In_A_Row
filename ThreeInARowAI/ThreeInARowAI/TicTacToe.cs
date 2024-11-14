using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeInARowAI
{
    internal class TicTacToe
    {
        public TicTacToe ParentClass;
        public int pathCost = 0;
        public char[,] grid =
        {
            { ' ',' ',' ' },
            { ' ',' ',' ' },
            { ' ',' ',' ' }
        };
        public TicTacToe(char[,] Passed_grid) { grid = Passed_grid; moves = 0; }
       
        public int moves  
        {
            get;
            set;
        }
        
        
        public int winner()
        {
            // Player X returns 1
            // Player O returns -1
            // Draw returns 0
            // GameNotFinished returns -2

            for(int i = 0; i < 3; i++)
            {
                if (grid[i,0] == grid[i,1]&& grid[i,0] == grid[i, 2])
                {
                    if (grid[i,0] == 'X')
                    {
                        return 1;
                    }
                    else
                    {
                        return -1;
                    }
                }
                else if (grid[0, i] == grid[1, i] && grid[0, i] == grid[2, i])
                {
                    if (grid[i, 0] == 'X')
                    {
                        return 1;
                    }
                    else
                    {
                        return -1;
                    }
                }
            }
            if (grid[0, 0] == grid[1, 1] && grid[0, 0] == grid[2, 2])
            {
                if (grid[0, 0] == 'X')
                {
                    return 1;
                }
                else
                {
                    return -1;
                }
            }
            else if (grid[0, 2] == grid[1, 1] && grid[0, 2] == grid[2, 0])
            {
                if (grid[0, 0] == 'X')
                {
                    return 1;
                }
                else
                {
                    return -1;
                }
            }
            
            for (int i = 0; i < 3; i++) 
            {
                for (int j = 0; j < 3; j++)
                {
                    if (grid[i,j] == ' ')
                    {
                        return -2;
                    }
                }
            }
            return 0;
        }
        
        
      
    }
}
