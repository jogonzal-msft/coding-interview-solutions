using System;
using System.Collections.Generic;

namespace CodingInterviewSolutions.Named
{
	public static class DeepestPathInBinaryTree
	{
		/// <summary>
		/// Binary tree implementation
		/// </summary>
		internal class Tree
		{
			internal Tree Left { get; set; }
			internal Tree Right { get; set; }
			internal int Value { get; set; }
		}

		internal static List<Tree> Run(Tree root)
		{
			// Questions to ask here
			// 1. Is the tree ordered?
			// If it is, there is a simple O(2 * log(n)) solution
			// 2. If not, then this is the solution that is O(n)

			if (root == null)
			{
				throw new ArgumentException("Root should not be null");
			}

			List<Tree> currentPath = new List<Tree>();
			List<Tree> deepestPath = new List<Tree>();

			FindDeepestPath(root, currentPath, ref deepestPath);

			return deepestPath;
		}

		private static void FindDeepestPath(Tree currentNode, List<Tree> currentPath, ref List<Tree> deepestPath)
		{
			// Calculate current path
			currentPath = new List<Tree>(currentPath) {currentNode};

			// Go left and right (if possible)
			if (currentNode.Left != null)
			{
				FindDeepestPath(currentNode.Left, currentPath, ref deepestPath);
			}
			if (currentNode.Right != null)
			{
				FindDeepestPath(currentNode.Right, currentPath, ref deepestPath);
			}

			// Only if it's a leaf node, compare against deepest path
			if (currentNode.Left == null && currentNode.Right == null
				&& currentPath.Count > deepestPath.Count)
			{
				deepestPath = currentPath;
			}
		}
	}
}
