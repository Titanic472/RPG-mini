using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Sorcery : SkillTreeSegment
{
    public GameObject PracticePlus, BSU, MR_1_1, Mana_10_1, ManaOverdrain, ManaOverdrain_Perc, ManaOverdrain_Potion, Shield_MagicDef_2Perc_1, Shield_MagicDef_2Perc_2, Shield_DmgReturn_1Perc_1, Shield_DmgReturn_1Perc_2, Mana_10_2, Mana_1Perc_1, Mana_2Perc_1, HP_5_1, MR_1_2, ManaUsage_1Perc_1, MR_2_1, DMG_Resistance_1_1, Mana_10_3, ManaUsage_1Perc_2, Mana_2Perc_2, Mana_20_1, ManaUsage_1Perc_3, Mana_3Perc_1, Mana_2Perc_3, ManaUsage_3Perc_1, HP_10_1, ManaUsage_1Perc_4, MR_2_2, HP_10_2, MR_3_1, MR_3_2, HP_10_3, ManaUsage_3Perc_2, MR_3_3, HP_15_1, DMG_Resistance_1_2, BS_Mana, BS_Damage, BS_Cooldown, BS_Poison_AddDuration, BS_Weakness, CHU, CH_Cooldown, CH_Mana, CH_Damage, CH_Effect, CH_Effect_EVChance, CH_Effect_Damage, CH_Effect_Duration, VU, V_Mana, V_EffectHeal, V_Damage, V_Heal, BS_NoEvasion;
    int SkillsUpgradeCost;
    void Awake(){
        Class = "Sorcery";
    }

    public void PracticePlus_Text(){
        SkillsUpgradeCost = 1;
        if(SkillManager.PracticePlus>=1) SkillsUpgradeCost = 2;
        if(SkillManager.PracticePlus>=5) SkillsUpgradeCost = 3;
        if(SkillManager.PracticePlus>=15) SkillsUpgradeCost = 4;
        if(SkillManager.PracticePlus==24) SkillsUpgradeCost = 5;
        GetText(Object: PracticePlus, Name: "PracticePlus", TextName: "Practice_Plus", Price1: SkillsUpgradeCost, HasCheck: false, MaxUpgradesCount: 25, HasSuffix: false);
    }

    public void PracticePlus_Upgrade(){
        Upgrade(Object: PracticePlus, Name: "PracticePlus", Price1: SkillsUpgradeCost, Invoke1:"Mana", MaxUpgradesCount: 25, HasSuffix: false);
        if(SkillManager.PracticePlus==1){
            BSU.GetComponent<Button>().interactable = true;
            MR_1_1.GetComponent<Button>().interactable = true;
            Mana_10_1.GetComponent<Button>().interactable = true;
            ManaOverdrain.GetComponent<Button>().interactable = true;
            /*SkillManager.Checklist_Add("BSU", "Sorcery");
            SkillManager.Checklist_Add("MR_1_1", "Sorcery");
            SkillManager.Checklist_Add("Mana_10_1", "Sorcery");
            SkillManager.Checklist_Add("ManaOverdrain_Unlock", "Sorcery");*/
        }

        SkillManager.CheckAll();
    }

    public void BSU_CheckUpgrade(){
        CheckUpgradeSingle(BSU, "BSU", Lvl: Convert.ToInt32(SkillManager.BSU), CheckValLvl1: 10);
    }

    public void BSU_Text(){
        GetText(BSU, "BSU", TextName: "Beginner_Spell", MaxUpgradesCount: 1, Price1: 80, HasSuffix: false);
    }

    public void BSU_Upgrade(){
        Upgrade(BSU, "BSU", MaxUpgradesCount: 1, Price1: 80, HasSuffix: false);
    }

    public void MR_1_1_Text(){
        GetText(MR_1_1, "MR_1_1", TextName: "Mana_Regeneration", Price1: 4, Price2: 1, Price3: 2, Price4: 2, Price5: 3, Format1: 1, HasCheck: false);
    }

    public void MR_1_1_Upgrade(){
        Upgrade(MR_1_1, "MR_1_1", Price1: 4, Price2: 1, Price3: 2, Price4: 2, Price5: 3, IsBool:false, Invoke1: "ManaRegen");
    }

    public void Mana_10_1_Text(){
        GetText(Mana_10_1, "Mana_10_1", TextName: "More_Mana", Price1: 1, Price2: 2, Price3: 2, Price4: 2, Price5: 3, HasCheck: false);
    }

    public void Mana_10_1_Upgrade(){
        Upgrade(Mana_10_1, "Mana_10_1", Price1: 1, Price2: 2, Price3: 2, Price4: 2, Price5: 3, IsBool:false, Invoke1: "Mana");
    }

    public void ManaOverdrain_CheckUpgrade(){
        CheckUpgradeSingle(ManaOverdrain, "ManaOverdrain", Lvl: Convert.ToInt32(SkillManager.ManaOverdrain), CheckValLvl1: 20);
    }

    public void ManaOverdrain_Text(){
        GetText(ManaOverdrain, "ManaOverdrain", TextName: "Mana_Overdrain", MaxUpgradesCount: 1, Price1: 1, HasSuffix: false);
    }

    public void ManaOverdrain_Upgrade(){
        Upgrade(ManaOverdrain, "ManaOverdrain", MaxUpgradesCount: 1, Price1: 1, HasSuffix: false);
    }

    public void ManaOverdrain_Perc_CheckUpgrade(){
        CheckUpgradeSingle(ManaOverdrain_Perc, "ManaOverdrain_Perc", Lvl: Convert.ToInt32(SkillManager.ManaOverdrain_Perc), CheckValLvl1: 30, CheckValLvl2: 50, CheckValLvl3: 90);
    }

    public void ManaOverdrain_Perc_Text(){
        GetText(ManaOverdrain_Perc, "ManaOverdrain_Perc", TextName: "Mana_Overdrain_Percercent", MaxUpgradesCount: 3, Price1: 4, Price2: 4, Price3: 5, HasSuffix: false);
    }

    public void ManaOverdrain_Perc_Upgrade(){
        Upgrade(ManaOverdrain_Perc, "ManaOverdrain_Perc", MaxUpgradesCount: 3, Price1: 4, Price2: 4, Price3: 5, HasSuffix: false, IsBool:false);
    }

    public void ManaOverdrain_Potion_CheckUpgrade(){
        CheckUpgradeSingle(ManaOverdrain_Potion, "ManaOverdrain_Potion", Lvl: Convert.ToInt32(SkillManager.ManaOverdrain_Potion), CheckValLvl1: 40, CheckValLvl2: 70, CheckValLvl3: 100);
    }

    public void ManaOverdrain_Potion_Text(){
        GetText(ManaOverdrain_Potion, "ManaOverdrain_Potion", TextName: "Mana_Overdrain_Potion", MaxUpgradesCount: 3, Price1: 2, Price2: 6, Price3: 8, HasSuffix: false);
    }

    public void ManaOverdrain_Potion_Upgrade(){
        Upgrade(ManaOverdrain_Potion, "ManaOverdrain_Potion", MaxUpgradesCount: 3, Price1: 2, Price2: 6, Price3: 8, HasSuffix: false, IsBool:false);
    }

    public void Shield_MagicDef_2Perc_1_Text(){
        GetText(Shield_MagicDef_2Perc_1, "Shield_MagicDef_2Perc_1", TextName: "Shield_Magic_Defence", Price1: 3, Price2: 3, Price3: 4, Price4: 4, Price5: 4, Format1: 2, HasCheck: false, HasSuffix: false);
    }

    public void Shield_MagicDef_2Perc_1_Upgrade(){
        Upgrade(Shield_MagicDef_2Perc_1, "Shield_MagicDef_2Perc_1", Price1: 3, Price2: 3, Price3: 4, Price4: 4, Price5: 4, HasSuffix: false, IsBool:false, Invoke1: "Shield");
    }

    public void Shield_MagicDef_2Perc_2_Text(){
        GetText(Shield_MagicDef_2Perc_2, "Shield_MagicDef_2Perc_2", TextName: "Shield_Magic_Defence", Price1: 3, Price2: 4, Price3: 5, Price4: 5, Price5: 5, Format1: 2, HasCheck: false, HasSuffix: false);
    }

    public void Shield_MagicDef_2Perc_2_Upgrade(){
        Upgrade(Shield_MagicDef_2Perc_2, "Shield_MagicDef_2Perc_2", Price1: 3, Price2: 4, Price3: 5, Price4: 5, Price5: 5, HasSuffix: false, IsBool:false, Invoke1: "Shield");
    }

    public void Shield_DmgReturn_1Perc_1_Text(){
        GetText(Shield_DmgReturn_1Perc_1, "Shield_DmgReturn_1Perc_1", TextName: "Shield_Damage_Return", Price1: 4, Price2: 3, Price3: 4, Price4: 4, Price5: 4, Format1: 1, HasCheck: false, HasSuffix: false);
    }

    public void Shield_DmgReturn_1Perc_1_Upgrade(){
        Upgrade(Shield_DmgReturn_1Perc_1, "Shield_DmgReturn_1Perc_1", Price1: 4, Price2: 3, Price3: 4, Price4: 4, Price5: 4, HasSuffix: false, IsBool:false, Invoke1: "Shield");
    }

    public void Shield_DmgReturn_1Perc_2_Text(){
        GetText(Shield_DmgReturn_1Perc_2, "Shield_DmgReturn_1Perc_2", TextName: "Shield_Damage_Return", Price1: 3, Price2: 4, Price3: 5, Price4: 5, Price5: 5, Format1: 1, HasCheck: false, HasSuffix: false);
    }

    public void Shield_DmgReturn_1Perc_2_Upgrade(){
        Upgrade(Shield_DmgReturn_1Perc_2, "Shield_DmgReturn_1Perc_2", Price1: 3, Price2: 4, Price3: 5, Price4: 5, Price5: 5, HasSuffix: false, IsBool:false, Invoke1: "Shield");
    }

    public void Mana_10_2_Text(){
        GetText(Mana_10_2, "Mana_10_2", TextName: "More_Mana", Price1: 4, Price2: 2, Price3: 2, Price4: 3, Price5: 3, HasCheck: false);
    }

    public void Mana_10_2_Upgrade(){
        Upgrade(Mana_10_2, "Mana_10_2", Price1: 4, Price2: 2, Price3: 2, Price4: 3, Price5: 3, IsBool:false, Invoke1: "Mana");
    }

    public void Mana_1Perc_1_Text(){
        GetText(Mana_1Perc_1, "Mana_1Perc_1", TextName: "Even_More_Mana", Price1: 2, Price2: 1, Price3: 1, Price4: 2, Price5: 2, Format1: 1, HasCheck: false);
    }

    public void Mana_1Perc_1_Upgrade(){
        Upgrade(Mana_1Perc_1, "Mana_1Perc_1", Price1: 2, Price2: 1, Price3: 1, Price4: 2, Price5: 2, IsBool:false, Invoke1: "ManaModifier");
    }

    public void Mana_2Perc_1_Text(){
        GetText(Mana_2Perc_1, "Mana_2Perc_1", TextName: "Even_More_Mana", Price1: 1, Price2: 2, Price3: 3, Price4: 3, Price5: 4, Format1: 2, HasCheck: false);
    }

    public void Mana_2Perc_1_Upgrade(){
        Upgrade(Mana_2Perc_1, "Mana_2Perc_1", Price1: 1, Price2: 2, Price3: 3, Price4: 3, Price5: 4, IsBool:false, Invoke1: "ManaModifier");
    }

    public void HP_5_1_Text(){
        GetText(HP_5_1, "HP_5_1", TextName: "Additional_Health", Price1: 2, Price2: 1, Price3: 1, Price4: 1, Price5: 2, Format1: 5, HasCheck: false);
    }

    public void HP_5_1_Upgrade(){
        Upgrade(HP_5_1, "HP_5_1", Price1: 2, Price2: 1, Price3: 1, Price4: 1, Price5: 2, IsBool:false, Invoke1: "Health");
    }

    public void MR_1_2_Text(){
        GetText(MR_1_2, "MR_1_2", TextName: "Mana_Regeneration", Price1: 1, Price2: 2, Price3: 2, Price4: 2, Price5: 3, Format1: 1, HasCheck: false);
    }

    public void MR_1_2_Upgrade(){
        Upgrade(MR_1_2, "MR_1_2", Price1: 1, Price2: 2, Price3: 2, Price4: 2, Price5: 3, IsBool:false, Invoke1: "ManaRegen");
    }

    public void ManaUsage_1Perc_1_Text(){
        GetText(ManaUsage_1Perc_1, "ManaUsage_1Perc_1", TextName: "Cheaper_Spells", Price1: 1, Price2: 1, Price3: 2, Price4: 2, Price5: 2, Format1: 1, HasCheck: false);
    }

    public void ManaUsage_1Perc_1_Upgrade(){
        Upgrade(ManaUsage_1Perc_1, "ManaUsage_1Perc_1", Price1: 1, Price2: 1, Price3: 2, Price4: 2, Price5: 2, IsBool:false, Invoke1: "ManaCost");
    }

    public void MR_2_1_Text(){
        GetText(MR_2_1, "MR_2_1", TextName: "Mana_Regeneration", Price1: 1, Price2: 3, Price3: 4, Price4: 4, Price5: 4, Format1: 2, HasCheck: false);
    }

    public void MR_2_1_Upgrade(){
        Upgrade(MR_2_1, "MR_2_1", Price1: 1, Price2: 3, Price3: 4, Price4: 4, Price5: 4, IsBool:false, Invoke1: "ManaRegen");
    }

    public void DMG_Resistance_1_1_Text(){
        GetText(DMG_Resistance_1_1, "DMG_Resistance_1_1", TextName: "Damage_Resistance", Price1: 3, Price2: 3, Price3: 3, Price4: 4, Price5: 4, Format1: 1, HasCheck: false);
    }

    public void DMG_Resistance_1_1_Upgrade(){
        Upgrade(DMG_Resistance_1_1, "DMG_Resistance_1_1", Price1: 3, Price2: 3, Price3: 3, Price4: 4, Price5: 4, IsBool:false, Invoke1: "DamageResistance");
    }

    public void Mana_10_3_Text(){
        GetText(Mana_10_3, "Mana_10_3", TextName: "More_Mana", Price1: 2, Price2: 2, Price3: 2, Price4: 2, Price5: 3, HasCheck: false);
    }

    public void Mana_10_3_Upgrade(){
        Upgrade(Mana_10_3, "Mana_10_3", Price1: 2, Price2: 2, Price3: 2, Price4: 2, Price5: 3, IsBool:false, Invoke1: "Mana");
    }

    public void ManaUsage_1Perc_2_Text(){
        GetText(ManaUsage_1Perc_2, "ManaUsage_1Perc_2", TextName: "Cheaper_Spells", Price1: 2, Price2: 1, Price3: 1, Price4: 2, Price5: 2, Format1: 1, HasCheck: false);
    }

    public void ManaUsage_1Perc_2_Upgrade(){
        Upgrade(ManaUsage_1Perc_2, "ManaUsage_1Perc_2", Price1: 2, Price2: 1, Price3: 1, Price4: 2, Price5: 2, IsBool:false, Invoke1: "ManaCost");
    }

    public void Mana_2Perc_2_Text(){
        GetText(Mana_2Perc_2, "Mana_2Perc_2", TextName: "Even_More_Mana", Price1: 1, Price2: 2, Price3: 3, Price4: 3, Price5: 4, Format1: 2, HasCheck: false);
    }

    public void Mana_2Perc_2_Upgrade(){
        Upgrade(Mana_2Perc_2, "Mana_2Perc_2", Price1: 1, Price2: 2, Price3: 3, Price4: 3, Price5: 4, IsBool:false, Invoke1: "ManaModifier");
    }

    public void Mana_20_1_Text(){
        GetText(Mana_20_1, "Mana_20_1", TextName: "A_Lot_Of_Mana", Price1: 2, Price2: 4, Price3: 4, Price4: 4, Price5: 5, HasCheck: false);
    }

    public void Mana_20_1_Upgrade(){
        Upgrade(Mana_20_1, "Mana_20_1", Price1: 2, Price2: 4, Price3: 4, Price4: 4, Price5: 5, IsBool:false, Invoke1: "Mana");
    }

    public void ManaUsage_1Perc_3_Text(){
        GetText(ManaUsage_1Perc_3, "ManaUsage_1Perc_3", TextName: "Cheaper_Spells", Price1: 3, Price2: 1, Price3: 2, Price4: 2, Price5: 2, Format1: 1, HasCheck: false);
    }

    public void ManaUsage_1Perc_3_Upgrade(){
        Upgrade(ManaUsage_1Perc_3, "ManaUsage_1Perc_3", Price1: 3, Price2: 1, Price3: 2, Price4: 2, Price5: 2, IsBool:false, Invoke1: "ManaCost");
    }

    public void Mana_3Perc_1_Text(){
        GetText(Mana_3Perc_1, "Mana_3Perc_1", TextName: "Even_More_Mana", Price1: 1, Price2: 3, Price3: 4, Price4: 4, Price5: 4, Format1: 3, HasCheck: false);
    }

    public void Mana_3Perc_1_Upgrade(){
        Upgrade(Mana_3Perc_1, "Mana_3Perc_1", Price1: 1, Price2: 3, Price3: 4, Price4: 4, Price5: 4, IsBool:false, Invoke1: "ManaModifier");
    }

    public void Mana_2Perc_3_Text(){
        GetText(Mana_2Perc_3, "Mana_2Perc_3", TextName: "Even_More_Mana", Price1: 3, Price2: 2, Price3: 3, Price4: 3, Price5: 4, Format1: 2, HasCheck: false);
    }

    public void Mana_2Perc_3_Upgrade(){
        Upgrade(Mana_2Perc_3, "Mana_2Perc_3", Price1: 3, Price2: 2, Price3: 3, Price4: 3, Price5: 4, IsBool:false, Invoke1: "ManaModifier");
    }

    public void ManaUsage_3Perc_1_Text(){
        GetText(ManaUsage_3Perc_1, "ManaUsage_3Perc_1", TextName: "Cheaper_Spells", Price1: 2, Price2: 3, Price3: 4, Price4: 4, Price5: 4, Format1: 3, HasCheck: false);
    }

    public void ManaUsage_3Perc_1_Upgrade(){
        Upgrade(ManaUsage_3Perc_1, "ManaUsage_3Perc_1", Price1: 2, Price2: 3, Price3: 4, Price4: 4, Price5: 4, IsBool:false, Invoke1: "ManaCost");
    }

    public void HP_10_1_Text(){
        GetText(HP_10_1, "HP_10_1", TextName: "Additional_Health", Price1: 3, Price2: 2, Price3: 2, Price4: 2, Price5: 2, Format1: 10, HasCheck: false);
    }

    public void HP_10_1_Upgrade(){
        Upgrade(HP_10_1, "HP_10_1", Price1: 3, Price2: 2, Price3: 2, Price4: 2, Price5: 2, IsBool:false, Invoke1: "Health");
    }

    public void ManaUsage_1Perc_4_Text(){
        GetText(ManaUsage_1Perc_4, "ManaUsage_1Perc_4", TextName: "Cheaper_Spells", Price1: 2, Price2: 1, Price3: 1, Price4: 2, Price5: 2, Format1: 1, HasCheck: false);
    }

    public void ManaUsage_1Perc_4_Upgrade(){
        Upgrade(ManaUsage_1Perc_4, "ManaUsage_1Perc_4", Price1: 2, Price2: 1, Price3: 1, Price4: 2, Price5: 2, IsBool:false, Invoke1: "ManaCost");
    }

    public void MR_2_2_Text(){
        GetText(MR_2_2, "MR_2_2", TextName: "Mana_Regeneration", Price1: 1, Price2: 3, Price3: 4, Price4: 4, Price5: 4, Format1: 2, HasCheck: false);
    }

    public void MR_2_2_Upgrade(){
        Upgrade(MR_2_2, "MR_2_2", Price1: 1, Price2: 3, Price3: 4, Price4: 4, Price5: 4, IsBool:false, Invoke1: "ManaRegen");
    }

    public void HP_10_2_Text(){
        GetText(HP_10_2, "HP_10_2", TextName: "Additional_Health", Price1: 3, Price2: 2, Price3: 2, Price4: 2, Price5: 2, Format1: 10, HasCheck: false);
    }

    public void HP_10_2_Upgrade(){
        Upgrade(HP_10_2, "HP_10_2", Price1: 3, Price2: 2, Price3: 2, Price4: 2, Price5: 2, IsBool:false, Invoke1: "Health");
    }

    public void MR_3_1_Text(){
        GetText(MR_3_1, "MR_3_1", TextName: "Mana_Regeneration", Price1: 2, Price2: 5, Price3: 5, Price4: 5, Price5: 6, Format1: 3, HasCheck: false);
    }

    public void MR_3_1_Upgrade(){
        Upgrade(MR_3_1, "MR_3_1", Price1: 2, Price2: 5, Price3: 5, Price4: 5, Price5: 6, IsBool:false, Invoke1: "ManaRegen");
    }

    public void MR_3_2_Text(){
        GetText(MR_3_2, "MR_3_2", TextName: "Mana_Regeneration", Price1: 4, Price2: 5, Price3: 5, Price4: 5, Price5: 6, Format1: 3, HasCheck: false);
    }

    public void MR_3_2_Upgrade(){
        Upgrade(MR_3_2, "MR_3_2", Price1: 4, Price2: 5, Price3: 5, Price4: 5, Price5: 6, IsBool:false, Invoke1: "ManaRegen");
    }

    public void HP_10_3_Text(){
        GetText(HP_10_3, "HP_10_3", TextName: "Additional_Health", Price1: 4, Price2: 2, Price3: 2, Price4: 2, Price5: 2, Format1: 10, HasCheck: false);
    }

    public void HP_10_3_Upgrade(){
        Upgrade(HP_10_3, "HP_10_3", Price1: 4, Price2: 2, Price3: 2, Price4: 2, Price5: 2, IsBool:false, Invoke1: "Health");
    }

    public void ManaUsage_3Perc_2_Text(){
        GetText(ManaUsage_3Perc_2, "ManaUsage_3Perc_2", TextName: "Cheaper_Spells", Price1: 2, Price2: 3, Price3: 3, Price4: 4, Price5: 4, Format1: 3, HasCheck: false);
    }

    public void ManaUsage_3Perc_2_Upgrade(){
        Upgrade(ManaUsage_3Perc_2, "ManaUsage_3Perc_2", Price1: 2, Price2: 3, Price3: 3, Price4: 4, Price5: 4, IsBool:false, Invoke1: "ManaCost");
    }

    public void MR_3_3_Text(){
        GetText(MR_3_3, "MR_3_3", TextName: "Mana_Regeneration", Price1: 3, Price2: 5, Price3: 5, Price4: 5, Price5: 6, Format1: 3, HasCheck: false);
    }

    public void MR_3_3_Upgrade(){
        Upgrade(MR_3_3, "MR_3_3", Price1: 3, Price2: 5, Price3: 5, Price4: 5, Price5: 6, IsBool:false, Invoke1: "ManaRegen");
    }

    public void HP_15_1_Text(){
        GetText(HP_15_1, "HP_15_1", TextName: "Additional_Health", Price1: 4, Price2: 3, Price3: 3, Price4: 3, Price5: 3, Format1: 15, HasCheck: false);
    }

    public void HP_15_1_Upgrade(){
        Upgrade(HP_15_1, "HP_15_1", Price1: 4, Price2: 3, Price3: 3, Price4: 3, Price5: 3, IsBool:false, Invoke1: "Health");
    }

    public void DMG_Resistance_1_2_Text(){
        GetText(DMG_Resistance_1_2, "DMG_Resistance_1_2", TextName: "Damage_Resistance", Price1: 2, Price2: 2, Price3: 2, Price4: 3, Price5: 4, Format1: 1, HasCheck: false);
    }

    public void DMG_Resistance_1_2_Upgrade(){
        Upgrade(DMG_Resistance_1_2, "DMG_Resistance_1_2", Price1: 2, Price2: 2, Price3: 2, Price4: 3, Price5: 4, IsBool:false, Invoke1: "DamageResistance");
    }

    public void BS_Mana_CheckUpgrade(){
        CheckUpgradeSingle(BS_Mana, "BS_Mana", Lvl: Convert.ToInt32(SkillManager.BS_Mana), CheckValLvl1: 25, CheckValLvl2: 70);
    }

    public void BS_Mana_Text(){
        GetText(BS_Mana, "BS_Mana", TextName: "Beginner_Mana", MaxUpgradesCount: 2, Price1: 2, Price2: 5, HasSuffix: false);
    }

    public void BS_Mana_Upgrade(){
        Upgrade(BS_Mana, "BS_Mana", MaxUpgradesCount: 2, Price1: 2, Price2: 5, HasSuffix: false, IsBool:false);
    }

    public void BS_Damage_CheckUpgrade(){
        CheckUpgradeSingle(BS_Damage, "BS_Damage", Lvl: Convert.ToInt32(SkillManager.BS_Damage), CheckValLvl1: 20, CheckValLvl2: 35, CheckValLvl3: 45);
    }

    public void BS_Damage_Text(){
        GetText(BS_Damage, "BS_Damage", TextName: "Beginner_Damage", MaxUpgradesCount: 3, Price1: 4, Price2: 4, Price3: 4, HasSuffix: false);
    }

    public void BS_Damage_Upgrade(){
        Upgrade(BS_Damage, "BS_Damage", MaxUpgradesCount: 3, Price1: 4, Price2: 4, Price3: 4, HasSuffix: false, IsBool:false);
    }

    public void BS_Cooldown_CheckUpgrade(){
        CheckUpgradeSingle(BS_Cooldown, "BS_Cooldown", Lvl: Convert.ToInt32(SkillManager.BS_Cooldown), CheckValLvl1: 30, CheckValLvl2: 50, CheckValLvl3: 75);
    }

    public void BS_Cooldown_Text(){
        GetText(BS_Cooldown, "BS_Cooldown", TextName: "Beginner_Cooldown", MaxUpgradesCount: 3, Price1: 3, Price2: 4, Price3: 5, HasSuffix: false);
    }

    public void BS_Cooldown_Upgrade(){
        Upgrade(BS_Cooldown, "BS_Cooldown", MaxUpgradesCount: 3, Price1: 3, Price2: 4, Price3: 5, HasSuffix: false, IsBool:false);
    }

    public void BS_Poison_AddDuration_CheckUpgrade(){
        CheckUpgradeSingle(BS_Poison_AddDuration, "BS_Poison_AddDuration", Lvl: Convert.ToInt32(SkillManager.BS_Poison_AddDuration), CheckValLvl1: 20);
    }

    public void BS_Poison_AddDuration_Text(){
        GetText(BS_Poison_AddDuration, "BS_Poison_AddDuration", TextName: "Deadlier_Poison", MaxUpgradesCount: 1, Price1: 3, HasSuffix: false);
    }

    public void BS_Poison_AddDuration_Upgrade(){
        Upgrade(BS_Poison_AddDuration, "BS_Poison_AddDuration", MaxUpgradesCount: 1, Price1: 3, HasSuffix: false);
    }

    public void BS_Weakness_CheckUpgrade(){
        CheckUpgradeSingle(BS_Weakness, "BS_Weakness", Lvl: Convert.ToInt32(SkillManager.BS_Weakness), CheckValLvl1: 24, CheckValLvl2: 42);
    }

    public void BS_Weakness_Text(){
        GetText(BS_Weakness, "BS_Weakness", TextName: "More_Effects", MaxUpgradesCount: 2, Price1: 3, Price2: 3, HasSuffix: false);
    }

    public void BS_Weakness_Upgrade(){
        Upgrade(BS_Weakness, "BS_Weakness", MaxUpgradesCount: 2, Price1: 3, Price2: 3, HasSuffix: false, IsBool:false);
    }

    public void CHU_CheckUpgrade(){
        CheckUpgradeSingle(CHU, "CHU", Lvl: Convert.ToInt32(SkillManager.CHU), CheckValLvl1: 60);
    }

    public void CHU_Text(){
        GetText(CHU, "CHU", TextName: "Chaos", MaxUpgradesCount: 1, Price1: 2, HasSuffix: false);
    }

    public void CHU_Upgrade(){
        Upgrade(CHU, "CHU", MaxUpgradesCount: 1, Price1: 2, HasSuffix: false);
    }

    public void CH_Cooldown_CheckUpgrade(){
        CheckUpgradeSingle(CH_Cooldown, "CH_Cooldown", Lvl: Convert.ToInt32(SkillManager.CH_Cooldown), CheckValLvl1: 85, CheckValLvl2: 120);
    }

    public void CH_Cooldown_Text(){
        GetText(CH_Cooldown, "CH_Cooldown", TextName: "Chaos_Cooldown", MaxUpgradesCount: 2, Price1: 5, Price2: 5, HasSuffix: false);
    }

    public void CH_Cooldown_Upgrade(){
        Upgrade(CH_Cooldown, "CH_Cooldown", MaxUpgradesCount: 2, Price1: 5, Price2: 5, HasSuffix: false, IsBool:false);
    }

    public void CH_Mana_CheckUpgrade(){
        CheckUpgradeSingle(CH_Mana, "CH_Mana", Lvl: Convert.ToInt32(SkillManager.CH_Mana), CheckValLvl1: 70, CheckValLvl2: 90, CheckValLvl3: 110);
    }

    public void CH_Mana_Text(){
        GetText(CH_Mana, "CH_Mana", TextName: "Chaos_Mana", MaxUpgradesCount: 3, Price1: 4, Price2: 4, Price3: 6, HasSuffix: false);
    }

    public void CH_Mana_Upgrade(){
        Upgrade(CH_Mana, "CH_Mana", MaxUpgradesCount: 3, Price1: 4, Price2: 4, Price3: 6, HasSuffix: false, IsBool:false);
    }

    public void CH_Damage_CheckUpgrade(){
        CheckUpgradeSingle(CH_Damage, "CH_Damage", Lvl: Convert.ToInt32(SkillManager.CH_Damage), CheckValLvl1: 65, CheckValLvl2: 72, CheckValLvl3: 80);
    }

    public void CH_Damage_Text(){
        GetText(CH_Damage, "CH_Damage", TextName: "Chaos_Damage", MaxUpgradesCount: 2, Price1: 4, Price2: 5, HasSuffix: false);
    }

    public void CH_Damage_Upgrade(){
        Upgrade(CH_Damage, "CH_Damage", MaxUpgradesCount: 2, Price1: 4, Price2: 5, HasSuffix: false, IsBool:false);
    }

    public void CH_Effect_CheckUpgrade(){
        CheckUpgradeSingle(CH_Effect, "CH_Effect", Lvl: Convert.ToInt32(SkillManager.CH_Effect), CheckValLvl1: 85);
    }

    public void CH_Effect_Text(){
        GetText(CH_Effect, "CH_Effect", TextName: "Chaos_Effect", MaxUpgradesCount: 1, Price1: 3, HasSuffix: false);
    }

    public void CH_Effect_Upgrade(){
        Upgrade(CH_Effect, "CH_Effect", MaxUpgradesCount: 1, Price1: 3, HasSuffix: false);
    }

    public void CH_Effect_EVChance_CheckUpgrade(){
        CheckUpgradeSingle(CH_Effect_EVChance, "CH_Effect_EVChance", Lvl: Convert.ToInt32(SkillManager.CH_Effect_EVChance), CheckValLvl1: 95, CheckValLvl2: 120);
    }

    public void CH_Effect_EVChance_Text(){
        GetText(CH_Effect_EVChance, "CH_Effect_EVChance", TextName: "Chaos_Effect_Avoid_Chance", MaxUpgradesCount: 2, Price1: 6, Price2: 5, HasSuffix: false);
    }

    public void CH_Effect_EVChance_Upgrade(){
        Upgrade(CH_Effect_EVChance, "CH_Effect_EVChance", MaxUpgradesCount: 2, Price1: 6, Price2: 5, HasSuffix: false, IsBool:false);
    }

    public void CH_Effect_Damage_CheckUpgrade(){
        CheckUpgradeSingle(CH_Effect_Damage, "CH_Effect_Damage", Lvl: Convert.ToInt32(SkillManager.CH_Effect_Damage), CheckValLvl1: 90, CheckValLvl2: 130);
    }

    public void CH_Effect_Damage_Text(){
        GetText(CH_Effect_Damage, "CH_Effect_Damage", TextName: "Chaos_Effect_Damage", MaxUpgradesCount: 2, Price1: 5, Price2: 5, HasSuffix: false);
    }

    public void CH_Effect_Damage_Upgrade(){
        Upgrade(CH_Effect_Damage, "CH_Effect_Damage", MaxUpgradesCount: 2, Price1: 5, Price2: 5, HasSuffix: false, IsBool:false);
    }

    public void CH_Effect_Duration_CheckUpgrade(){
        CheckUpgradeSingle(CH_Effect_Duration, "CH_Effect_Duration", Lvl: Convert.ToInt32(SkillManager.CH_Effect_Duration), CheckValLvl1: 98, CheckValLvl2: 128);
    }

    public void CH_Effect_Duration_Text(){
        GetText(CH_Effect_Duration, "CH_Effect_Duration", TextName: "Chaos_Effect_Duration", MaxUpgradesCount: 2, Price1: 4, Price2: 5, HasSuffix: false);
    }

    public void CH_Effect_Duration_Upgrade(){
        Upgrade(CH_Effect_Duration, "CH_Effect_Duration", MaxUpgradesCount: 2, Price1: 4, Price2: 5, HasSuffix: false, IsBool:false);
    }

    public void VU_CheckUpgrade(){
        CheckUpgradeSingle(VU, "VU", Lvl: Convert.ToInt32(SkillManager.VU), CheckValLvl1: 100);
    }

    public void VU_Text(){
        GetText(VU, "VU", TextName: "Vampirism", MaxUpgradesCount: 1, Price1: 4, HasSuffix: false);
    }

    public void VU_Upgrade(){
        Upgrade(VU, "VU", MaxUpgradesCount: 1, Price1: 4, HasSuffix: false);
    }

    public void V_Mana_CheckUpgrade(){
        CheckUpgradeSingle(V_Mana, "V_Mana", Lvl: Convert.ToInt32(SkillManager.V_Mana), CheckValLvl1: 120, CheckValLvl2: 165);
    }

    public void V_Mana_Text(){
        GetText(V_Mana, "V_Mana", TextName: "Vampirism_Mana", MaxUpgradesCount: 2, Price1: 6, Price2: 5, HasSuffix: false);
    }

    public void V_Mana_Upgrade(){
        Upgrade(V_Mana, "V_Mana", MaxUpgradesCount: 2, Price1: 6, Price2: 5, HasSuffix: false, IsBool:false);
    }

    public void V_EffectHeal_CheckUpgrade(){
        CheckUpgradeSingle(V_EffectHeal, "V_EffectHeal", Lvl: Convert.ToInt32(SkillManager.V_EffectHeal), CheckValLvl1: 135, CheckValLvl2: 170);
    }

    public void V_EffectHeal_Text(){
        GetText(V_EffectHeal, "V_EffectHeal", TextName: "Vampirism_Effect_Heal", MaxUpgradesCount: 2, Price1: 4, Price2: 7, HasSuffix: false);
    }

    public void V_EffectHeal_Upgrade(){
        Upgrade(V_EffectHeal, "V_EffectHeal", MaxUpgradesCount: 2, Price1: 4, Price2: 7, HasSuffix: false, IsBool:false);
    }

    public void V_Damage_CheckUpgrade(){
        CheckUpgradeSingle(V_Damage, "V_Damage", Lvl: Convert.ToInt32(SkillManager.V_Damage), CheckValLvl1: 110, CheckValLvl2: 130, CheckValLvl3: 155);
    }

    public void V_Damage_Text(){
        GetText(V_Damage, "V_Damage", TextName: "Vampirism_Damage", MaxUpgradesCount: 3, Price1: 6, Price2: 6, Price3: 7, HasSuffix: false);
    }

    public void V_Damage_Upgrade(){
        Upgrade(V_Damage, "V_Damage", MaxUpgradesCount: 3, Price1: 6, Price2: 6, Price3: 7, HasSuffix: false, IsBool:false);
    }

    public void V_Heal_CheckUpgrade(){
        CheckUpgradeSingle(V_Heal, "V_Heal", Lvl: Convert.ToInt32(SkillManager.V_Heal), CheckValLvl1: 120, CheckValLvl2: 140, CheckValLvl3: 157);
    }

    public void V_Heal_Text(){
        GetText(V_Heal, "V_Heal", TextName: "Vampirism_Heal", MaxUpgradesCount: 3, Price1: 5, Price2: 5, Price3: 7, HasSuffix: false);
    }

    public void V_Heal_Upgrade(){
        Upgrade(V_Heal, "V_Heal", MaxUpgradesCount: 3, Price1: 5, Price2: 5, Price3: 7, HasSuffix: false, IsBool:false);
    }

    public void BS_NoEvasion_CheckUpgrade(){
        CheckUpgradeSingle(BS_NoEvasion, "BS_NoEvasion", Lvl: Convert.ToInt32(SkillManager.BS_NoEvasion), CheckValLvl1: 14);
    }

    public void BS_NoEvasion_Text(){
        GetText(BS_NoEvasion, "BS_NoEvasion", TextName: "Perfect_Accuracy", MaxUpgradesCount: 1, Price1: 4, HasCheck: false, HasSuffix: false);
    }

    public void BS_NoEvasion_Upgrade(){
        Upgrade(BS_NoEvasion, "BS_NoEvasion", MaxUpgradesCount: 1, Price1: 4, HasSuffix: false);
    }

    /*

    public void BSU_CheckUpgrade(){
        CheckUpgrade(BSU, "", 0, 0);
    }

    public void BSU_Text(){
        GetText(BSU, "BSU");
    }

    public void BSU_Upgrade(){
        Upgrade(BSU, "BSU");
    }

    public void MR_1_1_Check(){
        Check(MR_1_1, "", 0, 0);
    }

    public void MR_1_1_CheckUpgrade(){
        CheckUpgrade(MR_1_1, "", 0, 0);
    }

    public void MR_1_1_Text(){
        GetText(MR_1_1, "MR_1_1");
    }

    public void MR_1_1_Upgrade(){
        Upgrade(MR_1_1, "MR_1_1");
    }

    public void Mana_10_1_Check(){
        Check(Mana_10_1, "", 0, 0);
    }

    public void Mana_10_1_CheckUpgrade(){
        CheckUpgrade(Mana_10_1, "", 0, 0);
    }

    public void Mana_10_1_Text(){
        GetText(Mana_10_1, "Mana_10_1");
    }

    public void Mana_10_1_Upgrade(){
        Upgrade(Mana_10_1, "Mana_10_1");
    }

    public void ManaOverdrain_Check(){
        Check(ManaOverdrain, "", 0, 0);
    }

    public void ManaOverdrain_CheckUpgrade(){
        CheckUpgrade(ManaOverdrain, "", 0, 0);
    }

    public void ManaOverdrain_Text(){
        GetText(ManaOverdrain, "ManaOverdrain");
    }

    public void ManaOverdrain_Upgrade(){
        Upgrade(ManaOverdrain, "ManaOverdrain");
    }

    public void ManaOverdrain_Perc_Check(){
        Check(ManaOverdrain_Perc, "", 0, 0);
    }

    public void ManaOverdrain_Perc_CheckUpgrade(){
        CheckUpgrade(ManaOverdrain_Perc, "", 0, 0);
    }

    public void ManaOverdrain_Perc_Text(){
        GetText(ManaOverdrain_Perc, "ManaOverdrain_Perc");
    }

    public void ManaOverdrain_Perc_Upgrade(){
        Upgrade(ManaOverdrain_Perc, "ManaOverdrain_Perc");
    }

    public void ManaOverdrain_Potion_Check(){
        Check(ManaOverdrain_Potion, "", 0, 0);
    }

    public void ManaOverdrain_Potion_CheckUpgrade(){
        CheckUpgrade(ManaOverdrain_Potion, "", 0, 0);
    }

    public void ManaOverdrain_Potion_Text(){
        GetText(ManaOverdrain_Potion, "ManaOverdrain_Potion");
    }

    public void ManaOverdrain_Potion_Upgrade(){
        Upgrade(ManaOverdrain_Potion, "ManaOverdrain_Potion");
    }

    public void Shield_MagicDef_2Perc_1_Check(){
        Check(Shield_MagicDef_2Perc_1, "", 0, 0);
    }

    public void Shield_MagicDef_2Perc_1_CheckUpgrade(){
        CheckUpgrade(Shield_MagicDef_2Perc_1, "", 0, 0);
    }

    public void Shield_MagicDef_2Perc_1_Text(){
        GetText(Shield_MagicDef_2Perc_1, "Shield_MagicDef_2Perc_1");
    }

    public void Shield_MagicDef_2Perc_1_Upgrade(){
        Upgrade(Shield_MagicDef_2Perc_1, "Shield_MagicDef_2Perc_1");
    }

    public void Shield_MagicDef_2Perc_2_Check(){
        Check(Shield_MagicDef_2Perc_2, "", 0, 0);
    }

    public void Shield_MagicDef_2Perc_2_CheckUpgrade(){
        CheckUpgrade(Shield_MagicDef_2Perc_2, "", 0, 0);
    }

    public void Shield_MagicDef_2Perc_2_Text(){
        GetText(Shield_MagicDef_2Perc_2, "Shield_MagicDef_2Perc_2");
    }

    public void Shield_MagicDef_2Perc_2_Upgrade(){
        Upgrade(Shield_MagicDef_2Perc_2, "Shield_MagicDef_2Perc_2");
    }

    public void Shield_DmgReturn_1Perc_1_Check(){
        Check(Shield_DmgReturn_1Perc_1, "", 0, 0);
    }

    public void Shield_DmgReturn_1Perc_1_CheckUpgrade(){
        CheckUpgrade(Shield_DmgReturn_1Perc_1, "", 0, 0);
    }

    public void Shield_DmgReturn_1Perc_1_Text(){
        GetText(Shield_DmgReturn_1Perc_1, "Shield_DmgReturn_1Perc_1");
    }

    public void Shield_DmgReturn_1Perc_1_Upgrade(){
        Upgrade(Shield_DmgReturn_1Perc_1, "Shield_DmgReturn_1Perc_1");
    }

    public void Shield_DmgReturn_1Perc_2_Check(){
        Check(Shield_DmgReturn_1Perc_2, "", 0, 0);
    }

    public void Shield_DmgReturn_1Perc_2_CheckUpgrade(){
        CheckUpgrade(Shield_DmgReturn_1Perc_2, "", 0, 0);
    }

    public void Shield_DmgReturn_1Perc_2_Text(){
        GetText(Shield_DmgReturn_1Perc_2, "Shield_DmgReturn_1Perc_2");
    }

    public void Shield_DmgReturn_1Perc_2_Upgrade(){
        Upgrade(Shield_DmgReturn_1Perc_2, "Shield_DmgReturn_1Perc_2");
    }

    public void Mana_10_2_Check(){
        Check(Mana_10_2, "", 0, 0);
    }

    public void Mana_10_2_CheckUpgrade(){
        CheckUpgrade(Mana_10_2, "", 0, 0);
    }

    public void Mana_10_2_Text(){
        GetText(Mana_10_2, "Mana_10_2");
    }

    public void Mana_10_2_Upgrade(){
        Upgrade(Mana_10_2, "Mana_10_2");
    }

    public void Mana_1Perc_1_Check(){
        Check(Mana_1Perc_1, "", 0, 0);
    }

    public void Mana_1Perc_1_CheckUpgrade(){
        CheckUpgrade(Mana_1Perc_1, "", 0, 0);
    }

    public void Mana_1Perc_1_Text(){
        GetText(Mana_1Perc_1, "Mana_1Perc_1");
    }

    public void Mana_1Perc_1_Upgrade(){
        Upgrade(Mana_1Perc_1, "Mana_1Perc_1");
    }

    public void Mana_2Perc_1_Check(){
        Check(Mana_2Perc_1, "", 0, 0);
    }

    public void Mana_2Perc_1_CheckUpgrade(){
        CheckUpgrade(Mana_2Perc_1, "", 0, 0);
    }

    public void Mana_2Perc_1_Text(){
        GetText(Mana_2Perc_1, "Mana_2Perc_1");
    }

    public void Mana_2Perc_1_Upgrade(){
        Upgrade(Mana_2Perc_1, "Mana_2Perc_1");
    }

    public void HP_5_1_Check(){
        Check(HP_5_1, "", 0, 0);
    }

    public void HP_5_1_CheckUpgrade(){
        CheckUpgrade(HP_5_1, "", 0, 0);
    }

    public void HP_5_1_Text(){
        GetText(HP_5_1, "HP_5_1");
    }

    public void HP_5_1_Upgrade(){
        Upgrade(HP_5_1, "HP_5_1");
    }

    public void MR_1_2_Check(){
        Check(MR_1_2, "", 0, 0);
    }

    public void MR_1_2_CheckUpgrade(){
        CheckUpgrade(MR_1_2, "", 0, 0);
    }

    public void MR_1_2_Text(){
        GetText(MR_1_2, "MR_1_2");
    }

    public void MR_1_2_Upgrade(){
        Upgrade(MR_1_2, "MR_1_2");
    }

    public void ManaUsage_1Perc_1_Check(){
        Check(ManaUsage_1Perc_1, "", 0, 0);
    }

    public void ManaUsage_1Perc_1_CheckUpgrade(){
        CheckUpgrade(ManaUsage_1Perc_1, "", 0, 0);
    }

    public void ManaUsage_1Perc_1_Text(){
        GetText(ManaUsage_1Perc_1, "ManaUsage_1Perc_1");
    }

    public void ManaUsage_1Perc_1_Upgrade(){
        Upgrade(ManaUsage_1Perc_1, "ManaUsage_1Perc_1");
    }

    public void MR_2_1_Check(){
        Check(MR_2_1, "", 0, 0);
    }

    public void MR_2_1_CheckUpgrade(){
        CheckUpgrade(MR_2_1, "", 0, 0);
    }

    public void MR_2_1_Text(){
        GetText(MR_2_1, "MR_2_1");
    }

    public void MR_2_1_Upgrade(){
        Upgrade(MR_2_1, "MR_2_1");
    }

    public void DMG_Resistance_1_1_Check(){
        Check(DMG_Resistance_1_1, "", 0, 0);
    }

    public void DMG_Resistance_1_1_CheckUpgrade(){
        CheckUpgrade(DMG_Resistance_1_1, "", 0, 0);
    }

    public void DMG_Resistance_1_1_Text(){
        GetText(DMG_Resistance_1_1, "DMG_Resistance_1_1");
    }

    public void DMG_Resistance_1_1_Upgrade(){
        Upgrade(DMG_Resistance_1_1, "DMG_Resistance_1_1");
    }

    public void Mana_10_3_Check(){
        Check(Mana_10_3, "", 0, 0);
    }

    public void Mana_10_3_CheckUpgrade(){
        CheckUpgrade(Mana_10_3, "", 0, 0);
    }

    public void Mana_10_3_Text(){
        GetText(Mana_10_3, "Mana_10_3");
    }

    public void Mana_10_3_Upgrade(){
        Upgrade(Mana_10_3, "Mana_10_3");
    }

    public void ManaUsage_1Perc_2_Check(){
        Check(ManaUsage_1Perc_2, "", 0, 0);
    }

    public void ManaUsage_1Perc_2_CheckUpgrade(){
        CheckUpgrade(ManaUsage_1Perc_2, "", 0, 0);
    }

    public void ManaUsage_1Perc_2_Text(){
        GetText(ManaUsage_1Perc_2, "ManaUsage_1Perc_2");
    }

    public void ManaUsage_1Perc_2_Upgrade(){
        Upgrade(ManaUsage_1Perc_2, "ManaUsage_1Perc_2");
    }

    public void Mana_2Perc_2_Check(){
        Check(Mana_2Perc_2, "", 0, 0);
    }

    public void Mana_2Perc_2_CheckUpgrade(){
        CheckUpgrade(Mana_2Perc_2, "", 0, 0);
    }

    public void Mana_2Perc_2_Text(){
        GetText(Mana_2Perc_2, "Mana_2Perc_2");
    }

    public void Mana_2Perc_2_Upgrade(){
        Upgrade(Mana_2Perc_2, "Mana_2Perc_2");
    }

    public void Mana_20_1_Check(){
        Check(Mana_20_1, "", 0, 0);
    }

    public void Mana_20_1_CheckUpgrade(){
        CheckUpgrade(Mana_20_1, "", 0, 0);
    }

    public void Mana_20_1_Text(){
        GetText(Mana_20_1, "Mana_20_1");
    }

    public void Mana_20_1_Upgrade(){
        Upgrade(Mana_20_1, "Mana_20_1");
    }

    public void ManaUsage_1Perc_3_Check(){
        Check(ManaUsage_1Perc_3, "", 0, 0);
    }

    public void ManaUsage_1Perc_3_CheckUpgrade(){
        CheckUpgrade(ManaUsage_1Perc_3, "", 0, 0);
    }

    public void ManaUsage_1Perc_3_Text(){
        GetText(ManaUsage_1Perc_3, "ManaUsage_1Perc_3");
    }

    public void ManaUsage_1Perc_3_Upgrade(){
        Upgrade(ManaUsage_1Perc_3, "ManaUsage_1Perc_3");
    }

    public void Mana_3Perc_1_Check(){
        Check(Mana_3Perc_1, "", 0, 0);
    }

    public void Mana_3Perc_1_CheckUpgrade(){
        CheckUpgrade(Mana_3Perc_1, "", 0, 0);
    }

    public void Mana_3Perc_1_Text(){
        GetText(Mana_3Perc_1, "Mana_3Perc_1");
    }

    public void Mana_3Perc_1_Upgrade(){
        Upgrade(Mana_3Perc_1, "Mana_3Perc_1");
    }

    public void Mana_2Perc_3_Check(){
        Check(Mana_2Perc_3, "", 0, 0);
    }

    public void Mana_2Perc_3_CheckUpgrade(){
        CheckUpgrade(Mana_2Perc_3, "", 0, 0);
    }

    public void Mana_2Perc_3_Text(){
        GetText(Mana_2Perc_3, "Mana_2Perc_3");
    }

    public void Mana_2Perc_3_Upgrade(){
        Upgrade(Mana_2Perc_3, "Mana_2Perc_3");
    }

    public void ManaUsage_3Perc_1_Check(){
        Check(ManaUsage_3Perc_1, "", 0, 0);
    }

    public void ManaUsage_3Perc_1_CheckUpgrade(){
        CheckUpgrade(ManaUsage_3Perc_1, "", 0, 0);
    }

    public void ManaUsage_3Perc_1_Text(){
        GetText(ManaUsage_3Perc_1, "ManaUsage_3Perc_1");
    }

    public void ManaUsage_3Perc_1_Upgrade(){
        Upgrade(ManaUsage_3Perc_1, "ManaUsage_3Perc_1");
    }

    public void HP_10_1_Check(){
        Check(HP_10_1, "", 0, 0);
    }

    public void HP_10_1_CheckUpgrade(){
        CheckUpgrade(HP_10_1, "", 0, 0);
    }

    public void HP_10_1_Text(){
        GetText(HP_10_1, "HP_10_1");
    }

    public void HP_10_1_Upgrade(){
        Upgrade(HP_10_1, "HP_10_1");
    }

    public void ManaUsage_1Perc_4_Check(){
        Check(ManaUsage_1Perc_4, "", 0, 0);
    }

    public void ManaUsage_1Perc_4_CheckUpgrade(){
        CheckUpgrade(ManaUsage_1Perc_4, "", 0, 0);
    }

    public void ManaUsage_1Perc_4_Text(){
        GetText(ManaUsage_1Perc_4, "ManaUsage_1Perc_4");
    }

    public void ManaUsage_1Perc_4_Upgrade(){
        Upgrade(ManaUsage_1Perc_4, "ManaUsage_1Perc_4");
    }

    public void MR_2_2_Check(){
        Check(MR_2_2, "", 0, 0);
    }

    public void MR_2_2_CheckUpgrade(){
        CheckUpgrade(MR_2_2, "", 0, 0);
    }

    public void MR_2_2_Text(){
        GetText(MR_2_2, "MR_2_2");
    }

    public void MR_2_2_Upgrade(){
        Upgrade(MR_2_2, "MR_2_2");
    }

    public void HP_10_2_Check(){
        Check(HP_10_2, "", 0, 0);
    }

    public void HP_10_2_CheckUpgrade(){
        CheckUpgrade(HP_10_2, "", 0, 0);
    }

    public void HP_10_2_Text(){
        GetText(HP_10_2, "HP_10_2");
    }

    public void HP_10_2_Upgrade(){
        Upgrade(HP_10_2, "HP_10_2");
    }

    public void MR_3_1_Check(){
        Check(MR_3_1, "", 0, 0);
    }

    public void MR_3_1_CheckUpgrade(){
        CheckUpgrade(MR_3_1, "", 0, 0);
    }

    public void MR_3_1_Text(){
        GetText(MR_3_1, "MR_3_1");
    }

    public void MR_3_1_Upgrade(){
        Upgrade(MR_3_1, "MR_3_1");
    }

    public void MR_3_2_Check(){
        Check(MR_3_2, "", 0, 0);
    }

    public void MR_3_2_CheckUpgrade(){
        CheckUpgrade(MR_3_2, "", 0, 0);
    }

    public void MR_3_2_Text(){
        GetText(MR_3_2, "MR_3_2");
    }

    public void MR_3_2_Upgrade(){
        Upgrade(MR_3_2, "MR_3_2");
    }

    public void HP_10_3_Check(){
        Check(HP_10_3, "", 0, 0);
    }

    public void HP_10_3_CheckUpgrade(){
        CheckUpgrade(HP_10_3, "", 0, 0);
    }

    public void HP_10_3_Text(){
        GetText(HP_10_3, "HP_10_3");
    }

    public void HP_10_3_Upgrade(){
        Upgrade(HP_10_3, "HP_10_3");
    }

    public void ManaUsage_3Perc_2_Check(){
        Check(ManaUsage_3Perc_2, "", 0, 0);
    }

    public void ManaUsage_3Perc_2_CheckUpgrade(){
        CheckUpgrade(ManaUsage_3Perc_2, "", 0, 0);
    }

    public void ManaUsage_3Perc_2_Text(){
        GetText(ManaUsage_3Perc_2, "ManaUsage_3Perc_2");
    }

    public void ManaUsage_3Perc_2_Upgrade(){
        Upgrade(ManaUsage_3Perc_2, "ManaUsage_3Perc_2");
    }

    public void MR_3_3_Check(){
        Check(MR_3_3, "", 0, 0);
    }

    public void MR_3_3_CheckUpgrade(){
        CheckUpgrade(MR_3_3, "", 0, 0);
    }

    public void MR_3_3_Text(){
        GetText(MR_3_3, "MR_3_3");
    }

    public void MR_3_3_Upgrade(){
        Upgrade(MR_3_3, "MR_3_3");
    }

    public void HP_15_1_Check(){
        Check(HP_15_1, "", 0, 0);
    }

    public void HP_15_1_CheckUpgrade(){
        CheckUpgrade(HP_15_1, "", 0, 0);
    }

    public void HP_15_1_Text(){
        GetText(HP_15_1, "HP_15_1");
    }

    public void HP_15_1_Upgrade(){
        Upgrade(HP_15_1, "HP_15_1");
    }

    public void DMG_Resistance_1_2_Check(){
        Check(DMG_Resistance_1_2, "", 0, 0);
    }

    public void DMG_Resistance_1_2_CheckUpgrade(){
        CheckUpgrade(DMG_Resistance_1_2, "", 0, 0);
    }

    public void DMG_Resistance_1_2_Text(){
        GetText(DMG_Resistance_1_2, "DMG_Resistance_1_2");
    }

    public void DMG_Resistance_1_2_Upgrade(){
        Upgrade(DMG_Resistance_1_2, "DMG_Resistance_1_2");
    }

    public void BS_Mana_Check(){
        Check(BS_Mana, "", 0, 0);
    }

    public void BS_Mana_CheckUpgrade(){
        CheckUpgrade(BS_Mana, "", 0, 0);
    }

    public void BS_Mana_Text(){
        GetText(BS_Mana, "BS_Mana");
    }

    public void BS_Mana_Upgrade(){
        Upgrade(BS_Mana, "BS_Mana");
    }

    public void BS_Damage_Check(){
        Check(BS_Damage, "", 0, 0);
    }

    public void BS_Damage_CheckUpgrade(){
        CheckUpgrade(BS_Damage, "", 0, 0);
    }

    public void BS_Damage_Text(){
        GetText(BS_Damage, "BS_Damage");
    }

    public void BS_Damage_Upgrade(){
        Upgrade(BS_Damage, "BS_Damage");
    }

    public void BS_Cooldown_Check(){
        Check(BS_Cooldown, "", 0, 0);
    }

    public void BS_Cooldown_CheckUpgrade(){
        CheckUpgrade(BS_Cooldown, "", 0, 0);
    }

    public void BS_Cooldown_Text(){
        GetText(BS_Cooldown, "BS_Cooldown");
    }

    public void BS_Cooldown_Upgrade(){
        Upgrade(BS_Cooldown, "BS_Cooldown");
    }

    public void BS_Poison_AddDuration_Check(){
        Check(BS_Poison_AddDuration, "", 0, 0);
    }

    public void BS_Poison_AddDuration_CheckUpgrade(){
        CheckUpgrade(BS_Poison_AddDuration, "", 0, 0);
    }

    public void BS_Poison_AddDuration_Text(){
        GetText(BS_Poison_AddDuration, "BS_Poison_AddDuration");
    }

    public void BS_Poison_AddDuration_Upgrade(){
        Upgrade(BS_Poison_AddDuration, "BS_Poison_AddDuration");
    }

    public void BS_Weakness_Check(){
        Check(BS_Weakness, "", 0, 0);
    }

    public void BS_Weakness_CheckUpgrade(){
        CheckUpgrade(BS_Weakness, "", 0, 0);
    }

    public void BS_Weakness_Text(){
        GetText(BS_Weakness, "BS_Weakness");
    }

    public void BS_Weakness_Upgrade(){
        Upgrade(BS_Weakness, "BS_Weakness");
    }

    public void CHU_Check(){
        Check(CHU, "", 0, 0);
    }

    public void CHU_CheckUpgrade(){
        CheckUpgrade(CHU, "", 0, 0);
    }

    public void CHU_Text(){
        GetText(CHU, "CHU");
    }

    public void CHU_Upgrade(){
        Upgrade(CHU, "CHU");
    }

    public void CH_Cooldown_Check(){
        Check(CH_Cooldown, "", 0, 0);
    }

    public void CH_Cooldown_CheckUpgrade(){
        CheckUpgrade(CH_Cooldown, "", 0, 0);
    }

    public void CH_Cooldown_Text(){
        GetText(CH_Cooldown, "CH_Cooldown");
    }

    public void CH_Cooldown_Upgrade(){
        Upgrade(CH_Cooldown, "CH_Cooldown");
    }

    public void CH_Mana_Check(){
        Check(CH_Mana, "", 0, 0);
    }

    public void CH_Mana_CheckUpgrade(){
        CheckUpgrade(CH_Mana, "", 0, 0);
    }

    public void CH_Mana_Text(){
        GetText(CH_Mana, "CH_Mana");
    }

    public void CH_Mana_Upgrade(){
        Upgrade(CH_Mana, "CH_Mana");
    }

    public void CH_Damage_Check(){
        Check(CH_Damage, "", 0, 0);
    }

    public void CH_Damage_CheckUpgrade(){
        CheckUpgrade(CH_Damage, "", 0, 0);
    }

    public void CH_Damage_Text(){
        GetText(CH_Damage, "CH_Damage");
    }

    public void CH_Damage_Upgrade(){
        Upgrade(CH_Damage, "CH_Damage");
    }

    public void CH_Effect_Check(){
        Check(CH_Effect, "", 0, 0);
    }

    public void CH_Effect_CheckUpgrade(){
        CheckUpgrade(CH_Effect, "", 0, 0);
    }

    public void CH_Effect_Text(){
        GetText(CH_Effect, "CH_Effect");
    }

    public void CH_Effect_Upgrade(){
        Upgrade(CH_Effect, "CH_Effect");
    }

    public void CH_Effect_EVChance_Check(){
        Check(CH_Effect_EVChance, "", 0, 0);
    }

    public void CH_Effect_EVChance_CheckUpgrade(){
        CheckUpgrade(CH_Effect_EVChance, "", 0, 0);
    }

    public void CH_Effect_EVChance_Text(){
        GetText(CH_Effect_EVChance, "CH_Effect_EVChance");
    }

    public void CH_Effect_EVChance_Upgrade(){
        Upgrade(CH_Effect_EVChance, "CH_Effect_EVChance");
    }

    public void CH_Effect_Damage_Check(){
        Check(CH_Effect_Damage, "", 0, 0);
    }

    public void CH_Effect_Damage_CheckUpgrade(){
        CheckUpgrade(CH_Effect_Damage, "", 0, 0);
    }

    public void CH_Effect_Damage_Text(){
        GetText(CH_Effect_Damage, "CH_Effect_Damage");
    }

    public void CH_Effect_Damage_Upgrade(){
        Upgrade(CH_Effect_Damage, "CH_Effect_Damage");
    }

    public void CH_Effect_Duration_Check(){
        Check(CH_Effect_Duration, "", 0, 0);
    }

    public void CH_Effect_Duration_CheckUpgrade(){
        CheckUpgrade(CH_Effect_Duration, "", 0, 0);
    }

    public void CH_Effect_Duration_Text(){
        GetText(CH_Effect_Duration, "CH_Effect_Duration");
    }

    public void CH_Effect_Duration_Upgrade(){
        Upgrade(CH_Effect_Duration, "CH_Effect_Duration");
    }

    public void VU_Check(){
        Check(VU, "", 0, 0);
        
    }
    public void VU_CheckUpgrade(){
        CheckUpgrade(VU, "", 0, 0);
    }
    public void VU_Text(){
        GetText(VU, "VU");
    }

    public void VU_Upgrade(){
        Upgrade(VU, "VU");
    }

    public void V_Mana_Check(){
        Check(V_Mana, "", 0, 0);
    }

    public void V_Mana_CheckUpgrade(){
        CheckUpgrade(V_Mana, "", 0, 0);
    }

    public void V_Mana_Text(){
        GetText(V_Mana, "V_Mana");
    }

    public void V_Mana_Upgrade(){
        Upgrade(V_Mana, "V_Mana");
    }

    public void V_EffectHeal_Check(){
        Check(V_EffectHeal, "", 0, 0);
    }

    public void V_EffectHeal_CheckUpgrade(){
        CheckUpgrade(V_EffectHeal, "", 0, 0);
    }

    public void V_EffectHeal_Text(){
        GetText(V_EffectHeal, "V_EffectHeal");
    }

    public void V_EffectHeal_Upgrade(){
        Upgrade(V_EffectHeal, "V_EffectHeal");
    }

    public void V_Damage_Check(){
        Check(V_Damage, "", 0, 0);
    }

    public void V_Damage_CheckUpgrade(){
        CheckUpgrade(V_Damage, "", 0, 0);
    }

    public void V_Damage_Text(){
        GetText(V_Damage, "V_Damage");
    }

    public void V_Damage_Upgrade(){
        Upgrade(V_Damage, "V_Damage");
    }

    public void V_Heal_Check(){
        Check(V_Heal, "", 0, 0);
    }

    public void V_Heal_CheckUpgrade(){
        CheckUpgrade(V_Heal, "", 0, 0);
    }

    public void V_Heal_Text(){
        GetText(V_Heal, "V_Heal");
    }

    public void V_Heal_Upgrade(){
        Upgrade(V_Heal, "V_Heal");
    }*/

}

