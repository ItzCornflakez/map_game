using System.Collections.Generic;

public class Leader{


    private string typeOf;

    private string name;

    private string nickName;

    private int admCapability, dipCapability, milCapability;

    private int age;

    private List<string> modifiers;

    public Leader(string typeOf, string name, string nickName, int admCapability, int dipCapability, int milCapability, int age){
        this.typeOf = typeOf;
        this.name = name; 
        this.nickName = nickName;
        this.admCapability = admCapability;
        this.dipCapability = dipCapability;
        this.milCapability = milCapability;
        this.age = age;
        this.modifiers = new List<string>();
        this.modifiers.Add("Item1");
        this.modifiers.Add("Item2");
    } 

    public string getLeaderName(){return this.name;}
    public int getAdmCapability(){return this.admCapability;}
    public int getDipCapbility(){return this.dipCapability;}
    public int getMilCapability(){return this.milCapability;}
    public List<string> getModifiers(){return this.modifiers;}
    public int getLeaderAge(){return this.age;}
}