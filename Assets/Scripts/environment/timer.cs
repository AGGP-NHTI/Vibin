using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class timer : MonoBehaviour
{
    public float time = 5f;
    public UnityEvent TimeUp;

    public bool StartOnGameStart = false;
    public bool starttime = false;

    void Awake()
    {
        if (TimeUp == null)
        {
            TimeUp = new UnityEvent();
        }
    }
    void Update()
    {
        if (StartOnGameStart || starttime)
        {
            time -= Time.deltaTime;
            if (time >= 0)
            {
                OnTimeUp();
            }
        }
    }
    public void OnTimeUp()
    {
        TimeUp.Invoke();
    }
    public void startTimer()
    {
        starttime = true;
    }
}
