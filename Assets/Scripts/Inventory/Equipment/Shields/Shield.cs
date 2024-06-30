using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : Item
{
    
    public override void Use(){
        if(ShieldingLevel<1+Skills.Instance.ShieldStacking){
            ShieldingLevel+=1;
            if(Skills.Instance.Shield_DamageBoost>0)Player.Instance.TemporaryDamageBoost += Skills.Instance.Shield_DamageBoost;
            if(Skills.Instance.Shield_MagicDefence>0)Player.Instance.MagicDefence += Skills.Instance.Shield_MagicDefence;
            Fight.Instance.ReloadShieldingLevelImage();
            int Chance = UnityEngine.Random.Range(0, 100);
            if(!(Chance<Skills.Instance.Shield_NoStaminaUsageChance*100))Player.Instance.SpeedEnergyRemove(EnergyUsage);
        }
    }

    public override void OnReceiveDamage(ref int IncomingDamage){
        if(Skills.Instance.Shield_DamageReturn>0)Fight.Instance.MobScript.GetDamage(Convert.ToInt32(Math.Ceiling(IncomingDamage*Skills.Instance.Shield_DamageReturn*ShieldingLevel)));
        if(Skills.Instance.Shield_DamageResistance>0)IncomingDamage -= Convert.ToInt32(IncomingDamage*Skills.Instance.Shield_DamageResistance*ShieldingLevel);
        IncomingDamage -= DamageReduction*ShieldingLevel;
        if(IncomingDamage<0 && Skills.Instance.Shield_ParryChance_1Perc>0)Player.Instance.Parry_ChanceAll += Skills.Instance.Shield_ParryChance_1Perc;
        if(IncomingDamage<0 && Fight.Instance.MobScript.Health == 0)IncomingDamage = 0;
    }

    public override void OnNextTurn(){
        Player.Instance.MagicDefence -= Skills.Instance.Shield_MagicDefence*ShieldingLevel;
        Player.Instance.TemporaryDamageBoost -= Skills.Instance.Shield_DamageBoost*ShieldingLevel;
        ShieldingLevel = 0;
        Fight.Instance.ReloadShieldingLevelImage();
    }
    
}
