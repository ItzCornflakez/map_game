public class Court{

    private Leader leader;
    private Leader heir;

    private Leader consert;

    private Advisor admAdvisor, dipAdvisor, milAdvisor;

    public Court(Leader leader, Leader heir, Leader consert){
        this.leader = leader;
        this.heir = heir;
        this.consert = consert;
        this.admAdvisor = null;
        this.dipAdvisor = null;
        this.milAdvisor = null;
    }


}