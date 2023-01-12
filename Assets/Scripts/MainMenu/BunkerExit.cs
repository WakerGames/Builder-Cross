using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunkerExit : MonoBehaviour
{
    [SerializeField] GameObject _gameHUD;
    [SerializeField] GameObject _joystick;
    [SerializeField] GameObject _mainCam;
    [SerializeField] GameObject _bunkerCam;
    [SerializeField] GameObject _mainCharacter;
    [SerializeField] GameObject _opacityImage;



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _gameHUD.SetActive(true);
            _joystick.SetActive(true);
            _mainCam.SetActive(true);
            _bunkerCam.SetActive(false);
            _mainCharacter.GetComponent<PlayerMovement>().enabled = true;
            _opacityImage.GetComponent<CharWalk>().enabled = false;
        }
    }
}
