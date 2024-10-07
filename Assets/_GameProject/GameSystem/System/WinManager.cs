using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Antopia {
    public class WinManager : MonoBehaviour {
        
        public static WinManager instance { get; private set; }

        [SerializeField] private GameObject m_WinUI;
        [SerializeField] private GameObject m_LossUI;

        [SerializeField] private Button m_WinBackToMainTitle;
        [SerializeField] private Button m_LossBackToMainTitle;
        [SerializeField] private Button m_WinRetry;
        [SerializeField] private Button m_LossRetry;

        public Graph graph { get; set; }

        public bool isGameOver;

        private void Awake() {
            instance = this;

            m_WinBackToMainTitle.onClick.AddListener(() => {
                SceneManager.LoadScene("TitleScene");
                Time.timeScale = 1f;
            });
            m_LossBackToMainTitle.onClick.AddListener(() => {
                SceneManager.LoadScene("TitleScene");
                Time.timeScale = 1f;
            });

            m_WinRetry.onClick.AddListener(() => {
                SceneManager.LoadScene("GameScene");
                Time.timeScale = 1f;
            });

            m_LossRetry.onClick.AddListener(() => {
                SceneManager.LoadScene("GameScene");
                Time.timeScale = 1f;
            });

        }
        public void Win() {
            Time.timeScale = 0;
            isGameOver = true;
            m_WinUI.gameObject.SetActive(true);
        }

        public void Loss() {
            Debug.Log("Loss");
            Time.timeScale = 0;
            isGameOver = true;
            m_LossUI.gameObject.SetActive(true);
        }

        public void CheckWin() {
            if(graph == null) {
                return;
            }

            foreach(var node in graph.nodes) {
                if (node.hasEnemy) {
                    return;
                }

                if (!node.isExplored && !node.isHome) {
                    return;
                }

            }

            Win();
        }
    }
}