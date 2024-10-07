using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Antopia {
    public class GraphNodeVisual : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler, IPointerExitHandler {
        [SerializeField] private Image m_Image;
        [SerializeField] private GameObject m_Highlight;
        [SerializeField] private bool m_ShowDebugText;
        [SerializeField] private TextMeshProUGUI m_DebugText;
        [SerializeField] private GameObject m_FoodVisual;

        [SerializeField] private GameObject m_EnemyVisualContainer;
        [SerializeField] private TextMeshProUGUI m_EnemyText;
 

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

            if (m_ShowDebugText) {
                m_DebugText.text = node.id.ToString();
            } else {
                m_DebugText.gameObject.SetActive(false);
            }

            m_Node.OnExplored += Node_OnExplored;
            m_Node.OnFoodUpdate += Node_OnFoodUpdate;
            m_Node.OnEnemyDead += Node_OnEnemyDead;

            if (node.isHome) {
                m_Image.color = Color.red;
                return;
            }

           

            if (!node.isExplored) {
                m_Image.color = Color.gray;
            }

            

        }

        private void Node_OnEnemyDead(object sender, System.EventArgs e) {
            m_EnemyVisualContainer.SetActive(false);
        }

        private void Node_OnFoodUpdate(object sender, System.EventArgs e) {
            if (m_Node.hasFood) {
                m_FoodVisual.SetActive(true);
            } else {
                m_FoodVisual.SetActive(false);
            }
        }

        private void Node_OnExplored(object sender, System.EventArgs e) {
            m_Image.color = Color.green;

            if (m_Node.hasFood) {
                m_FoodVisual.SetActive(true);
            }

            if (m_Node.hasEnemy) {
                m_EnemyVisualContainer.SetActive(true);
                m_EnemyText.text = m_Node.enemy.enemyName;
            }
        }
    }
}
