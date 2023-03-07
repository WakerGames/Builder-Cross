using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DayText : MonoBehaviour
{
    public TMP_Text _dayText;

    void Start()
    {
        if(PlayerPrefs.GetInt("Level") >= 1)
        {
            _dayText.text = "Day " + PlayerPrefs.GetInt("Level").ToString();
        }
        else
        {
            _dayText.text = "Day 1";
        }
    }

}
