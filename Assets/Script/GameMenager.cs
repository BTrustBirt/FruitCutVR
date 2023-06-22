using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GameMenager : MonoBehaviour
{
    [SerializeField]
    private CrateSword crateSword;

    [SerializeField]
    private Player player;

    [SerializeField]
    private CuttingSystem cuttingSystem;

    [SerializeField]
    private UiMenager uiMenager;

    [SerializeField]
    private Spawner spawner;

    private Sword sword;

    [SerializeField]
    private int roundMax;

    private int actualRound = 0;

    private int[] roundScore;


    [SerializeField]
    private float timeRound = 10f;

    [SerializeField]
    private int roundTimeScale;

    private void Start()
    {
        roundScore = new int[roundMax];
        spawner.IsRoundRun = false;
    }

    // Tworzy miecz
    public void CreatSword()
    {
        if (sword != null)
        {
            sword = null;
            return;
        }

        sword = crateSword.ResetSwordTransform(this);
    }


    // Oblicza wynik trafienia
    private int HitCalculate(int poowerHit)
    {
        roundScore[actualRound] += poowerHit;
        return roundScore[actualRound - 1] + poowerHit;
    }

    // Rozpoczyna ponownie grê

    public void Restart()
    {
       if (actualRound < roundMax)
        {
            spawner.IsRoundRun = true;
            StartRound();
        }
        else
        {
            actualRound = 0;
            spawner.IsRoundRun = false;
            uiMenager.CleanGame();
            StopAllCoroutines();
        }
    }

    private void StopRound()
    {
        spawner.IsRoundRun= false;
        StopAllCoroutines();
    }

    // Rozpoczyna now¹ rundê
    public void StartRound()
    {

        if (actualRound == roundScore.Length)
        {
            StopRound();
            int allCsore = 0;

            for (int i = 0; i < roundScore.Length; i++)
            {
                allCsore += +roundScore[i];
            }
            uiMenager.GameOver(allCsore);
        }
        else
        {
            actualRound++;
            spawner.StartSpawn(timeRound / 10);
            StartCoroutine(GameRound(timeRound * roundTimeScale * actualRound));
        }
    }

    // Wywo³ywane przy ciêciu

    public void Cutting(float baseSpeed)
    {
        int power = (int)baseSpeed + player.Strenght + player.Accuracy;

        uiMenager.RoundTurn(actualRound, power, HitCalculate(power));
    }

    // Coroutine dla rundy gry
    IEnumerator GameRound(float delay)
    {
        
        yield return new WaitForSeconds(delay);
        StopRound();
    }
}
