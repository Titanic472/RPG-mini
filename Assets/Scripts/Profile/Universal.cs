using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Universal : SkillTreeSegment
{
    public GameObject HPRegen, EnemyInfoUnlock, EnemyStatsUnlock, PassiveSkillsInfoUnlock, AddActveSkillSlot, ShieldStacking, SkilledTree_1Perc, StaminaRegen_1_1, EV_1_ACC_1_1, EV_2_ACC_2_1, EV_4_ACC_4_1, EV_5_ACC_5_1, EV_8_ACC_8_1, DMG_Resistance_1_1, DMG_Resistance_1_2, WeaponSkillChance_1Perc_1, WeaponSkillChance_2Perc_1, HP_2Perc_1, HP_3Perc_1;
    int SkillsUpgradeCost;
    public int AllUpgrades;

    void Awake(){
        Class = "Universal";
    }

    public void HPRegen_CheckUpgrade(){
        CheckUpgradeSingle(HPRegen, "HPRegen", Lvl:0, CheckValLvl1: 15*(SkillManager.HPRegen+1), Case: AllUpgrades);
    }
    public void HPRegen_Text(){
        SkillsUpgradeCost = 1;
        if(SkillManager.HPRegen>=1) SkillsUpgradeCost = 2;
        if(SkillManager.HPRegen>=5) SkillsUpgradeCost = 3;
        if(SkillManager.HPRegen>=15) SkillsUpgradeCost = 4;
        if(SkillManager.HPRegen==24) SkillsUpgradeCost = 5;
        GetText(Object: HPRegen, Name: "HPRegen", TextName: "Health_Regeneration", Price1: SkillsUpgradeCost, MaxUpgradesCount: 25, Format1: SkillsUpgradeCost*2, HasCheck: true, HasSuffix: false);
    }

    public void HPRegen_Upgrade(){
        Upgrade(Object: HPRegen, Name: "HPRegen", Price1: SkillsUpgradeCost, Invoke1:"HealthRegen", MaxUpgradesCount: 25, HasSuffix: false);
    }

    public void EnemyInfoUnlock_CheckUpgrade(){
        CheckUpgradeSingle(EnemyInfoUnlock, "EnemyInfoUnlock", Lvl: Convert.ToInt32(SkillManager.EnemyInfoUnlock), CheckValLvl1: 10, Case: AllUpgrades);
    }

    public void EnemyInfoUnlock_Text(){
        GetText(EnemyInfoUnlock, "EnemyInfoUnlock", TextName: "Enemy_Discovery", MaxUpgradesCount: 1, Price1: 1, HasSuffix: false);
    }

    public void EnemyInfoUnlock_Upgrade(){
        Upgrade(EnemyInfoUnlock, "EnemyInfoUnlock", MaxUpgradesCount: 1, Price1: 1, HasSuffix: false, IsBool:true, SetInteractable1: EnemyStatsUnlock, CheckVal1: 1);
    }

    public void EnemyStatsUnlock_CheckUpgrade(){
        CheckUpgradeSingle(EnemyStatsUnlock, "EnemyStatsUnlock", Lvl: Convert.ToInt32(SkillManager.EnemyStatsUnlock), CheckValLvl1: 25, Case: AllUpgrades);
    }

    public void EnemyStatsUnlock_Text(){
        GetText(EnemyStatsUnlock, "EnemyStatsUnlock", TextName: "Enemy_Research", MaxUpgradesCount: 1, Price1: 1, HasSuffix: false);
    }

    public void EnemyStatsUnlock_Upgrade(){
        Upgrade(EnemyStatsUnlock, "EnemyStatsUnlock", MaxUpgradesCount: 1, Price1: 1, HasSuffix: false, IsBool:true, SetInteractable1: PassiveSkillsInfoUnlock, CheckVal1: 1);
    }

    public void PassiveSkillsInfoUnlock_CheckUpgrade(){
        CheckUpgradeSingle(PassiveSkillsInfoUnlock, "PassiveSkillsInfoUnlock", Lvl: Convert.ToInt32(SkillManager.PassiveSkillsInfoUnlock), CheckValLvl1: 40, Case: AllUpgrades);
    }

    public void PassiveSkillsInfoUnlock_Text(){
        GetText(PassiveSkillsInfoUnlock, "PassiveSkillsInfoUnlock", TextName: "Self-inspecton", MaxUpgradesCount: 1, Price1: 1, HasSuffix: false);
    }

    public void PassiveSkillsInfoUnlock_Upgrade(){
        Upgrade(PassiveSkillsInfoUnlock, "PassiveSkillsInfoUnlock", MaxUpgradesCount: 1, Price1: 1, HasSuffix: false, IsBool:true);
    }

    public void AddActveSkillSlot_CheckUpgrade(){
        CheckUpgradeSingle(AddActveSkillSlot, "AddActveSkillSlot", Lvl: Convert.ToInt32(SkillManager.AddActveSkillSlot), CheckValLvl1: 70, CheckValLvl2: 160, Case: AllUpgrades);
    }

    public void AddActveSkillSlot_Text(){
        GetText(AddActveSkillSlot, "AddActveSkillSlot", TextName: "Additional_Slot", MaxUpgradesCount: 3, Price1: 3, Price2: 4, Price3: 5, HasSuffix: false);
    }

    public void AddActveSkillSlot_Upgrade(){
        Upgrade(AddActveSkillSlot, "AddActveSkillSlot", MaxUpgradesCount: 3, Price1: 3, Price2: 4, Price3: 5, HasSuffix: false, Invoke1: "ActiveSkillsSlots", SetInteractable1: SkilledTree_1Perc, CheckVal1: 1, SetInteractable2: ShieldStacking, CheckVal2: 1);
    }

    public void ShieldStacking_CheckUpgrade(){
        CheckUpgradeSingle(ShieldStacking, "ShieldStacking", Lvl: Convert.ToInt32(SkillManager.ShieldStacking), CheckValLvl1: 30, CheckValLvl2: 76, Case: AllUpgrades);
    }

    public void ShieldStacking_Text(){
        GetText(ShieldStacking, "ShieldStacking", TextName: "Multiple_Shielding", MaxUpgradesCount: 2, Price1: 2, Price2: 3, HasSuffix: false);
    }

    public void ShieldStacking_Upgrade(){
        Upgrade(ShieldStacking, "ShieldStacking", MaxUpgradesCount: 2, Price1: 2, Price2: 3, HasSuffix: false, SetInteractable1: StaminaRegen_1_1, CheckVal1: 1);
    }

    public void SkilledTree_1Perc_CheckUpgrade(){
        CheckUpgradeSingle(SkilledTree_1Perc, "SkilledTree_1Perc", Lvl: Convert.ToInt32(SkillManager.SkilledTree_1Perc_Universal), CheckValLvl1: 95, CheckValLvl2: 210, CheckValLvl3: 350, Case: AllUpgrades);
    }

    public void SkilledTree_1Perc_Text(){
        GetText(SkilledTree_1Perc, "SkilledTree_1Perc", TextName: "Skilled_Tree_Chance", MaxUpgradesCount: 3, Price1: 2, Price2: 3, Price3: 3, Format1: Math.Min(4, SkillManager.SkilledTree_1Perc_Universal+1));
    }

    public void SkilledTree_1Perc_Upgrade(){
        Upgrade(SkilledTree_1Perc, "SkilledTree_1Perc", MaxUpgradesCount: 3, Price1: 2, Price2: 3, Price3: 3, Invoke1: "SkilledTree");
    }

    public void StaminaRegen_1_1_CheckUpgrade(){
        CheckUpgradeSingle(StaminaRegen_1_1, "StaminaRegen_1_1", Lvl: Convert.ToInt32(SkillManager.StaminaRegen_1_1_Universal), CheckValLvl1: 35, CheckValLvl2: 45, CheckValLvl3: 60, CheckValLvl4: 85, CheckValLvl5: 115, Case: AllUpgrades);
    }

    public void StaminaRegen_1_1_Text(){
        GetText(StaminaRegen_1_1, "StaminaRegen_1_1", TextName: "Faster_Attacks", Price1: 2, Price2: 2, Price3: 2, Price4: 2, Price5: 2, Format1: 1);
    }

    public void StaminaRegen_1_1_Upgrade(){
        Upgrade(StaminaRegen_1_1, "StaminaRegen_1_1", Price1: 2, Price2: 2, Price3: 2, Price4: 2, Price5: 2, Invoke1: "AttackSpeed");
    }

    public void EV_1_ACC_1_1_CheckUpgrade(){
        CheckUpgradeSingle(EV_1_ACC_1_1, "EV_1_ACC_1_1", Lvl: Convert.ToInt32(SkillManager.EV_1_ACC_1_1_Universal), CheckValLvl1: 5, CheckValLvl2: 10, CheckValLvl3: 15, CheckValLvl4: 20, CheckValLvl5: 25, Case: AllUpgrades);
    }

    public void EV_1_ACC_1_1_Text(){
        GetText(EV_1_ACC_1_1, "EV_1_ACC_1_1", TextName: "Universal_Set", Price1: 0, Format1: 1);
    }

    public void EV_1_ACC_1_1_Upgrade(){
        Upgrade(EV_1_ACC_1_1, "EV_1_ACC_1_1", Price1: 0, Invoke1: "Evasion", Invoke2: "Accuracy", SetInteractable1: EV_2_ACC_2_1, CheckVal1: 5);
    }

    public void EV_2_ACC_2_1_CheckUpgrade(){
        CheckUpgradeSingle(EV_2_ACC_2_1, "EV_2_ACC_2_1", Lvl: Convert.ToInt32(SkillManager.EV_2_ACC_2_1_Universal), CheckValLvl1: 30, CheckValLvl2: 35, CheckValLvl3: 40, CheckValLvl4: 45, CheckValLvl5: 50, Case: AllUpgrades);
    }

    public void EV_2_ACC_2_1_Text(){
        GetText(EV_2_ACC_2_1, "EV_2_ACC_2_1", TextName: "Universal_Set", Price1: 0, Format1: 2);
    }

    public void EV_2_ACC_2_1_Upgrade(){
        Upgrade(EV_2_ACC_2_1, "EV_2_ACC_2_1", Price1: 0, Invoke1: "Evasion", Invoke2: "Accuracy", SetInteractable1: EV_4_ACC_4_1, CheckVal1: 5);
    }

    public void EV_4_ACC_4_1_CheckUpgrade(){
        CheckUpgradeSingle(EV_4_ACC_4_1, "EV_4_ACC_4_1", Lvl: Convert.ToInt32(SkillManager.EV_4_ACC_4_1_Universal), CheckValLvl1: 60, CheckValLvl2: 70, CheckValLvl3: 80, CheckValLvl4: 90, CheckValLvl5: 100, Case: AllUpgrades);
    }

    public void EV_4_ACC_4_1_Text(){
        GetText(EV_4_ACC_4_1, "EV_4_ACC_4_1", TextName: "Universal_Set", Price1: 0, Format1: 4);
    }

    public void EV_4_ACC_4_1_Upgrade(){
        Upgrade(EV_4_ACC_4_1, "EV_4_ACC_4_1", Price1: 0, Invoke1: "Evasion", Invoke2: "Accuracy", SetInteractable1: EV_5_ACC_5_1, CheckVal1: 5);
    }

    public void EV_5_ACC_5_1_CheckUpgrade(){
        CheckUpgradeSingle(EV_5_ACC_5_1, "EV_5_ACC_5_1", Lvl: Convert.ToInt32(SkillManager.EV_5_ACC_5_1_Universal), CheckValLvl1: 110, CheckValLvl2: 120, CheckValLvl3: 130, CheckValLvl4: 140, CheckValLvl5: 150, Case: AllUpgrades);
    }

    public void EV_5_ACC_5_1_Text(){
        GetText(EV_5_ACC_5_1, "EV_5_ACC_5_1", TextName: "Universal_Set", Price1: 0, Format1: 5);
    }

    public void EV_5_ACC_5_1_Upgrade(){
        Upgrade(EV_5_ACC_5_1, "EV_5_ACC_5_1", Price1: 0, Invoke1: "Evasion", Invoke2: "Accuracy", SetInteractable1: EV_8_ACC_8_1, CheckVal1: 5);
    }

    public void EV_8_ACC_8_1_CheckUpgrade(){
        CheckUpgradeSingle(EV_8_ACC_8_1, "EV_8_ACC_8_1", Lvl: Convert.ToInt32(SkillManager.EV_8_ACC_8_1_Universal), CheckValLvl1: 160, CheckValLvl2: 170, CheckValLvl3: 180, CheckValLvl4: 190, CheckValLvl5: 200, Case: AllUpgrades);
    }

    public void EV_8_ACC_8_1_Text(){
        GetText(EV_8_ACC_8_1, "EV_8_ACC_8_1", TextName: "Universal_Set", Price1: 0, Format1: 8);
    }

    public void EV_8_ACC_8_1_Upgrade(){
        Upgrade(EV_8_ACC_8_1, "EV_8_ACC_8_1", Price1: 0, Invoke1: "Evasion", Invoke2: "Accuracy");
    }

    public void DMG_Resistance_1_1_CheckUpgrade(){
        CheckUpgradeSingle(DMG_Resistance_1_1, "DMG_Resistance_1_1", Lvl: Convert.ToInt32(SkillManager.DMG_Resistance_1_1_Universal), CheckValLvl1: 5, CheckValLvl2: 30, CheckValLvl3: 55, CheckValLvl4: 80, CheckValLvl5: 105, Case: AllUpgrades);
    }

    public void DMG_Resistance_1_1_Text(){
        GetText(DMG_Resistance_1_1, "DMG_Resistance_1_1", TextName: "Damage_Resistance", Price1: 2, Price2: 2, Price3: 2, Price4: 2, Price5: 2, Format1: 1);
    }

    public void DMG_Resistance_1_1_Upgrade(){
        Upgrade(DMG_Resistance_1_1, "DMG_Resistance_1_1", Price1: 2, Price2: 2, Price3: 2, Price4: 2, Price5: 2, Invoke1: "DamageResistance", SetInteractable1: DMG_Resistance_1_2, CheckVal1: 5, SetInteractable2: WeaponSkillChance_1Perc_1, CheckVal2: 1, SetInteractable3: HP_2Perc_1, CheckVal3: 1);
    }

    public void DMG_Resistance_1_2_CheckUpgrade(){
        CheckUpgradeSingle(DMG_Resistance_1_2, "DMG_Resistance_1_2", Lvl: Convert.ToInt32(SkillManager.DMG_Resistance_1_2_Universal), CheckValLvl1: 130, CheckValLvl2: 155, CheckValLvl3: 180, CheckValLvl4: 205, CheckValLvl5: 230, Case: AllUpgrades);
    }

    public void DMG_Resistance_1_2_Text(){
        GetText(DMG_Resistance_1_2, "DMG_Resistance_1_2", TextName: "Damage_Resistance", MaxUpgradesCount: 4, Price1: 3, Price2: 3, Price3: 3, Price4: 3, Format1: 1);
    }

    public void DMG_Resistance_1_2_Upgrade(){
        Upgrade(DMG_Resistance_1_2, "DMG_Resistance_1_2", MaxUpgradesCount: 4, Price1: 3, Price2: 3, Price3: 3, Price4: 3, Invoke1: "DamageResistance");
    }

    public void WeaponSkillChance_1Perc_1_CheckUpgrade(){
        CheckUpgradeSingle(WeaponSkillChance_1Perc_1, "WeaponSkillChance_1Perc_1", Lvl: Convert.ToInt32(SkillManager.WeaponSkillChance_1Perc_1_Universal), CheckValLvl1: 20, CheckValLvl2: 40, CheckValLvl3: 60, CheckValLvl4: 80, CheckValLvl5: 100, Case: AllUpgrades);
    }

    public void WeaponSkillChance_1Perc_1_Text(){
        GetText(WeaponSkillChance_1Perc_1, "WeaponSkillChance_1Perc_1", TextName: "Weapon_Ability_Chance", Price1: 1, Price2: 1, Price3: 1, Price4: 1, Price5: 1, Format1: 1);
    }

    public void WeaponSkillChance_1Perc_1_Upgrade(){
        Upgrade(WeaponSkillChance_1Perc_1, "WeaponSkillChance_1Perc_1", Price1: 1, Price2: 1, Price3: 1, Price4: 1, Price5: 1, Invoke1: "WeaponSkillChance", SetInteractable1: WeaponSkillChance_2Perc_1, CheckVal1: 5);
    }

    public void WeaponSkillChance_2Perc_1_CheckUpgrade(){
        CheckUpgradeSingle(WeaponSkillChance_2Perc_1, "WeaponSkillChance_2Perc_1", Lvl: Convert.ToInt32(SkillManager.WeaponSkillChance_2Perc_1_Universal), CheckValLvl1: 120, CheckValLvl2: 140, CheckValLvl3: 160, CheckValLvl4: 180, CheckValLvl5: 200, Case: AllUpgrades);
    }

    public void WeaponSkillChance_2Perc_1_Text(){
        GetText(WeaponSkillChance_2Perc_1, "WeaponSkillChance_2Perc_1", TextName: "Weapon_Ability_Chance", Price1: 2, Price2: 2, Price3: 2, Price4: 2, Price5: 2, Format1: 2);
    }

    public void WeaponSkillChance_2Perc_1_Upgrade(){
        Upgrade(WeaponSkillChance_2Perc_1, "WeaponSkillChance_2Perc_1", Price1: 2, Price2: 2, Price3: 2, Price4: 2, Price5: 2, Invoke1: "WeaponSkillChance");
    }

    public void HP_2Perc_1_CheckUpgrade(){
        CheckUpgradeSingle(HP_2Perc_1, "HP_2Perc_1", Lvl: Convert.ToInt32(SkillManager.HP_2Perc_1_Universal), CheckValLvl1: 10, CheckValLvl2: 25, CheckValLvl3: 40, CheckValLvl4: 55, CheckValLvl5: 70, Case: AllUpgrades);
    }

    public void HP_2Perc_1_Text(){
        GetText(HP_2Perc_1, "HP_2Perc_1", TextName: "More_Health", Price1: 2, Price2: 2, Price3: 2, Price4: 2, Price5: 2, Format1: 2);
    }

    public void HP_2Perc_1_Upgrade(){
        Upgrade(HP_2Perc_1, "HP_2Perc_1", Price1: 2, Price2: 2, Price3: 2, Price4: 2, Price5: 2, Invoke1: "HealthModifier", SetInteractable1: HP_3Perc_1, CheckVal1: 5);
    }

    public void HP_3Perc_1_CheckUpgrade(){
        CheckUpgradeSingle(HP_3Perc_1, "HP_3Perc_1", Lvl: Convert.ToInt32(SkillManager.HP_3Perc_1_Universal), CheckValLvl1: 85, CheckValLvl2: 100, CheckValLvl3: 115, CheckValLvl4: 130, CheckValLvl5: 145, Case: AllUpgrades);
    }

    public void HP_3Perc_1_Text(){
        GetText(HP_3Perc_1, "HP_3Perc_1", TextName: "More_Health", Price1: 3, Price2: 3, Price3: 3, Price4: 3, Price5: 3, Format1: 3);
    }

    public void HP_3Perc_1_Upgrade(){
        Upgrade(HP_3Perc_1, "HP_3Perc_1", Price1: 3, Price2: 3, Price3: 3, Price4: 3, Price5: 3, Invoke1: "HealthModifier");
    }



}