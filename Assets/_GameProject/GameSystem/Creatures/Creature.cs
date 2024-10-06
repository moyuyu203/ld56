using System.Collections.Generic;
using UnityEngine;
using System;

namespace Antopia {
    public class Creature : MonoBehaviour {
        private enum InternalState {
            Deactivated,
            Moving,
            Idle
        }

        [SerializeField] private GameObject m_Visual;
        
        private InternalState m_State = InternalState.Deactivated;

        public bool isBusy { get { return !(m_State == InternalState.Deactivated); } }

        private List<GraphNode> m_Path = new List<GraphNode>();

        private GraphNode m_CurrentNode;
        private Action m_OnActionComplete;
       

        private Movement m_Movement;


        private void Awake() {
            m_Movement = GetComponent<Movement>();
        }
        public void Setup(GraphNode currentNode) {
            m_CurrentNode = currentNode;
        }

        public void Activate() {
            m_Visual.SetActive(true);
            m_State = InternalState.Idle;
            
            transform.position = m_CurrentNode.worldPosition;
        }


        public void Deactivate() {
            m_Visual.SetActive(false);
            
            m_State = InternalState.Deactivated;
        }
        public void MoveTo(Graph graph, GraphNode targetNode, Action onComplete) {
            m_Path = graph.ShortestPath(m_CurrentNode, targetNode);
            Debug.Log(m_Path.Count);
            //Debug.Log(m_Path);

            m_Path.RemoveAt(0);
            foreach(var node in m_Path) {
                Debug.Log(node);
            }

            m_State = InternalState.Moving;

            m_OnActionComplete = onComplete;

        }

        public void UpdateCurrentNode(GraphNode node) {
            m_CurrentNode = node;

        }

        public void MoveBackAndDeactivate(Graph graph) {
            Debug.Log("Move back and activate");
            MoveTo(graph, graph.homeColony, () => {
                Deactivate();
            });
        }



        private void Update() {
            if(m_State == InternalState.Moving) {
                if (m_Movement.isMoving) {
                    return;
                }
                //Start a new movement or finish the movement.
                if(m_Path.Count == 0) {
                    //Finish movement.
                    
                    m_State = InternalState.Idle;
                    m_OnActionComplete();
                    return;
                }

                //Move to next node.
                GraphNode nextNode = m_Path[0];
                m_Path.RemoveAt(0);
                Debug.Log(m_CurrentNode);
                Debug.Log(nextNode);
                m_Movement.MoveTo(nextNode);

            }
        }


    }
}
