using System;
using CodingInterviewSolutions.Named;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodingInterviewSolutionsUnitTests.Named
{
	[TestClass]
	public class CountRegionsInBoolArrayUnitTests
	{
		[TestMethod]
		public void MatrixWithNoRegions()
		{
			bool[,] matrix = new bool[3, 3]
			{
				{false, false, false},
 				{false, false, false},
				{false, false, false}
			};

			CountRegionsInBoolArray.FindCountRegionsWithTrue(matrix)
				.Should().Be(0);
		}

		[TestMethod]
		public void MatrixWith1RegionWith1()
		{
			bool[,] matrix = new bool[3, 3]
			{
				{false, false, false},
 				{false, true, false},
				{false, false, false}
			};

			CountRegionsInBoolArray.FindCountRegionsWithTrue(matrix)
				.Should().Be(1);
		}

		[TestMethod]
		public void MatrixWith2RegionsWith1()
		{
			bool[,] matrix = new bool[3, 3]
			{
				{false, false, false},
 				{false, true, false},
				{false, false, true}
			};

			CountRegionsInBoolArray.FindCountRegionsWithTrue(matrix)
				.Should().Be(2);
		}

		[TestMethod]
		public void MatrixWith3RegionsWith1()
		{
			bool[,] matrix = new bool[3, 3]
			{
				{true, false, false},
 				{false, true, false},
				{false, false, true}
			};

			CountRegionsInBoolArray.FindCountRegionsWithTrue(matrix)
				.Should().Be(3);
		}

		[TestMethod]
		public void MatrixWith1RegionWith6()
		{
			bool[,] matrix = new bool[3, 5]
			{
				{false, false, false, true, true},
 				{false, false, false, true, true},
				{false, false, false, true, true}
			};

			CountRegionsInBoolArray.FindCountRegionsWithTrue(matrix)
				.Should().Be(1);
		}

		[TestMethod]
		public void MatrixWith1RegionWith61RegionWith1()
		{
			bool[,] matrix = new bool[3, 5]
			{
				{true, false, false, true, true},
 				{false, false, false, true, true},
				{false, false, false, true, true}
			};

			CountRegionsInBoolArray.FindCountRegionsWithTrue(matrix)
				.Should().Be(2);
		}

		[TestMethod]
		public void WholeMatrixWith1Region()
		{
			bool[,] matrix = new bool[3, 5]
			{
				{true, true, true, true, true},
 				{true, true, true, true, true},
				{true, true, true, true, true}
			};

			CountRegionsInBoolArray.FindCountRegionsWithTrue(matrix)
				.Should().Be(1);
		}

		[TestMethod]
		public void MatrixThatIsNull_Throws()
		{
			bool[,] matrix = null;

			Action action = () =>
			{
				int someInt = CountRegionsInBoolArray.FindCountRegionsWithTrue(matrix);
			};

			action.ShouldThrow<ArgumentNullException>();
		}
	}
}
