using System.Collections.Generic;
using UnityEngine;
using System;

namespace Antopia {
    public class Creature : MonoBehaviour {
        [SerializeField] private GameObject m_Visual;
        
        public bool isBusy { get { return m_IsActivated; } }

        private List<GraphNode> m_Path = new List<GraphNode>();

        private GraphNode m_CurrentNode;

        private bool m_IsActivated;
        private Movement m_Movement;

        private void Awake() {
            m_Movement = GetComponent<Movement>();
        }
        public void Setup(GraphNode currentNode) {
            m_CurrentNode = currentNode;
        }

        public void Activate() {
            m_Visual.SetActive(true);
            m_IsActivated = true;

            transform.position = m_CurrentNode.worldPosition;
        }


        public void Deactivate() {
            m_Visual.SetActive(false);
            m_IsActivated = false;
        }
        public void MoveTo(GraphNode targetNode, Action onComplete) {
            if (!m_IsActivated) {
                return;
            }

            m_Movement.MoveTo(targetNode, () => {
                onComplete();
            });
        }



    }
}
