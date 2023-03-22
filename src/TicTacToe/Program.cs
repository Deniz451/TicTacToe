using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            int[] Board = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            bool GameOver = false;
            bool GameTie = false;
            char y = ' '; //abych vedel koho napsat do vyhry
            string UserInput;
            int z = 0; //abych moh prerusit player1 nebo 2 loop

            var UsedNumbers = new List<string>();
            var Player1 = new List<string>();
            var Player2 = new List<string>();
            var BoardMarks = new List<string>() { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };


            while (GameOver == false)  // BEGGINING OF GAME LOOP
            {

                z = 0;

                while (z == 0) //Player 1 playing
                {
                    Console.Clear();
                    Console.Write("      Player1 \n\n\n");
                    PrintBoard();

                    UserInput = Console.ReadLine();

                    if (UsedNumbers.Contains(UserInput))
                    {
                        Console.WriteLine("Please enter unused position");
                    }

                    else if (UserInput != "1" && UserInput != "2" && UserInput != "3" && UserInput != "4" && UserInput != "5" && UserInput != "6" && UserInput != "7" && UserInput != "8" && UserInput != "9")
                    {
                        Console.WriteLine("Please enter a position");
                    }

                    else
                    {
                        Player1.Add(UserInput);
                        BoardMarks[Int32.Parse(UserInput)] = "X";
                        z = 1;
                    }

                    UsedNumbers.Add(UserInput);
                    GameOver = CheckForP1();
                    GameTie = CheckForTie();

                }

                if (GameTie == true)
                {
                    GameOver = true;
                    break;
                }

                z = 0;

                while (z == 0) //Player 2 playing
                {
                    Console.Clear();
                    Console.Write("      Player2 \n\n\n");
                    PrintBoard();

                    UserInput = Console.ReadLine();

                    if (GameOver == true)
                    {
                        break;
                    }

                    else if (UsedNumbers.Contains(UserInput))
                    {
                        Console.WriteLine("Please enter unused position");
                        continue;
                    }

                    else if (UserInput != "1" && UserInput != "2" && UserInput != "3" && UserInput != "4" && UserInput != "5" && UserInput != "6" && UserInput != "7" && UserInput != "8" && UserInput != "9")
                    {
                        Console.WriteLine("Please enter a position");
                        continue;
                    }

                    else
                    {
                        Player2.Add(UserInput);
                        BoardMarks[Int32.Parse(UserInput)] = "O";
                        z = 1;

                        Console.Clear();
                        Console.Write("      Player2 \n\n\n");
                        PrintBoard();

                    }

                    UsedNumbers.Add(UserInput);
                    GameOver = CheckForP2();
                }
            } //END OF GAME LOOP

            Console.Clear();
            PrintBoard();

            if (y == '1') //checking who won
            {
                Console.WriteLine("Player 1 Wins!");
            }

            else if (y == '2')
            {
                Console.WriteLine("\nPlayer 2 Wins!");
            }

            else if (y == ' ')
            {
                Console.WriteLine("Tie!");
            }

            void PrintBoard ()
            {
                Console.WriteLine(
                       "      |     |     \n" +
                       "   " + BoardMarks[1] + "  |  " + BoardMarks[2] + "  |  " + BoardMarks[3] + "  \n" +
                       " _____|_____|_____\n" +
                       "      |     |     \n" +
                       "   " + BoardMarks[4] + "  |  " + BoardMarks[5] + "  |  " + BoardMarks[6] + "  \n" +
                       " _____|_____|_____\n" +
                       "      |     |     \n" +
                       "   " + BoardMarks[7] + "  |  " + BoardMarks[8] + "  |  " + BoardMarks[9] + "  \n" +
                       "      |     |     ");
            }

            bool CheckForP1 ()
            {
                if (Player1.Exists(x => x == "1") && Player1.Exists(x => x == "5") && Player1.Exists(x => x == "9"))
                {
                    y = '1';
                    return true;
                }

                else if (Player1.Exists(x => x == "3") && Player1.Exists(x => x == "5") && Player1.Exists(x => x == "7"))
                {
                    y = '1';
                    return true;
                }

                else if (Player1.Exists(x => x == "1") && Player1.Exists(x => x == "2") && Player1.Exists(x => x == "3"))
                {
                    y = '1';
                    return true;
                }

                else if (Player1.Exists(x => x == "4") && Player1.Exists(x => x == "5") && Player1.Exists(x => x == "6"))
                {
                    y = '1';
                    return true;
                }

                else if (Player1.Exists(x => x == "7") && Player1.Exists(x => x == "8") && Player1.Exists(x => x == "9"))
                {
                    y = '1';
                    return true;
                }

                else if (Player1.Exists(x => x == "1") && Player1.Exists(x => x == "4") && Player1.Exists(x => x == "7"))
                {
                    y = '1';
                    return true;
                }

                else if (Player1.Exists(x => x == "2") && Player1.Exists(x => x == "5") && Player1.Exists(x => x == "8"))
                {
                    y = '1';
                    return true;
                }

                else if (Player1.Exists(x => x == "3") && Player1.Exists(x => x == "6") && Player1.Exists(x => x == "9"))
                {
                    y = '1';
                    return true;
                }

                else
                {
                    return false;
                }
            }

            bool CheckForP2()
            {
                if (Player2.Exists(x => x == "1") && Player2.Exists(x => x == "5") && Player2.Exists(x => x == "9"))
                {
                    y = '2';
                    return true;
                }

                else if (Player2.Exists(x => x == "3") && Player2.Exists(x => x == "5") && Player2.Exists(x => x == "7"))
                {
                    y = '2';
                    return true;
                }

                else if (Player2.Exists(x => x == "1") && Player2.Exists(x => x == "2") && Player2.Exists(x => x == "3"))
                {
                    y = '2';
                    return true;
                }

                else if (Player2.Exists(x => x == "4") && Player2.Exists(x => x == "5") && Player2.Exists(x => x == "6"))
                {
                    y = '2';
                    return true;
                }

                else if (Player2.Exists(x => x == "7") && Player2.Exists(x => x == "8") && Player2.Exists(x => x == "9"))
                {
                    y = '2';
                    return true;
                }

                else if (Player2.Exists(x => x == "1") && Player2.Exists(x => x == "4") && Player2.Exists(x => x == "7"))
                {
                    y = '2';
                    return true;
                }

                else if (Player2.Exists(x => x == "2") && Player2.Exists(x => x == "5") && Player2.Exists(x => x == "8"))
                {
                    y = '2';
                    return true;
                }

                else if (Player2.Exists(x => x == "3") && Player2.Exists(x => x == "6") && Player2.Exists(x => x == "9"))
                {
                    y = '2';
                    return true;
                }

                else
                {
                    return false;
                }
            }

            bool CheckForTie()
            {
                if (UsedNumbers.Exists(x => x == "1") && UsedNumbers.Exists(x => x == "2") && UsedNumbers.Exists(x => x == "3") && UsedNumbers.Exists(x => x == "4") && UsedNumbers.Exists(x => x == "5") && UsedNumbers.Exists(x => x == "6") && UsedNumbers.Exists(x => x == "7") && UsedNumbers.Exists(x => x == "8") && UsedNumbers.Exists(x => x == "9"))
                {
                    return true;
                }

                else
                {
                    return false;
                }
            }


            Console.ReadLine();
        }
    }
}
