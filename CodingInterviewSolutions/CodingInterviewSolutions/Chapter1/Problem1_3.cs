using System;
using System.Text;

namespace CodingInterviewSolutions.Chapter1
{
	/// <summary>
	/// Write code to remove duplicate characters ins  astring without using any additional buffer
	/// </summary>
	public class Problem1_3
	{
		/// <summary>
		/// Approach 1: Use hashset to keep history of characters that we've seen - this is better but does not fit into the constraints of the problem
		/// Approach 2 (chosen): For each character that you see, swipe the rest of the string for that character
		/// </summary>
		public static string RemoveDuplicateCharacters(string input)
		{
			if (input == null)
			{
				throw new ArgumentNullException("input");
			}

			StringBuilder sb = new StringBuilder(input);
			for (int i = 0; i < sb.Length; i++)
			{
				char charToRemove = sb[i];
				for(int x  = i + 1; x < sb.Length; x++)
				{
					if (sb[x] == charToRemove)
					{
						sb.Remove(x, 1);
					}
				}
			}

			return sb.ToString();
		}
	}
}
