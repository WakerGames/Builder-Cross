using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void PauseTime()
    {
        Time.timeScale = 0;
        AudioListener.volume = 0;

    }
    public void PlayTime()
    {
        Time.timeScale = 1;
        AudioListener.volume = 1;
    }
    public void MuteToggle(bool muted)
    {
        if(muted)
        {
            AudioListener.volume= 0;
        }
        else
        {
            AudioListener.volume= 1;
        }
    }

}
