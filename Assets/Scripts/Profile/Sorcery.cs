using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sorcery : SkillTreeSegment
{
    public GameObject PracticePlus, BSU, MR_1_1, Mana_10_1, ManaOverdrain_Unlock, ManaOverdrain_Perc, ManaOverdrain_Potion, Shield_MagicDef_2Perc_1, Shield_MagicDef_2Perc_2, Shield_DmgReturn_1Perc_1, Shield_DmgReturn_1Perc_2, Mana_10_2, Mana_1Perc_1, Mana_2Perc_1, HP_5_1, MR_1_2, ManaUsage_1Perc_1, MR_2_1, DMG_Resistance_1_1, Mana_10_3, ManaUsage_1Perc_2, Mana_2Perc_2, Mana_20_1, ManaUsage_1Perc_3, Mana_3Perc_1, Mana_2Perc_3, ManaUsage_3Perc_1, HP_10_1, ManaUsage_1Perc_4, MR_2_2, HP_10_2, MR_3_1, MR_3_2, HP_10_3, ManaUsage_3Perc_2, MR_3_3, HP_15_1, DMG_Resistance_1_2, BS_Mana, BS_Damage, BS_Cooldown, BS_Poison_AddDuration, BS_Weakness, CHU, CH_Cooldown, CH_Mana, CH_Damage, CH_Effect, CH_Effect_EVChance, CH_Effect_Damage, CH_Effect_Duration, VU, V_Mana, V_EffectHeal, V_Damage, V_Heal;
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
        GetText("PracticePlus", TextName: "Practice_Plus", Price1: SkillsUpgradeCost, HasCheck: false, MaxUpgradesCount: 25, HasSuffix: false);
    }

    public void PracticePlus_Upgrade(){
        Upgrade(Object: PracticePlus, Name: "Practice_Plus", Price1: SkillsUpgradeCost, Invoke1:"Mana", IsBool:false, MaxUpgradesCount: 25, HasSuffix: false);
        if(SkillManager.PracticePlus==1){
            SkillManager.Checklist_Add("BSU", "Sorcery");
            SkillManager.Checklist_Add("MR_1_1", "Sorcery");
            SkillManager.Checklist_Add("Mana_10_1", "Sorcery");
            SkillManager.Checklist_Add("ManaOverdrain_Unlock", "Sorcery");
        }
        SkillManager.CheckAll();
    }
}
