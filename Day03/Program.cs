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
        static int Part1(string[] input)
        {
            int sum = 0;
            for (int i = 0; i < input.Length; i++)
            {
                int highest = 0;
                int secondHighest = 0;
                for (int j = 0; j < input[i].Length; j++)
                {
                    int currentDigit = int.Parse(input[i][j].ToString());
                    if (j != input[i].Length - 1)
                    {
                        if (currentDigit > highest)
                        {
                            secondHighest = 0;
                            highest = currentDigit;
                        }
                        else
                        {
                            secondHighest = secondHighest > currentDigit ? secondHighest : currentDigit;
                        }
                    }
                    else
                    {
                        secondHighest = secondHighest > currentDigit ? secondHighest : currentDigit;
                    }

                }
                int batteryBank = int.Parse(string.Concat(highest.ToString(), secondHighest.ToString()));
                sum += batteryBank;
            }
            return sum;
        }
        static long Part2(string[] input)
        {
            long sum = 0;

            for (int i = 0; i < input.Length; i++)
            {
                int[] listOfDigits = new int[12];
                for (int j = 0; j < input[i].Length; j++)
                {
                    int currentDigit = int.Parse(input[i][j].ToString());
                    int digitsLeft = input[i].Length - j;
                    
                    for (int k = 0; k < listOfDigits.Length; k++)
                    {
                        
                        if (listOfDigits.Length - k > digitsLeft)
                        {
                            //Console.WriteLine($"Current Digit: {currentDigit}, digits left {digitsLeft}, k {k}");
                            continue;
                        }
                        if (listOfDigits[k] < currentDigit)
                        {
                            listOfDigits[k] = currentDigit;
                            //Make the rest of the array zeroes
                            for (int l = k + 1; l < listOfDigits.Length; l++)
                            {
                                listOfDigits[l] = 0;
                            }
                            break;
                        }
                    }
                }
                string stringOfDigits = string.Join("", listOfDigits);
                //Console.WriteLine(stringOfDigits);
                sum += long.Parse(stringOfDigits);
        }
            return sum;
        }
    }
    }
