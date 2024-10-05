using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Antopia {
    [CreateAssetMenu(fileName = "new Graph setting", menuName = "Antopia/GraphSetting")]
    public class GraphSettingSO : ScriptableObject {

        public int numberOfNodes;
        public int minNumberOfEdges;
        public int maxNumberOfEdges;
        public float minEdgeDistance;
        public float maxEdgeDistance;
    }
}
