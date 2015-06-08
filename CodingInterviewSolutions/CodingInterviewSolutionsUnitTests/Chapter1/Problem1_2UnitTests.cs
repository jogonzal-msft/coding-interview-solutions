using CodingInterviewSolutions.Chapter1;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodingInterviewSolutionsUnitTests.Chapter1
{
	[TestClass]
	public class Problem1_2UnitTests
	{
		[TestMethod]
		public void UniqueLetterWords_AreUnique()
		{
			TestProblem1_2("helo", "oleh");
			TestProblem1_2("My name is jorge", "egroj si eman yM");
		}

		[TestMethod]
		public void Palindromes_Unchanged()
		{
			TestProblem1_2("cowoc", "cowoc");
			TestProblem1_2("tacocat", "tacocat");
		}

		/// <summary>
		/// Test problem 2
		/// </summary>
		private void TestProblem1_2(string input, string expectedResult)
		{
			Problem1_2.ReverseCString(input).Should().Be(expectedResult);
		}
	}
}
