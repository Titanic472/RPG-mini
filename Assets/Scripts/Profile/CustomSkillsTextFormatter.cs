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
            default:
                return -1010101010;//error handler
        }
    }
}
