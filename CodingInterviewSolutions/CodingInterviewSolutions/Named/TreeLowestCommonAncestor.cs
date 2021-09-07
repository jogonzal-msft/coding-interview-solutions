using System;

namespace CodingInterviewSolutions.Named
{
	/// <summary>
	/// Find the lowest common ancestor in a binary tree
	/// </summary>
	public static class TreeLowestCommonAncestor
	{
		/// <summary>
		/// Binary tree implementation
		/// </summary>
		public class Tree
		{
			public Tree Left { get; set; }
			public Tree Right { get; set; }
			public int Value { get; set; }
		}

		public static Tree LowestCommonAncestor(Tree root , int value1, int value2)
		{
			int smallValue = Math.Min(value1, value2);
			int bigValue = Math.Max(value1, value2);

			return LowestCommonAncestorPrivate(root, smallValue, bigValue);
		}

		private static Tree LowestCommonAncestorPrivate(Tree root, int smallValue, int bigValue)
		{
			if (root == null)
			{
				return null;
			}

			if (root.Value < smallValue && root.Value < bigValue)
			{
				// Both are going right
				return LowestCommonAncestorPrivate(root.Right, smallValue, bigValue);
			}
			else if (root.Value > smallValue && root.Value > bigValue)
			{
				// Both are going left
				return LowestCommonAncestorPrivate(root.Left, smallValue, bigValue);
			}
			else
			{
				// This is the intersection!
				if (ContainsValue(root, smallValue) && ContainsValue(root, bigValue))
				{
					return root;
				}
				else
				{
					return null;
				}
			}
		}

		private static bool ContainsValue(Tree root, int value)
		{
			if (root == null)
			{
				return false;
			}

			if (root.Value == value)
			{
				return true;
			}
			else if (value > root.Value)
			{
				return ContainsValue(root.Right, value);
			}
			else
			{
				return ContainsValue(root.Left, value);
			}
		}
	}
}
