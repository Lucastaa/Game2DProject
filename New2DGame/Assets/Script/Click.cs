using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
public class Click : MonoBehaviour
{
    private int money = 10000;

    public bool isSpin = false;
    public float rotationSpeed = 1000f;
    public float deceleration = 400f;
    public TMP_Text spinResultText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Chưa dừng được
        if (isSpin == true)
        {
            transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);

            rotationSpeed -= deceleration * Time.deltaTime;

            if (rotationSpeed <= 0)
            {
                rotationSpeed = 0;
                isSpin = false;
                GetReward();

            }
        }
        //Debug.Log(transform.eulerAngles.z);
        spinResultText.text = transform.rotation.eulerAngles.z.ToString();
        
    }
    public void GetReward()
    {
        float rot = transform.rotation.eulerAngles.z;

        if (rot > 0 && rot <= 45f)
        {
            Win(100);
        }
        else if (rot > 45f && rot <= 90f)
        {
            Win(500);
        }
        else if (rot > 90f && rot <= 135f)
        {
            Win(100);
        }
        else if (rot > 135f && rot <= 180f)
        {
            Win(100);
        }
        else if (rot > 180f && rot <= 225f)
        {
            Win(200);
        }
        else if (rot > 225f && rot <= 270f)
        {
            Win(100);
        }
        else if (rot > 270f && rot <= 315f)
        {
            Win(200);
        }
        else if (rot > 315 && rot <= 360f)
        {
            Win(300);
        }
    }    
    public void Win(int reward)
    {
        money += reward;
        Debug.Log("You win: " + reward + " Money left: " + money);
    }
    public void Button()
    {
        Debug.Log("Button clicked!");
        money -= 5000;
        Debug.Log("Money left: " + money);
        rotationSpeed = Random.Range(1000f, 1800.0f);
        isSpin = true;
    }
}
