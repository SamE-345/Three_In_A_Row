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

            

            TicTacToe game = new TicTacToe(grid);
            Opponent OP = new Opponent();
            while(game.winner() == -2)
            {
                game.NewInput();
                
                
            }
            Console.WriteLine(game.winner());
            
            

        }
    }
}
