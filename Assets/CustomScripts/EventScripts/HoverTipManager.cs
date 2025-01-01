using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class HoverTipManager : MonoBehaviour
{

    [System.Serializable]
    public class TipInstance
    {
        public TextMeshProUGUI tipText;
        public RectTransform tipWindow;
    }

    public static List<TipInstance> tipInstances = new List<TipInstance>();

    public static Action<int, string, Vector2> OnMouseHover; // Pass an ID to identify the tip instance
    public static Action<int> OnMouseLoseFocus; // Pass an ID to identify the tip instance

    private void OnEnable()
    {
        OnMouseHover += ShowTip;
        OnMouseLoseFocus += HideTip;
    }

    private void OnDisable()
    {
        OnMouseHover -= ShowTip;
        OnMouseLoseFocus -= HideTip;
    }

    private void ShowTip(int tipID, string tip, Vector2 mousePos)
    {

        var instance = tipInstances[tipID];

        instance.tipText.text = tip;
        instance.tipWindow.sizeDelta = new Vector2(
            instance.tipText.preferredWidth > 200 ? 200 : instance.tipText.preferredWidth,
            instance.tipText.preferredHeight
        );

        Canvas canvas = GetComponent<Canvas>();

        // Convert screen space to local space within the canvas
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            canvas.transform as RectTransform,
            Input.mousePosition,
            canvas.worldCamera,
            out Vector2 localPoint
        );

        localPoint += new Vector2(55, -30);

        instance.tipWindow.gameObject.SetActive(true);
        instance.tipWindow.transform.position = canvas.transform.TransformPoint(localPoint);
    }

    private void HideTip(int tipID)
    {
        var instance = tipInstances[tipID];

        instance.tipText.text = default;
        instance.tipWindow.gameObject.SetActive(false);
    }
}
