using UnityEngine;

public class CrateSword : MonoBehaviour
{
    [SerializeField]
    private GameObject swordPrefab;

    private GameObject sword;

    [SerializeField]
    private Transform spawnPoint;

    public Sword ResetSwordTransform(GameMenager value)
    {
        if (sword != null)
        {
            Destroy(sword);
            sword = null;
        }

        sword =  Instantiate(swordPrefab, spawnPoint.transform.position, spawnPoint.transform.rotation, null);
        Sword sw = sword.GetComponentInChildren<Sword>();
        sw.GetGameMenager(value);

        return sw;
    }
}
