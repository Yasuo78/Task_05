using System;
using System.IO;

namespace RAP_Task_05
{
    class Program
    {
        static string[] newFile = File.ReadAllLines($"maps/level01.txt");
        static char[,] Labirint = new char[newFile.Length, newFile[0].Length];
        static int HeroX;
        static int HeroY;
        static int k1_X;
        static int k1_Y;
        static int k2_X;
        static int k2_Y;
        static int k3_X;
        static int k3_Y;
        static int Fx;
        static int Fy;
        static bool k1 = false;
        static bool k2 = false;
        static bool k3 = false;


        static ConsoleKeyInfo key;
        static Random rnd = new Random();
        static bool mist = false;

        static char[,] ReadMap()
        {
            HeroX = 0;
            HeroY = 0;

            for (int i = 0; i < Labirint.GetLength(0); i++)
            {
                for (int j = 0; j < Labirint.GetLength(1); j++)
                {
                    Labirint[i, j] = newFile[i][j];

                    if (Labirint[i, j] == '♠')
                    {
                        HeroX = i;
                        HeroY = j;
                    }
                    else if (Labirint[i, j] == 'F')
                    {
                        Fx = i;
                        Fy = j;
                    }
                    else if (Labirint[i, j] == '1')
                    {
                        k1_X = i;
                        k1_Y = j;
                    }
                    else if (Labirint[i, j] == '2')
                    {
                        k2_X = i;
                        k2_Y = j;
                    }
                    else if (Labirint[i, j] == '3')
                    {
                        k3_X = i;
                        k3_Y = j;
                    }
                }
            }
            return Labirint;
        }


        static void DrawMap(char[,] map)
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    Console.Write(map[i, j]);
                }
                Console.WriteLine();
            }
        }

        static void Step()
        {
            char key1 = '_';
            char key2 = '_';
            char key3 = '_';

            do
            {
                Console.WriteLine("Соберите 3 ключа и доберитесь до финиша");
                Console.WriteLine($"Ключи: 1{key1} 2{key2} 3{key3}");


                DrawMap(Labirint);

                key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.LeftArrow)
                {
                    if ((Labirint[HeroX, HeroY - 1] != '█') && (HeroY != 0))
                    {
                        Labirint[HeroX, HeroY - 1] = '♠';
                        Labirint[HeroX, HeroY] = '*';
                        HeroY--;
                    }
                    else mist = true;
                }
                else if (key.Key == ConsoleKey.RightArrow)
                {
                    if ((Labirint[HeroX, HeroY + 1] != '█') && (HeroY != Labirint.GetLength(1)))
                    {
                        Labirint[HeroX, HeroY + 1] = '♠';
                        Labirint[HeroX, HeroY] = '*';
                        HeroY++;
                    }
                    else mist = true;
                }
                else if (key.Key == ConsoleKey.UpArrow)
                {
                    if ((Labirint[HeroX - 1, HeroY] != '█') && (HeroX != 0))
                    {
                        Labirint[HeroX - 1, HeroY] = '♠';
                        Labirint[HeroX, HeroY] = '*';
                        HeroX--;
                    }
                    else mist = true;
                }
                else if (key.Key == ConsoleKey.DownArrow)
                {
                    if ((Labirint[HeroX + 1, HeroY] != '█') && (HeroX != Labirint.GetLength(0)))
                    {
                        Labirint[HeroX + 1, HeroY] = '♠';
                        Labirint[HeroX, HeroY] = '*';
                        HeroX++;
                    }
                    else mist = true;
                }
                Labirint[Fx, Fy] = 'F';

                if ((HeroX == k1_X) && (HeroY == k1_Y))
                {
                    k1 = true;
                    key1 = '*';
                }
                if ((HeroX == k2_X) && (HeroY == k2_Y))
                {
                    k2 = true;
                    key2 = '*';
                }
                if ((HeroX == k3_X) && (HeroY == k3_Y))
                {
                    k3 = true;
                    key3 = '*';
                }

                Console.Clear();

                if ((Labirint[HeroX, HeroY] == Labirint[Fx, Fy]) && (k1 == true) && (k2 == true) && (k3 == true)) break;

            } while (true);

            Console.WriteLine(@"  ██╗   ██╗██╗ ██████╗████████╗ ██████╗ ██████╗ ██╗   ██╗
██║   ██║██║██╔════╝╚══██╔══╝██╔═══██╗██╔══██╗╚██╗ ██╔╝
██║   ██║██║██║        ██║   ██║   ██║██████╔╝ ╚████╔╝ 
╚██╗ ██╔╝██║██║        ██║   ██║   ██║██╔══██╗  ╚██╔╝  
 ╚████╔╝ ██║╚██████╗   ██║   ╚██████╔╝██║  ██║   ██║   
  ╚═══╝  ╚═╝ ╚═════╝   ╚═╝    ╚═════╝ ╚═╝  ╚═╝   ╚═╝");
        }

        static void Main(string[] args)
        {
            Labirint = ReadMap();

            Step();
        }
    }
}