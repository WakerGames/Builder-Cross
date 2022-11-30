using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour
{
    private Text _info;
    private float _madTimer;
    [SerializeField] private float maxTimeValue;
    [SerializeField] private Slider timeSlider;
    private bool _timeEnd = false;
    private Player _player;
    
    public delegate void OnTimeEnd();

    public static OnTimeEnd timeEnded;
    

    private void Awake()
    {
        _info = GameObject.FindWithTag("info").GetComponent<Text>();
        _player = GameObject.FindWithTag("Player").GetComponent<Player>();
        //timeSlider = GameObject.Find("Timer").GetComponent<Slider>();
    }

    private void OnEnable()
    {
        timeEnded += EndGame;
    }

    private void OnDisable()
    {
        timeEnded -= EndGame;
    }

    void Start()
    {
        timeSlider.maxValue = maxTimeValue;
        timeSlider.minValue = 0;
        timeSlider.wholeNumbers = false;
        timeSlider.value = timeSlider.maxValue;
        _madTimer = timeSlider.value;
    }


    void FixedUpdate()
    {
        if (timeSlider.value > timeSlider.minValue)
        {
            _madTimer -= Time.fixedDeltaTime;
            timeSlider.value = _madTimer;
            _info.text = ((int)timeSlider.value).ToString();
        }

        else if (timeSlider.value <= 0)
        {
            _timeEnd = true;
            timeEnded();
        }
        else
        {
            _info.text = "X";
        }
    }

    public bool IsTimeEnd()
    {
        return _timeEnd;
    }

    public void EndGame()
    {
        _player.characterRagdollManager.RagdollModeOn(Death.DeathCause.Regular, null, null);
    }
}