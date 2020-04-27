using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ontrigger : MonoBehaviour
{
    public List<GameObject> TurnOn;    
    public List<GameObject> TurnOff;    
    void OnTriggerEnter2D(Collider2D collider)
    {
        Activate();
    }
    public void Activate()
    {
        foreach (GameObject i in TurnOn)
        {
            i.SetActive(true);
        }
        foreach (GameObject i in TurnOff)
        {
            i.SetActive(false);
        }
    }
}