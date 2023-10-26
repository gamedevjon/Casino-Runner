using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    [SerializeField]
    private GameObject _resetPoint, _spawnPoint;
    [SerializeField]
    private float _speed = 2.0f;

    private void OnEnable()
    {
        GameManager.onStart += GameManager_onStart;
        GameManager.onStop += GameManager_onStop;
    } 

    private void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * _speed);

        if (transform.position.z <= _resetPoint.transform.position.z)
        {
            transform.position = _spawnPoint.transform.position;
        }
    }
    private void GameManager_onStart()
    {
        _speed = 10;
    }

    private void GameManager_onStop()
    {
        StartCoroutine(StopPathRoutine());
    }

    IEnumerator StopPathRoutine()
    {
        while (_speed > 0)
        {
            _speed -= Time.deltaTime * 5f;

            yield return new WaitForEndOfFrame();
        }
    }

    private void OnDisable()
    {
        GameManager.onStart -= GameManager_onStart;
        GameManager.onStop -= GameManager_onStop;
    }
}
