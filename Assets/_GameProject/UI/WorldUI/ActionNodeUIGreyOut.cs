using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Antopia {
    public class ActionNodeUIGreyOut : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {
        [SerializeField] private GameObject m_ErrorMsg;

        public void OnPointerEnter(PointerEventData eventData) {
            m_ErrorMsg.SetActive(true);
        }

        public void OnPointerExit(PointerEventData eventData) {
            m_ErrorMsg.SetActive(false);
        }
    }
}