using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Antopia {
    [CreateAssetMenu(fileName = "New AntColonySetting", menuName = "Antopia/ColonySetting")]
    public class AntColonySettingSO : ScriptableObject {
        public int startingWorkers = 2;
        public int startingFood = 25;
        public int foodReductionTimeInSeconds = 10;

        public int workerFoodComsumption = 1;
        public int baseFoodComsumption = 3;

    }
}
