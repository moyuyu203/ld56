using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Antopia {
    public class GraphNodeVisual : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler, IPointerExitHandler {
        [SerializeField] private Image m_Image;
        [SerializeField] private GameObject m_Highlight;

        private GraphNode m_Node;
        private Graph m_Graph;
        public void OnPointerClick(PointerEventData eventData) {
            //Debug.Log("Pointer click");
            //Debug.Log("Is home : " + m_Node.isHome);
            m_Highlight.gameObject.SetActive(false);
            NodeActionUI.instance.ShowNodeAction(m_Graph, m_Node);
            
        }

        public void OnPointerEnter(PointerEventData eventData) {
            //Debug.Log("Pointer enter");
            //Debug.Log("Is home : " + m_Node.isHome);
            m_Highlight.gameObject.SetActive(true);
        }

        public void OnPointerExit(PointerEventData eventData) {
            m_Highlight.gameObject.SetActive(false);
        }

        public void Setup(Graph graph, GraphNode node) {
            transform.position = node.worldPosition;
            m_Node = node;
            m_Graph = graph;

            m_Node.OnExplored += Node_OnExplored;

            if (node.isHome) {
                m_Image.color = Color.red;
                return;
            }

            if (!node.isExplored) {
                m_Image.color = Color.gray;
            }

        }

        private void Node_OnExplored(object sender, System.EventArgs e) {
            m_Image.color = Color.green;
        }
    }
}
