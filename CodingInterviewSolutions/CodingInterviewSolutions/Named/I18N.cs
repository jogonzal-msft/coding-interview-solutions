using System;
using System.Collections.Generic;
using System.Linq;

namespace CodingInterviewSolutions.Named
{
	public class I18NCountingSolution
	{
		public static List<string> GenerateAllPossibleAbbreviationsInternal(string input)
		{
			int numberOfAbbreviations = (int) Math.Pow(2, input.Length);
			char[][] possibleAbbreviations = new char[numberOfAbbreviations][];
			for (int i = 0; i < numberOfAbbreviations; i++)
			{
				possibleAbbreviations[i] = input.ToCharArray();
				PopulateProperly(i, input, possibleAbbreviations[i]);
			}

			return possibleAbbreviations.Select(p => new string(p)).ToList();
		}

		private static void PopulateProperly(int currentNumber, string input, char[] possibleAbbreviation)
		{
			int currentBit = 1;
			for (int i = 0; i < input.Length; i++)
			{
				if ((currentNumber & currentBit) > 0)
				{
					possibleAbbreviation[i] = '1';
				}

				// Cycle through all the bits
				currentBit = currentBit << 1;
			}
		}
	}

	public class I18NRecursiveSolution
	{
		public static List<string> GenerateAllPossibleAbbreviationsInternal(string input)
		{
			// Take a recursive approach - first generate all possible solutions for the input - 1
			return RecursiveHelper(input, 0);
		}

		private static List<string> RecursiveHelper(string input, int currentCharacter)
		{
			List<char> options = new List<char>()
			{
				'1',
				input[currentCharacter]
			};

			if (currentCharacter == input.Length - 1)
			{
				return options.Select(o => o.ToString()).ToList();
			}

			List<string> rec = RecursiveHelper(input, currentCharacter + 1);
			List<string> result = new List<string>(rec.Count * 2);
			foreach (var option in options)
			{
				result.AddRange(rec.Select(recIndividual => option + recIndividual));
			}
			return result;
		}
	}
}
