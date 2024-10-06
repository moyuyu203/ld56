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

        private bool m_IsShowing;
        private void Awake() {
            Assert.IsNull(instance);

            instance = this;
        }

        public void ShowNodeAction(Graph graph, GraphNode node) {
            //Camera.main.transform.position = new Vector3(node.worldPosition.x, node.worldPosition.y, Camera.main.transform.position.z);
            m_IsShowing = true;

            m_VisualContainer.SetActive(true);
            m_BackGround.SetActive(true);

            foreach (Transform child in m_VisualContainer.transform) {
              
                Destroy(child.gameObject);
            }

            int positionIndex = 0;
            float actionButtonPositionOffset = 120f * (Screen.height / 1080f);
            foreach(var action in PlayerNodeActionManager.instance.GetActions(graph, node)) {
                NodeActionButton actionButton = Instantiate(m_NodeActionButton, m_VisualContainer.transform);
                actionButton.gameObject.SetActive(true);

                actionButton.transform.position += (new Vector3(0, 1, 0)) * positionIndex * actionButtonPositionOffset;
                actionButton.Setup(action, graph, node, () => {
                    Hide();
                });

                positionIndex++;
            }


        }

        public void Hide() {
            m_IsShowing = false;

            m_VisualContainer.SetActive(false);
            m_BackGround.SetActive(false);
        }

        private void Update() {
            if(m_IsShowing && Input.GetMouseButton(1)) {
                Hide();
            }
        }
    }
}
