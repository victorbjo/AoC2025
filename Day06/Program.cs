using System;
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
            List<List<int>> numberRows = new List<List<int>>();
            string operatorStr = lines[lines.Length - 1];
            List<string> operators = operatorStr.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();

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
        static long Part2(string[] lines)
        {
            List<char[]> linesExploded = new List<char[]>();
            foreach (var line in lines)
            {
                linesExploded.Add(line.ToCharArray());
            }
            List<string> numberList = new List<string>();
            List<List<string>> colList = new List<List<string>>();
            List<char> opList = new List<char>();


            string tempNum = "";

            foreach (var (index, operatorChar) in linesExploded[linesExploded.Count - 1].Select((value, index) => (index, value)))
            {
                if (operatorChar == '*' || operatorChar == '+')
                {
                    opList.Add(operatorChar);
                    if (index != 0)
                    {
                        colList.Add(numberList);
                        numberList = new List<string>();
                    }
                }
                foreach (var line in linesExploded)
                {
                    char lineChar = line[index];
                    bool inNum = char.IsDigit(lineChar);
                    if (inNum)
                    {
                        tempNum += lineChar;
                    }
                }
                numberList.Add(tempNum);
                tempNum = "";
            }
            colList.Add(numberList);
            long sum = 0;
            foreach(var (index, numList) in colList.Select((value, index) => (index, value)))
            {
                long tempMul = 1;
                long tempSum = 0;
                foreach(string num in numList)
                {
                    char operatorChar = opList[index];
                    if (!int.TryParse(num, out _))
                    {
                        continue;
                    }
                    //Console.WriteLine($"{num}");
                    if (operatorChar == '+')
                    {
                        tempSum += int.Parse(num);
                        tempMul = 0;
                    }
                    else
                    {
                        tempMul *= int.Parse(num);
                    }
                }
                //Console.WriteLine($"----");
                sum += tempSum;
                sum += tempMul;

            }
            return sum;
        }
    }
}