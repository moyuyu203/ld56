using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Antopia {
    public class AddAntButton : MonoBehaviour {
        [SerializeField] private Button m_Button;
        [SerializeField] private AntType m_AntType;
        

        private void Start() {
            m_Button.onClick.AddListener(() => {
                if (AntColony.instance.CanAddAnt(m_AntType)) {
                    AntColony.instance.AddAnt(m_AntType);
                }
            });

        }



    }
}
