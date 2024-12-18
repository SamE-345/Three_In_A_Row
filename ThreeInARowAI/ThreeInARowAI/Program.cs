namespace ThreeInARowAI
{
    internal class Program
    {

        static void Main(string[] args)
        {
            PlayGame();


            
            

        }
        static void showGrid(TicTacToe game)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int ii = 0; ii < 3; ii++)
                {
                    Console.Write(game.grid[i, ii]);
                }
                Console.WriteLine();
            }
        }
        static void PlayGame()
        {
            char[,] grid =
        {
                { ' ',' ',' ' },
                { ' ',' ',' ' },
                { ' ',' ',' ' }
            };



            TicTacToe game = new TicTacToe(grid);
            Opponent OP = new Opponent();
            while (game.winner() == -2)
            {
                game.grid = game.NewInput();
                Console.WriteLine("");
                showGrid(game);
                Console.WriteLine("________");
                if (game.winner() != -2)
                {
                    break;
                }
                game = OP.BestMove(game);
                showGrid(game);
                Console.WriteLine();
            }
            if (game.winner() == 1)
            {
                Console.WriteLine("Computer wins");
            }
            else if (game.winner() == -1)
            {
                Console.WriteLine("Player wins");
            }
            else
            {
                Console.WriteLine("Draw");
            }
        }
    }
}
