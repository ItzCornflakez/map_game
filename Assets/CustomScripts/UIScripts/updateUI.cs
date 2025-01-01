using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using Unity.VisualScripting;
using System.Linq;

public class updateUI : MonoBehaviour
{


    public GameObject nation1;

    private Province province;

    private Army army;

    public GameObject provinceUI;

 
    // Start is called before the first frame update
    void Start()
    {
        //updateEconomyUI();
        this.provinceUI.SetActive(false);
        this.updateCourtUI(nation1.GetComponent<createNation>().getNation().getCourt());
        
    }

    // Helper function to find inactive GameObjects by name
    GameObject FindInactiveObject(string objectName)
    {
        GameObject[] allObjects = Resources.FindObjectsOfTypeAll<GameObject>();

        foreach (GameObject obj in allObjects)
        {
            if (obj.name == objectName && !obj.scene.isSubScene)
            {
                return obj;
            }
        }

        Debug.LogWarning($"Object with name {objectName} not found.");
        return null;
    }

    // Update UI elements
    void UpdateText(string objectName, string value)
    {
        var textComponent = FindInactiveObject(objectName)?.GetComponent<Text>();
        if (textComponent != null) textComponent.text = value;
    }

    void updateCourtUI(Court court){

        // Update Ruler UI
        UpdateText("RulerNameText", $"{court.getRuler().getLeaderName()}");
        UpdateText("RulerAdmText", $"{court.getRuler().getAdmCapability()}");
        UpdateText("RulerDipText", $"{court.getRuler().getDipCapbility()}");
        UpdateText("RulerMilText", $"{court.getRuler().getMilCapability()}");
        UpdateText("RulerModifiersText", $"{this.stringOfModifiers(court.getRuler().getModifiers())}");
        UpdateText("RulerAgeText", $"{court.getRuler().getLeaderAge()}");

        // Update Heir UI
        UpdateText("HeirNameText", $"{court.getHeir().getLeaderName()}");
        UpdateText("HeirAdmText", $"{court.getHeir().getAdmCapability()}");
        UpdateText("HeirDipText", $"{court.getHeir().getDipCapbility()}");
        UpdateText("HeirMilText", $"{court.getHeir().getMilCapability()}");
        UpdateText("HeirModifiersText", $"{this.stringOfModifiers(court.getHeir().getModifiers())}");
        UpdateText("HeirAgeText", $"{court.getHeir().getLeaderAge()}");

        // Update Consort UI
        UpdateText("ConsortNameText", $"{court.getConsort().getLeaderName()}");
        UpdateText("ConsortAdmText", $"{court.getConsort().getAdmCapability()}");
        UpdateText("ConsortDipText", $"{court.getConsort().getDipCapbility()}");
        UpdateText("ConsortMilText", $"{court.getConsort().getMilCapability()}");
        UpdateText("ConsortModifiersText", $"{this.stringOfModifiers(court.getConsort().getModifiers())}");
        UpdateText("ConsortAgeText", $"{court.getConsort().getLeaderAge()}");
    }
    void updateEconomyUI(Economy economy){

        // Update Economy UI
        UpdateText("TaxationText", $"{economy.getTaxation()}");
        UpdateText("TaxEfficiencyText", $"({economy.getTaxIncomeEfficiency() * 100}%)");
        UpdateText("ProductionText", $"{economy.getProduction()}");
        UpdateText("ProductionEfficiencyText", $"({economy.getProductionEfficiency() * 100}%)");
    }
    public void UpdateProvinceUI(GameObject provinceGameObject){

        this.province = provinceGameObject.GetComponent<initializeProvince>().getProvince();
        //GameObject parent = provinceGameObject.transform.parent.gameObject;
        //GameObject grandParent = parent.transform.parent.gameObject;

        UpdateText("CustomProvinceNameText", $"{this.province.getProvinceName()}");
        UpdateText("ProvinceNameText", $"{this.province.getProvinceName()}");
        //UpdateText("AreaText", $"{parent.name}");
        //UpdateText("RegionText", $"{grandParent.name}");
        UpdateText("AreaText", $"to be decided");
        UpdateText("RegionText", $"to be decided");
        UpdateText("TaxDevText", $"{this.province.getTaxDev()}");
        UpdateText("ProdDevText", $"{this.province.getProdDev()}");
        UpdateText("ManDevText", $"{this.province.getManDev()}");
        UpdateText("DevText", $"{this.province.getDev()}");
        UpdateText("DevCostText", $"{this.province.getDevCost()}");
        UpdateText("DevastationText", $"{this.province.getDevastation()}");
        UpdateText("LootText", $"{this.province.getLoot()}");
        UpdateText("TaxText", $"{this.province.getProvincialTaxIncome()}");
        UpdateText("ProductionText", $"{this.province.getProvincialProductionIncome()}");
        UpdateText("TotalText", $"{(this.province.getProvincialTaxIncome() + this.province.getProvincialProductionIncome())}");
        UpdateText("UnrestText", $"{this.province.getUnrest()}");
        UpdateText("AutonomyText", $"{this.province.getAutonomy()}");
        UpdateText("CultureText", $"{this.province.getCulture()}");
        UpdateText("ReligionText", $"{this.province.getReligion()}");
        UpdateText("ArmiesText", $"{this.province.getArmiesInQueue()}");
        UpdateText("NaviesText", $"{this.province.getNaviesInQueue()}");
        UpdateText("ManpowerText", $"{this.province.getManpower()}");
        UpdateText("SupplyLimitText", $"{this.province.getSupplyLimit()}");
        UpdateText("SailorsText", $"{this.province.getSailors()}");
        UpdateText("ProvinceWarScoreText", $"{this.province.getProvinceWarScore()}");
        UpdateText("FortLevelText", $"{this.province.getFortLevel()}");
        UpdateText("FortDefenseText", $"{this.province.getFortDefense()}");
        UpdateText("GarrisonText", $"{this.province.getGarrison()}");
        UpdateText("TradePowerText", $"{this.province.getTradePower()}");
        UpdateText("TradeValueText", $"{this.province.getTradeValue()}");
        UpdateText("GoodsProducedText", $"{this.province.getGoodsProduced()}");
        UpdateText("TradeGoodText", $"{this.province.getTradeGood()}");
        UpdateText("MarketPriceText", $"{this.province.getMarketPrice()}");

    }

