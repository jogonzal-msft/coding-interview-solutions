using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodingInterviewSolutions.Personal;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodingInterviewSolutionsUnitTests.Personal
{
	[TestClass]
	public class PersonalProblem2_UnitTests
	{
		private static PersonalProblem2.Tree _sampleTree = new PersonalProblem2.Tree()
		{
			Value = 5,
			Left = new PersonalProblem2.Tree()
			{
				Value = 2,
				Right = new PersonalProblem2.Tree()
				{
					Value = 3,
				},
				Left = new PersonalProblem2.Tree()
				{
					Value = 1
				}
			},
			Right = new PersonalProblem2.Tree()
			{
				Value = 20,
				Right = new PersonalProblem2.Tree()
				{
					Value = 40,
					Left = new PersonalProblem2.Tree()
					{
						Value = 30
					},
					Right = new PersonalProblem2.Tree()
					{
						Value = 50
					}
				},
				Left = new PersonalProblem2.Tree()
				{
					Value = 15
				}
			}
		};

		[TestMethod]
		public void Null_Null()
		{
			PersonalProblem2.Tree tree = null;
			PersonalProblem2.LowestCommonAncestor(tree, 1, 2).Should().BeNull();
		}

		[TestMethod]
		public void SampleTree_2()
		{
			PersonalProblem2.LowestCommonAncestor(_sampleTree, 3, 1).Value.Should().Be(2);
		}

		[TestMethod]
		public void SampleTree_LEafElements()
		{
			PersonalProblem2.LowestCommonAncestor(_sampleTree, 30, 50).Value.Should().Be(40);
		}

		[TestMethod]
		public void SampleTree_AllTree()
		{
			PersonalProblem2.LowestCommonAncestor(_sampleTree, 50, 1).Value.Should().Be(5);
		}

		[TestMethod]
		public void SampleTree_ElementDoesNotExist()
		{
			PersonalProblem2.LowestCommonAncestor(_sampleTree, 0, 1).Should().BeNull();
		}
	}
}
