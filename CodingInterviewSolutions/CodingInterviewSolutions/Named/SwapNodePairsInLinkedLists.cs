namespace CodingInterviewSolutions.Named
{
	/// <summary>
	/// Given a pointer to the root, swap the nodes in a linked list. Swap nodes 1 and 2, 3 and 4, ... etc
	/// 
	/// Pitfalls: Not updating root, not making sense of the swaps that need to happen
	/// 
	/// Possible approaches: Recursive, iterative special handle first, dummy node
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

		public static void SwapPairsIterative(ref LinkedListNode root)
		{
			// First iteration is a special case
			if (root?.Next == null)
			{
				// Nothing to swap if root or root next is null
				return;
			}

			LinkedListNode node1 = root;
			LinkedListNode node2 = node1.Next;

			root = node2; // This works because it is a reference!!

			// node1 next needs to point to node2 next
			node1.Next = node2.Next;

			// node2 next needs to point to node1
			node2.Next = node1;

			LinkedListNode beforeRoot = node1;
			while (beforeRoot?.Next?.Next != null)
			{
				node1 = beforeRoot.Next;
				node2 = node1.Next;

				beforeRoot.Next = node2;

				// node1 next needs to point to node2 next
				node1.Next = node2.Next;

				// node2 next needs to point to node1
				node2.Next = node1;

				// Advance to next pair
				beforeRoot = node1;
			}
		}

		public static void SwapPairsIterativeDummyNode(ref LinkedListNode root)
		{
			// Add the dummy node
			var dummyNode = new LinkedListNode(0);
			dummyNode.Next = root;

			// Now, starting at root, knowing that the list starts with a dummy node, swap everything

			LinkedListNode beforeRoot = dummyNode;
			while (beforeRoot?.Next?.Next != null)
			{
				LinkedListNode node1 = beforeRoot.Next;
				LinkedListNode node2 = node1.Next;

				beforeRoot.Next = node2;

				// node1 next needs to point to node2 next
				node1.Next = node2.Next;

				// node2 next needs to point to node1
				node2.Next = node1;

				// Advance to next pair
				beforeRoot = node1;
			}

			// Remove the dummy node and reassign root
			root = dummyNode.Next;
		}
	}
}
