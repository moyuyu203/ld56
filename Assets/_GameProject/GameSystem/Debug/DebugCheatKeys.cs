using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Antopia {
    public class DebugCheatKeys : MonoBehaviour {

        private void Update() {
            if (Input.GetKeyDown(KeyCode.R)) {
                //Reload scene.
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }
}
