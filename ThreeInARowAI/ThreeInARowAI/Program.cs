namespace ThreeInARowAI
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
                char[,] grid =
            {
                { ' ',' ',' ' },
                { ' ',' ',' ' },
                { ' ',' ',' ' }
            };

            /*
            Action act = new Action(grid);
            char[,] newgrd = act.AddMiddle('O');
            
            for (int i=0; i<3; i++)
            {
                for (int ii=0; ii<3; ii++)
                {
                    Console.WriteLine(newgrd[i, ii]);
                }
            }
            */
            Opponent Ops = new Opponent(grid);


            /*
            char[,] NewGrid = Ops.BestNextMove(Ops.Winners).grid;
            if (NewGrid != null)
            {
                for (int i = 0; i < NewGrid.Length; i++)
                {
                    for (int j = 0; j < NewGrid.Length; j++)
                    {
                        Console.Write(NewGrid[i, j]);
                    }
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Array is empty");
            }
            */
        }
    }
}
