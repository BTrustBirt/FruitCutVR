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

    public int actualRound { get; private set; }

    private int[] roundScore;

    [SerializeField]
    private float timeRound = 10f;

    [SerializeField]
    private int roundTimeScale;

    [SerializeField]
    private GameObject RoundOne;

    private void Start()
    {
        roundScore = new int[3];
        spawner.IsRoundRun = false;
        actualRound = 0;
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
        return roundScore[actualRound] + poowerHit;
    }

    // Rozpoczyna ponownie grê

    public void NextRound(int round)
    {
        actualRound = round-1;
        spawner.IsRoundRun = true;
        uiMenager.ShowRound(actualRound.ToString());
        StartRound();
        CalculateAllAcore();

        //if (actualRound == roundScore.Length)
        //{
        //    actualRound = 0;
        //    spawner.IsRoundRun = false;
        //    uiMenager.ShowRound("Game Over");
        //    CalculateAllAcore();
        //    StopAllCoroutines();
        //}
        //else
        //{
        //    spawner.IsRoundRun = true;
        //    uiMenager.ShowRound(actualRound.ToString());
        //    StartRound();
        //}
    }

    public void StartGame()
    {
        if (actualRound < roundScore.Length)
        {
            RoundOne.SetActive(true);
        }
        else
        {
            //Restart game
            for (int i = 0; i < roundScore.Length; i++)
            {
                roundScore[i] = 0;
            }
            uiMenager.CleanGame();
            actualRound = 1;
            spawner.IsRoundRun = true;
            uiMenager.ShowRound(actualRound.ToString());
            StartRound();
            for (int i = 0; i < roundScore.Length; i++)
            {
                roundScore[i] = 0;
            }
        }

    }

    private void CalculateAllAcore()
    {
        int tempScore = 0;
        for (int i = 0; i < roundScore.Length; i++)
        {
            tempScore =+ roundScore[i];
        }

        //uiMenager.GameOver(tempScore);
    }

    private void StopRound()
    {
        spawner.IsRoundRun= false;
        StopAllCoroutines();
    }

    // Rozpoczyna now¹ rundê
    public void StartRound()
    {
        spawner.StartSpawn(timeRound / 10);
        StartCoroutine(GameRound(timeRound * roundTimeScale * actualRound));
    }

    // Wywo³ywane przy ciêciu

    public void Cutting(float baseSpeed)
    {
        int power = (int)baseSpeed + player.Strenght + player.Accuracy;

        uiMenager.RoundTurn( power, HitCalculate(power));
    }

    // Coroutine dla rundy gry
    IEnumerator GameRound(float delay)
    {
        float currentTime = delay;
        
        while (currentTime > 0)
        {
            // Aktualizacja wartoœci w UI
            int minutes = Mathf.FloorToInt(currentTime / 60);
            int seconds = Mathf.FloorToInt(currentTime % 60);
            
            yield return new WaitForSeconds(1f); // Poczekaj 1 sekundê

            // Odliczanie czasu
            currentTime -= 1f;
            uiMenager.ShowTimer(minutes,seconds);
        }

        uiMenager.ShowTimer(0, 0);
        StopRound();
        uiMenager.ShowRound("Press to next Round");
    }
}
