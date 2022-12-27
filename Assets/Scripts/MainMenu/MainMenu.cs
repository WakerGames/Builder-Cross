using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private AudioSource _buttonAudio;

    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
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
    public void MuteToggle(bool muted)
    {
        if(muted)
        {
            Debug.Log("Ses Açýk");
            AudioListener.volume= 1;
        }
        else
        {
            Debug.Log("Ses Kapandý");
            AudioListener.volume= 0;
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
}
