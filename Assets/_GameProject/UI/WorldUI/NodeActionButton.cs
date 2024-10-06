using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Antopia {
    public class NodeActionButton : MonoBehaviour {
        [SerializeField] private Button m_ActionButton;
        [SerializeField] private TextMeshProUGUI m_ButtonText;
        [SerializeField] private GameObject m_ActionGreyOut;


        public void Setup(NodeActionSO actionSO, Graph graph, GraphNode node, Action onComplete) {
            //Debug.Log("Setup Action button");
            if(!actionSO.CanTakeAction(graph, node)) {
                m_ActionGreyOut.SetActive(true);
            }

            m_ButtonText.text = actionSO.actionTitle;
         
            m_ActionButton.onClick.AddListener(() => {
               

                //Debug.Log("On action button click");
                actionSO.PerformAction(graph, node);
                onComplete();
            });

        }
    }
}
