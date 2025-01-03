using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Globalization;
using System;
using System.IO;
using OfficeOpenXml;

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

        // Specify the path to the Excel file
        string filePath = Application.dataPath + "/CustomScripts/EventScripts/Events.xlsx";

        if (File.Exists(filePath))
        {
            try
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial; // Set EPPlus license context
                using (var package = new ExcelPackage(new FileInfo(filePath)))
                {
                    var worksheet = package.Workbook.Worksheets[0]; // Assuming data is in the first sheet

                    for (int row = 2; row <= worksheet.Dimension.End.Row; row++) // Skip headers
                    {
                        EventData eventData = ParseRowToEventData(worksheet, row);
                        if (eventData != null)
                        {
                            eventDataList.Add(eventData);
                        }
                    }
                }

                Debug.Log("Successfully initialized events from file.");
            }
            catch (Exception ex)
            {
                Debug.LogError($"Failed to read Excel file: {ex.Message}");
            }
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

    private EventData ParseRowToEventData(ExcelWorksheet worksheet, int row)
    {
        try
        {
            int eventID = int.Parse(worksheet.Cells[row, 1].Text);
            string eventName = worksheet.Cells[row, 2].Text;
            string eventText = worksheet.Cells[row, 3].Text;

            string fullStartDate = worksheet.Cells[row, 4].Text;
            string fullEndDate = worksheet.Cells[row, 5].Text;

            string format = "yyyyMMdd";

            DateTime.TryParseExact(fullStartDate, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime convertedStartTime);
            DateTime.TryParseExact(fullEndDate, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime convertedEndTime);

            // Create the list of options
            List<EventOption> options = new List<EventOption>();
            int column = 6;
            while (!string.IsNullOrWhiteSpace(worksheet.Cells[row, column].Text))
            {
                string optionText = worksheet.Cells[row, column].Text;
                int optionValue = int.Parse(worksheet.Cells[row, column + 1].Text);
                string optionHoverText = worksheet.Cells[row, column + 2].Text;
                options.Add(new EventOption(optionText, optionValue, optionHoverText));
                column += 3;
            }

            // Create and return the EventData object
            return new EventData(eventID, eventName, eventText, convertedStartTime, convertedEndTime, options);
        }
        catch (Exception ex)
        {
            Debug.LogError($"Failed to parse row {row}. Error: {ex.Message}");
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