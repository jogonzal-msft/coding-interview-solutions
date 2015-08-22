using CodingInterviewSolutions.Chapter1;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodingInterviewSolutionsUnitTests.Chapter1
{
	[TestClass]
	public class Problem1_3UnitTests
	{
		[TestMethod]
		public void Test1()
		{
			Problem1_3.RemoveDuplicateCharacters("doggie")
				.Should().Be("dogie");
	
			Problem1_3.RemoveDuplicateCharacters("my name is")
				.Should().Be("my naeis");

			Problem1_3.RemoveDuplicateCharacters("Superman")
				.Should().Be("Superman");
		}
	}
}
