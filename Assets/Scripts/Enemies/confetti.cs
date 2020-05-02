using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class confetti : MonoBehaviour
{
    public EnemyProjectile projectile;
    public Sprite end;
    float time;
    public SpriteRenderer spriteR;
    // Start is called before the first frame update
    void Awake()
    {
        time = projectile.LT;
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.fixedDeltaTime;
        if (time <= 0.2)
        {
            spriteR.sprite = end;
        }
    }
}
