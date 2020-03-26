using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PWPlayerController : PlayerController
{
   
   

  

    public override void Horizontal(float value)
    {
        PWPawn PWP = ((PWPawn)PossesedPawn);
        if (PWP)
        {
            PWP.Horizontal(value);
        }
    }

    public override void Vertical(float value)
    {
        PWPawn PWP = ((PWPawn)PossesedPawn);
        if (PWP)
        {
            PWP.Vertical(value);
        }

    }


    public override void Fire1(bool value)
    {
        //((PWPawn)PossesedPawn).Fire1(value);

        if (value)
        {
            LOG("PC: Fire1");
            PWPawn PWP = ((PWPawn)PossesedPawn); 
            if (PWP)
            {
                PWP.Fire1(value);
            }


        }
    }

    public override void Fire2(bool value)
    {
        if (value)
        {
            LOG("PC: Fire2");
            PWPawn PWP = ((PWPawn)PossesedPawn);
            if (PWP)
            {
                PWP.Fire2(value);
            }
        }
    }

    public override void Fire3(bool value)
    {
        if (value)
        {
            LOG("PC: Fire3");
            PWPawn PWP = ((PWPawn)PossesedPawn);
            if (PWP)
            {
                PWP.Fire3(value);
            }
        }

    }


}
