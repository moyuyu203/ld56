using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Antopia {
    public class Movement : MonoBehaviour {
        private float m_MoveSpeed;

        public bool isMoving { get { return m_IsMoving; } }

        private GraphNode m_TargetNode;
        private bool m_IsMoving;
        private AntWorker m_Creature;

        public void MoveTo(GraphNode targetNode, float moveSpeed) {
            m_IsMoving = true;
            m_MoveSpeed = moveSpeed;
            m_TargetNode = targetNode;
        }

        private void Start() {
            m_Creature = GetComponent<AntWorker>();  
        }

        private void Update() {
            if (!m_IsMoving) {
                return;
            }

            float epsilon = 0.1f;
            if(Vector3.Distance(transform.position, m_TargetNode.worldPosition) < epsilon) {
                //Move complete.
                m_IsMoving = false;
                m_Creature.UpdateCurrentNode(m_TargetNode);
                return;
            }
            //Debug.Log(m_TargetNode);

            Vector3 moveDirection = m_TargetNode.worldPosition - transform.position;
            moveDirection = moveDirection.normalized;

            transform.position += moveDirection * m_MoveSpeed * Time.deltaTime;


        }



    }
}