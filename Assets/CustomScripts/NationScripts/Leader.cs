using System.Collections.Generic;

public class Leader
{
    private string typeOf;
    private string name;
    private string nickName;
    private int admCapability;
    private int dipCapability;
    private int milCapability;
    private int age;
    private List<string> modifiers;

    public Leader(string typeOf, string name, string nickName, int admCapability, int dipCapability, int milCapability, int age)
    {
        this.typeOf = typeOf;
        this.name = name;
        this.nickName = nickName;
        this.admCapability = admCapability;
        this.dipCapability = dipCapability;
        this.milCapability = milCapability;
        this.age = age;
        this.modifiers = new List<string> { "Item1", "Item2" };
    }

    public string TypeOf { get => typeOf; set => typeOf = value; }
    public string Name { get => name; set => name = value; }
    public string NickName { get => nickName; set => nickName = value; }
    public int AdmCapability { get => admCapability; set => admCapability = value; }
    public int DipCapability { get => dipCapability; set => dipCapability = value; }
    public int MilCapability { get => milCapability; set => milCapability = value; }
    public int Age { get => age; set => age = value; }
    public List<string> Modifiers { get => modifiers; set => modifiers = value; }
}
