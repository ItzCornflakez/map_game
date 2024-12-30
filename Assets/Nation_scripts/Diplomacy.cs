using System;
using System.Collections.Generic;

public class Diplomacy
{

    private int maxRelations;
    private List<string> relationList;
    private int aggressiveExpansion;

    public Diplomacy(int maxRelations, List<string> relationList, int aggressiveExpansion)
    {

        this.maxRelations = maxRelations;
        this.relationList = relationList;
        this.aggressiveExpansion = aggressiveExpansion;
    }
}