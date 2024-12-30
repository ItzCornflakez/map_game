using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class provinceBehavior : MonoBehaviour
{
    public GameObject provinceUI;
    private RectTransform provinceRect;
    private bool animationPlayed = false; // Flag to prevent spamming

    void Start()
    {
        // Ensure the UI starts offscreen
        provinceRect = provinceUI.GetComponent<RectTransform>();
        provinceUI.SetActive(false);
    }

    public void SetFlag(bool flag)
    {
        this.animationPlayed = flag;
    }

    void OnMouseDown()
    {

        // Check if the animation has already been played
        if (animationPlayed) return;

        animationPlayed = true; // Set the flag to true

        // Enable the UI
        provinceUI.SetActive(true);

        // Move it from offscreen to its final position
        provinceRect.anchoredPosition = new Vector2(-Screen.width, provinceRect.anchoredPosition.y);
        LeanTween.moveX(provinceRect, 210, 0.5f).setEase(LeanTweenType.easeOutCubic);

        // Update the UI
        GameObject.Find("UpdateUI").GetComponent<updateUI>().UpdateProvinceUI(this.transform.gameObject);
    }
}