using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SkillTreeMultiupgradeButton : SkillTreeButton
{
    protected int SkillsUpgradeCost;

    protected void CalculateUpgradeCost()
    {
        SkillsUpgradeCost = 1;
        if (level >= 1) SkillsUpgradeCost = 2;
        if (level >= 5) SkillsUpgradeCost = 3;
        if (level >= 15) SkillsUpgradeCost = 4;
        if (level >= 24) SkillsUpgradeCost = 5;
    }
    public override void OnClick()
    {
        CalculateUpgradeCost();
        GetCustomFormats();
        GetText(Object: gameObject, Name: gameObject.name, TextName: textName, MaxUpgradesCount: maxUpgrades, Price1: SkillsUpgradeCost, Format1: format1[0], Format2: format2[0], Format3: format3[0], StringFormat: stringFormat[0], HasCheck: false, HasSuffix: false);
    }

    public override void UpgradeClick()
    {
        CalculateUpgradeCost();
        int[] checkValues = new int[4];
        for (int i = 0; i < 4; ++i)
        {
            if (childsConnected[i] != null)
            {
                checkValues[i] = childsConnected[i].GetComponent<SkillTreeButton>().previousButtonLevelToUnlock;
            }
            else checkValues[i] = -1;
        }
        Upgrade(Object: gameObject, Name: gameObject.name, Price1: SkillsUpgradeCost, Invoke1: invokes[0], Invoke2: invokes[1], IsBool: false, MaxUpgradesCount: maxUpgrades, HasSuffix: false, SetInteractable1: childsConnected[0], CheckVal1: checkValues[0], SetInteractable2: childsConnected[1], CheckVal2: checkValues[1], SetInteractable3: childsConnected[2], CheckVal3: checkValues[2], SetInteractable4: childsConnected[3], CheckVal4: checkValues[3]);
        ++level;
    }
}
