using CodingInterviewSolutions.Small;

using FluentAssertions;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingInterviewSolutionsUnitTests.Small
{
	[TestClass]
	public class SmallProblem2UnitTests
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
			char[] output = SmallProblem2.EncodeSpaces(input);
			output.Should().BeEquivalentTo(expectedOutput);
		}
	}
}
