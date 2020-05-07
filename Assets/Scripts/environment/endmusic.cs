using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endmusic : MonoBehaviour
{
    public float length = 7f;
    public AudioSource first;
    public AudioSource loop;
    bool ff = true;
    
    void Start()
    {
        loop.Play();
        loop.Pause();
    }

    
    void FixedUpdate()
    {
        if (first.isPlaying == false)
        {
            if (ff)
            {
                ff = false;
                loop.PlayDelayed(length);
            }
        }
    }
}
