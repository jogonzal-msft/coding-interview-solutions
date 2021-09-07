using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace CodingInterviewSolutions.Named
{
	public class MinimumLengthSubstringsV2
	{
		private static Dictionary<char, int> GetDensityMap(string s)
		{
			var dict = new Dictionary<char, int>();
			for (int i = 0; i < s.Length; i++)
			{
				var c = s[i];
				dict[c] = dict.GetValueOrDefault(c) + 1;
			}
			return dict;
		}

		private static bool AreAllCharsInside(Dictionary<char, int> child, Dictionary<char, int> parent)
		{
			if (child.Count != parent.Count)
			{
				return false;
			}

			return child.All(entry => parent[entry.Key] <= entry.Value);
		}

		private static void ApplyDiff(int diff, char c, Dictionary<char, int> child, Dictionary<char, int> parent)
		{
			if (!parent.ContainsKey(c))
			{
				return;
			}

			int newVal = child.GetValueOrDefault(c) + diff;
			child[c] = newVal;
		}

		public static string MinLengthSubstring(String t, String s)
		{
			if (s.Length > t.Length)
			{
				return "";
			}

			var densityMapS = GetDensityMap(s);

			Debug.WriteLine($"Density map: {JsonConvert.SerializeObject(densityMapS)}");

			var slidingDensityMap = new Dictionary<char, int>();
			for (int i = 0; i < s.Length; i++)
			{
				if (!densityMapS.ContainsKey(t[i]))
				{
					// Ignore if not in list of chars
					continue;
				}

				slidingDensityMap[t[i]] = slidingDensityMap.GetValueOrDefault(t[i]) + 1;
			}

			Debug.WriteLine($"Sliding density map initial: {JsonConvert.SerializeObject(slidingDensityMap)}");

			int left = 0;
			int right = s.Length - 1;
			string minWindow = "";
			do {
				bool areAllCharsInside = AreAllCharsInside(slidingDensityMap, densityMapS);

				Debug.WriteLine($"{t.Substring(left, right - left + 1)} - AllCharsInside: {areAllCharsInside}. Left:{left} Right:{right} Sliding density map: {JsonConvert.SerializeObject(slidingDensityMap)}");

				if (areAllCharsInside)
				{
					if (minWindow == "" || minWindow.Length > right-left+1)
					{
						minWindow = t.Substring(left, right - left + 1);
					}
					ApplyDiff(-1, t[left], slidingDensityMap, densityMapS);
					left++;
				} else
				{
					if (right < t.Length - 1)
					{
						ApplyDiff(+1, t[right + 1], slidingDensityMap, densityMapS);
					}

					right++;
				}
				// Increase s or t depending on whether all chars are inside
			} while (right < t.Length && left < (t.Length - s.Length) + 1);

			return minWindow;
		}
	}
}
