using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProvinceBehavior : MonoBehaviour
{
    private GameObject provinceUI;
    private RectTransform provinceRect;
    private bool animationPlayed = false; // Flag to prevent spamming

    private Province province;

    public Province Province { get => province; set => province = value; }
    public GameObject ProvinceUI { get => provinceUI; set => provinceUI = value; }

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
        GameObject.Find("UpdateUIManager").GetComponent<updateUI>().UpdateProvinceUI(province);
    }

}