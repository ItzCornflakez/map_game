using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using System.Text;
using System.IO;
using System;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Globalization;

public class InitializeEvents : MonoBehaviour
{

    private MongoClient client;
    private IMongoDatabase database;
    private IMongoCollection<EventData> eventCollection;

    private List<EventData> eventDataList = new List<EventData>();

    void Start()
    {

        // Initialize MongoDB connection
        client = new MongoClient("mongodb://localhost:27017");
        database = client.GetDatabase("mapGameDatabase");
        eventCollection = database.GetCollection<EventData>("events");

        // Specify the path to the text file
        string filePath = Application.dataPath + "/events/Events.txt";

        if (File.Exists(filePath))
        {
            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                // Parse each line to create EventData
                EventData eventData = ParseLineToEventData(line);
                if (eventData != null)
                {
                    eventDataList.Add(eventData);
                }
            }

            Debug.Log("Successfully initialized events from file.");
        }
        else
        {
            Debug.LogError($"File not found at {filePath}");
        }

        // Debug log the events
        foreach (var eventData in eventDataList)
        {
            Debug.Log($"Event: {eventData.eventName}, Text: {eventData.eventText}");
            foreach (var option in eventData.optionList)
            {
                Debug.Log($" - Option: {option.optionText}, Value: {option.optionValue}");
            }
        }

        // Upload all events
        StartCoroutine(UploadAllEvents());
    }

    private EventData ParseLineToEventData(string line)
    {
        try
        {
            string[] components = line.Split(new string[] { "," }, StringSplitOptions.None);

            // Trim quotes and whitespace
            for (int i = 0; i < components.Length; i++)
            {
                components[i] = components[i].Trim(' ', '"');
            }

            int eventID = int.Parse(components[0]);

            // Extract event name and text
            string eventName = components[1];
            string eventText = components[2];

            string fullStartDate = components[3];
            string fullEndDate = components[4];

            string format = "yyyyMMdd";

            DateTime.TryParseExact(fullStartDate, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime convertedStartTime);
            DateTime.TryParseExact(fullEndDate, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime convertedEndTime);


            // Create the list of options
            List<EventOption> options = new List<EventOption>();
            for (int i = 5; i < components.Length; i += 2)
            {
                string optionText = components[i];
                int optionValue = int.Parse(components[i + 1]);
                options.Add(new EventOption(optionText, optionValue));
            }

            // Create and return the EventData object
            return new EventData(eventID, eventName, eventText, convertedStartTime, convertedEndTime, options);
        }
        catch (Exception ex)
        {
            Debug.LogError($"Failed to parse line: {line}. Error: {ex.Message}");
            return null;
        }
    }

    IEnumerator UploadAllEvents()
    {
        ResetDatabaseCollection();

        foreach (EventData eventData in eventDataList)
        {
            eventCollection.InsertOne(eventData); // Directly insert the EventData object
            yield return null; // Yield for a frame to allow other processes to run
        }
    }

    void ResetDatabaseCollection()
    {
        eventCollection.DeleteMany(FilterDefinition<EventData>.Empty);
    }
}