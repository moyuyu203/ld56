using UnityEngine;

public class CameraDrag : MonoBehaviour {
    private Vector3 dragOrigin;
    private bool isDragging = false;

    void Update() {
        // Start dragging when left mouse button is pressed
        if (Input.GetMouseButtonDown(1)) {
            dragOrigin = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            isDragging = true;
        }

        // Stop dragging when left mouse button is released
        if (Input.GetMouseButtonUp(1)) {
            isDragging = false;
        }

        

        // Move the camera while dragging
        if (isDragging) {
            Vector3 difference = dragOrigin - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            difference.z = 0; // Keep the camera on the same Z plane

            Camera.main.transform.position += difference;
        }
    }
}