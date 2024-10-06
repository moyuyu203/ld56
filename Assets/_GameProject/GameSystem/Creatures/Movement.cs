using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Antopia {
    public class Movement : MonoBehaviour {
        [SerializeField] private float m_MoveSpeed;

        private Action m_OnComplete;
        private GraphNode m_TargetNode;
        private bool m_IsMoving;

        public void MoveTo(GraphNode targetNode, Action onComplete) {
            m_IsMoving = true;
            m_OnComplete = onComplete;
            m_TargetNode = targetNode;
        }


        private void Update() {
            if (!m_IsMoving) {
                return;
            }

            float epsilon = 0.1f;
            if(Vector3.Distance(transform.position, m_TargetNode.worldPosition) < epsilon) {
                //Move complete.
                m_IsMoving = false;
                m_OnComplete();
                return;
            }

            Vector3 moveDirection = m_TargetNode.worldPosition - transform.position;
            moveDirection = moveDirection.normalized;

            transform.position += moveDirection * m_MoveSpeed * Time.deltaTime;


        }



    }
}