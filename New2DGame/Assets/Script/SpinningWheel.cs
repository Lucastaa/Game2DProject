using UnityEngine;
using TMPro;
public class SpinningWheel : MonoBehaviour
{
    public int money = 10;
    public float rotationSpeed = 1000f;
    public float deceleration = 400f;


    public bool isSpinning = false;

    public TMP_Text spinResultText;
    public TMP_Text coinAnnounce;
    public GameObject panel;
    public GameObject spinningWheel;
    public GameObject triangle;
    public TMP_Text panelAnnouce;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        panel.SetActive(false);
        spinningWheel.SetActive(true);
        triangle.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (isSpinning)
        {
            transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);

            rotationSpeed -= deceleration * Time.deltaTime;
            if (rotationSpeed <= 0)
            {
                rotationSpeed = 0;
                isSpinning = false;
                GetReward();
            }
        }
        spinResultText.text = transform.rotation.eulerAngles.z.ToString();
    }
    public void GetReward()
    {
        float rot = transform.rotation.eulerAngles.z;
        int rewardIndex = ((int)(rot % 360) / 30) + 1;
        Win(rewardIndex);

        panel.SetActive(true);
        spinningWheel.SetActive(false);
        triangle.SetActive(false);

        //float rot = transform.rotation.eulerAngles.z;
        //if (rot > 0 && rot <= 30)
        //{
        //    Win(1);
        //}
        //else if (rot > 30 && rot <= 60)
        //{
        //    Win(2);
        //}
        //else if (rot > 60 && rot <= 90)
        //{
        //    Win(3);
        //}
        //else if (rot > 90 && rot <= 120)
        //{
        //    Win(4);
        //}
        //else if (rot > 120 && rot <= 150)
        //{
        //    Win(5);
        //}
        //else if (rot > 150 && rot <= 180)
        //{
        //    Win(6);
        //}
        //else if (rot > 180 && rot <= 210)
        //{
        //    Win(7);
        //}
        //else if (rot > 210 && rot <= 240)
        //{
        //    Win(8);
        //}
        //else if (rot > 240 && rot <= 270)
        //{
        //    Win(9);
        //}
        //else if (rot > 270 && rot <= 300)
        //{
        //    Win(10);
        //}
        //else if (rot > 300 && rot <= 330)
        //{
        //    Win(11);
        //}
        //else if (rot > 330 && rot <= 360)
        //{
        //    Win(12);
        //}
    }
public void Win(int amount)
    {
        Debug.Log("You win: " + amount + " point!");
        money += amount;
        coinAnnounce.text ="Total amount: " + money.ToString();
        panelAnnouce.text = "THE SPIN STOPPED!! \n\n\nYOU WON: " + amount +"\nTOTAL AMOUNT: " + money.ToString();
    }
    public void Button()
    {
        rotationSpeed = Random.Range(1000f, 1500f);
        if (money < 0)
        {
            Debug.Log("Not enough money to spin!");
            return;
        }
        money -= 5;
        coinAnnounce.text = "Total amount: " + money.ToString();
        Debug.Log("Money left: " + money);
        Debug.Log("Wheel spinning!");
        isSpinning = true;
    }
    public void ClosePanel()
    {
        panel.SetActive(false);
        spinningWheel.SetActive(true);
        triangle.SetActive(true);
    }
}
