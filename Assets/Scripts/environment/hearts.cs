using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hearts : MonoBehaviour
{
    public bool go = false;
    public float rate = 5f;
    public AudioSource audiosource;
    public AudioClip clip;
    bool ff = true;
    public Vector3 norm;
    void Start()
    {
        norm = gameObject.transform.localScale;
    }
    void Update()
    {
        if (go)
        {
            transform.localScale -= new Vector3(rate, rate, rate) * Time.fixedDeltaTime;
            if (ff)
            {
                audiosource.PlayOneShot(clip, PlayerPrefs.GetFloat("Effects", 0.5f));
                ff = false;
            }
            if (transform.localScale.x <= 0)
            {
                gameObject.SetActive(false);
            }
        }
    }
    public void Vanish()
    {
        go = true;
    }
}
