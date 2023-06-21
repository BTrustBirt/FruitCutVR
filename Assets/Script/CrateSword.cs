using UnityEngine;

public class CrateSword : MonoBehaviour
{
    [SerializeField]
    private GameObject swordPrefab;

    private GameObject sword;

    [SerializeField]
    private Transform spawnPoint;

    [SerializeField]
    private Sword swordObject;

    public Sword GetSword()
    {
        if (swordObject != null)
        {
            return swordObject;
        }

        return null;
    }

    public void ResetSwordTransform(GameMenager value)
    {
        if (sword != null)
        {
            Destroy(sword);
            sword = null;
        }

        sword =  Instantiate(swordPrefab, spawnPoint.transform.position, spawnPoint.transform.rotation, null);
        swordObject = sword.GetComponentInChildren<Sword>();
        swordObject.GetGameMenager(value);
        swordPrefab.SetActive(true);
    }
}
