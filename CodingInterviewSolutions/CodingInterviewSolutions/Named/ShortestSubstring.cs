using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace CodingInterviewSolutions.Named
{
	public class MinimumLengthSubstrings
	{
		public class CharRequirement
		{
			public int required { get; set; }
			public List<int> positions { get; set; }
		}

		public class Range
		{
			public int start { get; set; }
			public int end { get; set; }
		}

		private static Range MergePositionIntoRange(Range range, int position)
		{
			if (range == null)
			{
				return new Range()
				{
					start = position,
					end = position,
				};
			}

			range.start = Math.Min(range.start, position);
			range.end = Math.Max(range.end, position);
			return range;
		}

		private static List<List<int>> ExploreOptions(List<int> positions, int slots, int index)
		{
			List<List<int>> list = new List<List<int>>();
			for (int i = 0; i < positions.Count - slots + 1; i++)
			{
				int element = positions[i];

				if (slots == 1)
				{
					List<int> newList = new List<int>();
					newList.Add(element);
					list.Add(newList);
				}
				else
				{
					var exploredList = ExploreOptions(positions, slots - 1, index + 1);
					foreach (var option in exploredList)
					{
						option.Add(element);
						list.Add(option);
					}
				}
			}

			return list;
		}

		private static Dictionary<char, List<int>> GetPositionMap(string s)
		{
			var dict = new Dictionary<char, List<int>>();
			for (int i = 0; i < s.Length; i++)
			{
				char c = s[i];
				var list = dict.GetValueOrDefault(c);
				if (list == null)
				{
					list = new List<int>();
					dict[c] = list;
				}
				list.Add(i);
			}
			return dict;
		}

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

		private static List<List<int>> ConvertRequirementToOptions(CharRequirement requirement)
		{
			List<int> positions = requirement.positions;
			int slots = requirement.required;

			return ExploreOptions(positions, slots, 0);
		}

		private static Range ConvertToRange(List<int> options)
		{
			Range range = null;
			foreach(var option in options)
			{
				range = MergePositionIntoRange(range, option);
			}
			return range;
		}

		private static Range CombineRangeWithRange(Range range1, Range range2)
		{
			return new Range()
			{
				start = Math.Min(range1.start, range2.start),
				end = Math.Max(range1.end, range2.end),
			};
		}

		public static int MinLengthSubstring(String s, String t)
		{
			// Create position map s and density map for t
			var positionMapS = GetPositionMap(s);
			var densityMapT = GetDensityMap(t);

			// Find possible positions of required characters
			List<CharRequirement> requirements = new List<CharRequirement>();
			foreach (var entry in densityMapT)
			{
				var c = entry.Key;
				var required = entry.Value;
				var positions = positionMapS.GetValueOrDefault(c);
				if (positions == null || required > positions.Count)
				{
					return -1; // If the match isn't found, then that's it
				}

				requirements.Add(new CharRequirement()
				{
					required = required,
					positions = positions,
				});
			}

			// Do the required ones first
			requirements.Sort((x, y) => {
				int xVariants = x.positions.Count - x.required;
				int yVariants = y.positions.Count - y.required;

				return xVariants > yVariants ? 1 : -1;
			});

			// Convert to position possibilities
			List<List<Range>> rangePaths = requirements.Select(ConvertRequirementToOptions).Select(r => r.Select(ConvertToRange).ToList()).ToList();
			Debug.WriteLine(JsonConvert.SerializeObject(rangePaths));

			// Initialize ranges, then explore
			List<Range> possibleRanges = new List<Range>();

			foreach (var range in rangePaths[0])
			{
				possibleRanges.Add(range);
			}

			for (int i = 1; i < rangePaths.Count; i++)
			{
				var possibleRangePaths = rangePaths[i];
				if (possibleRangePaths.Count == 1)
				{
					foreach(var range in possibleRanges)
					{
						var rangePath = possibleRangePaths[0];
						range.start = Math.Min(range.start, rangePath.start);
						range.end = Math.Max(range.end, rangePath.end);
					}
				} else
				{
					List<Range> newRanges = new List<Range>();
					foreach (var rangePath in possibleRangePaths)
					{
						//Debug.WriteLine("Possible ranges:");
						//Debug.WriteLine(JsonConvert.SerializeObject(possibleRanges));
						foreach (var range in possibleRanges)
						{
							//Console.WriteLine(JsonConvert.SerializeObject(range));
							var resultRange = CombineRangeWithRange(range, rangePath);
							Debug.WriteLine($"Combine {JsonConvert.SerializeObject(rangePath)} and {JsonConvert.SerializeObject(range)} into {JsonConvert.SerializeObject(resultRange)}");
							newRanges.Add(resultRange);
							//Console.WriteLine(JsonConvert.SerializeObject(range));
						}
					}
					possibleRanges = newRanges;
				}
			}

			Debug.WriteLine(JsonConvert.SerializeObject(possibleRanges));

			return possibleRanges.Select(r => (r.end - r.start + 1)).Min();
		}
	}
}
