using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace Antopia {
    public class NodeActionUI : MonoBehaviour {
        public static NodeActionUI instance { get; private set; }

        [SerializeField] private GameObject m_VisualContainer;
        [SerializeField] private GameObject m_BackGround;
        [SerializeField] private NodeActionButton m_NodeActionButton;

        private void Awake() {
            Assert.IsNull(instance);

            instance = this;
        }

        public void ShowNodeAction(Graph graph, GraphNode node) {
            //Camera.main.transform.position = new Vector3(node.worldPosition.x, node.worldPosition.y, Camera.main.transform.position.z);

            m_VisualContainer.SetActive(true);
            m_BackGround.SetActive(true);

            foreach (Transform child in m_VisualContainer.transform) {
                if (child == m_NodeActionButton) continue;

                Destroy(child.gameObject);
            }

            foreach(var action in PlayerNodeActionManager.instance.actions) {
                NodeActionButton actionButton = Instantiate(m_NodeActionButton, m_VisualContainer.transform);
                actionButton.gameObject.SetActive(true);

                actionButton.Setup(action, graph, node, () => {
                    Hide();
                });
            }


        }

        public void Hide() {
            m_VisualContainer.SetActive(false);
            m_BackGround.SetActive(false);
        }
    }
}
