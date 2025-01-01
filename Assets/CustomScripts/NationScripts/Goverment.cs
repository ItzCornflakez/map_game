
using System.Collections.Generic;
using UnityEngine;
public class Goverment{

    private float reformProgress;

    private GameObject goverment;

    private List<string> acceptedCultures;
    private List<string> nonAcceptedCultures;

    public Goverment(GameObject goverment, List<string> acceptedCultures, List<string> nonAcceptedCultures){
        
        this.goverment = goverment;
        this.acceptedCultures = acceptedCultures;
        this.nonAcceptedCultures = nonAcceptedCultures;

    }
}