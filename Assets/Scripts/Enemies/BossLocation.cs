using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLocation : MonoBehaviour
{
    public Boss boss;
    public float movespeed;
    public GameObject currentTarget;
    Transform transf;
    public bool isClose = false;
    Vector3 MoveDirection;
    public float WithinRange;
    float hold;
    // Start is called before the first frame update
    void Start()
    {
        if (boss != null)
        {
            currentTarget = boss.gameObject;
        }
        

        transf = gameObject.GetComponent<Transform>();
    }
    void Awake()
    {
        if (boss == null)
        {
            gameObject.transform.SetParent(null);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (boss != null)
        {
            MoveDirection = (currentTarget.transform.position - transf.position).normalized;
            transf.position += (Time.deltaTime * MoveDirection * movespeed);
        }
        if (boss == null)
        {
            if (!IsCloseToTarget())
            {
                MoveDirection = (currentTarget.transform.position - transf.position).normalized;
                transf.position += (Time.deltaTime * MoveDirection * movespeed);
            }
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
}
