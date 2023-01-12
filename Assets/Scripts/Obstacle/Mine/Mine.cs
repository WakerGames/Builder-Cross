using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Unity.VisualScripting;
using UnityEngine;
using DeathCause = Death.DeathCause;

public class Mine : MonoBehaviour, IDamageDealer
{
    [SerializeField] private float verticalForceAmount;
    [SerializeField] private float horizontalForceRadius;

    [SerializeField] ParticleSystem explosionParticleEffect;

    [SerializeField] AudioSource audioSrc; // By default, Loop is active, clip is beep, everything else is disabled

    //[SerializeField] private AudioClip beepSound;
    [SerializeField] private AudioClip explosionSound;

    private static bool _audioPlaying = false;


    public void DealDamage(GameObject other)
    {
        Debug.Log(other);
        other.GetComponent<Death>()?.Die(other.TryGetComponent(out Player temp), DeathCause.Explosion,
            horizontalForceRadius, verticalForceAmount);
    }

    private IEnumerator MineExplosion()
    {
        audioSrc.loop = false;
        audioSrc.clip = explosionSound;
        audioSrc.Play(0);
        explosionParticleEffect.Play();

        //DAHA SONRA BU KODU KULLANCAZ 
        //yield return new WaitWhile(() => audioData.isPlaying);
        yield return new WaitForSeconds(0.5f);
        Destroy(this.gameObject);
    }


    //private void OnCollisionEnter(Collision other)
    //{
    //    DealDamage(other.gameObject);
    //    Debug.Log(audioData.loop);
    //    StartCoroutine(MineExplosion());
    //}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Character>() != null)
        {
            Debug.Log("la");
            DealDamage(collision.gameObject);
            StartCoroutine(MineExplosion());
        }
    }

    private void OnTriggerEnter(Collider other) // Beeping
    {
        if (!_audioPlaying)
        {
            audioSrc.loop = true;
            audioSrc.Play();
            Debug.Log("Bruh");
            _audioPlaying = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        audioSrc.Stop();
        _audioPlaying = false;
        audioSrc.loop = false;
    }
}