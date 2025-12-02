using System;
using System.IO;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Day02
{
    class Program
    {
        static void Main(string[] args)
        {
            // Read all lines from the input file
            string lines = File.ReadAllText("input.txt");
            //long part1_solution = part1(lines);
            long part2_solution = part2(lines);
            //Console.WriteLine($"Part 1 Solution: {part1_solution}");
            Console.WriteLine($"Part 2 Solution: {part2_solution}");
            Console.WriteLine($"Part 2 Solution: {check_validity_part2(999)}");
        }

        static long part1(string lines)
        {
            string[] ranges = lines.Split(",");
            long sum = 0;
            for (int i = 0; i < ranges.Length; i++)
            {
                //sum = 0;
                string[] range_temp = ranges[i].Split("-");
                long range_lower = long.Parse(range_temp[0]);
                long range_upper = long.Parse(range_temp[1]);

                for (long j = range_lower; j <= range_upper; j++)
                {
                    //bool value = check_validity(j);
                    sum += check_validity(j) ? j : 0;
                }
                //Console.WriteLine($"range_lower, range_upper: {range_lower},{range_upper}, {sum}");
            }
            return sum;
        }
        static bool check_validity(long ID)
            {
                string id_string = ID.ToString();
                if (id_string.Length % 2 != 0) return false;
                for (int i = 0; i < id_string.Length / 2; i++)
                {
                    if (id_string[i] != id_string[id_string.Length/2 + i]) {
                        return false;
                    }
                }
            return true;
            }
        static long part2(string lines)
        {
            string[] ranges = lines.Split(",");
            long sum = 0;
            for (int i = 0; i < ranges.Length; i++)
            {
                string[] range_temp = ranges[i].Split("-");
                long range_lower = long.Parse(range_temp[0]);
                long range_upper = long.Parse(range_temp[1]);

                for (long j = range_lower; j <= range_upper; j++)
                {
                    sum += check_validity_part2(j) ? j : 0;
                }
            }
            return sum;
        }
        static bool check_validity_part2(long ID)
        {
            string id_string = ID.ToString();
            for (int i = 1; i <= id_string.Length; i++)
            {
                if (id_string.Length % (i+1) != 0)
                {
                    continue;
                }
                int subArray_size = id_string.Length / (i+1);
                var subArrays = id_string
                    .Select((value, index) => new { value, index })
                    .GroupBy(item => item.index / subArray_size)
                    .Select(group => group.Select(item => item.value).ToArray())
                    .ToArray();
                bool allEqual = subArrays.All(sub => sub.SequenceEqual(subArrays[0]));

                if (allEqual)
                {
                    Console.WriteLine($"ID: {ID}");
                    return allEqual;
                }

            }
            return false;
        }
        }
    }