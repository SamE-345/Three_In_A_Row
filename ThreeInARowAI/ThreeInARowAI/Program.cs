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
            TicTacToe Game1 = new TicTacToe(grid);

        }
    }
}
