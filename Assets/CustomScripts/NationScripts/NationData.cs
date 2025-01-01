using System;
using System.Collections.Generic;

public class NationData{

    private string nationName;
    private string description;
    private List<Province> provinceList;

    public NationData(string nationName, string description, List<Province> provinceList){
        
        this.nationName = nationName;
        this.description = description;
        this.provinceList = provinceList;

    }
}