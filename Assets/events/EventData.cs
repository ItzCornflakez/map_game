using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using System.Text;
using System.IO;
using System;
using System.Globalization;
using Newtonsoft.Json;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

[System.Serializable]
public class EventOption
{
    public string optionText;
    public int optionValue;

    public EventOption(string optionText, int optionValue)
    {
        this.optionText = optionText;
        this.optionValue = optionValue;
    }
}

[System.Serializable]
public class EventData
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)] // Ensures MongoDB's ObjectId is correctly mapped
    public string Id { get; set; }
    public int eventID;
    public string eventName;
    public string eventText;
    public DateTime startTime;
    public DateTime endTime;
    public List<EventOption> optionList;

    public EventData(int eventId, string eventName, string eventText, DateTime startTime, DateTime endTime, List<EventOption> optionList)
    {
        this.eventID = eventId;
        this.eventName = eventName;
        this.eventText = eventText;
        this.optionList = optionList;
        this.startTime = startTime;
        this.endTime = endTime;
    }

    // Override Equals method
    public override bool Equals(object obj)
    {
        if (obj is EventData other)
        {
            // Compare based on Id and eventID
            return string.Equals(Id, other.Id, StringComparison.Ordinal) && eventID == other.eventID;
        }
        return false;
    }

    // Override GetHashCode method
    public override int GetHashCode()
    {
        unchecked
        {
            // Generate hash using Id and eventID
            int hash = 17;
            hash = hash * 31 + (Id != null ? Id.GetHashCode() : 0);
            hash = hash * 31 + eventID.GetHashCode();
            return hash;
        }
    }
}
