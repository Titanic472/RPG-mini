using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : Item
{
    public override void Use(){
        if(ShieldingLevel<3){
            ShieldingLevel+=1;
            Fight.Instance.ReloadShieldingLevelImage();
            Player.Instance.SpeedEnergyRemove(EnergyUsage);
        }
    }

    public override void OnReceiveDamage(ref int IncomingDamage){
        IncomingDamage -= DamageReduction*ShieldingLevel;
        if(IncomingDamage<0)IncomingDamage = 0;
    }

    public override void OnNextTurn(){
        ShieldingLevel = 0;
        Fight.Instance.ReloadShieldingLevelImage();
    }
    
}
