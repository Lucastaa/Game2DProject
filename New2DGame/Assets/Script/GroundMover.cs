using UnityEngine;

public class GroundMover : MonoBehaviour
{
    public float speed = 5f;
    public float resetPosition = -20f;
    public float startPosition = 20f;

    private GameObject[] grounds;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        grounds = GameObject.FindGameObjectsWithTag("Ground");
    }

    // Update is called once per frame
    void Update()
    {
        foreach(GameObject ground in grounds)
        {
            if (ground == null) continue;
            ground.transform.position += Vector3.left * speed * Time.deltaTime;

            if (ground.transform.position.x < resetPosition)
            {
                Vector3 pos = ground.transform.position;
                pos.x = startPosition;
                ground.transform.position = pos;
            }
        }
    }
}
