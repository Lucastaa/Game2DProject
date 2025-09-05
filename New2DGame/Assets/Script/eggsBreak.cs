using UnityEngine;

public class eggsBreak : MonoBehaviour
{
    public Animator aim;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Break")
        {
            aim.SetBool("Break", true);
            Destroy(gameObject, 0.5f);
        }
    }
}
