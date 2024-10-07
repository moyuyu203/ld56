using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Antopia {
    public abstract class NodeActionConditionSO : ScriptableObject {
        public abstract bool IsSatisfied(Graph graph, GraphNode node, out string errorMsg);
    }
}
