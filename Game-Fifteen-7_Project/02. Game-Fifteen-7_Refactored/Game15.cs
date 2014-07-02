namespace Game15
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    class Game15
    {
        static int[,] a = new int[4, 4] { { 1, 2, 3, 4 }, { 5, 6, 7, 8 }, { 9, 10, 11, 12 }, { 13, 14, 15, 0 } };
        static int x = 3;
        static int y = 3;
        static bool flag2 = true;
        static int countOfTotalMoves;
        static string[] topPlayersScores = new string[5];
        static int topCount = 0;

        static bool check(int i, int j)
        {
            if ((i == x - 1 || i == x + 1) && j == y)
            {
                return true;
            }

            if ((i == x) && (j == y - 1 || j == y + 1))
            {
                return true;
            }

            return false;
        }

        static void Move(int number)
        {
            int k = x;
            int l = y;
            bool flag = true;

            for (int row = 0; row < 4; row++)
            {
                if (flag)
                {
                    for (int col = 0; col < 4; col++)
                    {
                        if (a[row, col] == number)
                        {
                            k = row;
                            l = col;
                            flag = false;
                            break;
                        }
                    }
                }
                else
                {
                    break;
                }
            }

            bool flag2 = check(k, l);

            if (!flag2)
            {
                Console.WriteLine("Illegal move!");
            }
            else
            {
                int temp = a[k, l];
                a[k, l] = a[x, y];
                a[x, y] = temp;
                x = k;
                y = l;
                countOfTotalMoves++;

                Console.WriteLine(" -------------");

                for (int row = 0; row < 4; row++)
                {
                    Console.Write("| ");

                    for (int col = 0; col < 4; col++)
                    {
                        if (a[row, col] >= 10)
                        {
                            Console.Write("{0} ", a[row, col]);
                        }
                        else if (a[row, col] == 0)
                        {
                            Console.Write("   ");
                        }
                        else
                        {
                            Console.Write(" {0} ", a[row, col]);
                        }
                    }

                    Console.WriteLine("|");
                }

                Console.WriteLine(" -------------");
            }
        }

        static bool check2()
        {
            if (a[3, 3] == 0)
            {
                int n = 1;

                for (int row = 0; row < 4; row++)
                {
                    for (int col = 0; col < 4; col++)
                    {
                        if (n <= 15)
                        {
                            if (a[row, col] == n)
                            {
                                n++;
                            }
                            else
                            {
                                return false;
                            }
                        }
                        else
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        static void startagain()
        {
            countOfTotalMoves = 0;
            Random randomGenerator = new Random();

            for (int i = 0; i < 1000; i++)
            {
                int n = randomGenerator.Next(3);

                if (n == 0)
                {
                    int nx = x - 1;
                    int ny = y;

                    if (nx >= 0 && nx <= 3 && ny >= 0 && ny <= 3)
                    {
                        int temp = a[x, y];
                        a[x, y] = a[nx, ny];
                        a[nx, ny] = temp;
                        x = nx;
                        y = ny;
                    }
                    else
                    {
                        n++;
                        i--;
                    }
                }

                if (n == 1)
                {
                    int nx = x;
                    int ny = y + 1;

                    if (nx >= 0 && nx <= 3 && ny >= 0 && ny <= 3)
                    {
                        int temp = a[x, y];
                        a[x, y] = a[nx, ny];
                        a[nx, ny] = temp;
                        x = nx;
                        y = ny;
                    }
                    else
                    {
                        n++;
                        i--;
                    }
                }

                if (n == 2)
                {
                    int nx = x + 1;
                    int ny = y;

                    if (nx >= 0 && nx <= 3 && ny >= 0 && ny <= 3)
                    {
                        int temp = a[x, y];
                        a[x, y] = a[nx, ny];
                        a[nx, ny] = temp;
                        x = nx;
                        y = ny;
                    }
                    else
                    {
                        n++;
                        i--;
                    }
                }

                if (n == 3)
                {
                    int nx = x;
                    int ny = y - 1;

                    if (nx >= 0 && nx <= 3 && ny >= 0 && ny <= 3)
                    {
                        int temp = a[x, y];
                        a[x, y] = a[nx, ny];
                        a[nx, ny] = temp;
                        x = nx;
                        y = ny;
                    }
                    else
                    {
                        i--;
                    }
                }
            }

            Console.WriteLine(" -------------");

            for (int row = 0; row < 4; row++)
            {
                Console.Write("| ");

                for (int col = 0; col < 4; col++)
                {
                    if (a[row, col] >= 10)
                    {
                        Console.Write("{0} ", a[row, col]);
                    }
                    else if (a[row, col] == 0)
                    {
                        Console.Write("   ");
                    }
                    else
                    {
                        Console.Write(" {0} ", a[row, col]);
                    }
                }

                Console.WriteLine("|");
            }

            Console.WriteLine(" -------------");
        }

        static void move(int i, string res)
        {
            if (i == 0)
            {
                topPlayersScores[i] = res;
            }

            for (int j = 0; j < i; j++)
            {
                topPlayersScores[j] = topPlayersScores[j + 1];
            }

            topPlayersScores[i] = res;
        }

        public static void Main(string[] args)
        {
            while (flag2)
            {
                countOfTotalMoves = 0;
                Random r = new Random();

                for (int i = 0; i < 1000; i++)
                {
                    int n = r.Next(3);

                    if (n == 0)
                    {
                        int nx = x - 1;
                        int ny = y;
                        if (nx >= 0 && nx <= 3 && ny >= 0 && ny <= 3)
                        {
                            int temp = a[x, y];
                            a[x, y] = a[nx, ny];
                            a[nx, ny] = temp;
                            x = nx;
                            y = ny;
                        }
                        else
                        {
                            n++;
                            i--;
                        }
                    }

                    if (n == 1)
                    {
                        int nx = x;
                        int ny = y + 1;

                        if (nx >= 0 && nx <= 3 && ny >= 0 && ny <= 3)
                        {
                            int temp = a[x, y];
                            a[x, y] = a[nx, ny];
                            a[nx, ny] = temp;
                            x = nx;
                            y = ny;
                        }
                        else
                        {
                            n++;
                            i--;
                        }
                    }

                    if (n == 2)
                    {
                        int nx = x + 1;
                        int ny = y;

                        if (nx >= 0 && nx <= 3 && ny >= 0 && ny <= 3)
                        {
                            int temp = a[x, y];
                            a[x, y] = a[nx, ny];
                            a[nx, ny] = temp;
                            x = nx;
                            y = ny;
                        }
                        else
                        {
                            n++;
                            i--;
                        }
                    }

                    if (n == 3)
                    {
                        int nx = x;
                        int ny = y - 1;

                        if (nx >= 0 && nx <= 3 && ny >= 0 && ny <= 3)
                        {
                            int temp = a[x, y];
                            a[x, y] = a[nx, ny];
                            a[nx, ny] = temp;
                            x = nx;
                            y = ny;
                        }
                        else
                        {
                            i--;
                        }
                    }
                }

                Console.WriteLine("Welcome to the game “15”.\nPlease try to arrange the numbers sequentially.\nUse 'top' to view the top scoreboard,\n'restart' to start a new game\nand 'exit' to quit the game.\n");
                Console.WriteLine(" -------------");

                for (int row = 0; row < 4; row++)
                {
                    Console.Write("| ");

                    for (int col = 0; col < 4; col++)
                    {
                        if (a[row, col] >= 10)
                        {
                            Console.Write("{0} ", a[row, col]);
                        }
                        else if (a[row, col] == 0)
                        {
                            Console.Write("   ");
                        }
                        else
                        {
                            Console.Write(" {0} ", a[row, col]);
                        }
                    }

                    Console.WriteLine("|");
                }

                Console.WriteLine(" -------------");

                bool flagSolved = check2();

                while (!flagSolved)
                {
                    Console.Write("Enter a number to move: ");
                    string inputCommand = Console.ReadLine();
                    int selectedNumber;
                    bool flag = int.TryParse(inputCommand, out selectedNumber);

                    if (flag)
                    {
                        if (selectedNumber >= 1 && selectedNumber <= 15)
                        {
                            Move(selectedNumber);
                        }
                        else
                        {
                            Console.WriteLine("Illegal move!");
                        }
                    }
                    else
                    {
                        if (inputCommand == "exit")
                        {
                            Console.WriteLine("Good bye!");
                            flag2 = false;
                            break;
                        }
                        else
                        {
                            if (inputCommand == "restart")
                            {
                                startagain();
                            }
                            else
                            {
                                if (inputCommand == "top")
                                {
                                    Console.WriteLine("\nScoreboard:");

                                    if (topCount != 0)
                                    {
                                        for (int i = 5 - topCount; i < 5; i++)
                                        {
                                            Console.WriteLine("{0}", topPlayersScores[i]);
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("-");
                                    }

                                    Console.WriteLine();
                                }
                                else
                                {
                                    Console.WriteLine("Illegal command!");
                                }
                            }
                        }
                    }
                    flagSolved = check2();
                }

                if (flagSolved)
                {
                    Console.WriteLine("Congratulations! You won the game in {0} moves.", countOfTotalMoves);

                    Console.Write("Please enter your name for the top scoreboard: ");

                    string s1 = Console.ReadLine();

                    string res = countOfTotalMoves + " moves by " + s1;

                    if (topCount < 5)
                    {
                        topPlayersScores[topCount] = res;

                        topCount++;

                        Array.Sort(topPlayersScores);
                    }
                    else
                    {
                        for (int i = 4; i >= 0; i++)
                        {
                            if (topPlayersScores[i].CompareTo(res) <= 0)
                            {
                                move(i, res);
                            }
                        }
                    }

                    Console.WriteLine("\nScoreboard:");

                    if (topCount != 0)
                    {
                        for (int i = 5 - topCount; i < 5; i++)
                        {
                            Console.WriteLine("{0}", topPlayersScores[i]);
                        }
                    }
                    else
                    {
                        Console.WriteLine("-");
                    }

                    Console.WriteLine();
                }
            }
        }
    }
}