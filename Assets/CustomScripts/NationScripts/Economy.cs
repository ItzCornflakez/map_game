
using System;
using System.Collections.Generic;

public class Economy
{
    private float money;

    // Income
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

    // Expenses
    private float advisors;
    private float stateMaintance;
    private float interest;
    private float diplomaticRelations;
    private float fortMaintance;
    private float colonialMaintance;
    private float missionariesMaintance;
    private float rootOutCorruption;
    private float armyMaintance;
    private float fleetMaintance;

    private float inflation;

    private List<Province> provinces;

    private float nationalTaxIncome;

    private float taxIncomeEfficiency;
    private float productionEfficiency;
    private float tradeEfficiency;

    public Economy(float money, float inflation, List<Province> provinces)
    {
        this.money = money;
        this.provinces = provinces;
        this.taxation = SumOfProvinceTaxes(this.provinces) + nationalTaxIncome;
        this.production = SumOfProvinceProduction(this.provinces);
        this.trade = 0; // Fix
        this.gold = 0;
        this.harborFees = 0;
        this.subsidies = 0;
        this.spoilsOfWar = 0;
        this.warReparations = 0;
        this.condottieri = 0;
        this.knowledgeSharing = 0;
        this.inflation = inflation;
        this.advisors = 0;
        this.stateMaintance = 0;
        this.interest = 0;
        this.diplomaticRelations = 0;
        this.fortMaintance = 0;
        this.colonialMaintance = 0;
        this.missionariesMaintance = 0;
        this.rootOutCorruption = 0;
        this.armyMaintance = 0;
        this.fleetMaintance = 0;

        this.taxIncomeEfficiency = 0.2f;
        this.productionEfficiency = 0.5f;
        this.tradeEfficiency = 0;
    }

    private float SumOfProvinceTaxes(List<Province> provinces)
    {
        float totalTaxation = 0;
        foreach (var province in provinces)
        {
            totalTaxation += province.TaxIncome;
        }
        return totalTaxation;
    }

    private float SumOfProvinceProduction(List<Province> provinces)
    {
        float totalProduction = 0;
        foreach (var province in provinces)
        {
            totalProduction += province.ProductionIncome;
        }
        return totalProduction;
    }

    public float Money { get => money; set => money = value; }
    public float Taxation { get => taxation; set => taxation = value; }
    public float Production { get => production; set => production = value; }
    public float Trade { get => trade; set => trade = value; }
    public float Gold { get => gold; set => gold = value; }
    public float HarborFees { get => harborFees; set => harborFees = value; }
    public float Subsidies { get => subsidies; set => subsidies = value; }
    public float SpoilsOfWar { get => spoilsOfWar; set => spoilsOfWar = value; }
    public float WarReparations { get => warReparations; set => warReparations = value; }
    public float Condottieri { get => condottieri; set => condottieri = value; }
    public float KnowledgeSharing { get => knowledgeSharing; set => knowledgeSharing = value; }
    public float Advisors { get => advisors; set => advisors = value; }
    public float StateMaintance { get => stateMaintance; set => stateMaintance = value; }
    public float Interest { get => interest; set => interest = value; }
    public float DiplomaticRelations { get => diplomaticRelations; set => diplomaticRelations = value; }
    public float FortMaintance { get => fortMaintance; set => fortMaintance = value; }
    public float ColonialMaintance { get => colonialMaintance; set => colonialMaintance = value; }
    public float MissionariesMaintance { get => missionariesMaintance; set => missionariesMaintance = value; }
    public float RootOutCorruption { get => rootOutCorruption; set => rootOutCorruption = value; }
    public float ArmyMaintance { get => armyMaintance; set => armyMaintance = value; }
    public float FleetMaintance { get => fleetMaintance; set => fleetMaintance = value; }
    public float Inflation { get => inflation; set => inflation = value; }
    public List<Province> Provinces { get => provinces; set => provinces = value; }
    public float NationalTaxIncome { get => nationalTaxIncome; set => nationalTaxIncome = value; }
    public float TaxIncomeEfficiency { get => taxIncomeEfficiency; set => taxIncomeEfficiency = value; }
    public float ProductionEfficiency { get => productionEfficiency; set => productionEfficiency = value; }
    public float TradeEfficiency { get => tradeEfficiency; set => tradeEfficiency = value; }
}