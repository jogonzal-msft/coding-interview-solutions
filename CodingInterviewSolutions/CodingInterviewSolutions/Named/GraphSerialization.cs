using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace CodingInterviewSolutions.Named
{
	/// <summary>
	/// This problem consists on serializing and deserializing a graph object given below
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
