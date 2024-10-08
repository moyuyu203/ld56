using UnityEngine;

namespace Antopia {
    [CreateAssetMenu(fileName ="Explore", menuName ="Antopia/NodeAction/Effects/Explore")]
    public class Explore : NodeActionEffectSO {
        public override void ApplyEffectTo(Graph graph, GraphNode node) {
            Debug.Log("Explore");

            var antWorker = AntColony.instance.RequestAntWorker();
            antWorker.MoveTo(graph, node, () => {
                if (node.hasEnemy) {
                    if (!node.TryExplore()) {
                        AntColony.instance.AntDie(antWorker);
                        return;
                    }
                }

                node.MarkAsExplored();
                antWorker.MoveBackAndDeactivate(graph);
            });

            
        }
    }
}