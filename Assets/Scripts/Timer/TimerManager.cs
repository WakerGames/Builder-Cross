using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour
{
    private float _madTimer;
    [SerializeField] private Image sliderImage;
    private bool _timeEnd = false;
    private Player _player;
    [SerializeField] public GameObject _poisonedScreen;
    [SerializeField] private GameObject _gameHUD;
    [SerializeField] private GameObject _joyStick;
    [SerializeField] private AudioSource _timerSound;
    
    public delegate void OnTimeEnd();

    public static OnTimeEnd timeEnded;
    

    private void Awake()
    {
        _player = GameObject.FindWithTag("Player").GetComponent<Player>();
        
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
    }


    void FixedUpdate()
    {
        if (_player.CanMove)
        {
            if (sliderImage.fillAmount >= 0 && sliderImage.fillAmount < 1)
            {
                _madTimer += 0.0005f;
                sliderImage.fillAmount = _madTimer;
            }
            else
            {
                _timeEnd = true;
                timeEnded();
            }
            sliderImage.GetComponent<Image>().fillAmount += 0.0005f;
        }
        if(_madTimer == 85f)
        {
            _timerSound.Play();
        }
    }

    public bool IsTimeEnd()
    {
        return _timeEnd;
    }

    public void EndGame()
    {
        _poisonedScreen.SetActive(true);
        _gameHUD.SetActive(false);
        _joyStick.SetActive(false);
        _player.characterRagdollManager.RagdollModeOn(Death.DeathCause.Regular, null, null);
    }
}