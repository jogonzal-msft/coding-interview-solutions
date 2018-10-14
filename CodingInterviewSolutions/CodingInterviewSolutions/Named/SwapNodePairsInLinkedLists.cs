namespace CodingInterviewSolutions.Named
{
	/// <summary>
	/// Given a pointer to the root
	/// 
	/// Pitfalls: Not updating root, not making sense of the swaps that need to happen
	/// </summary>
	public class SwapNodePairsInLinkedList
	{
		public class LinkedListNode
		{
			public int Value;
			public LinkedListNode Next;

			public LinkedListNode(int value)
			{
				Value = value;
			}
		}

		public static void SwapPairsRecursive(ref LinkedListNode root)
		{
			if (root?.Next == null)
			{
				// Nothing to swap if root or root next is null
				return;
			}

			LinkedListNode node1 = root;
			LinkedListNode node2 = node1.Next;

			// root needs to point to node2
			root = node2; // This works because it is a reference!!

			// node1 next needs to point to node2 next
			node1.Next = node2.Next;

			// node2 next needs to point to node1
			node2.Next = node1;

			SwapPairsRecursive(ref node1.Next);
		}
	}
}
