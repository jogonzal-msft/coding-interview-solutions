namespace CodingInterviewSolutions.Named
{
	public static class DeleteNodeInLinkedList
	{
		public class Node
		{
			public int value;
			public Node next;
		}

		public static void Delete(ref Node root, int value)
		{
			if (root == null)
			{
				return;
			}

			if (root.value == value)
			{
				root = root.next;
				return;
			}

			Delete(ref root.next, value);
		}
	}
}
