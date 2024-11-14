using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeInARowAI
{
    internal class Opponent<T>
    {
        // AIChar is always O
        char AIChar = 'O';
        Stack<TicTacToe> Frontier;
        HashSet<TicTacToe> CheckedNodes;
        List<TicTacToe> Winners = new List<TicTacToe>();
        List<TicTacToe> Draws = new List<TicTacToe>();
        public Opponent(char[,] InitialState)
        {
            TicTacToe StartingState = new TicTacToe(InitialState);
            Stack<TicTacToe> Frontier = new Stack<TicTacToe>();
            Frontier.Push(StartingState); // Adds the starting state onto the frontier
            ExpandNode();

        }
        public void ExpandNode()
        {
            while (Frontier.Count > 0)
            {
                TicTacToe node = Frontier.Pop();
                Action Expand = new Action(node.grid);
                // Receive the stack from Expand.TryALL and and all of the nodes onto the frontier.

                Stack<char[,]> ChildNodes = Expand.TryAll(AIChar);
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
                    

                }
                
                else if (ChildNodes.Count > 0)
                {

                    for (int i = 0; i < ChildNodes.Count; i++)
                    {
                        TicTacToe newState = new TicTacToe(ChildNodes.Pop());
                        newState.ParentClass = node;
                        newState.pathCost = node.pathCost + 1;
                        // Adds a reference to the parent node so you can backtrack
                        if (!CheckedNodes.Contains(newState))
                        {
                            Frontier.Push(newState);
                            // Adds the new nodes to the frontier and doesn't allow for dupes
                        }

                    }
                    CheckedNodes.Add(node);
                    // Adds a node to the explored set
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
