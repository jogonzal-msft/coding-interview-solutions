using System.Collections.Generic;
using System.Diagnostics;

namespace CodingInterviewSolutions.Named
{
	public class SumOfTwoNumbersInArray
	{
		/// <summary>
		/// Given an array with numbers and a number target, determine if the array contains two numbers which if summed together, add up to target
		/// </summary>
		public static bool Run(List<int> arr, int target)
		{
			// Build a dictionary with all the elements in it and their occurrence count
			Dictionary<int, int> dict = new Dictionary<int, int>(arr.Count);
			foreach (var num in arr)
			{
				int currentCountOfNumber;
				if (!dict.TryGetValue(num, out currentCountOfNumber))
				{
					currentCountOfNumber = 0;
				}
				dict[num] = currentCountOfNumber + 1;
			}

			foreach (var num in arr)
			{
				int complement = target - num;
				Debug.WriteLine("{0} - {1} = {2}", target, num, complement);
				int minimumRequirement = complement == num ? 2 : 1;

				int currentCount;
				if (!dict.TryGetValue(complement, out currentCount))
				{
					currentCount = 0;
				}

				if (minimumRequirement <= currentCount)
				{
					return true;
				}
			}

			return false;
		}
	}
}
