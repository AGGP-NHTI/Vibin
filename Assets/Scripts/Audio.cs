using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    public AudioSource audioSource;
    public bool music = false;
    public bool effect = true;
    // Start is called before the first frame update
    void Start()
    {
        if (music)
        {
            audioSource.volume = PlayerPrefs.GetFloat("Music");
        }
        if (effect)
        {
            audioSource.volume = PlayerPrefs.GetFloat("Effects");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Pause()
    {
        audioSource.Pause();
    }
    public void Play()
    {
        audioSource.Play(0);
    }
}
