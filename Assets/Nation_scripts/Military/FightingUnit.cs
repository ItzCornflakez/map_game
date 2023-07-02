
using System;
using System.Collections.Generic;
using TMPro;

[Serializable]
public class FightingUnit 
{

    public float MenCount { get; set; }
    public float Morale { get; set; }
    public float Dicipline { get; set; }
    public float AttackSpeed { get; set; }
    public List<UnitBonus> Bonuses { get; set; }
    public String UnitType { get; set; }
    public float WalkingSpeed { get; set; }
    public float EmbarkSpeed { get; set; }



    public FightingUnit(float menCount, float morale, float dicipline, float attackSpeed, List<UnitBonus> bonuses, String unitType, float walkingSpeed, float embarkSpeed) 
    {
        this.MenCount = menCount;
        this.Morale = morale;
        this.Dicipline = dicipline;
        this.AttackSpeed = attackSpeed;
        this.Bonuses = bonuses;
        this.UnitType = unitType;
        this.WalkingSpeed = walkingSpeed;
        this.EmbarkSpeed = embarkSpeed;
    }

}
