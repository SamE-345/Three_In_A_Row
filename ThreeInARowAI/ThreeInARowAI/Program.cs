namespace ThreeInARowAI
{
    internal class Program
    {

        static void Main(string[] args)
        {
            bool repeat = true;
            do
            {
                Console.WriteLine("Press 1 for new game \n Press 2 to load game \n press 3 to exit");
                int choice = Convert.ToInt32(Console.ReadLine());
                if (choice == 1)
                {
                    PlayGame();
                }
                else if (choice == 2)
                {
                    // Add feature to read a file of a gamestate then resume the game
                    Console.WriteLine("Enter filename");
                    string filename = Console.ReadLine();
                    StreamReader sr = new StreamReader(filename);   
                }
                else if (choice == 3)
                {
                    Console.Clear();
                    repeat = false;
                }
            } while (repeat == true);


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
        static void PlayGame(char[,] grid)
        {
            



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
