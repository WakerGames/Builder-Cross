using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using AppsFlyerSDK;

public class BunkerEnter : MonoBehaviour
{
    [SerializeField] GameObject _gameHUD;
    [SerializeField] GameObject _joystick;
    [SerializeField] GameObject _survivedScene;
    [SerializeField] GameObject _tryAgainSurvivedScene;
    [SerializeField] GameObject _mainCharacter;
    [SerializeField] GameObject _mainCam;
    [SerializeField] GameObject _bunkerCam;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            int temp = SceneManager.GetActiveScene().buildIndex + 1;
            PlayerPrefs.SetInt("Level", temp % SceneManager.sceneCountInBuildSettings);
            SendPurchaseInfo();

            //For saving
            if (temp % SceneManager.sceneCountInBuildSettings == 0)
            {
                PlayerPrefs.SetInt("Level", 1);
            }

            _mainCharacter.transform.Rotate(0f, 0f, 0f);
            _bunkerCam.SetActive(true);
            _mainCam.SetActive(false);
            StartCoroutine(StopMainChar());
            _gameHUD.SetActive(false);
            _joystick.SetActive(false);

            if (_mainCharacter.GetComponent<BoxManager>().BoxesOnHand.Count == 3)
            {
                _survivedScene.SetActive(true);
            }
            else if (_mainCharacter.GetComponent<BoxManager>().BoxesOnHand.Count == 0)
            {
                _tryAgainSurvivedScene.SetActive(true);
                _mainCharacter.GetComponent<AnimatorController>().WalkMain();
            }
            else
            {
                _tryAgainSurvivedScene.SetActive(true);
            }

        }
    }
    public void SendPurchaseInfo()
    {
        Dictionary<string, string>
            eventValues = new Dictionary<string, string>();
        eventValues.Add(AFInAppEvents.LEVEL_ACHIEVED, $"Achieved Level : {PlayerPrefs.GetInt("Level")} ");
        AppsFlyer.sendEvent(AFInAppEvents.LEVEL_ACHIEVED, eventValues);
    }
    IEnumerator StopMainChar()
    {
        _mainCharacter.GetComponent<Player>().characterMoveSpeed = 3;
        yield return new WaitForSeconds(1.5f);
        _mainCharacter.GetComponent<Player>().characterMoveSpeed = 0;
    }
}
