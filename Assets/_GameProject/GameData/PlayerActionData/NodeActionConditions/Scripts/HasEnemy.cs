using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Antopia {
    [CreateAssetMenu(fileName = "HasEnemy", menuName = "Antopia/NodeAction/Condition/HasEnemy")]
    public class HasEnemy : NodeActionConditionSO {
        public override bool IsSatisfied(Graph graph, GraphNode node, out string errorMsg) {
            if (node.hasEnemy) {
                errorMsg = "";
                return true;
            } else {
                errorMsg = "There is no enemy. ";
                return false;
            }
        }
    }
}