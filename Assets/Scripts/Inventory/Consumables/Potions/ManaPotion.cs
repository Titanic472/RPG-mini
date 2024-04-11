using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaPotion : Item
{
    public override void Use(){
        if(Player.Instance.Mana == Player.Instance.MaxMana) return;
        --Amount;
        if(Fight.Instance.InBattle)Fight.Instance.PotionSlots_Reload();
        Player.Instance.ManaRestore();
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
