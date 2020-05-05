using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endmusic : MonoBehaviour
{
    public float length = 7f;
    public AudioSource first;
    public AudioSource loop;
    
    void Start()
    {
        loop.Play();
        loop.Pause();
    }

    
    void FixedUpdate()
    {
        length -= Time.fixedDeltaTime;
        if (length <= 0)
        {
            first.gameObject.SetActive(false);
            loop.UnPause();
        }
    }
}
