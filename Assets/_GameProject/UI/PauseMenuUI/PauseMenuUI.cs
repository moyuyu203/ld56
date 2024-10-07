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
        [SerializeField] private Button m_PauseButton;
        [SerializeField] private GameObject m_Menu;

        private bool m_IsPaused;

        private void Start() {
            m_PauseButton.onClick.AddListener(() => {
                Pause(true);
            });

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
            if (WinManager.instance.isGameOver) {
                return;
            }

            if (Input.GetKeyDown(KeyCode.Space)) {
                if (m_IsPaused) {
                    Unpause();
                } else {
                    Pause(false);
                }
            }

            if (Input.GetKeyDown(KeyCode.Escape)) {
                if (m_IsPaused) {
                    Unpause();
                } else {
                    Pause(true);
                }
            }
        }


        private void Pause(bool isShowMenu) {
            if (WinManager.instance.isGameOver) {
                return;
            }

            Time.timeScale = 0f;
            if (isShowMenu) {
                m_Menu.SetActive(true);
            }

            m_VisualContainer.SetActive(true);
            m_IsPaused = true;  
        }

        private void Unpause() {
            if (WinManager.instance.isGameOver) {
                return;
            }

            Time.timeScale = 1f;
            m_VisualContainer.SetActive(false);
            m_Menu.SetActive(false);
            m_IsPaused = false;
        }


    }
}
