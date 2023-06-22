using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int strenght;

    public int Strenght
    {
        get { return strenght; } 
        set { strenght = value; }
    }

    private int accuracy;

    public int Accuracy 
    { 
        get { return accuracy; } 
        set {accuracy= value; } 
    }

      
}
