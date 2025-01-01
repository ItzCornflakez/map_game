using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class LoadGameInfo : MonoBehaviour{

    // Start is called before the first frame update

    private List<Province> provinceList;

    void Start(){

        provinceList = new List<Province>();

        GameObject[] provincesObjs = GameObject.FindGameObjectsWithTag("Province");
        for(int i = 0; i < provincesObjs.Length; i++){
            Province province = provincesObjs[i].GetComponent<initializeProvince>().getProvince();
            provinceList.Add(province);
        }

    }

    public List<Province> getProvinces(){
        return provinceList;
    }

    // Update is called once per frame
    void Update(){
        
    }
}
