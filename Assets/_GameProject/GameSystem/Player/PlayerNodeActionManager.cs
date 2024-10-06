using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace Antopia {
    public class PlayerNodeActionManager : MonoBehaviour {
        public static PlayerNodeActionManager instance { get; private set; }

        public List<NodeActionSO> actions { get { return m_Actions;  } }

        [SerializeField] private List<NodeActionSO> m_Actions = new List<NodeActionSO>();


        private void Awake() {
            Assert.IsNull(instance);

            instance = this;
        }

        
    }
}
