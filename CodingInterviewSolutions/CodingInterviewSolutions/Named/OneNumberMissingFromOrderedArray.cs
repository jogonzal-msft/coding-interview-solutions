using System;
using System.Collections.Generic;
using System.Linq;

namespace CodingInterviewSolutions.Named
{
	public static class OneNumberMissingFromOrderedArray
	{
		public static int Run(int[] arr)
		{
			HashSet<int> hash = new HashSet<int>();
			for(int i = 0; i < arr.Length + 1; i++)
			{
				hash.Add(i);
			}

			foreach (var i in arr)
			{
				if (!InRange(i, arr.Length + 1))
				{
					throw new ArgumentException("outside of range!");
				}

				if (!hash.Remove(i))
				{
					// Number is not in hash - this should never happen
					throw new ArgumentException("two numbers missing!");
				}
			}

			return hash.Single();
		}

		private static bool InRange(int i, int length)
		{
			return (i >= 0 && i < length);
		}
	}
}
