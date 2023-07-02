using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class militaryBehavior : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject militaryArmyUI;

    void Start()
    {
        this.militaryArmyUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        this.militaryArmyUI.SetActive(true);
        GameObject.Find("UpdateUI").GetComponent<updateUI>().UpdateMilitaryArmyUI(this.transform.gameObject);
    }
}
