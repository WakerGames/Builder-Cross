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
        _dayText.text = "Day " + PlayerPrefs.GetInt("Level").ToString();
        
    }

}
