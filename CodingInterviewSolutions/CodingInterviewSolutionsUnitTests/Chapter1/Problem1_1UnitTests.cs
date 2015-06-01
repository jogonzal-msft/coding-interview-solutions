using CodingInterviewSolutions.Chapter1;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodingInterviewSolutionsUnitTests.Chapter1
{
	[TestClass]
	public class Problem1_1UnitTests
	{
		[TestMethod]
		public void UniqueLetterWords_AreUnique()
		{
			TestProblem1_1("helo", true);
			TestProblem1_1("mynaeisro", true);
			TestProblem1_1("thisdoen rp", true);
			TestProblem1_1("asdfghjkl;", true);
			TestProblem1_1(" ", true);
			TestProblem1_1("", true);
		}

		[TestMethod]
		public void WordsWithRepeatedLetters_AreUnique()
		{
			TestProblem1_1("helle", false);
			TestProblem1_1("doggy", false);
			TestProblem1_1("this repeats a bunch of letters", false);
			TestProblem1_1("two space ;", false);
		}

		/// <summary>
		/// Test both implementations of problem 1
		/// </summary>
		private void TestProblem1_1(string input, bool expectedResult)
		{
			Problem1_1.HasOnlyUniqueCharacters(input).Should().Be(expectedResult);
			Problem1_1.HasOnlyUniqueCharactersWithoutDataStructure(input).Should().Be(expectedResult);
		}
	}
}
