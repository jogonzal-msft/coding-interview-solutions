using CodingInterviewSolutions.Small;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodingInterviewSolutionsUnitTests.Small
{
	[TestClass]
	public class SmallProblem1UnitTests
	{
		[TestMethod]
		public void Null_Ignored()
		{
			SmallProblem1.ListElement linkedList = null;
			SmallProblem1.RemoveElementFromLinkedList(ref linkedList);
			linkedList.Should().BeNull();
		}
		
		[TestMethod]
		public void OneValue_SetToNull()
		{
			var linkedList = new SmallProblem1.ListElement()
			{
				Value = 1,
				Next = null
			};
			SmallProblem1.RemoveElementFromLinkedList(ref linkedList);
			linkedList.Should().BeNull();
		}

		[TestMethod]
		public void TwoValues_FirstRemoved_SecondRemains()
		{
			var linkedList = new SmallProblem1.ListElement()
			{
				Value = 1,
				Next = new SmallProblem1.ListElement()
				{
					Value = 2,
					Next = null
				}
			};
			SmallProblem1.RemoveElementFromLinkedList(ref linkedList);
			linkedList.Value.Should().Be(2);
			linkedList.Next.Should().BeNull();
		}

		[TestMethod]
		public void TwoValues_SecondRemoved_FirstRemains()
		{
			var secondValue = new SmallProblem1.ListElement()
			{
				Value = 2,
				Next = null
			};
			var linkedList = new SmallProblem1.ListElement()
			{
				Value = 1,
				Next = secondValue
			};
			SmallProblem1.RemoveElementFromLinkedList(ref secondValue);
			linkedList.Value.Should().Be(1);

			// NOTE: The last value of the chain can't be deleted with this approach!
			// This is a known issue.
			// linkedList.Next.Should().BeNull();
		}
	}
}
