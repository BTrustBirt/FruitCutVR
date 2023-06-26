using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frut : MonoBehaviour, IFruits
{
    [SerializeField]
    private ParticleSystem particalSystem;

    private GameMenager gameMenager;

    [SerializeField]
    private MeshRenderer renderer;

    [SerializeField]
    private GameObject[] cuttinObject;

    private void OnEnable()
    {
        foreach (GameObject item in cuttinObject)
        {
            item.SetActive(false);
        }
        renderer.enabled = true;
        Invoke(nameof(DestroyObject), 3f);
        particalSystem.gameObject.SetActive(true);
        particalSystem.Stop();
        gameObject.GetComponent<Rigidbody>().velocity= Vector3.zero;
    }

    public void SetGameMenager(GameMenager gm)
    {
        gameMenager = gm;
    }

    public void Use(float value)
    {
        particalSystem.gameObject.SetActive(true);
        particalSystem.Play();

        Invoke(nameof(DestroyObject), 1f);

        Vector3 tempVelocity = new Vector3(Random.RandomRange(value / 2, value), Random.RandomRange( value / 2, value), Random.RandomRange( value / 2, value));
       
        renderer.enabled = false;
       
        foreach (GameObject item in cuttinObject)
        {
            Rigidbody rb;
            item.SetActive(true);
            rb =  item.GetComponent<Rigidbody>();
            rb.useGravity = true;
          
            tempVelocity.x = Random.RandomRange(value / 2, value * 2);

            rb.velocity = tempVelocity;
        }
    }

    private void DestroyObject()
    {
        Rigidbody rb;

        foreach (GameObject item in cuttinObject)
        {
            rb = item.GetComponent<Rigidbody>();
           
            rb.velocity = Vector3.zero;
            rb.useGravity = false;
            item.GetComponent<Transform>().localPosition = Vector3.zero;

            item.SetActive(false);
        }
        gameObject.SetActive(false);
        renderer.enabled = true;
    }
}
