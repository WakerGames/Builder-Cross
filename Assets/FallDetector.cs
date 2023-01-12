using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class FallDetector : MonoBehaviour
{
    [SerializeField] private Collider boxClldr;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GameObject().CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Debug.LogError("Player fell down the map!");
        }

    }
}
