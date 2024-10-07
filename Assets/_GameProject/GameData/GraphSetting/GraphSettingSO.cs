using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Antopia {
    [CreateAssetMenu(fileName = "new Graph setting", menuName = "Antopia/GraphSetting")]
    public class GraphSettingSO : ScriptableObject {

        public int xGridSize = 10;
        public int yGridSize = 10;

        public float bigGridDistance = 3f;
        public float smallGridDistance = 2f;

        public int minEdgePerNode = 2;
        public int maxEdgePerNode = 5;

        public int hasFoodProbability = 33; // out of 100
        public int minFood = 30;
        public int maxFood = 120;

        public int hasEnemyProbability = 33;
        public List<EnemySO> enemySOs = new List<EnemySO>();    


    }
}
