using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sorcery : SkillTreeSegment
{
    public GameObject PracticePlus, BSU, MR_1_1, Mana_10_1, ManaOverdrain, ManaOverdrain_Perc, ManaOverdrain_Potion, Shield_MagicDef_2Perc_1, Shield_MagicDef_2Perc_2, Shield_DmgReturn_1Perc_1, Shield_DmgReturn_1Perc_2, Mana_10_2, Mana_1Perc_1, Mana_2Perc_1, HP_5_1, MR_1_2, ManaUsage_1Perc_1, MR_2_1, DMG_Resistance_1_1, Mana_10_3, ManaUsage_1Perc_2, Mana_2Perc_2, Mana_20_1, ManaUsage_1Perc_3, Mana_3Perc_1, Mana_2Perc_3, ManaUsage_3Perc_1, HP_10_1, ManaUsage_1Perc_4, MR_2_2, HP_10_2, MR_3_1, MR_3_2, HP_10_3, ManaUsage_3Perc_2, MR_3_3, HP_15_1, DMG_Resistance_1_2, BS_Mana, BS_Damage, BS_Cooldown, BS_Poison_AddDuration, BS_Weakness, CHU, CH_Cooldown, CH_Mana, CH_Damage, CH_Effect, CH_Effect_EVChance, CH_Effect_Damage, CH_Effect_Duration, VU, V_Mana, V_EffectHeal, V_Damage, V_Heal;
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
        Upgrade(Object: PracticePlus, Name: "PracticePlus", Price1: SkillsUpgradeCost, Invoke1:"Mana", IsBool:false, MaxUpgradesCount: 25, HasSuffix: false);
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
    }

}

