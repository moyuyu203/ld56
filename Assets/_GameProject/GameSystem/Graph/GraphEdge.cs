using System;
using System.Collections.Generic;

namespace Antopia {
    public struct GraphEdge : IEquatable<GraphEdge> {
        public GraphNode nodeA { get; private set; }
        public GraphNode nodeB { get; private set; }

        public GraphEdge(GraphNode nodeA, GraphNode nodeB) {
            this.nodeA = nodeA;
            this.nodeB = nodeB;
        }
        public override bool Equals(object obj) {
            return obj is GraphEdge otherEdge &&
                nodeA == otherEdge.nodeA &&
                nodeB == otherEdge.nodeB;

        }

        public bool Equals(GraphEdge other) {
            return this == other;
        }


        public static bool operator ==(GraphEdge edgeA, GraphEdge edgeB){
            return  edgeA.nodeA == edgeB.nodeA && edgeA.nodeB == edgeB.nodeB;

        }

        public static bool operator !=(GraphEdge edgeA, GraphEdge edgeB) {
            return !(edgeA == edgeB);
        }

        public override int GetHashCode() {
            return HashCode.Combine(nodeA, nodeB);
        }

        public override string ToString() {
            return "(${nodeA}, ${nodeB})";
        }
    }
}