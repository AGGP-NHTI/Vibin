using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceLines : MonoBehaviour
{
    public AudioSource source;

    public float MaxTime = 60f;
    public float MinTime = 15f;

    public float currentTime;

    public List<AudioClip> Lines;

    void Start()
    {
        OnTimeEnd();
    }
  
    void FixedUpdate()
    {
        currentTime -= Time.fixedDeltaTime;
        if (currentTime <= 0)
        {
            OnTimeEnd();

            int num = Random.Range(0, Lines.Capacity + 1);
            source.PlayOneShot(Lines[num], PlayerPrefs.GetFloat("Voices"));
        }
    }

    void OnTimeEnd()
    {
        currentTime = Random.Range(MinTime, MaxTime);
    }
}