    public void UpdateMilitaryArmyUI(GameObject armyGameObject)
    {
        this.army = armyGameObject.GetComponent<initializeArmy>().Army;

        float armyInfantryCount = 0f;
        float armyHorsemenCount = 0f;
        float armyArtilleryCount = 0f;

        for(int i = 0; i < this.army.InfantryCollumb.Count; i++)
        {
            armyInfantryCount += this.army.InfantryCollumb.ElementAt(i).MenCount;
        }
        for (int i = 0; i < this.army.HorsemenCollumb.Count; i++)
        {
            armyHorsemenCount += this.army.HorsemenCollumb.ElementAt(i).MenCount;
        }
        for (int i = 0; i < this.army.ArtilleryCollumb.Count; i++)
        {
            armyArtilleryCount += this.army.ArtilleryCollumb.ElementAt(i).MenCount;
        }

        // Update Army UI
        UpdateText("ArmyNameText", this.army.ArmyName);
        UpdateText("InfantryCountText", $"{armyInfantryCount}");
        UpdateText("HorsemenCountText", $"{armyHorsemenCount}");
        UpdateText("ArtilleryCountText", $"{armyArtilleryCount}");
        UpdateText("TotalArmyCountText", $"{armyInfantryCount + armyHorsemenCount + armyArtilleryCount}");

        // Update detailed counts
        UpdateText("infantrySingleDigitCountText", $"{this.army.InfantryCollumb.Count}");
        UpdateText("infantryThousandCountText", $"{armyInfantryCount}");
        UpdateText("horsemenSingleDigitCountText", $"{this.army.HorsemenCollumb.Count}");
        UpdateText("horsemenThousandCountText", $"{armyHorsemenCount}");
        UpdateText("artillerySingleDigitCountText", $"{this.army.ArtilleryCollumb.Count}");
        UpdateText("artilleryThousandCountText", $"{armyArtilleryCount}");
    }

    public string stringOfModifiers(List<string> modifiers){
        string modifiersString = "";
        foreach (var item in modifiers){
            if(modifiersString == ""){
                modifiersString += $"{item}";
            } else {
            modifiersString += ", " + $"{item}";
            }
        }
        return modifiersString;
    }
}
