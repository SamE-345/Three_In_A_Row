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
            Action PlayerAction = new Action(grid);
            ConsoleKeyInfo key = Console.ReadKey();
            Thread.Sleep(500);
            Console.Clear();
            char Input = key.KeyChar;
            bool ValidInt = false;
            char[,] PostActionGrid = new char[3, 3];
            do
            {
                //Console.WriteLine("Please enter a number between 1-9");
                
                    int abc = Convert.ToInt32(Input)-'0';
                    Console.WriteLine(abc);
                    ValidInt = true;
                
               
                if (ValidInt == true && Input-'0' < 10 && Input-'0' > 0)
                {
                    if (Input == 1)
                    {
                        if (PlayerAction.AddTopLeft('O') == null)
                        {
                            ValidInt = false;
                            Console.WriteLine("Spot already taken");
                        }
                        else
                        {
                            return PlayerAction.AddTopLeft('O');
                        }
                    }
                    else if (Input == 2)
                    {
                        if( PlayerAction.AddTopMiddle('O')== null)
                        {
                            ValidInt = false;
                            Console.WriteLine("Spot already taken");
                        }
                        else
                        {
                            return PlayerAction.AddTopMiddle('O');
                        }
                    }
                    else if (Input == 3)
                    {
                        if (PlayerAction.AddTopRight('O')== null)
                        {
                            ValidInt = false;
                            Console.WriteLine("Spot already taken");
                        }
                        else
                        {
                            return PlayerAction.AddTopRight('O');
                        }

                    }
                    else if (Input == 4)
                    {
                        if (PlayerAction.AddMiddleLeft('O')== null)
                        {
                            ValidInt = false;
                            Console.WriteLine("Spot already taken");
                        }
                        else
                        {
                            return PlayerAction.AddMiddleLeft('O');
                        }
                    }
                    else if (Input == 5)
                    {
                        if(PlayerAction.AddMiddle('O')== null)
                        {
                            ValidInt = false;
                            Console.WriteLine("Spot already taken");
                        }
                        else
                        {
                            PlayerAction.AddMiddle('O');
                        }
                    }
                    else if (Input == 6)
                    {
                        if(PlayerAction.AddMiddlRight('O')== null)
                        {
                            ValidInt = false;
                            Console.WriteLine("Spot already taken");
                        }
                        else
                        {
                            PlayerAction.AddMiddlRight('O');
                        }
                    }
                    else if (Input == 7)
                    {
                        if (PlayerAction.AddBottomLeft('O')== null)
                        {
                            ValidInt = false;
                            Console.WriteLine("Spot already taken");
                        }
                        else
                        {
                            return PlayerAction.AddBottomLeft('O');
                        }
                    }
                    else if (Input == 8)
                    {
                        if (PlayerAction.AddBottomMiddle('O')== null)
                        {
                            ValidInt = false;
                            Console.WriteLine("Spot already taken");
                        }
                        else
                        {
                            return PlayerAction.AddBottomMiddle('O');
                        }
                    }
                    else if (Input == 9)
                    {
                        if (PlayerAction.AddBottomRight('O')== null)
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
                else { ValidInt = false; Console.WriteLine("Enter a number between 1-9");  key = Console.ReadKey(); Input = key.KeyChar; }
                
            }while (!ValidInt);
            return null;
        }
        public void UpdateGrid(char[,] Newgrid)
        {
            grid = Newgrid;
        }
    }  
}
