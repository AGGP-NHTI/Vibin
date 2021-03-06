﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class savepoint : MonoBehaviour
{
    public GameObject Player;
    public GameObject Camera;
    public GameObject point;
    public SpriteRenderer renderer;
    public Sprite tagged;
    public AudioSource source;
    public AudioClip tag;
    public life bar;
    void Start()
    {
        if (PlayerPrefs.GetInt("AtBoss") == 1)
        {
            Player.transform.position = point.transform.position;
            Camera.transform.position = point.transform.position;
            renderer.sprite = tagged;
        }
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        
        if (collider.gameObject == Player)
        {
            if (PlayerPrefs.GetInt("AtBoss") == 0)
            {
                source.PlayOneShot(tag, PlayerPrefs.GetFloat("Effects", 0.5f));
                bar.Reset();
            }
            PlayerPrefs.SetInt("AtBoss", 1);
            renderer.sprite = tagged;
           
        }
    }
}
