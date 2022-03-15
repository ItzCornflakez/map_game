using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class provinceBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    
    public GameObject provinceUI;
    void Start()
    {
        this.provinceUI.SetActive(false);  
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown(){
        this.provinceUI.SetActive(true);
        GameObject.Find("UpdateUI").GetComponent<updateUI>().updateProvinceUI(gameObject.GetComponent<initializeProvince>().getProvince(), this.transform.gameObject);
    }

}
