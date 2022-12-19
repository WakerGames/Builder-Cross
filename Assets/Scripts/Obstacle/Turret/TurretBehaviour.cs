using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DeathCause = Death.DeathCause;

public class TurretBehaviour : MonoBehaviour, IDamageDealer
{
    [SerializeField] private float shootingDuration;
    [SerializeField] AudioSource audioData;
    [SerializeField] private AudioClip shootingSfx;
    [SerializeField] private AudioClip laserSfx;
    [SerializeField] private AudioClip overheatSfx;
    [SerializeField] ParticleSystem bulletParticleEffect;
    [SerializeField] Collider shootingCollider;
    [SerializeField] private float horizontalForceRadius;
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private float laserKickStartAmount;

    private bool _readyToShoot;
    private Renderer _renderer;

    void OnEnable()
    {
        lineRenderer = GetComponent<LineRenderer>();
        _renderer = GetComponent<Renderer>();
    }

    void Start()
    {
        StartCoroutine(Fire());
    }

    private IEnumerator Fire()      // OverheatSFX - green, LaserSFX - yellow, Shooting - red
    {
        while (_renderer.enabled)
        {
            SetShooting(true);
            SetLaserColor(Color.red);

            yield return new WaitForSecondsRealtime(shootingDuration);

            SetShooting(false);
            SetLaserColor(Color.clear);  
            yield return new WaitForSecondsRealtime(overheatSfx.length);
            
            SetLaserColor(new Color(255,215,0));    // Gold
            KickStartLaser();

            audioData.clip = laserSfx;
            if (!audioData.isPlaying)
                audioData.PlayDelayed(0.3f);

            StartCoroutine(FadeInLaser());

            yield return new WaitUntil(() => _readyToShoot);
        }
    }

    void SetShooting(bool shootingState) //Plays overheat sfx if set to false!
    {
        if (shootingState)
        {
            shootingCollider.enabled = true;
            audioData.clip = shootingSfx;

            if (!audioData.isPlaying)
                audioData.Play();

            bulletParticleEffect.Play();
        }
        else
        {
            bulletParticleEffect.Stop();
            shootingCollider.enabled = false;
            _readyToShoot = false;
            
            if (audioData.isPlaying)
                audioData.Stop();

            audioData.clip = overheatSfx;
            if (!audioData.isPlaying)
                audioData.Play();
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
        var currentMaterialStartColor =
            lineRenderer
                .startColor; //have to set these since accessing via gameobject does not give permission to Set stuff
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
            var currentMaterialStartColor =
                lineRenderer
                    .startColor; //have to set these since accessing via gameobject does not give permission to Set stuff
            var currentMaterialEndColor = lineRenderer.endColor;

            currentMaterialStartColor.a += 0.01f;
            currentMaterialStartColor.a += 0.01f;

            lineRenderer.startColor = currentMaterialStartColor;
            lineRenderer.endColor = currentMaterialEndColor;

            yield return new WaitForSecondsRealtime(0.04f);
        }

        _readyToShoot = true;
    }

    void SetLaserColor(Color newColor)
    {
        Gradient tempGradient = new Gradient();

        GradientColorKey[] tempColorKeys = new GradientColorKey[2];
        tempColorKeys[0] = new GradientColorKey(newColor, 0);
        tempColorKeys[1] = new GradientColorKey(newColor, 1);

        tempGradient.colorKeys = tempColorKeys;
        lineRenderer.colorGradient = tempGradient;
    }

    IEnumerator LaserColorMorph(Color newColor, float timeToMorph) // To streamline things
    {
        float time = 0;
        float progress;
        Color initialColor = lineRenderer.colorGradient.colorKeys[0].color;
        //reduce colorkey count to 2 just in case
        SetLaserColor(initialColor);

        while (time < timeToMorph)
        {
            time += Time.deltaTime;
            progress = time / timeToMorph;
            Color lerpedColor = Color.Lerp(initialColor, newColor, progress);
            SetLaserColor(lerpedColor);
        }

        yield return null;
    }


    public void DealDamage(GameObject other)
    {
        other.GetComponent<Death>()?.Die(other.TryGetComponent(out Player temp), DeathCause.Turret,
            horizontalForceRadius, null);
    }

    private void OnTriggerEnter(Collider other)
    {
        DealDamage(other.gameObject);
    }
}