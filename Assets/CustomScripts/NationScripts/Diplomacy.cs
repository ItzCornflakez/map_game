using System;
using System.Collections.Generic;

public class Relation
{
    private int nationId;
    private int relation;

    public Relation(int nationId, int relation)
    {
        this.nationId = nationId;
        this.relation = relation;
    }
}


public class Diplomacy
{

    private int maxRelations;
    private List<Relation> relationList;
    private List<Relation> aggressiveExpansion;

    public Diplomacy(int maxRelations, List<Relation> relationList, List<Relation> aggressiveExpansion)
    {

        this.maxRelations = maxRelations;
        this.relationList = relationList;
        this.aggressiveExpansion = aggressiveExpansion;
    }
}