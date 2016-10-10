using CodingInterviewSolutions.Named;

using FluentAssertions;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodingInterviewSolutionsUnitTests.Named
{
	[TestClass]
	public class InvertPairsInLinkedListUnitTests
	{
		[TestMethod]
		public void ListWith4Elements()
		{
			var input = new InvertPairsInLinkedList.Node()
			{
				Value = 1,
				Next = new InvertPairsInLinkedList.Node()
				{
					Value = 2,
					Next = new InvertPairsInLinkedList.Node()
					{
						Value = 3,
						Next = new InvertPairsInLinkedList.Node()
						{
							Value = 4
						}
					}
				}
			};

			input.ToString().Should().Be("1,2,3,4,");

			InvertPairsInLinkedList.Run(ref input);

			input.ToString().Should().Be("2,1,4,3,");
		}

		[TestMethod]
		public void ListWith1Element()
		{
			var input = new InvertPairsInLinkedList.Node()
			{
				Value = 1
			};

			input.ToString().Should().Be("1,");

			InvertPairsInLinkedList.Run(ref input);

			input.ToString().Should().Be("1,");
		}

		[TestMethod]
		public void ListWith2Elements()
		{
			var input = new InvertPairsInLinkedList.Node()
			{
				Value = 1,
				Next = new InvertPairsInLinkedList.Node()
				{
					Value = 2
				}
			};

			input.ToString().Should().Be("1,2,");

			InvertPairsInLinkedList.Run(ref input);

			input.ToString().Should().Be("2,1,");
		}

		[TestMethod]
		public void EmptyList()
		{
			InvertPairsInLinkedList.Node input = null;

			InvertPairsInLinkedList.Run(ref input);

			input.Should().BeNull();
		}

		[TestMethod]
		public void ListWith5Elements()
		{
			var input = new InvertPairsInLinkedList.Node()
			{
				Value = 1,
				Next = new InvertPairsInLinkedList.Node()
				{
					Value = 2,
					Next = new InvertPairsInLinkedList.Node()
					{
						Value = 3,
						Next = new InvertPairsInLinkedList.Node()
						{
							Value = 4,
							Next = new InvertPairsInLinkedList.Node()
							{
								Value = 5
							}
						}
					}
				}
			};

			input.ToString().Should().Be("1,2,3,4,5,");

			InvertPairsInLinkedList.Run(ref input);

			input.ToString().Should().Be("2,1,4,3,5,");
		}
	}
}
