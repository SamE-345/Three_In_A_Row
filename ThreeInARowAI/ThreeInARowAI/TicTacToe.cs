﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeInARowAI
{
    internal class TicTacToe
    {
        char[,] grid =
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
        
        public void AddTopLeft(char player)
        {
            if (grid[0, 0] == ' ')
            {
                grid[0, 0] = player;
                moves++;
            }
        }
        public void AddTopRight(char player)
        {
            grid[0,2] = player;
            moves++;
        }
        public void AddTopMiddle(char player)
        {
            grid[0,1] = player;
            moves++;
        }
        public void AddMiddleLeft(char player)
        {
            grid[1,0] = player;
            moves++;
        }
        public void AddMiddle(char player)
        {
            grid[1,1] = player;
            moves++;
        }
        public void AddMiddlRight(char player)
        {
            grid[1,2] = player;
            moves++;
        }
        public void AddBottomLeft(char player)
        {
            grid[2, 0] = player;
            moves++;
        }
        public void AddBottomMiddle(char player)
        {
            grid[2,1] = player;
            moves++;
        }
        public void AddBottomRight(char player)
        {
            grid[2,2] = player;
            moves++;
        }
        public int winner(int[,] grid)
        {
            // Player X returns 1
            // Player O returns -1
            // No winner returns 0

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
            return 0;

        }
      
    }
}
