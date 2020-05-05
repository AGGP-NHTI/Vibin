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
    }
    void Update()
    {
        if (health[health.Capacity - 1] == null)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
        }
    }
}
