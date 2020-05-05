using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameRestart : MonoBehaviour
{
    public GameObject player;
    void Update()
    {
        if(player.gameObject.GetComponent<PlayerPawn>().health < 1)
        {
            SceneManager.LoadScene(0);
        }
    }
}
