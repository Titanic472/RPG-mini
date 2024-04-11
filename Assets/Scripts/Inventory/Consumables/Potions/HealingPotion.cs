using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingPotion : Item
{
    public override void Use(){
        if(Player.Instance.Health == Player.Instance.MaxHealth) return;
        --Amount;
        float Modifier = 1;
        if(Fight.Instance.EffectsManager.GetEffect(10, Player.Instance)){
            if(Fight.Instance.InBattle){
                if(Player.Instance.Health > Player.Instance.MaxHealth/2) Fight.Instance.MobScript.TriggerHeal(Convert.ToInt32((float)(Player.Instance.MaxHealth-Player.Instance.Health)*0.2f));
                else Fight.Instance.MobScript.TriggerHeal(Convert.ToInt32((float)Player.Instance.MaxHealth*0.1f));
            }
            Modifier = 0.8f;
        }
        if(Fight.Instance.EffectsManager.GetEffect(9, Player.Instance)) Modifier *= 0.5f;
        if(Fight.Instance.InBattle){
            if(Player.Instance.MaxHealth - Player.Instance.Health > Convert.ToInt32((float)Player.Instance.MaxHealth/2*Modifier)) Player.Instance.SelfSprite.GetComponent<F_Text_Creator>().CreateText_Green(Convert.ToInt32((float)Player.Instance.MaxHealth/2*Modifier) + "");
            else Player.Instance.SelfSprite.GetComponent<F_Text_Creator>().CreateText_Green(Player.Instance.MaxHealth - Player.Instance.Health + ""); 
            Fight.Instance.PotionSlots_Reload();
        }
        Player.Instance.Heal(Modifier);
        Player.Instance.RightHand.GetComponent<Item>().OnPotionUse();
        Player.Instance.LeftHand.GetComponent<Item>().OnPotionUse();
        Player.Instance.Hat.GetComponent<Item>().OnPotionUse();
        Player.Instance.Chestplate.GetComponent<Item>().OnPotionUse();
        Player.Instance.Boots.GetComponent<Item>().OnPotionUse();
        Player.Instance.Trinket1.GetComponent<Item>().OnPotionUse();
        Player.Instance.Trinket2.GetComponent<Item>().OnPotionUse();
        Player.Instance.SpeedEnergyRemove(EnergyUsage);
    }
}
