using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<GameObject> pooledObjects;
    
    public GameObject[] objectToPool;
 
    public bool IsRoundRun { get; set; }

    public int amountToPool;
    
    private int count = 0;
    
    [SerializeField]
    private GameMenager gameMenager;
    
    [SerializeField]
    private Transform[] SpawnPoint;

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
    }

    public void StartSpawn(float timeSpawn)
    {
        StartCoroutine(SpawnFruits(timeSpawn));
    }

    // Zwraca obiekt do puli
    private GameObject GetObjectToPool()
    {
        GameObject tempObject;

        if (count >= objectToPool.Length-1)
        {
            count= 0;
        }

        return tempObject = objectToPool[count];
    }

    // Zwraca obiekt z puli
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

    // Coroutine dla generowania owoców
    IEnumerator SpawnFruits(float time)
    {
        while (IsRoundRun)
        {
            yield return new WaitForSeconds(time);
            int randomSpawn = Random.RandomRange(0, SpawnPoint.Length - 1);
            GetPooledObject().transform.position = SpawnPoint[randomSpawn].position;
        }
    }
}
