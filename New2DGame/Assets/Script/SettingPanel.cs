using UnityEngine;
using UnityEngine.UI;

public class SettingPanel : MonoBehaviour
{
    public GameObject settingPanel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        settingPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Clicked()
    {
        settingPanel.SetActive(!settingPanel.activeSelf);
        if (settingPanel.activeSelf)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }
}
