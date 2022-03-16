using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createNation : MonoBehaviour{

    //NationData
    public string nationName;
    public string description;
    public List<int> provinceIdList;

    //Court
    public string leaderName;
    public int age;
    public int admCapability, dipCapability, milCapability;
    public string leaderNameHeir;
    public int ageHeir;
    public int admCapabilityHeir, dipCapabilityHeir, milCapabilityHeir;
    public string leaderNameConsert;
    public int ageConsert;
    public int admCapabilityConsert, dipCapabilityConsert, milCapabilityConsert;

    //Diplomacy
    public int maxRelations;
    public List<string> relationList;
    public int aggressiveExpansion; 

    //Military
    public int currForce;
    public int forceLimit;
    public int currManpower;
    public int maxManpower;
    public float dicipline;
    public float morale;

    //Economy
    public float money;
    public int inflation;

    //Religion
    public string religionName;
    public float missionaryStrength;

    private List<Province> selectedProvinces;

    private Nation nation;

    // Start is called before the first frame update
    void Start(){

        //StartCoroutine(waitGameInfo());

        selectedProvinces = new List<Province>();
    
        GameObject gameInfo = GameObject.Find("GameInfo");
        LoadGameInfo gameScript = gameInfo.GetComponent<LoadGameInfo>();
        List<Province> provinceList = gameScript.getProvinces();
        for(int i = 0; i < provinceIdList.Count; i++){
            for(int j = 0; j < provinceList.Count; j++){
                Province tempProvince = provinceList[j];
                if(provinceIdList[i] == tempProvince.getProvinceId()){
                    selectedProvinces.Add(tempProvince);
                }
            
            }
            
            
        }

        Leader leader = new Leader("Ruler", leaderName, "", admCapability, dipCapability, milCapability, age);
        Leader heir = new Leader("Heir", leaderNameHeir, "", admCapabilityHeir, dipCapabilityHeir, milCapabilityHeir, ageHeir);
        Leader consert = new Leader("Consert", leaderNameConsert, "", admCapabilityConsert, dipCapabilityConsert, milCapabilityConsert, ageConsert);

        NationData nationData = new NationData(nationName, description, selectedProvinces);
        Court court = new Court(leader, heir, consert);
        Diplomacy diplomacy = new Diplomacy(maxRelations, relationList, aggressiveExpansion);
        Military military = new Military(currForce, forceLimit, currManpower, maxManpower, dicipline, morale);
        Economy economy = new Economy(money, selectedProvinces);
        Religion religion = new Religion(religionName, missionaryStrength);

        this.nation = new Nation(nationData, court, diplomacy, military, economy, religion);
    }
    public Nation getNation(){return this.nation;}
}
