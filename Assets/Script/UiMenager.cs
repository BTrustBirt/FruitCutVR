using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using TMPro;
using UnityEngine;

public class UiMenager : MonoBehaviour
{
    [SerializeField]
    private TextMeshPro roundScroe;

    [SerializeField]
    private TextMeshPro RoundNumber;
    
    [SerializeField]
    private TextMeshPro allSCore;

    [SerializeField]
    private TextMeshPro damageStrong;

    [SerializeField]
    private TextMeshPro time;
    public void PowerShowText(int value)
    {
        damageStrong.text = value.ToString();   
    }

    public void ShowRound(string runds)
    {
        RoundNumber.text = runds;
        damageStrong.text = "";
    }

    public void RoundTurn( int strong,int sumRound)
    {
        damageStrong.text = strong.ToString();
        roundScroe.text = sumRound.ToString();

    }

    public void GameOver(int value)
    {
        allSCore.text = value.ToString();
        
    }

    public void CleanGame()
    {
        damageStrong.text = "";
        allSCore.text = "";
        
    }

    public void ShowTimer(float minutes,float seconds)
    {
        time.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    private void CleanBoardDamage()
    {
        damageStrong.text = "";
    }
}
