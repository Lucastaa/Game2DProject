using UnityEngine;

public class EggsSpawner : MonoBehaviour
{
    public GameObject eggsPrefab;
    public Transform chickenTransform;
    public float speed = 5.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        float delayStartTime = Random.Range(2f, 5f);
        InvokeRepeating("DropEgg", 0f, 5f);
    }

    void Update()
    {
        
    }

    // Update is called once per frame
    void DropEgg()
    {
        var eggs = Instantiate(eggsPrefab, chickenTransform.position, Quaternion.identity);
        
        eggs.GetComponent<Rigidbody2D>().linearVelocity = Vector2.down;
        if (transform.position.y < -3)
        {
            Destroy(eggs);
        }
    }
}
