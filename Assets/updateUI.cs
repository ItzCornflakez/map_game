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
    }
    void updateEconomyUI(Economy economy){
    
        GameObject.Find("TaxationText").GetComponent<Text>().text = $"{economy.getTaxation()}";
        GameObject.Find("TaxEfficiencyText").GetComponent<Text>().text = $"({economy.getTaxIncomeEfficiency() * 100}%)";
        GameObject.Find("ProductionText").GetComponent<Text>().text = $"{economy.getProduction()}";
        GameObject.Find("ProductionEfficiencyText").GetComponent<Text>().text = $"({economy.getProductionEfficiency() * 100}%)";
    }
    public void updateProvinceUI(GameObject provinceGameObject){

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
}
