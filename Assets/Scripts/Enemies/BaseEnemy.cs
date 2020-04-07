using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : PWPawn
{
    public Vision vision;
    public Attack attack;
    public GameObject hitboxspawn;
    Vector3 localScale;

    public GameObject Player;
    public float idleWidth = 5f;
    public float speed = 2f;
    public float AT = 1f;
    public float damage = 2f;
    public float AttackDistance = 2f;
    bool movingRight = true;

    delegate void currentAction();
    currentAction currentaction;

    Vector3 startpos;
    Vector3 leftpos;
    Vector3 rightpos;
    
    void Start()
    {
        UpdateStartPos();
        rightpos.z = startpos.z;
        leftpos.z = rightpos.z;
        currentaction = Idle;
        localScale = transform.localScale;
    }
    
    void UpdateStartPos()
    {
        startpos = gameObject.transform.position;
        rightpos.x = startpos.x + idleWidth;
        leftpos.x = startpos.x - idleWidth;
        rightpos.y = startpos.y;
        leftpos.y = startpos.y;
    }
   
    void FixedUpdate()
    {
        currentaction();
        transform.localScale = localScale;
    }
    void Moving()
    {
        if (movingRight)
        {
            gameObject.transform.position += new Vector3(speed, 0, 0);
        }
        else
        {
            gameObject.transform.position += new Vector3(-speed, 0, 0);
        }
    }
    void Idle()
    {
        Moving();
        if (movingRight && Vector3.Distance(gameObject.transform.position, leftpos) >= 1)
        {
            movingRight = true;
            localScale.x *= -1;
        }
        else if (!movingRight && Vector3.Distance(gameObject.transform.position, rightpos) >= 1)
        {
            movingRight = false;
            localScale.x *= -1;
        }
        if (vision.sighted == true)
        {
            currentaction = Chase;
            
        }
    }
    void Chase()
    {
        if (Vector3.Distance(gameObject.transform.position, Player.transform.position) < AttackDistance)
        {
            currentaction = Attack;
        }
        if (vision.sighted == false)
        {
            currentaction = Idle;
            UpdateStartPos();
        }
    }
    void Attack()
    {
        UpdateStartPos();
       
        Attack clone = Instantiate(attack, hitboxspawn.transform.position, hitboxspawn.transform.rotation);
        currentaction = Idle;
    }
    void Hit()
    {
        UpdateStartPos();
    }
    
}
