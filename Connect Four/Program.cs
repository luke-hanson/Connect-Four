using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect_Four
{
    class Program
    {
        static void Main(string[] args)
        {
            string[,] board = new string[6, 7];
            int player = 2;
            bool win = false;

            //setting up a blank board
            for (int row = 0; row < 6; row++)
            {
                for (int collumn = 0; collumn < 7; collumn++)
                {
                    board[row, collumn] = "* ";
                    Console.Write(board[row, collumn]);
                }
                Console.WriteLine();
            }
            Console.WriteLine("1 2 3 4 5 6 7 ");

            //player turn loop
            while (win == false)
            {
                player--;
                win = coinDrop(board, player, win);
                if (win==true)
                {
                    Console.WriteLine("Congratulations Player" + player + "! You win!");
                    break;
                }
                player++;
                win=coinDrop(board, player, win);
                if (win == true)
                {
                    Console.WriteLine("Congratulations Player" + player + "! You win!");
                    break;
                }
            }
            
            Console.ReadKey();
        }   

        //Dropping a coin
        static bool coinDrop(string[,] board, int player, bool win)
        {
            int input;
            do
            {
                Console.WriteLine("Player" + player + ", enter the number of the collumn you wish to drop into. (1-7)");
                string inputAsString = Console.ReadLine();

                //in case a player enters nothing
                if (inputAsString == "")
                {
                    inputAsString = "0";
                }

                Console.Clear();

                input = Convert.ToInt32(inputAsString);

                //if a player enters a bad number
                if (input < 1 || input > 7)
                {
                    for (int row = 0; row < 6; row++)
                    {
                        for (int collumn = 0; collumn < 7; collumn++)
                        {
                            Console.Write(board[row, collumn]);
                        }
                        Console.WriteLine();
                    }
                    Console.WriteLine("1 2 3 4 5 6 7 ");
                    Console.WriteLine("Invalid number, try again.");
                }
              
            }
            while (input < 1 || input > 7);

            //determining player token
            string print;
            if (player==1)
            {
                print= "O ";
            }
            else
            {
                print="X ";
            }

            //placing player token
            for (int row=5; row>0; row--)
            {
                if (board[row,input - 1]=="* ")
                {
                    board[row, input - 1] = print;
                    break;
                }
            }

            //printing board
            for (int row = 0; row < 6; row++)
            {
                for (int collumn = 0; collumn < 7; collumn++)
                {
                    Console.Write(board[row, collumn]);
                }
                Console.WriteLine();
            }
            Console.WriteLine("1 2 3 4 5 6 7 ");

            //checking for a win
            win = horizontal (board, print, win);
            if (win==true)
            {
                return win;
            }

            win = vertical(board, print, win);
            if (win == true)
            {
                return win;
            }

            win = positive(board, print, win);
            if (win == true)
            {
                return win;
            }

            win = negative(board, print, win);
            if (win == true)
            {
                return win;
            }

            return win;
        }

        //horizontal win scan
        static bool horizontal (string[,] board, string print, bool win)
        {
            
            int winStreak = 0;

            for (int row = 0; row < 6; row++)
            {
                for (int collumn = 0; collumn < 7; collumn++)
                {
                    if (board[row,collumn]==print)
                    {
                        winStreak++;
                    }
                    else
                    {
                        winStreak = 0;
                    }

                    if (winStreak==4)
                    {
                        win = true;
                        return win;
                    }
                }
                winStreak = 0;
            }
            return win;
        }

        //vertical win scan
        static bool vertical(string[,] board, string print, bool win)
        {

            int winStreak = 0;

            for (int collumn = 0; collumn < 7; collumn++)
            {
                for (int row = 0; row < 6; row++)
                {
                    if (board[row, collumn] == print)
                    {
                        winStreak++;
                    }
                    else
                    {
                        winStreak = 0;
                    }

                    if (winStreak == 4)
                    {
                        win = true;
                        return win;
                    }
                }
                winStreak = 0;
            }
            return win;
        }

        //positive slant scan
        static bool positive(string[,] board, string print, bool win)
        {
            for (int row = 3; row < 6; row++)
            {
                for (int collumn = 0; collumn < 4; collumn++)
                {
                    if (board[row, collumn] == print)
                    {
                        if (board[row-1,collumn+1] == print)
                        {
                            if (board[row-2,collumn+2] == print)
                            {
                                if (board[row-3,collumn+3] == print)
                                {
                                    win = true;
                                    return win;
                                }
                            }
                        }
                    }
                }
            }
            return win;
        }

        //negative slant scan
        static bool negative(string[,] board, string print, bool win)
        {
            for (int row = 0; row < 3; row++)
            {
                for (int collumn = 0; collumn < 4; collumn++)
                {
                    if (board[row, collumn] == print)
                    {
                        if (board[row + 1, collumn + 1] == print)
                        {
                            if (board[row + 2, collumn + 2] == print)
                            {
                                if (board[row + 3, collumn + 3] == print)
                                {
                                    win = true;
                                    return win;
                                }
                            }
                        }
                    }
                }
            }
            return win;
        }
    }
}
