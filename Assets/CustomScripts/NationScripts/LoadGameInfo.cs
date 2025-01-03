using System.Collections.Generic;
using UnityEngine;
using System.Globalization;
using System;
using System.IO;
using OfficeOpenXml;
using System.Linq;

public class LoadGameInfo : MonoBehaviour
{
    private List<Province> provinceList;
    private List<ProvincePair> provincePairList;
    private List<Nation> nationList;

    private Nation activeNation;

    public Nation ActiveNation { get => activeNation; set => activeNation = value; }

void Start()
    {

        provinceList = new List<Province>();
        provincePairList = new List<ProvincePair>();
        nationList = new List<Nation>();

        LoadProvinces();
        AssignProvinceScriptsToGameObjects();

        LoadNations();

        activeNation = nationList[0];

        UpdateProvinceColors();
    }

    public void UpdateProvinceColors()
    {
        foreach (Nation nation in nationList) // Go through all the nations
        {
            foreach (Province province in nation.NationData.ProvinceList) // Get each of the nations provinces
            {
                foreach(ProvincePair provincePair in provincePairList) // Go through all the gameObjects<->province pairs to get the gameObject to color.
                                                                   // Match province and update the color
                    if (province == provincePair.Province)
                    {
                        Renderer renderer = provincePair.GameObject.GetComponent<Renderer>();
                        if (renderer != null)
                        {
                            // Convert HexColor to Unity Color
                            if (ColorUtility.TryParseHtmlString(nation.NationData.HexColor, out Color color))
                            {
                                renderer.material.color = color; 
                            }
                            else
                            {
                                Debug.LogError($"Invalid HexColor: {nation.NationData.HexColor} for nation {nation}");
                            }
                        }
                    }
            }
        }
    }

    public void AssignProvinceScriptsToGameObjects()
    {
        GameObject provinceUI = GameObject.Find("ProvinceUI");

        // Find all GameObjects in the scene
        GameObject[] allObjects = FindObjectsOfType<GameObject>();

        foreach (GameObject obj in allObjects)
        {
            // Check if the object name matches the naming scheme (e.g., "00001_province")
            if (obj.name.Contains("_province"))
            {
                // Extract the index from the name
                string[] parts = obj.name.Split('_');
                if (parts.Length > 1 && int.TryParse(parts[0], out int index))
                {
                    // Find the corresponding Province in the list by ID
                    Province matchingProvince = provinceList.FirstOrDefault(p => p.Id == index-1);
                    if (matchingProvince != null)
                    {
                        ProvinceBehavior provinceComponent = obj.AddComponent<ProvinceBehavior>();
                        obj.AddComponent<MeshCollider>();
                        ObjectMovement objMovement = obj.AddComponent<ObjectMovement>();
                        objMovement.isMovable = false;



                        // Assign the matching province
                        provinceComponent.Province = matchingProvince;
                        Debug.Log($"Assigned province '{matchingProvince.Name}' to GameObject '{obj.name}'");

                        provinceComponent.ProvinceUI = provinceUI;

                        provincePairList.Add(new ProvincePair(obj, matchingProvince));
                    }
                    else
                    {
                        Debug.LogWarning($"No matching province found for GameObject '{obj.name}' with index {index}");
                    }
                }
            }
        }
    }


