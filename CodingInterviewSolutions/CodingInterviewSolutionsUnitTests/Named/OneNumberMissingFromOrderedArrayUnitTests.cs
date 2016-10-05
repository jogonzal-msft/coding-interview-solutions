using System;
using System.Collections.Generic;
using CodingInterviewSolutions.Named;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodingInterviewSolutionsUnitTests.Named
{
	[TestClass]
	public class OneNumberMissingFromOrderedArrayUnitTests
	{
		[TestMethod]
		public void TestMethod1()
		{
			var input = new List<int>()
			{
				0,
				1,
				2,
				3,
				4,
				5,
				7,
				8,
				9
			};

			OneNumberMissingFromOrderedArray.Run(input.ToArray()).Should().Be(6);
		}
	}
}
