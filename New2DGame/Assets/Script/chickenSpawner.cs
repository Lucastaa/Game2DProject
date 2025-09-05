using UnityEngine;

public class chickenSpawner : MonoBehaviour
{
    void Start()
    {
        float delayStartTime = Random.Range(2f, 5f);
        InvokeRepeating("SpawnChicken", 0f, 2f);
    }
    void SpawnChicken()
    {
        var chicken = Resources.Load<GameObject>("redChicken");
        Instantiate(chicken, transform.position, Quaternion.Euler(0, 0, 0));
    }
    void OnDisable()
    {
        CancelInvoke("SpawnChicken");
    }
}
