using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class FinishingLine : MonoBehaviour
{
    [SerializeField] Canvas _canvas;
    [SerializeField] GameObject nextLevelUI;

    void OnTriggerEnter(Collider col)
        {
            if (col.gameObject.CompareTag("Player"))
            {
                nextLevelUI.SetActive(true);
                Time.timeScale = 0;
                print("Pause in action");
            }
        }
    public void Resume()
    {
        if (SceneManager.GetActiveScene().buildIndex != SceneManager.sceneCountInBuildSettings - 1)
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
