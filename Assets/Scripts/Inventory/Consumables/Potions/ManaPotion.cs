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
        Player.Instance.SpeedEnergyRemove(EnergyUsage);
    }
}
