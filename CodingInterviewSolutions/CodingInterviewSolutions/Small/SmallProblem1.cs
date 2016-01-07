using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingInterviewSolutions.Small
{
	/// <summary>
	/// Given a reference to an item in a linked list, remove it
	/// </summary>
	public class SmallProblem1
	{
		/// <summary>
		/// A linked list
		/// </summary>
		public class ListElement
		{
			public ListElement Next { get; set; }

			public int Value { get; set; }
		}

		public static void RemoveElementFromLinkedList(ref ListElement elementToRemove)
		{
			// The classical way of approaching this problem is to simply disconnect the previous node from this element
			// The problem here is that this MIGHT be the first element, or the last
			// We don't really have access to the last element's pointer, so we can't modify it
			// the best approach is to copy the next element's value over and point NEXT to NEXT's NEXT
			if (elementToRemove == null)
			{
				// Nothing to do here!
				return;
			}

			if (elementToRemove.Next == null)
			{
				// This is the only element from the list - assume we have the root of the list and simply point to null
				elementToRemove = null;
				// NOTE: There are additional coniderations in native code that apply
				// if this is the root node (e.g. need double pointer) but do not apply
				// in managed code
				// Note: This doesn't work if this is the last element
				return;
			}

			// Copy next's value
			elementToRemove.Value = elementToRemove.Next.Value;
			// Set this element's value to next's next
			elementToRemove.Next = elementToRemove.Next.Next;
		}
	}
}
