using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharWalk : MonoBehaviour
{
    public float speed = 5f;
    bool _walkTime = false;
    [SerializeField] GameObject _mainCharacter;

    private void Update()
    {
        if (_walkTime)
        {
            _mainCharacter.transform.Translate(Vector3.forward * speed * Time.deltaTime);
            _mainCharacter.GetComponent<AnimatorController>().WalkMain();

        }
    }

    public void WalkBit()
    {
        _walkTime = true;
    }
    public void StopWalk()
    {
        _walkTime = false;
    }
}
