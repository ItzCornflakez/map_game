using System.Collections.Generic;
public class Advisor{

    private string name;
    private int age;
    private int level;
    private float cost;

    private List<string> modifiers;

    public Advisor(string name, int age, int level, float cost, List<string> modifiers){
        this.name = name;
        this.age = age;
        this.level = level;
        this.cost = cost;
        this.modifiers = modifiers;

    }

}