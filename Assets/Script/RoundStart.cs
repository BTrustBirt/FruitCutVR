using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundStart : MonoBehaviour
{
    [SerializeField]
    int round;

    [SerializeField]
    private GameMenager gameMenager;

    [SerializeField]
    private GameObject nextRound;

    private void OnEnable()
    {
        if (nextRound != null)
        {
            nextRound.SetActive(true);
            nextRound.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            gameMenager.NextRound(round);
            if (nextRound != null)
            {
                nextRound.SetActive(true);
            }

            gameObject.SetActive(false);
        }
    }
}
