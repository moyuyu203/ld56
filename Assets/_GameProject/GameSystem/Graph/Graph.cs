using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.Assertions;

namespace Antopia {
    public class Graph {
        public HashSet<GraphNode> nodes { get { return new HashSet<GraphNode>(m_Nodes); } }

        public HashSet<GraphEdge> edges { get { return new HashSet<GraphEdge>(m_Edges); } }


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
        }

        public HashSet<GraphNode> GetAdjacentNodes(GraphNode node) {
            Assert.IsTrue(m_AdjacencyMap.Keys.Contains(node));

            return m_AdjacencyMap[node];
        }

        public int GetNodeDegree(GraphNode node) {
            Assert.IsTrue(m_AdjacencyMap.Keys.Contains(node));

            return m_AdjacencyMap[node].Count;
        }

    }
}
