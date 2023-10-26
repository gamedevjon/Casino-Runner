using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Animator _anim;

    private Vector3 _targetPos;

    private int _boundsCheck = 0;

    private void OnEnable()
    {
        GameManager.onStart += GameManager_onStart;
    }

    private void GameManager_onStart()
    {
        _anim.SetBool("Moving", true);
    }

    private void Start()
    {
        _anim = GetComponent<Animator>();

        int random = Random.Range(0, 5);

        _anim.SetInteger("RandomIdle", random);

        _targetPos = transform.position;
    }

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, _targetPos, Time.deltaTime * 10f);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //slide
            _anim.SetTrigger("Sliding");
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            if (_boundsCheck == -1)
                return;

            _boundsCheck--;
            _targetPos += Vector3.left;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            if (_boundsCheck == 1)
                return;

            _boundsCheck++;
            _targetPos += Vector3.right;
        }


    }

    private void OnDisable()
    {
        GameManager.onStart -= GameManager_onStart; 
    }
}
