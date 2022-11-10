using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretShootingScript : MonoBehaviour,IDamageDealer
{
    [SerializeField] AudioSource audioData;
    [SerializeField] ParticleSystem bulletParticleEffect;
    float _audioLength = 3;
    [SerializeField] Collider shootingCollider;
    [SerializeField] private float horizontalForceRadius;
    private void Start()
    {
        PlayFireSound();
        _audioLength = 1f;
    }

    IEnumerator MyCoroutine()
    {
        yield return new WaitForSeconds(3f);
        //code here will execute after 5 seconds
        PlayFireSound();

    }

    IEnumerator DelayLittle()
    {

        StartCoroutine(PlayFire(_audioLength));
        yield return new WaitForSeconds(_audioLength); //wait 5 secconds
        shootingCollider.enabled = false;
        StopParticleEffect();
        StartCoroutine(MyCoroutine());

    }
    void PlayFireSound()
    {
        audioData.Play(0);
        StartCoroutine(DelayLittle());
        PlayParticleEffect();

    }
    IEnumerator PlayFire(float seconds)
    {
        yield return new WaitForSeconds(0.1f);
        shootingCollider.enabled = true;
        yield return new WaitForSeconds(seconds);
        shootingCollider.enabled = false;
    }
    void StopFire()
    {
        shootingCollider.enabled = false;
    }

    void PlayParticleEffect()
    {
        bulletParticleEffect.Play();
    }

    void StopParticleEffect()
    {
        bulletParticleEffect.Stop();
    }

    public void DealDamage(Collider other)
    {
        Debug.Log(other.gameObject.name);

        if (other.gameObject.GetComponent<Death>() != null)
        {
            other.gameObject.GetComponent<Death>().GotShot(horizontalForceRadius);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            DealDamage(other);

        }

    }
}
