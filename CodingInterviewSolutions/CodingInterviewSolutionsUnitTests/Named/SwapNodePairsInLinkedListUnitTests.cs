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

			converted.ShouldBeEquivalentTo(list, options => options.WithStrictOrdering());
		}

		[TestMethod]
		public void Test1Node()
		{
			var input = new List<int>() { 1 };
			var expectedOutput = new List<int>() { 1 };

			TestBothSolutions(input, expectedOutput);
		}

		[TestMethod]
		public void Test2Nodes()
		{
			var input = new List<int>() { 1, 2 };
			var expectedOutput = new List<int>() { 2, 1 };

			TestBothSolutions(input, expectedOutput);
		}

		[TestMethod]
		public void Test3Nodes()
		{
			var input = new List<int>() { 1, 2, 3 };
			var expectedOutput = new List<int>() { 2, 1, 3 };

			TestBothSolutions(input, expectedOutput);
		}

		[TestMethod]
		public void Test4Nodes()
		{
			var input = new List<int>() { 1, 2, 3, 4 };
			var expectedOutput = new List<int>() { 2, 1, 4, 3 };

			TestBothSolutions(input, expectedOutput);
		}

		[TestMethod]
		public void Test5Nodes()
		{
			var input = new List<int>() { 1, 2, 3, 4, 5 };
			var expectedOutput = new List<int>() { 2, 1, 4, 3, 5 };

			TestBothSolutions(input, expectedOutput);
		}

		[TestMethod]
		public void Test8Nodes()
		{
			var input = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8 };
			var expectedOutput = new List<int>() { 2, 1, 4, 3, 6, 5, 8, 7 };

			TestBothSolutions(input, expectedOutput);
		}

		private void TestBothSolutions(List<int> input, List<int> expectedOutput)
		{
			TestRecursiveSolution(input, expectedOutput);
			TestIterativeSolution(input, expectedOutput);
		}

		private void TestRecursiveSolution(List<int> input, List<int> expectedOutput)
		{
			var actualNodeList = ConvertListToLinkedList(input);
			SwapNodePairsInLinkedList.SwapPairsRecursive(ref actualNodeList);

			var converted = ConvertLinkedListToList(actualNodeList);
			converted.ShouldBeEquivalentTo(expectedOutput, options => options.WithStrictOrdering());
		}

		private void TestIterativeSolution(List<int> input, List<int> expectedOutput)
		{
			var actualNodeList = ConvertListToLinkedList(input);
			SwapNodePairsInLinkedList.SwapPairsIterative(ref actualNodeList);

			var converted = ConvertLinkedListToList(actualNodeList);
			converted.ShouldBeEquivalentTo(expectedOutput, options => options.WithStrictOrdering());
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
