using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Antopia {
    public class GameLoader : MonoBehaviour {
        [SerializeField] private GraphRenderer m_GraphRenderer;
        [SerializeField] private RandomGraphGenerator m_RandomGenerator;

        private void Start() {
           Graph graph = m_RandomGenerator.MakeGraph();

            m_GraphRenderer.RenderGraph(graph);
        }


    }
}