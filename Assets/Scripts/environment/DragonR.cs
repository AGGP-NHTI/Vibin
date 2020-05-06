using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonR : MonoBehaviour
{
    public AudioSource source;
    public AudioClip clip;
    public BossLocation bossLocation;
    public GameObject center;

    void OnTriggerEnter2D(Collider2D collider)
    {
        PlayerPawn playerPawn = collider.GetComponent(typeof(PlayerPawn)) as PlayerPawn;

        if (playerPawn != null)
        {
            source.PlayOneShot(clip, PlayerPrefs.GetFloat("Effects"));
            bossLocation.currentTarget = center;
            Destroy(gameObject);
        }
    }
}
