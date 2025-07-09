using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BS_Weakness : SkillTreeButton
{
    public override void OnClick()
    {
        GetCustomFormats();
        if(level==0) textName = "More_Effects";
        else textName = "Stronger_Weakness";
        GetText(Object: gameObject, Name: gameObject.name, TextName: textName, MaxUpgradesCount: maxUpgrades, Price1: upgradePrices[0], Price2: upgradePrices[1], Price3: upgradePrices[2], Price4: upgradePrices[3], Price5: upgradePrices[4], Format1: format1[Math.Min(maxUpgrades - 1, level)], Format2: format2[Math.Min(maxUpgrades - 1, level)], Format3: format3[Math.Min(maxUpgrades - 1, level)], StringFormat: stringFormat[Math.Min(maxUpgrades - 1, level)], HasCheck: hasCheck, HasSuffix: hasSuffix);
    }
}
