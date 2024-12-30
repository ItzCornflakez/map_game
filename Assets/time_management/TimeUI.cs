using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class TimeUI : MonoBehaviour
{

    //public GameObject timeText;
    public GameObject timeText2;

    private DateTime newDate; 
    // Start is called before the first frame update
    void Start(){
        GameObject dateTextObject = GameObject.Find("Date text");
        FixDate gameScript = dateTextObject.GetComponent<FixDate>();
        newDate = gameScript.startDate;
    }
    private void OnEnable(){
        TimeManager.OnSecondChanged += UpdateTime;
        
    }
    private void OnDisable(){
        TimeManager.OnSecondChanged -= UpdateTime;
    }
    private void UpdateTime(){

        newDate = newDate.AddDays(1);
        timeText2.GetComponent<Text>().text = newDate.ToString("dd MMM yyyy");
      
    }
}
