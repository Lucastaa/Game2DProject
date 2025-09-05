using UnityEngine;

public class GameEvent : MonoBehaviour
{
    public GameObject redBoss;
    public GameObject chickensSpawner;
    public int countChickens = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        redBoss.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        countChickens = GameObject.FindGameObjectsWithTag("Enemy").Length;
        if (countChickens == 0)
        {
            clearState();
        }
    }

    public void clearState()
    {
        chickensSpawner.SetActive(false);
        NextStage();
    }
    public void NextStage()
    {
        redBoss.SetActive(true);
    }
}
