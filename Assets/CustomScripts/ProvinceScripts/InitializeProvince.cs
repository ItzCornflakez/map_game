using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializeProvince : MonoBehaviour
{

    private Province province;

    /*
    public int id;
    public string name;
    public string description;
    public int baseTaxDevelopment;
    public int baseProductionDevelopment;
    public int baseManpowerDevelopment;
    public float autonomy;
    public string religion;
    public string culture;
    public string tradeGood;

    void Start()
    {
        this.province = new Province(this.id, this.name, this.description, this.baseTaxDevelopment, this.baseProductionDevelopment, this.baseManpowerDevelopment, this.autonomy,
         this.religion, this.culture, this.tradeGood);
    }
    */

    public Province Province { get => province; set => province = value; }
}