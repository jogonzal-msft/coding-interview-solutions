using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodingInterviewSolutions.Named;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodingInterviewSolutionsUnitTests.Named
{
	[TestClass]
	class I18NUnitTests
	{
		[TestMethod]
		public void Test3Chars()
		{
			const string input = "abc";
			List<string> expectedOutput = new List<string>()
			{
				"abc",
				"ab1",
				"a1c",
				"a11",
				"1bc",
				"1b1",
				"11c",
				"111",
			};
			var sol1 = I18NCountingSolution.GenerateAllPossibleAbbreviationsInternal(input);
			var sol2 = I18NRecursiveSolution.GenerateAllPossibleAbbreviationsInternal(input);
			expectedOutput.ShouldBeEquivalentTo(sol1);
			expectedOutput.ShouldBeEquivalentTo(sol2);
		}
	}

}
