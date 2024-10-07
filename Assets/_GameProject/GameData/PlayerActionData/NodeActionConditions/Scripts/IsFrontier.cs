using UnityEngine;

namespace Antopia {
    [CreateAssetMenu(fileName = "IsFrontier", menuName = "Antopia/NodeAction/Condition/IsFrontier")]
    public class IsFrontier : NodeActionConditionSO {
        public bool isInvert;
        public override bool IsSatisfied(Graph graph, GraphNode node, out string errorMsg) {
            if (isInvert) {
                if (graph.IsFrontier(node)) {
                    errorMsg = "It's Frontier";
                    return false;
                } else {
                    errorMsg = "_";
                    return true;

                }
                
            }

            if (graph.IsFrontier(node)) {
                errorMsg = "_";
                return true;
            } else {
                errorMsg = "You must first explore the frontier before exploring this node.";
                return false;
            }

        }
    }
}
