using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingInterviewSolutions.Named
{
	public class CelebrityProblem
	{
		public class Node
		{
			public Node(string name)
			{
				this.Name = name;
				this.Knows = new List<Node>();
			}

			public string Name { get; set; }
			public List<Node> Knows { get; set; }
		}

		public static Node FindCelebrity(List<Node> nodes)
		{
			// A celebrity is a person who knows everyone, but doesn't know anyone
			// 1. Find 1 node that doesn't know anyone
			var lonelyPeople = nodes.Where(n => n.Knows == null || n.Knows.Count == 0).ToList();

			// If there's more than 1 or 0, then no celebrity
			if (lonelyPeople.Count != 1)
			{
				return null;
			}

			Node potentialCelebrity = lonelyPeople[0];
			// Now need to go through all nodes and validate they all know the potential celebrity
			foreach (var node in nodes)
			{
				if (node == potentialCelebrity)
				{
					continue; // No need to validate anything for celebrity
				}

				if (!node.Knows.Contains(potentialCelebrity))
				{
					return null; // There isn't a celebrity
				}
			}

			return potentialCelebrity;
		}
	}
}
