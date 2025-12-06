using System;
using System.IO;
using System.Linq;
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
            List<List<int>> numberRows = new List<List<int>>();
            string operatorStr = lines[lines.Length - 1];
            List<string> operators = operatorStr.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();

            /*
            for (int i = 0; i < lines.Length; i++) {
                string[] lineSplit = lines[i].Split(' ');
                List<int> numberRow = new List<int>();
                if (i == lines.Length - 1) {
                    continue;
                }
                foreach (string numberStr in lineSplit) {
                    if (numberStr.Trim() == "") {
                        continue;
                    }
                    int number = int.Parse(numberStr.Trim());
                    numberRow.Add(number);
                }
                numberRows.Add(numberRow);
            }*/


            long sum = 0;
            Console.WriteLine(numberRows.Count);
            for (int i = 0; i < operators.Count; i++)
            {
                long tempSum = 0;
                long tempMul = 1;
                for (int j = 0; j < lines.Length; j++)
                {
                    if (j == lines.Length - 1)
                    {
                        continue;
                    }
                    List<string> numberList = lines[j].Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
                    if (operators[i] == "*")
                    {
                        tempMul *= int.Parse(numberList[i]);
                        //Console.WriteLine(numberList[i]);
                    }
                    else
                    {
                        tempMul = 0;
                        tempSum += int.Parse(numberList[i]);
                    }
                }
                sum += tempSum;
                sum += tempMul;
            }


            return sum;
        }
        static int Part2(string[] lines)
        {
            return 0;
        }
    }
}