using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProvincePair
{
    private GameObject gameObject;
    private Province province;

    public ProvincePair(GameObject gameObject, Province province)
    {
        this.gameObject = gameObject;
        this.province = province;
    }

    public GameObject GameObject { get => gameObject; set => gameObject = value; }
    public Province Province { get => province; set => province = value; }

}

    public class Province
{
   
    private int id;
    //private string owningNationName;
    private string name;
    private string description;
    private int baseTaxDevelopment;
    private int baseProductionDevelopment;
    private int baseManpowerDevelopment;
    private int currentTaxDevelopment;
    private int currentProductionDevelopment;
    private int currentManpowerDevelopment;
    private int baseManpower;
    private float localTaxIncome;
    private float taxIncomeEfficiency;
    private float localManpowerIncrease;
    private float localManpowerModifier;
    private float productionEfficiencyModifiers;
    private float autonomy;
    private string religion;
    private string culture;

    private float taxIncome;
    private float manpower;
    private float productionIncome;

    private float goodsProduced;
    private float flatGoodsProduced;
    private float goodsProducedModifiers;
    private float tradeValue;
    private float marketPrice;
    private string tradeGood;
    private float eventPriceModifiers;

    private float devastation;
    private float loot;
    private float unrest;

    private float totalDevelopment;
    private float developmentCost;
    private float developmentEfficiency;
    private float additionalDevelopmentModifiers;

    private float armiesInQueue;
    private float naviesInQueue;

    private float supplyLimit;
    private float sailors;
    private float warScore;
    private float fortLevel;
    private float fortDefense;
    private float garrison;
    private float tradePower;

    private Dictionary<string, float> tradeGoodDict;

    public Province(int id, string name, string description, int baseTaxDevelopment, int baseProductionDevelopment, int baseManpowerDevelopment, float autonomy,
     string religion, string culture, string tradeGood)
    {
        this.id = id;
        //this.owningNationName = owningNationName;
        this.name = name;
        this.description = description;
        this.baseTaxDevelopment = baseTaxDevelopment;
        this.baseProductionDevelopment = baseProductionDevelopment;
        this.baseManpowerDevelopment = baseManpowerDevelopment;
        this.baseManpower = this.baseManpowerDevelopment * 250;
        this.localTaxIncome = 0;
        this.taxIncomeEfficiency = 1;
        this.autonomy = autonomy;
        this.religion = religion;
        this.culture = culture;
        this.tradeGood = tradeGood;

        this.flatGoodsProduced = 0;
        this.goodsProducedModifiers = 0;
        this.eventPriceModifiers = 0;
        this.productionEfficiencyModifiers = 0;

        this.devastation = 0;
        this.loot = 0;
        this.unrest = 0;

        this.totalDevelopment = this.baseTaxDevelopment + this.baseProductionDevelopment + this.baseManpowerDevelopment;
        this.developmentEfficiency = 0;
        if (this.totalDevelopment > 9)
        {
            this.additionalDevelopmentModifiers = 1.0f + ((this.totalDevelopment - 9) * 0.03f);
        }
        else
        {
            this.additionalDevelopmentModifiers = 1;
        }
        this.developmentCost = 50 * (1.0f - this.developmentEfficiency) * this.additionalDevelopmentModifiers;

        InitializeTradeGoodDict();

        foreach (KeyValuePair<string, float> entry in tradeGoodDict)
        {
            if (entry.Key == this.tradeGood)
            {
                this.marketPrice = entry.Value;
            }
        }

        this.supplyLimit = 0;
        this.sailors = 0;
        this.warScore = 0;
        this.fortLevel = 0;
        this.fortDefense = 0;
        this.garrison = 0;
        this.tradePower = 0;

        UpdateProvinceData();
    }

    public void UpdateProvinceData()
    {
        this.taxIncome = ((this.baseTaxDevelopment + this.localTaxIncome) / 12) * this.taxIncomeEfficiency * (1 - this.autonomy);
        this.manpower = (this.baseManpower + this.localManpowerIncrease) * (1 + this.localManpowerModifier) * (1 - this.autonomy);

        this.goodsProduced = ((this.baseProductionDevelopment * 0.2f) + this.flatGoodsProduced) * (1 + this.goodsProducedModifiers);
        this.tradeValue = this.marketPrice * (1 + this.eventPriceModifiers) * this.goodsProduced;
        this.productionIncome = (1 + this.productionEfficiencyModifiers) * (1 - this.autonomy) * this.tradeValue;
    }

