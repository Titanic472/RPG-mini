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
        Upgrade(Object: PracticePlus, Name: "PracticePlus", Price1: SkillsUpgradeCost, Invoke1:"Mana", MaxUpgradesCount: 25, HasSuffix: false, SetInteractable1: ManaOverdrain, CheckVal1: 1, SetInteractable2: Mana_10_1, CheckVal2: 1, SetInteractable3: MR_1_1, CheckVal3: 1, SetInteractable4: BSU, CheckVal4: 1);
    }

    private void BSU_CheckUpgrade(){
        CheckUpgradeSingle(BSU, "BSU", Lvl: Convert.ToInt32(SkillManager.BSU), CheckValLvl1: 10);
    }

    public void BSU_Text(){
        GetText(BSU, "BSU", TextName: "Beginner_Spell", MaxUpgradesCount: 1, Price1: 4, HasSuffix: false);
    }

    public void BSU_Upgrade(){
        Upgrade(BSU, "BSU", MaxUpgradesCount: 1, Price1: 4, HasSuffix: false, IsBool: true, SetInteractable1: BS_Damage, CheckVal1: 1, SetInteractable2: BS_Mana, CheckVal2: 1, SetInteractable3: BS_NoEvasion, CheckVal3: 1);
        SkillManager.ActiveSkillsManager.SkillsUnlockCheck();
    }

    public void MR_1_1_Text(){
        GetText(MR_1_1, "MR_1_1", TextName: "Mana_Regeneration", Price1: 1, Price2: 1, Price3: 2, Price4: 2, Price5: 2, Format1: 1, HasCheck: false);
    }

    public void MR_1_1_Upgrade(){
        Upgrade(MR_1_1, "MR_1_1", Price1: 1, Price2: 1, Price3: 2, Price4: 2, Price5: 2, Invoke1: "ManaRegen", SetInteractable1: MR_1_2, CheckVal1: 3);
    }

    public void Mana_10_1_Text(){
        GetText(Mana_10_1, "Mana_10_1", TextName: "More_Mana", Price1: 1, Price2: 2, Price3: 2, Price4: 2, Price5: 3, HasCheck: false);
    }

    public void Mana_10_1_Upgrade(){
        Upgrade(Mana_10_1, "Mana_10_1", Price1: 1, Price2: 2, Price3: 2, Price4: 2, Price5: 3, Invoke1: "Mana", SetInteractable1: Mana_1Perc_1, CheckVal1: 4, SetInteractable2: Mana_10_2, CheckVal2: 3);
    }

    private void ManaOverdrain_CheckUpgrade(){
        CheckUpgradeSingle(ManaOverdrain, "ManaOverdrain", Lvl: Convert.ToInt32(SkillManager.ManaOverdrain), CheckValLvl1: 20);
    }

    public void ManaOverdrain_Text(){
        GetText(ManaOverdrain, "ManaOverdrain", TextName: "Mana_Overdrain", MaxUpgradesCount: 1, Price1: 4, HasSuffix: false);
    }

    public void ManaOverdrain_Upgrade(){
        Upgrade(ManaOverdrain, "ManaOverdrain", MaxUpgradesCount: 1, Price1: 4, HasSuffix: false, IsBool: true, SetInteractable1: ManaOverdrain_Perc, CheckVal1: 1, SetInteractable2: Shield_MagicDef_2Perc_1, CheckVal2: 1);
    }

    private void ManaOverdrain_Perc_CheckUpgrade(){
        CheckUpgradeSingle(ManaOverdrain_Perc, "ManaOverdrain_Perc", Lvl: Convert.ToInt32(SkillManager.ManaOverdrain_Perc), CheckValLvl1: 30, CheckValLvl2: 50, CheckValLvl3: 90);
    }

    public void ManaOverdrain_Perc_Text(){
        int Format;
        switch(SkillManager.ManaOverdrain_Perc){
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
        GetText(ManaOverdrain_Perc, "ManaOverdrain_Perc", TextName: "Mana_Overdrain_Percercent", MaxUpgradesCount: 3, Price1: 2, Price2: 4, Price3: 5, Format1: Format, HasSuffix: false);
    }

    public void ManaOverdrain_Perc_Upgrade(){
        Upgrade(ManaOverdrain_Perc, "ManaOverdrain_Perc", MaxUpgradesCount: 3, Price1: 2, Price2: 4, Price3: 5, HasSuffix: false, SetInteractable1: ManaOverdrain_Potion, CheckVal1: 1);
    }

    private void ManaOverdrain_Potion_CheckUpgrade(){
        CheckUpgradeSingle(ManaOverdrain_Potion, "ManaOverdrain_Potion", Lvl: Convert.ToInt32(SkillManager.ManaOverdrain_Potion), CheckValLvl1: 40, CheckValLvl2: 70, CheckValLvl3: 100);
    }

    public void ManaOverdrain_Potion_Text(){
        int Format;
        switch(SkillManager.ManaOverdrain_Potion){
            case 0:
                Format = 1;
                break;
            case 1:
                Format = 2;
                break;
            default:
                Format = 3;
                break;
        }
        GetText(ManaOverdrain_Potion, "ManaOverdrain_Potion", TextName: "Mana_Overdrain_Potion", MaxUpgradesCount: 3, Price1: 3, Price2: 6, Price3: 8, Format1: Format, HasSuffix: false);
    }

    public void ManaOverdrain_Potion_Upgrade(){
        Upgrade(ManaOverdrain_Potion, "ManaOverdrain_Potion", MaxUpgradesCount: 3, Price1: 3, Price2: 6, Price3: 8, HasSuffix: false);
    }

    public void Shield_MagicDef_2Perc_1_Text(){
        GetText(Shield_MagicDef_2Perc_1, "Shield_MagicDef_2Perc_1", TextName: "Shield_Magic_Defence", Price1: 3, Price2: 3, Price3: 4, Price4: 4, Price5: 4, Format1: 2, Format2: SkillManager.Shield_MagicDefence*100, HasCheck: false, HasSuffix: false);
    }

    public void Shield_MagicDef_2Perc_1_Upgrade(){
        Upgrade(Shield_MagicDef_2Perc_1, "Shield_MagicDef_2Perc_1", Price1: 3, Price2: 3, Price3: 4, Price4: 4, Price5: 4, HasSuffix: false, Invoke1: "Shield", SetInteractable1: Shield_MagicDef_2Perc_2, CheckVal1: 5, SetInteractable2: Shield_DmgReturn_1Perc_1, CheckVal2: 1);
    }

    public void Shield_MagicDef_2Perc_2_Text(){
        GetText(Shield_MagicDef_2Perc_2, "Shield_MagicDef_2Perc_2", TextName: "Shield_Magic_Defence", Price1: 4, Price2: 4, Price3: 5, Price4: 5, Price5: 5, Format1: 2, Format2: SkillManager.Shield_MagicDefence*100, HasCheck: false, HasSuffix: false);
    }

    public void Shield_MagicDef_2Perc_2_Upgrade(){
        Upgrade(Shield_MagicDef_2Perc_2, "Shield_MagicDef_2Perc_2", Price1: 4, Price2: 4, Price3: 5, Price4: 5, Price5: 5, HasSuffix: false, Invoke1: "Shield");
    }

    public void Shield_DmgReturn_1Perc_1_Text(){
        GetText(Shield_DmgReturn_1Perc_1, "Shield_DmgReturn_1Perc_1", TextName: "Shield_Damage_Return", Price1: 3, Price2: 3, Price3: 4, Price4: 4, Price5: 4, Format1: 1, Format2: SkillManager.Shield_DamageReturn*100, HasCheck: false, HasSuffix: false);
    }

    public void Shield_DmgReturn_1Perc_1_Upgrade(){
        Upgrade(Shield_DmgReturn_1Perc_1, "Shield_DmgReturn_1Perc_1", Price1: 3, Price2: 3, Price3: 4, Price4: 4, Price5: 4, HasSuffix: false, Invoke1: "Shield", SetInteractable1: Shield_DmgReturn_1Perc_2, CheckVal1: 5);
    }

    public void Shield_DmgReturn_1Perc_2_Text(){
        GetText(Shield_DmgReturn_1Perc_2, "Shield_DmgReturn_1Perc_2", TextName: "Shield_Damage_Return", Price1: 4, Price2: 4, Price3: 5, Price4: 5, Price5: 5, Format1: 1, Format2: SkillManager.Shield_DamageReturn*100, HasCheck: false, HasSuffix: false);
    }

    public void Shield_DmgReturn_1Perc_2_Upgrade(){
        Upgrade(Shield_DmgReturn_1Perc_2, "Shield_DmgReturn_1Perc_2", Price1: 4, Price2: 4, Price3: 5, Price4: 5, Price5: 5, HasSuffix: false, Invoke1: "Shield");
    }

    public void Mana_10_2_Text(){
        GetText(Mana_10_2, "Mana_10_2", TextName: "More_Mana", Price1: 2, Price2: 2, Price3: 2, Price4: 3, Price5: 3, HasCheck: false);
    }

    public void Mana_10_2_Upgrade(){
        Upgrade(Mana_10_2, "Mana_10_2", Price1: 2, Price2: 2, Price3: 2, Price4: 3, Price5: 3, Invoke1: "Mana", SetInteractable1: HP_5_1, CheckVal1: 3, SetInteractable2: Mana_2Perc_1, CheckVal2: 2);
    }

    public void Mana_1Perc_1_Text(){
        GetText(Mana_1Perc_1, "Mana_1Perc_1", TextName: "Even_More_Mana", Price1: 1, Price2: 1, Price3: 1, Price4: 2, Price5: 2, Format1: 1, HasCheck: false);
    }

    public void Mana_1Perc_1_Upgrade(){
        Upgrade(Mana_1Perc_1, "Mana_1Perc_1", Price1: 1, Price2: 1, Price3: 1, Price4: 2, Price5: 2, Invoke1: "ManaModifier");
    }

    public void Mana_2Perc_1_Text(){
        GetText(Mana_2Perc_1, "Mana_2Perc_1", TextName: "Even_More_Mana", Price1: 2, Price2: 2, Price3: 3, Price4: 3, Price5: 4, Format1: 2, HasCheck: false);
    }

    public void Mana_2Perc_1_Upgrade(){
        Upgrade(Mana_2Perc_1, "Mana_2Perc_1", Price1: 2, Price2: 2, Price3: 3, Price4: 3, Price5: 4, Invoke1: "ManaModifier", SetInteractable1: Mana_10_3, CheckVal1: 3, SetInteractable2: ManaUsage_1Perc_2, CheckVal2: 4);
    }

    public void HP_5_1_Text(){
        GetText(HP_5_1, "HP_5_1", TextName: "Additional_Health", Price1: 1, Price2: 1, Price3: 1, Price4: 1, Price5: 2, Format1: 5, HasCheck: false);
    }

    public void HP_5_1_Upgrade(){
        Upgrade(HP_5_1, "HP_5_1", Price1: 1, Price2: 1, Price3: 1, Price4: 1, Price5: 2, Invoke1: "Health");
        if(SkillManager.ManaUsage_1Perc_1_Sorcery>0) DMG_Resistance_1_1.GetComponent<Button>().interactable = true;
    }

    public void MR_1_2_Text(){
        GetText(MR_1_2, "MR_1_2", TextName: "Mana_Regeneration", Price1: 1, Price2: 2, Price3: 2, Price4: 2, Price5: 2, Format1: 1, HasCheck: false);
    }

    public void MR_1_2_Upgrade(){
        Upgrade(MR_1_2, "MR_1_2", Price1: 1, Price2: 2, Price3: 2, Price4: 2, Price5: 2, Invoke1: "ManaRegen", SetInteractable1: ManaUsage_1Perc_1, CheckVal1: 2, SetInteractable2: MR_2_1, CheckVal2: 3);
    }

    public void ManaUsage_1Perc_1_Text(){
        GetText(ManaUsage_1Perc_1, "ManaUsage_1Perc_1", TextName: "Cheaper_Spells", Price1: 1, Price2: 1, Price3: 2, Price4: 2, Price5: 2, Format1: 1, HasCheck: false);
    }

    public void ManaUsage_1Perc_1_Upgrade(){
        Upgrade(ManaUsage_1Perc_1, "ManaUsage_1Perc_1", Price1: 1, Price2: 1, Price3: 2, Price4: 2, Price5: 2, Invoke1: "ManaCost");
        if(SkillManager.HP_5_1_Sorcery>0) DMG_Resistance_1_1.GetComponent<Button>().interactable = true;
    }

    public void MR_2_1_Text(){
        GetText(MR_2_1, "MR_2_1", TextName: "Mana_Regeneration", Price1: 3, Price2: 3, Price3: 3, Price4: 4, Price5: 4, Format1: 2, HasCheck: false);
    }

    public void MR_2_1_Upgrade(){
        Upgrade(MR_2_1, "MR_2_1", Price1: 3, Price2: 3, Price3: 3, Price4: 4, Price5: 4, Invoke1: "ManaRegen", SetInteractable1: MR_2_2, CheckVal1: 3, SetInteractable2: ManaUsage_1Perc_4, CheckVal2: 1);
    }

    public void DMG_Resistance_1_1_Text(){
        GetText(DMG_Resistance_1_1, "DMG_Resistance_1_1", TextName: "Damage_Resistance", Price1: 2, Price2: 3, Price3: 3, Price4: 4, Price5: 4, Format1: 1, HasCheck: false);
    }

    public void DMG_Resistance_1_1_Upgrade(){
        Upgrade(DMG_Resistance_1_1, "DMG_Resistance_1_1", Price1: 2, Price2: 3, Price3: 3, Price4: 4, Price5: 4, Invoke1: "DamageResistance");
    }

    public void Mana_10_3_Text(){
        GetText(Mana_10_3, "Mana_10_3", TextName: "More_Mana", Price1: 2, Price2: 2, Price3: 2, Price4: 2, Price5: 3, HasCheck: false);
    }

    public void Mana_10_3_Upgrade(){
        Upgrade(Mana_10_3, "Mana_10_3", Price1: 2, Price2: 2, Price3: 2, Price4: 2, Price5: 3, Invoke1: "Mana", SetInteractable1: Mana_20_1, CheckVal1: 3, SetInteractable2: Mana_2Perc_2, CheckVal2: 4);
    }

    public void ManaUsage_1Perc_2_Text(){
        GetText(ManaUsage_1Perc_2, "ManaUsage_1Perc_2", TextName: "Cheaper_Spells", Price1: 1, Price2: 1, Price3: 1, Price4: 2, Price5: 2, Format1: 1, HasCheck: false);
    }

    public void ManaUsage_1Perc_2_Upgrade(){
        Upgrade(ManaUsage_1Perc_2, "ManaUsage_1Perc_2", Price1: 1, Price2: 1, Price3: 1, Price4: 2, Price5: 2, Invoke1: "ManaCost");
    }

    public void Mana_2Perc_2_Text(){
        GetText(Mana_2Perc_2, "Mana_2Perc_2", TextName: "Even_More_Mana", Price1: 2, Price2: 2, Price3: 3, Price4: 3, Price5: 4, Format1: 2, HasCheck: false);
    }

    public void Mana_2Perc_2_Upgrade(){
        Upgrade(Mana_2Perc_2, "Mana_2Perc_2", Price1: 2, Price2: 2, Price3: 3, Price4: 3, Price5: 4, Invoke1: "ManaModifier", SetInteractable1: ManaUsage_3Perc_1, CheckVal1: 5, SetInteractable2: HP_10_1, CheckVal2: 2);
    }

    public void Mana_20_1_Text(){
        GetText(Mana_20_1, "Mana_20_1", TextName: "A_Lot_Of_Mana", Price1: 3, Price2: 4, Price3: 4, Price4: 4, Price5: 5, HasCheck: false);
    }

    public void Mana_20_1_Upgrade(){
        Upgrade(Mana_20_1, "Mana_20_1", Price1: 3, Price2: 4, Price3: 4, Price4: 4, Price5: 5, Invoke1: "Mana", SetInteractable1: ManaUsage_1Perc_3, CheckVal1: 2, SetInteractable2: Mana_3Perc_1, CheckVal2: 4);
    }

    public void ManaUsage_1Perc_3_Text(){
        GetText(ManaUsage_1Perc_3, "ManaUsage_1Perc_3", TextName: "Cheaper_Spells", Price1: 1, Price2: 1, Price3: 2, Price4: 2, Price5: 2, Format1: 1, HasCheck: false);
    }

    public void ManaUsage_1Perc_3_Upgrade(){
        Upgrade(ManaUsage_1Perc_3, "ManaUsage_1Perc_3", Price1: 1, Price2: 1, Price3: 2, Price4: 2, Price5: 2, Invoke1: "ManaCost");
    }

    public void Mana_3Perc_1_Text(){
        GetText(Mana_3Perc_1, "Mana_3Perc_1", TextName: "Even_More_Mana", Price1: 3, Price2: 3, Price3: 4, Price4: 4, Price5: 4, Format1: 3, HasCheck: false);
    }

    public void Mana_3Perc_1_Upgrade(){
        Upgrade(Mana_3Perc_1, "Mana_3Perc_1", Price1: 3, Price2: 3, Price3: 4, Price4: 4, Price5: 4, Invoke1: "ManaModifier", SetInteractable1: Mana_2Perc_3, CheckVal1: 3);
    }

    public void Mana_2Perc_3_Text(){
        GetText(Mana_2Perc_3, "Mana_2Perc_3", TextName: "Even_More_Mana", Price1: 2, Price2: 2, Price3: 3, Price4: 3, Price5: 4, Format1: 2, HasCheck: false);
    }

    public void Mana_2Perc_3_Upgrade(){
        Upgrade(Mana_2Perc_3, "Mana_2Perc_3", Price1: 2, Price2: 2, Price3: 3, Price4: 3, Price5: 4, Invoke1: "ManaModifier");
    }

    public void ManaUsage_3Perc_1_Text(){
        GetText(ManaUsage_3Perc_1, "ManaUsage_3Perc_1", TextName: "Cheaper_Spells", Price1: 3, Price2: 3, Price3: 4, Price4: 4, Price5: 4, Format1: 3, HasCheck: false);
    }

    public void ManaUsage_3Perc_1_Upgrade(){
        Upgrade(ManaUsage_3Perc_1, "ManaUsage_3Perc_1", Price1: 3, Price2: 3, Price3: 4, Price4: 4, Price5: 4, Invoke1: "ManaCost");
    }

    public void HP_10_1_Text(){
        GetText(HP_10_1, "HP_10_1", TextName: "Additional_Health", Price1: 2, Price2: 2, Price3: 2, Price4: 2, Price5: 2, Format1: 10, HasCheck: false);
    }

    public void HP_10_1_Upgrade(){
        Upgrade(HP_10_1, "HP_10_1", Price1: 2, Price2: 2, Price3: 2, Price4: 2, Price5: 2, Invoke1: "Health");
    }

    public void ManaUsage_1Perc_4_Text(){
        GetText(ManaUsage_1Perc_4, "ManaUsage_1Perc_4", TextName: "Cheaper_Spells", Price1: 1, Price2: 1, Price3: 1, Price4: 2, Price5: 2, Format1: 1, HasCheck: false);
    }

    public void ManaUsage_1Perc_4_Upgrade(){
        Upgrade(ManaUsage_1Perc_4, "ManaUsage_1Perc_4", Price1: 1, Price2: 1, Price3: 1, Price4: 2, Price5: 2, Invoke1: "ManaCost");
    }

    public void MR_2_2_Text(){
        GetText(MR_2_2, "MR_2_2", TextName: "Mana_Regeneration", Price1: 3, Price2: 3, Price3: 3, Price4: 4, Price5: 4, Format1: 2, HasCheck: false);
    }

    public void MR_2_2_Upgrade(){
        Upgrade(MR_2_2, "MR_2_2", Price1: 3, Price2: 3, Price3: 3, Price4: 4, Price5: 4, Invoke1: "ManaRegen", SetInteractable1: HP_10_2, CheckVal1: 2, SetInteractable2: MR_3_1, CheckVal2: 3);
    }

    public void HP_10_2_Text(){
        GetText(HP_10_2, "HP_10_2", TextName: "Additional_Health", Price1: 2, Price2: 2, Price3: 2, Price4: 2, Price5: 2, Format1: 10, HasCheck: false);
    }

    public void HP_10_2_Upgrade(){
        Upgrade(HP_10_2, "HP_10_2", Price1: 2, Price2: 2, Price3: 2, Price4: 2, Price5: 2, Invoke1: "Health");
    }

    public void MR_3_1_Text(){
        GetText(MR_3_1, "MR_3_1", TextName: "Mana_Regeneration", Price1: 4, Price2: 5, Price3: 5, Price4: 5, Price5: 5, Format1: 3, HasCheck: false);
    }

    public void MR_3_1_Upgrade(){
        Upgrade(MR_3_1, "MR_3_1", Price1: 4, Price2: 5, Price3: 5, Price4: 5, Price5: 5, Invoke1: "ManaRegen", SetInteractable1: MR_3_2, CheckVal1: 3, SetInteractable2: ManaUsage_3Perc_2, CheckVal2: 4);
    }

    public void MR_3_2_Text(){
        GetText(MR_3_2, "MR_3_2", TextName: "Mana_Regeneration", Price1: 4, Price2: 5, Price3: 5, Price4: 5, Price5: 6, Format1: 3, HasCheck: false);
    }

    public void MR_3_2_Upgrade(){
        Upgrade(MR_3_2, "MR_3_2", Price1: 4, Price2: 5, Price3: 5, Price4: 5, Price5: 6, Invoke1: "ManaRegen", SetInteractable1: HP_10_3, CheckVal1: 2);
    }

    public void HP_10_3_Text(){
        GetText(HP_10_3, "HP_10_3", TextName: "Additional_Health", Price1: 2, Price2: 2, Price3: 2, Price4: 2, Price5: 2, Format1: 10, HasCheck: false);
    }

    public void HP_10_3_Upgrade(){
        Upgrade(HP_10_3, "HP_10_3", Price1: 2, Price2: 2, Price3: 2, Price4: 2, Price5: 2, Invoke1: "Health");
    }

    public void ManaUsage_3Perc_2_Text(){
        GetText(ManaUsage_3Perc_2, "ManaUsage_3Perc_2", TextName: "Cheaper_Spells", Price1: 3, Price2: 3, Price3: 3, Price4: 4, Price5: 4, Format1: 3, HasCheck: false);
    }

    public void ManaUsage_3Perc_2_Upgrade(){
        Upgrade(ManaUsage_3Perc_2, "ManaUsage_3Perc_2", Price1: 3, Price2: 3, Price3: 3, Price4: 4, Price5: 4, Invoke1: "ManaCost", SetInteractable1: HP_15_1, CheckVal1: 1, SetInteractable2: MR_3_3, CheckVal2: 3);
    }

    public void MR_3_3_Text(){
        GetText(MR_3_3, "MR_3_3", TextName: "Mana_Regeneration", Price1: 4, Price2: 5, Price3: 5, Price4: 5, Price5: 6, Format1: 3, HasCheck: false);
    }

    public void MR_3_3_Upgrade(){
        Upgrade(MR_3_3, "MR_3_3", Price1: 4, Price2: 5, Price3: 5, Price4: 5, Price5: 6, Invoke1: "ManaRegen");
        if(SkillManager.HP_15_1_Sorcery>0)DMG_Resistance_1_2.GetComponent<Button>().interactable = true;
    }

    public void HP_15_1_Text(){
        GetText(HP_15_1, "HP_15_1", TextName: "Additional_Health", Price1: 2, Price2: 3, Price3: 3, Price4: 3, Price5: 3, Format1: 15, HasCheck: false);
    }

    public void HP_15_1_Upgrade(){
        Upgrade(HP_15_1, "HP_15_1", Price1: 2, Price2: 3, Price3: 3, Price4: 3, Price5: 3, Invoke1: "Health");
        if(SkillManager.MR_3_3_Sorcery>0)DMG_Resistance_1_2.GetComponent<Button>().interactable = true;
    }

    public void DMG_Resistance_1_2_Text(){
        GetText(DMG_Resistance_1_2, "DMG_Resistance_1_2", TextName: "Damage_Resistance", Price1: 2, Price2: 2, Price3: 2, Price4: 3, Price5: 4, Format1: 1, HasCheck: false);
    }

    public void DMG_Resistance_1_2_Upgrade(){
        Upgrade(DMG_Resistance_1_2, "DMG_Resistance_1_2", Price1: 2, Price2: 2, Price3: 2, Price4: 3, Price5: 4, Invoke1: "DamageResistance");
    }

    private void BS_Mana_CheckUpgrade(){
        CheckUpgradeSingle(BS_Mana, "BS_Mana", Lvl: Convert.ToInt32(SkillManager.BS_Mana), CheckValLvl1: 25, CheckValLvl2: 70);
    }

    public void BS_Mana_Text(){
        int Format;
        switch(SkillManager.BS_Mana){
            case 0:
                Format = 40;
                break;
            default:
                Format = 30;
                break;
        }
        GetText(BS_Mana, "BS_Mana", TextName: "Beginner_Mana", MaxUpgradesCount: 2, Price1: 4, Price2: 5, Format1: Format, HasSuffix: false);
    }

    public void BS_Mana_Upgrade(){
        Upgrade(BS_Mana, "BS_Mana", MaxUpgradesCount: 2, Price1: 4, Price2: 5, HasSuffix: false);
    }

    private void BS_Damage_CheckUpgrade(){
        CheckUpgradeSingle(BS_Damage, "BS_Damage", Lvl: Convert.ToInt32(SkillManager.BS_Damage), CheckValLvl1: 20, CheckValLvl2: 35, CheckValLvl3: 45);
    }

    public void BS_Damage_Text(){
        int Format;
        switch(SkillManager.BS_Damage){
            case 0:
                Format = 20;
                break;
            case 1:
                Format = 30;
                break;
            default:
                Format = 50;
                break;
        }
        GetText(BS_Damage, "BS_Damage", TextName: "Beginner_Damage", MaxUpgradesCount: 3, Price1: 3, Price2: 4, Price3: 4, Format1: Format, HasSuffix: false);
    }

    public void BS_Damage_Upgrade(){
        Upgrade(BS_Damage, "BS_Damage", MaxUpgradesCount: 3, Price1: 3, Price2: 4, Price3: 4, HasSuffix: false);
    }

    private void BS_Cooldown_CheckUpgrade(){
        CheckUpgradeSingle(BS_Cooldown, "BS_Cooldown", Lvl: Convert.ToInt32(SkillManager.BS_Cooldown), CheckValLvl1: 30, CheckValLvl2: 50, CheckValLvl3: 75);
    }

    public void BS_Cooldown_Text(){
        int Format;
        switch(SkillManager.BS_Cooldown){
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
        GetText(BS_Cooldown, "BS_Cooldown", TextName: "Beginner_Cooldown", MaxUpgradesCount: 3, Price1: 3, Price2: 4, Price3: 5, Format1: Format, HasSuffix: false);
    }

    public void BS_Cooldown_Upgrade(){
        Upgrade(BS_Cooldown, "BS_Cooldown", MaxUpgradesCount: 3, Price1: 3, Price2: 4, Price3: 5, HasSuffix: false);
    }

    private void BS_Poison_AddDuration_CheckUpgrade(){
        CheckUpgradeSingle(BS_Poison_AddDuration, "BS_Poison_AddDuration", Lvl: Convert.ToInt32(SkillManager.BS_Poison_AddDuration), CheckValLvl1: 20);
    }

    public void BS_Poison_AddDuration_Text(){
        GetText(BS_Poison_AddDuration, "BS_Poison_AddDuration", TextName: "Deadlier_Poison", MaxUpgradesCount: 1, Price1: 3, HasSuffix: false);
    }

    public void BS_Poison_AddDuration_Upgrade(){
        Upgrade(BS_Poison_AddDuration, "BS_Poison_AddDuration", MaxUpgradesCount: 1, Price1: 3, HasSuffix: false, IsBool: true, SetInteractable1: BS_Weakness, CheckVal1: 1);
    }

    private void BS_Weakness_CheckUpgrade(){
        CheckUpgradeSingle(BS_Weakness, "BS_Weakness", Lvl: Convert.ToInt32(SkillManager.BS_Weakness), CheckValLvl1: 24, CheckValLvl2: 42);
    }

    public void BS_Weakness_Text(){
        string Format;
        switch(SkillManager.BS_Weakness){
            case 0:
                Format = "More_Effects";
                break;
            default:
                Format = "Stronger_Weakness";
                break;
        }
        GetText(BS_Weakness, "BS_Weakness", TextName: Format, MaxUpgradesCount: 2, Price1: 2, Price2: 3, HasSuffix: false);
    }

    public void BS_Weakness_Upgrade(){
        Upgrade(BS_Weakness, "BS_Weakness", MaxUpgradesCount: 2, Price1: 2, Price2: 3, HasSuffix: false);
    }

    private void CHU_CheckUpgrade(){
        CheckUpgradeSingle(CHU, "CHU", Lvl: Convert.ToInt32(SkillManager.CHU), CheckValLvl1: 60);
    }

    public void CHU_Text(){
        GetText(CHU, "CHU", TextName: "Chaos", MaxUpgradesCount: 1, Price1: 5, HasSuffix: false);
    }

    public void CHU_Upgrade(){
        Upgrade(CHU, "CHU", MaxUpgradesCount: 1, Price1: 5, HasSuffix: false, IsBool: true, SetInteractable1: CH_Cooldown, CheckVal1: 1, SetInteractable2: CH_Mana, CheckVal2: 1, SetInteractable3: CH_Damage, CheckVal3: 1);
        SkillManager.ActiveSkillsManager.SkillsUnlockCheck();
    }

    private void CH_Cooldown_CheckUpgrade(){
        CheckUpgradeSingle(CH_Cooldown, "CH_Cooldown", Lvl: Convert.ToInt32(SkillManager.CH_Cooldown), CheckValLvl1: 85, CheckValLvl2: 120);
    }

    public void CH_Cooldown_Text(){
        int Format;
        switch(SkillManager.CH_Cooldown){
            case 0:
                Format = 6;
                break;
            default:
                Format = 5;
                break;
        }
        GetText(CH_Cooldown, "CH_Cooldown", TextName: "Chaos_Cooldown", MaxUpgradesCount: 2, Price1: 4, Price2: 5, Format1: Format, HasSuffix: false);
    }

    public void CH_Cooldown_Upgrade(){
        Upgrade(CH_Cooldown, "CH_Cooldown", MaxUpgradesCount: 2, Price1: 4, Price2: 5, HasSuffix: false);
    }

    private void CH_Mana_CheckUpgrade(){
        CheckUpgradeSingle(CH_Mana, "CH_Mana", Lvl: Convert.ToInt32(SkillManager.CH_Mana), CheckValLvl1: 70, CheckValLvl2: 90, CheckValLvl3: 110);
    }

    public void CH_Mana_Text(){
        int Format;
        switch(SkillManager.CH_Mana){
            case 0:
                Format = 220;
                break;
            case 1:
                Format = 180;
                break;
            default:
                Format = 150;
                break;
        }
        GetText(CH_Mana, "CH_Mana", TextName: "Chaos_Mana", MaxUpgradesCount: 3, Price1: 4, Price2: 4, Price3: 6, Format1: Format, HasSuffix: false);
    }

    public void CH_Mana_Upgrade(){
        Upgrade(CH_Mana, "CH_Mana", MaxUpgradesCount: 3, Price1: 4, Price2: 4, Price3: 6, HasSuffix: false);
    }


    private void CH_Damage_CheckUpgrade(){
        CheckUpgradeSingle(CH_Damage, "CH_Damage", Lvl: Convert.ToInt32(SkillManager.CH_Damage), CheckValLvl1: 65, CheckValLvl2: 72, CheckValLvl3: 80);
    }

    public void CH_Damage_Text(){
        int Format;
        switch(SkillManager.CH_Damage){
            case 0:
                Format = 2;
                break;
            default:
                Format = 5;
                break;
        }
        GetText(CH_Damage, "CH_Damage", TextName: "Chaos_Damage", MaxUpgradesCount: 2, Price1: 3, Price2: 5, Format1: Format, HasSuffix: false);
    }

    public void CH_Damage_Upgrade(){
        Upgrade(CH_Damage, "CH_Damage", MaxUpgradesCount: 2, Price1: 3, Price2: 5, HasSuffix: false, SetInteractable1: CH_Effect, CheckVal1: 2);
    }

    private void CH_Effect_CheckUpgrade(){
        CheckUpgradeSingle(CH_Effect, "CH_Effect", Lvl: Convert.ToInt32(SkillManager.CH_Effect), CheckValLvl1: 85);
    }

    public void CH_Effect_Text(){
        GetText(CH_Effect, "CH_Effect", TextName: "Chaos_Effect", MaxUpgradesCount: 1, Price1: 6, HasSuffix: false);
    }

    public void CH_Effect_Upgrade(){
        Upgrade(CH_Effect, "CH_Effect", MaxUpgradesCount: 1, Price1: 6, HasSuffix: false, IsBool: true, SetInteractable1: VU, CheckVal1: 1, SetInteractable2: CH_Effect_EVChance, CheckVal2: 1, SetInteractable3: CH_Effect_Damage, CheckVal3: 1, SetInteractable4: CH_Effect_Duration, CheckVal4: 1);
    }

    private void CH_Effect_EVChance_CheckUpgrade(){
        CheckUpgradeSingle(CH_Effect_EVChance, "CH_Effect_EVChance", Lvl: Convert.ToInt32(SkillManager.CH_Effect_EVChance), CheckValLvl1: 95, CheckValLvl2: 120);
    }

    public void CH_Effect_EVChance_Text(){
        int Format;
        switch(SkillManager.CH_Effect_EVChance){
            case 0:
                Format = 7;
                break;
            default:
                Format = 5;
                break;
        }
        GetText(CH_Effect_EVChance, "CH_Effect_EVChance", TextName: "Chaos_Effect_Avoid_Chance", MaxUpgradesCount: 2, Price1: 5, Price2: 5, Format1: Format, HasSuffix: false);
    }

    public void CH_Effect_EVChance_Upgrade(){
        Upgrade(CH_Effect_EVChance, "CH_Effect_EVChance", MaxUpgradesCount: 2, Price1: 5, Price2: 5, HasSuffix: false);
    }

    private void CH_Effect_Damage_CheckUpgrade(){
        CheckUpgradeSingle(CH_Effect_Damage, "CH_Effect_Damage", Lvl: Convert.ToInt32(SkillManager.CH_Effect_Damage), CheckValLvl1: 90, CheckValLvl2: 130);
    }

    public void CH_Effect_Damage_Text(){
        string Format;
        switch(SkillManager.CH_Effect_Damage){
            case 0:
                Format = "1";
                break;
            default:
                Format = "1.5";
                break;
        }
        GetText(CH_Effect_Damage, "CH_Effect_Damage", TextName: "Chaos_Effect_Damage", MaxUpgradesCount: 2, Price1: 4, Price2: 5, StringFormat: Format, HasSuffix: false);
    }

    public void CH_Effect_Damage_Upgrade(){
        Upgrade(CH_Effect_Damage, "CH_Effect_Damage", MaxUpgradesCount: 2, Price1: 4, Price2: 5, HasSuffix: false);
    }

    private void CH_Effect_Duration_CheckUpgrade(){
        CheckUpgradeSingle(CH_Effect_Duration, "CH_Effect_Duration", Lvl: Convert.ToInt32(SkillManager.CH_Effect_Duration), CheckValLvl1: 98, CheckValLvl2: 128);
    }

    public void CH_Effect_Duration_Text(){
        string Format;
        switch(SkillManager.CH_Effect_Duration){
            case 0:
                Format = "2-6";
                break;
            default:
                Format = "4-8";
                break;
        }
        GetText(CH_Effect_Duration, "CH_Effect_Duration", TextName: "Chaos_Effect_Duration", MaxUpgradesCount: 2, Price1: 4, Price2: 5, StringFormat: Format, HasSuffix: false);
    }

    public void CH_Effect_Duration_Upgrade(){
        Upgrade(CH_Effect_Duration, "CH_Effect_Duration", MaxUpgradesCount: 2, Price1: 4, Price2: 5, HasSuffix: false);
    }

    private void VU_CheckUpgrade(){
        CheckUpgradeSingle(VU, "VU", Lvl: Convert.ToInt32(SkillManager.VU), CheckValLvl1: 100);
    }

    public void VU_Text(){
        GetText(VU, "VU", TextName: "Vampirism", MaxUpgradesCount: 1, Price1: 6, HasSuffix: false);
    }

    public void VU_Upgrade(){
        Upgrade(VU, "VU", MaxUpgradesCount: 1, Price1: 6, HasSuffix: false, IsBool: true, SetInteractable1: V_Mana, CheckVal1: 1, SetInteractable2: V_EffectHeal, CheckVal2: 1, SetInteractable3: V_Damage, CheckVal3: 1, SetInteractable4: V_Heal, CheckVal4: 1);
        SkillManager.ActiveSkillsManager.SkillsUnlockCheck();
    }

    private void V_Mana_CheckUpgrade(){
        CheckUpgradeSingle(V_Mana, "V_Mana", Lvl: Convert.ToInt32(SkillManager.V_Mana), CheckValLvl1: 120, CheckValLvl2: 165);
    }

    public void V_Mana_Text(){
        int Format;
        switch(SkillManager.V_Mana){
            case 0:
                Format = 130;
                break;
            default:
                Format = 100;
                break;
        }
        GetText(V_Mana, "V_Mana", TextName: "Vampirism_Mana", MaxUpgradesCount: 2, Price1: 4, Price2: 5, Format1: Format, HasSuffix: false);
    }

    public void V_Mana_Upgrade(){
        Upgrade(V_Mana, "V_Mana", MaxUpgradesCount: 2, Price1: 4, Price2: 5, HasSuffix: false);
    }

    private void V_EffectHeal_CheckUpgrade(){
        CheckUpgradeSingle(V_EffectHeal, "V_EffectHeal", Lvl: Convert.ToInt32(SkillManager.V_EffectHeal), CheckValLvl1: 135, CheckValLvl2: 170);
    }

    public void V_EffectHeal_Text(){
        int Format;
        switch(SkillManager.V_EffectHeal){
            case 0:
                Format = 2;
                break;
            default:
                Format = 5;
                break;
        }
        GetText(V_EffectHeal, "V_EffectHeal", TextName: "Vampirism_Effect_Heal", MaxUpgradesCount: 2, Price1: 6, Price2: 7, Format1: Format, HasSuffix: false);
    }

    public void V_EffectHeal_Upgrade(){
        Upgrade(V_EffectHeal, "V_EffectHeal", MaxUpgradesCount: 2, Price1: 6, Price2: 7, HasSuffix: false);
    }

    private void V_Damage_CheckUpgrade(){
        CheckUpgradeSingle(V_Damage, "V_Damage", Lvl: Convert.ToInt32(SkillManager.V_Damage), CheckValLvl1: 110, CheckValLvl2: 130, CheckValLvl3: 155);
    }

    public void V_Damage_Text(){
        int Format;
        switch(SkillManager.V_Damage){
            case 0:
                Format = 300;
                break;
            case 1:
                Format = 400;
                break;
            default:
                Format = 600;
                break;
        }
        GetText(V_Damage, "V_Damage", TextName: "Vampirism_Damage", MaxUpgradesCount: 3, Price1: 5, Price2: 6, Price3: 7, Format1: Format, HasSuffix: false);
    }

    public void V_Damage_Upgrade(){
        Upgrade(V_Damage, "V_Damage", MaxUpgradesCount: 3, Price1: 5, Price2: 6, Price3: 7, HasSuffix: false);

    }

    private void V_Heal_CheckUpgrade(){
        CheckUpgradeSingle(V_Heal, "V_Heal", Lvl: Convert.ToInt32(SkillManager.V_Heal), CheckValLvl1: 120, CheckValLvl2: 140, CheckValLvl3: 157);
    }

    public void V_Heal_Text(){
        int Format;
        switch(SkillManager.V_Heal){
            case 0:
                Format = 15;
                break;
            case 1:
                Format = 20;
                break;
            default:
                Format = 30;
                break;
        }
        GetText(V_Heal, "V_Heal", TextName: "Vampirism_Heal", MaxUpgradesCount: 3, Price1: 4, Price2: 5, Price3: 7, Format1: Format, HasSuffix: false);
    }

    public void V_Heal_Upgrade(){
        Upgrade(V_Heal, "V_Heal", MaxUpgradesCount: 3, Price1: 4, Price2: 5, Price3: 7, HasSuffix: false);

    }

    private void BS_NoEvasion_CheckUpgrade(){
        CheckUpgradeSingle(BS_NoEvasion, "BS_NoEvasion", Lvl: Convert.ToInt32(SkillManager.BS_NoEvasion), CheckValLvl1: 14);
    }

    public void BS_NoEvasion_Text(){
        GetText(BS_NoEvasion, "BS_NoEvasion", TextName: "Perfect_Accuracy", MaxUpgradesCount: 1, Price1: 1, HasCheck: true, HasSuffix: false);
    }

    public void BS_NoEvasion_Upgrade(){
        Upgrade(BS_NoEvasion, "BS_NoEvasion", MaxUpgradesCount: 1, Price1: 1, HasSuffix: false, IsBool: true, SetInteractable1: BS_Cooldown, CheckVal1: 1, SetInteractable2: BS_Poison_AddDuration, CheckVal2: 1, SetInteractable3: CHU, CheckVal3: 1);
    }

}

