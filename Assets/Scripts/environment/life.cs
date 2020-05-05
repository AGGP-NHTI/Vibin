using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class life : MonoBehaviour
{
    public List<hearts> health;
    public int healthindex = 0;
    
    public void calldamage()
    {
        health[healthindex].Vanish();
        healthindex++;
        if (healthindex <= health.Capacity -1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
        }
    }
}
