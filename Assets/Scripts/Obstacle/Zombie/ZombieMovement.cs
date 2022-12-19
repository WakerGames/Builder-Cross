
using UnityEngine;

public class ZombieMovement : MonoBehaviour
{
    [SerializeField] private AnimatorController characterAnimatorController;
    public Transform target;
    private float characterMoveSpeed;
    

    private void Start()
    {
        GetComponent<Character>().charAudioSource.Play();
        characterAnimatorController = GetComponent<AnimatorController>();
        characterMoveSpeed = gameObject.GetComponent<FollowingZombie>().characterMoveSpeed;
        characterAnimatorController.ZombieRun();
    }

    void FixedUpdate()
    {
        gameObject.transform.LookAt(target);
        transform.position = Vector3.MoveTowards(transform.position, target.position, characterMoveSpeed*Time.deltaTime);
    }
}
