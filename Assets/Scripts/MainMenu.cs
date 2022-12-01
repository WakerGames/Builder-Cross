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
    }
    public void PlayTime()
    {
        Time.timeScale = 1;
    }

}
