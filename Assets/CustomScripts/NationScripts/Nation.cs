
public class Nation
{
    private NationData nationData;
    private Court court;
    private Diplomacy diplomacy;
    private Military military;
    private Economy economy;
    private Religion religion;

    public Nation(NationData nationData, Court court, Diplomacy diplomacy, Military military, Economy economy, Religion religion)
    {
        this.nationData = nationData;
        this.court = court;
        this.military = military;
        this.diplomacy = diplomacy;
        this.economy = economy;
        this.religion = religion;
    }

    public NationData NationData { get => nationData; set => nationData = value; }
    public Court Court { get => court; set => court = value; }
    public Diplomacy Diplomacy { get => diplomacy; set => diplomacy = value; }
    public Military Military { get => military; set => military = value; }
    public Economy Economy { get => economy; set => economy = value; }
    public Religion Religion { get => religion; set => religion = value; }
}
