using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Antopia {
    public class GraphEdgeVisual : MonoBehaviour {
        [SerializeField] private LineRenderer m_LineRenderer;


        public void Setup(GraphEdge edge) {
            //Set line position.
            m_LineRenderer.positionCount = 2;
            
           
            m_LineRenderer.SetPosition(0, edge.nodeA.worldPosition);
            m_LineRenderer.SetPosition(1, edge.nodeB.worldPosition);

            //Set width
            float width = 0.1f;
            m_LineRenderer.startWidth = width;
            m_LineRenderer.endWidth = width;

            //Set material and color.
            m_LineRenderer.material = new Material(Shader.Find("Sprites/Default"));
            m_LineRenderer.startColor = Color.white;
            m_LineRenderer.endColor = Color.white;


        }

    }
}
