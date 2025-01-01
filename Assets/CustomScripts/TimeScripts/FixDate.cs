using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class FixDate : MonoBehaviour
{

    public DateTime startDate;

    void Start()
    {
        startDate = new DateTime(1444, 11, 11);
        this.GetComponent<Text>().text = startDate.ToString("dd MMM yyyy");
    }

}
