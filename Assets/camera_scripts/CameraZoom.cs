using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    public float zoomChange;
    public float smoothChange;
    public float minSize, maxSize;
    private Camera cam;
    // Start is called before the first frame update
    private void Start() {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    private void LateUpdate() {
        if(Input.mouseScrollDelta.y > 0) {
            cam.orthographicSize -= zoomChange * Time.deltaTime * smoothChange;
        }
        if(Input.mouseScrollDelta.y < 0) {
            cam.orthographicSize += zoomChange * Time.deltaTime * smoothChange;
        }
        cam.orthographicSize = Mathf.Clamp(cam.orthographicSize, minSize, maxSize);
         
    }

}
