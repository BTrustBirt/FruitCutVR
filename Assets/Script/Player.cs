using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float strenght;

    public float Strenght
    {
        get { return strenght; } 
        set { strenght = value; }
    }

    private float accuracy;

    public float Accuracy 
    { 
        get { return accuracy; } 
        set {accuracy= value; } 
    }

      
}
