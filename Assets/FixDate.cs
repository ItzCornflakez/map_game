using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class FixDate : MonoBehaviour
{
    // Start is called before the first frame update

    public DateTime date1;
    void Start()
    {   
        date1 = new DateTime(1444, 11, 11);
        this.GetComponent<Text>().text = date1.ToString("d MMM yyyy");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
