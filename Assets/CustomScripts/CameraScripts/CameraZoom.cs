using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraZoom : MonoBehaviour
{
    public float zoomChange;
    public float smoothChange;
    public float minSize, maxSize;
    public float maxAngle = 30f;
    private Camera cam;

    private Quaternion initialRotation;
    private bool shouldChangeAngle = false;

    // Start is called before the first frame update
    private void Start() {
        cam = GetComponent<Camera>();
        initialRotation = cam.transform.rotation;
    }

    // Update is called once per frame
    private void LateUpdate() {

        Vector3 currentPosition = cam.transform.position;

        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }


        if (Input.mouseScrollDelta.y > 0) {
            cam.orthographicSize -= zoomChange * Time.deltaTime * smoothChange;
        }
        if(Input.mouseScrollDelta.y < 0) {
            cam.orthographicSize += zoomChange * Time.deltaTime * smoothChange;
        }
        cam.orthographicSize = Mathf.Clamp(cam.orthographicSize, minSize, maxSize);

        // Calculate the target rotation based on the zoom level
        float zoomPercentage = Mathf.InverseLerp(maxSize, minSize, cam.orthographicSize);

        if (zoomPercentage > 0.8f)
        {
            shouldChangeAngle = true;
        }

        // Calculate the target rotation based on the zoom level
        float targetAngle = shouldChangeAngle ? Mathf.Lerp(0f, maxAngle, Mathf.InverseLerp(0.9f, 1f, zoomPercentage)) : 0f;


        // Apply the rotation to the camera
        Quaternion targetRotation = initialRotation * Quaternion.Euler(-targetAngle, 0f, 0f);
        cam.transform.rotation = Quaternion.Lerp(cam.transform.rotation, targetRotation, smoothChange * Time.deltaTime);
        cam.transform.position = currentPosition;
    }

}
