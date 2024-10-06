using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace Antopia {
    public class PlayerNodeActionManager : MonoBehaviour {
        public static PlayerNodeActionManager instance { get; private set; }


        [SerializeField] private List<NodeActionSO> m_FrontierNodeActions = new List<NodeActionSO>();
        [SerializeField] private List<NodeActionSO> m_HomeNodeActions = new List<NodeActionSO>();
        [SerializeField] private List<NodeActionSO> m_ExploredNodeActions = new List<NodeActionSO>();

        private void Awake() {
            Assert.IsNull(instance);

            instance = this;
        }

        public List<NodeActionSO> GetActions(Graph graph, GraphNode node) {
            if (node.isHome) {
                return m_HomeNodeActions;
            }

            if (graph.IsFrontier(node)) {
                return m_FrontierNodeActions;
            }

            if (node.isExplored) {
                return m_ExploredNodeActions;
            }

            return new List<NodeActionSO>();
        }
        
    }
}
