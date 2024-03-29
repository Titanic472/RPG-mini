using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hat : Item
{
    public override void OnReceiveDamage(ref int IncomingDamage){
        IncomingDamage-=UnityEngine.Random.Range(MinDefence, MaxDefence+1);
        if(IncomingDamage<0)IncomingDamage = 0;
    }
}
