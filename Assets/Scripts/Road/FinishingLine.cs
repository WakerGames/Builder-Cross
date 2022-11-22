using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class FinishingLine : MonoBehaviour
{
    [SerializeField] Canvas _canvas;
    [SerializeField] GameObject NextLevelUI;
    public bool pause;
        void Update()
        {
            if (pause)
            {
                Time.timeScale = 0;
            }
            if (!pause)
            {
                Time.timeScale = 1;
            }
        }


        void OnTriggerEnter(Collider col)
        {
            if (col.gameObject.tag == "Player")
            {
                NextLevelUI.SetActive(true);
                StartCoroutine(pauseTime());
                print("Pause in action");
            }
        }
    IEnumerator pauseTime()
    {
        pause = true;
        yield return new WaitForSeconds(1f);
        pause = false;
    }
    public void Resume()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
  
}
