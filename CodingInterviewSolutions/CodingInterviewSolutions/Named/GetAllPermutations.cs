using System.Collections.Generic;

namespace CodingInterviewSolutions.Named
{
	public class GetAllPermutations
	{
		public static List<IList<int>> Get(List<int> input, int slots)
		{
			return GetAllPermutationsOptimized(input, new HashSet<int>(), slots);
		}

		private static List<IList<int>> GetAllPermutationsOptimized(List<int> arr, HashSet<int> picked, int count)
		{
			// Pick 1, write it, return it
			List<IList<int>> permutations = new List<IList<int>>();
			for (int i = 0; i < arr.Count; i++)
			{
				if (picked.Contains(i))
				{
					continue;
				}

				int element = arr[i];
				if (count == 1)
				{
					var newArr = new List<int>();
					newArr.Add(element);
					permutations.Add(newArr);
				}
				else
				{
					var newPicked = new HashSet<int>(picked);
					newPicked.Add(i);
					var otherCombinations = GetAllPermutationsOptimized(arr, newPicked, count - 1);
					foreach (var combination in otherCombinations)
					{
						combination.Insert(0, element);
						permutations.Add(combination);
					}
				}
			}

			return permutations;
		}
	}
}
