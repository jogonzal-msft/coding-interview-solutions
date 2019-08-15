namespace CodingInterviewSolutions.Named
{
	public static class DeleteNodeInLinkedListWithReturn
	{
		public class Node
		{
			public int value;
			public Node next;
		}

		public static Node Delete(Node root, int value)
		{
			if (root == null)
			{
				return null;
			}

			if (root.value == value)
			{
				return root.next;
			}

			Node previous = root;

			while(previous.next != null)
			{
				if (previous.next.value == value)
				{
					// Skip node
					previous.next = previous.next.next;
					return root;
				}
				previous = previous.next;
			}

			return root;
		}
	}
}
