using UnityEngine;

public class ExitProvinceUI : MonoBehaviour
{

    public void ResetAllProvinceBehaviorScripts()
    {
        // Find all GameObjects with the provinceBehavior script
        ProvinceBehavior[] provinceObjects = FindObjectsByType<ProvinceBehavior>(FindObjectsSortMode.None);

        // Call the setFlag method on each found object
        foreach (ProvinceBehavior province in provinceObjects)
        {
            province.SetFlag(false);
        }

    }
}
