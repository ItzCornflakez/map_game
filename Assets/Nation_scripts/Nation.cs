
public class Nation{

    private NationData nationData;
    private Court court;
    private Diplomacy diplomacy;
    private Military military;
    private Economy economy;
    private Religion religion;

    public Nation(NationData nationData, Court court, Diplomacy diplomacy, Military military, Economy economy, Religion religion){

        this.nationData = nationData;
        this.court = court;
        this.military = military;
        this.diplomacy = diplomacy;
        this.economy = economy;
        this.religion = religion;
        

    }
    public Economy getEconomy(){return this.economy;}
}