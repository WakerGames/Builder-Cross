using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TimerManager : MonoBehaviour
{
    private Text _info;
    private float _madTimer;
    private Slider _time;
    bool _timeEnd;

    private void Awake()
    {
        _info = GameObject.FindWithTag("info").GetComponent<Text>();
        _time = GameObject.Find("Timer").GetComponent<Slider>();
    }
    void Start()
    {
        _time.maxValue = 60;
        _time.minValue = 0;
        _time.wholeNumbers = false;
        _time.value = _time.maxValue;
        _madTimer = _time.value;
    }

    
    void Update()
    {
        if(_time.value > _time.minValue)
        {
            _madTimer -= Time.deltaTime;
            _time.value = _madTimer;
            _info.text = ((int)_time.value).ToString();
        }
        else
        {
            _info.text = "X";
        }
        if(_time.value == 0)
        {
            _timeEnd = true;
        }
    }
    public bool isTimeEnd()
    {
        return _timeEnd;
    }
}
