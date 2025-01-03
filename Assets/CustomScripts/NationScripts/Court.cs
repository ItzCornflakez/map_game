using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Court
{
    private Leader ruler;
    private Leader heir;
    private Leader consort;

    private Advisor admAdvisor;
    private Advisor dipAdvisor;
    private Advisor milAdvisor;

    private GameObject ui;

    public Court(Leader ruler, Leader heir, Leader consort)
    {
        this.ruler = ruler;
        this.heir = heir;
        this.consort = consort;
        this.admAdvisor = null;
        this.dipAdvisor = null;
        this.milAdvisor = null;
    }

    public Leader Ruler { get => ruler; set => ruler = value; }
    public Leader Heir { get => heir; set => heir = value; }
    public Leader Consort { get => consort; set => consort = value; }
    public Advisor AdmAdvisor { get => admAdvisor; set => admAdvisor = value; }
    public Advisor DipAdvisor { get => dipAdvisor; set => dipAdvisor = value; }
    public Advisor MilAdvisor { get => milAdvisor; set => milAdvisor = value; }
    public GameObject UI { get => ui; set => ui = value; }
}
