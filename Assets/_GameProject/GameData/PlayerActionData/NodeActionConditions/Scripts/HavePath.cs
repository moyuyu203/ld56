using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Antopia {
    [CreateAssetMenu(fileName = "HavePath", menuName = "Antopia/NodeAction/Condition/HavePath")]
    public class HavePath : NodeActionConditionSO {
        public override bool IsSatisfied(Graph graph, GraphNode node, out string errorMsg) {
            List<GraphNode> path = graph.ShortestPath(graph.homeColony, node);

            if(path.Count == 0) {
                errorMsg = "The path is blocked";
                return false;
            } else {
                errorMsg = "";
                return true;
            }
        }
    }
}
