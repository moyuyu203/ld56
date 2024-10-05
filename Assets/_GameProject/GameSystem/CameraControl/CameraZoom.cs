using UnityEngine;

public class CameraZoom : MonoBehaviour {
    public float zoomSpeed = 0.5f;     // Speed of zooming in and out
    public float minZoom = 2f;         // Minimum zoom limit
    public float maxZoom = 10f;        // Maximum zoom limit

    private Camera cam;

    void Start() {
        cam = Camera.main;
    }

    void Update() {
        // Get input from the mouse scroll wheel
        float scrollData = Input.GetAxis("Mouse ScrollWheel");

        // Only proceed if there's scroll input
        if (scrollData != 0.0f) {
            // Calculate the new orthographic size
            float newSize = cam.orthographicSize - scrollData * zoomSpeed;

            // Clamp the new size within the min and max limits
            cam.orthographicSize = Mathf.Clamp(newSize, minZoom, maxZoom);
        }
    }
}