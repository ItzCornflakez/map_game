using System;
using UnityEngine;

public class UIElementWithEvents : MonoBehaviour{

    public static event Action<UIElementWithEvents> UIElementEntered;
    
}