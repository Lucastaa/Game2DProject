using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class ToggleMusic : MonoBehaviour
{
    public Slider volumeSlider;
    public AudioMixer audioMixer;
    public GameObject mute;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (volumeSlider != null)
        {
            float volume;
            audioMixer.GetFloat("MasterVolume", out volume);
            volumeSlider.value = Mathf.Pow(10, volume / 20f);
            volumeSlider.onValueChanged.AddListener(SetVolume);
        }
        mute.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetVolume(float value)
    {
        float dB = Mathf.Log10(Mathf.Clamp(value, 0.0001f, 1f)) * 20f;
        audioMixer.SetFloat("MasterVolume", dB);
    }
    public void Mute()
    {
        if (volumeSlider.value > 0)
        {
            volumeSlider.value = 0;
            mute.SetActive(true);
        }
        else
        {
            volumeSlider.value = 1f;
            mute.SetActive(false);
        }
    }
    public void UnMute()
    {
        if (mute.activeSelf)
        {
            mute.SetActive(false);
            volumeSlider.value = 1f;
        }
    }
}
