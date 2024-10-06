using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.Assertions;
using UnityEngine;

namespace Antopia {
    public class Graph {
        public HashSet<GraphNode> nodes { get { return new HashSet<GraphNode>(m_Nodes); } }

        public HashSet<GraphEdge> edges { get { return new HashSet<GraphEdge>(m_Edges); } }

        public GraphNode homeColony { get; private set; }

        private HashSet<GraphNode> m_Nodes;
        private HashSet<GraphEdge> m_Edges;

        private Dictionary<GraphNode, HashSet<GraphNode>> m_AdjacencyMap;
        public Graph(HashSet<GraphNode> nodes, HashSet<GraphEdge> edges) {

            m_Nodes = nodes;
            m_Edges = edges;

            m_AdjacencyMap = new Dictionary<GraphNode, HashSet<GraphNode>>();

            foreach(var edge in edges) {
                //Add nodeB to nodeA's adjacency. 
                if (m_AdjacencyMap.Keys.Contains(edge.nodeA)) {
                    m_AdjacencyMap[edge.nodeA].Add(edge.nodeB);
                } else {
                    m_AdjacencyMap[edge.nodeA] = new HashSet<GraphNode>();
                    m_AdjacencyMap[edge.nodeA].Add(edge.nodeB);
                }

                //Add nodeA to nodeB's adjacency.
                if (m_AdjacencyMap.Keys.Contains(edge.nodeB)) {
                    m_AdjacencyMap[edge.nodeB].Add(edge.nodeA);
                } else {
                    m_AdjacencyMap[edge.nodeB] = new HashSet<GraphNode>();
                    m_AdjacencyMap[edge.nodeB].Add(edge.nodeA);
                }


            }

            //Cache home colony
            foreach(var node in nodes) {
                if (node.isHome) {
                    Assert.IsNull(homeColony);//There should be only one home node.
                    homeColony = node;
                }

            }

            Assert.IsNotNull(homeColony);//There should be one and only one home node.
        }

        public bool IsFrontier(GraphNode node) {
            Assert.IsTrue(m_AdjacencyMap.Keys.Contains(node));

            if (node.isExplored) {
                return false;
            }

            foreach(var adjNode in m_AdjacencyMap[node]) {
                if (adjNode.isExplored) {
                    return true;
                }
            }

            return false;
        }

        public HashSet<GraphNode> GetAdjacentNodes(GraphNode node) {
            Assert.IsTrue(m_AdjacencyMap.Keys.Contains(node));

            return m_AdjacencyMap[node];
        }

        public int GetNodeDegree(GraphNode node) {
            Assert.IsTrue(m_AdjacencyMap.Keys.Contains(node));

            return m_AdjacencyMap[node].Count;
        }

        /// <summary>
        /// Finds the shortest path between two nodes using Dijkstra's algorithm.
        /// </summary>
        /// <param name="source">The starting node.</param>
        /// <param name="target">The target node.</param>
        /// <returns>A list of nodes representing the shortest path. Returns an empty list if the target can't be reached.</returns>
        public List<GraphNode> ShortestPath(GraphNode source, GraphNode target) {
            var distances = new Dictionary<GraphNode, float>();
            var previous = new Dictionary<GraphNode, GraphNode>();
            var visited = new HashSet<GraphNode>();
            var priorityQueue = new SimplePriorityQueue<GraphNode>();

            // Initialize distances and priority queue
            foreach (var node in nodes) {
                distances[node] = float.PositiveInfinity;
            }
            distances[source] = 0;
            priorityQueue.Enqueue(source, 0);

            while (priorityQueue.Count > 0) {
                var current = priorityQueue.Dequeue();

                if (current.Equals(target)) {
                    break; // Shortest path to target found
                }

                if (!visited.Add(current)) {
                    continue; // Skip if already visited
                }

                foreach (var neighbor in GetNeighbors(current)) {
                    float weight = Vector3.Distance(current.worldPosition, neighbor.worldPosition);
                    float altDistance = distances[current] + weight;

                    if (altDistance < distances[neighbor]) {
                        distances[neighbor] = altDistance;
                        previous[neighbor] = current;
                        priorityQueue.Enqueue(neighbor, altDistance);
                    }
                }
            }

            // Reconstruct the shortest path
            if (!previous.ContainsKey(target)) {
                return new List<GraphNode>(); // Target not reachable
            }

            var path = new List<GraphNode>();
            var nodeInPath = target;

            while (!nodeInPath.Equals(source)) {
                path.Add(nodeInPath);
                nodeInPath = previous[nodeInPath];
            }
            path.Add(source);
            path.Reverse();

            return path;
        }

        /// <summary>
        /// Retrieves the neighboring nodes connected to the specified node.
        /// </summary>
        /// <param name="node">The node whose neighbors are to be found.</param>
        /// <returns>A list of neighboring nodes.</returns>
        private List<GraphNode> GetNeighbors(GraphNode node) {
            var neighbors = new List<GraphNode>();
            foreach (var edge in m_Edges) {
                if (edge.nodeA.Equals(node)) {
                    neighbors.Add(edge.nodeB);
                } else if (edge.nodeB.Equals(node)) {
                    neighbors.Add(edge.nodeA);
                }
            }
            return neighbors;
        }

    }
}
