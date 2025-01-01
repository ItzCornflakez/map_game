
using System;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;

public class Army
{

    public int ArmyId { get; set; }
    public string ArmyName { get; set; }
    public List<FightingUnit> InfantryCollumb { get; set; }
    public List<FightingUnit> HorsemenCollumb { get; set; }
    public List<FightingUnit> ArtilleryCollumb { get; set; }
    public List<ArmyBonus> ArmyBonuses { get; set; }


    public Army(int armyId, String armyName, List<FightingUnit> infantryCollumb, List<FightingUnit> horsemenCollumb, List<FightingUnit> artilleryCollumb, List<ArmyBonus> armyBonuses)
    {
        this.ArmyId = armyId;
        this.ArmyName = armyName;
        this.InfantryCollumb = infantryCollumb;
        this.HorsemenCollumb = horsemenCollumb;
        this.ArtilleryCollumb = artilleryCollumb; 
        this.ArmyBonuses = armyBonuses;
    }

}
