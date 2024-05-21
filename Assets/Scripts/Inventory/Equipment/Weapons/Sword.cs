using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : Item
{
    public override void Use(){
        Player.Instance.RightHand.GetComponent<Item>().OnAttack();
        Player.Instance.LeftHand.GetComponent<Item>().OnAttack();
        Player.Instance.Hat.GetComponent<Item>().OnAttack();
        Player.Instance.Chestplate.GetComponent<Item>().OnAttack();
        Player.Instance.Boots.GetComponent<Item>().OnAttack();
        Player.Instance.Trinket1.GetComponent<Item>().OnAttack();
        Player.Instance.Trinket2.GetComponent<Item>().OnAttack();
        if(!Fight.Instance.MobScript.Avoid()){
            int AttackDamage = Convert.ToInt32(Math.Ceiling(Player.Instance.DamageModifier*(Player.Instance.BaseDamage + Damage + Player.Instance.Trinket1.GetComponent<Item>().Damage + Player.Instance.Trinket2.GetComponent<Item>().Damage + Player.Instance.Hat.GetComponent<Item>().Damage + Player.Instance.Chestplate.GetComponent<Item>().Damage + Player.Instance.Boots.GetComponent<Item>().Damage)));
            AttackDamage = Convert.ToInt32(Math.Ceiling(AttackDamage* + Player.Instance.BuffsDamageModifier));
            AttackDamage += Convert.ToInt32(AttackDamage*Player.Instance.BrutalityStreak_AddDamageAll);
            Player.Instance.BrutalityStreak_AddDamageAll += Player.Instance.BrutalityStreak_AddDamage;
            bool IsCrit = Player.Instance.Crit();
            AttackDamage += Convert.ToInt32(AttackDamage*Convert.ToInt32(IsCrit)*Skills.Instance.Crit_Damage);
            Fight.Instance.MobScript.GetDamage(AttackDamage, true, IsCrit);
            Fight.Instance.EffectsManager.TriggerEffects(2, Player.Instance);
            Fight.Instance.EffectsManager.TriggerEffects(3, Fight.Instance.MobScript);
        }
        else {
            Player.Instance.BrutalityStreak_AddDamageAll = 0;
            Fight.Instance.MobScript.GetComponent<F_Text_Creator>().CreateText_Red(Language_Changer.Instance.GetText("Avoided"));
            Fight.Instance.EffectsManager.TriggerEffects(4, Fight.Instance.MobScript);
        }
        Player.Instance.SpeedEnergyRemove(EnergyUsage);
    }
}
