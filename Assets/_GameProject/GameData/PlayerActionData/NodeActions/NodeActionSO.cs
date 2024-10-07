using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace Antopia {
    [CreateAssetMenu(fileName = "New Node Action", menuName = "Antopia/NodeAction/Action")]
    public class NodeActionSO : ScriptableObject {
        public string actionTitle;

        public List<NodeActionConditionSO> conditions;
        public List<NodeActionEffectSO> effects;
        public bool CanTakeAction(Graph graph, GraphNode node, out string errorMsg) {
            foreach (var condition in conditions) {
                if (!condition.IsSatisfied(graph, node, out string conditionMsg)) {
                    errorMsg = conditionMsg;
                    return false;
                }
            }

            errorMsg = "";
            return true;
        }

        public void PerformAction(Graph graph, GraphNode node) {
            Assert.IsTrue(CanTakeAction(graph, node, out string _));

            //Debug.Log("Perform action");

            foreach(var effect in effects) {
                effect.ApplyEffectTo(graph,node);
            }

        }


    }
}