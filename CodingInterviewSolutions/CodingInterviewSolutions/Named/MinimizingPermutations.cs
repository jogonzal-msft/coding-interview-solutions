using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace CodingInterviewSolutions.Named
{
	public class MinimizingPermutations
	{
        private static bool isSolution(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] != (i + 1))
                {
                    return false;
                }
            }

            return true;
        }

        private static int[] InvertAtRange(int start, int end, int[] arr)
        {
            var newArr = new int[arr.Length];
            // 3 ranges to copy
            // 0 to i - 1 (normal)
            for (int i = 0; i < start; i++)
            {
                newArr[i] = arr[i];
            }
            // i to j (inverted)
            int length = end - start + 1;
            for (int i = 0; i < length / 2; i++)
            {
                newArr[i + start] = arr[end - i];
                newArr[end - i] = arr[i + start];
            }
            if (length % 2 == 1)
			{
                newArr[start + length / 2] = arr[start + length / 2];
			}
            // j to end (normal)
            for (int i = end + 1; i < arr.Length; i++)
            {
                newArr[i] = arr[i];
            }
            return newArr;
        }

        private static List<int[]> ExploreAllPossibilities(int[] arr)
        {
            Console.WriteLine($"Started with {JsonConvert.SerializeObject(arr)}");
            List<int[]> list = new List<int[]>();
            // Explore all possible ranges that can be inverted
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    int[] newArr = InvertAtRange(i, j, arr);
                    list.Add(newArr);
                    Console.WriteLine($"Came up with {JsonConvert.SerializeObject(newArr)}");
                }
            }

            return list;
        }

        public static int minOperations(int[] arr)
        {
            List<int[]> possibilitiesInLastLevel = new List<int[]>();
            int output = 0;

            if (isSolution(arr))
            {
                return output;
            }

            possibilitiesInLastLevel.Add(arr);

            while (true)
            {
                output++;
                Debug.WriteLine($"Exploring level {output}. Have {possibilitiesInLastLevel.Count} possibilities to start");
                List<int[]> possibilitiesInThisLevel = new List<int[]>();
                // For every possibility in last level, explore all permutations, seeing if there is a solution
                foreach (var lastPossibility in possibilitiesInLastLevel)
                {
                    var possibilities = ExploreAllPossibilities(lastPossibility);
                    foreach (var possibility in possibilities)
                    {
                        if (isSolution(possibility))
                        {
                            return output;
                        }
                    }
                    possibilitiesInThisLevel.AddRange(possibilities);
                }

                possibilitiesInLastLevel = possibilitiesInThisLevel;
            }

            return output;
        }
    }
}
