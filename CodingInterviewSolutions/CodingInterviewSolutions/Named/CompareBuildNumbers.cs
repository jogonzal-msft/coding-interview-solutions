using System;
using System.Linq;

namespace CodingInterviewSolutions.Named
{
	public static class CompareBuildNumbers
	{
		public static int Compare(string a, string b)
		{
			return CompareEfficient(a, b);
		}

		public static int CompareInefficient(string a, string b)
		{
			if (a == null)
			{
				a = "";
			}

			if (b == null)
			{
				b = "";
			}

			var aChunks = a.Split('.').ToList();
			var bChunks = b.Split('.').ToList();

			// To compare, we have to "even" out the number of elements
			while (aChunks.Count < bChunks.Count)
			{
				aChunks.Add("0");
			}
			while (bChunks.Count < aChunks.Count)
			{
				bChunks.Add("0");
			}

			// After they have the same # of elements, now we can start to compare, starting with the leftmost
			for(int i = 0; i < aChunks.Count; i++)
			{
				var aChunk = aChunks[i];
				var bChunk = bChunks[i];
				int aChunkAsInt;
				if (!int.TryParse(aChunk, out aChunkAsInt))
				{
					// Consider this value a 0
					aChunkAsInt = 0;
				}
				int bChunkAsInt;
				if (!int.TryParse(bChunk, out bChunkAsInt))
				{
					// Consider this value a 0
					bChunkAsInt = 0;
				}

				if (aChunkAsInt < bChunkAsInt)
				{
					return -1; // A is smaller
				}
				if (aChunkAsInt > bChunkAsInt)
				{
					return 1; // B is smaller
				}
			}

			return 0;
		}

		public static int CompareEfficient(string a, string b)
		{
			if (a == null)
			{
				a = "";
			}

			if (b == null)
			{
				b = "";
			}

			var aChunks = a.Split('.');
			var bChunks = b.Split('.');

			int endOfLoop = Math.Max(aChunks.Length, bChunks.Length);
			for (int i = 0; i < endOfLoop; i++)
			{
				int aChunkAsInt = CompareBuildNumbers.GetChunkAtIndex(aChunks, i);
				int bChunkAsInt = CompareBuildNumbers.GetChunkAtIndex(bChunks, i);

				if (aChunkAsInt < bChunkAsInt)
				{
					return -1; // A is smaller
				}
				if (aChunkAsInt > bChunkAsInt)
				{
					return 1; // B is smaller
				}
			}

			return 0;
		}

		private static int GetChunkAtIndex(string[] chunks, int i)
		{
			if (i >= chunks.Length)
			{
				return 0;
			}

			string currentChunk = chunks[i];
			int currentChunkAsInt;
			if (!int.TryParse(currentChunk, out currentChunkAsInt))
			{
				return 0;
			}
			return currentChunkAsInt;
		}
	}
}
