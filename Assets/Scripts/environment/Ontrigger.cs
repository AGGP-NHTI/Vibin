using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Ontrigger : MonoBehaviour
{
    public List<GameObject> TurnOn;    
    public List<GameObject> TurnOff;

    public UnityEvent WhenTriggerEntered;

    void Awake()
    {
        if (WhenTriggerEntered == null)
        {
            WhenTriggerEntered = new UnityEvent();
        }
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        PlayerPawn playerPawn = collider.GetComponent(typeof(PlayerPawn)) as PlayerPawn;

        if (playerPawn != null)
        {
            Activate();
            TriggerEntered();
        }
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
    public void DeActivate()
    {
        foreach (GameObject i in TurnOn)
        {
            i.SetActive(false);
        }
        foreach (GameObject i in TurnOff)
        {
            i.SetActive(true);
        }
    }
    public void TriggerEntered()
    {
        WhenTriggerEntered.Invoke();
    }
}