using System;
using System.Collections.Generic;
using CodingInterviewSolutions.Named;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodingInterviewSolutionsUnitTests.Named
{
	[TestClass]
	public class MinInversionsUnitTests
	{
		[TestMethod]
		public void Test_1()
		{
			int[] arr = new int[] { 3, 1, 2 };
			MinimizingPermutations.minOperations(arr).Should().Be(2);
		}

		[TestMethod]
		public void Test_2()
		{
			int[] arr = new int[] { 5, 1, 2, 3, 4 };
			MinimizingPermutations.minOperations(arr).Should().Be(2);
		}
	}
}
