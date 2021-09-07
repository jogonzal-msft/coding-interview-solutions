using System;
using System.Collections.Generic;

namespace CodingInterviewSolutions.Named
{
	public static class DeepestPathInBinaryTree
	{
		/// <summary>
		/// Binary tree implementation
		/// </summary>
		public class TreeNode
		{
			public TreeNode Left { get; set; }
			public TreeNode Right { get; set; }
			public int Value { get; set; }
		}

		public static List<TreeNode> Run(TreeNode root)
		{
			// Questions to ask here
			// 1. Is the tree ordered?
			// If it is, there is a simple O(2 * log(n)) solution
			// 2. If not, then this is the solution that is O(n) and stores a lot of data... and a solution that doesn't store a lot of data. That is the solution that is implemented below.

			if (root == null)
			{
				throw new ArgumentException("Root should not be null");
			}

			Dictionary<TreeNode, int> deepestPathDictionary = new Dictionary<TreeNode, int>();
			int maxDepth = AnnotateDepths(root, 0, deepestPathDictionary);

			List<TreeNode> deepestPath = new List<TreeNode>();
			WalkMaxDepthPath(root, maxDepth, deepestPath, deepestPathDictionary);
			return deepestPath;
		}

		private static void WalkMaxDepthPath(TreeNode currentNode, int maxDepth, List<TreeNode> deepestPath, Dictionary<TreeNode, int> deepestPathDictionary)
		{
			deepestPath.Add(currentNode);

			if (currentNode.Left != null && deepestPathDictionary[currentNode.Left] == maxDepth)
			{
				WalkMaxDepthPath(currentNode.Left, maxDepth, deepestPath, deepestPathDictionary);
			}
			else if (currentNode.Right != null && deepestPathDictionary[currentNode.Right] == maxDepth)
			{
				WalkMaxDepthPath(currentNode.Right, maxDepth, deepestPath, deepestPathDictionary);
			}
		}

		/// <summary>
		/// Annotate the TreeNodes by 
		/// </summary>
		private static int AnnotateDepths(TreeNode currentNode, int currentDepth, Dictionary<TreeNode, int> deepestPathDictionary)
		{
			// Go left and right (if possible)
			int maxDepthLeft = -1, maxDepthRight = -1;
			if (currentNode.Left != null)
			{
				maxDepthLeft = AnnotateDepths(currentNode.Left, currentDepth + 1, deepestPathDictionary);
			}
			if (currentNode.Right != null)
			{
				maxDepthRight = AnnotateDepths(currentNode.Right, currentDepth + 1, deepestPathDictionary);
			}

			int maxDepthSeenByThisPath = Math.Max(currentDepth, Math.Max(maxDepthLeft, maxDepthRight));

			deepestPathDictionary[currentNode] = maxDepthSeenByThisPath;
			return maxDepthSeenByThisPath;
		}
	}
}
