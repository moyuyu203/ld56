using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Antopia {
    public class Graph {
        public HashSet<GraphNode> nodes { get { return new HashSet<GraphNode>(m_IdToNodeMap.Values); } }

        public HashSet<GraphEdge> edges { get { return new HashSet<GraphEdge>(m_Edges); } }

        private Dictionary<int, GraphNode> m_IdToNodeMap;

        private List<GraphEdge> m_Edges;

        public Graph(List<GraphNode> nodes, List<GraphEdge> edges) {
            m_IdToNodeMap = new Dictionary<int, GraphNode>();
            m_Edges = new List<GraphEdge>(edges);


            foreach (var node in nodes) {
                m_IdToNodeMap[node.id] = node;
            }
        }

    }
}
