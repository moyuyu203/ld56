using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Antopia {
    public class GameLoader : MonoBehaviour {
        [SerializeField] private GraphRenderer m_GraphRenderer;
        [SerializeField] private RandomGraphGenerator m_RandomGenerator;
        [SerializeField] private AntColony m_AntColony;
        private void Start() {
            Graph graph = m_RandomGenerator.MakeGraph();

            WinManager.instance.graph = graph;

            

            m_AntColony.graph = graph;

            m_GraphRenderer.RenderGraph(graph);
        }


    }
}