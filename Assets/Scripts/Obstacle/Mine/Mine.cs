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
    [SerializeField] AudioSource audioSrc;
    [SerializeField] private AudioClip beepSound;
    [SerializeField] private AudioClip explosionSound;

    public void DealDamage(GameObject other)
    {
        Debug.Log(other);
        other.GetComponent<Death>()?.Die(other.TryGetComponent(out Player temp), DeathCause.Explosion,
            horizontalForceRadius, verticalForceAmount);
    }

    private void OnEnable()
    {
        audioSrc.clip = beepSound;
        audioSrc.loop = true;
        audioSrc.playOnAwake = true;
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Character>() != null)
        {
            DealDamage(other.gameObject);
            StartCoroutine(MineExplosion());
        }
    }
}