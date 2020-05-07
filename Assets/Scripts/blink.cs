using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blink : MonoBehaviour
{
    public PlayerPawn player;
    public SpriteRenderer renderer;
    public Color invis;
    Color normal;
    public float frequency = 0.1f;
    float fre;
    bool on = false;

    void Start()
    {
        normal = renderer.color;
        fre = frequency;
    }
    void Update()
    {
        if (player.invincible)
        {
            flash();
        }
        else
        {
            renderer.color = normal;
        }
    }
    void flash()
    {
        fre -= Time.fixedDeltaTime;
        if (fre <= 0)
        {
            if (on)
            {
                renderer.color = invis;
                on = false;
            }
            else if (!on)
            {
                renderer.color = normal;
                on = true;
            }
            fre = frequency;
        }
    }
}
