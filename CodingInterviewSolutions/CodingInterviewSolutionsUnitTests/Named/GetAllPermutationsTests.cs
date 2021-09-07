using System;
using System.Collections.Generic;
using CodingInterviewSolutions.Named;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodingInterviewSolutionsUnitTests.Named
{
	[TestClass]
	public class GetAllPermutationsUnitTests
	{
		[TestMethod]
		public void TestPermutations_1()
		{
			var input = new List<int>() { 1, 2, 3 };
			List<IList<int>> expectedOutput = new List<IList<int>>()
			{
				new List<int>(){1, 2},
				new List<int>(){1, 3},
				new List<int>(){2, 1},
				new List<int>(){2, 3},
				new List<int>(){3, 1},
				new List<int>(){3, 2},
			};

			var output = GetAllPermutations.Get(input, 2);
			expectedOutput.ShouldBeEquivalentTo(output);
		}

		[TestMethod]
		public void TestPermutations_2()
		{
			var input = new List<int>() { 1, 2, 3 };
			List<IList<int>> expectedOutput = new List<IList<int>>()
			{
				new List<int>(){1, 2, 3},
				new List<int>(){1, 3, 2},
				new List<int>(){2, 1, 3},
				new List<int>(){2, 3, 1},
				new List<int>(){3, 1, 2},
				new List<int>(){3, 2, 1},
			};

			var output = GetAllPermutations.Get(input, 3);
			expectedOutput.ShouldBeEquivalentTo(output);
		}
	}
}
