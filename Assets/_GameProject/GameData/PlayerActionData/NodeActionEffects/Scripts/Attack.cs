using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Antopia {
    [CreateAssetMenu(fileName = "Attack", menuName = "Antopia/NodeAction/Effects/Attack")]
    public class Attack : NodeActionEffectSO {
        public override void ApplyEffectTo(Graph graph, GraphNode node) {
            Debug.Log("Attack");

            var soldier = AntColony.instance.RequestAntSoldier();
            soldier.MoveTo(graph, node, () => {
                if (!node.hasEnemy) {
                    soldier.MoveBackAndDeactivate(graph);
                    return;
                }

                Debug.Log("Should Attacking");

                soldier.AttackAt(node, () => {

                    soldier.MoveBackAndDeactivate(graph);
                });

            });


        }
    }
}
