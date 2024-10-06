using UnityEngine;

namespace Antopia {
    [CreateAssetMenu(fileName = "IsFrontier", menuName = "Antopia/NodeAction/Condition/IsFrontier")]
    public class IsFrontier : NodeActionConditionSO {
        public override bool IsSatisfied(Graph graph, GraphNode node) {
            return graph.IsFrontier(node);
        }
    }
}
