using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Evasion : SkillTreeSegment
{
    public GameObject EvasionMain, PHU, AvoidChance_1Perc_1, Parry_Unlock, Parry_Chance, Parry_Perc, Parry_Damage, Shield_ParryChance_1Perc, Shield_DMGResistance_1Perc_1, Shield_DMGResistance_2Perc_1, Shield_AvoidChance1Perc_1, Shield_AvoidChance2Perc_1, EV_4_1, AvoidChance_1Perc_2, HP_10_1, DMG_Resistance_1Perc_1, AvoidChance_2Perc_1, AvoidChance_2Perc_2, EV_8_1, HP_15_1, AvoidChance_2Perc_3, EV_10_1, DMG_Resistance_1Perc_2, EV_8_2, EV_10_2, HP_10_2, StaminaRegen_1_1, MaxStamina_1_1, EV_6_ACC_6_1, StaminaRegen_1_2, HP_10_3, MaxStamina_1_2, EV_4_ACC_4_1, StaminaRegen_1_3, HP_15_2, EV_10_ACC_10_1, MaxStamina_1_3, DoubleStaminaUnlock, StaminaRegen_2_1, EV_10_ACC_10_2, MaxStamina_1_4, DMG_resistance_1Perc_3, EV_10_ACC_10_3, PH_Damage, PH_Cooldown, PH_WeaponSkillChance, KDU, KD_Amount, KD_Damage, KD_Cooldown, KD_NoStaminaUse, KD_Bleeding, KD_Poison, KD_Explosive, KD_IgnoreAvoid, DFU, DF_EffectDuration, DF_Debuff, DF_Debuff_Percent, DF_Debuff_Stamina, DF_Debuff_Duration, DF_DoubleEffect;
    int SkillsUpgradeCost;
    
    void Awake(){
        branchName = "Evasion";
    }

    public void EvasionMain_Text(){
        SkillsUpgradeCost = 1;
        if(SkillManager.EvasionMain>=1) SkillsUpgradeCost = 2;
        if(SkillManager.EvasionMain>=5) SkillsUpgradeCost = 3;
        if(SkillManager.EvasionMain>=15) SkillsUpgradeCost = 4;
        if(SkillManager.EvasionMain>=24) SkillsUpgradeCost = 5;
        GetText(Object: EvasionMain, Name: "EvasionMain", TextName: "Evasion", Price1: SkillsUpgradeCost, MaxUpgradesCount: -1, Format1: player.BaseEvasion, HasCheck: false, HasSuffix: false);
    }

    public void EvasionMain_Upgrade(){
        Upgrade(Object: EvasionMain, Name: "EvasionMain", Price1: SkillsUpgradeCost, Invoke1:"Evasion", MaxUpgradesCount: -1, HasSuffix: false, SetInteractable1: PHU, CheckVal1: 1, SetInteractable2: StaminaRegen_1_1, CheckVal2: 1, SetInteractable3: AvoidChance_1Perc_1, CheckVal3: 1, SetInteractable4: Parry_Unlock, CheckVal4: 1);
    }

    public void PHU_CheckUpgrade(){
        CheckUpgradeSingle(PHU, "PHU", Lvl: Convert.ToInt32(SkillManager.PHU), CheckValLvl1: 10);
        SkillManager.ActiveSkillsManager.SkillsUnlockCheck();
    }

    public void PHU_Text(){
        GetText(PHU, "PHU", TextName: "Precise_Hit", MaxUpgradesCount: 1, Price1: 4, HasSuffix: false);
    }

    public void PHU_Upgrade(){
        Upgrade(PHU, "PHU", MaxUpgradesCount: 1, Price1: 4, HasSuffix: false, IsBool:true, SetInteractable1: PH_Damage, CheckVal1: 1, SetInteractable2: PH_Cooldown, CheckVal2: 1, SetInteractable3: PH_WeaponSkillChance, CheckVal3: 1, SetInteractable4: KDU, CheckVal4: 1);
        SkillManager.ActiveSkillsManager.SkillsUnlockCheck();
    }
    
    public void AvoidChance_1Perc_1_Text(){
        GetText(AvoidChance_1Perc_1, "AvoidChance_1Perc_1", TextName: "Avoid_Chance", Price1: 1, Price2: 1, Price3: 1, Price4: 1, Price5: 1, Format1: 1, Format2: player.MaxAvoidChance, HasCheck: false);
    }

    public void AvoidChance_1Perc_1_Upgrade(){
        Upgrade(AvoidChance_1Perc_1, "AvoidChance_1Perc_1", Price1: 1, Price2: 1, Price3: 1, Price4: 1, Price5: 1, Invoke1: "MaxAvoidChance", SetInteractable1: AvoidChance_1Perc_2, CheckVal1: 3, SetInteractable2: EV_4_1, CheckVal2: 2);
    }
    
    public void Parry_Unlock_CheckUpgrade(){
        CheckUpgradeSingle(Parry_Unlock, "Parry_Unlock", Lvl: Convert.ToInt32(SkillManager.Parry_Unlock), CheckValLvl1: 20);
    }

    public void Parry_Unlock_Text(){
        GetText(Parry_Unlock, "Parry_Unlock", TextName: "Parry_Unlock", MaxUpgradesCount: 1, Price1: 4, HasSuffix: false);
    }

    public void Parry_Unlock_Upgrade(){
        Upgrade(Parry_Unlock, "Parry_Unlock", MaxUpgradesCount: 1, Price1: 4, HasSuffix: false, IsBool:true, SetInteractable1: Parry_Chance, CheckVal1: 1, SetInteractable2: Shield_DMGResistance_1Perc_1, CheckVal2: 1);
    }
    
    public void Parry_Chance_CheckUpgrade(){
        CheckUpgradeSingle(Parry_Chance, "Parry_Chance", Lvl: Convert.ToInt32(SkillManager.Parry_Chance), CheckValLvl1: 30, CheckValLvl2: 85);
    }

    public void Parry_Chance_Text(){
        int Format;
        switch(SkillManager.Parry_Chance){
            case 0:
                Format = 2;
                break;
            default:
                Format = 3;
                break;
        }
        GetText(Parry_Chance, "Parry_Chance", TextName: "Parry_Chance", MaxUpgradesCount: 2, Price1: 4, Price2: 5, Format1: Format, HasSuffix: false);
    }

    public void Parry_Chance_Upgrade(){
        Upgrade(Parry_Chance, "Parry_Chance", MaxUpgradesCount: 2, Price1: 4, Price2: 5, HasSuffix: false, SetInteractable1: Parry_Perc, CheckVal1: 1);
    }
    
    public void Parry_Perc_CheckUpgrade(){
        CheckUpgradeSingle(Parry_Perc, "Parry_Perc", Lvl: Convert.ToInt32(SkillManager.Parry_Perc), CheckValLvl1: 35, CheckValLvl2: 90);
    }

    public void Parry_Perc_Text(){
        int Format;
        switch(SkillManager.Parry_Perc){
            case 0:
                Format = 90;
                break;
            default:
                Format = 75;
                break;
        }
        GetText(Parry_Perc, "Parry_Perc", TextName: "Better_Parry", MaxUpgradesCount: 2, Price1: 3, Price2: 6, Format1: Format, HasSuffix: false);
    }

    public void Parry_Perc_Upgrade(){
        Upgrade(Parry_Perc, "Parry_Perc", MaxUpgradesCount: 2, Price1: 3, Price2: 6, HasSuffix: false, SetInteractable1: Parry_Damage, CheckVal1: 1);
    }
    
    public void Parry_Damage_CheckUpgrade(){
        CheckUpgradeSingle(Parry_Damage, "Parry_Damage", Lvl: Convert.ToInt32(SkillManager.Parry_Damage), CheckValLvl1: 40, CheckValLvl2: 95);
    }

    public void Parry_Damage_Text(){
        int Format;
        switch(SkillManager.Parry_Damage){
            case 0:
                Format = 5;
                break;
            default:
                Format = 10;
                break;
        }
        GetText(Parry_Damage, "Parry_Damage", TextName: "Painful_Parry", MaxUpgradesCount: 2, Price1: 4, Price2: 5, Format1: Format, HasSuffix: false);
    }

    public void Parry_Damage_Upgrade(){
        Upgrade(Parry_Damage, "Parry_Damage", MaxUpgradesCount: 2, Price1: 4, Price2: 5, HasSuffix: false, SetInteractable1: Shield_ParryChance_1Perc, CheckVal1: 1);
    }
    
    public void Shield_ParryChance_1Perc_Text(){
        GetText(Shield_ParryChance_1Perc, "Shield_ParryChance_1Perc", TextName: "Shield_Parry", Price1: 2, Price2: 3, Price3: 3, Price4: 3, Price5: 3, Format1: Math.Min(5, SkillManager.Shield_ParryChance_1Perc+1), HasCheck: false, HasSuffix: false);
    }

    public void Shield_ParryChance_1Perc_Upgrade(){
        Upgrade(Shield_ParryChance_1Perc, "Shield_ParryChance_1Perc", Price1: 2, Price2: 3, Price3: 3, Price4: 3, Price5: 3, HasSuffix: false);
    }
    
    public void Shield_DMGResistance_1Perc_1_Text(){
        GetText(Shield_DMGResistance_1Perc_1, "Shield_DMGResistance_1Perc_1", TextName: "Tough_Shield", Price1: 1, Price2: 2, Price3: 2, Price4: 3, Price5: 3, Format1: 1, Format2: SkillManager.Shield_DMGResistance_2Perc_1*2+SkillManager.Shield_DMGResistance_1Perc_1, HasCheck: false, HasSuffix: false);
    }

    public void Shield_DMGResistance_1Perc_1_Upgrade(){
        Upgrade(Shield_DMGResistance_1Perc_1, "Shield_DMGResistance_1Perc_1", Price1: 1, Price2: 2, Price3: 2, Price4: 3, Price5: 3, HasSuffix: false, Invoke1: "Shield", SetInteractable1: Shield_DMGResistance_2Perc_1, CheckVal1: 5, SetInteractable2: Shield_AvoidChance1Perc_1, CheckVal2: 1);
    }
    
    public void Shield_DMGResistance_2Perc_1_Text(){
        GetText(Shield_DMGResistance_2Perc_1, "Shield_DMGResistance_2Perc_1", TextName: "Tough_Shield", Price1: 3, Price2: 4, Price3: 4, Price4: 5, Price5: 5, Format1: 2, Format2: SkillManager.Shield_DMGResistance_2Perc_1*2 + SkillManager.Shield_DMGResistance_1Perc_1, HasCheck: false, HasSuffix: false);
    }

    public void Shield_DMGResistance_2Perc_1_Upgrade(){
        Upgrade(Shield_DMGResistance_2Perc_1, "Shield_DMGResistance_2Perc_1", Price1: 3, Price2: 4, Price3: 4, Price4: 5, Price5: 5, HasSuffix: false, Invoke1: "Shield");
    }
    
    public void Shield_AvoidChance1Perc_1_Text(){
        GetText(Shield_AvoidChance1Perc_1, "Shield_AvoidChance1Perc_1", TextName: "Shield_Avoid", Price1: 1, Price2: 2, Price3: 2, Price4: 2, Price5: 3, Format1: 1, Format2: SkillManager.Shield_AvoidChance1Perc_1 + SkillManager.Shield_AvoidChance2Perc_1*2, HasCheck: false, HasSuffix: false);
    }

    public void Shield_AvoidChance1Perc_1_Upgrade(){
        Upgrade(Shield_AvoidChance1Perc_1, "Shield_AvoidChance1Perc_1", Price1: 1, Price2: 2, Price3: 2, Price4: 2, Price5: 3, HasSuffix: false, Invoke1: "Shield", SetInteractable1: Shield_AvoidChance2Perc_1, CheckVal1: 5);
    }
    
    public void Shield_AvoidChance2Perc_1_Text(){
        GetText(Shield_AvoidChance2Perc_1, "Shield_AvoidChance2Perc_1", TextName: "Shield_Avoid", Price1: 3, Price2: 4, Price3: 4, Price4: 4, Price5: 4, Format1: 1, Format2: SkillManager.Shield_AvoidChance1Perc_1 + SkillManager.Shield_AvoidChance2Perc_1*2, HasCheck: false, HasSuffix: false);
    }

    public void Shield_AvoidChance2Perc_1_Upgrade(){
        Upgrade(Shield_AvoidChance2Perc_1, "Shield_AvoidChance2Perc_1", Price1: 3, Price2: 4, Price3: 4, Price4: 4, Price5: 4, HasSuffix: false, Invoke1: "Shield");
    }
    
    public void EV_4_1_Text(){
        GetText(EV_4_1, "EV_4_1", TextName: "More_Evasion", Price1: 1, Price2: 1, Price3: 1, Price4: 1, Price5: 1, Format1: 4, HasCheck: false);
    }

    public void EV_4_1_Upgrade(){
        Upgrade(EV_4_1, "EV_4_1", Price1: 1, Price2: 1, Price3: 1, Price4: 1, Price5: 1, Invoke1: "Evasion");
    }
    
    public void AvoidChance_1Perc_2_Text(){
        GetText(AvoidChance_1Perc_2, "AvoidChance_1Perc_2", TextName: "Avoid_Chance", Price1: 1, Price2: 1, Price3: 1, Price4: 1, Price5: 2, Format1: 1, Format2: player.MaxAvoidChance, HasCheck: false);
    }

    public void AvoidChance_1Perc_2_Upgrade(){
        Upgrade(AvoidChance_1Perc_2, "AvoidChance_1Perc_2", Price1: 1, Price2: 1, Price3: 1, Price4: 1, Price5: 2, Invoke1: "MaxAvoidChance", SetInteractable1: HP_10_1, CheckVal1: 4, SetInteractable2: AvoidChance_2Perc_1, CheckVal2: 3);
    }
    
    public void HP_10_1_Text(){
        GetText(HP_10_1, "HP_10_1", TextName: "Additional_Health", Price1: 1, Price2: 2, Price3: 2, Price4: 2, Price5: 3, Format1: 10, HasCheck: false);
    }

    public void HP_10_1_Upgrade(){
        Upgrade(HP_10_1, "HP_10_1", Price1: 1, Price2: 2, Price3: 2, Price4: 2, Price5: 3, Invoke1: "Health", SetInteractable1: DMG_Resistance_1Perc_1, CheckVal1: 2);
    }
    
    public void DMG_Resistance_1Perc_1_Text(){
        GetText(DMG_Resistance_1Perc_1, "DMG_Resistance_1Perc_1", TextName: "Damage_Resistance", Price1: 2, Price2: 2, Price3: 2, Price4: 3, Price5: 4, Format1: 1, HasCheck: false);
    }

    public void DMG_Resistance_1Perc_1_Upgrade(){
        Upgrade(DMG_Resistance_1Perc_1, "DMG_Resistance_1Perc_1", Price1: 2, Price2: 2, Price3: 2, Price4: 3, Price5: 4, Invoke1: "DamageResistance");
    }
    
    public void AvoidChance_2Perc_1_Text(){
        GetText(AvoidChance_2Perc_1, "AvoidChance_2Perc_1", TextName: "Avoid_Chance", Price1: 2, Price2: 2, Price3: 2, Price4: 2, Price5: 3, Format1: 2, Format2: player.MaxAvoidChance, HasCheck: false);
    }

    public void AvoidChance_2Perc_1_Upgrade(){
        Upgrade(AvoidChance_2Perc_1, "AvoidChance_2Perc_1", Price1: 2, Price2: 2, Price3: 2, Price4: 2, Price5: 3, Invoke1: "MaxAvoidChance", SetInteractable1: EV_8_2, CheckVal1: 3, SetInteractable2: AvoidChance_2Perc_2, CheckVal2: 4);
    }
    
    public void AvoidChance_2Perc_2_Text(){
        GetText(AvoidChance_2Perc_2, "AvoidChance_2Perc_2", TextName: "Avoid_Chance", Price1: 2, Price2: 2, Price3: 2, Price4: 2, Price5: 3, Format1: 2, Format2: player.MaxAvoidChance, HasCheck: false);
    }

    public void AvoidChance_2Perc_2_Upgrade(){
        Upgrade(AvoidChance_2Perc_2, "AvoidChance_2Perc_2", Price1: 2, Price2: 2, Price3: 2, Price4: 2, Price5: 3, Invoke1: "MaxAvoidChance", SetInteractable1: EV_8_1, CheckVal1: 2, SetInteractable2: AvoidChance_2Perc_3, CheckVal2: 4);
    }
    
    public void EV_8_1_Text(){
        GetText(EV_8_1, "EV_8_1", TextName: "More_Evasion", Price1: 2, Price2: 2, Price3: 2, Price4: 2, Price5: 2, Format1: 8, HasCheck: false);
    }

    public void EV_8_1_Upgrade(){
        Upgrade(EV_8_1, "EV_8_1", Price1: 2, Price2: 2, Price3: 2, Price4: 2, Price5: 2, Invoke1: "Evasion", SetInteractable1: HP_15_1, CheckVal1: 3);
    }
    
    public void HP_15_1_Text(){
        GetText(HP_15_1, "HP_15_1", TextName: "Additional_Health", Price1: 2, Price2: 3, Price3: 3, Price4: 3, Price5: 4, Format1: 15, HasCheck: false);
    }

    public void HP_15_1_Upgrade(){
        Upgrade(HP_15_1, "HP_15_1", Price1: 2, Price2: 3, Price3: 3, Price4: 3, Price5: 4, Invoke1: "Health");
        if(SkillManager.EV_10_1_Evasion>0)DMG_Resistance_1Perc_2.GetComponent<Button>().interactable = true;
    }
    
    public void AvoidChance_2Perc_3_Text(){
        GetText(AvoidChance_2Perc_3, "AvoidChance_2Perc_3", TextName: "Avoid_Chance", Price1: 2, Price2: 2, Price3: 2, Price4: 2, Price5: 3, Format1: 2, Format2: player.MaxAvoidChance, HasCheck: false);
    }

    public void AvoidChance_2Perc_3_Upgrade(){
        Upgrade(AvoidChance_2Perc_3, "AvoidChance_2Perc_3", Price1: 2, Price2: 2, Price3: 2, Price4: 2, Price5: 3, Invoke1: "MaxAvoidChance", SetInteractable1: EV_10_1, CheckVal1: 3);
    }
    
    public void EV_10_1_Text(){
        GetText(EV_10_1, "EV_10_1", TextName: "More_Evasion", Price1: 2, Price2: 2, Price3: 3, Price4: 3, Price5: 3, Format1: 10, HasCheck: false);
    }

    public void EV_10_1_Upgrade(){
        Upgrade(EV_10_1, "EV_10_1", Price1: 2, Price2: 2, Price3: 3, Price4: 3, Price5: 3, Invoke1: "Evasion");
        if(SkillManager.HP_15_1_Evasion>0)DMG_Resistance_1Perc_2.GetComponent<Button>().interactable = true;
    }
    
    public void DMG_Resistance_1Perc_2_Text(){
        GetText(DMG_Resistance_1Perc_2, "DMG_Resistance_1Perc_2", TextName: "Damage_Resistance", Price1: 2, Price2: 2, Price3: 2, Price4: 3, Price5: 4, Format1: 1, HasCheck: false);
    }

    public void DMG_Resistance_1Perc_2_Upgrade(){
        Upgrade(DMG_Resistance_1Perc_2, "DMG_Resistance_1Perc_2", Price1: 2, Price2: 2, Price3: 2, Price4: 3, Price5: 4, Invoke1: "DamageResistance");
    }
    
    public void EV_8_2_Text(){
        GetText(EV_8_2, "EV_8_2", TextName: "More_Evasion", Price1: 2, Price2: 2, Price3: 2, Price4: 2, Price5: 2, Format1: 8, HasCheck: false);
    }

    public void EV_8_2_Upgrade(){
        Upgrade(EV_8_2, "EV_8_2", Price1: 2, Price2: 2, Price3: 2, Price4: 2, Price5: 2, Invoke1: "Evasion", SetInteractable1: EV_10_2, CheckVal1: 4);
    }
    
    public void EV_10_2_Text(){
        GetText(EV_10_2, "EV_10_2", TextName: "More_Evasion", Price1: 2, Price2: 2, Price3: 3, Price4: 3, Price5: 3, Format1: 10, HasCheck: false);
    }

    public void EV_10_2_Upgrade(){
        Upgrade(EV_10_2, "EV_10_2", Price1: 2, Price2: 2, Price3: 3, Price4: 3, Price5: 3, Invoke1: "Evasion", SetInteractable1: HP_10_2, CheckVal1: 1);
    }
    
    public void HP_10_2_Text(){
        GetText(HP_10_2, "HP_10_2", TextName: "Additional_Health", Price1: 1, Price2: 2, Price3: 2, Price4: 2, Price5: 3, Format1: 10, HasCheck: false);
    }

    public void HP_10_2_Upgrade(){
        Upgrade(HP_10_2, "HP_10_2", Price1: 1, Price2: 2, Price3: 2, Price4: 2, Price5: 3, Invoke1: "Health");
    }
    
    public void StaminaRegen_1_1_Text(){
        GetText(StaminaRegen_1_1, "StaminaRegen_1_1", TextName: "Faster_Attacks", Price1: 2, Price2: 2, Price3: 3, Price4: 3, Price5: 3, Format1: 1, HasCheck: false);
    }

    public void StaminaRegen_1_1_Upgrade(){
        Upgrade(StaminaRegen_1_1, "StaminaRegen_1_1", Price1: 2, Price2: 2, Price3: 3, Price4: 3, Price5: 3, Invoke1: "AttackSpeed", SetInteractable1: MaxStamina_1_1, CheckVal1: 3, SetInteractable2: StaminaRegen_1_2, CheckVal2: 4);
    }
    
    public void MaxStamina_1_1_Text(){
        GetText(MaxStamina_1_1, "MaxStamina_1_1", TextName: "Endurance", MaxUpgradesCount: 2, Price1: 5, Price2: 6, HasCheck: false);
    }

    public void MaxStamina_1_1_Upgrade(){
        Upgrade(MaxStamina_1_1, "MaxStamina_1_1", MaxUpgradesCount: 2, Price1: 5, Price2: 6, Invoke1: "MaxStamina", SetInteractable1: EV_6_ACC_6_1, CheckVal1: 1);
    }
    
    public void EV_6_ACC_6_1_Text(){
        GetText(EV_6_ACC_6_1, "EV_6_ACC_6_1", TextName: "Universal_Set", Price1: 3, Price2: 3, Price3: 3, Price4: 3, Price5: 3, Format1: 6, HasCheck: false);
    }

    public void EV_6_ACC_6_1_Upgrade(){
        Upgrade(EV_6_ACC_6_1, "EV_6_ACC_6_1", Price1: 3, Price2: 3, Price3: 3, Price4: 3, Price5: 3, Invoke1: "Evasion", Invoke2: "Accuracy");
    }
    
    public void StaminaRegen_1_2_Text(){
        GetText(StaminaRegen_1_2, "StaminaRegen_1_2", TextName: "Faster_Attacks", Price1: 2, Price2: 3, Price3: 3, Price4: 3, Price5: 3, Format1: 1, HasCheck: false);
    }

    public void StaminaRegen_1_2_Upgrade(){
        Upgrade(StaminaRegen_1_2, "StaminaRegen_1_2", Price1: 2, Price2: 3, Price3: 3, Price4: 3, Price5: 3, Invoke1: "AttackSpeed", SetInteractable1: HP_10_3, CheckVal1: 2);
    }
    
    public void HP_10_3_Text(){
        GetText(HP_10_3, "HP_10_3", TextName: "Additional_Health", Price1: 1, Price2: 2, Price3: 2, Price4: 2, Price5: 3, Format1: 10, HasCheck: false);
    }

    public void HP_10_3_Upgrade(){
        Upgrade(HP_10_3, "HP_10_3", Price1: 1, Price2: 2, Price3: 2, Price4: 2, Price5: 3, Invoke1: "Health", SetInteractable1: MaxStamina_1_2, CheckVal1: 3);
    }
    
    public void MaxStamina_1_2_Text(){
        GetText(MaxStamina_1_2, "MaxStamina_1_2", TextName: "Endurance", MaxUpgradesCount: 3, Price1: 5, Price2: 5, Price3: 6, HasCheck: false);
    }

    public void MaxStamina_1_2_Upgrade(){
        Upgrade(MaxStamina_1_2, "MaxStamina_1_2", MaxUpgradesCount: 3, Price1: 5, Price2: 5, Price3: 6, Invoke1: "MaxStamina", SetInteractable1: EV_4_ACC_4_1, CheckVal1: 1, SetInteractable2: StaminaRegen_1_3, CheckVal2: 1);
    }
    
    public void EV_4_ACC_4_1_Text(){
        GetText(EV_4_ACC_4_1, "EV_4_ACC_4_1", TextName: "Universal_Set", Price1: 2, Price2: 2, Price3: 2, Price4: 2, Price5: 2, Format1: 4, HasCheck: false);
    }

    public void EV_4_ACC_4_1_Upgrade(){
        Upgrade(EV_4_ACC_4_1, "EV_4_ACC_4_1", Price1: 2, Price2: 2, Price3: 2, Price4: 2, Price5: 2, Invoke1: "Evasion", Invoke2: "Accuracy");
    }
    
    public void StaminaRegen_1_3_Text(){
        GetText(StaminaRegen_1_3, "StaminaRegen_1_3", TextName: "Faster_Attacks", Price1: 2, Price2: 3, Price3: 3, Price4: 3, Price5: 4, Format1: 1, HasCheck: false);
    }

    public void StaminaRegen_1_3_Upgrade(){
        Upgrade(StaminaRegen_1_3, "StaminaRegen_1_3", Price1: 2, Price2: 3, Price3: 3, Price4: 3, Price5: 4, Invoke1: "AttackSpeed", SetInteractable1: EV_10_ACC_10_1, CheckVal1: 2, SetInteractable2: HP_15_2, CheckVal2: 3);
    }
    
    public void HP_15_2_Text(){
        GetText(HP_15_2, "HP_15_2", TextName: "Additional_Health", Price1: 1, Price2: 2, Price3: 2, Price4: 2, Price5: 3, Format1: 15, HasCheck: false);
    }

    public void HP_15_2_Upgrade(){
        Upgrade(HP_15_2, "HP_15_2", Price1: 1, Price2: 2, Price3: 2, Price4: 2, Price5: 3, Invoke1: "Health");
        if(SkillManager.MaxStamina_1_3_Evasion>0)DoubleStaminaUnlock.GetComponent<Button>().interactable = true;
    }
    
    public void EV_10_ACC_10_1_Text(){
        GetText(EV_10_ACC_10_1, "EV_10_ACC_10_1", TextName: "Universal_Set", Price1: 4, Price2: 5, Price3: 5, Price4: 5, Price5: 5, Format1: 10, HasCheck: false);
    }

    public void EV_10_ACC_10_1_Upgrade(){
        Upgrade(EV_10_ACC_10_1, "EV_10_ACC_10_1", Price1: 4, Price2: 5, Price3: 5, Price4: 5, Price5: 5, Invoke1: "Evasion", Invoke2: "Accuracy", SetInteractable1: MaxStamina_1_3, CheckVal1: 3);
    }
    
    public void MaxStamina_1_3_Text(){
        GetText(MaxStamina_1_3, "MaxStamina_1_3", TextName: "Endurance", MaxUpgradesCount: 2, Price1: 5, Price2: 6, HasCheck: false);
    }

    public void MaxStamina_1_3_Upgrade(){
        Upgrade(MaxStamina_1_3, "MaxStamina_1_3", MaxUpgradesCount: 2, Price1: 5, Price2: 6, Invoke1: "MaxStamina");
        if(SkillManager.HP_15_2_Evasion>0)DoubleStaminaUnlock.GetComponent<Button>().interactable = true;
    }
    
    public void DoubleStaminaUnlock_Text(){
        GetText(DoubleStaminaUnlock, "DoubleStaminaUnlock", TextName: "Better_Start", MaxUpgradesCount: 1, Price1: 8, HasCheck: false, HasSuffix: false);
    }

    public void DoubleStaminaUnlock_Upgrade(){
        Upgrade(DoubleStaminaUnlock, "DoubleStaminaUnlock", MaxUpgradesCount: 1, Price1: 8, HasSuffix: false, IsBool:true, SetInteractable1: StaminaRegen_2_1, CheckVal1: 1, SetInteractable2: MaxStamina_1_4, CheckVal2: 1);
    }
    
    public void StaminaRegen_2_1_Text(){
        GetText(StaminaRegen_2_1, "StaminaRegen_2_1", TextName: "Faster_Attacks", Price1: 4, Price2: 5, Price3: 5, Price4: 6, Price5: 6, Format1: 2, HasCheck: false);
    }

    public void StaminaRegen_2_1_Upgrade(){
        Upgrade(StaminaRegen_2_1, "StaminaRegen_2_1", Price1: 4, Price2: 5, Price3: 5, Price4: 6, Price5: 6, Invoke1: "AttackSpeed", SetInteractable1: EV_10_ACC_10_2, CheckVal1: 3);
    }
    
    public void EV_10_ACC_10_2_Text(){
        GetText(EV_10_ACC_10_2, "EV_10_ACC_10_2", TextName: "Universal_Set", Price1: 4, Price2: 5, Price3: 5, Price4: 5, Price5: 5, Format1: 10, HasCheck: false);
    }

    public void EV_10_ACC_10_2_Upgrade(){
        Upgrade(EV_10_ACC_10_2, "EV_10_ACC_10_2", Price1: 4, Price2: 5, Price3: 5, Price4: 5, Price5: 5, Invoke1: "Evasion", Invoke2: "Accuracy");
    }
    
    public void MaxStamina_1_4_Text(){
        GetText(MaxStamina_1_4, "MaxStamina_1_4", TextName: "Endurance", MaxUpgradesCount: 3, Price1: 5, Price2: 5, Price3: 6, HasCheck: false);
    }

    public void MaxStamina_1_4_Upgrade(){
        Upgrade(MaxStamina_1_4, "MaxStamina_1_4", MaxUpgradesCount: 3, Price1: 5, Price2: 5, Price3: 6, Invoke1: "MaxStamina", SetInteractable1: DMG_resistance_1Perc_3, CheckVal1: 2, SetInteractable2: EV_10_ACC_10_3, CheckVal2: 1);
    }
    
    public void DMG_resistance_1Perc_3_Text(){
        GetText(DMG_resistance_1Perc_3, "DMG_resistance_1Perc_3", TextName: "Damage_Resistance", Price1: 2, Price2: 2, Price3: 2, Price4: 3, Price5: 4, Format1: 1, HasCheck: false);
    }

    public void DMG_resistance_1Perc_3_Upgrade(){
        Upgrade(DMG_resistance_1Perc_3, "DMG_resistance_1Perc_3", Price1: 2, Price2: 2, Price3: 2, Price4: 3, Price5: 4, Invoke1: "DamageResistance");
    }
    
    public void EV_10_ACC_10_3_Text(){
        GetText(EV_10_ACC_10_3, "EV_10_ACC_10_3", TextName: "Universal_Set", Price1: 4, Price2: 5, Price3: 5, Price4: 5, Price5: 5, Format1: 10, HasCheck: false);
    }

    public void EV_10_ACC_10_3_Upgrade(){
        Upgrade(EV_10_ACC_10_3, "EV_10_ACC_10_3", Price1: 4, Price2: 5, Price3: 5, Price4: 5, Price5: 5, Invoke1: "Evasion", Invoke2: "Accuracy");
    }
    
    public void PH_Damage_CheckUpgrade(){
        CheckUpgradeSingle(PH_Damage, "PH_Damage", Lvl: Convert.ToInt32(SkillManager.PH_Damage), CheckValLvl1: 20, CheckValLvl2: 45, CheckValLvl3: 62);
    }

    public void PH_Damage_Text(){
        int Format;
        switch(SkillManager.PH_Damage){
            case 0:
                Format = 25;
                break;
            case 1:
                Format = 40;
                break;
            default:
                Format = 60;
                break;
        }
        GetText(PH_Damage, "PH_Damage", TextName: "Precise_Damage", MaxUpgradesCount: 3, Price1: 3, Price2: 4, Price3: 4, Format1: Format, HasSuffix: false);
    }

    public void PH_Damage_Upgrade(){
        Upgrade(PH_Damage, "PH_Damage", MaxUpgradesCount: 3, Price1: 3, Price2: 4, Price3: 4, HasSuffix: false, SetInteractable1: PH_Damage, CheckVal1: 1, SetInteractable2: PH_Cooldown, CheckVal2: 1, SetInteractable3: PH_WeaponSkillChance, CheckVal3: 1, SetInteractable4: KDU, CheckVal4: 1);
    }
    
    public void PH_Cooldown_CheckUpgrade(){
        CheckUpgradeSingle(PH_Cooldown, "PH_Cooldown", Lvl: Convert.ToInt32(SkillManager.PH_Cooldown), CheckValLvl1: 30, CheckValLvl2: 55, CheckValLvl3: 80);
    }

    public void PH_Cooldown_Text(){
        int Format;
        switch(SkillManager.PH_Cooldown){
            case 0:
                Format = 7;
                break;
            case 1:
                Format = 6;
                break;
            default:
                Format = 5;
                break;
        }
        GetText(PH_Cooldown, "PH_Cooldown", TextName: "Precise_Cooldown", MaxUpgradesCount: 3, Price1: 3, Price2: 4, Price3: 5, Format1: Format, HasSuffix: false);
    }

    public void PH_Cooldown_Upgrade(){
        Upgrade(PH_Cooldown, "PH_Cooldown", MaxUpgradesCount: 3, Price1: 3, Price2: 4, Price3: 5, HasSuffix: false);
    }
    
    public void PH_WeaponSkillChance_CheckUpgrade(){
        CheckUpgradeSingle(PH_WeaponSkillChance, "PH_WeaponSkillChance", Lvl: Convert.ToInt32(SkillManager.PH_WeaponSkillChance), CheckValLvl1: 40, CheckValLvl2: 85);
    }

    public void PH_WeaponSkillChance_Text(){
        GetText(PH_WeaponSkillChance, "PH_WeaponSkillChance", TextName: "Precise_Enchants", MaxUpgradesCount: 2, Price1: 2, Price2: 5, Format1: Math.Min(100, SkillManager.PH_WeaponSkillChance*50+50), HasSuffix: false);
    }

    public void PH_WeaponSkillChance_Upgrade(){
        Upgrade(PH_WeaponSkillChance, "PH_WeaponSkillChance", MaxUpgradesCount: 2, Price1: 2, Price2: 5, HasSuffix: false);
    }
    
    public void KDU_CheckUpgrade(){
        CheckUpgradeSingle(KDU, "KDU", Lvl: Convert.ToInt32(SkillManager.KDU), CheckValLvl1: 65);
    }

    public void KDU_Text(){
        GetText(KDU, "KDU", TextName: "Dance_With_Knives_Unlock", MaxUpgradesCount: 1, Price1: 6, HasSuffix: false);
    }

    public void KDU_Upgrade(){
        Upgrade(KDU, "KDU", MaxUpgradesCount: 1, Price1: 6, HasSuffix: false, IsBool:true, SetInteractable1: KD_Amount, CheckVal1: 1, SetInteractable2: KD_Damage, CheckVal2: 1, SetInteractable3: KD_Cooldown, CheckVal3: 1, SetInteractable4: KD_NoStaminaUse, CheckVal4: 1);
        KD_Bleeding.GetComponent<Button>().interactable = true;
        KD_Poison.GetComponent<Button>().interactable = true;
        KD_Explosive.GetComponent<Button>().interactable = true;
        KD_IgnoreAvoid.GetComponent<Button>().interactable = true;
        DFU.GetComponent<Button>().interactable = true;
        SkillManager.ActiveSkillsManager.SkillsUnlockCheck();
    }
    
    public void KD_Amount_CheckUpgrade(){
        CheckUpgradeSingle(KD_Amount, "KD_Amount", Lvl: Convert.ToInt32(SkillManager.KD_Amount), CheckValLvl1: 85, CheckValLvl2: 105, CheckValLvl3: 128);
    }

    public void KD_Amount_Text(){
        int Format;
        switch(SkillManager.KD_Amount){
            case 0:
                Format = 5;
                break;
            case 1:
                Format = 7;
                break;
            default:
                Format = 10;
                break;
        }
        GetText(KD_Amount, "KD_Amount", TextName: "More_Knives", MaxUpgradesCount: 3, Price1: 4, Price2: 4, Price3: 6, Format1: Format, HasSuffix: false);
    }

    public void KD_Amount_Upgrade(){
        Upgrade(KD_Amount, "KD_Amount", MaxUpgradesCount: 3, Price1: 4, Price2: 4, Price3: 6, HasSuffix: false);
    }
    
    public void KD_Damage_CheckUpgrade(){
        CheckUpgradeSingle(KD_Damage, "KD_Damage", Lvl: Convert.ToInt32(SkillManager.KD_Damage), CheckValLvl1: 75, CheckValLvl2: 124);
    }

    public void KD_Damage_Text(){
        int Format;
        switch(SkillManager.KD_Damage){
            case 0:
                Format = 100;
                break;
            default:
                Format = 150;
                break;
        }
        GetText(KD_Damage, "KD_Damage", TextName: "Knife_Damage", MaxUpgradesCount: 2, Price1: 3, Price2: 5, Format1: Format, HasSuffix: false);
    }

    public void KD_Damage_Upgrade(){
        Upgrade(KD_Damage, "KD_Damage", MaxUpgradesCount: 2, Price1: 3, Price2: 5, HasSuffix: false);
    }
    
    public void KD_Cooldown_CheckUpgrade(){
        CheckUpgradeSingle(KD_Cooldown, "KD_Cooldown", Lvl: Convert.ToInt32(SkillManager.KD_Cooldown), CheckValLvl1: 90, CheckValLvl2: 150);
    }

    public void KD_Cooldown_Text(){
        int Format;
        switch(SkillManager.KD_Cooldown){
            case 0:
                Format = 7;
                break;
            default:
                Format = 6;
                break;
        }
        GetText(KD_Cooldown, "KD_Cooldown", TextName: "Knives_Cooldown", MaxUpgradesCount: 2, Price1: 4, Price2: 5, Format1: Format, HasSuffix: false);
    }

    public void KD_Cooldown_Upgrade(){
        Upgrade(KD_Cooldown, "KD_Cooldown", MaxUpgradesCount: 2, Price1: 4, Price2: 5, HasSuffix: false);
    }
    
    public void KD_NoStaminaUse_CheckUpgrade(){
        CheckUpgradeSingle(KD_NoStaminaUse, "KD_NoStaminaUse", Lvl: Convert.ToInt32(SkillManager.KD_NoStaminaUse), CheckValLvl1: 78, CheckValLvl2: 102, CheckValLvl3: 134);
    }

    public void KD_NoStaminaUse_Text(){
        int Format;
        switch(SkillManager.KD_NoStaminaUse){
            case 0:
                Format = 10;
                break;
            case 1:
                Format = 20;
                break;
            default:
                Format = 33;
                break;
        }
        GetText(KD_NoStaminaUse, "KD_NoStaminaUse", TextName: "Knife-Combo", MaxUpgradesCount: 3, Price1: 4, Price2: 5, Price3: 7, Format1: Format, HasSuffix: false);
    }

    public void KD_NoStaminaUse_Upgrade(){
        Upgrade(KD_NoStaminaUse, "KD_NoStaminaUse", MaxUpgradesCount: 3, Price1: 4, Price2: 5, Price3: 7, HasSuffix: false);
    }
    
    public void KD_Bleeding_CheckUpgrade(){
        CheckUpgradeSingle(KD_Bleeding, "KD_Bleeding", Lvl: Convert.ToInt32(SkillManager.KD_Bleeding), CheckValLvl1: 100);
    }

    public void KD_Bleeding_Text(){
        GetText(KD_Bleeding, "KD_Bleeding", TextName: "Sharpened_Knives", MaxUpgradesCount: 1, Price1: 6, HasSuffix: false);
    }

    public void KD_Bleeding_Upgrade(){
        Upgrade(KD_Bleeding, "KD_Bleeding", MaxUpgradesCount: 1, Price1: 6, HasSuffix: false, IsBool:true);
    }
    
    public void KD_Poison_CheckUpgrade(){
        CheckUpgradeSingle(KD_Poison, "KD_Poison", Lvl: Convert.ToInt32(SkillManager.KD_Poison), CheckValLvl1: 110);
    }

    public void KD_Poison_Text(){
        GetText(KD_Poison, "KD_Poison", TextName: "Poisoned_Knives", MaxUpgradesCount: 1, Price1: 5, HasSuffix: false);
    }

    public void KD_Poison_Upgrade(){
        Upgrade(KD_Poison, "KD_Poison", MaxUpgradesCount: 1, Price1: 5, HasSuffix: false, IsBool:true);
    }
    
    public void KD_Explosive_CheckUpgrade(){
        CheckUpgradeSingle(KD_Explosive, "KD_Explosive", Lvl: Convert.ToInt32(SkillManager.KD_Explosive), CheckValLvl1: 105, CheckValLvl2: 150);
    }

    public void KD_Explosive_Text(){
        string Format = "Explosive_Knives";
        if(SkillManager.KD_Explosive>0)Format = "Stronger_Explosives";
        GetText(KD_Explosive, "KD_Explosive", TextName: Format, MaxUpgradesCount: 2, Price1: 4, Price2: 6, HasSuffix: false);
    }

    public void KD_Explosive_Upgrade(){
        Upgrade(KD_Explosive, "KD_Explosive", MaxUpgradesCount: 2, Price1: 4, Price2: 6, HasSuffix: false);
    }
    
    public void KD_IgnoreAvoid_CheckUpgrade(){
        CheckUpgradeSingle(KD_IgnoreAvoid, "KD_IgnoreAvoid", Lvl: Convert.ToInt32(SkillManager.KD_IgnoreAvoid), CheckValLvl1: 102);
    }

    public void KD_IgnoreAvoid_Text(){
        GetText(KD_IgnoreAvoid, "KD_IgnoreAvoid", TextName: "No_Mercy", MaxUpgradesCount: 1, Price1: 5, HasSuffix: false);
    }

    public void KD_IgnoreAvoid_Upgrade(){
        Upgrade(KD_IgnoreAvoid, "KD_IgnoreAvoid", MaxUpgradesCount: 1, Price1: 5, HasSuffix: false, IsBool:true);
    }
    
    public void DFU_CheckUpgrade(){
        CheckUpgradeSingle(DFU, "DFU", Lvl: Convert.ToInt32(SkillManager.DFU), CheckValLvl1: 120);
    }

    public void DFU_Text(){
        GetText(DFU, "DFU", TextName: "Deep_Focus_Unlock", MaxUpgradesCount: 1, Price1: 6, HasSuffix: false);
    }

    public void DFU_Upgrade(){
        Upgrade(DFU, "DFU", MaxUpgradesCount: 1, Price1: 6, HasSuffix: false, IsBool:true, SetInteractable1: DF_DoubleEffect, CheckVal1: 1, SetInteractable2: DF_EffectDuration, CheckVal2: 1, SetInteractable3: DF_Debuff, CheckVal3: 1);
        SkillManager.ActiveSkillsManager.SkillsUnlockCheck();
    }
    
    public void DF_EffectDuration_CheckUpgrade(){
        CheckUpgradeSingle(DF_EffectDuration, "DF_EffectDuration", Lvl: Convert.ToInt32(SkillManager.DF_EffectDuration), CheckValLvl1: 130, CheckValLvl2: 155, CheckValLvl3: 184);
    }

    public void DF_EffectDuration_Text(){
        int Format, AnotherFormat;
        switch(SkillManager.DF_EffectDuration){
            case 0:
                Format = 4;
                AnotherFormat = 6;
                break;
            case 1:
                Format = 5;
                AnotherFormat = 7;
                break;
            default:
                Format = 6;
                AnotherFormat = 8;
                break;
        }
        GetText(DF_EffectDuration, "DF_EffectDuration", TextName: "Longer_Focus", MaxUpgradesCount: 3, Price1: 5, Price2: 5, Price3: 6, Format1: Format, Format2: AnotherFormat, HasSuffix: false);
    }

    public void DF_EffectDuration_Upgrade(){
        Upgrade(DF_EffectDuration, "DF_EffectDuration", MaxUpgradesCount: 3, Price1: 5, Price2: 5, Price3: 6, HasSuffix: false);
    }
    
    public void DF_Debuff_CheckUpgrade(){
        CheckUpgradeSingle(DF_Debuff, "DF_Debuff", Lvl: Convert.ToInt32(SkillManager.DF_Debuff), CheckValLvl1: 140);
    }

    public void DF_Debuff_Text(){
        GetText(DF_Debuff, "DF_Debuff", TextName: "Focused_Debuff", MaxUpgradesCount: 1, Price1: 6, HasSuffix: false);
    }

    public void DF_Debuff_Upgrade(){
        Upgrade(DF_Debuff, "DF_Debuff", MaxUpgradesCount: 1, Price1: 6, HasSuffix: false, IsBool:true, SetInteractable1: DF_Debuff_Percent, CheckVal1: 1, SetInteractable2: DF_Debuff_Stamina, CheckVal2: 1, SetInteractable3: DF_Debuff_Duration, CheckVal3: 1);
    }
    
    public void DF_Debuff_Percent_CheckUpgrade(){
        CheckUpgradeSingle(DF_Debuff_Percent, "DF_Debuff_Percent", Lvl: Convert.ToInt32(SkillManager.DF_Debuff_Percent), CheckValLvl1: 155, CheckValLvl2: 180);
    }

    public void DF_Debuff_Percent_Text(){
        int Format;
        switch(SkillManager.DF_Debuff_Percent){
            case 0:
                Format = 8;
                break;
            default:
                Format = 5;
                break;
        }
        GetText(DF_Debuff_Percent, "DF_Debuff_Percent", TextName: "Stronger_Debuff", MaxUpgradesCount: 2, Price1: 4, Price2: 6, Format1: Format, HasSuffix: false);
    }

    public void DF_Debuff_Percent_Upgrade(){
        Upgrade(DF_Debuff_Percent, "DF_Debuff_Percent", MaxUpgradesCount: 2, Price1: 4, Price2: 6, HasSuffix: false);
    }
    
    public void DF_Debuff_Stamina_CheckUpgrade(){
        CheckUpgradeSingle(DF_Debuff_Stamina, "DF_Debuff_Stamina", Lvl: Convert.ToInt32(SkillManager.DF_Debuff_Stamina), CheckValLvl1: 144, CheckValLvl2: 166, CheckValLvl3: 188);
    }

    public void DF_Debuff_Stamina_Text(){
        int Format;
        switch(SkillManager.DF_Debuff_Stamina){
            case 0:
                Format = 15;
                break;
            case 1:
                Format = 20;
                break;
            default:
                Format = 25;
                break;
        }
        GetText(DF_Debuff_Stamina, "DF_Debuff_Stamina", TextName: "Better_Debuff", MaxUpgradesCount: 3, Price1: 4, Price2: 5, Price3: 7, Format1: Format, HasSuffix: false);
    }

    public void DF_Debuff_Stamina_Upgrade(){
        Upgrade(DF_Debuff_Stamina, "DF_Debuff_Stamina", MaxUpgradesCount: 3, Price1: 4, Price2: 5, Price3: 7, HasSuffix: false);
    }
    
    public void DF_Debuff_Duration_CheckUpgrade(){
        CheckUpgradeSingle(DF_Debuff_Duration, "DF_Debuff_Duration", Lvl: Convert.ToInt32(SkillManager.DF_Debuff_Duration), CheckValLvl1: 160, CheckValLvl2: 196);
    }

    public void DF_Debuff_Duration_Text(){
        int Format;
        switch(SkillManager.DF_Debuff_Duration){
            case 0:
                Format = 5;
                break;
            default:
                Format = 8;
                break;
        }
        GetText(DF_Debuff_Duration, "DF_Debuff_Duration", TextName: "Deeper_Debuff", MaxUpgradesCount: 2, Price1: 6, Price2: 7, Format1: Format, HasSuffix: false);
    }

    public void DF_Debuff_Duration_Upgrade(){
        Upgrade(DF_Debuff_Duration, "DF_Debuff_Duration", MaxUpgradesCount: 2, Price1: 6, Price2: 7, HasSuffix: false);
    }
    
    public void DF_DoubleEffect_CheckUpgrade(){
        CheckUpgradeSingle(DF_DoubleEffect, "DF_DoubleEffect", Lvl: Convert.ToInt32(SkillManager.DF_DoubleEffect), CheckValLvl1: 135);
    }

    public void DF_DoubleEffect_Text(){
        GetText(DF_DoubleEffect, "DF_DoubleEffect", TextName: "Focused_Avoid", MaxUpgradesCount: 1, Price1: 6, HasSuffix: false);
    }

    public void DF_DoubleEffect_Upgrade(){
        Upgrade(DF_DoubleEffect, "DF_DoubleEffect", MaxUpgradesCount: 1, Price1: 6, HasSuffix: false, IsBool:true);
    }
}