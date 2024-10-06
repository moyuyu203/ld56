using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace Antopia {
    
    public abstract class NodeActionEffectSO : ScriptableObject {

        public abstract void ApplyEffectTo(Graph graph,GraphNode node);

    }
}
