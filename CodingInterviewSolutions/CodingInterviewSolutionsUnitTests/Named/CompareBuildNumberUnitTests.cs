using CodingInterviewSolutions.Named;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodingInterviewSolutionsUnitTests.Named
{
	[TestClass]
	public class CompareBuildNumberUnitTests
	{
		[TestMethod]
		public void TestEqual_3Digits()
		{
			Assert.AreEqual(CompareBuildNumbers.Compare("1.1.1", "1.1.1"), 0);
		}

		[TestMethod]
		public void TestEqual_2Digits()
		{
			Assert.AreEqual(CompareBuildNumbers.Compare("1.9", "1.9"), 0);
		}

		[TestMethod]
		public void TestGreater_DifferentDigits()
		{
			Assert.AreEqual(CompareBuildNumbers.Compare("1.1.1", "1.1"), 1);
		}

		[TestMethod]
		public void TestSmaller_DifferentDigits()
		{
			Assert.AreEqual(CompareBuildNumbers.Compare("1.1", "1.1.1"), -1);
		}

		[TestMethod]
		public void TestSmaller_SameDigits()
		{
			Assert.AreEqual(CompareBuildNumbers.Compare("1.1.0", "1.1.1"), -1);
		}

		[TestMethod]
		public void TestBigger_SameDigits()
		{
			Assert.AreEqual(CompareBuildNumbers.Compare("1.1.1", "1.1.0"), 1);
		}

		[TestMethod]
		public void TestInvalid_SameDigits()
		{
			Assert.AreEqual(CompareBuildNumbers.Compare("1.HELLO.0", "1.HELLOV2.0"), 0);
		}

		[TestMethod]
		public void TestInvalid_SameDigitsThirdPosition()
		{
			Assert.AreEqual(CompareBuildNumbers.Compare("1.1.HELLOV@", "1.1.102983ASKDFAS"), 0);
		}
	}
}
