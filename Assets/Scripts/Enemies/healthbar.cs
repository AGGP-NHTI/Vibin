using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthbar : MonoBehaviour
{
    Vector3 scale;
    public GameObject spot;
    // Start is called before the first frame update
    void Start()
    {
        scale = gameObject.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = spot.transform.position;
        gameObject.transform.localScale = scale;
    }
}
