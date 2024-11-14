using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeInARowAI
{
    internal class Action
    {
        char[,] InitialState;
        public Action(char[,] Passed_grid) { InitialState = Passed_grid; }
        public char[,] AddTopLeft(char player)
        {
            char[,] newState = InitialState;
           
            if (InitialState[0, 0] == ' ')
            {
                newState[0, 0] = player;
                
                return newState;
            }
            else
            {
                return null;
            }
        }
        public char[,] AddTopRight(char player)
        {
            char[,] newState = InitialState;
            if (InitialState[0, 2] == ' ')
            {
                newState[0, 2] = player;

                return newState;
            }
            else
            {
                return null;
            }

        }
        public char[,] AddTopMiddle(char player)
        {
            char[,] newState = InitialState;
            if (InitialState[0, 1] == ' ')
            {
                newState[0, 1] = player;

                return newState;
            }
            else
            {
                return null;
            }
        }
        public char[,] AddMiddleLeft(char player)
        {
            char[,] newState = InitialState;
            if (InitialState[1, 0] == ' ')
            {
                newState[1, 0] = player;

                return newState;
            }
            else
            {
                return null;
            }
        }
        public char[,] AddMiddle(char player)
        {
            char[,] newState = InitialState;
            if (InitialState[1, 1] == ' ')
            {
                newState[1, 1] = player;

                return newState;
            }
            else
            {
                return null;
            }
        }
        public char[,] AddMiddlRight(char player)
        {
            char[,] newState = InitialState;
            if (InitialState[1, 2] == ' ')
            {
                newState[1, 2] = player;

                return newState;
            }
            else
            {
                return null;
            };
        }
        public char[,] AddBottomLeft(char player)
        {
            char[,] newState = InitialState;
            if (InitialState[2, 0] == ' ')
            {
                newState[2, 0] = player;

                return newState;
            }
            else
            {
                return null;
            }
        }
        public char[,] AddBottomMiddle(char player)
        {
            char[,] newState = InitialState;
            if (InitialState[2, 1] == ' ')
            {
                newState[2, 1] = player;

                return newState;
            }
            else
            {
                return null;
            }
        }
        public char[,] AddBottomRight(char player)
        {
            char[,] newState = InitialState;
            if (InitialState[2, 2] == ' ')
            {
                newState[0, 0] = player;

                return newState;
            }
            else
            {
                return null;
            }
        }
        public Stack<char[,]> TryAll(char Player)
        {
            // Tries all of the actions on a basestate and creates a stack of all possible child nodes and returns them
            Stack<char[,]> ChildNodes = new Stack<char[,]>();
            if (AddTopLeft(Player) != null)
            {
                ChildNodes.Push(AddTopLeft(Player));
            }
            if (AddTopRight(Player) != null)
            {
                ChildNodes.Push(AddTopRight(Player));
            }
            if (AddTopMiddle(Player) != null)
            {
                ChildNodes.Push(AddTopMiddle(Player));
            }
            if (AddMiddleLeft(Player)!= null)
            {
                ChildNodes.Push(AddMiddleLeft(Player));
            }
            if (AddMiddle(Player) != null)
            {
                ChildNodes.Push(AddMiddle(Player));
            }
            if(AddMiddleLeft(Player) != null)
            {
                ChildNodes.Push(AddMiddleLeft(Player));
            }
            if (AddBottomLeft(Player) != null)
            {
                ChildNodes.Push(AddBottomLeft(Player));
            }
            if (AddBottomMiddle(Player) != null)
            {
                ChildNodes.Push(AddBottomMiddle(Player));
            }
            if (AddBottomRight(Player) != null)
            {
                ChildNodes.Push(AddBottomRight(Player));
            }
            return ChildNodes;
        }
    }
}
