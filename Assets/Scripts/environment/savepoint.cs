using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class savepoint : MonoBehaviour
{
    public GameObject Player;
    public GameObject point;
    void Start()
    {
        if (PlayerPrefs.GetInt("AtBoss") == 1)
        {
            Player.transform.position = point.transform.position;
        }
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject == Player)
        {
            PlayerPrefs.SetInt("AtBoss", 1);
        }
    }
}
