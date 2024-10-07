using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Antopia {
    public class AntDiedPopUpManager : MonoBehaviour {
        public static AntDiedPopUpManager instance { get; private set; }

        [SerializeField] private GameObject m_AntDiedIndicator;

        private void Awake() {
            instance = this;
        }
        public void AntDied(Vector3 positionWhereAntDied) {
            Instantiate(m_AntDiedIndicator, positionWhereAntDied, Quaternion.identity); 

        }

    }
}
