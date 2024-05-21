using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Accuracy : SkillTreeSegment
{
    public GameObject AccuracyMain, BLU, BL_Cooldown, BL_Chance, BL_ReturnDamage, BrutalityStreak_Unlock, BrutalityStreak_EnergySave, BrutalityStreak_AvoidChance, BrutalityStreak_SpecialAttacksTrigger, Shield_NoStaminaUsage_5Perc, Shield_DamageBoost_3Perc, DMG_2_1, DMG_1Perc_1, HP_1Perc_1, EV_4_ACC_4_1, HP_25_1, DMG_2Perc_1, HP_2Perc_1, DMG_4_1, DMG_4_2, DMG_2Perc_2, DMG_5_1, EV_10_ACC_10_1, HP_30_1, EV_10_ACC_10_2, EV_6_ACC_6_1, DMG_5_2, DMG_5Perc_1, HP_5Perc_1, CritChance_2Perc_1, ACC_10_1, CritDamage_5Perc_1, CritChance_2Perc_2, CritChance_2Perc_3, CritDamage_5Perc_2, HP_30_2, HP_2Perc_2, CritChance_4Perc_1, HP_25_2, CritDamage_10Perc_1, ACC_10_3, CritDamage_10Perc_2, CritDamage_20Perc_1, ACC_10_4, HP_40_1, DMGCapOverdamage_Unlock, DMGCapOverdamage_10Perc_1, ACC_10_2, DMGCapOverdamage_10Perc_2, EV_10_ACC_10_3;
    int SkillsUpgradeCost;
    
    void Awake(){
        Class = "Accuracy";
    }

    public void AccuracyMain_Text(){
        SkillsUpgradeCost = 1;
        if(SkillManager.AccuracyMain>=1) SkillsUpgradeCost = 2;
        if(SkillManager.AccuracyMain>=5) SkillsUpgradeCost = 3;
        if(SkillManager.AccuracyMain>=15) SkillsUpgradeCost = 4;
        if(SkillManager.AccuracyMain==24) SkillsUpgradeCost = 5;
        GetText(Object: AccuracyMain, Name: "AccuracyMain", TextName: "AccuracyMain", Price1: SkillsUpgradeCost, HasCheck: false, HasSuffix: false);
    }

    public void AccuracyMain_Upgrade(){
        Upgrade(Object: AccuracyMain, Name: "AccuracyMain", Price1: SkillsUpgradeCost, Invoke1:"Accuracy", MaxUpgradesCount: -1, HasSuffix: false, SetInteractable1: BLU, CheckVal1: 1, SetInteractable2: CritChance_2Perc_1, CheckVal2: 1, SetInteractable3: DMG_2_1, CheckVal3: 1, SetInteractable4: BrutalityStreak_Unlock, CheckVal4: 1);
    }

}