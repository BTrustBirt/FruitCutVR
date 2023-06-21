using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<GameObject> pooledObjects;
    public GameObject[] objectToPool;
    public int amountToPool;
    private int count = 0;
    [SerializeField]
    private GameMenager gameMenager;
    [SerializeField]
    private Transform SpawnPoint;

    void Start()
    {
        pooledObjects = new List<GameObject>();
        GameObject tmp;
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject tempObject = GetObjectToPool();

            tmp = Instantiate(tempObject);
            tmp.SetActive(false);
            tmp.GetComponent<IFruits>().SetGameMenager(gameMenager);
            pooledObjects.Add(tmp);
            count++;
        }

        StartCoroutine(SpawnFruits());

    }

    private GameObject GetObjectToPool()
    {
        GameObject tempObject;

        if (count >= objectToPool.Length-1)
        {
            count= 0;
        }

        return tempObject = objectToPool[count];
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                pooledObjects[i].SetActive(true);
                return pooledObjects[i];
            }
        }

        GameObject tempObject = objectToPool[Random.RandomRange(0, objectToPool.Length - 1)];

        GameObject tmp = Instantiate(tempObject);
        tmp.SetActive(true);
        tmp.GetComponent<IFruits>().SetGameMenager(gameMenager);
        pooledObjects.Add(tmp);

        return tmp;
    }

    IEnumerator SpawnFruits()
    {
        while (true)
        {
            yield return new WaitForSeconds(2f);
            GetPooledObject().transform.position = SpawnPoint.position;
        }
    }

    
}
