using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleEffectPotion : Item
{
    public int EffectId, Duration;

    public override void Use(){
        --Amount;
        Fight.Instance.EffectsManager.Add(EffectId, Duration, Player.Instance);
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
