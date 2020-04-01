using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PWPawn : Pawn {

    public float StartingHealth = 100.0f;
    public float Health = 100.0f;

    public virtual void Horizontal(float value)
    {
       
    }

    public virtual void Vertical(float value)
    {
       
    }

    public virtual void Fire1(bool value)
    {
        LOG("Pawn: Fire1");   
    }

    public virtual void Fire2(bool value)
    {
       
    }

    protected override bool ProcessDamage(Actor Source, float Value, DamageEventInfo EventInfo, Controller Instigator)
    {
        // Setup for Logging Dammage Information  
        string DamageEventString = Source.ActorName + " " + EventInfo.DamageType.verb + " " + this.ActorName + " (" + Value.ToString() + " damage)";
        if (Instigator)
        {
            DamageEventString = Instigator.Name + " via " + DamageEventString;
        }
        else
        {
            DamageEventString = "The World via " + DamageEventString;
        }
        DAMAGELOG(DamageEventString);

        //Applying damage to health

   
        Health -= Value;

        if (Health <= 0f)
        {
            if (Instigator)
            {
                PWPlayerController PWPC = ((PWPlayerController)Instigator);
                PWPlayerController PWPCthis = ((PWPlayerController)controller);
                LOG(PWPC.PlayerName + " Killed " + PWPCthis.PlayerName);


            }
            else
            {
                PWPlayerController PWPCthis = ((PWPlayerController)controller);
                LOG("World Killed " + PWPCthis.PlayerName);
            }

            IgnoresDamage = true;

            Game.Self.GetSpectator(controller);


        }



        return true;
    }
}
