using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : Item
{
    public override void Use(ref int DamageAmount){
        if(!Fight.Instance.MobScript.Avoid()){
            int AttackDamage = Convert.ToInt32(Math.Ceiling(Player.Instance.DamageModifier*(Player.Instance.BaseDamage + Damage + Player.Instance.Trinket1.GetComponent<Item>().Damage + Player.Instance.Trinket2.GetComponent<Item>().Damage + Player.Instance.Hat.GetComponent<Item>().Damage + Player.Instance.Chestplate.GetComponent<Item>().Damage + Player.Instance.Boots.GetComponent<Item>().Damage)));
            AttackDamage = Convert.ToInt32(Math.Ceiling(AttackDamage* + Player.Instance.BuffsDamageModifier));
            AttackDamage += Convert.ToInt32(AttackDamage*Player.Instance.BrutalityStreak_AddDamageAll);
            Player.Instance.BrutalityStreak_AddDamageAll += Player.Instance.BrutalityStreak_AddDamage;
            bool IsCrit = Player.Instance.Crit();
            AttackDamage += AttackDamage*Convert.ToInt32(IsCrit);
            Fight.Instance.MobScript.GetDamage(AttackDamage, true, IsCrit);
        }
        else Player.Instance.BrutalityStreak_AddDamageAll = 0;
        Player.Instance.SpeedEnergyRemove(EnergyUsage);
    }
}
