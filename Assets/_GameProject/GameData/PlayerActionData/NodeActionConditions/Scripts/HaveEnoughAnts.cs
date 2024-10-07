using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Antopia {
    public enum AntType {
        Worker,
        Soldier,
        Queen
    }

    [CreateAssetMenu(fileName = "HaveEnoughAnts", menuName = "Antopia/NodeAction/Condition/HaveEnoughAnts")]
    public class HaveEnoughAnts : NodeActionConditionSO {
        public AntType antType;
        public int numberRequired;
        
        public override bool IsSatisfied(Graph graph, GraphNode node, out string errorMsg) {
            switch (antType) {
                case AntType.Worker:
                    if(AntColony.instance.numberOfAntWorkersAvailable >= numberRequired) {
                        errorMsg = "";
                        return true;
                    } else {
                        errorMsg = "Not enough workers";
                        return false;
                    }

                case AntType.Soldier:
                    if (AntColony.instance.numberOfAntSoldiersAvailable >= numberRequired) {
                        errorMsg = "";
                        return true;
                    } else {
                        errorMsg = "Not enough soldiers";
                        return false;
                    }

            }

            errorMsg = "";
            return false;
        }
    }
}
