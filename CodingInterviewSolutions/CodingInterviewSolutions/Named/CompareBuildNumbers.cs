using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingInterviewSolutions.Named
{
	public static class CompareBuildNumbers
	{
		public static int Compare(string a, string b)
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
	}
}
