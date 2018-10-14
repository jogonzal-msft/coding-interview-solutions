using System.Collections.Generic;

using CodingInterviewSolutions.Named;

using FluentAssertions;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodingInterviewSolutionsUnitTests.Named
{
	[TestClass]
	class SwapNodePairsInLinkedListUnitTests
	{
		[TestMethod]
		public void TestHelperMethods()
		{
			// Back and forth conversion
			var list = new List<int>() { 1, 2, 3, 4, 5, 6, 7 };
			var converted = ConvertLinkedListToList(ConvertListToLinkedList(list));

			converted.Should().BeEquivalentTo(list);
		}

		[TestMethod]
		public void Test1Node()
		{
			
		}

		private List<int> ConvertLinkedListToList(SwapNodePairsInLinkedList.LinkedListNode node)
		{
			List<int> list = new List<int>();

			while(node != null)
			{
				list.Add(node.Value);
				node = node.Next;
			}

			return list;
		}

		private SwapNodePairsInLinkedList.LinkedListNode ConvertListToLinkedList(List<int> list)
		{
			SwapNodePairsInLinkedList.LinkedListNode root = null;
			SwapNodePairsInLinkedList.LinkedListNode current = null;
			foreach (var value in list)
			{
				var newNode = new SwapNodePairsInLinkedList.LinkedListNode(value);

				if (root == null)
				{
					root = newNode;
					current = root;
					continue;
				}

				current.Next = new SwapNodePairsInLinkedList.LinkedListNode(value);
				current = current.Next;
			}

			return root;
		}
	}

}
