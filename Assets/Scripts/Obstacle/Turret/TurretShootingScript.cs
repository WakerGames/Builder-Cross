using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DeathCause = Death.DeathCause;

public class TurretShootingScript : MonoBehaviour,IDamageDealer
{
    [SerializeField] AudioSource audioData;
    [SerializeField] ParticleSystem bulletParticleEffect;
    float _audioLength = 3;
    [SerializeField] Collider shootingCollider;
    [SerializeField] private float horizontalForceRadius;
    private bool readyToShoot;

    private void Start()
    {
        //Debug.Log(gameObject.GetComponent<LineRenderer>().startColor.a); -is 1-
        PlayFireSound();
        _audioLength = 1f;
    }

    //IEnumerator MyCoroutine()
    //{
    //    yield return new WaitForSeconds(3f);
    //    //code here will execute after 5 seconds
    //    PlayFireSound();

    //}

    //IEnumerator DelayLittle()
    //{

    //    StartCoroutine(PlayFire(_audioLength));
    //    //DisappearLaser();   //Mert
    //    yield return new WaitForSeconds(_audioLength); //wait 5 secconds
    //    shootingCollider.enabled = false;
    //    StopParticleEffect();
    //    StartCoroutine(MyCoroutine());

    //}

    void PlayFireSound()
    {
        
        StartCoroutine(DelayLittleMert2());
        
    }

    IEnumerator DelayLittleMert2()
    {

        StartCoroutine(PlayFire(_audioLength));
        DisappearLaser();   //Mert
        if (!audioData.isPlaying)
        {

            audioData.Play(0);
            PlayParticleEffect();
        }
        yield return new WaitForSeconds(_audioLength); //wait 5 secconds

        if(audioData.isPlaying)
        {
            audioData.Stop();
            StopParticleEffect();
        }
        shootingCollider.enabled = false;
        
        KickstartLaser();
        yield return new WaitForSeconds(3f);
        PlayFireSound();
        StartCoroutine(FadeInLaser());
        
       
    }


    IEnumerator PlayFire(float seconds)
    {
        yield return new WaitForSeconds(0.1f);
        shootingCollider.enabled = true;
        yield return new WaitForSeconds(seconds);
        shootingCollider.enabled = false;

        readyToShoot = false;
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

    void DisappearLaser() 
    {
        var currentMaterialStartColor = gameObject.GetComponent<LineRenderer>().startColor;
        var currentMaterialEndColor = gameObject.GetComponent<LineRenderer>().endColor;
        currentMaterialStartColor.a = 0f;
        currentMaterialEndColor.a = 0f;

        gameObject.GetComponent<LineRenderer>().startColor = currentMaterialStartColor;
        gameObject.GetComponent<LineRenderer>().endColor = currentMaterialEndColor;
    }

    private IEnumerator FadeInLaser() 
    {
        //if (gameObject.GetComponent<LineRenderer>().startColor.a < 1f)
        //{
        //    var currentMaterialStartColor = gameObject.GetComponent<LineRenderer>().startColor;     //have to set these since accessing via gameobject does not give permission to Set stuff
        //    var currentMaterialEndColor = gameObject.GetComponent<LineRenderer>().endColor;

        //    currentMaterialStartColor.a += 0.01f;
        //    currentMaterialStartColor.a += 0.01f;

        //    gameObject.GetComponent<LineRenderer>().startColor = currentMaterialStartColor;
        //    gameObject.GetComponent<LineRenderer>().endColor = currentMaterialEndColor;

        //    yield return new WaitForSecondsRealtime(0.04f); //Wait for seconds realtime * alpha increase amount must equal 0.25 for it to wait 3 seconds!
        //    StartCoroutine(FadeInLaser());
        //}
        //else 
        //{
        //    readyToShoot = true;
        //}


        while (gameObject.GetComponent<LineRenderer>().startColor.a < 1f)
        {
            var currentMaterialStartColor = gameObject.GetComponent<LineRenderer>().startColor;     //have to set these since accessing via gameobject does not give permission to Set stuff
            var currentMaterialEndColor = gameObject.GetComponent<LineRenderer>().endColor;

            currentMaterialStartColor.a += 0.01f;
            currentMaterialStartColor.a += 0.01f;

            gameObject.GetComponent<LineRenderer>().startColor = currentMaterialStartColor;
            gameObject.GetComponent<LineRenderer>().endColor = currentMaterialEndColor;

            yield return new WaitForSecondsRealtime(0.04f);
        }
        readyToShoot = true;


    }

    void KickstartLaser()
    {
        var currentMaterialStartColor = gameObject.GetComponent<LineRenderer>().startColor;     //have to set these since accessing via gameobject does not give permission to Set stuff
        var currentMaterialEndColor = gameObject.GetComponent<LineRenderer>().endColor;

        currentMaterialStartColor.a = 0.25f;
        currentMaterialStartColor.a = 0.25f;

        gameObject.GetComponent<LineRenderer>().startColor = currentMaterialStartColor;
        gameObject.GetComponent<LineRenderer>().endColor = currentMaterialEndColor;
    }

    public void DealDamage(GameObject other)
    {
        other.GetComponent<Death>()?.Die(other.TryGetComponent(out Player temp), DeathCause.Turret, horizontalForceRadius, null);
    }

   
    //private void OnCollisionEnter(Collision collision)
    //{
    //    DealDamage(collision.gameObject);
    //}

    private void OnTriggerEnter(Collider other)
    {
        DealDamage(other.gameObject);
    }
}
