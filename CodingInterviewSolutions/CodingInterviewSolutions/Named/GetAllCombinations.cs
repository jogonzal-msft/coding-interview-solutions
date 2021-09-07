using System.Collections.Generic;

namespace CodingInterviewSolutions.Named
{
	public class GetAllCombinations
	{
		public static List<IList<int>> Get(List<int> input, int slots)
		{
			return GetAllCombinationsOptimized(input, slots, 0);
		}

		private static List<IList<int>> GetAllCombinationsOptimized(List<int> arr, int count, int startIndex)
		{
			// Pick 1, write it, return it
			List<IList<int>> combinations = new List<IList<int>>();

			for (int i = startIndex; i < arr.Count - count + 1; i++)
			{
				int element = arr[i];
				if (count == 1)
				{
					var newArr = new List<int>();
					newArr.Add(element);
					combinations.Add(newArr);
				}
				else
				{
					var otherCombinations = GetAllCombinationsOptimized(arr, count - 1, i + 1);
					foreach (var combination in otherCombinations)
					{
						combination.Insert(0, element);
						combinations.Add(combination);
					}
				}
			}

			return combinations;
		}
	}
}
