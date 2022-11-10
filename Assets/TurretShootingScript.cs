using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretShootingScript : MonoBehaviour
{
    [SerializeField] AudioSource audioData;
    [SerializeField] ParticleSystem bulletParticleEffect;
    float _audioLength = 3;

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
        yield return new WaitForSeconds(_audioLength); //wait 5 secconds
        StopParticleEffect();
        StartCoroutine(MyCoroutine());

    }
    void PlayFireSound()
    {
        audioData.Play(0);
        StartCoroutine(DelayLittle());
        PlayParticleEffect();
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
            other.gameObject.GetComponent<Death>().Die();
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
