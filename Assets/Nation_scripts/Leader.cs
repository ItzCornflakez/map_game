using System.Collections.Generic;

public class Leader{


    private string typeOf;

    private string name;

    private string nickName;

    private int admCapability, dipCapability, milCapability;

    private int age;

    private List<string> skills;

    public Leader(string typeOf, string name, string nickName, int admCapability, int dipCapability, int milCapability, int age){
        this.typeOf = typeOf;
        this.name = name; 
        this.nickName = nickName;
        this.admCapability = admCapability;
        this.dipCapability = dipCapability;
        this.milCapability = milCapability;
        this.age = age;
        this.skills = new List<string>();
    } 
}