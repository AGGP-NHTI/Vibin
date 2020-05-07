using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class life : MonoBehaviour
{
    public List<hearts> health;
    public int healthindex = 0;
    public PlayerPawn player;
    int currentlife = 3;

    
    public void calldamage()
    {
        health[healthindex].Vanish();
        healthindex++;                         
    }
    void Update()
    {
        if (health[health.Capacity - 1] == null)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
        }
        if (player.health < currentlife)
        {
            calldamage();
            currentlife--;
        }
    }
    public void Reset()
    {
        currentlife = 3;
        healthindex = 0;
        foreach (hearts i in health)
        {
            i.gameObject.SetActive(true);
            i.transform.localScale = i.norm;
            i.go = false;
        }
        player.health = 3;
    }
}
