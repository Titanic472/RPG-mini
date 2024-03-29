using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chestplate : Item
{
    public override void OnReceiveDamage(ref int IncomingDamage){
        IncomingDamage-=UnityEngine.Random.Range(MinDefence, MaxDefence+1);
        if(IncomingDamage<0)IncomingDamage = 0;
    }
}
