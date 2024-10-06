using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Antopia {
    [CreateAssetMenu(fileName = "GatherFood", menuName = "Antopia/NodeAction/Effects/GatherFood")]
    public class GatherFood : NodeActionEffectSO {
        public override void ApplyEffectTo(Graph graph, GraphNode node) {
            Debug.Log("Explore");

            var antWorker = AntColony.instance.RequestAntWorker();

            antWorker.MoveTo(graph, node, () => {
                antWorker.GatherFood(node, () => {
                    antWorker.MoveBackAndDeactivate(graph);
                });

            });
        }
    }
}
