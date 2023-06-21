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
        //gameObject.SetActive(true);
        foreach (GameObject item in cuttinObject)
        {
            item.SetActive(false);
        }
        Invoke(nameof(DestroyObject), 3f);
    }


    public void SetGameMenager(GameMenager gm)
    {
        gameMenager = gm;
    }



    public void Use(float value)
    {
        gameMenager.Cutting(value);
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
            rb.AddTorque(Vector3.up);

            tempVelocity.x = Random.RandomRange(value / 2, value * 2);

            rb.velocity = tempVelocity;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Sword")
        {
            Use(other.GetComponent<Sword>().strong);
        }
    }

    private void DestroyObject()
    {
        foreach (GameObject item in cuttinObject)
        {

            item.SetActive(false);
            item.GetComponent<Rigidbody>().useGravity = false;
            item.GetComponent<Transform>().localPosition = Vector3.zero;
        }
        gameObject.SetActive(false);
        renderer.enabled = true;
        
    }
}
