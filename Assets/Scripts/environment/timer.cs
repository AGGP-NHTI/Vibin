using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class timer : MonoBehaviour
{
    public float time = 5f;
    public UnityEvent TimeUp;

    void Awake()
    {
        if (TimeUp == null)
            TimeUp = new UnityEvent();
    }
    void Update()
    {
        time -= Time.deltaTime;
        if (time >= 0)
        {
            OnTimeUp();
        }
    }
    public void OnTimeUp()
    {
        TimeUp.Invoke();
    }
}
