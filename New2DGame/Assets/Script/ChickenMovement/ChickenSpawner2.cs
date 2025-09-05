using UnityEngine;

public class ChickenSpawner2 : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int rows = 2;           
    public int cols = 6;           
    public float spacingX = 1.5f;   
    public float spacingY = 1.5f;  
    public Vector2 startPos = new Vector2(-4f, 2f);

    void Start()
    {
        SpawnEnemies();
    }

    void SpawnEnemies()
    {
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                Vector2 spawnPos = new Vector2(
                    startPos.x + col * spacingX,
                    startPos.y - row * spacingY
                );
                Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
            }
        }
    }
}