using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Court
{

    private Leader ruler;
    private Leader heir;

    private Leader consort;

    private Advisor admAdvisor, dipAdvisor, milAdvisor;

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

    public Leader getRuler() { return this.ruler; }
    public Leader getHeir() { return this.heir; }
    public Leader getConsort() { return this.consort; }


}