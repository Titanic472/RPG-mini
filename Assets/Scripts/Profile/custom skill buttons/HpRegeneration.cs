using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpRegeneration : SkillTreeMultiupgradeButton
{
    private void CheckUpgrade()
    {
        CheckUpgradeSingle(gameObject, gameObject.name, Lvl: 0, CheckValLvl1: 15*(SkillManager.HPRegen+1), Case: SkillManager.AllUpgrades);
    }

    public override void OnClick()
    {
        CalculateUpgradeCost();
        GetCustomFormats();
        GetText(Object: gameObject, Name: gameObject.name, TextName: textName, MaxUpgradesCount: maxUpgrades, Price1: SkillsUpgradeCost, Format1: SkillsUpgradeCost*2, HasCheck: true, HasSuffix: false);
    }
}
