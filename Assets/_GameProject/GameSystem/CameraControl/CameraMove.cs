using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Antopia {
    public class CameraMove : MonoBehaviour {
        [SerializeField] private float m_MoveSpeed;

        [SerializeField] private float m_LeftBound = -5;
        [SerializeField] private float m_RightBound = 5;
        [SerializeField] private float m_UpBound = 5;
        [SerializeField] private float m_BottomBound = -5;
        private void Update() {
            if (Input.GetKey(KeyCode.W)) {
                if (transform.position.y < m_UpBound) {
                    transform.position += Vector3.up * m_MoveSpeed * Time.deltaTime;
                }
            }
            if (Input.GetKey(KeyCode.A)) {
                if(transform.position.x > m_LeftBound)
                transform.position += Vector3.left * m_MoveSpeed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.D)) {
                if(transform.position.x < m_RightBound)
                transform.position += Vector3.right * m_MoveSpeed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.S)) {
                if(transform.position.y > m_BottomBound)
                transform.position += Vector3.down * m_MoveSpeed * Time.deltaTime;
            }


            
        }
    }
}
