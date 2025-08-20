using UnityEngine;
using UnityEngine.SceneManagement;

public class PausedManager : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject playButton;
    public GameObject returnButton;
    public GameObject restartButton;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }
    public void UnPause()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }
    public void RestartGame()
    {
        SceneManager.LoadScene("TwoScene");
        Time.timeScale = 1f;
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;
    }
}
