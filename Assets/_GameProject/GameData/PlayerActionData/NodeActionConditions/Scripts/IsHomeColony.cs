using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Antopia {
    [CreateAssetMenu(fileName = "IsHome", menuName = "Antopia/NodeAction/Condition/IsHome")]
    public class IsHomeColony : NodeActionConditionSO {
        public bool isNotHome;
        public override bool IsSatisfied(Graph graph, GraphNode node, out string errorMsg) {
            if (isNotHome) {

                if (node.isHome) {
                    errorMsg = "Can't not be home node";
                    return false;
                } else {
                    errorMsg = "";
                    return true;
                }

            }

            if (node.isHome) {
                errorMsg = "";
                return true;
            } else {
                errorMsg = "It needs to be a home node.";
                return false;
            }
        }
    }
}
