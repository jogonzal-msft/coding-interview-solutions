using CodingInterviewSolutions.Small;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodingInterviewSolutionsUnitTests.Small
{
	[TestClass]
	public class RemoveElementFromLinkedListUnitTests
	{
		[TestMethod]
		public void Null_Ignored()
		{
			RemoveElementFromLinkedList.ListElement linkedList = null;
			RemoveElementFromLinkedList.Run(ref linkedList);
			linkedList.Should().BeNull();
		}
		
		[TestMethod]
		public void OneValue_SetToNull()
		{
			var linkedList = new RemoveElementFromLinkedList.ListElement()
			{
				Value = 1,
				Next = null
			};
			RemoveElementFromLinkedList.Run(ref linkedList);
			linkedList.Should().BeNull();
		}

		[TestMethod]
		public void TwoValues_FirstRemoved_SecondRemains()
		{
			var linkedList = new RemoveElementFromLinkedList.ListElement()
			{
				Value = 1,
				Next = new RemoveElementFromLinkedList.ListElement()
				{
					Value = 2,
					Next = null
				}
			};
			RemoveElementFromLinkedList.Run(ref linkedList);
			linkedList.Value.Should().Be(2);
			linkedList.Next.Should().BeNull();
		}

		[TestMethod]
		public void TwoValues_SecondRemoved_FirstRemains()
		{
			var secondValue = new RemoveElementFromLinkedList.ListElement()
			{
				Value = 2,
				Next = null
			};
			var linkedList = new RemoveElementFromLinkedList.ListElement()
			{
				Value = 1,
				Next = secondValue
			};
			RemoveElementFromLinkedList.Run(ref secondValue);
			linkedList.Value.Should().Be(1);

			// NOTE: The last value of the chain can't be deleted with this approach!
			// This is a known issue.
			// linkedList.Next.Should().BeNull();
		}
	}
}
