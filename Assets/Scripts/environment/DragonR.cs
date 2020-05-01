using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonR : MonoBehaviour
{
    public AudioSource source;
    public AudioClip clip;

    void OnTriggerEnter2D(Collider2D collider)
    {
        PlayerPawn playerPawn = collider.GetComponent(typeof(PlayerPawn)) as PlayerPawn;

        if (playerPawn != null)
        {
            source.PlayOneShot(clip, PlayerPrefs.GetFloat("Effects"));
            Destroy(gameObject);
        }
    }
}
