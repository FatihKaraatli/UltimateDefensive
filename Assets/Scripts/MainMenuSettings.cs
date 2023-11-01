using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainMenuSettings : MonoBehaviour
{
    public AudioSource mainAudioSource;
    public AudioSource[] mainEffectAudioSource;

    public GameObject musicOn;
    public GameObject musicOff;

    public GameObject sesSoundEffectOn;
    public GameObject sesSoundEffectOff;

    public TextMeshProUGUI sensText;
    public Slider sensSlider;

    public void Start()
    {
        sensSlider.maxValue = 200f;
        if (PlayerPrefs.GetFloat("firstImplamentsensitivity") == 0)
        {
            PlayerPrefs.SetFloat("sensitivity", 100);
            sensSlider.value = 100f;

            PlayerPrefs.SetFloat("firstImplamentsensitivity", 1);

        }
        sensSlider.value = PlayerPrefs.GetFloat("sensitivity");
        PlayerPrefs.SetFloat("sensitivity", sensSlider.value);

        if (PlayerPrefs.GetString("music") == "on")
        {
            mainAudioSource.mute = false;
            musicOn.SetActive(true);
            musicOff.SetActive(false);
        }
        else if (PlayerPrefs.GetString("music") == "off")
        {
            mainAudioSource.mute = true;
            musicOn.SetActive(false);
            musicOff.SetActive(true);
        }
        else 
        {
            mainAudioSource.mute = false;
            musicOn.SetActive(true);
            musicOff.SetActive(false);
        }

        if (PlayerPrefs.GetString("soundeffect") == "on")
        {
            for (int i = 0; i < mainEffectAudioSource.Length; i++)
            {
                mainEffectAudioSource[i].mute = false;
            }
            sesSoundEffectOn.SetActive(true);
            sesSoundEffectOff.SetActive(false);
        }
        else if (PlayerPrefs.GetString("soundeffect") == "off")
        {
            for (int i = 0; i < mainEffectAudioSource.Length; i++)
            {
                mainEffectAudioSource[i].mute = true;
            }
            sesSoundEffectOn.SetActive(false);
            sesSoundEffectOff.SetActive(true);
        }
        else 
        {
            for (int i = 0; i < mainEffectAudioSource.Length; i++)
            {
                mainEffectAudioSource[i].mute = false;
            }
            sesSoundEffectOn.SetActive(true);
            sesSoundEffectOff.SetActive(false);
        }
    }

    public void Update()
    {
        PlayerPrefs.SetFloat("sensitivity", sensSlider.value);
        sensText.text = "SENSITIVITY : " + (int)(sensSlider.value);
    }

    public void MusicOn()
    {
        mainAudioSource.mute = true;
        musicOn.SetActive(false);
        musicOff.SetActive(true);
        PlayerPrefs.SetString("music", "off");
    }
    public void MusicOff()
    {
        mainAudioSource.mute = false;
        musicOn.SetActive(true);
        musicOff.SetActive(false);
        PlayerPrefs.SetString("music", "on");
    }


    public void SoundEffectOn()
    {
        for (int i = 0; i < mainEffectAudioSource.Length; i++)
        {
            mainEffectAudioSource[i].mute = true;
        }
        sesSoundEffectOn.SetActive(false);
        sesSoundEffectOff.SetActive(true);
        PlayerPrefs.SetString("soundeffect", "off");
    }
    public void SoundEffectOff()
    {
        for (int i = 0; i < mainEffectAudioSource.Length; i++)
        {
            mainEffectAudioSource[i].mute = false;
        }
        sesSoundEffectOn.SetActive(true);
        sesSoundEffectOff.SetActive(false);
        PlayerPrefs.SetString("soundeffect", "on");
    }
}
