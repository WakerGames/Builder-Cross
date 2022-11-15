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
    [SerializeField] AudioSource audioData;

    public void DealDamage(GameObject other)
    {
        Debug.Log(other);
        other.GetComponent<Death>()?.Die(other.TryGetComponent(out Player temp), DeathCause.Explosion, horizontalForceRadius, verticalForceAmount);
    }

    private IEnumerator MineExplosion()
    {
        audioData.Play(0);
        explosionParticleEffect.Play();
        yield return new WaitWhile(() => audioData.isPlaying);
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
        DealDamage(other.gameObject);
        Debug.Log(audioData.loop);
        StartCoroutine(MineExplosion());
    }

}