using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Antopia {
    [CreateAssetMenu(fileName = "IsHome", menuName = "Antopia/NodeAction/Condition/IsHome")]
    public class IsHomeColony : NodeActionConditionSO {
        public bool isNotHome;
        public override bool IsSatisfied(Graph graph, GraphNode node) {
            if (isNotHome) {
                return !node.isHome;
            }
            return node.isHome;
        }
    }
}
