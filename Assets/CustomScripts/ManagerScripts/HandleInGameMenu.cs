using UnityEngine;
using UnityEngine.UI;

public class HandleInGameMenu : MonoBehaviour
{
    public GameObject ui;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && ui != null)
        {
            // Toggle the UI's active state
            ui.SetActive(!ui.activeSelf);
        }
    }
}
