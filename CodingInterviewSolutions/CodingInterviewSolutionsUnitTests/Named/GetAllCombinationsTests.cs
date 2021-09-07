using System;
using System.Collections.Generic;
using CodingInterviewSolutions.Named;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodingInterviewSolutionsUnitTests.Named
{
	[TestClass]
	public class GetAllCombinationsUnitTests
	{
		[TestMethod]
		public void TestCombinations_1()
		{
			var input = new List<int>() { 1, 2, 3, 4 };
			List<IList<int>> expectedOutput = new List<IList<int>>()
			{
				new List<int>(){1, 2, 3},
				new List<int>(){1, 2, 4},
				new List<int>(){1, 3, 4},
				new List<int>(){2, 3, 4},
			};

			var output = GetAllCombinations.Get(input, 3);
			expectedOutput.Should().BeEquivalentTo(output);
		}

		[TestMethod]
		public void TestCombinations_2()
		{
			var input = new List<int>() { 1, 2, 3, 4 };
			List<IList<int>> expectedOutput = new List<IList<int>>()
			{
				new List<int>(){1, 2},
				new List<int>(){1, 3},
				new List<int>(){1, 4},
				new List<int>(){2, 3},
				new List<int>(){2, 4},
				new List<int>(){3, 4},
			};

			var output = GetAllCombinations.Get(input, 2);
			expectedOutput.Should().BeEquivalentTo(output);
		}
	}
}
