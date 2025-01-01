
using System;
using System.Collections.Generic;

public class Economy{

    private float money;

    //Income
    private float taxation;
    private float production;
    private float trade;
    private float gold;
    private float harborFees;
    private float subsidies;
    private float spoilsOfWar;
    private float warReparations;
    private float condottieri;
    private float knowledgeSharing;


    //Expenses
    private float advisors;
    private float stateMaintance;
    private float interest;
    private float diplomaticRelations;
    private float fortMaintance;
    private float colonialMaintance;
    private float missionariesMaintance;
    private float RootOutCorruption;
    private float armyMaintance;
    private float fleetMaintance;

    private float inflation;

    private List<Province> provinces;

    private float nationalTaxIncome;

    private float taxIncomeEfficiency;
    private float productionEfficiency;
    private float tradeEfficiency;

    public Economy(float money, List<Province> provinces){
        
        this.money = money;
        this.provinces = provinces;
        this.taxation = sumOfProvinceTaxes(this.provinces) + nationalTaxIncome;
        this.production = sumOfProvinceProduction(this.provinces);
        this.trade = 0; //Fix
        this.gold = 0;
        this.harborFees = 0;
        this.subsidies = 0;
        this.spoilsOfWar = 0;
        this.warReparations = 0;
        this.condottieri = 0;
        this.knowledgeSharing = 0;
        this.inflation = 0;
        this.advisors = 0;
        this.stateMaintance = 0;
        this.interest = 0;
        this.diplomaticRelations = 0;
        this.fortMaintance = 0;
        this.colonialMaintance = 0;
        this.missionariesMaintance = 0;
        this.RootOutCorruption = 0;
        this.armyMaintance = 0;
        this.fleetMaintance = 0;

        this.taxIncomeEfficiency = 0.2f;
        this.productionEfficiency = 0.5f;
        this.tradeEfficiency = 0;

    }
    private float sumOfProvinceTaxes(List<Province> provinces){
        float totalTaxation = 0;
        for(int i = 0; i < provinces.Count; i++){
            totalTaxation += provinces[i].getProvincialTaxIncome();
        }
        return totalTaxation;
    }
    private float sumOfProvinceProduction(List<Province> provinces){
        float totalProduction = 0;
        for(int i = 0; i < provinces.Count; i++){
            totalProduction += provinces[i].getProvincialProductionIncome();
        }
        return totalProduction;
    }
    public float getTaxation(){return this.taxation;}
    public float getTaxIncomeEfficiency(){return this.taxIncomeEfficiency;}
    public float getProduction(){return this.production;}
    public float getProductionEfficiency(){return this.productionEfficiency;}
}