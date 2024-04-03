using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleEffectPotion : Item
{
    public int EffectId, Duration;

    public override void Use(){
        --Amount;
        Fight.Instance.EffectsManager.Add(EffectId, Duration, Player.Instance);
        Player.Instance.SpeedEnergyRemove(EnergyUsage);
    }
}
