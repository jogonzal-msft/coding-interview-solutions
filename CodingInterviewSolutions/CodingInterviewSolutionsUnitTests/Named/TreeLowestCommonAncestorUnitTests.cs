using CodingInterviewSolutions.Named;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodingInterviewSolutionsUnitTests.Named
{
	[TestClass]
	public class TreeLowestCommonAncestorUnitTests
	{
		private static TreeLowestCommonAncestor.Tree _sampleTree = new TreeLowestCommonAncestor.Tree()
		{
			Value = 5,
			Left = new TreeLowestCommonAncestor.Tree()
			{
				Value = 2,
				Right = new TreeLowestCommonAncestor.Tree()
				{
					Value = 3,
				},
				Left = new TreeLowestCommonAncestor.Tree()
				{
					Value = 1
				}
			},
			Right = new TreeLowestCommonAncestor.Tree()
			{
				Value = 20,
				Right = new TreeLowestCommonAncestor.Tree()
				{
					Value = 40,
					Left = new TreeLowestCommonAncestor.Tree()
					{
						Value = 30
					},
					Right = new TreeLowestCommonAncestor.Tree()
					{
						Value = 50
					}
				},
				Left = new TreeLowestCommonAncestor.Tree()
				{
					Value = 15
				}
			}
		};

		[TestMethod]
		public void Null_Null()
		{
			TreeLowestCommonAncestor.Tree tree = null;
			TreeLowestCommonAncestor.LowestCommonAncestor(tree, 1, 2).Should().BeNull();
		}

		[TestMethod]
		public void SampleTree_2()
		{
			TreeLowestCommonAncestor.LowestCommonAncestor(_sampleTree, 3, 1).Value.Should().Be(2);
		}

		[TestMethod]
		public void SampleTree_LEafElements()
		{
			TreeLowestCommonAncestor.LowestCommonAncestor(_sampleTree, 30, 50).Value.Should().Be(40);
		}

		[TestMethod]
		public void SampleTree_AllTree()
		{
			TreeLowestCommonAncestor.LowestCommonAncestor(_sampleTree, 50, 1).Value.Should().Be(5);
		}

		[TestMethod]
		public void SampleTree_ElementDoesNotExist()
		{
			TreeLowestCommonAncestor.LowestCommonAncestor(_sampleTree, 0, 1).Should().BeNull();
		}
	}
}
