using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EventManager : MonoBehaviour
{
    public GameObject eventUIObject;
    public GameObject eventUIButtonObject;

    private MongoClient client;
    private IMongoDatabase database;
    private IMongoCollection<EventData> eventCollection;

    private List<EventData> activeEvents = new List<EventData>();
    private List<EventData> firedEvents = new List<EventData>();

    private GameObject timeObject;

    private DateTime lastCheckedTime;
    private DateTime currentTime;

    void Start()
    {

        currentTime = GetCurrentTime();
        lastCheckedTime = currentTime;

        try
        {
            // Initialize MongoDB connection
            client = new MongoClient("mongodb://localhost:27017");
            database = client.GetDatabase("mapGameDatabase");
            eventCollection = database.GetCollection<EventData>("events");

            Debug.Log("MongoDB connection initialized successfully.");
        }
        catch (Exception ex)
        {
            Debug.LogError($"Error initializing MongoDB connection: {ex.Message}");
        }

        FetchActiveEvents();
    }

    void Update()
    {
        // Get the current time
        currentTime = GetCurrentTime();

        if (currentTime.Year != lastCheckedTime.Year)
        {

        }

        // Check if the month has changed
        if (currentTime.Month != lastCheckedTime.Month)
        {
            OnMonthChange();
        }

        if (currentTime.Day != lastCheckedTime.Day)
        {
            //Debug.LogError($"{currentTime.Day} and {lastCheckedTime.Day}");
            OnDayChange();
        }

        lastCheckedTime = currentTime;
    }

    void OnYearChange()
    {
        // Example action to perform
        Debug.Log("A year has passed! Performing action...");

    }

    void OnMonthChange()
    {
        // Example action to perform
        Debug.Log("A month has passed! Performing action...");

        FetchActiveEvents();
    }

    void OnDayChange()
    {
        HandleActiveEvents();
    }

    DateTime GetCurrentTime()
    {
        string format = "dd MMM yyyy";
        GameObject timeObject = GameObject.Find("Date text");

        if (timeObject != null)
        {
            Text textComponent = timeObject.GetComponent<Text>();
            if (textComponent != null)
            {
                if (DateTime.TryParseExact(textComponent.text, format,
                                           System.Globalization.CultureInfo.InvariantCulture,
                                           System.Globalization.DateTimeStyles.None,
                                           out DateTime currentTime))
                {
                    return currentTime;
                }
            }
        }

        // Return a default value if parsing fails
        return DateTime.MinValue;
    }

    void HandleActiveEvents()
    {
        // Create a local copy of the activeEvents list to avoid external modifications
        List<EventData> eventsSnapshot = new List<EventData>(activeEvents);

        foreach (EventData currentEvent in eventsSnapshot)
        {
            currentTime = GetCurrentTime();
            double likelihood = CalculateLikelihood(currentEvent.startTime, currentEvent.endTime, currentTime);
            System.Random random = new System.Random();
            double randomValue = random.NextDouble();
            if (randomValue <= likelihood)
            {
                FireEvent(currentEvent);
            }

        }
    }

    void FireEvent(EventData currentEvent)
    {
        GameObject instanceOfEventUI = Instantiate(eventUIObject);

        GameObject parentObject = GameObject.Find("WindowUI");

        instanceOfEventUI.transform.SetParent(parentObject.transform, false);
        // Optionally, set the position and rotation
        instanceOfEventUI.transform.localPosition = Vector3.zero; // Adjust as needed
        instanceOfEventUI.transform.localRotation = Quaternion.identity;

        Transform childTransform1 = instanceOfEventUI.transform.GetChild(0);
        Transform childTransform2 = instanceOfEventUI.transform.GetChild(1);

        childTransform1.GetChild(0).GetComponent<TextMeshProUGUI>().text = currentEvent.eventName;
        childTransform2.GetChild(1).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = currentEvent.eventText;

        // Add buttons prefabs
        Transform buttonParent = childTransform2.GetChild(2);

        for (int i = 0; i < currentEvent.optionList.Count; i++)
        {
            HandleEventOption(currentEvent.optionList[i], buttonParent, i);
        }


        activeEvents.Remove(currentEvent);
        firedEvents.Add(currentEvent);
    }

    void HandleEventOption(EventOption option, Transform buttonParent, int i)
    {

        GameObject instanceOfEventUIButton = Instantiate(eventUIButtonObject);
        instanceOfEventUIButton.transform.SetParent(buttonParent.transform, false);

        // Optionally, set the position and rotation
        instanceOfEventUIButton.transform.localPosition = Vector3.zero; // Adjust as needed
        instanceOfEventUIButton.transform.localRotation = Quaternion.identity;

        // Set button text
        instanceOfEventUIButton.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = option.optionText;

        HandleHoverLogic(option, instanceOfEventUIButton, i);
    }

    void HandleHoverLogic(EventOption option, GameObject instanceOfEventUIButton, int i)
    {
        // Add the HoverTip component and configure it
        HoverTip hoverTip = instanceOfEventUIButton.AddComponent<HoverTip>();
        hoverTip.tipToShow = $"Option: {option.optionText}\nValue: {option.optionValue}"; // Customize tip text
        hoverTip.tipID = i; // Assign a unique tipID (matches the button index)

        HoverTipManager.TipInstance newTipInstance = new HoverTipManager.TipInstance
        {
            tipText = instanceOfEventUIButton.transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>(),
            tipWindow = instanceOfEventUIButton.transform.GetChild(1).GetComponent<RectTransform>()
        };
        HoverTipManager.tipInstances.Add(newTipInstance);
        hoverTip.tipID = HoverTipManager.tipInstances.Count - 1;

        HoverTipManager.OnMouseLoseFocus(hoverTip.tipID);
    }

    void FetchActiveEvents()
    {
        try
        {
            // Get the current date and time from the UI
            GameObject dateTextObject = GameObject.Find("Date text");

            UnityEngine.UI.Text dateText = dateTextObject.GetComponent<UnityEngine.UI.Text>();

            string format = "dd MMM yyyy";

            DateTime.TryParseExact(dateText.text, format,
                                       System.Globalization.CultureInfo.InvariantCulture,
                                       System.Globalization.DateTimeStyles.None,
                                       out DateTime currentTime);


            // Create a filter for events within the current date
            var filterBuilder = Builders<EventData>.Filter;
            var filter = filterBuilder.Gte(x => x.endTime, currentTime) &
                            filterBuilder.Lte(x => x.startTime, currentTime);

            // Query the database
            var activeEvents = eventCollection.Find(filter).ToList();

            this.activeEvents = activeEvents;
            this.activeEvents.RemoveAll(event1 => firedEvents.Contains(event1));
        }
        catch (Exception ex)
        {
            Debug.LogError($"Error fetching active events: {ex.Message}");
        }
    }

    double CalculateLikelihood(DateTime startDate, DateTime endDate, DateTime currentDate)
    {
        if (currentDate < startDate)
            return 0.0;
        if (currentDate > endDate)
            return 100.0;

        double totalDuration = (endDate - startDate).TotalDays;
        double elapsedDuration = (currentDate - startDate).TotalDays;

        return (elapsedDuration / totalDuration);
    }
}