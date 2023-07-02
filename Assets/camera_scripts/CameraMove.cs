using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraMove : MonoBehaviour
{
    public float panSpeed;
    public float panBorderThickness;

    private Vector3 resetCamera;

    // Start is called before the first frame update
    private void Start()
    {
        resetCamera = Camera.main.transform.position;
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        // Check if the mouse is over a UI object
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        // WASD Movement
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontal, vertical, 0f).normalized;
        Vector3 panMovement = direction * panSpeed * Time.deltaTime;
        Camera.main.transform.Translate(panMovement, Space.World);

        // Move camera if mouse is pressing against the borders of the view
        Vector3 mousePosition = Input.mousePosition;
        float screenWidth = Screen.width;
        float screenHeight = Screen.height;

        if (mousePosition.x < panBorderThickness)
        {
            Camera.main.transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
        }
        else if (mousePosition.x > screenWidth - panBorderThickness)
        {
            Camera.main.transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
        }

        if (mousePosition.y < panBorderThickness)
        {
            Camera.main.transform.Translate(Vector3.down * panSpeed * Time.deltaTime, Space.World);
        }
        else if (mousePosition.y > screenHeight - panBorderThickness)
        {
            Camera.main.transform.Translate(Vector3.up * panSpeed * Time.deltaTime, Space.World);
        }

        // Reset camera position
        if (Input.GetMouseButton(1))
        {
            Camera.main.transform.position = resetCamera;
        }
    }
}







