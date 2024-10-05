using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Antopia {
    public class GraphNodeVisual : MonoBehaviour {
        
        public void Setup(GraphNode node) {
            transform.position = node.worldPosition;
        }


    }
}
