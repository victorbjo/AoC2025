using System;
using System.IO;
using System.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Day03
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("input.txt");
            Console.WriteLine($"Part 1: {Part1(lines)}");
            Console.WriteLine($"Part 2: {Part2(lines)}");
        }

        static (string[], int) removePaperRolls(string[] input)
        {
            int sum = 0;
            string[] lines = new string[input.Length];
            for (int i = 0; i < input.Length; i ++)
            {
                char[] chars = input[i].ToCharArray();
                for (int j = 0; j < input[i].Length; j++)
                {
                    if (input[i][j] != '@') continue;
                    int adjacentPapers = 0;
                    if (i != 0)
                    {
                        if (j != 0){
                            if (input[i - 1][j - 1] == '@') adjacentPapers++;
                        }
                        if (j != input[i].Length - 1)
                        {
                            if (input[i - 1][j + 1] == '@') adjacentPapers++;
                        }
                        if (input[i - 1][j] == '@') adjacentPapers++;
                    }
                    if (i != input.Length - 1)
                    {
                        if (j != 0)
                        {
                            if (input[i + 1][j - 1] == '@') adjacentPapers++;
                        }
                        if (j != input[i].Length - 1)
                        {
                            if (input[i + 1][j + 1] == '@') adjacentPapers++;
                        }
                        if (input[i + 1][j] == '@') adjacentPapers++;
                    }
                    if (j != 0)
                    {
                        if (input[i][j - 1] == '@') adjacentPapers++;
                    }
                    if (j != input[i].Length - 1)
                    {
                        if (input[i][j + 1] == '@') adjacentPapers++;
                    }
                    //Console.WriteLine(adjacentPapers);
                    sum = adjacentPapers < 4 ? sum + 1 : sum;
                    chars[j] = adjacentPapers < 4 ? '.' : chars[j];
                }
                lines[i] = new string(chars);
                //Console.WriteLine(lines[i]);
            }
            return (lines, sum);
        }
        static int Part1(string[] input)
        {
            var result = removePaperRolls(input);

            return result.Item2;
        }
        static long Part2(string[] input)
        {
            long sum = 0;
            while (true)
            {
                var result = removePaperRolls(input);
                input = result.Item1;
                if (result.Item2 == 0) break;
                sum += result.Item2;
            }
            return sum;
        }
    }
}
