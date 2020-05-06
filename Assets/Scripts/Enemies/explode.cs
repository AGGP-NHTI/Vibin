using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explode : MonoBehaviour
{
    public AudioSource source;
    public AudioClip clip;
    public float lifetime = 1f;
    
    void Awake()
    {
        source.PlayOneShot(clip, PlayerPrefs.GetFloat("Effects", 0.5f));
    }
    
    void FixedUpdate()
    {
        lifetime -= Time.fixedDeltaTime;
        if (lifetime <= 0)
        {
            Destroy(gameObject);
        }
    }
}
