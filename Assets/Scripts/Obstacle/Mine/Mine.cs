using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Unity.VisualScripting;
using UnityEngine;

public class Mine : MonoBehaviour, IDamageDealer
{
    [SerializeField] private float verticalForceAmount;
    [SerializeField] private float horizontalForceRadius;
    
    [SerializeField] ParticleSystem explosionParticleEffect;
    [SerializeField] AudioSource audioData;

    public void DealDamage(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Death>().Explode(horizontalForceRadius, verticalForceAmount);

            GameObject.Find("CM vcam1").GetComponent<CinemachineVirtualCamera>().Follow = null;
            GameObject.Find("CM vcam1").GetComponent<CinemachineVirtualCamera>().LookAt = null;
        }
        
        //Explode animation here
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            DealDamage(other);
            audioData.Play(0);
            explosionParticleEffect.Play();
        }
    }
}