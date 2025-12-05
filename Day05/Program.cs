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

        static Tuple<List<Tuple<long, long>>, List<long>> ParseInput(string[] lines)
        {
            List<Tuple<long, long>> ranges = new List<Tuple<long, long>>();
            List<long> stock = new List<long>();
            bool changeFlag = false;
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i] == "")
                {
                    changeFlag = true;
                    continue;
                }
                if (!changeFlag)
                {
                    var parts = lines[i].Split('-');
                    ranges.Add(Tuple.Create(long.Parse(parts[0]), long.Parse(parts[1])));
                }
                else
                {
                    stock.Add(long.Parse(lines[i]));
                }
            }
            return Tuple.Create(ranges, stock);
        }
        static bool IsInRange(long number, List<Tuple<long, long>> range)
        {
            bool resultFlag = false;
            foreach (var rangeItem in range)
            {
                if (number >= rangeItem.Item1 && number <= rangeItem.Item2)
                {
                    resultFlag = true;
                    break;
                }

            }
            return resultFlag;
        }

        static int Part1(string[] lines)
        {
            var (ranges, stock) = ParseInput(lines);
            ranges = ranges.OrderBy(t => t.Item1).ToList();
            int sum = 0;
            foreach (var item in stock)
            {
                if (IsInRange(item, ranges))
                {
                    sum += 1;
                }
            }
            return sum;
        }

        static List<Tuple<long, long>> mergeRanges(List<Tuple<long, long>> ranges)
        {
            for (int i = 0; i < ranges.Count - 1; i++)
            {
                var currentRange = ranges[i];
                var nextRange = ranges[i + 1];
                if (currentRange.Item2 >= nextRange.Item1 - 1)
                {
                    var mergedRange = Tuple.Create(currentRange.Item1, Math.Max(currentRange.Item2, nextRange.Item2));
                    ranges[i] = mergedRange;
                    ranges.RemoveAt(i + 1);
                    i--;
                }
            }



            return ranges;
        }

        static long Part2(string[] lines)
        {
            var (ranges, stock) = ParseInput(lines);
            ranges = ranges.OrderBy(t => t.Item1).ToList();
            ranges = mergeRanges(ranges);
            long sum = 0;
            foreach (var range in ranges)
            {
                long rangeSize = range.Item2 - range.Item1 + 1;
                sum += rangeSize;
            }



            return sum;
        }
    }
}