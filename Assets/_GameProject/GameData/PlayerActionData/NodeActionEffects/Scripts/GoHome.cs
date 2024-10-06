using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Antopia {
    [CreateAssetMenu(fileName = "GoHomeEffect", menuName = "Antopia/NodeAction/Effects/GoHome")]
    public class GoHome : NodeActionEffectSO {
        public event EventHandler OnGoHome;
        public override void ApplyEffectTo(Graph graph, GraphNode node) {
            Debug.Log("Go Home");
            OnGoHome?.Invoke(this, EventArgs.Empty);
        }
    }
}
