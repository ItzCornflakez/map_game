using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using Unity.VisualScripting;
using System.Linq;

public class updateUI : MonoBehaviour
{
    public GameObject gameManager;

    private Army army;

    public GameObject provinceUI;

    // Start is called before the first frame update
    void Start()
    {
        this.provinceUI.SetActive(false);
        this.UpdateCourtUI(gameManager.GetComponent<LoadGameInfo>().ActiveNation.Court);
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

    void UpdateCourtUI(Court court)
    {
        // Update Ruler UI
        UpdateText("RulerNameText", court.Ruler.Name);
        UpdateText("RulerAdmText", court.Ruler.AdmCapability.ToString());
        UpdateText("RulerDipText", court.Ruler.DipCapability.ToString());
        UpdateText("RulerMilText", court.Ruler.MilCapability.ToString());
        UpdateText("RulerModifiersText", stringOfModifiers(court.Ruler.Modifiers));
        UpdateText("RulerAgeText", court.Ruler.Age.ToString());

        // Update Heir UI
        UpdateText("HeirNameText", court.Heir.Name);
        UpdateText("HeirAdmText", court.Heir.AdmCapability.ToString());
        UpdateText("HeirDipText", court.Heir.DipCapability.ToString());
        UpdateText("HeirMilText", court.Heir.MilCapability.ToString());
        UpdateText("HeirModifiersText", stringOfModifiers(court.Heir.Modifiers));
        UpdateText("HeirAgeText", court.Heir.Age.ToString());

        // Update Consort UI
        UpdateText("ConsortNameText", court.Consort.Name);
        UpdateText("ConsortAdmText", court.Consort.AdmCapability.ToString());
        UpdateText("ConsortDipText", court.Consort.DipCapability.ToString());
        UpdateText("ConsortMilText", court.Consort.MilCapability.ToString());
        UpdateText("ConsortModifiersText", stringOfModifiers(court.Consort.Modifiers));
        UpdateText("ConsortAgeText", court.Consort.Age.ToString());
    }

    void UpdateEconomyUI(Economy economy)
    {
        // Update Economy UI
        UpdateText("TaxationText", economy.Taxation.ToString());
        UpdateText("TaxEfficiencyText", $"({economy.TaxIncomeEfficiency * 100}%)");
        UpdateText("ProductionText", economy.Production.ToString());
        UpdateText("ProductionEfficiencyText", $"({economy.ProductionEfficiency * 100}%)");
    }

    public void UpdateProvinceUI(Province province)
    {
        // Update Province UI
        UpdateText("CustomProvinceNameText", province.Name);
        UpdateText("ProvinceNameText", province.Name);
        UpdateText("ProvinceAreaText", "to be decided");
        UpdateText("ProvinceRegionText", "to be decided");
        UpdateText("ProvinceTaxDevText", province.CurrentTaxDevelopment.ToString());
        UpdateText("ProvinceProdDevText", province.CurrentProductionDevelopment.ToString());
        UpdateText("ProvinceManDevText", province.CurrentManpowerDevelopment.ToString());
        UpdateText("ProvinceTotalDevelopmentText", province.TotalDevelopment.ToString());
        UpdateText("ProvinceDevelopmentCostText", province.DevelopmentCost.ToString());
        UpdateText("ProvinceDevastationText", province.Devastation.ToString());
        UpdateText("ProvinceLootText", province.Loot.ToString());
        UpdateText("ProvinceTaxText", province.TaxIncome.ToString());
        UpdateText("ProvinceProductionText", province.ProductionIncome.ToString());
        UpdateText("ProvinceTotalText", (province.TaxIncome + province.ProductionIncome).ToString());
        UpdateText("ProvinceUnrestText", province.Unrest.ToString());
        UpdateText("ProvinceAutonomyText", province.Autonomy.ToString());
        UpdateText("ProvinceCultureText", province.Culture);
        UpdateText("ProvinceReligionText", province.Religion);
        UpdateText("ProvinceArmiesText", province.ArmiesInQueue.ToString());
        UpdateText("ProvinceNaviesText", province.NaviesInQueue.ToString());
        UpdateText("ProvinceManpowerText", province.Manpower.ToString());
        UpdateText("ProvinceSupplyLimitText", province.SupplyLimit.ToString());
        UpdateText("ProvinceSailorsText", province.Sailors.ToString());
        UpdateText("ProvinceWarScoreText", province.WarScore.ToString());
        UpdateText("ProvinceFortLevelText", province.FortLevel.ToString());
        UpdateText("ProvinceFortDefenseText", province.FortDefense.ToString());
        UpdateText("ProvinceGarrisonText", province.Garrison.ToString());
        UpdateText("ProvinceTradePowerText", province.TradePower.ToString());
        UpdateText("ProvinceTradeValueText", province.TradeValue.ToString());
        UpdateText("ProvinceGoodsProducedText", province.GoodsProduced.ToString());
        //UpdateText("ProvinceTradeGoodText", province.TradeGood);
        UpdateText("ProvinceTradeGoodText", "Wine");
        UpdateText("ProvinceMarketPriceText", province.MarketPrice.ToString());
    }

    public void UpdateMilitaryArmyUI(GameObject armyGameObject)
    {
        this.army = armyGameObject.GetComponent<initializeArmy>().Army;

        float armyInfantryCount = 0f;
        float armyHorsemenCount = 0f;
        float armyArtilleryCount = 0f;

        foreach (var infantry in this.army.InfantryCollumb)
        {
            armyInfantryCount += infantry.MenCount;
        }
        foreach (var horseman in this.army.HorsemenCollumb)
        {
            armyHorsemenCount += horseman.MenCount;
        }
        foreach (var artillery in this.army.ArtilleryCollumb)
        {
            armyArtilleryCount += artillery.MenCount;
        }

        // Update Army UI
        UpdateText("ArmyNameText", this.army.ArmyName);
        UpdateText("InfantryCountText", armyInfantryCount.ToString());
        UpdateText("HorsemenCountText", armyHorsemenCount.ToString());
        UpdateText("ArtilleryCountText", armyArtilleryCount.ToString());
        UpdateText("TotalArmyCountText", (armyInfantryCount + armyHorsemenCount + armyArtilleryCount).ToString());

        // Update detailed counts
        UpdateText("infantrySingleDigitCountText", this.army.InfantryCollumb.Count.ToString());
        UpdateText("infantryThousandCountText", armyInfantryCount.ToString());
        UpdateText("horsemenSingleDigitCountText", this.army.HorsemenCollumb.Count.ToString());
        UpdateText("horsemenThousandCountText", armyHorsemenCount.ToString());
        UpdateText("artillerySingleDigitCountText", this.army.ArtilleryCollumb.Count.ToString());
        UpdateText("artilleryThousandCountText", armyArtilleryCount.ToString());
    }

    public string stringOfModifiers(List<string> modifiers)
    {
        return string.Join(", ", modifiers);
    }
}
