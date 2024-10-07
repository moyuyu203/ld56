using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Antopia {
    public class InfoTag : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {
        [SerializeField] private GameObject m_InfoObject;

        public void OnPointerEnter(PointerEventData eventData) {
            m_InfoObject.SetActive(true);
        }

        public void OnPointerExit(PointerEventData eventData) {
            m_InfoObject.SetActive(false);
        }
    }
}
