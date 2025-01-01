using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Vector3 originalPosition;
    private Vector3 dragOffset;
    private Canvas canvas; // Optional: if using a Canvas for UI elements
    private RectTransform rectTransform; // For UI elements

    private void Awake()
    {
        // Cache components
        rectTransform = GetComponent<RectTransform>();
        canvas = GameObject.Find("Canvas").GetComponentInParent<Canvas>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        originalPosition = transform.position; // Store the original position

        // Calculate drag offset
        if (rectTransform != null && canvas != null)
        {
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                canvas.transform as RectTransform,
                eventData.position,
                eventData.pressEventCamera,
                out Vector2 localMousePosition);

            dragOffset = rectTransform.anchoredPosition - localMousePosition;
        }
        else
        {
            Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(new Vector3(eventData.position.x, eventData.position.y, Camera.main.WorldToScreenPoint(transform.position).z));
            dragOffset = transform.position - mouseWorldPosition;
        }

    }

    public void OnDrag(PointerEventData eventData)
    {
        if (rectTransform != null && canvas != null)
        {
            // For UI elements: move based on canvas scaling and maintain offset
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                canvas.transform as RectTransform,
                eventData.position,
                eventData.pressEventCamera,
                out Vector2 localMousePosition);

            rectTransform.anchoredPosition = localMousePosition + (Vector2)dragOffset;
        }
        else
        {
            // For world objects: move directly and maintain offset
            Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(new Vector3(eventData.position.x, eventData.position.y, Camera.main.WorldToScreenPoint(transform.position).z));
            transform.position = mouseWorldPosition + dragOffset;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
    }
}