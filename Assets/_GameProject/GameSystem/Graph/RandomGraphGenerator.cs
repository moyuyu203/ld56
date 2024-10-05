using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Antopia {
    public class RandomGraphGenerator : MonoBehaviour{
        [SerializeField] private GraphSettingSO m_GraphSetting;

        public Graph MakeGraph() {
            List<GraphNode> nodes = new List<GraphNode>();
            List<GraphEdge> edges = new List<GraphEdge>();

            //Make home node.
            GraphNode homeNode = new GraphNode(1, Vector3.zero);
            nodes.Add(homeNode);

            //Add some dummy nodes.
            GraphNode dummy1 = new GraphNode(2, Vector3.one * 3);
            nodes.Add(homeNode);

            //Add dummy edges.
            // Create and return the graph
            return new Graph(nodes, edges);
        }


        
       
    }
}
