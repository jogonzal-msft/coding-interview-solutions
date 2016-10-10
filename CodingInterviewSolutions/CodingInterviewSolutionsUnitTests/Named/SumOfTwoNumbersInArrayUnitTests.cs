using System.Collections.Generic;

using CodingInterviewSolutions.Named;

using FluentAssertions;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodingInterviewSolutionsUnitTests.Named
{
	[TestClass]
	public class SumOfTwoNumbersInArrayUnitTests
	{
		[TestMethod]
		public void SimpleList_ContainsAndNotContains()
		{
			var list = new List<int>()
			{
				1, 2, 3, 4, 5
			};

			SumOfTwoNumbersInArray.Run(list, 9).Should().BeTrue();
			SumOfTwoNumbersInArray.Run(list, 2).Should().BeFalse();
			SumOfTwoNumbersInArray.Run(list, 3).Should().BeTrue();
			SumOfTwoNumbersInArray.Run(list, 6).Should().BeTrue();
			SumOfTwoNumbersInArray.Run(list, 10).Should().BeFalse();
		}

		[TestMethod]
		public void RepeatedNumbers_Succeeds()
		{
			var list = new List<int>()
			{
				1, 2, 2
			};

			SumOfTwoNumbersInArray.Run(list, 4).Should().BeTrue();
			SumOfTwoNumbersInArray.Run(list, 3).Should().BeTrue();
			SumOfTwoNumbersInArray.Run(list, 2).Should().BeFalse();
			SumOfTwoNumbersInArray.Run(list, -1).Should().BeFalse();
		}
	}
}
