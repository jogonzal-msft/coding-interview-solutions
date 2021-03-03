using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace CodingInterviewSolutions.Named
{
	public class CyclicSort
	{
		public static List<int> Sort(List<int> list)
		{
			Debug.WriteLine($"Entire array is ", JsonConvert.SerializeObject(list));

			// Unique numbers from 0-N in array, sort them
			for (int i = 0; i < list.Count; i++)
			{
				while(i != list[i])
				{
					// i is not in the right location, send it to the right location
					int temp = list[i];
					Debug.WriteLine($"Swapping {list[i]} and {list[temp]}");
					list[i] = list[temp];
					list[temp] = temp;
					Debug.WriteLine($"Entire array is ", JsonConvert.SerializeObject(list));
				}
			}

			return list;
		}
	}
}
