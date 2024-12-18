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
        public Action Moves;
        public char[,] grid =
        {
            { ' ',' ',' ' },
            { ' ',' ',' ' },
            { ' ',' ',' ' }
        };
        public TicTacToe(char[,] Passed_grid) {
            grid = Passed_grid;
            moves = 0;
        }
        
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
                if (grid[i,0] == grid[i,1]&& grid[i,0] == grid[i, 2] && grid[i,0] != ' ')
                {
                    if (grid[i,0] == 'X')
                    {
                        return 1;
                    }
                    else if (grid[i,0] == 'O')
                    {
                        return -1;
                    }
                }
                else if (grid[0, i] == grid[1, i] && grid[0, i] == grid[2, i])
                {
                    if (grid[0, i] == 'X')
                    {
                        return 1;
                    }
                    else if (grid[0,i]=='O')
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
                else if (grid[0,0] == 'O')
                {
                    return -1;
                }
            }
            else if (grid[0, 2] == grid[1, 1] && grid[0, 2] == grid[2, 0])
            {
                if (grid[0, 2] == 'X')
                {
                    return 1;
                }
                else if (grid[0,2]=='O')
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
        public char[,] NewInput()
        {
            Console.WriteLine("Please enter a number between 1-9");
            Action PlayerAction = new Action(grid);
            ConsoleKeyInfo key = Console.ReadKey();
            Thread.Sleep(500);
            //Console.Clear();
            char Input = key.KeyChar;
            bool ValidInt = false;
            char[,] PostActionGrid = new char[3, 3];
           
            
            int IntInput = Convert.ToInt32(Input)-'0';
                if (IntInput < 10 && IntInput > 0)
                {
                    if (IntInput == 1)
                    {
                        if (grid[0,0] =='X' || grid[0,0] ==  'O')
                        {
                            ValidInt = false;
                            Console.WriteLine("Spot already taken");
                        }
                        else
                        {
                            return PlayerAction.AddTopLeft('O');
                        }
                    }
                    else if (IntInput == 2)
                    {
                        if(grid[0, 1] == 'X' || grid[0, 1] == 'O')
                        {
                            ValidInt = false;
                            Console.WriteLine("Spot already taken");
                        }
                        else
                        {
                            return PlayerAction.AddTopMiddle('O');
                        }
                    }
                    else if (IntInput == 3)
                    {
                        
                        if (grid[0, 2] == 'X' || grid[0, 2] == 'O')
                        {
                            ValidInt = false;
                            Console.WriteLine("Spot already taken");
                        }
                        else
                        {
                            return PlayerAction.AddTopRight('O');
                        }

                    }
                    else if (IntInput == 4)
                    {
                        if (grid[1, 0] == 'X' || grid[1, 0] == 'O')
                        {
                            ValidInt = false;
                            Console.WriteLine("Spot already taken");
                        }
                        else
                        {
                            return PlayerAction.AddMiddleLeft('O');
                        }
                    }
                    else if (IntInput == 5)
                    {
                        if(grid[1, 1] == 'X' || grid[1, 1] == 'O')
                        {
                            ValidInt = false;
                            Console.WriteLine("Spot already taken");
                        }
                        else
                        {
                            return PlayerAction.AddMiddle('O');
                        }
                    }
                    else if (IntInput == 6)
                    {
                        if(grid[1, 2] == 'X' || grid[1, 2] == 'O')
                        {
                            ValidInt = false;
                            Console.WriteLine("Spot already taken");
                        }
                        else
                        {
                            return PlayerAction.AddMiddleRight('O');
                        }
                    }
                    else if (IntInput == 7)
                    {
                        if (grid[2, 0] == 'X' || grid[2, 0] == 'O')
                        {
                            ValidInt = false;
                            Console.WriteLine("Spot already taken");
                        }
                        else
                        {
                            return PlayerAction.AddBottomLeft('O');
                        }
                    }
                    else if (IntInput == 8)
                    {
                        if (grid[2, 1] == 'X' || grid[2, 1] == 'O')
                        {
                            ValidInt = false;
                            Console.WriteLine("Spot already taken");
                        }
                        else
                        {
                            return PlayerAction.AddBottomMiddle('O');
                        }
                    }
                    else if (IntInput == 9)
                    {
                        if (grid[2, 2] == 'X' || grid[2, 2] == 'O')
                        {
                            ValidInt = false;
                            Console.WriteLine("Spot already taken");
                        }
                        else
                        {
                            return PlayerAction.AddBottomRight('O');
                        }
                    }
                    
                }
                //else { ValidInt = false; Console.WriteLine("Enter a number between 1-9");  key = Console.ReadKey(); Input = key.KeyChar; }
                
            
            return grid;
        }
        public void UpdateGrid(char[,] Newgrid)
        {
            Console.WriteLine("Update");
            grid = Newgrid;
            
        }
    }  
}
