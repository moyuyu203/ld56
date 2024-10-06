using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Antopia {
    public class HomeColonyUI : MonoBehaviour {
        [SerializeField] private GoHome m_GoHomeEffect;
        [SerializeField] private GameObject m_VisualContainer;
        [SerializeField] private Button m_GoBackButton;


        private void Start() {
            m_GoHomeEffect.OnGoHome += GoHomeEffect_OnGoHome;

            m_GoBackButton.onClick.AddListener(() => {
                Hide();
            });
        }

        private void OnDestroy() {

            m_GoHomeEffect.OnGoHome -= GoHomeEffect_OnGoHome;
        }

        private void GoHomeEffect_OnGoHome(object sender, System.EventArgs e) {
            Show();
        }


        private void Show() {

            m_VisualContainer.SetActive(true);
        }

        private void Hide() {
            m_VisualContainer.SetActive(false);
        }
    }
}
