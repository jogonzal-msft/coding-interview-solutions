using System.Collections.Generic;

namespace CodingInterviewSolutions.Chapter1
{
	/// <summary>
	/// Implement an algorithm to determine if a string has all unique characters
	/// What if you can not use additional data structures?
	/// </summary>
	public class Problem1_1
	{
		/// <summary>
		/// Approach: Use a hashset to know if the characters have already been seen
		/// Adding to hashset (O(1))
		/// Checking hashset for value (O(1))
		/// </summary>
		public static bool HasOnlyUniqueCharacters(string input)
		{
			HashSet<char> hashset = new HashSet<char>();

			foreach(var character in input)
			{
				if (hashset.Contains(character))
				{
					// This means that the character was already present in the string
					return false;
				}
				hashset.Add(character);
			}

			// If we looped through the array without finding a match, done!
			return true;
		}

		public static bool HasOnlyUniqueCharactersWithoutDataStructure(string input)
		{
			for (int i = 0; i < input.Length; i++)
			{
				char character = input[i];
				// Check if from this point to the end, the character is present
				for (int k = i + 1; k < input.Length; k++)
				{
					if (character == input[k])
					{
						// Any match would indicate characters are not unique
						return false;
					}
				}
			}

			// If we looped through the array without finding a match, done!
			return true;
		}
	}
}
