
using System;
using UnityEngine;

namespace Antopia {
    public class GraphNode : IEquatable<GraphNode> {
        public event EventHandler OnExplored; 

        public int id { get; private set; }

        public Vector3 worldPosition { get; private set; }

        public bool isHome { get; private set; }

        public bool isExplored { get; private set; }
     
        public GraphNode(int id, Vector3 worldPosition, bool isHome) {
            this.id = id;
            this.worldPosition = worldPosition;
            this.isHome = isHome;

            if (isHome) {
                MarkAsExplored();
            }

        }

        public void MarkAsExplored() {
            isExplored = true;

            OnExplored?.Invoke(this, EventArgs.Empty);
        }

        public override bool Equals(object obj) {
            return obj is GraphNode otherNode &&
                        id == otherNode.id;
        }
        public bool Equals(GraphNode other) {
            return id == other.id;
        }

        public static bool operator ==(GraphNode nodeA, GraphNode nodeB) {
            return nodeA.id == nodeB.id;
        }

        public static bool operator !=(GraphNode nodeA, GraphNode nodeB) {
            return !(nodeA == nodeB);
        }

        public override int GetHashCode() {
            return HashCode.Combine(id);
        }

        public override string ToString() {
            return id.ToString();
        }

    }
}
