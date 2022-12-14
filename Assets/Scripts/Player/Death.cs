using UnityEngine;
using Random = UnityEngine.Random;

public class Death : MonoBehaviour
{
    [SerializeField] private RagdollManager _ragdollManager;
    

    [SerializeField] private AudioClip deathClip;

    public enum DeathCause
    {
        Regular,
        Explosion,
        Turret
    }

    private void Awake()
    {
        _ragdollManager = GetComponent<RagdollManager>();
    }


    public void SlowTime()
    {
        ShowDeathScene();
        Time.timeScale = 0.1f;
    }


    public void Die(bool playerIsDying, DeathCause causeOfDeath, float? horizontalForceRadius,
        float? verticalForceAmount)
    {
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;

        if (playerIsDying && Player.playerDied != null)
            Player.playerDied();


        if (!playerIsDying) // If the hostile NPC is dying
        {
            GetComponent<Character>().charAudioSource.clip = deathClip;

            GetComponent<Character>().charAudioSource.Play();

            if (GetComponent<AttackerMovement>() != null)
                GetComponent<AttackerMovement>().enabled = false;
            if (GetComponent<ZombieMovement>() != null)
                GetComponent<ZombieMovement>().enabled = false;
        }

        switch (causeOfDeath)
        {
            case DeathCause.Regular:
                _ragdollManager.RagdollModeOn(DeathCause.Regular, null, null);
                break;

            case DeathCause.Explosion:
                _ragdollManager.RagdollModeOn(DeathCause.Explosion, horizontalForceRadius, verticalForceAmount);
                break;

            case DeathCause.Turret:
                _ragdollManager.RagdollModeOn(DeathCause.Turret, horizontalForceRadius, null);
                break;

            default:
                break;
        }
    }

    private static void ShowDeathScene()
    {
        var player = GameObject.FindWithTag("Player").GetComponent<Player>();
        player._deadScene.SetActive(true);
        player._joystick.gameObject.SetActive(false);
        player._gamehud.SetActive(false);
    }
}