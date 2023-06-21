using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public void CreatSword()
    {
        crateSword.ResetSwordTransform(this);

        //if (sword != null)
        //{
        //    sword = null;
        //    return;
        //}

        //sword = crateSword.GetSword();

    }

    public Player GetPlayer()
    {
        return player;
    }

    public void Cutting(float baseSpeed)
    {
        float power = baseSpeed + player.Strenght + player.Accuracy;



        //TODO uiRepresentation
    }
}
