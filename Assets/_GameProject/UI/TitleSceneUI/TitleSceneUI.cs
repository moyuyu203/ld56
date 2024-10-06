using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Antopia {
    public class TitleSceneUI : MonoBehaviour {
        [SerializeField] private Button m_StartGameButton;
        [SerializeField] private Button m_QuitGameButton;


        private void Awake() {
            m_StartGameButton.onClick.AddListener(() => {
                SceneManager.LoadScene("GameScene");
            });

            m_QuitGameButton.onClick.AddListener(() => {
                Application.Quit();
            });
        }
    }
}