using System;
using System.Collections.Generic;

namespace Antopia {
    public struct GraphEdge : IEquatable<GraphEdge> {

        public GraphNode nodeA;
        public GraphNode nodeB;

        public HashSet<GraphNode> nodes {

            get {
                return new HashSet<GraphNode> { nodeA, nodeB };
            }
        }

        public GraphEdge(GraphNode nodeA, GraphNode nodeB) {
            this.nodeA = nodeA;
            this.nodeB = nodeB;
        }

        public override bool Equals(object obj) {
            return obj is GraphEdge otherEdge &&
                    otherEdge.nodes.IsSubsetOf(nodes);

        }

        public bool Equals(GraphEdge other) {
            return this == other;
        }


        public static bool operator ==(GraphEdge edgeA, GraphEdge edgeB){
            return edgeA.nodes.IsSubsetOf(edgeB.nodes);

        }

        public static bool operator !=(GraphEdge edgeA, GraphEdge edgeB) {
            return !(edgeA == edgeB);
        }

        public override int GetHashCode() {
            return HashCode.Combine(nodes);
        }
    }
}