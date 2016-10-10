using System.Text;

namespace CodingInterviewSolutions.Named
{
	public static class InvertPairsInLinkedList
	{
		public class Node
		{
			public int Value { get; set; }
			public Node Next { get; set; }

			public override string ToString()
			{
				StringBuilder sb = new StringBuilder();
				Node current = this;
				while (current != null)
				{
					sb.Append(current.Value + ",");
					current = current.Next;
				}
				return sb.ToString();
			}
		}


		/// <summary>
		/// The first node and the last one are special (in c++ at least) because the first one has to be inverted by reference
		/// </summary>
		public static void Run(ref Node head)
		{
			Node first = head;

			if (head != null && head.Next != null)
			{
				// Invert reference so caller also sees this
				head = head.Next;
			}

			Node previous = null;

			// Cycle through list
			while (first != null && first.Next != null)
			{
				Node second = first.Next;
				if (previous != null)
				{
					previous.Next = second;
				}

				Node temp = second.Next;
				second.Next = first;
				first.Next = temp;

				// Advance
				previous = first;
				first = first.Next;
			}
		}
	}
}
