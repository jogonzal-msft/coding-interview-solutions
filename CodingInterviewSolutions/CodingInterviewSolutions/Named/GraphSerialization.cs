using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace CodingInterviewSolutions.Named
{
	/// <summary>
	/// Problem description: Given a graph formed by nodes described by the class "Node" below, we want to serialize it.
	/// You have access to a JSON serializer (e.g. JSON.stringify for JS or JSON.NET for C#) that can serialize DAGs (Directed Acyclic Graph), however, it didn't work for all graphs in your test cases.
	/// (Candidate should ask/suggest these are possible problems) Problem 1: The graph contains cycles (node1 -> node2 -> node1 -> node2) and (optional) Problem 2: a node can have multiple parents (e.g. node1 can be a child of node2 and of node3)
	/// Hint1: For a graph that contains cycles, when you used your JSON serializer that works on DAGs, it threw an error "Converting circular structure to JSON"
	/// Hint2: For a graph that contains nodes with multiple parents, you noticed the serializer worked, but it serialized the same node multiple times. In a case where a node was the child of all other N nodes in the graph, it serialized that node N times.
	/// Solution 1 (implemented here): A. Add ids to all nodes B. Whenever you see a node that you've already seen in the graph, serialize only its id
	/// Solution 2: Add ids to all nodes. Serialize the connections of the nodes as an array with only their id's (e.g. [node1 -> node2, node1 -> node3, ...])
	///             and serialize all unique nodes in a linear list.
	/// Bonus: Build a deserializer for the results of your serializers
	/// </summary>
	public static class GraphSerialization
	{
		public class Node
		{
			public Dictionary<string, string> Properties { get; set; }
			public List<Node> Connections { get; set; }
		}

		/// <summary>
		/// There are a couple things we need to watch out for here:
		/// 1. We'll generate a new node for serialization - we'll add to that node only if the node was
		///    never seen before (keep a HashSet of seen nodes)
		/// 2. If the node was seen before, we'll only serialize it's id.
		///    If not, then serialize it fully (with children and properties)
		/// </summary>
		public static string SerializeGraph(Node rootNode)
		{
			Dictionary<Node, Guid> visitedNodes = new Dictionary<Node, Guid>();

			SerializableNode serializableRootNode = GetSerializableNode(rootNode, visitedNodes);

			return JsonConvert.SerializeObject(serializableRootNode);
		}

		private static SerializableNode GetSerializableNode(Node node, Dictionary<Node, Guid> visitedNodes)
		{
			Guid id;
			if (visitedNodes.TryGetValue(node, out id))
			{
				// Node has been previously serialized - just serialize it's ID
				return new SerializableNode(){
					Id = id
				};
			} else {
				// Add to visited
				id = Guid.NewGuid();
				visitedNodes.Add(node, id);

				// Get children
				List<SerializableNode> connections = null;
				if (node.Connections != null && node.Connections.Count > 0){
					connections = node.Connections.Select(n => GetSerializableNode(n, visitedNodes)).ToList();
				}

				// Return node with id, properties and connections
				return new SerializableNode(){
					Id = id,
					Properties = node.Properties,
					Connections = node.Connections
				};
			}
		}

		/// <summary>
		/// Used to append an id to every single node
		/// </summary>
		private class SerializableNode : Node
		{
			public Guid Id { get; set; }
		}
	}
}
