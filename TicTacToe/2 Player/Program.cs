// 2 Player TicTacToe

using System;

namespace TicTacToe
{
    class Program
    {
        static char[] board = { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' };
        static char currentPlayer = 'X';

        static void Main(string[] args)
        {
            bool gameRunning = true;

            while (gameRunning)
            {
                Console.Clear();
                DrawBoard();

                int move;
                while (true)
                {
                    Console.WriteLine($"Player {currentPlayer}, make your move (1-9):");
                    bool isValidMove = int.TryParse(Console.ReadLine(), out move);
                    if (isValidMove && move >= 1 && move <= 9 && board[move - 1] == ' ')
                        break;
                    else
                        Console.WriteLine("Invalid move. Try again.");
                }

                board[move - 1] = currentPlayer;

                if (CheckWin())
                {
                    Console.Clear();
                    DrawBoard();
                    Console.WriteLine($"Player {currentPlayer} wins!");
                    gameRunning = false;
                    break;
                }

                if (IsBoardFull())
                {
                    Console.Clear();
                    DrawBoard();
                    Console.WriteLine("It's a draw!");
                    gameRunning = false;
                    break;
                }

                currentPlayer = (currentPlayer == 'X') ? 'O' : 'X';
            }

            Console.WriteLine("Game over. Press any key to exit.");
            Console.ReadKey();
        }

        static void DrawBoard()
        {
            Console.WriteLine($"{board[0]} | {board[1]} | {board[2]}");
            Console.WriteLine("---------");
            Console.WriteLine($"{board[3]} | {board[4]} | {board[5]}");
            Console.WriteLine("---------");
            Console.WriteLine($"{board[6]} | {board[7]} | {board[8]}");
        }

        static bool CheckWin()
        {
            // Check rows
            for (int i = 0; i < 3; i++)
            {
                if (board[i * 3] != ' ' && board[i * 3] == board[i * 3 + 1] && board[i * 3] == board[i * 3 + 2])
                    return true;
            }

            // Check columns
            for (int i = 0; i < 3; i++)
            {
                if (board[i] != ' ' && board[i] == board[i + 3] && board[i] == board[i + 6])
                    return true;
            }

            // Check diagonals
            if (board[0] != ' ' && board[0] == board[4] && board[0] == board[8])
                return true;

            if (board[2] != ' ' && board[2] == board[4] && board[2] == board[6])
                return true;

            return false;
        }

        static bool IsBoardFull()
        {
            foreach (char cell in board)
            {
                if (cell == ' ')
                    return false;
            }
            return true;
        }
    }
}