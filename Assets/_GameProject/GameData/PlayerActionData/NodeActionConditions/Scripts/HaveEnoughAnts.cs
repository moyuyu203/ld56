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
        
        public override bool IsSatisfied(Graph graph, GraphNode node) {
            switch (antType) {
                case AntType.Worker:
                    if(AntColony.instance.numberOfAntWorkersAvailable >= numberRequired) {
                        return true;
                    } else {
                        return false;
                    }

            }


            return false;
        }
    }
}
