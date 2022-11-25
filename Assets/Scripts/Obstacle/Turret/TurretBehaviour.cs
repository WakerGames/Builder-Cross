using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DeathCause = Death.DeathCause;

public class TurretBehaviour : MonoBehaviour, IDamageDealer
{
    [SerializeField] private float shootingDuration;
    [SerializeField] private float increaseAmount;
    [SerializeField] AudioSource audioData;
    [SerializeField] ParticleSystem bulletParticleEffect;
    [SerializeField] Collider shootingCollider;
    [SerializeField] private float horizontalForceRadius;
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private float laserKickStartAmount;
    private bool _readyToShoot;

    void OnEnable()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Fire());
    }

    private IEnumerator Fire()
    {
        while (true)
        {
            Debug.Log("here");
            DisappearLaser();
            shootingCollider.enabled = true;
            if (!audioData.isPlaying)
                audioData.Play();
        
            bulletParticleEffect.Play();
            
            yield return new WaitForSecondsRealtime(shootingDuration);
            Debug.Log("here waiting");
            bulletParticleEffect.Stop();
            shootingCollider.enabled = false;
            _readyToShoot = false;
            if (audioData.isPlaying)
                audioData.Stop();
        
            KickStartLaser();
            StartCoroutine(FadeInLaser());
            yield return new WaitUntil(() => _readyToShoot);
            Debug.Log("here waiting for shoot");
        }
    }

    void DisappearLaser()
    {
        var currentMaterialStartColor = lineRenderer.startColor;
        var currentMaterialEndColor = lineRenderer.endColor;
        currentMaterialStartColor.a = 0f;
        currentMaterialEndColor.a = 0f;

        lineRenderer.startColor = currentMaterialStartColor;
        lineRenderer.endColor = currentMaterialEndColor;
    }
    void KickStartLaser()
    {
        var currentMaterialStartColor = lineRenderer.startColor;     //have to set these since accessing via gameobject does not give permission to Set stuff
        var currentMaterialEndColor = lineRenderer.endColor;

        currentMaterialStartColor.a = laserKickStartAmount;
        currentMaterialEndColor.a = laserKickStartAmount;

        lineRenderer.startColor = currentMaterialStartColor;
        lineRenderer.endColor = currentMaterialEndColor;
    }

    private IEnumerator FadeInLaser()
    {
        while (lineRenderer.startColor.a < 1f)
        {
            var currentMaterialStartColor = lineRenderer.startColor;     //have to set these since accessing via gameobject does not give permission to Set stuff
            var currentMaterialEndColor = lineRenderer.endColor;

            currentMaterialStartColor.a += 0.01f;
            currentMaterialStartColor.a += 0.01f;

            lineRenderer.startColor = currentMaterialStartColor;
            lineRenderer.endColor = currentMaterialEndColor;

            yield return new WaitForSecondsRealtime(0.04f);
        }
        _readyToShoot = true;
    }
    

    public void DealDamage(GameObject other)
    {
        other.GetComponent<Death>()?.Die(other.TryGetComponent(out Player temp), DeathCause.Turret, horizontalForceRadius, null);
    }

    private void OnTriggerEnter(Collider other)
    {
        DealDamage(other.gameObject);
    }
}
