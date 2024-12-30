using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITab
{

    public GameObject ui;

    public void setUI(string uiName)
    {

        GameObject[] allObjects = Resources.FindObjectsOfTypeAll<GameObject>();

        foreach (GameObject obj in allObjects)
        {
            if (obj.name == uiName && !obj.scene.isSubScene)
            {
                this.ui = obj;
                break;
            }
        }

    }
    public GameObject getUI() { return this.ui; }

}
