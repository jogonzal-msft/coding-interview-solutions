using System.Collections.Generic;
using System.Linq;
using CodingInterviewSolutions.Named;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodingInterviewSolutionsUnitTests.Named
{
	[TestClass]
	public class DeepestPathInBinaryTreeUnitTests
	{
		private static DeepestPathInBinaryTree.TreeNode _sampleTree = new DeepestPathInBinaryTree.TreeNode()
		{
			Value = 5,
			Left = new DeepestPathInBinaryTree.TreeNode()
			{
				Value = 2,
				Right = new DeepestPathInBinaryTree.TreeNode()
				{
					Value = 3,
				},
				Left = new DeepestPathInBinaryTree.TreeNode()
				{
					Value = 1
				}
			},
			Right = new DeepestPathInBinaryTree.TreeNode()
			{
				Value = 20,
				Right = new DeepestPathInBinaryTree.TreeNode()
				{
					Value = 40,
					Left = new DeepestPathInBinaryTree.TreeNode()
					{
						Value = 30
					},
					Right = new DeepestPathInBinaryTree.TreeNode()
					{
						Value = 50,
						Left = new DeepestPathInBinaryTree.TreeNode()
						{
							Value = 100
						},
					}
				},
				Left = new DeepestPathInBinaryTree.TreeNode()
				{
					Value = 15
				}
			}
		};

		[TestMethod]
		public void TestMethod1()
		{
			var deepestPath = DeepestPathInBinaryTree.Run(_sampleTree);
			var values = deepestPath.Select(n => n.Value);
			values.Should().BeEquivalentTo(new List<int>() {5, 20, 40, 50, 100});
		}
	}
}
