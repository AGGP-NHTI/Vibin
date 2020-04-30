using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialMessageScript : MonoBehaviour
{
    public GameObject message;


    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        message.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        message.SetActive(false);
    }
}
