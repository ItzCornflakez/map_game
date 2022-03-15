using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleMenuScript : MonoBehaviour
{


    public GameObject menuUI;
    // Start is called before the first frame update

    private GameObject tabsUI; 
    void Start()
    {
        tabsUI = GameObject.Find("TabsUI");
        for(int i = 0; i < tabsUI.transform.childCount; i++){
            int x = i;
        Button tempButton = tabsUI.transform.GetChild(x).gameObject.GetComponent<Button>();
        tempButton.onClick.AddListener(() => switchTab(x+2));
        } 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("f1"))
        {
            menuUI.gameObject.SetActive(true);
        }
    }

    void switchTab(int x){

        for(int i = 2; i < menuUI.transform.childCount; i++){
            if( i != x){
                menuUI.transform.GetChild(i).gameObject.SetActive(false);
            }
        }
        menuUI.transform.GetChild(x).gameObject.SetActive(true);
            
    }
}
