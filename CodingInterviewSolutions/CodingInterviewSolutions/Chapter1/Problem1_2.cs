using System;
using System.Collections.Generic;
using System.Text;

namespace CodingInterviewSolutions.Chapter1
{
	/// <summary>
	/// Write code to reverse a C-Style String (C-String means that “abcd” is
	/// represented as five characters, including the null character)
	/// </summary>
	public class Problem1_2
	{
		/// <summary>
		/// Approach: SWAP characters from first to last using a StringBuilder
		/// </summary>
		public static string ReverseCString(string input)
		{
			if (input == null)
			{
				throw new ArgumentNullException("input");
			}

			StringBuilder sb = new StringBuilder(input);
			for (int i = 0; i < input.Length/2; i++)
			{
				char charToSwap = sb[i];
				sb[i] = input[input.Length - i - 1];
				sb[input.Length - i - 1] = charToSwap;
			}

			return sb.ToString();
		}
	}
}
