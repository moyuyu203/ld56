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
            GraphNode dummy1 = new GraphNode(2, new Vector3(2,-3,0));
            nodes.Add(dummy1);

            //Add some dummy nodes.
            GraphNode dummy2 = new GraphNode(3, new Vector3(4, 2, 0));
            nodes.Add(dummy2);

            //Add some dummy nodes.
            GraphNode dummy3 = new GraphNode(4, new Vector3(-4, 2, 0));
            nodes.Add(dummy3);



            //Add dummy edges.
            // Create and return the graph
            edges.Add(new GraphEdge(nodes[0], nodes[1]));
            edges.Add(new GraphEdge(nodes[0], nodes[2]));
            edges.Add(new GraphEdge(nodes[1], nodes[2]));
            edges.Add(new GraphEdge(nodes[0], nodes[3]));

            return new Graph(nodes, edges);
        }


        
       
    }
}
