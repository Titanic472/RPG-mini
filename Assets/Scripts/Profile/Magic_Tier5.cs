using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class Magic_Tier5 : SkillTreeSegment
{
    public GameObject Mana_2Perc_2, CH_Ultimate_RandomDebuff, BS_Ultimate, ManaOverdrain_Potion_3, Mana_10_7, MR_2_4, Mana_20_7, MCost_1Perc_2, MR_2_6, EV_5_ACC_5_2, HP_20_1, HPRegen_10_1, DMG_Resistance_2_1, MCost_2Perc_2, V_Ultimate, Mana_20_5, V_Damage_3, V_Heal_3, V_EffectHeal_2, MR_2_5, V_Mana_2, Mana_20_6, EV_5_ACC_5_1, HPRegen_20_1, MCost_2Perc_3, HP_20_2, CH_Ultimate_HPPercent, CH_Effect_Damage_2, Mana_20_8, CH_Effect_Duration_2, CH_Mana_3, MR_2_7, CH_Effect_EVChance_2, DMG_Resistance_2_2, Mana_20_9, HPRegen_20_2;
    public bool CH_Ultimate_RandomDebuff_Checked, BS_Ultimate_Checked, ManaOverdrain_Potion_3_Checked, Mana_10_7_Checked, MR_2_4_Checked, Mana_20_7_Checked, MCost_1Perc_2_Checked, MR_2_6_Checked, EV_5_ACC_5_2_Checked, HP_20_1_Checked, MCost_2Perc_2_Checked, V_Ultimate_Checked, Mana_20_5_Checked, V_Damage_3_Checked, V_Heal_3_Checked, V_EffectHeal_2_Checked, MR_2_5_Checked, V_Mana_2_Checked, Mana_20_6_Checked, EV_5_ACC_5_1_Checked, MCost_2Perc_3_Checked, CH_Ultimate_HPPercent_Checked, CH_Effect_Damage_2_Checked, Mana_20_8_Checked, CH_Effect_Duration_2_Checked, CH_Mana_3_Checked, MR_2_7_Checked, CH_Effect_EVChance_2_Checked, DMG_Resistance_2_2_Checked, Mana_20_9_Checked;

    void Awake(){
        Class = "Magic_Tier5";
    }

    public void HP_20_2_Text(){
        GetText("HP_20_2", TextName: "Additional Health", DescriptionName: "HP 20 Description", Price: 2, HasCheck: false);
    }

    public void HP_20_2_Upgrade(){
        Upgrade(Object: HP_20_2, Name: "HP_20_2", Price: 2, Invoke1:"Health");

        MCost_2Perc_3.transform.Find("Button").GetComponent<Button>().interactable = true;
        SkillManager.Checklist_Add("MCost_2Perc_3","Magic_Tier5");
        Mana_20_8.transform.Find("Button").GetComponent<Button>().interactable = true;
        SkillManager.Checklist_Add("Mana_20_8","Magic_Tier5");
        CH_Effect_Damage_2.SetActive(true);
        MR_2_7.SetActive(true);
        CH_Effect_Duration_2.SetActive(true);
        SkillManager.CheckAll();
    }

    public void MCost_2Perc_3_Check(){
        Check(Object: MCost_2Perc_3, Name: "MCost_2Perc_3", SkillManager.Practice_Plus, 22);
    }

    public void MCost_2Perc_3_Text(){
        GetText("MCost_2Perc_3", TextName: "Cheaper Spells", Price: 6, Category: 'M', Req_C: 22, Format1: 2);
    }

    public void MCost_2Perc_3_Upgrade(){
        Upgrade(Object: MCost_2Perc_3, Name: "MCost_2Perc_3", Price: 6, Invoke1:"ManaCost");
    }

    public void CH_Ultimate_HPPercent_Check(){
        Check(Object: CH_Ultimate_HPPercent, Name: "CH_Ultimate_HPPercent", SkillManager.CH_Effect_Damage, 2, SkillManager.CH_Effect_Duration, 2, SkillManager.CH_Effect_EVChance, 2, SkillManager.CH_Mana, 3);
    }

    public void CH_Ultimate_HPPercent_Text(){
        GetText("CH_Ultimate_HPPercent", TextName: "Chaos Ultimate Percent", Price: 15, Req1: "Chaos Effect Avoid Chance", Req1Lvl: 2, Req2: "Chaos Effect Duration", Req2Lvl: 2, Req3: "Chaos Effect Damage", Req3Lvl: 2, Req4: "Chaos Mana", Req4Lvl: 3, HasSuffix: false);
    }

    public void CH_Ultimate_HPPercent_Upgrade(){
        Upgrade(Object: CH_Ultimate_HPPercent, Name: "CH_Ultimate_HPPercent", Price: 15, HasSuffix: false);
    }

    public void Mana_20_8_Check(){
        Check(Object: Mana_20_8, Name: "Mana_20_8", SkillManager.Practice_Plus, 22);
    }

    public void Mana_20_8_Text(){
        GetText("Mana_20_8", TextName: "A Lot Of Mana", Price: 6, Category: 'M', Req_C: 22);
    }

    public void Mana_20_8_Upgrade(){
        Upgrade(Object: Mana_20_8, Name: "Mana_20_8", Price: 6, Invoke1:"Mana");

        CH_Effect_Damage_2.transform.Find("Button").GetComponent<Button>().interactable = true;
        SkillManager.Checklist_Add("CH_Effect_Damage_2","Magic_Tier5");
        MR_2_7.transform.Find("Button").GetComponent<Button>().interactable = true;
        SkillManager.Checklist_Add("MR_2_7","Magic_Tier5");
        CH_Effect_Duration_2.transform.Find("Button").GetComponent<Button>().interactable = true;
        SkillManager.Checklist_Add("CH_Effect_Duration_2","Magic_Tier5");
        CH_Mana_3.SetActive(true);
        CH_Effect_EVChance_2.SetActive(true);
        DMG_Resistance_2_2.SetActive(true);
        Mana_20_9.SetActive(true);
	    SkillManager.CheckAll();
    }

    public void CH_Effect_Damage_2_Check(){
        Check(Object: CH_Effect_Damage_2, Name: "CH_Effect_Damage_2", SkillManager.Practice_Plus, 23, SkillManager.CH_Effect_Damage, 1);
    }

    public void CH_Effect_Damage_2_Text(){
        GetText("CH_Effect_Damage_2", SkillName: "CH_Effect_Damage", TextName: "Chaos Effect Damage", Price: 8, Category: 'M', Req_C: 23, UpgValue: 1, Format1: (float)1.5, Req1: "Chaos Effect Damage", Req1Lvl: 1, HasSuffix: false);
    }

    public void CH_Effect_Damage_2_Upgrade(){
        Upgrade(Object: CH_Effect_Damage_2, Name: "CH_Effect_Damage_2", SkillName: "CH_Effect_Damage", Price: 8, IsBool: false, HasSuffix: false);

        CH_Mana_3.transform.Find("Button").GetComponent<Button>().interactable = true;
        SkillManager.Checklist_Add("CH_Mana_3","Magic_Tier5");
        SkillManager.CheckAll();
    }

    public void CH_Mana_3_Check(){
        Check(Object: CH_Mana_3, Name: "CH_Mana_3", SkillManager.Practice_Plus, 24, SkillManager.CH_Mana, 2);
    }

    public void CH_Mana_3_Text(){
        GetText("CH_Mana_3", SkillName: "CH_Mana", TextName: "Chaos Mana", Price: 6, Category: 'M', Req_C: 24, UpgValue: 2, Format1: 150, Req1: "Chaos Mana", Req1Lvl: 2, HasSuffix: false);
    }

    public void CH_Mana_3_Upgrade(){
        Upgrade(Object: CH_Mana_3, Name: "CH_Mana_3", SkillName: "CH_Mana", Price: 6, IsBool: false, HasSuffix: false);

        if(SkillManager.MR_2_7_Magic_Tier5){
            DMG_Resistance_2_2.transform.Find("Button").GetComponent<Button>().interactable = true;
            SkillManager.Checklist_Add("DMG_Resistance_2_2","Magic_Tier5");
            HPRegen_20_2.SetActive(true);
        }
        SkillManager.CheckAll();
    }

    public void CH_Effect_EVChance_2_Check(){
        Check(Object: CH_Effect_EVChance_2, Name: "CH_Effect_EVChance_2", SkillManager.Practice_Plus, 24, SkillManager.CH_Effect_EVChance, 1);
    }

    public void CH_Effect_EVChance_2_Text(){
        GetText("CH_Effect_EVChance_2", SkillName: "CH_Effect_EVChance", TextName: "Chaos Effect Avoid Chance", Price: 8, Category: 'M', Req_C: 24, UpgValue: 1, Format1: 5, Req1: "Chaos Effect Avoid Chance", Req1Lvl: 1, HasSuffix: false);
    }

    public void CH_Effect_EVChance_2_Upgrade(){
        Upgrade(Object: CH_Effect_EVChance_2, Name: "CH_Effect_EVChance_2", SkillName: "CH_Effect_EVChance", Price: 8, IsBool: false, HasSuffix: false);

        if(SkillManager.MR_2_7_Magic_Tier5){
            Mana_20_9.transform.Find("Button").GetComponent<Button>().interactable = true;
            SkillManager.Checklist_Add("Mana_20_9","Magic_Tier5");
            HPRegen_20_2.SetActive(true);
        }
        SkillManager.CheckAll();
    }

    public void CH_Effect_Duration_2_Check(){
        Check(Object: CH_Effect_Duration_2, Name: "CH_Effect_Duration_2", SkillManager.Practice_Plus, 23, SkillManager.CH_Effect_Duration, 1);
    }

    public void CH_Effect_Duration_2_Text(){
        GetText("CH_Effect_Duration_2", SkillName: "CH_Effect_Duration", TextName: "Chaos Effect Duration", Price: 7, Category: 'M', Req_C: 23, UpgValue: 1, StringFormat: "4-8", Req1: "Chaos Effect Duration", Req1Lvl: 1, HasSuffix: false);
    }

    public void CH_Effect_Duration_2_Upgrade(){
        Upgrade(Object: CH_Effect_Duration_2, Name: "CH_Effect_Duration_2", SkillName: "CH_Effect_Duration", Price: 7, IsBool: false, HasSuffix: false);

        CH_Effect_EVChance_2.transform.Find("Button").GetComponent<Button>().interactable = true;
        SkillManager.Checklist_Add("CH_Effect_EVChance_2","Magic_Tier5");
        SkillManager.CheckAll();
    }

    public void DMG_Resistance_2_2_Check(){
        Check(Object: DMG_Resistance_2_2, Name: "DMG_Resistance_2_2", SkillManager.Practice_Plus, 25);
    }

    public void DMG_Resistance_2_2_Text(){
        GetText("DMG_Resistance_2_2", TextName: "Damage Resistance", Price: 4, Category: 'M', Req_C: 25, Format1: 2);
    }

    public void DMG_Resistance_2_2_Upgrade(){
        Upgrade(Object: DMG_Resistance_2_2, Name: "DMG_Resistance_2_2", Price: 4, Invoke1:"DamageResistance");

        if(SkillManager.Mana_20_9_Magic_Tier5){
            HPRegen_20_2.transform.Find("Button").GetComponent<Button>().interactable = true;
            HPRegen_20_2.transform.Find("Glowing_Yellow").gameObject.SetActive(true);
        }
    }

    public void Mana_20_9_Check(){
        Check(Object: Mana_20_9, Name: "Mana_20_9", SkillManager.Practice_Plus, 25);
    }

    public void Mana_20_9_Text(){
        GetText("Mana_20_9", TextName: "A Lot Of Mana", Price: 6, Category: 'M', Req_C: 25);
    }

    public void Mana_20_9_Upgrade(){
        Upgrade(Object: Mana_20_9, Name: "Mana_20_9", Price: 6, Invoke1:"Mana");

        if(SkillManager.DMG_Resistance_2_2_Magic_Tier5){
            HPRegen_20_2.transform.Find("Button").GetComponent<Button>().interactable = true;
            HPRegen_20_2.transform.Find("Glowing_Yellow").gameObject.SetActive(true);
        }
    }

    public void HPRegen_20_2_Text(){
        GetText("HPRegen_20_2", TextName: "Health Regeneration", Price: 15, Format1: 20, HasCheck: false);
    }

    public void HPRegen_20_2_Upgrade(){
        Upgrade(Object: HPRegen_20_2, Name: "HPRegen_20_2", Price: 15, Invoke1:"HealthRegen");
        }

    public void MR_2_7_Check(){
        Check(Object: MR_2_7, Name: "MR_2_7", SkillManager.Practice_Plus, 23);
    }

    public void MR_2_7_Text(){
        GetText("MR_2_7", TextName: "Mana Regeneration", Price: 6, Category: 'M', Req_C: 23, Format1: 2);
    }

    public void MR_2_7_Upgrade(){
        Upgrade(Object: MR_2_7, Name: "MR_2_7", Price: 6, Invoke1:"ManaRegen");

        if(SkillManager.CH_Mana==3){
            DMG_Resistance_2_2.transform.Find("Button").GetComponent<Button>().interactable = true;
            SkillManager.Checklist_Add("DMG_Resistance_2_2","Magic_Tier5");
            HPRegen_20_2.SetActive(true);
        }
        if(SkillManager.CH_Effect_EVChance==2){
            Mana_20_9.transform.Find("Button").GetComponent<Button>().interactable = true;
            SkillManager.Checklist_Add("Mana_20_9","Magic_Tier5");
            HPRegen_20_2.SetActive(true);
        }
        SkillManager.CheckAll();
    }

    public void Mana_2Perc_2_Text(){
        GetText("Mana_2Perc_2", TextName: "Even More Mana", Price: 2, Format1: 2, HasCheck: false);
    }

    public void Mana_2Perc_2_Upgrade(){
        Upgrade(Object: Mana_2Perc_2, Name: "Mana_2Perc_2", Price: 2, Invoke1:"ManaModifier");

        ManaOverdrain_Potion_3.transform.Find("Button").GetComponent<Button>().interactable = true;
        SkillManager.Checklist_Add("ManaOverdrain_Potion_3","Magic_Tier5");
        MR_2_4.SetActive(true);
        MCost_1Perc_2.SetActive(true);
        Mana_10_7.SetActive(true);
        SkillManager.CheckAll();
    }

    public void BS_Ultimate_Check(){
        Check(Object: BS_Ultimate, Name: "BS_Ultimate", Convert.ToInt32(SkillManager.BS_NoEvasion), 1, SkillManager.BS_Damage, 3);
    }

    public void BS_Ultimate_Text(){
        GetText("BS_Ultimate", TextName: "Ultimate Beginner", Price: 5, Req1: "Perfect Accuracy", Req2: "Beginner Damage", Req2Lvl: 3, NeedOtherUnlock: true, HasSuffix: false);
    }

    public void BS_Ultimate_Upgrade(){
        Upgrade(Object: BS_Ultimate, Name: "BS_Ultimate", Price: 5, HasSuffix: false);
    }

    public void CH_Ultimate_RandomDebuff_Check(){
        Check(Object: CH_Ultimate_RandomDebuff, Name: "CH_Ultimate_RandomDebuff", SkillManager.CH_Effect_Damage, 2, SkillManager.CH_Effect_Duration, 2, SkillManager.CH_Effect_EVChance, 2);
    }

    public void CH_Ultimate_RandomDebuff_Text(){
        GetText("CH_Ultimate_RandomDebuff", TextName: "Chaos Ultimate Random Debuff", Price: 10, Req1: "Chaos Effect Avoid Chance", Req1Lvl: 2, Req2: "Chaos Effect Duration", Req2Lvl: 2, Req3: "Chaos Effect Damage", Req3Lvl: 2, HasSuffix: false);
    }

    public void CH_Ultimate_RandomDebuff_Upgrade(){
        Upgrade(Object: CH_Ultimate_RandomDebuff, Name: "CH_Ultimate_RandomDebuff", Price: 10, HasSuffix: false);
    }

    public void ManaOverdrain_Potion_3_Check(){
        Check(Object: ManaOverdrain_Potion_3, Name: "ManaOverdrain_Potion_3", SkillManager.Practice_Plus, 22, SkillManager.ManaOverdrain_Potion, 2);
    }

    public void ManaOverdrain_Potion_3_Text(){
        GetText("ManaOverdrain_Potion_3", SkillName: "ManaOverdrain_Potion", TextName: "Mana Overdrain Potion", Price: 8, Category: 'M', Req_C: 22, UpgValue: 2, Format1: 3, Req1: "Mana Overdrain Potion", Req1Lvl: 2, HasSuffix: false);
    }

    public void ManaOverdrain_Potion_3_Upgrade(){
        Upgrade(Object: ManaOverdrain_Potion_3, Name: "ManaOverdrain_Potion_3", SkillName: "ManaOverdrain_Potion", Price: 8, IsBool: false, HasSuffix: false);

        MR_2_4.transform.Find("Button").GetComponent<Button>().interactable = true;
        MCost_1Perc_2.transform.Find("Button").GetComponent<Button>().interactable = true;
        Mana_10_7.transform.Find("Button").GetComponent<Button>().interactable = true;
        SkillManager.Checklist_Add("MR_2_4","Magic_Tier5");
        SkillManager.Checklist_Add("MCost_1Perc_2","Magic_Tier5");
        SkillManager.Checklist_Add("Mana_10_7","Magic_Tier5");
        Mana_20_7.SetActive(true);
        MR_2_6.SetActive(true);
        EV_5_ACC_5_2.SetActive(true);
        HP_20_1.SetActive(true);
        SkillManager.CheckAll();
    }

    public void MCost_1Perc_2_Check(){
        Check(Object: MCost_1Perc_2, Name: "MCost_1Perc_2", SkillManager.Practice_Plus, 23);
    }

    public void MCost_1Perc_2_Text(){
        GetText("MCost_1Perc_2", TextName: "Cheaper Spells", Price: 2, Category: 'M', Req_C: 23, Format1: 1);
    }

    public void MCost_1Perc_2_Upgrade(){
        Upgrade(Object: MCost_1Perc_2, Name: "MCost_1Perc_2", Price: 2, Invoke1:"ManaCost");

        if(SkillManager.Mana_20_7_Magic_Tier5){
            EV_5_ACC_5_2.transform.Find("Button").GetComponent<Button>().interactable = true;
            SkillManager.Checklist_Add("EV_5_ACC_5_2","Magic_Tier5");
            HPRegen_10_1.SetActive(true);
        }
        if(SkillManager.MR_2_6_Magic_Tier5){
            HP_20_1.transform.Find("Button").GetComponent<Button>().interactable = true;
            SkillManager.Checklist_Add("HP_20_1","Magic_Tier5");
            HPRegen_10_1.SetActive(true);
        }
        SkillManager.CheckAll();
    }
    
    public void MR_2_4_Check(){
        Check(Object: MR_2_4, Name: "MR_2_4", SkillManager.Practice_Plus, 23);
    }

    public void MR_2_4_Text(){
        GetText("MR_2_4", TextName: "Mana Regeneration", Price: 6, Category: 'M', Req_C: 23, Format1: 2);
    }

    public void MR_2_4_Upgrade(){
        Upgrade(Object: MR_2_4, Name: "MR_2_4", Price: 6, Invoke1:"ManaRegen");

        Mana_20_7.transform.Find("Button").GetComponent<Button>().interactable = true;
        SkillManager.Checklist_Add("Mana_20_7","Magic_Tier5");
        SkillManager.CheckAll();
    }

    public void Mana_20_7_Check(){
        Check(Object: Mana_20_7, Name: "Mana_20_7", SkillManager.Practice_Plus, 24);
    }

    public void Mana_20_7_Text(){
        GetText("Mana_20_7", TextName: "A Lot Of Mana", Price: 6, Category: 'M', Req_C: 24);
    }

    public void Mana_20_7_Upgrade(){
        Upgrade(Object: Mana_20_7, Name: "Mana_20_7", Price: 6, Invoke1:"Mana");

        if(SkillManager.MCost_1Perc_2_Magic_Tier5){
            EV_5_ACC_5_2.transform.Find("Button").GetComponent<Button>().interactable = true;
            SkillManager.Checklist_Add("EV_5_ACC_5_2","Magic_Tier5");
            HPRegen_10_1.SetActive(true);
        }
        SkillManager.CheckAll();
    }

    public void Mana_10_7_Check(){
        Check(Object: Mana_10_7, Name: "Mana_10_7", SkillManager.Practice_Plus, 23);
    }

    public void Mana_10_7_Text(){
        GetText("Mana_10_7", TextName: "More Mana", Price: 2, Category: 'M', Req_C: 23);
    }

    public void Mana_10_7_Upgrade(){
        Upgrade(Object: Mana_10_7, Name: "Mana_10_7", Price: 2, Invoke1:"Mana");

        MR_2_6.transform.Find("Button").GetComponent<Button>().interactable = true;
        SkillManager.Checklist_Add("MR_2_6","Magic_Tier5");
        SkillManager.CheckAll();
    }

    public void MR_2_6_Check(){
        Check(Object: MR_2_6, Name: "MR_2_6", SkillManager.Practice_Plus, 24);
    }

    public void MR_2_6_Text(){
        GetText("MR_2_6", TextName: "Mana Regeneration", Price: 5, Category: 'M', Req_C: 24, Format1: 2);
    }

    public void MR_2_6_Upgrade(){
        Upgrade(Object: MR_2_6, Name: "MR_2_6", Price: 5, Invoke1:"ManaRegen");

        if(SkillManager.MCost_1Perc_2_Magic_Tier5){
            HP_20_1.transform.Find("Button").GetComponent<Button>().interactable = true;
            SkillManager.Checklist_Add("HP_20_1","Magic_Tier5");
            HPRegen_10_1.SetActive(true);
        }
        SkillManager.CheckAll();
    }

    public void HP_20_1_Check(){
        Check(Object: HP_20_1, Name: "HP_20_1", SkillManager.Practice_Plus, 25);
    }

    public void HP_20_1_Text(){
        GetText("HP_20_1", TextName: "Additional Health", DescriptionName: "HP 20 Description", Price: 3, Category: 'M', Req_C: 25);
    }

    public void HP_20_1_Upgrade(){
        Upgrade(Object: HP_20_1, Name: "HP_20_1", Price: 3, Invoke1:"Health");

        if(SkillManager.EV_5_ACC_5_2_Magic_Tier5){
            HPRegen_10_1.transform.Find("Button").GetComponent<Button>().interactable = true;
            HPRegen_10_1.transform.Find("Glowing_Yellow").gameObject.SetActive(true);
        }
        SkillManager.Skilltree_Health();
    }

    public void EV_5_ACC_5_2_Check(){
        Check(Object: EV_5_ACC_5_2, Name: "EV_5_ACC_5_2", SkillManager.Practice_Plus, 25);
    }

    public void EV_5_ACC_5_2_Text(){
        GetText("EV_5_ACC_5_2", TextName: "Universal Set", Price: 3, Category: 'M', Req_C: 25, Format1: 5);
    }

    public void EV_5_ACC_5_2_Upgrade(){
        Upgrade(Object: EV_5_ACC_5_2, Name: "EV_5_ACC_5_2", Price: 3, Invoke1:"Evasion", Invoke2:"Accuracy");

        if(SkillManager.HP_20_1_Magic_Tier5){
            HPRegen_10_1.transform.Find("Button").GetComponent<Button>().interactable = true;
            HPRegen_10_1.transform.Find("Glowing_Yellow").gameObject.SetActive(true);
        }
        SkillManager.CheckAll();
    }

    public void HPRegen_10_1_Text(){
        GetText("HPRegen_10_1", TextName: "Health Regeneration", Price: 10, Format1: 10, HasCheck: false);
    }

    public void HPRegen_10_1_Upgrade(){
        Upgrade(Object: HPRegen_10_1, Name: "HPRegen_10_1", Price: 10, Invoke1:"HealthRegen");
    }

    public void DMG_Resistance_2_1_Text(){
        GetText("DMG_Resistance_2_1", TextName: "Damage Resistance", Price: 4, Format1: 2, HasCheck: false);
    }

    public void DMG_Resistance_2_1_Upgrade(){
        Upgrade(Object: DMG_Resistance_2_1, Name: "DMG_Resistance_2_1", Price: 4, Invoke1:"DamageResistance");

        MCost_2Perc_2.transform.Find("Button").GetComponent<Button>().interactable = true;
        SkillManager.Checklist_Add("MCost_2Perc_2","Magic_Tier5");
        Mana_20_5.transform.Find("Button").GetComponent<Button>().interactable = true;
        SkillManager.Checklist_Add("Mana_20_5","Magic_Tier5");
        V_Damage_3.SetActive(true);
        V_Heal_3.SetActive(true);
        MR_2_5.SetActive(true);
        SkillManager.CheckAll();
    }

    public void MCost_2Perc_2_Check(){
        Check(Object: MCost_2Perc_2, Name: "MCost_2Perc_2", SkillManager.Practice_Plus, 22);
    }

    public void MCost_2Perc_2_Text(){
        GetText("MCost_2Perc_2", TextName: "Cheaper Spells", Price: 6, Category: 'M', Req_C: 22, Format1: 2);
    }

    public void MCost_2Perc_2_Upgrade(){
        Upgrade(Object: MCost_2Perc_2, Name: "MCost_2Perc_2", Price: 6, Invoke1:"ManaCost");
    }

    public void V_Ultimate_Check(){
        Check(Object: V_Ultimate, Name: "V_Ultimate", SkillManager.V_Damage, 3,  SkillManager.V_EffectHeal, 2,  SkillManager.V_Heal, 3,  SkillManager.V_Mana, 2);
    }

    public void V_Ultimate_Text(){
        GetText("V_Ultimate", TextName: "Ultimate Vampirism", Price: 10, Req1: "Vampirism Damage", Req1Lvl: 3, Req2: "Vampirism Heal", Req2Lvl: 3, Req3: "Vampirism Mana", Req3Lvl: 2, Req4: "Vampirism Effect Heal", Req4Lvl: 2, HasSuffix: false);
    }

    public void V_Ultimate_Upgrade(){
        Upgrade(Object: V_Ultimate, Name: "V_Ultimate", Price: 10, HasSuffix: false);
    }

    public void Mana_20_5_Check(){
        Check(Object: Mana_20_5, Name: "Mana_20_5", SkillManager.Practice_Plus, 22);
    }

    public void Mana_20_5_Text(){
        GetText("Mana_20_5", TextName: "A Lot Of Mana", Price: 7, Category: 'M', Req_C: 22);
    }

    public void Mana_20_5_Upgrade(){
        Upgrade(Object: Mana_20_5, Name: "Mana_20_5", Price: 7, Invoke1:"Mana");

        V_Damage_3.transform.Find("Button").GetComponent<Button>().interactable = true;
        V_Heal_3.transform.Find("Button").GetComponent<Button>().interactable = true;
        MR_2_5.transform.Find("Button").GetComponent<Button>().interactable = true;
        SkillManager.Checklist_Add("V_Damage_3","Magic_Tier5");
        SkillManager.Checklist_Add("V_Heal_3","Magic_Tier5");
        SkillManager.Checklist_Add("MR_2_5","Magic_Tier5");
        V_EffectHeal_2.SetActive(true);
        EV_5_ACC_5_1.SetActive(true);
        Mana_20_6.SetActive(true);
        V_Mana_2.SetActive(true);
        SkillManager.CheckAll();
    }

    public void MR_2_5_Check(){
        Check(Object: MR_2_5, Name: "MR_2_5", SkillManager.Practice_Plus, 23);
    }

    public void MR_2_5_Text(){
        GetText("MR_2_5", TextName: "Mana Regeneration", Price: 6, Category: 'M', Req_C: 23, Format1: 2);
    }

    public void MR_2_5_Upgrade(){
        Upgrade(Object: MR_2_5, Name: "MR_2_5", Price: 6, Invoke1:"ManaRegen");

        if(SkillManager.V_EffectHeal==2){
            EV_5_ACC_5_1.transform.Find("Button").GetComponent<Button>().interactable = true;
            SkillManager.Checklist_Add("EV_5_ACC_5_1","Magic_Tier5");
            HPRegen_20_1.SetActive(true);
        }
        if(SkillManager.V_Mana==2){
            Mana_20_6.transform.Find("Button").GetComponent<Button>().interactable = true;
            SkillManager.Checklist_Add("Mana_20_6","Magic_Tier5");
            HPRegen_20_1.SetActive(true);
        }
        SkillManager.CheckAll();
    }

    public void V_Damage_3_Check(){
        Check(Object: V_Damage_3, Name: "V_Damage_3", SkillManager.Practice_Plus, 23, SkillManager.V_Damage, 2);
    }

    public void V_Damage_3_Text(){
        GetText("V_Damage_3", SkillName: "V_Damage", TextName: "Vampirism Damage", Price: 7, Category: 'M', Req_C: 23, UpgValue: 2, Format1: 600, Req1: "Vampirism Damage", Req1Lvl: 2, HasSuffix: false);
    }

    public void V_Damage_3_Upgrade(){
        Upgrade(Object: V_Damage_3, Name: "V_Damage_3", SkillName: "V_Damage", Price: 7, IsBool: false, HasSuffix: false);
        
        V_EffectHeal_2.transform.Find("Button").GetComponent<Button>().interactable = true;
        SkillManager.Checklist_Add("V_EffectHeal_2","Magic_Tier5");
        SkillManager.CheckAll();
    }

    public void V_EffectHeal_2_Check(){
        Check(Object: V_EffectHeal_2, Name: "V_EffectHeal_2", SkillManager.Practice_Plus, 24, SkillManager.V_EffectHeal, 1);
    }

    public void V_EffectHeal_2_Text(){
        GetText("V_EffectHeal_2", SkillName: "V_EffectHeal", TextName: "Vampirism Effect Heal", Price: 5, Category: 'M', Req_C: 24, UpgValue: 1, Format1: 5, Req1: "Vampirism Effect Heal", Req1Lvl: 1, HasSuffix: false);
    }

    public void V_EffectHeal_2_Upgrade(){
        Upgrade(Object: V_EffectHeal_2, Name: "V_EffectHeal_2", SkillName: "V_EffectHeal", Price: 5, IsBool: false, HasSuffix: false);

        if(SkillManager.MR_2_5_Magic_Tier5){
            EV_5_ACC_5_1.transform.Find("Button").GetComponent<Button>().interactable = true;
            SkillManager.Checklist_Add("EV_5_ACC_5_1","Magic_Tier5");
            HPRegen_20_1.SetActive(true);
        }
        SkillManager.CheckAll();
    }

    public void V_Heal_3_Check(){
        Check(Object: V_Heal_3, Name: "V_Heal_3", SkillManager.Practice_Plus, 23, SkillManager.V_Heal, 2);
    }

    public void V_Heal_3_Text(){
        GetText("V_Heal_3", SkillName: "V_Heal", TextName: "Vampirism Heal", Price: 8, Category: 'M', Req_C: 23, UpgValue: 2, Format1: 30, Req1: "Vampirism Heal", Req1Lvl: 2, HasSuffix: false);
    }

    public void V_Heal_3_Upgrade(){
        Upgrade(Object: V_Heal_3, Name: "V_Heal_3", SkillName: "V_Heal", Price: 8, IsBool: false, HasSuffix: false);
        
        V_Mana_2.transform.Find("Button").GetComponent<Button>().interactable = true;
        SkillManager.Checklist_Add("V_Mana_2","Magic_Tier5");
        SkillManager.CheckAll();
    }

    public void V_Mana_2_Check(){
        Check(Object: V_Mana_2, Name: "V_Mana_2", SkillManager.Practice_Plus, 24, SkillManager.V_Mana, 1);
    }

    public void V_Mana_2_Text(){
        GetText("V_Mana_2", SkillName: "V_Mana", TextName: "Vampirism Mana", Price: 6, Category: 'M', Req_C: 24, UpgValue: 1, Format1: 100, Req1: "Vampirism Mana", Req1Lvl: 1, HasSuffix: false);
    }

    public void V_Mana_2_Upgrade(){
        Upgrade(Object: V_Mana_2, Name: "V_Mana_2", SkillName: "V_Mana", Price: 6, IsBool: false, HasSuffix: false);

        if(SkillManager.MR_2_5_Magic_Tier5){
            Mana_20_6.transform.Find("Button").GetComponent<Button>().interactable = true;
            SkillManager.Checklist_Add("Mana_20_6","Magic_Tier5");
            HPRegen_20_1.SetActive(true);
        }
        SkillManager.CheckAll();
    }

    public void EV_5_ACC_5_1_Check(){
        Check(Object: EV_5_ACC_5_1, Name: "EV_5_ACC_5_1", SkillManager.Practice_Plus, 25);
    }

    public void EV_5_ACC_5_1_Text(){
        GetText("EV_5_ACC_5_1", TextName: "Universal Set", Price: 3, Category: 'M', Req_C: 25, Format1: 5);
    }

    public void EV_5_ACC_5_1_Upgrade(){
        Upgrade(Object: EV_5_ACC_5_1, Name: "EV_5_ACC_5_1", Price: 3, Invoke1:"Evasion", Invoke2:"Accuracy");

        if(SkillManager.Mana_20_6_Magic_Tier5){
            HPRegen_20_1.transform.Find("Button").GetComponent<Button>().interactable = true;
            HPRegen_20_1.transform.Find("Glowing_Yellow").gameObject.SetActive(true);
        }
        SkillManager.CheckAll();
    }

    public void Mana_20_6_Check(){
        Check(Object: Mana_20_6, Name: "Mana_20_6", SkillManager.Practice_Plus, 25);
    }

    public void Mana_20_6_Text(){
        GetText("Mana_20_6", TextName: "A Lot Of Mana", Price: 6, Category: 'M', Req_C: 25);
    }

    public void Mana_20_6_Upgrade(){
        Upgrade(Object: Mana_20_6, Name: "Mana_20_6", Price: 6, Invoke1:"Mana");

        if(SkillManager.EV_5_ACC_5_1_Magic_Tier5){
            HPRegen_20_1.transform.Find("Button").GetComponent<Button>().interactable = true;
            HPRegen_20_1.transform.Find("Glowing_Yellow").gameObject.SetActive(true);
        }
    }

    public void HPRegen_20_1_Text(){
        GetText("HPRegen_20_1", TextName: "Health Regeneration", Price: 15, Format1: 20, HasCheck: false);
    }

    public void HPRegen_20_1_Upgrade(){
        Upgrade(Object: HPRegen_20_1, Name: "HPRegen_20_1", Price: 15, Invoke1:"HealthRegen");
    }
}