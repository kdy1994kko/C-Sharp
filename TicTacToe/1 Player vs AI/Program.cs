// 1 Player Vs AI

using System;

namespace TicTacToe
{
    class Program
    {
        static char[] board = { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' };
        static char player = 'X';
        static char aiPlayer = 'O';

        static void Main(string[] args)
        {
            bool gameRunning = true;

            while (gameRunning)
            {
                Console.Clear();
                DrawBoard();

                if (player == 'X')
                {
                    MakePlayerMove();
                    if (CheckWin(player))
                    {
                        Console.Clear();
                        DrawBoard();
                        Console.WriteLine("You win!");
                        gameRunning = false;
                    }
                    else if (IsBoardFull())
                    {
                        Console.Clear();
                        DrawBoard();
                        Console.WriteLine("It's a draw!");
                        gameRunning = false;
                    }
                    else
                    {
                        player = 'O';
                    }
                }
                else
                {
                    MakeAIMove();
                    if (CheckWin(aiPlayer))
                    {
                        Console.Clear();
                        DrawBoard();
                        Console.WriteLine("You lose!");
                        gameRunning = false;
                    }
                    else if (IsBoardFull())
                    {
                        Console.Clear();
                        DrawBoard();
                        Console.WriteLine("It's a draw!");
                        gameRunning = false;
                    }
                    else
                    {
                        player = 'X';
                    }
                }
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

        static void MakePlayerMove()
        {
            int move;
            while (true)
            {
                Console.WriteLine("Make your move (1-9):");
                bool isValidMove = int.TryParse(Console.ReadLine(), out move);
                if (isValidMove && move >= 1 && move <= 9 && board[move - 1] == ' ')
                {
                    board[move - 1] = player;
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid move. Try again.");
                }
            }
        }

        static void MakeAIMove()
        {
            Console.WriteLine("AI's turn:");

            // Check for a winning move
            for (int i = 0; i < 9; i++)
            {
                if (board[i] == ' ')
                {
                    board[i] = aiPlayer;
                    if (CheckWin(aiPlayer))
                        return;
                    else
                        board[i] = ' ';
                }
            }

            // Check for a blocking move
            for (int i = 0; i < 9; i++)
            {
                if (board[i] == ' ')
                {
                    board[i] = player;
                    if (CheckWin(player))
                    {
                        board[i] = aiPlayer;
                        return;
                    }
                    else
                        board[i] = ' ';
                }
            }

            // Choose a random move
            Random random = new Random();
            int randomMove;
            do
            {
                randomMove = random.Next(0, 9);
            } while (board[randomMove] != ' ');

            board[randomMove] = aiPlayer;
        }

        static bool CheckWin(char currentPlayer)
        {
            // Check rows
            for (int i = 0; i < 3; i++)
            {
                if (board[i * 3] == currentPlayer && board[i * 3 + 1] == currentPlayer && board[i * 3 + 2] == currentPlayer)
                    return true;
            }

            // Check columns
            for (int i = 0; i < 3; i++)
            {
                if (board[i] == currentPlayer && board[i + 3] == currentPlayer && board[i + 6] == currentPlayer)
                    return true;
            }

            // Check diagonals
            if (board[0] == currentPlayer && board[4] == currentPlayer && board[8] == currentPlayer)
                return true;

            if (board[2] == currentPlayer && board[4] == currentPlayer && board[6] == currentPlayer)
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