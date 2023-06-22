using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using TMPro;
using UnityEngine;

public class UiMenager : MonoBehaviour
{
    [SerializeField]
    private TextMeshPro round1Text;

    [SerializeField]
    private TextMeshPro round2Text;
    
    [SerializeField]
    private TextMeshPro round3Text;

    [SerializeField]
    private TextMeshPro AllScoreText;

    [SerializeField]
    private TextMeshPro damageStrong;

    public void PowerShowText(int value)
    {
        damageStrong.text = value.ToString();
        
        Invoke(nameof(CleanBoardDamage),0.5f);
    }

    public void RoundTurn(int round, int strong,int sumRound)
    {
        round1Text.text = "";
        round2Text.text = "";
        round3Text.text = "";
        damageStrong.text = "";

        switch (round)
        {
            case 1: 
                PowerShowText(strong);
                round1Text.text = sumRound.ToString();
                break;
            case 2:
                PowerShowText(strong);
                round2Text.text = sumRound.ToString();
                break;
            case 3:
                PowerShowText(strong); 
                round3Text.text = sumRound.ToString();
                break;
            default:
                break;
        }
    }

    public void GameOver(int value)
    {
        AllScoreText.text = value.ToString();
    }

    public void CleanGame()
    {
        round1Text.text = "";
        round2Text.text = "";
        round3Text.text = "";
        damageStrong.text = "";
    }

    private void CleanBoardDamage()
    {
        damageStrong.text = "";
    }
}
