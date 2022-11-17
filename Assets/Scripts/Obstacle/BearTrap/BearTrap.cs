using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using DeathCause = Death.DeathCause;

public class BearTrap : MonoBehaviour, IDamageDealer
{
    [SerializeField] AudioSource audioData;

    [SerializeField] GameObject leftJaw;
    [SerializeField] GameObject rightJaw;
    private bool _triggered = false;

    private void AttachLeg(GameObject other)
    {
        if (other.CompareTag("Player"))
        {
            Rigidbody calfR = GameObject.Find("calf_r").GetComponent<Rigidbody>();
            Rigidbody calfL = GameObject.Find("calf_l").GetComponent<Rigidbody>();

            var rightLegDistance = Vector3.Distance(calfR.gameObject.transform.position,
                gameObject.transform.position);
            var leftLegDistance = Vector3.Distance(calfL.gameObject.transform.position,
                gameObject.transform.position);

            if (rightLegDistance < leftLegDistance)
            {
                calfR.MovePosition(this.gameObject.GetComponent<BoxCollider>().center);

                // calfR.gameObject.GetComponent<CharacterJoint>().connectedBody =
                //     this.gameObject.GetComponent<Rigidbody>();
                this.gameObject.GetComponent<FixedJoint>().connectedBody = calfR;

                calfR.centerOfMass = Vector3.zero;
                calfR.inertiaTensorRotation = Quaternion.identity;


                calfR.isKinematic = true;
            }
            else
            {
                calfL.MovePosition(this.gameObject.GetComponent<BoxCollider>().center);

                // calfL.gameObject.GetComponent<CharacterJoint>().connectedBody =
                //     this.gameObject.GetComponent<Rigidbody>();
                this.gameObject.GetComponent<FixedJoint>().connectedBody = calfL;


                calfL.centerOfMass = Vector3.zero;
                calfL.inertiaTensorRotation = Quaternion.identity;

                calfL.isKinematic = true;
            }
        }
    }


    void TrapCloseAnimation()
    {
        leftJaw.transform.Rotate(90.0f, 0.0f, 0.0f, Space.Self);
        rightJaw.transform.Rotate(-90.0f, 0.0f, 0.0f, Space.Self);
    }

    public void DealDamage(GameObject other)
    {
        AttachLeg(other);

        if (other.GetComponent<Death>() != null)
        {
            other.GetComponent<Death>().Die(other.TryGetComponent(out Player temp), DeathCause.Regular, null, null);
        }
    }


    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (!_triggered)
    //    {
    //        _triggered = true;
    //        DealDamage(collision.gameObject);
    //        TrapCloseAnimation();
    //        audioData.Play(0);
    //    }
    //}

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.GetComponent<Character>() != null)
        {
            DealDamage(other.gameObject);
            TrapCloseAnimation();
            audioData.Play(0);

        }



    }
}