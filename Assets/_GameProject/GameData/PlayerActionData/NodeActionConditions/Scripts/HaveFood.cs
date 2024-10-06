using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Antopia {
    [CreateAssetMenu(fileName = "HaveFood", menuName = "Antopia/NodeAction/Condition/HaveFood")]
    public class HaveFood : NodeActionConditionSO {
        public override bool IsSatisfied(Graph graph, GraphNode node) {
            return node.hasFood;
        }
    }
}
