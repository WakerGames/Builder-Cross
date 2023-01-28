using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private AudioSource _buttonAudio;
    [SerializeField] private GameObject soundOnButton;
    [SerializeField] private GameObject soundOffButton;
    [SerializeField] private GameObject vibrationOnButton;
    [SerializeField] private GameObject vibrationOffButton;
    [SerializeField] private SettingsSO settings;

    public void Play()
    {
        
        if (PlayerPrefs.GetInt("Level") > 0)
        {
            SceneManager.LoadScene(PlayerPrefs.GetInt("Level"));
        }
        else
        {
            SceneManager.LoadScene(1);
        }
        
    }
    public  void DeletePref()
    {
        PlayerPrefs.DeleteKey("Level");
    }
    public void OpenNextScene()
    {

        SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex + 1) % SceneManager.sceneCountInBuildSettings);

    }
    public void PauseTime()
    {
        Time.timeScale = 0;
        AudioListener.pause = true;
    }
    public void PlayTime()
    {
        Time.timeScale = 1;
        AudioListener.pause = false;

        //MuteToggle();
    }
    public void MuteToggle(bool value)
    {
        if(!value)
        {
            Debug.Log("Sound enabled");
            AudioListener.volume= 1;
            settings.muted = false;
            soundOnButton.SetActive(true);
            soundOffButton.SetActive(false);
        }
        else
        {
            Debug.Log("Muted");
            AudioListener.volume= 0;
            settings.muted = true;
            soundOnButton.SetActive(false);
            soundOffButton.SetActive(true);
        }
    }

    public void VibrationToggle(bool value)
    {
        if (value)
        {
            settings.vibrationEnabled = true;
            vibrationOnButton.SetActive(true);
            vibrationOffButton.SetActive(false);
        }
        else
        {
            settings.vibrationEnabled = false;
            vibrationOnButton.SetActive(false);
            vibrationOffButton.SetActive(true);
        }
    }

    public void AdsEnabled(bool value) //TODO
    {
        if (value)
        {
            settings.ads = true;
            GameObject.Find("").SetActive(true);
            GameObject.Find("").SetActive(false);
        }
        else
        {
            
        }
    }
    
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }
    public void ButtonSound()
    {
        _buttonAudio.Play();
    }

    private void RestoreSettings()   //TODO ads
    {
        if (!settings.muted)
        {
            AudioListener.volume= 1;
            soundOnButton.SetActive(true);
            soundOffButton.SetActive(false);
        }
        else
        {
            AudioListener.volume= 0;
            soundOnButton.SetActive(false);
            soundOffButton.SetActive(true);
        }

        if (settings.vibrationEnabled)
        {
            vibrationOnButton.SetActive(true);
            vibrationOffButton.SetActive(false);
        }
        else
        {
            vibrationOnButton.SetActive(false);
            vibrationOffButton.SetActive(true);
        }
    }

    private void Start()
    {
       
        RestoreSettings();
    }
}
