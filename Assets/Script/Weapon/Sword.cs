using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    private float strong;

    private bool isHold;

    [SerializeField]
    private Transform tipPosition;

    [field:SerializeField]
    public float minSpeed { get; private set; }

    private Vector3 previoousPosition;

    private GameMenager gameMenager;

    // Ustawia flagê okreœlaj¹c¹, czy miecz jest trzymany
    public void Hold(bool value)
    {
        isHold= value;
    }

    public void GetGameMenager(GameMenager value)
    {
        gameMenager = value;
    }

    private void FixedUpdate()
    {
        if (isHold)
        {
            Vector3 correntPosition = tipPosition.position;
            Vector3 shiftSword = correntPosition - previoousPosition;

            float speed = shiftSword.magnitude / Time.deltaTime;  // Oblicz szybkoœæ wzglêdn¹ obiektu dziecka

            if (speed > minSpeed)
            {
                strong = speed;
            }
            else
            {
                //strong = 0;
            }

            previoousPosition = correntPosition;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Fruits")
        {
            other.GetComponent<IFruits>().Use(strong);

            if (strong > 0)
            {
                gameMenager.Cutting(strong);
            }
                      
        }
    }
}
