using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class TimeUI : MonoBehaviour
{

    //public GameObject timeText;
    public GameObject timeText2;

    private DateTime date2; 
    // Start is called before the first frame update
    void Start(){
        GameObject dateTextObject = GameObject.Find("Date text");
        FixDate gameScript = dateTextObject.GetComponent<FixDate>();
        date2 = gameScript.date1;
    }
    private void OnEnable(){
        TimeManager.OnSecondChanged += UpdateTime;
        
    }
    private void OnDisable(){
        TimeManager.OnSecondChanged -= UpdateTime;
    }
    private void UpdateTime(){
        //timeText.GetComponent<Text>().text = $"{TimeManager.second}";

        date2 = date2.AddDays(1);
        timeText2.GetComponent<Text>().text = date2.ToString("d MMM yyyy");
      
    }
}
