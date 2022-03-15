using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class updateUI : MonoBehaviour
{


    public GameObject nation1;

    private Province province;

    public GameObject provinceUI;
    // Start is called before the first frame update
    void Start()
    {
        //updateEconomyUI();
        this.provinceUI.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        print(UnityStats.vboTotal);
    }
    void updateEconomyUI(){
        Nation nation = nation1.GetComponent<createNation>().getNation();
        Economy economy = nation.getEconomy();
        //Values to print to UI
        float taxation = economy.getTaxation();
        float taxIncomeEfficiency = economy.getTaxIncomeEfficiency();
        float production = economy.getProduction();
        float productionEfficiency = economy.getProductionEfficiency();

        //Get UI objects
        GameObject taxText = GameObject.Find("TaxationText");
        GameObject taxEfficiencyText = GameObject.Find("TaxEfficiencyText");
        GameObject prodText = GameObject.Find("ProductionText");
        GameObject prodEfficiencyText = GameObject.Find("ProductionEfficiencyText");
        taxText.GetComponent<Text>().text = $"{taxation}";
        taxEfficiencyText.GetComponent<Text>().text = $"({taxIncomeEfficiency * 100}%)";
        prodText.GetComponent<Text>().text = $"{production}";
        prodEfficiencyText.GetComponent<Text>().text = $"({productionEfficiency * 100}%)";
    }
    public void updateProvinceUI(Province province, GameObject provinceGameObject){
        this.province = province;
        
        //Values to print on UI
        string provinceName = this.province.getProvinceName();
        GameObject parent = provinceGameObject.transform.parent.gameObject;
        GameObject grandParent = parent.transform.parent.gameObject;
        string areaName = parent.name;
        string regionName = grandParent.name;
        int taxDev = this.province.getTaxDev();
        int prodDev = this.province.getProdDev();
        int manDev = this.province.getManDev();
        float dev = this.province.getDev();
        float devCost = this.province.getDevCost();
        float devastation = this.province.getAutonomy();
        float loot = this.province.getLoot();
        float taxation = this.province.getProvincialTaxIncome();
        float production = this.province.getProvincialProductionIncome();
        float total = taxation + production;
        float unrest = this.province.getUnrest();
        float autonomy = this.province.getAutonomy();
        string culture = this.province.getCulture();
        string religion = this.province.getReligion();
        float armiesInQueue = this.province.getArmiesInQueue();
        float naviesInQueue = this.province.getNaviesInQueue();
        float manpower =  this.province.getManpower();
        float supplyLimit =  this.province.getSupplyLimit();
        float sailors =  this.province.getSailors();
        float provinceWarScore = this.province.getProvinceWarScore();
        float fortLevel = this.province.getFortLevel();
        float fortDefense = this.province.getFortDefense();
        float garrison =  this.province.getGarrison();
        float tradePower = this.province.getTradePower();
        float tradeValue = this.province.getTradeValue();
        float goodsProduced =  this.province.getGoodsProduced();
        string tradeGood =  this.province.getTradeGood();
        float marketPrice =  this.province.getMarketPrice();
        

        //Text object to print to 
        GameObject customProvinceNameText = GameObject.Find("CustomProvinceNameText");
        GameObject provinceNameText = GameObject.Find("ProvinceNameText");
        GameObject areaText = GameObject.Find("AreaText");
        GameObject regionText = GameObject.Find("RegionText");
        GameObject taxDevText = GameObject.Find("TaxDevText");
        GameObject prodDevText = GameObject.Find("ProdDevText");
        GameObject manDevText = GameObject.Find("ManDevText");
        GameObject devText = GameObject.Find("DevText");
        GameObject devCostText = GameObject.Find("DevCostText");
        GameObject devastationText = GameObject.Find("DevastationText");
        GameObject lootText = GameObject.Find("LootText");
        GameObject taxText = GameObject.Find("TaxText");
        GameObject productionText = GameObject.Find("ProductionText");
        GameObject totalText = GameObject.Find("TotalText");
        GameObject unrestText = GameObject.Find("UnrestText");
        GameObject autonomyText = GameObject.Find("AutonomyText");
        GameObject cultureText = GameObject.Find("CultureText");
        GameObject religionText = GameObject.Find("ReligionText");
        GameObject armiesText = GameObject.Find("ArmiesText");
        GameObject naviesText = GameObject.Find("NaviesText");
        GameObject manpowerText = GameObject.Find("ManpowerText");
        GameObject supplyLimitText = GameObject.Find("SupplyLimitText");
        GameObject sailorsText = GameObject.Find("SailorsText");
        GameObject provinceWarScoreText = GameObject.Find("ProvinceWarScoreText");
        GameObject fortLevelText = GameObject.Find("FortLevelText");
        GameObject fortDefenseText = GameObject.Find("FortDefenseText");
        GameObject garrisonText = GameObject.Find("GarrisonText");
        GameObject tradePowerText = GameObject.Find("TradePowerText");
        GameObject tradeValueText = GameObject.Find("TradeValueText");
        GameObject goodsProducedText = GameObject.Find("GoodsProducedText");
        GameObject tradeGoodText = GameObject.Find("TradeGoodText");
        GameObject marketPriceText = GameObject.Find("MarketPriceText");


        //Print on objects
        customProvinceNameText.GetComponent<Text>().text = $"{provinceName}";
        provinceNameText.GetComponent<Text>().text = $"{provinceName}";
        areaText.GetComponent<Text>().text = $"{areaName}";
        regionText.GetComponent<Text>().text = $"{regionName}";
        taxDevText.GetComponent<Text>().text = $"{taxDev}";
        prodDevText.GetComponent<Text>().text = $"{prodDev}";
        manDevText.GetComponent<Text>().text = $"{manDev}";
        devText.GetComponent<Text>().text = $"{dev}";
        devCostText.GetComponent<Text>().text = $"{devCost}";
        devastationText.GetComponent<Text>().text = $"{devastation}";
        lootText.GetComponent<Text>().text = $"{loot}";
        taxText.GetComponent<Text>().text = $"{taxation}";
        productionText.GetComponent<Text>().text = $"{production}";
        totalText.GetComponent<Text>().text = $"{total}";
        unrestText.GetComponent<Text>().text = $"{unrest}";
        autonomyText.GetComponent<Text>().text = $"{autonomy}";
        cultureText.GetComponent<Text>().text = $"{culture}";
        religionText.GetComponent<Text>().text = $"{religion}";
        armiesText.GetComponent<Text>().text = $"{armiesInQueue}";
        naviesText.GetComponent<Text>().text = $"{naviesInQueue}";
        manpowerText.GetComponent<Text>().text = $"{manpower}";
        supplyLimitText.GetComponent<Text>().text = $"{supplyLimit}";
        sailorsText.GetComponent<Text>().text = $"{sailors}";
        provinceWarScoreText.GetComponent<Text>().text = $"{provinceWarScore}";
        fortLevelText.GetComponent<Text>().text = $"{fortLevel}";
        fortDefenseText.GetComponent<Text>().text = $"{fortDefense}";
        garrisonText.GetComponent<Text>().text = $"{garrison}";
        tradePowerText.GetComponent<Text>().text = $"{tradePower}";
        tradeValueText.GetComponent<Text>().text = $"{tradeValue}";
        goodsProducedText.GetComponent<Text>().text = $"{goodsProduced}";
        tradeGoodText.GetComponent<Text>().text = $"{tradeGood}";
        marketPriceText.GetComponent<Text>().text = $"{marketPrice}";
        



    }
}
