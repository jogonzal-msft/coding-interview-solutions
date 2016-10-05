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
		private static DeepestPathInBinaryTree.Tree _sampleTree = new DeepestPathInBinaryTree.Tree()
		{
			Value = 5,
			Left = new DeepestPathInBinaryTree.Tree()
			{
				Value = 2,
				Right = new DeepestPathInBinaryTree.Tree()
				{
					Value = 3,
				},
				Left = new DeepestPathInBinaryTree.Tree()
				{
					Value = 1
				}
			},
			Right = new DeepestPathInBinaryTree.Tree()
			{
				Value = 20,
				Right = new DeepestPathInBinaryTree.Tree()
				{
					Value = 40,
					Left = new DeepestPathInBinaryTree.Tree()
					{
						Value = 30
					},
					Right = new DeepestPathInBinaryTree.Tree()
					{
						Value = 50,
						Left = new DeepestPathInBinaryTree.Tree()
						{
							Value = 100
						},
					}
				},
				Left = new DeepestPathInBinaryTree.Tree()
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
