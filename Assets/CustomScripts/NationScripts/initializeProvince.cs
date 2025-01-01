using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class initializeProvince : MonoBehaviour{
    public int provinceId;
    public string provinceName;
    public string provinceDescription;
    public int baseTax;
    public int baseProduction;
    public int baseManpower;
    public float autonomy;
    public string religion;
    public string culture;
    public string tradeGood;

    private Province province;
    void Start(){
        this.province = new Province(this.provinceId, this.provinceName, this.provinceDescription, this.baseTax, this.baseProduction, this.baseManpower, this.autonomy,
         this.religion, this.culture, this.tradeGood);
    }

    public Province getProvince(){
        return this.province;
    }
}
