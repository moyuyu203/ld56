using UnityEngine;

namespace Antopia {
    public class GraphRenderer : MonoBehaviour {
        [SerializeField] private GraphNodeVisual m_GraphNodeVisualPrefab;
        [SerializeField] private GraphEdgeVisual m_GraphEdgeVisualPrefab;

        public void RenderGraph(Graph graph) {

            foreach(var node in graph.nodes) {
                GraphNodeVisual nodeVisual = Instantiate(m_GraphNodeVisualPrefab, transform);

                nodeVisual.Setup(graph, node);

            }

            foreach(var edge in graph.edges) {
                GraphEdgeVisual edgeVisual = Instantiate(m_GraphEdgeVisualPrefab, transform);

                edgeVisual.Setup(edge);
            }

        }
    }
}
