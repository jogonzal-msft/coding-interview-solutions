using System;
using System.Collections.Generic;
using CodingInterviewSolutions.Named;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodingInterviewSolutionsUnitTests.Named
{
	[TestClass]
	public class MinimumLengthSubstringTests
	{
		[TestMethod]
		public void TestMinimumLengthSubstring_1()
		{
			string s = "dcbefebce";
			string t = "fd";

			string expectedOutput = "dcbef";

			var output = MinimumLengthSubstringsV2.MinLengthSubstring(s, t);
			output.Should().Be(expectedOutput);
		}

		[TestMethod]
		public void TestMinimumLengthSubstring_2()
		{
			string s = "dcbefebcefdalksjdlaksjd";
			string t = "fd";

			string expectedOutput = "fd";

			var output = MinimumLengthSubstringsV2.MinLengthSubstring(s, t);
			output.Should().Be(expectedOutput);
		}

		[TestMethod]
		public void TestMinimumLengthSubstring_3()
		{
			string s = "aabcba";
			string t = "ab";

			string expectedOutput = "ab";

			var output = MinimumLengthSubstringsV2.MinLengthSubstring(s, t);
			output.Should().Be(expectedOutput);
		}

		[TestMethod]
		public void TestMinimumLengthSubstring_4()
		{
			string s = "ADOBECODEBANC";
			string t = "BANC";

			string expectedOutput = "BANC";

			var output = MinimumLengthSubstringsV2.MinLengthSubstring(s, t);
			output.Should().Be(expectedOutput);
		}
	}
}
