using System;
using System.IO;

namespace Day01
{
    class Program
    {
        static void Main(string[] args)
        {
            // Read all lines from the input file
            string[] lines = File.ReadAllLines("input.txt");
            int part1Result = Part1(lines);
            Console.WriteLine(part1Result);
            

            int part2Result = Part2(lines);
            Console.WriteLine(part2Result);
        }
        static int Part1(string[] lines) {
            // Print the number of lines
            Console.WriteLine($"Number of lines: {lines.Length}");
            int sum = 50;
            int metaSum = 0;
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].Contains("L")){
                    sum -= int.Parse(lines[i].Substring(1, lines[i].Length-1));
                }
                else {
                    sum += int.Parse(lines[i].Substring(1, lines[i].Length-1));
                }

                if (sum < 0 && Math.Abs(sum)%100 != 0)
                {
                    sum = Math.Abs(sum) % 100;
                    sum = 100 - sum;
                }
                else if (Math.Abs(sum) >= 100)
                {
                    sum = sum%100;
                }
                if (sum == 0){
                    metaSum += 1;
                }
            }
            return metaSum;
        }
        

        static int Part2(string[] lines) {
             // Print the number of lines
            Console.WriteLine($"Number of lines: {lines.Length}");
            int sum = 50;
            int metaSum = 0;
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].Contains("L"))
                {
                    if (sum == 0) //If going left from 0, decrease metaSum by 1, as any negative sum will later be counted as having passed 0 at least once
                    {
                        metaSum -= 1;
                    }
                    sum -= int.Parse(lines[i].Substring(1, lines[i].Length - 1));
                }
                else
                {
                    sum += int.Parse(lines[i].Substring(1, lines[i].Length - 1));
                }
                if (sum == 0)
                {
                    metaSum += 1;
                }
                if (sum < 0)
                {
                    int temp = Math.Abs(sum) / 100;
                    metaSum += temp + 1;
                    sum = Math.Abs(sum) % 100;
                    sum = 100 - sum;
                    if (sum == 100)
                    { 
                        sum = 0;
                    }
                    
                }
                else if (sum >= 100)
                {
                    int temp = sum / 100;
                    metaSum += temp;
                    sum = sum % 100;
                }
                if (sum == 0)
                {
                    metaSum += 0;
                }
                //Print current sum and metaSum
                Console.WriteLine($"Current sum: {sum}, metaSum: {metaSum}, movement {lines[i]}");
            }
            return metaSum;
        }
    }
}