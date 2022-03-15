using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Province{

    private int provinceId;
    private string provinceName;
    private string provinceDescription;
    private int baseTax;
    private int baseProduction;
    private int baseManpower1;
    private int baseManpower2;
    private float localTaxIncome;
    private float taxIncomeEfficiency;
    private float localManpowerIncrease;
    private float localManpowerModifier;
    private float productionEfficiencyModifiers;
    private float autonomy;
    private string religion;
    private string culture;

    private float provincialTaxIncome;
    private float provinceManpower;
    private float provinceProductionIncome;

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

    private float development;
    private float developmentCost;
    private float developmentEfficiency;
    private float additionalDevelopmentModifiers;

    private float armiesInQueue;
    private float naviesInQueue;

    private float supplyLimit;
    private float sailors;
    private float provinceWarScore;
    private float fortLevel;
    private float fortDefense;
    private float garrison;
    private float tradePower;

    private Dictionary<string, float> tradeGoodDict;
    

    public Province(int provinceId, string provinceName, string provinceDescription, int baseTax, int baseProduction, int baseManpower1, float autonomy,
     string religion, string culture, string tradeGood){
        
        this.provinceId = provinceId;
        this.provinceName = provinceName;
        this.provinceDescription = provinceDescription;
        this.baseTax = baseTax;
        this.baseProduction = baseProduction;
        this.baseManpower1 = baseManpower1;
        this.baseManpower2 = this.baseManpower1*250;
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

        this.development = this.baseTax + this.baseProduction + this.baseManpower1;
        this.developmentEfficiency = 0;
        if(this.development > 9){this.additionalDevelopmentModifiers = 1.0f + ((this.development - 9) * 0.03f);}
        else{this.additionalDevelopmentModifiers = 1;}
        this.developmentCost = 50 * (1.0f - this.developmentEfficiency) * this.additionalDevelopmentModifiers;

        initializeTradeGoodDict();

        foreach(KeyValuePair<string, float> entry in tradeGoodDict){
            if(entry.Key == this.tradeGood){
                this.marketPrice = entry.Value;
            }
        }

        this.supplyLimit = 0;
        this.sailors = 0;
        this.provinceWarScore = 0;
        this.fortLevel = 0;
        this.fortDefense = 0;
        this.garrison = 0;
        this.tradePower = 0;
        
        updateProvinceData();
        

    }
    public void updateProvinceData(){
        this.provincialTaxIncome = ((this.baseTax + this.localTaxIncome) / 12) * this.taxIncomeEfficiency * (1 - this.autonomy);
        this.provinceManpower = (this.baseManpower2 + this.localManpowerIncrease) * (1 + this.localManpowerModifier) * (1-this.autonomy);

        this.goodsProduced = ((this.baseProduction * (float)0.2) + this.flatGoodsProduced) * (1 + this.goodsProducedModifiers);
        this.tradeValue = this.marketPrice * (1 + this.eventPriceModifiers) * this.goodsProduced; 
        this.provinceProductionIncome = (1 + this.productionEfficiencyModifiers) * (1 - this.autonomy) * this.tradeValue;
    }

    public void initializeTradeGoodDict(){
        this.tradeGoodDict = new Dictionary<string, float>();
        this.tradeGoodDict.Add("Cloth", 3.0f);
        this.tradeGoodDict.Add("Fish", 2.5f);
    }
    public int getProvinceId(){return this.provinceId;}
    public string getProvinceName(){return this.provinceName;}
    public int getTaxDev(){return this.baseTax;}
    public int getProdDev(){return this.baseProduction;}
    public int getManDev(){return this.baseManpower1;}
    public float getDev(){return this.development;}
    public float getDevCost(){return this.developmentCost;}
    public float getProvincialTaxIncome(){return this.provincialTaxIncome;}
    public float getTaxIncomeEfficiency(){return this.taxIncomeEfficiency;}
    public float getProvincialProductionIncome(){return this.provinceProductionIncome;}
    public float getProductionEfficiency(){return this.productionEfficiencyModifiers;}
    public float getDevastation(){return this.devastation;}
    public float getLoot(){return this.loot;}
    public float getUnrest(){return this.unrest;}
    public float getAutonomy(){return this.autonomy;}
    public string getCulture(){return this.culture;}
    public string getReligion(){return this.religion;}
    public float getArmiesInQueue(){return this.armiesInQueue;}
    public float getNaviesInQueue(){return this.naviesInQueue;}
    public float getManpower(){return this.provinceManpower;}
    public float getSupplyLimit(){return this.supplyLimit;}
    public float getSailors(){return this.sailors;}
    public float getProvinceWarScore(){return this.provinceWarScore;}
    public float getFortLevel(){return this.fortLevel;}
    public float getFortDefense(){return this.fortDefense;}
    public float getGarrison(){return this.garrison;}
    public float getTradePower(){return this.tradePower;}
    public float getTradeValue(){return this.tradeValue;}
    public float getGoodsProduced(){return this.goodsProduced;}
    public string getTradeGood(){return this.tradeGood;}
    public float getMarketPrice(){return this.marketPrice;}

}