using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
                Debug.LogError("GameManager is NULL");

            return _instance;
        }
    }

    public static event Action onStart;
    public static event Action onStop;

    private void Awake()
    {
        _instance = this;
    }

    public void Play()
    {
       onStart?.Invoke();
    }

    public void StopTracks()
    {
        onStop?.Invoke();
    }
}
