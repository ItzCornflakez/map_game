using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public class EndTimerObject
{
    public DateTime endTime;
    public GameObject eventUIObject;


    public EndTimerObject(DateTime endTime, GameObject eventUIObject)
    {
        this.endTime = endTime;
        this.eventUIObject = eventUIObject;
    }
}