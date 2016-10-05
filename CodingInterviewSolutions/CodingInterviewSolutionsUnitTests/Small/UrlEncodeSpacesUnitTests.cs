using CodingInterviewSolutions.Small;

using FluentAssertions;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodingInterviewSolutionsUnitTests.Small
{
	[TestClass]
	public class UrlEncodeSpacesUnitTests
	{
		[TestMethod]
		public void SmallProblem2Tests()
		{
			TestSmallProblem2(
				new char[] { 'h', 'o', 'l', 'a' },
				new char[] { 'h', 'o', 'l', 'a' });

			TestSmallProblem2(
				new char[] { 'h', 'o', ' ', 'a' },
				new char[] { 'h', 'o', '%', '2', '0', 'a' });

			TestSmallProblem2(
				new char[] { ' ' },
				new char[] { '%', '2', '0' });

			TestSmallProblem2(
				new char[] { 'h', 'o', ' ', 'a', ' ' },
				new char[] { 'h', 'o', '%', '2', '0', 'a', '%', '2', '0' });

		}

		private static void TestSmallProblem2(char[] input, char[] expectedOutput)
		{
			char[] output = UrlEncodeSpaces.EncodeSpaces(input);
			output.Should().BeEquivalentTo(expectedOutput);
		}
	}
}
