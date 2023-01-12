using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelText : MonoBehaviour
{
    public Text _levelText;

    private void Start()
    {
        _levelText.text = "Level " + SceneManager.GetActiveScene().buildIndex;
    }
}
