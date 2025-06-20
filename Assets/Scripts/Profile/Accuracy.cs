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
        branchName = "Accuracy";
    }

    public void AccuracyMain_Text(){
        SkillsUpgradeCost = 1;
        if(SkillManager.AccuracyMain>=1) SkillsUpgradeCost = 2;
        if(SkillManager.AccuracyMain>=5) SkillsUpgradeCost = 3;
        if(SkillManager.AccuracyMain>=15) SkillsUpgradeCost = 4;
        if(SkillManager.AccuracyMain>=24) SkillsUpgradeCost = 5;
        GetText(Object: AccuracyMain, Name: "AccuracyMain", TextName: "Accuracy", Price1: SkillsUpgradeCost, MaxUpgradesCount: -1, Format1: player.BaseAccuracy, HasCheck: false, HasSuffix: false);
    }

    public void AccuracyMain_Upgrade(){
        Upgrade(Object: AccuracyMain, Name: "AccuracyMain", Price1: SkillsUpgradeCost, Invoke1:"Accuracy", MaxUpgradesCount: -1, HasSuffix: false, SetInteractable1: BLU, CheckVal1: 1, SetInteractable2: CritChance_2Perc_1, CheckVal2: 1, SetInteractable3: DMG_2_1, CheckVal3: 1, SetInteractable4: BrutalityStreak_Unlock, CheckVal4: 1);
    }

    public void BLU_CheckUpgrade(){
        CheckUpgradeSingle(BLU, "BLU", Lvl: Convert.ToInt32(SkillManager.BLU), CheckValLvl1: 10);
    }

    public void BLU_Text(){
        GetText(BLU, "BLU", TextName: "Block_Unlock", MaxUpgradesCount: 1, Price1: 3, HasSuffix: false);
    }

    public void BLU_Upgrade(){
        Upgrade(BLU, "BLU", MaxUpgradesCount: 1, Price1: 3, HasSuffix: false, IsBool:true, SetInteractable1: BL_Cooldown, CheckVal1: 1, SetInteractable2: BL_Chance, CheckVal2: 1, SetInteractable3: BL_ReturnDamage, CheckVal3: 1);
        SkillManager.ActiveSkillsManager.SkillsUnlockCheck();
    }

    public void BL_Cooldown_CheckUpgrade(){
        CheckUpgradeSingle(BL_Cooldown, "BL_Cooldown", Lvl: Convert.ToInt32(SkillManager.BL_Cooldown), CheckValLvl1: 20, CheckValLvl2: 65);
    }

    public void BL_Cooldown_Text(){
        int Format;
        switch(SkillManager.BL_Cooldown){
            case 0:
                Format = 5;
                break;
            default:
                Format = 4;
                break;
        }
        GetText(BL_Cooldown, "BL_Cooldown", TextName: "Block_Cooldown", MaxUpgradesCount: 2, Price1: 3, Price2: 4, Format1: Format, HasSuffix: false);
    }

    public void BL_Cooldown_Upgrade(){
        Upgrade(BL_Cooldown, "BL_Cooldown", MaxUpgradesCount: 2, Price1: 3, Price2: 4, HasSuffix: false);
    }

    public void BL_Chance_CheckUpgrade(){
        CheckUpgradeSingle(BL_Chance, "BL_Chance", Lvl: Convert.ToInt32(SkillManager.BL_Chance), CheckValLvl1: 25, CheckValLvl2: 40, CheckValLvl3: 60);
    }

    public void BL_Chance_Text(){
        int Format;
        switch(SkillManager.BL_Chance){
            case 0:
                Format = 70;
                break;
            case 1:
                Format = 80;
                break;
            default:
                Format = 95;
                break;
        }
        GetText(BL_Chance, "BL_Chance", TextName: "Block_Chance", MaxUpgradesCount: 3, Price1: 2, Price2: 3, Price3: 5, Format1: Format, HasSuffix: false);
    }

    public void BL_Chance_Upgrade(){
        Upgrade(BL_Chance, "BL_Chance", MaxUpgradesCount: 3, Price1: 2, Price2: 3, Price3: 5, HasSuffix: false);
    }

    public void BL_ReturnDamage_CheckUpgrade(){
        CheckUpgradeSingle(BL_ReturnDamage, "BL_ReturnDamage", Lvl: Convert.ToInt32(SkillManager.BL_ReturnDamage), CheckValLvl1: 20, CheckValLvl2: 50, CheckValLvl3: 75);
    }

    public void BL_ReturnDamage_Text(){
        int Format;
        switch(SkillManager.BL_ReturnDamage){
            case 0:
                Format = 25;
                break;
            case 1:
                Format = 35;
                break;
            default:
                Format = 50;
                break;
        }
        GetText(BL_ReturnDamage, "BL_ReturnDamage", TextName: "Strike_Back", MaxUpgradesCount: 3, Price1: 3, Price2: 4, Price3: 4, Format1: Format, HasSuffix: false);
    }

    public void BL_ReturnDamage_Upgrade(){
        Upgrade(BL_ReturnDamage, "BL_ReturnDamage", MaxUpgradesCount: 3, Price1: 3, Price2: 4, Price3: 4, HasSuffix: false);
    }

    public void BrutalityStreak_Unlock_CheckUpgrade(){
        CheckUpgradeSingle(BrutalityStreak_Unlock, "BrutalityStreak_Unlock", Lvl: Convert.ToInt32(SkillManager.BrutalityStreak_Unlock), CheckValLvl1: 20);
    }

    public void BrutalityStreak_Unlock_Text(){
        GetText(BrutalityStreak_Unlock, "BrutalityStreak_Unlock", TextName: "Brutality_Streak_Unlock", MaxUpgradesCount: 1, Price1: 4, HasSuffix: false);
    }

    public void BrutalityStreak_Unlock_Upgrade(){
        Upgrade(BrutalityStreak_Unlock, "BrutalityStreak_Unlock", MaxUpgradesCount: 1, Price1: 4, HasSuffix: false, IsBool:true, SetInteractable1: BrutalityStreak_EnergySave, CheckVal1: 1, SetInteractable2: Shield_NoStaminaUsage_5Perc, CheckVal2: 1);
    }

    public void BrutalityStreak_EnergySave_CheckUpgrade(){
        CheckUpgradeSingle(BrutalityStreak_EnergySave, "BrutalityStreak_EnergySave", Lvl: Convert.ToInt32(SkillManager.BrutalityStreak_EnergySave), CheckValLvl1: 30, CheckValLvl2: 50, CheckValLvl3: 90);
    }

    public void BrutalityStreak_EnergySave_Text(){
        int Format;
        switch(SkillManager.BrutalityStreak_EnergySave){
            case 0:
                Format = 2;
                break;
            case 1:
                Format = 3;
                break;
            default:
                Format = 4;
                break;
        }
        GetText(BrutalityStreak_EnergySave, "BrutalityStreak_EnergySave", TextName: "Energy_Saving", MaxUpgradesCount: 3, Price1: 2, Price2: 4, Price3: 5, Format1: Format, HasSuffix: false);
    }

    public void BrutalityStreak_EnergySave_Upgrade(){
        Upgrade(BrutalityStreak_EnergySave, "BrutalityStreak_EnergySave", MaxUpgradesCount: 3, Price1: 2, Price2: 4, Price3: 5, HasSuffix: false, SetInteractable1: BrutalityStreak_AvoidChance, CheckVal1: 1);
    }

    public void BrutalityStreak_AvoidChance_CheckUpgrade(){
        CheckUpgradeSingle(BrutalityStreak_AvoidChance, "BrutalityStreak_AvoidChance", Lvl: Convert.ToInt32(SkillManager.BrutalityStreak_AvoidChance), CheckValLvl1: 40, CheckValLvl2: 90);
    }

    public void BrutalityStreak_AvoidChance_Text(){
        int Format;
        switch(SkillManager.BrutalityStreak_AvoidChance){
            case 0:
                Format = 7;
                break;
            default:
                Format = 5;
                break;
        }
        GetText(BrutalityStreak_AvoidChance, "BrutalityStreak_AvoidChance", TextName: "Brutality_Streak_Mob_Avoid_Chance", MaxUpgradesCount: 2, Price1: 4, Price2: 5, Format1: Format, HasSuffix: false);
    }

    public void BrutalityStreak_AvoidChance_Upgrade(){
        Upgrade(BrutalityStreak_AvoidChance, "BrutalityStreak_AvoidChance", MaxUpgradesCount: 2, Price1: 4, Price2: 5, HasSuffix: false, SetInteractable1: BrutalityStreak_SpecialAttacksTrigger, CheckVal1: 1);
    }

    public void BrutalityStreak_SpecialAttacksTrigger_CheckUpgrade(){
        CheckUpgradeSingle(BrutalityStreak_SpecialAttacksTrigger, "BrutalityStreak_SpecialAttacksTrigger", Lvl: Convert.ToInt32(SkillManager.BrutalityStreak_SpecialAttacksTrigger), CheckValLvl1: 75);
    }

    public void BrutalityStreak_SpecialAttacksTrigger_Text(){
        GetText(BrutalityStreak_SpecialAttacksTrigger, "BrutalityStreak_SpecialAttacksTrigger", TextName: "BrutalityStreak_SpecialAttacksTrigger", MaxUpgradesCount: 1, Price1: 4, HasSuffix: false);
    }

    public void BrutalityStreak_SpecialAttacksTrigger_Upgrade(){
        Upgrade(BrutalityStreak_SpecialAttacksTrigger, "BrutalityStreak_SpecialAttacksTrigger", MaxUpgradesCount: 1, Price1: 4, HasSuffix: false, IsBool:true);
    }

    public void Shield_NoStaminaUsage_5Perc_Text(){
        GetText(Shield_NoStaminaUsage_5Perc, "Shield_NoStaminaUsage_5Perc", TextName: "Instant_Shield", Price1: 4, Price2: 4, Price3: 4, Price4: 5, Price5: 5, Format1: Math.Min(25, (SkillManager.Shield_NoStaminaUsage_5Perc+1)*5), HasCheck: false, HasSuffix: false);
    }

    public void Shield_NoStaminaUsage_5Perc_Upgrade(){
        Upgrade(Shield_NoStaminaUsage_5Perc, "Shield_NoStaminaUsage_5Perc", Price1: 4, Price2: 4, Price3: 4, Price4: 5, Price5: 5, HasSuffix: false, Invoke1: "Shield", SetInteractable1: Shield_DamageBoost_3Perc, CheckVal1: 1);
    }

    public void Shield_DamageBoost_3Perc_Text(){
        GetText(Shield_DamageBoost_3Perc, "Shield_DamageBoost_3Perc", TextName: "Dangerous_Shield", Price1: 4, Price2: 4, Price3: 4, Price4: 5, Price5: 5, Format1: Math.Min(15, (SkillManager.Shield_DamageBoost_3Perc+1)*3), HasCheck: false, HasSuffix: false);
    }

    public void Shield_DamageBoost_3Perc_Upgrade(){
        Upgrade(Shield_DamageBoost_3Perc, "Shield_DamageBoost_3Perc", Price1: 4, Price2: 4, Price3: 4, Price4: 5, Price5: 5, HasSuffix: false, Invoke1: "Shield");
    }

    public void DMG_2_1_Text(){
        GetText(DMG_2_1, "DMG_2_1", TextName: "Additional_Damage", Price1: 1, Price2: 1, Price3: 2, Price4: 2, Price5: 2, Format1: 2, HasCheck: false);
    }

    public void DMG_2_1_Upgrade(){
        Upgrade(DMG_2_1, "DMG_2_1", Price1: 1, Price2: 1, Price3: 2, Price4: 2, Price5: 2, Invoke1: "Damage", SetInteractable1: DMG_1Perc_1, CheckVal1: 3, SetInteractable2: EV_4_ACC_4_1, CheckVal2: 2);
    }

    public void DMG_1Perc_1_Text(){
        GetText(DMG_1Perc_1, "DMG_1Perc_1", TextName: "Even_More_Damage", Price1: 1, Price2: 1, Price3: 1, Price4: 1, Price5: 2, Format1: 1, HasCheck: false);
    }

    public void DMG_1Perc_1_Upgrade(){
        Upgrade(DMG_1Perc_1, "DMG_1Perc_1", Price1: 1, Price2: 1, Price3: 1, Price4: 1, Price5: 2, Invoke1: "DamageModifier", SetInteractable1: HP_1Perc_1, CheckVal1: 2);
    }

    public void HP_1Perc_1_Text(){
        GetText(HP_1Perc_1, "HP_1Perc_1", TextName: "More_Health", Price1: 1, Price2: 1, Price3: 1, Price4: 1, Price5: 1, Format1: 1, HasCheck: false);
    }

    public void HP_1Perc_1_Upgrade(){
        Upgrade(HP_1Perc_1, "HP_1Perc_1", Price1: 1, Price2: 1, Price3: 1, Price4: 1, Price5: 1, Invoke1: "HealthModifier", SetInteractable1: DMG_2Perc_1, CheckVal1: 3, SetInteractable2: DMG_4_1, CheckVal2: 2);
    }

    public void EV_4_ACC_4_1_Text(){
        GetText(EV_4_ACC_4_1, "EV_4_ACC_4_1", TextName: "Universal_Set", Price1: 2, Price2: 2, Price3: 2, Price4: 2, Price5: 2, Format1: 4, HasCheck: false);
    }

    public void EV_4_ACC_4_1_Upgrade(){
        Upgrade(EV_4_ACC_4_1, "EV_4_ACC_4_1", Price1: 2, Price2: 2, Price3: 2, Price4: 2, Price5: 2, Invoke1: "Evasion", Invoke2: "Accuracy", SetInteractable1: HP_25_1, CheckVal1: 2);
    }

    public void HP_25_1_Text(){
        GetText(HP_25_1, "HP_25_1", TextName: "Additional_Health", Price1: 2, Price2: 2, Price3: 2, Price4: 2, Price5: 3, Format1: 25, HasCheck: false);
    }

    public void HP_25_1_Upgrade(){
        Upgrade(HP_25_1, "HP_25_1", Price1: 2, Price2: 2, Price3: 2, Price4: 2, Price5: 3, Invoke1: "Health");
    }

    public void DMG_2Perc_1_Text(){
        GetText(DMG_2Perc_1, "DMG_2Perc_1", TextName: "Even_More_Damage", Price1: 2, Price2: 2, Price3: 2, Price4: 2, Price5: 3, Format1: 2, HasCheck: false);
    }

    public void DMG_2Perc_1_Upgrade(){
        Upgrade(DMG_2Perc_1, "DMG_2Perc_1", Price1: 2, Price2: 2, Price3: 2, Price4: 2, Price5: 3, Invoke1: "DamageModifier", SetInteractable1: HP_2Perc_1, CheckVal1: 2);
    }

    public void HP_2Perc_1_Text(){
        GetText(HP_2Perc_1, "HP_2Perc_1", TextName: "More_Health", Price1: 1, Price2: 1, Price3: 2, Price4: 2, Price5: 2, Format1: 2, HasCheck: false);
    }

    public void HP_2Perc_1_Upgrade(){
        Upgrade(HP_2Perc_1, "HP_2Perc_1", Price1: 1, Price2: 1, Price3: 2, Price4: 2, Price5: 2, Invoke1: "HealthModifier");
        if(SkillManager.HP_30_2_Accuracy>0)DMGCapOverdamage_Unlock.GetComponent<Button>().interactable = true;
    }

    public void DMG_4_1_Text(){
        GetText(DMG_4_1, "DMG_4_1", TextName: "Additional_Damage", Price1: 2, Price2: 2, Price3: 3, Price4: 3, Price5: 4, Format1: 4, HasCheck: false);
    }

    public void DMG_4_1_Upgrade(){
        Upgrade(DMG_4_1, "DMG_4_1", Price1: 2, Price2: 2, Price3: 3, Price4: 3, Price5: 4, Invoke1: "Damage", SetInteractable1: DMG_4_2, CheckVal1: 4, SetInteractable2: DMG_2Perc_2, CheckVal2: 2);
    }

    public void DMG_4_2_Text(){
        GetText(DMG_4_2, "DMG_4_2", TextName: "Additional_Damage", Price1: 2, Price2: 3, Price3: 3, Price4: 3, Price5: 4, Format1: 4, HasCheck: false);
    }

    public void DMG_4_2_Upgrade(){
        Upgrade(DMG_4_2, "DMG_4_2", Price1: 2, Price2: 3, Price3: 3, Price4: 3, Price5: 4, Invoke1: "Damage", SetInteractable1: DMG_5_1, CheckVal1: 3);
    }

    public void DMG_2Perc_2_Text(){
        GetText(DMG_2Perc_2, "DMG_2Perc_2", TextName: "Even_More_Damage", Price1: 2, Price2: 2, Price3: 2, Price4: 2, Price5: 3, Format1: 2, HasCheck: false);
    }

    public void DMG_2Perc_2_Upgrade(){
        Upgrade(DMG_2Perc_2, "DMG_2Perc_2", Price1: 2, Price2: 2, Price3: 2, Price4: 2, Price5: 3, Invoke1: "DamageModifier", SetInteractable1: EV_6_ACC_6_1, CheckVal1: 2);
    }

    public void DMG_5_1_Text(){
        GetText(DMG_5_1, "DMG_5_1", TextName: "Additional_Damage", Price1: 3, Price2: 3, Price3: 4, Price4: 4, Price5: 4, Format1: 5, HasCheck: false);
    }

    public void DMG_5_1_Upgrade(){
        Upgrade(DMG_5_1, "DMG_5_1", Price1: 3, Price2: 3, Price3: 4, Price4: 4, Price5: 4, Invoke1: "Damage", SetInteractable1: EV_10_ACC_10_1, CheckVal1: 2);
    }

    public void EV_10_ACC_10_1_Text(){
        GetText(EV_10_ACC_10_1, "EV_10_ACC_10_1", TextName: "Universal_Set", Price1: 4, Price2: 5, Price3: 5, Price4: 5, Price5: 5, Format1: 10, HasCheck: false);
    }

    public void EV_10_ACC_10_1_Upgrade(){
        Upgrade(EV_10_ACC_10_1, "EV_10_ACC_10_1", Price1: 4, Price2: 5, Price3: 5, Price4: 5, Price5: 5, Invoke1: "Evasion", Invoke2: "Accuracy", SetInteractable1: HP_30_1, CheckVal1: 3);
    }

    public void HP_30_1_Text(){
        GetText(HP_30_1, "HP_30_1", TextName: "Additional_Health", Price1: 3, Price2: 3, Price3: 3, Price4: 3, Price5: 4, Format1: 30, HasCheck: false);
    }

    public void HP_30_1_Upgrade(){
        Upgrade(HP_30_1, "HP_30_1", Price1: 3, Price2: 3, Price3: 3, Price4: 3, Price5: 4, Invoke1: "Health", SetInteractable1: EV_10_ACC_10_2, CheckVal1: 3);
    }

    public void EV_10_ACC_10_2_Text(){
        GetText(EV_10_ACC_10_2, "EV_10_ACC_10_2", TextName: "Universal_Set", Price1: 4, Price2: 5, Price3: 5, Price4: 5, Price5: 5, Format1: 10, HasCheck: false);
    }

    public void EV_10_ACC_10_2_Upgrade(){
        Upgrade(EV_10_ACC_10_2, "EV_10_ACC_10_2", Price1: 4, Price2: 5, Price3: 5, Price4: 5, Price5: 5, Invoke1: "Evasion", Invoke2: "Accuracy");
    }

    public void EV_6_ACC_6_1_Text(){
        GetText(EV_6_ACC_6_1, "EV_6_ACC_6_1", TextName: "Universal_Set", Price1: 3, Price2: 3, Price3: 3, Price4: 3, Price5: 3, Format1: 6, HasCheck: false);
    }

    public void EV_6_ACC_6_1_Upgrade(){
        Upgrade(EV_6_ACC_6_1, "EV_6_ACC_6_1", Price1: 3, Price2: 3, Price3: 3, Price4: 3, Price5: 3, Invoke1: "Evasion", Invoke2: "Accuracy", SetInteractable1: DMG_5_2, CheckVal1: 2);
    }

    public void DMG_5_2_Text(){
        GetText(DMG_5_2, "DMG_5_2", TextName: "Additional_Damage", Price1: 3, Price2: 3, Price3: 4, Price4: 4, Price5: 4, Format1: 5, HasCheck: false);
    }

    public void DMG_5_2_Upgrade(){
        Upgrade(DMG_5_2, "DMG_5_2", Price1: 3, Price2: 3, Price3: 4, Price4: 4, Price5: 4, Invoke1: "Damage", SetInteractable1: DMG_5Perc_1, CheckVal1: 4);
    }

    public void DMG_5Perc_1_Text(){
        GetText(DMG_5Perc_1, "DMG_5Perc_1", TextName: "Even_More_Damage", Price1: 4, Price2: 4, Price3: 4, Price4: 5, Price5: 5, Format1: 5, HasCheck: false);
    }

    public void DMG_5Perc_1_Upgrade(){
        Upgrade(DMG_5Perc_1, "DMG_5Perc_1", Price1: 4, Price2: 4, Price3: 4, Price4: 5, Price5: 5, Invoke1: "DamageModifier", SetInteractable1: HP_5Perc_1, CheckVal1: 1);
    }

    public void HP_5Perc_1_Text(){
        GetText(HP_5Perc_1, "HP_5Perc_1", TextName: "More_Health", Price1: 3, Price2: 3, Price3: 4, Price4: 4, Price5: 4, Format1: 5, HasCheck: false);
    }

    public void HP_5Perc_1_Upgrade(){
        Upgrade(HP_5Perc_1, "HP_5Perc_1", Price1: 3, Price2: 3, Price3: 4, Price4: 4, Price5: 4, Invoke1: "HealthModifier");
    }

    public void CritChance_2Perc_1_Text(){
        GetText(CritChance_2Perc_1, "CritChance_2Perc_1", TextName: "Max_Critical_Strike_Chance", Price1: 1, Price2: 1, Price3: 1, Price4: 1, Price5: 2, Format1: 2, Format2: player.MaxCritChance, HasCheck: false);
    }

    public void CritChance_2Perc_1_Upgrade(){
        Upgrade(CritChance_2Perc_1, "CritChance_2Perc_1", Price1: 1, Price2: 1, Price3: 1, Price4: 1, Price5: 2, Invoke1: "MaxCritChance", SetInteractable1: ACC_10_1, CheckVal1: 2, SetInteractable2: CritDamage_5Perc_1, CheckVal2: 3);
    }

    public void ACC_10_1_Text(){
        GetText(ACC_10_1, "ACC_10_1", TextName: "More Accuracy", Price1: 2, Price2: 2, Price3: 2, Price4: 3, Price5: 3, HasCheck: false);
    }

    public void ACC_10_1_Upgrade(){
        Upgrade(ACC_10_1, "ACC_10_1", Price1: 2, Price2: 2, Price3: 2, Price4: 3, Price5: 3, Invoke1: "Accuracy");
    }

    public void CritDamage_5Perc_1_Text(){
        GetText(CritDamage_5Perc_1, "CritDamage_5Perc_1", TextName: "Crit_Damage", Price1: 1, Price2: 2, Price3: 2, Price4: 2, Price5: 3, Format1: 5, Format2: (SkillManager.Crit_Damage+1)*100, HasCheck: false);
    }

    public void CritDamage_5Perc_1_Upgrade(){
        Upgrade(CritDamage_5Perc_1, "CritDamage_5Perc_1", Price1: 1, Price2: 2, Price3: 2, Price4: 2, Price5: 3, Invoke1: "CritDamage", SetInteractable1: CritChance_2Perc_2, CheckVal1: 3);
    }

    public void CritChance_2Perc_2_Text(){
        GetText(CritChance_2Perc_2, "CritChance_2Perc_2", TextName: "Max_Critical_Strike_Chance", Price1: 1, Price2: 1, Price3: 1, Price4: 1, Price5: 2, Format1: 2, Format2: player.MaxCritChance, HasCheck: false);
    }

    public void CritChance_2Perc_2_Upgrade(){
        Upgrade(CritChance_2Perc_2, "CritChance_2Perc_2", Price1: 1, Price2: 1, Price3: 1, Price4: 1, Price5: 2, Invoke1: "MaxCritChance", SetInteractable1: CritChance_2Perc_3, CheckVal1: 4, SetInteractable2: CritDamage_5Perc_2, CheckVal2: 2);
    }

    public void CritChance_2Perc_3_Text(){
        GetText(CritChance_2Perc_3, "CritChance_2Perc_3", TextName: "Max_Critical_Strike_Chance", Price1: 1, Price2: 1, Price3: 2, Price4: 2, Price5: 2, Format1: 2, Format2: player.MaxCritChance, HasCheck: false);
    }

    public void CritChance_2Perc_3_Upgrade(){
        Upgrade(CritChance_2Perc_3, "CritChance_2Perc_3", Price1: 1, Price2: 1, Price3: 2, Price4: 2, Price5: 2, Invoke1: "MaxCritChance", SetInteractable1: HP_2Perc_2, CheckVal1: 2);
    }

    public void CritDamage_5Perc_2_Text(){
        GetText(CritDamage_5Perc_2, "CritDamage_5Perc_2", TextName: "Crit_Damage", Price1: 1, Price2: 2, Price3: 2, Price4: 2, Price5: 3, Format1: 5, Format2: (SkillManager.Crit_Damage+1)*100, HasCheck: false);
    }

    public void CritDamage_5Perc_2_Upgrade(){
        Upgrade(CritDamage_5Perc_2, "CritDamage_5Perc_2", Price1: 1, Price2: 2, Price3: 2, Price4: 2, Price5: 3, Invoke1: "CritDamage", SetInteractable1: HP_30_2, CheckVal1: 3);
    }

    public void HP_30_2_Text(){
        GetText(HP_30_2, "HP_30_2", TextName: "Additional_Health", Price1: 3, Price2: 3, Price3: 3, Price4: 3, Price5: 4, Format1: 30, HasCheck: false);
    }

    public void HP_30_2_Upgrade(){
        Upgrade(HP_30_2, "HP_30_2", Price1: 3, Price2: 3, Price3: 3, Price4: 3, Price5: 4, Invoke1: "Health");
        if(SkillManager.HP_2Perc_1_Accuracy>0)DMGCapOverdamage_Unlock.GetComponent<Button>().interactable = true;
    }

    public void HP_2Perc_2_Text(){
        GetText(HP_2Perc_2, "HP_2Perc_2", TextName: "More_Health", Price1: 1, Price2: 1, Price3: 2, Price4: 2, Price5: 2, Format1: 2, HasCheck: false);
    }

    public void HP_2Perc_2_Upgrade(){
        Upgrade(HP_2Perc_2, "HP_2Perc_2", Price1: 1, Price2: 1, Price3: 2, Price4: 2, Price5: 2, Invoke1: "HealthModifier", SetInteractable1: CritChance_4Perc_1, CheckVal1: 4, SetInteractable2: CritDamage_10Perc_1, CheckVal2: 1);
    }

    public void CritChance_4Perc_1_Text(){
        GetText(CritChance_4Perc_1, "CritChance_4Perc_1", TextName: "Max_Critical_Strike_Chance", Price1: 2, Price2: 2, Price3: 3, Price4: 3, Price5: 4, Format1: 4, Format2: player.MaxCritChance, HasCheck: false);
    }

    public void CritChance_4Perc_1_Upgrade(){
        Upgrade(CritChance_4Perc_1, "CritChance_4Perc_1", Price1: 2, Price2: 2, Price3: 3, Price4: 3, Price5: 4, Invoke1: "MaxCritChance", SetInteractable1: HP_25_2, CheckVal1: 2);
    }

    public void HP_25_2_Text(){
        GetText(HP_25_2, "HP_25_2", TextName: "Additional_Health", Price1: 2, Price2: 3, Price3: 3, Price4: 3, Price5: 4, Format1: 25, HasCheck: false);
    }

    public void HP_25_2_Upgrade(){
        Upgrade(HP_25_2, "HP_25_2", Price1: 2, Price2: 3, Price3: 3, Price4: 3, Price5: 4, Invoke1: "Health");
    }

    public void CritDamage_10Perc_1_Text(){
        GetText(CritDamage_10Perc_1, "CritDamage_10Perc_1", TextName: "Crit_Damage", Price1: 2, Price2: 3, Price3: 3, Price4: 3, Price5: 4, Format1: 10, Format2: (SkillManager.Crit_Damage+1)*100, HasCheck: false);
    }

    public void CritDamage_10Perc_1_Upgrade(){
        Upgrade(CritDamage_10Perc_1, "CritDamage_10Perc_1", Price1: 2, Price2: 3, Price3: 3, Price4: 3, Price5: 4, Invoke1: "CritDamage", SetInteractable1: ACC_10_3, CheckVal1: 3);
    }

    public void ACC_10_3_Text(){
        GetText(ACC_10_3, "ACC_10_3", TextName: "More Accuracy", Price1: 2, Price2: 2, Price3: 2, Price4: 3, Price5: 3, HasCheck: false);
    }

    public void ACC_10_3_Upgrade(){
        Upgrade(ACC_10_3, "ACC_10_3", Price1: 2, Price2: 2, Price3: 2, Price4: 3, Price5: 3, Invoke1: "Accuracy", SetInteractable1: CritDamage_10Perc_2, CheckVal1: 4);
    }

    public void CritDamage_10Perc_2_Text(){
        GetText(CritDamage_10Perc_2, "CritDamage_10Perc_2", TextName: "Crit_Damage", Price1: 3, Price2: 3, Price3: 4, Price4: 4, Price5: 4, Format1: 10, Format2: (SkillManager.Crit_Damage+1)*100, HasCheck: false);
    }

    public void CritDamage_10Perc_2_Upgrade(){
        Upgrade(CritDamage_10Perc_2, "CritDamage_10Perc_2", Price1: 3, Price2: 3, Price3: 4, Price4: 4, Price5: 4, Invoke1: "CritDamage", SetInteractable1: HP_40_1, CheckVal1: 1, SetInteractable2: CritDamage_20Perc_1, CheckVal2: 4);
    }

    public void CritDamage_20Perc_1_Text(){
        GetText(CritDamage_20Perc_1, "CritDamage_20Perc_1", TextName: "Crit_Damage", Price1: 4, Price2: 4, Price3: 5, Price4: 5, Price5: 6, Format1: 10, Format2: (SkillManager.Crit_Damage+1)*100, HasCheck: false);
    }

    public void CritDamage_20Perc_1_Upgrade(){
        Upgrade(CritDamage_20Perc_1, "CritDamage_20Perc_1", Price1: 4, Price2: 4, Price3: 5, Price4: 5, Price5: 6, Invoke1: "CritDamage", SetInteractable1: ACC_10_4, CheckVal1: 2);
    }

    public void ACC_10_4_Text(){
        GetText(ACC_10_4, "ACC_10_4", TextName: "More Accuracy", Price1: 2, Price2: 2, Price3: 2, Price4: 3, Price5: 3, HasCheck: false);
    }

    public void ACC_10_4_Upgrade(){
        Upgrade(ACC_10_4, "ACC_10_4", Price1: 2, Price2: 2, Price3: 2, Price4: 3, Price5: 3, Invoke1: "Accuracy");
    }

    public void HP_40_1_Text(){
        GetText(HP_40_1, "HP_40_1", TextName: "Additional_Health", Price1: 4, Price2: 4, Price3: 4, Price4: 4, Price5: 5, Format1: 40, HasCheck: false);
    }

    public void HP_40_1_Upgrade(){
        Upgrade(HP_40_1, "HP_40_1", Price1: 4, Price2: 4, Price3: 4, Price4: 4, Price5: 5, Invoke1: "Health");
    }

    public void DMGCapOverdamage_Unlock_Text(){
        int Format = 10;
        if(SkillManager.DMGCapOverdamage_Unlock>0)Format = 5;
        GetText(DMGCapOverdamage_Unlock, "DMGCapOverdamage_Unlock", TextName: "DMGCapOverdamage_Unlock", MaxUpgradesCount: 2, Price1: 5, Price2: 6, Format1: Format, HasCheck: false, HasSuffix: false);
    }

    public void DMGCapOverdamage_Unlock_Upgrade(){
        Upgrade(DMGCapOverdamage_Unlock, "DMGCapOverdamage_Unlock", MaxUpgradesCount: 2, Price1: 6, HasSuffix: false, SetInteractable1: DMGCapOverdamage_10Perc_1, CheckVal1: 1, SetInteractable2: DMGCapOverdamage_10Perc_2, CheckVal2: 1);
    }

    public void DMGCapOverdamage_10Perc_1_Text(){
        GetText(DMGCapOverdamage_10Perc_1, "DMGCapOverdamage_10Perc_1", TextName: "More_Overdamage", Price1: 3, Price2: 3, Price3: 3, Price4: 4, Price5: 4, Format1: SkillManager.DMGCapOverdamage*100, HasCheck: false, HasSuffix: false);
    }

    public void DMGCapOverdamage_10Perc_1_Upgrade(){
        Upgrade(DMGCapOverdamage_10Perc_1, "DMGCapOverdamage_10Perc_1", Price1: 3, Price2: 3, Price3: 3, Price4: 4, Price5: 4, HasSuffix: false, Invoke1: "DMGCapOverdamage", SetInteractable1: ACC_10_2, CheckVal1: 3);
    }

    public void ACC_10_2_Text(){
        GetText(ACC_10_2, "ACC_10_2", TextName: "More Accuracy", Price1: 2, Price2: 2, Price3: 2, Price4: 3, Price5: 3, HasCheck: false);
    }

    public void ACC_10_2_Upgrade(){
        Upgrade(ACC_10_2, "ACC_10_2", Price1: 2, Price2: 2, Price3: 2, Price4: 3, Price5: 3, Invoke1: "Accuracy");
    }

    public void DMGCapOverdamage_10Perc_2_Text(){
        GetText(DMGCapOverdamage_10Perc_2, "DMGCapOverdamage_10Perc_2", TextName: "More_Overdamage", Price1: 3, Price2: 3, Price3: 3, Price4: 4, Price5: 4, Format1: SkillManager.DMGCapOverdamage*100, HasCheck: false, HasSuffix: false);
    }

    public void DMGCapOverdamage_10Perc_2_Upgrade(){
        Upgrade(DMGCapOverdamage_10Perc_2, "DMGCapOverdamage_10Perc_2", Price1: 3, Price2: 3, Price3: 3, Price4: 4, Price5: 4, HasSuffix: false, Invoke1: "DMGCapOverdamage", SetInteractable1: EV_10_ACC_10_3, CheckVal1: 3);
    }

    public void EV_10_ACC_10_3_Text(){
        GetText(EV_10_ACC_10_3, "EV_10_ACC_10_3", TextName: "Universal_Set", Price1: 4, Price2: 5, Price3: 5, Price4: 5, Price5: 5, Format1: 10, HasCheck: false);
    }

    public void EV_10_ACC_10_3_Upgrade(){
        Upgrade(EV_10_ACC_10_3, "EV_10_ACC_10_3", Price1: 4, Price2: 5, Price3: 5, Price4: 5, Price5: 5, Invoke1: "Evasion", Invoke2: "Accuracy");
    }

}