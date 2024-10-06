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



    }
}
