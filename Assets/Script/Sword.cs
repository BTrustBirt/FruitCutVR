using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    [HideInInspector]
    public float strong;

    public bool isHold;

    [SerializeField]
    private Transform tipPosition;

    public float minSpeed = 10f;

    private Vector3 previoousPosition;

    private GameMenager gameMenager;

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
                Debug.Log(speed + "Przekroczono minimaln¹ wartoœæ szybkoœci obiektu dziecka!");
            }

            // Zapisz bie¿¹c¹ pozycjê jako poprzedni¹ pozycjê na potrzeby kolejnej aktualizacji
            previoousPosition = correntPosition;
           // Debug.Log(speed + "  pprzed si³a");
        }
    }

    


}
