using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeInARowAI
{
    internal class Opponent
    {
        // AIChar is always X
        private char AIChar = 'X';
        public char[,] BMOVE;
        public Stack<TicTacToe> Frontier = new Stack<TicTacToe>();
        HashSet<TicTacToe> CheckedNodes = new HashSet<TicTacToe>();
        public List<TicTacToe> Winners = new List<TicTacToe>();
        List<TicTacToe> Draws = new List<TicTacToe>();
        public Opponent(char[,] InitialState)
        {
            TicTacToe StartingState = new TicTacToe(InitialState);
           
            Frontier.Push(StartingState); // Adds the starting state onto the frontier
            ExpandNode();
            if (Winners.Count > 0)
            {
                BMOVE = BestNextMove(Winners).grid;
                Console.WriteLine("Winnable");
            }
            else if (Draws.Count > 0)
            {
                BMOVE = BestNextMove(Draws).grid;
            }
            else
            {
                
            }

        }
        public void ExpandNode()
        {
            Console.WriteLine();
            if (Frontier != null) {
               
                while (Frontier.Count > 0)
                {
                    Stack<char[,]> ChildNodes;
                    TicTacToe node = Frontier.Pop();
                    Action Expand = new Action(node.grid);
                    // Receive the stack from Expand.TryALL and and all of the nodes onto the frontier.
                    if (node.pathCost % 2 == 1)
                    {
                        ChildNodes = Expand.TryAll(AIChar);
                    }
                    else
                    {
                        ChildNodes = Expand.TryAll('O');
                    }
                    if (ChildNodes.Count == 0) // If it is a leaf node
                    {
                        if (node.winner() == -1)
                        {
                            Winners.Add(node);
                            
                            
                        }
                        else if (node.winner() == 0)
                        {
                            Draws.Add(node);
                        }
                        Console.WriteLine("Leaf Node");

                    }

                    else if (ChildNodes.Count > 0)
                    {
                        Console.WriteLine("Line 76");
                        for (int i = 0; i < ChildNodes.Count; i++)
                        {
                            TicTacToe newState = new TicTacToe(ChildNodes.Pop());
                            newState.ParentClass = node;  // Adds a reference to the parent node so you can backtrack
                            newState.pathCost = node.pathCost + 1;
                            if (node.pathCost % 2 == 1)
                            {
                                if (!CheckedNodes.Contains(newState))
                                {
                                    Frontier.Push(newState);
                                    // Adds the new nodes to the frontier and doesn't allow for dupes
                                }

                            }
                        }
                        CheckedNodes.Add(node);
                        // Adds a node to the explored set
                    }
                }
            }
        }

        public TicTacToe BestNextMove(List<TicTacToe> UnsortedList)
        {
            /* 
             * If winners has any values in, Implement sorting algorithm
             * If not, sort Draws if there is any 
             * If draws is empty, opponent loses
             * Pick wins with the lowest Path Cost and uses that move.
             */
           
            for (int i = 0;i < UnsortedList.Count-1; i++)
            {
                if (UnsortedList[i].pathCost > UnsortedList[i+1].pathCost)
                {
                    TicTacToe temp = UnsortedList[i+1];
                    UnsortedList[i+1] = UnsortedList[i];
                    UnsortedList[i] = temp;
                    i = 0;
                }

            }
            TicTacToe BestScenario = UnsortedList[0];
            TicTacToe Parents = BestScenario;
            while (Parents.pathCost > 1)
            {
                Parents = Parents.ParentClass;
            }
            
            
            
            
            return Parents;
        }
    }
}
