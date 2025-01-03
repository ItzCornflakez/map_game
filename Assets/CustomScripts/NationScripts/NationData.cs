using System;
using System.Collections.Generic;

public class NationData
{
    private int id;
    private string name;
    private string hexColor;
    private string description;
    private List<Province> provinceList;

    public NationData(int id, string name, string hexColor, string description, List<Province> provinceList)
    {
        this.id = id;
        this.name = name;
        this.hexColor = hexColor;
        this.description = description;
        this.provinceList = provinceList;
    }

    public int Id { get => id; set => id = value; }
    public string Name { get => name; set => name = value; }
    public string HexColor { get => hexColor; set => hexColor = value; }
    public string Description { get => description; set => description = value; }
    public List<Province> ProvinceList { get => provinceList; set => provinceList = value; }
}