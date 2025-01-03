using System.Collections;
using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    private static GameObject selectedObject = null;
    public bool isMovable; // Set this in the Inspector to determine if the object can be moved
    public float movementSpeed = 5f; // Speed of the movement animation
    private GameObject destinationMarkerPrefab; // Assign a prefab for the green circle in the Inspector

    private LineRenderer lineRenderer;
    private Coroutine currentMovementCoroutine;
    private bool isMovementCancelled;
    private GameObject currentDestinationMarker; // Reference to the current destination marker

    public Quaternion originalRotation;

    void Start()
    {

        originalRotation = this.transform.rotation;

        // Initialize LineRenderer
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.enabled = false;
        lineRenderer.widthMultiplier = 0.1f;
        lineRenderer.numCapVertices = 10; // Rounded ends for the line

        destinationMarkerPrefab = Resources.Load<GameObject>("Torus");
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Left mouse button
        {
            HandleLeftClick();
        }

        if (Input.GetMouseButtonDown(1)) // Right mouse button
        {
            HandleRightClick();
        }
    }

    private void HandleLeftClick()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            var clickedObject = hit.collider.gameObject;

            if (selectedObject == null)
            {
                if (clickedObject.GetComponent<ObjectMovement>()?.isMovable == true)
                {
                    selectedObject = clickedObject;
                    Debug.Log("Selected: " + selectedObject.name);
                }
            }
        }
        else
        {
            selectedObject = null;
        }
    }

    private void HandleRightClick()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            var clickedObject = hit.collider.gameObject;

            if (selectedObject != null && clickedObject != selectedObject)
            {
                if (currentMovementCoroutine != null)
                {
                    isMovementCancelled = true;
                    StopCoroutine(currentMovementCoroutine); // Cancel the current movement
                }

                Vector3 targetPosition = clickedObject.transform.position;

                // Draw the destination marker
                DrawDestinationMarker(targetPosition);

                DrawPath(selectedObject.transform.position, targetPosition);
                isMovementCancelled = false; // Reset cancel flag for new movement
                currentMovementCoroutine = StartCoroutine(MoveObject(selectedObject, targetPosition));
            }
        }
    }

    private IEnumerator MoveObject(GameObject obj, Vector3 targetPosition)
    {
      
        Vector3 startPosition = obj.transform.position;
        float elapsedTime = 0f;

        while (elapsedTime < 1f)
        {
            if (isMovementCancelled) // Stop the animation if canceled
            {
                lineRenderer.enabled = false;
                yield break;
            }

            elapsedTime += (Time.deltaTime * movementSpeed) / 10f;
            obj.transform.position = Vector3.Lerp(startPosition, targetPosition, elapsedTime);

            Vector3 direction = (targetPosition - startPosition).normalized;
            if (direction != Vector3.zero)
            {
                Vector3 stableUp = obj.transform.up;
                if (Mathf.Abs(Vector3.Dot(direction, stableUp)) > 0.99f)
                {
                    stableUp = Vector3.Cross(direction, obj.transform.right);
                }
                Quaternion lookRotation = Quaternion.LookRotation(direction, stableUp);
                obj.transform.rotation = Quaternion.Slerp(obj.transform.rotation, lookRotation, Time.deltaTime * 10f);
            }

            yield return null;
        }

        // Restore the original rotation
        obj.transform.rotation = obj.GetComponent<ObjectMovement>().originalRotation;

        obj.transform.position = targetPosition;
        lineRenderer.enabled = false;

        // Destroy the destination marker after reaching
        if (currentDestinationMarker != null)
        {
            Destroy(currentDestinationMarker);
        }
    }

    private void DrawPath(Vector3 start, Vector3 end)
    {
        lineRenderer.enabled = true;
        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0, start);
        lineRenderer.SetPosition(1, end);
    }

    private void DrawDestinationMarker(Vector3 position)
    {
        if (destinationMarkerPrefab != null)
        {
            // Destroy any existing marker
            if (currentDestinationMarker != null)
            {
                Destroy(currentDestinationMarker);
            }

            // Instantiate a new marker
            currentDestinationMarker = Instantiate(destinationMarkerPrefab, position, Quaternion.identity);
        }
        else
        {
            Debug.LogWarning("Destination marker prefab is not assigned.");
        }
    }
}
