using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Antopia {
    public class PauseMenuUI : MonoBehaviour {
        [SerializeField] private GameObject m_VisualContainer;
        [SerializeField] private Button m_ContinueButton;
        [SerializeField] private Button m_QuitToMainMenuButton;

        private bool m_IsPaused;

        private void Start() {
            m_QuitToMainMenuButton.onClick.AddListener(() => {
                if (m_IsPaused) {
                    Unpause();
                }

                SceneManager.LoadScene("TitleScene");
            });

            m_ContinueButton.onClick.AddListener(() => {
                Unpause();
            });

        }
        private void Update() {

            if (Input.GetKeyDown(KeyCode.Escape)) {
                if (m_IsPaused) {
                    Unpause();
                } else {
                    Pause();
                }
            }
        }


        private void Pause() {
            Time.timeScale = 0f;
            m_VisualContainer.SetActive(true);
            m_IsPaused = true;  
        }

        private void Unpause() {
            Time.timeScale = 1f;
            m_VisualContainer.SetActive(false);
            m_IsPaused = false;
        }


    }
}
