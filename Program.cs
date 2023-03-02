using System;

class Program
{
    static void Main(string[] args)
    {
        // Initialize the board
        char[,] board = {
            {'1', '2', '3'},
            {'4', '5', '6'},
            {'7', '8', '9'}
        };

        // Initialize variables
        bool gameEnded = false;
        char player = 'X';
        int choice = 0;
        int row, column;

        while (!gameEnded)
        {
            // Draw the board
            Console.Clear();
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2} ", board[0, 0], board[0, 1], board[0, 2]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2} ", board[1, 0], board[1, 1], board[1, 2]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2} ", board[2, 0], board[2, 1], board[2, 2]);
            Console.WriteLine("     |     |      ");

            // Ask for player input
            Console.WriteLine("Player {0}, choose your move (1-9):", player);
            choice = int.Parse(Console.ReadLine());

            // Determine row and column indices
            row = (choice - 1) / 3;
            column = (choice - 1) % 3;

            // Check if chosen cell is already occupied
            if (board[row, column] != 'X' && board[row, column] != 'O')
            {
                board[row, column] = player;

                // Check if the game is over
                if (board[0, 0] == board[0, 1] && board[0, 1] == board[0, 2] ||
                    board[1, 0] == board[1, 1] && board[1, 1] == board[1, 2] ||
                    board[2, 0] == board[2, 1] && board[2, 1] == board[2, 2] ||
                    board[0, 0] == board[1, 0] && board[1, 0] == board[2, 0] ||
                    board[0, 1] == board[1, 1] && board[1, 1] == board[2, 1] ||
                    board[0, 2] == board[1, 2] && board[1, 2] == board[2, 2] ||
                    board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2] ||
                    board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0])
                {
                    gameEnded = true;
                    Console.WriteLine("Player {0} wins!", player);
                }
                // Check if the game is a tie
                else if (board[0, 0] != '1' && board[0, 1] != '2' && board[0, 2] != '3' &&
                         board[1, 0] != '4' && board[1, 1] != '5' && board[1, 2] != '6' &&
                         board[2, 0] != '7' && board
            }
        }
    }
}