    public void LoadProvinces()
    {
        // Specify the path to the Excel file
        string filePath = Application.dataPath + "/CustomScripts/ProvinceScripts/Provinces.xlsx";

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
                        Province province = ParseRowToProvince(worksheet, row);
                        if (province != null)
                        {
                            provinceList.Add(province);
                        }
                    }
                }
                Debug.Log("Successfully initialized provinces from file.");
            }
            catch (Exception ex)
            {
                Debug.LogError($"Failed to read Excel file: {ex.Message}");
            }
        }
    }

    private Province ParseRowToProvince(ExcelWorksheet worksheet, int row)
    {
        try
        {

            int id = int.Parse(worksheet.Cells[row, 1].Text);
            string name = worksheet.Cells[row, 2].Text;
            string description = worksheet.Cells[row, 3].Text;
            int baseTaxDevelopment = int.Parse(worksheet.Cells[row, 4].Text);
            int baseProductionDevelopment = int.Parse(worksheet.Cells[row, 5].Text);
            int baseManpowerDevelopment = int.Parse(worksheet.Cells[row, 6].Text);
            float autonomy = float.Parse(worksheet.Cells[row, 7].Text);
            string religion = worksheet.Cells[row, 8].Text;
            string culture = worksheet.Cells[row, 9].Text;
            string tradeGood = worksheet.Cells[row, 10].Text;

            return new Province(id, name, description, baseTaxDevelopment, baseProductionDevelopment, baseManpowerDevelopment, autonomy, religion, culture, tradeGood);
        }
        catch (Exception ex)
        {
            Debug.LogError($"Failed to read Excel file: {ex.Message}");
            return null;
        }
    }


    public void LoadNations()
    {
        // Specify the path to the Excel file
        string filePath = Application.dataPath + "/CustomScripts/NationScripts/Nations.xlsx";

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
                        Nation nation = ParseRowToNation(worksheet, row);
                        if (nation != null)
                        {
                            nationList.Add(nation);
                        }
                    }
                }
                Debug.Log("Successfully initialized nations from file.");
            }
            catch (Exception ex)
            {
                Debug.LogError($"Failed to read Excel file: {ex.Message}");
            }
        }
    }

    private Nation ParseRowToNation(ExcelWorksheet worksheet, int row)
    {
        try
        {

            List<Province> selectedProvinces = new List<Province>();

            int id = int.Parse(worksheet.Cells[row, 1].Text);
            string name = worksheet.Cells[row, 2].Text;
            string hexColor = worksheet.Cells[row, 3].Text;
            string description = worksheet.Cells[row, 4].Text;
            List<int> selectedProvincesIds = worksheet.Cells[row, 9].Text
            .Trim('\"') // Removes leading and trailing quotes, if present
            .Split(',')
            .Select(p => int.Parse(p.Trim()))
            .ToList();
            string leaderName = worksheet.Cells[row, 10].Text;
            int admCapability = int.Parse(worksheet.Cells[row, 11].Text);
            int dipCapability = int.Parse(worksheet.Cells[row, 12].Text);
            int milCapability = int.Parse(worksheet.Cells[row, 13].Text);
            int age = int.Parse(worksheet.Cells[row, 14].Text);
            string leaderNameHeir = worksheet.Cells[row, 15].Text;
            int admCapabilityHeir = int.Parse(worksheet.Cells[row, 16].Text);
            int dipCapabilityHeir = int.Parse(worksheet.Cells[row, 17].Text);
            int milCapabilityHeir = int.Parse(worksheet.Cells[row, 18].Text);
            int ageHeir = int.Parse(worksheet.Cells[row, 19].Text);
            string leaderNameConsert = worksheet.Cells[row, 20].Text;
            int admCapabilityConsert = int.Parse(worksheet.Cells[row, 21].Text);
            int dipCapabilityConsert = int.Parse(worksheet.Cells[row, 22].Text);
            int milCapabilityConsert = int.Parse(worksheet.Cells[row, 23].Text);
            int ageConsert = int.Parse(worksheet.Cells[row, 24].Text);
            int maxRelations = int.Parse(worksheet.Cells[row, 25].Text);

            List<Relation> relationList = worksheet.Cells[row, 26].Text
            .Split(',')
            .Select(r => {
                var parts = r.Trim().Split(':');
                return new Relation(int.Parse(parts[0]), int.Parse(parts[1]));
            })
            .ToList();
            List<Relation> aggressiveExpansionList = worksheet.Cells[row, 27].Text
            .Split(',')
            .Select(r => {
                var parts = r.Trim().Split(':');
                return new Relation(int.Parse(parts[0]), int.Parse(parts[1]));
            })
            .ToList();
            int currForce = int.Parse(worksheet.Cells[row, 28].Text);
            int forceLimit = int.Parse(worksheet.Cells[row, 29].Text);
            int currManpower = int.Parse(worksheet.Cells[row, 30].Text);
            int maxManpower = int.Parse(worksheet.Cells[row, 31].Text);
            float discipline = float.Parse(worksheet.Cells[row, 32].Text);
            float morale = float.Parse(worksheet.Cells[row, 33].Text);
            float money = float.Parse(worksheet.Cells[row, 34].Text);
            float inflation = float.Parse(worksheet.Cells[row, 35].Text);
            string religionName = worksheet.Cells[row, 36].Text;
            float missionaryStrength = float.Parse(worksheet.Cells[row, 37].Text);

            // Populate selectedProvinces using selectedProvincesIds
            foreach (int provinceId in selectedProvincesIds)
            {
                Province province = GetProvinceById(provinceId); // Assumes a method to fetch Province by ID
                if (province != null)
                {
                    selectedProvinces.Add(province);
                }
                else
                {
                    Debug.LogWarning($"Province with ID {provinceId} not found.");
                }
            }



            Leader leader = new Leader("Ruler", leaderName, "", admCapability, dipCapability, milCapability, age);
            Leader heir = new Leader("Heir", leaderNameHeir, "", admCapabilityHeir, dipCapabilityHeir, milCapabilityHeir, ageHeir);
            Leader consert = new Leader("Consert", leaderNameConsert, "", admCapabilityConsert, dipCapabilityConsert, milCapabilityConsert, ageConsert);

            NationData nationData = new NationData(id, name, hexColor, description, selectedProvinces);
            Court court = new Court(leader, heir, consert);
            Diplomacy diplomacy = new Diplomacy(maxRelations, relationList, aggressiveExpansionList);
            Military military = new Military(currForce, forceLimit, currManpower, maxManpower, discipline, morale);
            Economy economy = new Economy(money, inflation, selectedProvinces);
            Religion religion = new Religion(religionName, missionaryStrength);

            return new Nation(nationData, court, diplomacy, military, economy, religion);
        }
        catch (Exception ex)
        {
            Debug.LogError($"Failed to read Excel file: {ex.Message}");
            return null;
        }
    }

    // Dummy method for fetching a Province by its ID
    Province GetProvinceById(int id)
    {
        foreach (Province province in provinceList)
        {
            if(province.Id == id)
            {
                return province;
            }
        }
        return null;
    }

}

