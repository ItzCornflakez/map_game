using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class initializeArmy : MonoBehaviour
{
    public int ArmyId;
    public string ArmyName;
    public List<int> FightingUnitCounts; 

    public Army Army { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        List<FightingUnit> infantryCollumb = new();
        for(int i = 0; i < FightingUnitCounts.ElementAt(0); i++)
        {
            FightingUnit fightingUnit = new(1000, 1.0f, 1.0f, 1.0f, null, "infantry", 1.0f, 1.0f);
            infantryCollumb.Add(fightingUnit);
        }
        List<FightingUnit> horsemenCollumb = new();
        for (int i = 0; i < FightingUnitCounts.ElementAt(1); i++)
        {
            FightingUnit fightingUnit = new(1000, 1.0f, 1.0f, 1.0f, null, "horsemen", 1.0f, 1.0f);
            horsemenCollumb.Add(fightingUnit);
        }
        List<FightingUnit> artilleryCollumb = new();
        for (int i = 0; i < FightingUnitCounts.ElementAt(2); i++)
        {
            FightingUnit fightingUnit = new(1000, 1.0f, 1.0f, 1.0f, null, "artillery", 1.0f, 1.0f);
            artilleryCollumb.Add(fightingUnit);
        }


        this.Army = new Army(this.ArmyId, this.ArmyName, infantryCollumb, horsemenCollumb, artilleryCollumb, null);

    }

    // Update is called once per frame

}
