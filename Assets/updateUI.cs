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

    // Update is called once per frame
    void Update()
    {
    }

    void updateCourtUI(Court court){
        //Ruler
        GameObject.Find("RulerNameText").GetComponent<Text>().text = $"{court.getRuler().getLeaderName()}";
        GameObject.Find("RulerAdmText").GetComponent<Text>().text = $"{court.getRuler().getAdmCapability()}";
        GameObject.Find("RulerDipText").GetComponent<Text>().text = $"{court.getRuler().getDipCapbility()}";
        GameObject.Find("RulerMilText").GetComponent<Text>().text = $"{court.getRuler().getMilCapability()}";
        GameObject.Find("RulerModifiersText").GetComponent<Text>().text = $"{this.stringOfModifiers(court.getRuler().getModifiers())}";
        GameObject.Find("RulerAgeText").GetComponent<Text>().text = $"{court.getRuler().getLeaderAge()}";
        //Heir
        GameObject.Find("HeirNameText").GetComponent<Text>().text = $"{court.getHeir().getLeaderName()}";
        GameObject.Find("HeirAdmText").GetComponent<Text>().text = $"{court.getHeir().getAdmCapability()}";
        GameObject.Find("HeirDipText").GetComponent<Text>().text = $"{court.getHeir().getDipCapbility()}";
        GameObject.Find("HeirMilText").GetComponent<Text>().text = $"{court.getHeir().getMilCapability()}";    
        GameObject.Find("HeirModifiersText").GetComponent<Text>().text = $"{this.stringOfModifiers(court.getHeir().getModifiers())}";
        GameObject.Find("HeirAgeText").GetComponent<Text>().text = $"{court.getHeir().getLeaderAge()}";
        //Consort
        GameObject.Find("ConsortNameText").GetComponent<Text>().text = $"{court.getConsort().getLeaderName()}";
        GameObject.Find("ConsortAdmText").GetComponent<Text>().text = $"{court.getConsort().getAdmCapability()}";
        GameObject.Find("ConsortDipText").GetComponent<Text>().text = $"{court.getConsort().getDipCapbility()}";
        GameObject.Find("ConsortMilText").GetComponent<Text>().text = $"{court.getConsort().getMilCapability()}";
        GameObject.Find("ConsortModifiersText").GetComponent<Text>().text = $"{this.stringOfModifiers(court.getConsort().getModifiers())}";
        GameObject.Find("ConsortAgeText").GetComponent<Text>().text = $"{court.getConsort().getLeaderAge()}";
    }
    void updateEconomyUI(Economy economy){
    
        GameObject.Find("TaxationText").GetComponent<Text>().text = $"{economy.getTaxation()}";
        GameObject.Find("TaxEfficiencyText").GetComponent<Text>().text = $"({economy.getTaxIncomeEfficiency() * 100}%)";
        GameObject.Find("ProductionText").GetComponent<Text>().text = $"{economy.getProduction()}";
        GameObject.Find("ProductionEfficiencyText").GetComponent<Text>().text = $"({economy.getProductionEfficiency() * 100}%)";
    }
    public void UpdateProvinceUI(GameObject provinceGameObject){

        this.province = provinceGameObject.GetComponent<initializeProvince>().getProvince();
        GameObject parent = provinceGameObject.transform.parent.gameObject;
        GameObject grandParent = parent.transform.parent.gameObject;
        
        //Print on objects
        GameObject.Find("CustomProvinceNameText").GetComponent<Text>().text = $"{this.province.getProvinceName()}";
        GameObject.Find("ProvinceNameText").GetComponent<Text>().text = $"{this.province.getProvinceName()}";
        GameObject.Find("AreaText").GetComponent<Text>().text = $"{parent.name}";
        GameObject.Find("RegionText").GetComponent<Text>().text = $"{grandParent.name}";
        GameObject.Find("TaxDevText").GetComponent<Text>().text = $"{this.province.getTaxDev()}";
        GameObject.Find("ProdDevText").GetComponent<Text>().text = $"{this.province.getProdDev()}";
        GameObject.Find("ManDevText").GetComponent<Text>().text = $"{this.province.getManDev()}";
        GameObject.Find("DevText").GetComponent<Text>().text = $"{this.province.getDev()}";
        GameObject.Find("DevCostText").GetComponent<Text>().text = $"{this.province.getDevCost()}";
        GameObject.Find("DevastationText").GetComponent<Text>().text = $"{this.province.getDevastation()}";
        GameObject.Find("LootText").GetComponent<Text>().text = $"{this.province.getLoot()}";
        GameObject.Find("TaxText").GetComponent<Text>().text = $"{this.province.getProvincialTaxIncome()}";
        GameObject.Find("ProductionText").GetComponent<Text>().text = $"{this.province.getProvincialProductionIncome()}";
        GameObject.Find("TotalText").GetComponent<Text>().text = $"{(this.province.getProvincialTaxIncome() + this.province.getProvincialProductionIncome())}";
        GameObject.Find("UnrestText").GetComponent<Text>().text = $"{this.province.getUnrest()}";
        GameObject.Find("AutonomyText").GetComponent<Text>().text = $"{this.province.getAutonomy()}";
        GameObject.Find("CultureText").GetComponent<Text>().text = $"{this.province.getCulture()}";
        GameObject.Find("ReligionText").GetComponent<Text>().text = $"{this.province.getReligion()}";
        GameObject.Find("ArmiesText").GetComponent<Text>().text = $"{this.province.getArmiesInQueue()}";
        GameObject.Find("NaviesText").GetComponent<Text>().text = $"{this.province.getNaviesInQueue()}";
        GameObject.Find("ManpowerText").GetComponent<Text>().text = $"{this.province.getManpower()}";
        GameObject.Find("SupplyLimitText").GetComponent<Text>().text = $"{this.province.getSupplyLimit()}";
        GameObject.Find("SailorsText").GetComponent<Text>().text = $"{this.province.getSailors()}";
        GameObject.Find("ProvinceWarScoreText").GetComponent<Text>().text = $"{this.province.getProvinceWarScore()}";
        GameObject.Find("FortLevelText").GetComponent<Text>().text = $"{this.province.getFortLevel()}";
        GameObject.Find("FortDefenseText").GetComponent<Text>().text = $"{this.province.getFortDefense()}";
        GameObject.Find("GarrisonText").GetComponent<Text>().text = $"{this.province.getGarrison()}";
        GameObject.Find("TradePowerText").GetComponent<Text>().text = $"{this.province.getTradePower()}";
        GameObject.Find("TradeValueText").GetComponent<Text>().text = $"{this.province.getTradeValue()}";
        GameObject.Find("GoodsProducedText").GetComponent<Text>().text = $"{this.province.getGoodsProduced()}";
        GameObject.Find("TradeGoodText").GetComponent<Text>().text = $"{this.province.getTradeGood()}";
        GameObject.Find("MarketPriceText").GetComponent<Text>().text = $"{this.province.getMarketPrice()}";
        



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

        GameObject.Find("ArmyNameText").GetComponent<TMPro.TextMeshProUGUI>().text = this.army.ArmyName;
        GameObject.Find("InfantryCountText").GetComponent<TMPro.TextMeshProUGUI>().text = $"{armyInfantryCount}";
        GameObject.Find("HorsemenCountText").GetComponent<TMPro.TextMeshProUGUI>().text = $"{armyHorsemenCount}";
        GameObject.Find("ArtilleryCountText").GetComponent<TMPro.TextMeshProUGUI>().text = $"{armyArtilleryCount}";
        GameObject.Find("TotalArmyCountText").GetComponent<TMPro.TextMeshProUGUI>().text = $"{armyInfantryCount+armyHorsemenCount+armyArtilleryCount}";

        GameObject.Find("infantrySingleDigitCountText").GetComponent<TMPro.TextMeshProUGUI>().text = $"{this.army.InfantryCollumb.Count}";
        GameObject.Find("infantryThousandCountText").GetComponent<TMPro.TextMeshProUGUI>().text = $"{armyInfantryCount}";
        GameObject.Find("horsemenSingleDigitCountText").GetComponent<TMPro.TextMeshProUGUI>().text = $"{this.army.HorsemenCollumb.Count}";
        GameObject.Find("horsemenThousandCountText").GetComponent<TMPro.TextMeshProUGUI>().text = $"{armyHorsemenCount}";
        GameObject.Find("artillerySingleDigitCountText").GetComponent<TMPro.TextMeshProUGUI>().text = $"{this.army.ArtilleryCollumb.Count}";
        GameObject.Find("artilleryThousandCountText").GetComponent<TMPro.TextMeshProUGUI>().text = $"{armyArtilleryCount}";
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
