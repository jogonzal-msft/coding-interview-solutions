using CodingInterviewSolutions.Named;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static CodingInterviewSolutions.Named.DeleteNodeInLinkedListWithReturn;

namespace CodingInterviewSolutionsUnitTests.Named
{
	[TestClass]
	public class DeleteNodeInLinkedListWithReturnUnitTests
	{
		[TestMethod]
		public void NoNodes_Nothing()
		{
			Node node = null;
			node = DeleteNodeInLinkedListWithReturn.Delete(node, 0);
			Assert.IsNull(node);
		}

		[TestMethod]
		public void OnlyOneNode_Deleted()
		{
			Node node = new Node()
			{
				value = 1,
				next = null,
			};
			node = DeleteNodeInLinkedListWithReturn.Delete(node, 1);
			Assert.IsNull(node);
		}

		[TestMethod]
		public void SecondNode_Deleted()
		{
			Node node = new Node()
			{
				value = 1,
				next = new Node()
				{
					value = 2,
					next = null,
				},
			};
			node = DeleteNodeInLinkedListWithReturn.Delete(node, 2);
			Assert.AreEqual(node.value, 1);
			Assert.AreEqual(node.next, null);
		}

		[TestMethod]
		public void FirstNode_Deleted()
		{
			Node node = new Node()
			{
				value = 1,
				next = new Node()
				{
					value = 2,
					next = null,
				},
			};
			node = DeleteNodeInLinkedListWithReturn.Delete(node, 1);
			Assert.AreEqual(node.value, 2);
			Assert.AreEqual(node.next, null);
		}
		[TestMethod]
		public void NodeAtFirstWith3_Deleted()
		{
			Node node = new Node()
			{
				value = 1,
				next = new Node()
				{
					value = 2,
					next = new Node()
					{
						value = 3,
						next = null,
					},
				},
			};
			node = DeleteNodeInLinkedListWithReturn.Delete(node, 1);
			Assert.AreEqual(node.value, 2);
			Assert.AreEqual(node.next.value, 3);
			Assert.AreEqual(node.next.next, null);
		}

		[TestMethod]
		public void NodeMiddleWith3_Deleted()
		{
			Node node = new Node()
			{
				value = 1,
				next = new Node()
				{
					value = 2,
					next = new Node()
					{
						value = 3,
						next = null,
					},
				},
			};
			node = DeleteNodeInLinkedListWithReturn.Delete(node, 2);
			Assert.AreEqual(node.value, 1);
			Assert.AreEqual(node.next.value, 3);
			Assert.AreEqual(node.next.next, null);
		}

		[TestMethod]
		public void NodeEndWith3_Deleted()
		{
			Node node = new Node()
			{
				value = 1,
				next = new Node()
				{
					value = 2,
					next = new Node()
					{
						value = 3,
						next = null,
					},
				},
			};
			node = DeleteNodeInLinkedListWithReturn.Delete(node, 3);
			Assert.AreEqual(node.value, 1);
			Assert.AreEqual(node.next.value, 2);
			Assert.AreEqual(node.next.next, null);
		}

		[TestMethod]
		public void RepeatedNodeWith3_Deleted()
		{
			Node node = new Node()
			{
				value = 1,
				next = new Node()
				{
					value = 1,
					next = new Node()
					{
						value = 1,
						next = null,
					},
				},
			};
			node = DeleteNodeInLinkedListWithReturn.Delete(node, 1);
			Assert.AreEqual(node.value, 1);
			Assert.AreEqual(node.next.value, 1);
			Assert.AreEqual(node.next.next, null);
		}
	}
}