    public void InitializeTradeGoodDict()
    {
        this.tradeGoodDict = new Dictionary<string, float>();
        this.tradeGoodDict.Add("Cloth", 3.0f);
        this.tradeGoodDict.Add("Fish", 2.5f);
    }

   
    public int Id { get => id; set => id = value; }
    //public string OwningNationName { get => owningNationName; set => owningNationName = value; }
    public string Name { get => name; set => name = value; }
    public string Description { get => description; set => description = value; }
    public int BaseTaxDev { get => baseTaxDevelopment; set => baseTaxDevelopment = value; }
    public int BaseProductionDevelopment { get => baseProductionDevelopment; set => baseProductionDevelopment = value; }
    public int BaseManpowerDevelopment { get => baseManpowerDevelopment; set => baseManpowerDevelopment = value; }
    public int CurrentTaxDevelopment { get => currentTaxDevelopment; set => currentTaxDevelopment = value; }
    public int CurrentProductionDevelopment { get => currentProductionDevelopment; set => currentProductionDevelopment = value; }
    public int CurrentManpowerDevelopment { get => currentManpowerDevelopment; set => currentManpowerDevelopment = value; }
    public int BaseManpower { get => baseManpower; set => baseManpower = value; }
    public float LocalTaxIncome { get => localTaxIncome; set => localTaxIncome = value; }
    public float TaxIncomeEfficiency { get => taxIncomeEfficiency; set => taxIncomeEfficiency = value; }
    public float LocalManpowerIncrease { get => localManpowerIncrease; set => localManpowerIncrease = value; }
    public float LocalManpowerModifier { get => localManpowerModifier; set => localManpowerModifier = value; }
    public float ProductionEfficiencyModifiers { get => productionEfficiencyModifiers; set => productionEfficiencyModifiers = value; }
    public float Autonomy { get => autonomy; set => autonomy = value; }
    public string Religion { get => religion; set => religion = value; }
    public string Culture { get => culture; set => culture = value; }
    public float TaxIncome { get => taxIncome; set => taxIncome = value; }
    public float Manpower { get => manpower; set => manpower = value; }
    public float ProductionIncome { get => productionIncome; set => productionIncome = value; }
    public float GoodsProduced { get => goodsProduced; set => goodsProduced = value; }
    public float FlatGoodsProduced { get => flatGoodsProduced; set => flatGoodsProduced = value; }
    public float GoodsProducedModifiers { get => goodsProducedModifiers; set => goodsProducedModifiers = value; }
    public float TradeValue { get => tradeValue; set => tradeValue = value; }
    public float MarketPrice { get => marketPrice; set => marketPrice = value; }
    public string TradeGood { get => tradeGood; set => tradeGood = value; }
    public float EventPriceModifiers { get => eventPriceModifiers; set => eventPriceModifiers = value; }
    public float Devastation { get => devastation; set => devastation = value; }
    public float Loot { get => loot; set => loot = value; }
    public float Unrest { get => unrest; set => unrest = value; }
    public float TotalDevelopment { get => totalDevelopment; set => totalDevelopment = value; }
    public float DevelopmentCost { get => developmentCost; set => developmentCost = value; }
    public float DevelopmentEfficiency { get => developmentEfficiency; set => developmentEfficiency = value; }
    public float AdditionalDevelopmentModifiers { get => additionalDevelopmentModifiers; set => additionalDevelopmentModifiers = value; }
    public float ArmiesInQueue { get => armiesInQueue; set => armiesInQueue = value; }
    public float NaviesInQueue { get => naviesInQueue; set => naviesInQueue = value; }
    public float SupplyLimit { get => supplyLimit; set => supplyLimit = value; }
    public float Sailors { get => sailors; set => sailors = value; }
    public float WarScore { get => warScore; set => warScore = value; }
    public float FortLevel { get => fortLevel; set => fortLevel = value; }
    public float FortDefense { get => fortDefense; set => fortDefense = value; }
    public float Garrison { get => garrison; set => garrison = value; }
    public float TradePower { get => tradePower; set => tradePower = value; }
}
