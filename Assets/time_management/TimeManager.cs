using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class TimeManager : MonoBehaviour{

    public static Action OnSecondChanged;

    public static int second { get; private set;}

    private float secondToRealTime = 0.5f;
    private float timer;

    public float timeMultiplier;

    public bool pause;


    // Start is called before the first frame update
    void Start(){
        second = 0;
        timer = secondToRealTime;        
    }

    // Update is called once per frame
    void Update(){
        if(pause == false){
        timer -= Time.deltaTime * timeMultiplier;
        }
        if(timer <= 0){
            second++;
            OnSecondChanged?.Invoke();

            timer = secondToRealTime;
        }
        
    }
    public void increaseTimeMultiplierFunc(){
        if(this.timeMultiplier < 5){
            this.timeMultiplier += 1.0f;
            GameObject.Find("TimeModifierText").GetComponent<Text>().text = $"{this.GetComponent<TimeManager>().timeMultiplier}";
        }
        
    }
    public void decreaseTimeMultiplierFunc(){
        if(this.timeMultiplier > 0){
            this.timeMultiplier -= 1.0f;
            GameObject.Find("TimeModifierText").GetComponent<Text>().text = $"{this.GetComponent<TimeManager>().timeMultiplier}";
        }
    }
    public void togglePause(){
        pause = !pause;
    }
}
