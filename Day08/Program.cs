using System;
using System.Collections;
using System.IO;
using System.Linq;
using System.Runtime.ExceptionServices;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Day08
{
        public class JunctionBox
        {
            public int X { get; }
            public int Y { get; }
            public int Z { get; }

            public JunctionBox(int x, int y, int z)
            {
                X = x;
                Y = y;
                Z = z;
            }

            public double DistanceTo(JunctionBox other)
            {
                long dx = (long)X - other.X;
                long dy = (long)Y - other.Y;
                long dz = (long)Z - other.Z;
                return Math.Sqrt(dx * dx + dy * dy + dz * dz);
            }
        public override string ToString()
            {
                return $"({X}, {Y}, {Z})";
            }
    }
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

            List<JunctionBox> jList = new List<JunctionBox>();
            foreach (string line in lines)
            {
                string[] coordinates3D = line.Split(",");
                JunctionBox point3D = new JunctionBox(int.Parse(coordinates3D[0]), int.Parse(coordinates3D[1]), int.Parse(coordinates3D[2]));
                jList.Add(point3D);
            }
            List<(double Dist, JunctionBox Box1, JunctionBox Box2)> distanceList = new List<(double, JunctionBox, JunctionBox)>();
            for (int i = 0; i < jList.Count(); i++)
            {
                for (int j = i; j < jList.Count(); j++)
                {
                    if (j == i)
                    {
                        continue;
                    }
                    var distance = (Dist: jList[i].DistanceTo(jList[j]), Box1: jList[i], Box2: jList[j]);
                    distanceList.Add(distance);
                }
            }
            distanceList = distanceList
                .OrderBy(item => item.Dist)
                .ToList();

            List<List<JunctionBox>> listOfUnions = new List<List<JunctionBox>>();
            for (int i = 0; i < 1000; i++)
            {

                List<int> listToMerge = new List<int>();
                for (int j = 0; j < listOfUnions.Count(); j++)
                {
                    if (listOfUnions[j].Contains(distanceList[i].Box1) || listOfUnions[j].Contains(distanceList[i].Box2))
                    {
                        if (!listOfUnions[j].Contains(distanceList[i].Box1))
                            listOfUnions[j].Add(distanceList[i].Box1);
                        if (!listOfUnions[j].Contains(distanceList[i].Box2))
                            listOfUnions[j].Add(distanceList[i].Box2);
                        listToMerge.Add(j);
                    }
                }
                //If no listToMerge is 0, then no lists containing either junctionboxes has been found and a new union will be added
                if (listToMerge.Count() == 0)
                {
                    List<JunctionBox> tempList = new List<JunctionBox>();
                    tempList.Add(distanceList[i].Box1);
                    tempList.Add(distanceList[i].Box2);
                    listOfUnions.Add(tempList);
                }
                else if (listToMerge.Count() > 1)
                {
                    List<JunctionBox> mergedUnion = new List<JunctionBox>();
                    foreach (int index in listToMerge)
                    {
                        mergedUnion.AddRange(listOfUnions[index]);
                    }
                    // Remove duplicates
                    mergedUnion = mergedUnion.Distinct().ToList();

                    // Remove old unions (descending order)
                    listToMerge.Sort((a, b) => b.CompareTo(a));
                    foreach (int index in listToMerge)
                    {
                        listOfUnions.RemoveAt(index);
                    }
                    // Add the merged, deduplicated union
                    listOfUnions.Add(mergedUnion);
                }
            }
            listOfUnions = listOfUnions.OrderByDescending(union => union.Count).ToList();

            long sum = listOfUnions[0].Count() * listOfUnions[1].Count() * listOfUnions[2].Count();
            return sum;

        }
        static long Part2(string[] lines)
        {

            List<JunctionBox> jList = new List<JunctionBox>();
            foreach (string line in lines)
            {
                string[] coordinates3D = line.Split(",");
                JunctionBox point3D = new JunctionBox(int.Parse(coordinates3D[0]), int.Parse(coordinates3D[1]), int.Parse(coordinates3D[2]));
                jList.Add(point3D);
            }
            List<(double Dist, JunctionBox Box1, JunctionBox Box2)> distanceList = new List<(double, JunctionBox, JunctionBox)>();
            for (int i = 0; i < jList.Count(); i++)
            {
                for (int j = i; j < jList.Count(); j++)
                {
                    if (j == i)
                    {
                        continue;
                    }
                    var distance = (Dist: jList[i].DistanceTo(jList[j]), Box1: jList[i], Box2: jList[j]);
                    distanceList.Add(distance);
                }
            }
            distanceList = distanceList
                .OrderBy(item => item.Dist)
                .ToList();

            List<List<JunctionBox>> listOfUnions = new List<List<JunctionBox>>();
            for (int i = 0; i < 100000; i++)
            {
                List<int> listToMerge = new List<int>();
                for (int j = 0; j < listOfUnions.Count(); j++)
                {
                    if (listOfUnions[j].Contains(distanceList[i].Box1) || listOfUnions[j].Contains(distanceList[i].Box2))
                    {
                        if (!listOfUnions[j].Contains(distanceList[i].Box1))
                            listOfUnions[j].Add(distanceList[i].Box1);
                        if (!listOfUnions[j].Contains(distanceList[i].Box2))
                            listOfUnions[j].Add(distanceList[i].Box2);
                        listToMerge.Add(j);
                    }
                }
                //If no listToMerge is 0, then no lists containing either junctionboxes has been found and a new union will be added
                if (listToMerge.Count() == 0)
                {
                    List<JunctionBox> tempList = new List<JunctionBox>();
                    tempList.Add(distanceList[i].Box1);
                    tempList.Add(distanceList[i].Box2);
                    listOfUnions.Add(tempList);
                }
                else if (listToMerge.Count() > 1)
                {
                    List<JunctionBox> mergedUnion = new List<JunctionBox>();
                    foreach (int index in listToMerge)
                    {
                        mergedUnion.AddRange(listOfUnions[index]);
                    }
                    // Remove duplicates
                    mergedUnion = mergedUnion.Distinct().ToList();

                    // Remove old unions (descending order)
                    listToMerge.Sort((a, b) => b.CompareTo(a));
                    foreach (int index in listToMerge)
                    {
                        listOfUnions.RemoveAt(index);
                    }
                    // Add the merged, deduplicated union
                    listOfUnions.Add(mergedUnion);
                }
                //Console.WriteLine(listOfUnions.Count());
                if (listOfUnions[0].Count() == 1000)
                {
                    long dist = (long)distanceList[i].Box1.X * (long)distanceList[i].Box2.X;
                    return dist;
                }
            }
            listOfUnions = listOfUnions.OrderByDescending(union => union.Count).ToList();

            //long sum = listOfUnions[0].Count() * listOfUnions[1].Count() * listOfUnions[2].Count();
            return 0;
        }
    }
}