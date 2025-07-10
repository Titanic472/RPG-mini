using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class CustomSkillsTextFormatter
{
    public static float GetText(string name, int formatterIndex)
    {
        switch (name)
        {
            case "SkilledTree_1Perc":
                return Math.Min(4, Skills.Instance.SkilledTree_1Perc_Universal + 1);
            case "Shield_MagicDef_2Perc_1":
                return Skills.Instance.Shield_MagicDefence * 100;
            case "Shield_MagicDef_2Perc_2":
                return Skills.Instance.Shield_MagicDefence * 100;
            case "Shield_DmgReturn_1Perc_1":
                return Skills.Instance.Shield_DamageReturn * 100;
            case "Shield_DmgReturn_1Perc_2":
                return Skills.Instance.Shield_DamageReturn * 100;
            case "EvasionMain":
                return Player.Instance.BaseEvasion;
            case "AvoidChance_1Perc_1":
                return Player.Instance.MaxAvoidChance;
            case "AvoidChance_1Perc_2":
                return Player.Instance.MaxAvoidChance;
            case "AvoidChance_2Perc_1":
                return Player.Instance.MaxAvoidChance;
            case "AvoidChance_2Perc_2":
                return Player.Instance.MaxAvoidChance;
            case "AvoidChance_2Perc_3":
                return Player.Instance.MaxAvoidChance;
            case "Shield_DMGResistance_1Perc_1":
                return Skills.Instance.Shield_DMGResistance_2Perc_1*2+Skills.Instance.Shield_DMGResistance_1Perc_1;
            case "Shield_DMGResistance_2Perc_1":
                return Skills.Instance.Shield_DMGResistance_2Perc_1*2+Skills.Instance.Shield_DMGResistance_1Perc_1;
            case "Shield_AvoidChance1Perc_1":
                return Skills.Instance.Shield_AvoidChance2Perc_1 * 2 + Skills.Instance.Shield_AvoidChance1Perc_1;
            case "Shield_AvoidChance2Perc_1":
                return Skills.Instance.Shield_AvoidChance2Perc_1 * 2 + Skills.Instance.Shield_AvoidChance1Perc_1;
            case "AccuracyMain":
                return Player.Instance.BaseAccuracy;
            case "CritChance_2Perc_1":
                return Player.Instance.MaxCritChance;
            case "CritChance_2Perc_2":
                return Player.Instance.MaxCritChance;
            case "CritChance_2Perc_3":
                return Player.Instance.MaxCritChance;
            case "CritChance_4Perc_1":
                return Player.Instance.MaxCritChance;
            case "CritDamage_3Perc_1":
                return (Skills.Instance.Crit_Damage + 1) * 100;
            case "CritDamage_3Perc_2":
                return (Skills.Instance.Crit_Damage + 1) * 100;
            case "CritDamage_5Perc_1":
                return (Skills.Instance.Crit_Damage + 1) * 100;
            case "CritDamage_5Perc_2":
                return (Skills.Instance.Crit_Damage + 1) * 100;
            case "CritDamage_10Perc_1":
                return (Skills.Instance.Crit_Damage + 1) * 100;
            case "DMGCapOverdamage_10Perc_1":
                return Skills.Instance.DMGCapOverdamage * 100;
            case "DMGCapOverdamage_10Perc_2":
                return Skills.Instance.DMGCapOverdamage * 100;
            case "DMGCapOverdamage_Unlock":
                return Skills.Instance.DMGCapOverdamage * 100;
            case "Shield_NoStaminaUsage_5Perc":
                return Math.Min(25, Skills.Instance.Shield_NoStaminaUsage_5Perc * 5);
            default:
                return -1010101010;//error handler
        }
    }
}
