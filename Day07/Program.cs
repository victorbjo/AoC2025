using System;
using System.Collections;
using System.IO;
using System.Linq;
using System.Runtime.ExceptionServices;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Day05
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("input.txt");
            Console.WriteLine($"Part 1: {Part1(lines)}");
            Console.WriteLine($"Part 2: {Part2(lines)}");
        }
        static long Part1(string[] lines)
        {
            List<char[]> charList = lines.Select(x => x.ToCharArray()).ToList();
            for (int i = 0; i < charList[0].Length; i++)
            {
                if (charList[0][i] == 'S')
                {
                    charList[1][i] = '|';
                }
            }
            long sum = 0;
            long tempSum = 0;
            for (int i = 0; i < charList.Count() - 1; i++)
            {
                for (int j = 0; j < charList[0].Length; j++)
                {
                    if (charList[i][j] == '|')
                    {
                        if (charList[i + 1][j] == '^')
                        {
                            sum++;
                            charList[i + 1][j + 1] = '|';
                            charList[i + 1][j - 1] = '|';
                        }
                        else
                        {
                            charList[i + 1][j] = '|';
                        }
                    }
                }


            }



            for (int i = 0; i < charList.Count(); i++)
            {

                Console.WriteLine(new string(charList[i]));
            }

            return sum;
        }

        static long exhaustiveSearch(List<char[]> charList, (int x, int y) coors)
        {
            Stack<(int x, int y)> coordinates = new Stack<(int, int)>();
            coordinates.Push((coors.x, coors.y));
            long tempSum = 1;
            while (coordinates.Count() > 0)
            {
                //Console.WriteLine("ASD");
                var current = coordinates.Pop();
                if (current.x != charList.Count() - 1)
                {

                    if (charList[current.x + 1][current.y] == '^')
                    {
                        coordinates.Push((current.x + 1, current.y + 1));
                        coordinates.Push((current.x + 1, current.y - 1));
                        tempSum += 1;
                    }
                    else
                    {
                        //Console.WriteLine("ASD");

                        coordinates.Push((current.x + 1, current.y));

                        //Console.WriteLine(coordinates.Count());
                    }
                }

            }
            return tempSum;
            /*if (charList[x][y] == '^')
            {
                exhaustiveSearch
            }*/

            //return 0;
        }
        static void addNum(List<string[]> charList, (int x,int y) coors, long amount)
        {
            if (long.TryParse(charList[coors.x][coors.y], out _)){
                charList[coors.x][coors.y] = (long.Parse(charList[coors.x][coors.y]) + amount).ToString();
            }
            else
            {
                charList[coors.x][coors.y] = (amount).ToString();
            }
        }
        static long Part2(string[] lines)
        {
            List<string[]> charList = lines.Select(line => line.Select(c => c.ToString()).ToArray()).ToList();
            for (int i = 0; i < charList[0].Length; i++)
            {
                if (charList[0][i] == "S")
                {
                    charList[1][i] = "1";
                }
            }
            long sum = 0;
            long tempSum = 0;
            for (int i = 0; i < charList.Count() - 1; i++)
            {
                for (int j = 0; j < charList[0].Length; j++)
                {
                    if (long.TryParse(charList[i][j], out _))
                    {
                        //long current = int.TryParse(charList[i][j], out _) ? long.Parse(charList[i][j]) : 0;
                        if (charList[i + 1][j] == "^")
                        {
                            addNum(charList, (i + 1, j + 1), long.Parse(charList[i][j]));
                            addNum(charList, (i + 1, j - 1), long.Parse(charList[i][j]));
                            //charList[i + 1][j + 1] = "|";
                            //charList[i + 1][j - 1] = "|";
                        }
                        else
                        {
                            addNum(charList, (i + 1, j), long.Parse(charList[i][j]));
                            //charList[i + 1][j] = "|";
                        }
                    }
                }


            }
            /*for (int i = 0; i < charList.Count(); i++)
            {

                Console.WriteLine(string.Join("   ",charList[i]));
            }*/
            long sums = 0;
            for (int i = 0; i < charList[charList.Count()-1].Length; i++)
            {
                if (long.TryParse(charList[charList.Count()-1][i], out _))
                {
                    sums += long.Parse(charList[charList.Count() - 1][i]);
                }
            }

            return sums;
        }
    }
}