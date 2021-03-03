using System;
using System.Collections.Generic;
using CodingInterviewSolutions.Named;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodingInterviewSolutionsUnitTests.Named
{
	[TestClass]
	public class CyclicSortTests
	{
		[TestMethod]
		public void SampleArray1()
		{
			List<int> input = new List<int>()
			{
				0, 2, 3, 5, 4, 1
			};

			List<int> expectedOutput = new List<int>()
			{
				0, 1, 2, 3, 4, 5
			};
			var output = CyclicSort.Sort(input);
			expectedOutput.ShouldBeEquivalentTo(output);
		}
	}
}
