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

		public static void SwapPairs(ref LinkedListNode root)
		{
			if (root?.Next == null)
			{
				// Nothing to swap
				return;
			}


		}
	}
}
