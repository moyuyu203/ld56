using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Antopia {
    [CreateAssetMenu(fileName ="Explore", menuName ="Antopia/NodeAction/Effects/Explore")]
    public class Explore : NodeActionEffectSO {
        public override void ApplyEffectTo(Graph graph, GraphNode node) {
            Debug.Log("Explore");

            var antWorker = AntColony.instance.RequestAntWorker();
            antWorker.MoveTo(node, () => {
                node.MarkAsExplored();
                antWorker.Deactivate();
            });

            
        }
    }
}