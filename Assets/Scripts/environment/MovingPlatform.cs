﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{  
    GameObject currentTarget;

    public List<GameObject> PathList;

    public int PathListIndex = 0;
 
    public float currentSpeed = 5f;
   
    Vector3 MoveDirection;

    public bool HasDynamicDirection;
    public float WithinRange = .75f;
    Transform transf;

    void Start()
    {
        transf = gameObject.GetComponent<Transform>();
        NextTarget();
        UpdateMovedirection();      
    }
    
    void Update()
    {
        if (HasDynamicDirection)
        {

            UpdateMovedirection();
        }

        transf.position += (Time.deltaTime * MoveDirection * currentSpeed);

        if (IsCloseToTarget())
        {
            NextTarget();
            UpdateMovedirection();
        }       
    }

    public bool IsCloseToTarget()
    {
        if (GetDistanceTo(currentTarget) < WithinRange)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public float GetDistanceTo(GameObject Other)
    {
        float distanceTo = (Other.transform.position - transform.position).magnitude;

        return distanceTo;
    }
    public void NextTarget()
    {
        if (PathListIndex < PathList.Capacity - 1)
        {
            PathListIndex++;
        }
        else
        {
            PathListIndex = 0;
        }
        currentTarget = PathList[PathListIndex];

    }
    public void UpdateMovedirection()
    {
        MoveDirection = (currentTarget.transform.position - transf.position).normalized;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerPawn playerPawn = collision.gameObject.GetComponent(typeof(PlayerPawn)) as PlayerPawn;
        if (playerPawn != null)
        {
            playerPawn.transform.SetParent(gameObject.transform);
        }

        BaseStandardEnemy basestandardEnemy = collision.gameObject.GetComponent(typeof(BaseStandardEnemy)) as BaseStandardEnemy;
        if (basestandardEnemy != null)
        {
            basestandardEnemy.Parent.transform.SetParent(gameObject.transform);
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        PlayerPawn playerPawn = collision.gameObject.GetComponent(typeof(PlayerPawn)) as PlayerPawn;
        if (playerPawn != null)
        {
            playerPawn.transform.SetParent(null);
        }

        BaseStandardEnemy basestandardEnemy = collision.gameObject.GetComponent(typeof(BaseStandardEnemy)) as BaseStandardEnemy;
        if (basestandardEnemy != null)
        {
            basestandardEnemy.Parent.transform.SetParent(null);
        }
    }
}
