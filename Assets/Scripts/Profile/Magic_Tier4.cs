using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class Magic_Tier4 : SkillTreeSegment
{
    public GameObject MR_2_2, Mana_20_3, M_2Perc_1, CH_Damage_2, CH_Effect, HP_10_2, EV_2_ACC_2_3, HP_15_2, MR_2_3, MCost_2Perc_1, CH_Effect_EVChance_1, ManaOverdrain_Perc_3, CH_Cooldown_2, CH_Effect_Damage_1, CH_Effect_Duration_1, V_Heal_2, EV_2_ACC_2_4, Mana_20_4, VU, V_Heal_1, V_Damage_1, V_Damage_2, V_EffectHeal_1, CH_Mana_2, V_Mana_1, UltimateUnlock;
    public bool MR_2_2_Checked, CH_Damage_2_Checked, CH_Effect_Checked, HP_10_2_Checked, MR_2_3_Checked, MCost_2Perc_1_Checked, CH_Effect_EVChance_1_Checked, ManaOverdrain_Perc_3_Checked, CH_Cooldown_2_Checked, CH_Effect_Damage_1_Checked, CH_Effect_Duration_1_Checked, EV_2_ACC_2_4_Checked, Mana_20_4_Checked, VU_Checked, V_Heal_1_Checked, V_Damage_1_Checked, V_Damage_2_Checked, V_EffectHeal_1_Checked, CH_Mana_2_Checked, V_Mana_1_Checked, V_Heal_2_Checked;
    public Magic_Tier5 Magic_Tier5;

    void Awake(){
        Class = "Magic_Tier4";
    }

    public void MR_2_2_Check(){
        Check(Object: MR_2_2, Name: "MR_2_2", SkillManager.Practice_Plus, 17);
    }

    public void MR_2_2_Text(){
        GetText("MR_2_2", TextName: "Mana Regeneration", Price: 5, Category: 'M', Req_C: 17, Format1: 2);
    }

    public void MR_2_2_Upgrade(){
        Upgrade(Object: MR_2_2, Name: "MR_2_2", Price: 5, Invoke1:"ManaRegen");

        Mana_20_3.transform.Find("Button").GetComponent<Button>().interactable = true;
        Mana_20_3.transform.Find("Glowing_Yellow").gameObject.SetActive(true);
        M_2Perc_1.transform.Find("Button").GetComponent<Button>().interactable = true;
        M_2Perc_1.transform.Find("Glowing_Yellow").gameObject.SetActive(true);
        CH_Mana_2.SetActive(true);
        CH_Damage_2.SetActive(true);
        ManaOverdrain_Perc_3.SetActive(true);
        SkillManager.CheckAll();
    }

    public void Mana_20_3_Text(){
        GetText("Mana_20_3", TextName: "A Lot Of Mana", Price: 5, HasCheck: false);
    }

    public void Mana_20_3_Upgrade(){
        Upgrade(Object: Mana_20_3, Name: "Mana_20_3", Price: 5, Invoke1:"Mana");

        if(SkillManager.EV_2_ACC_2_3_Magic_Tier4){
            ManaOverdrain_Perc_3.transform.Find("Button").GetComponent<Button>().interactable = true;
            SkillManager.Checklist_Add("ManaOverdrain_Perc_3","Magic_Tier4");
        }
        if(SkillManager.M_2Perc_1_Magic_Tier4){
            CH_Damage_2.transform.Find("Button").GetComponent<Button>().interactable = true;
            SkillManager.Checklist_Add("CH_Damage_2","Magic_Tier4");
            CH_Effect.SetActive(true);
            MR_2_3.SetActive(true);
        }
        SkillManager.CheckAll();
    }

    public void M_2Perc_1_Text(){
        GetText("M_2Perc_1", TextName: "Even More Mana", Price: 3, Format1: 2, HasCheck: false);
    }

    public void M_2Perc_1_Upgrade(){
        Upgrade(Object: M_2Perc_1, Name: "M_2Perc_1", Price: 3, Invoke1:"ManaModifier");

        CH_Mana_2.transform.Find("Button").GetComponent<Button>().interactable = true;
        SkillManager.Checklist_Add("CH_Mana_2","Magic_Tier4");
        if(SkillManager.Mana_20_3_Magic_Tier4){
            CH_Damage_2.transform.Find("Button").GetComponent<Button>().interactable = true;
            SkillManager.Checklist_Add("CH_Damage_2","Magic_Tier4");
            CH_Effect.SetActive(true);
            MR_2_3.SetActive(true);
        }
        V_Heal_1.SetActive(true);
        VU.SetActive(true);
        CH_Effect.SetActive(true);
        SkillManager.CheckAll();
    }
    
    public void CH_Mana_2_Check(){
        Check(Object: CH_Mana_2, Name: "CH_Mana_2", SkillManager.Practice_Plus, 19, SkillManager.CH_Mana, 1);
    }

    public void CH_Mana_2_Text(){
        GetText("CH_Mana_2", SkillName: "CH_Mana", TextName: "Chaos Mana", Price: 5, Category: 'M', Req_C: 19, UpgValue: 1, Format1: 180, Req1: "Chaos Mana", Req1Lvl: 1, HasSuffix: false);
    }

    public void CH_Mana_2_Upgrade(){
        Upgrade(Object: CH_Mana_2, Name: "CH_Mana_2", SkillName: "CH_Mana", Price: 5, IsBool: false, HasSuffix: false);

        if(SkillManager.VU){
            V_Heal_1.transform.Find("Button").GetComponent<Button>().interactable = true;
            SkillManager.Checklist_Add("V_Heal_1","Magic_Tier4");
            V_Damage_2.SetActive(true);
        }
        SkillManager.CheckAll();
    }

    public void ManaOverdrain_Perc_3_Check(){
        Check(Object: ManaOverdrain_Perc_3, Name: "ManaOverdrain_Perc_3", SkillManager.Practice_Plus, 19, SkillManager.ManaOverdrain_Perc, 2);
    }

    public void ManaOverdrain_Perc_3_Text(){
        GetText("ManaOverdrain_Perc_3", SkillName: "ManaOverdrain_Perc", TextName: "Mana Overdrain Percent", Price: 4, Category: 'M', Req_C: 19, UpgValue: 2, Format1: 25, Req1: "Mana Overdrain Percent", Req1Lvl: 2, HasSuffix: false);
    }

    public void ManaOverdrain_Perc_3_Upgrade(){
        Upgrade(Object: ManaOverdrain_Perc_3, Name: "ManaOverdrain_Perc_3", SkillName: "ManaOverdrain_Perc", Price: 4, IsBool: false, HasSuffix: false);
    }

    public void CH_Damage_2_Check(){
        Check(Object: CH_Damage_2, Name: "CH_Damage_2", SkillManager.Practice_Plus, 18, SkillManager.CH_Damage, 1);
    }

    public void CH_Damage_2_Text(){
        GetText("CH_Damage_2", SkillName: "CH_Damage", TextName: "Chaos Damage", Price: 4, Category: 'M', Req_C: 18, UpgValue: 1, Format1: 5, Req1: "Chaos Damage", Req1Lvl: 1, HasSuffix: false);
    }

    public void CH_Damage_2_Upgrade(){
        Upgrade(Object: CH_Damage_2, Name: "CH_Damage_2", SkillName: "CH_Damage", Price: 4, IsBool: false, HasSuffix: false);

        if(SkillManager.MR_2_3_Magic_Tier4){
            CH_Effect.transform.Find("Button").GetComponent<Button>().interactable = true;
            SkillManager.Checklist_Add("CH_Effect","Magic_Tier4");
            VU.SetActive(true);
            MCost_2Perc_1.SetActive(true);
            CH_Effect_EVChance_1.SetActive(true);
        }
        SkillManager.CheckAll();
    }

    public void HP_10_2_Check(){
        Check(Object: HP_10_2, Name: "HP_10_2", SkillManager.Practice_Plus, 17);
    }

    public void HP_10_2_Text(){
        GetText("HP_10_2", TextName: "Additional Health", DescriptionName: "HP 10 Description", Price: 2, Category: 'M', Req_C: 17);
    }

    public void HP_10_2_Upgrade(){
        Upgrade(Object: HP_10_2, Name: "HP_10_2", Price: 2, Invoke1:"Health");

        HP_15_2.transform.Find("Button").GetComponent<Button>().interactable = true;
        HP_15_2.transform.Find("Glowing_Yellow").gameObject.SetActive(true);
        EV_2_ACC_2_3.transform.Find("Button").GetComponent<Button>().interactable = true;
        EV_2_ACC_2_3.transform.Find("Glowing_Yellow").gameObject.SetActive(true);
        ManaOverdrain_Perc_3.SetActive(true);
        MR_2_3.SetActive(true);
        CH_Cooldown_2.SetActive(true);
        SkillManager.CheckAll();
    }

    public void HP_15_2_Text(){
        GetText("HP_15_2", TextName: "Additional Health", DescriptionName: "HP 15 Description", Price: 2, HasCheck: false);
    }

    public void HP_15_2_Upgrade(){
        Upgrade(Object: HP_15_2, Name: "HP_15_2", Price: 2, Invoke1:"Health");

        if(SkillManager.EV_2_ACC_2_3_Magic_Tier4){
            MR_2_3.transform.Find("Button").GetComponent<Button>().interactable = true;
            SkillManager.Checklist_Add("MR_2_3","Magic_Tier4");
            CH_Effect.SetActive(true);
        }
        CH_Cooldown_2.transform.Find("Button").GetComponent<Button>().interactable = true;
        SkillManager.Checklist_Add("CH_Cooldown_2","Magic_Tier4");
        CH_Effect_Duration_1.SetActive(true);
        CH_Effect_EVChance_1.SetActive(true);
        CH_Effect.SetActive(true);
        SkillManager.CheckAll();
    }

    public void EV_2_ACC_2_3_Text(){
        GetText("EV_2_ACC_2_3", TextName: "Universal Set", Price: 2, Format1: 2, HasCheck: false);
    }

    public void EV_2_ACC_2_3_Upgrade(){
        Upgrade(Object: EV_2_ACC_2_3, Name: "EV_2_ACC_2_3", Price: 2, Invoke1:"Evasion", Invoke2:"Accuracy");

        if(SkillManager.Mana_20_3_Magic_Tier4){
            ManaOverdrain_Perc_3.transform.Find("Button").GetComponent<Button>().interactable = true;
            SkillManager.Checklist_Add("ManaOverdrain_Perc_3","Magic_Tier4");
        }
        if(SkillManager.HP_15_2_Magic_Tier4){
            MR_2_3.transform.Find("Button").GetComponent<Button>().interactable = true;
            SkillManager.Checklist_Add("MR_2_3","Magic_Tier4");
            CH_Effect.SetActive(true);
        }
        SkillManager.CheckAll();
    }

    public void CH_Cooldown_2_Check(){
        Check(Object: CH_Cooldown_2, Name: "CH_Cooldown_2", SkillManager.Practice_Plus, 19, SkillManager.CH_Cooldown, 1);
    }

    public void CH_Cooldown_2_Text(){
        GetText("CH_Cooldown_2", SkillName: "CH_Cooldown", TextName: "Chaos Cooldown", Price: 6, Category: 'M', Req_C: 19, UpgValue: 1, Format1: 5, Req1: "Chaos Cooldown", Req1Lvl: 1, HasSuffix: false);
    }

    public void CH_Cooldown_2_Upgrade(){
        Upgrade(Object: CH_Cooldown_2, Name: "CH_Cooldown_2", SkillName: "CH_Cooldown", Price: 6, IsBool: false, HasSuffix: false);

        if(SkillManager.CH_Effect_EVChance>=1){
            CH_Effect_Duration_1.transform.Find("Button").GetComponent<Button>().interactable = true;
            SkillManager.Checklist_Add("CH_Effect_Duration_1","Magic_Tier4");
            V_Heal_2.SetActive(true);
        }
        SkillManager.CheckAll();
    }
    
    public void MR_2_3_Check(){
        Check(Object: MR_2_3, Name: "MR_2_3", SkillManager.Practice_Plus, 18);
    }

    public void MR_2_3_Text(){
        GetText("MR_2_3", TextName: "Mana Regeneration", Price: 6, Category: 'M', Req_C: 18, Format1: 2);
    }

    public void MR_2_3_Upgrade(){
        Upgrade(Object: MR_2_3, Name: "MR_2_3", Price: 6, Invoke1:"ManaRegen");

        if(SkillManager.CH_Damage>1){
            CH_Effect.transform.Find("Button").GetComponent<Button>().interactable = true;
            SkillManager.Checklist_Add("CH_Effect","Magic_Tier4");
            VU.SetActive(true);
            MCost_2Perc_1.SetActive(true);
            CH_Effect_EVChance_1.SetActive(true);
        }
        SkillManager.CheckAll();
    }

    public void CH_Effect_Check(){
        Check(Object: CH_Effect, Name: "CH_Effect", SkillManager.Practice_Plus, 19);
    }

    public void CH_Effect_Text(){
        GetText("CH_Effect", TextName: "Chaos Effect", Price: 5, Category: 'M', Req_C: 19, HasSuffix: false);
    }

    public void CH_Effect_Upgrade(){
        Upgrade(Object: CH_Effect, Name: "CH_Effect", Price: 5, HasSuffix: false);

        V_Heal_1.SetActive(true);
        V_Damage_1.SetActive(true);
        V_Mana_1.SetActive(true);
        V_EffectHeal_1.SetActive(true);
        Mana_20_4.SetActive(true);
        EV_2_ACC_2_4.SetActive(true);
        CH_Effect_Damage_1.SetActive(true);
        CH_Effect_Duration_1.SetActive(true);

        CH_Effect_EVChance_1.transform.Find("Button").GetComponent<Button>().interactable = true;
        SkillManager.Checklist_Add("CH_Effect_EVChance_1","Magic_Tier4");
        MCost_2Perc_1.transform.Find("Button").GetComponent<Button>().interactable = true;
        SkillManager.Checklist_Add("MCost_2Perc_1","Magic_Tier4");
        VU.transform.Find("Button").GetComponent<Button>().interactable = true;
        SkillManager.Checklist_Add("VU","Magic_Tier4");
        SkillManager.CheckAll();
    }

    public void VU_Check(){
        Check(Object: VU, Name: "VU", SkillManager.Practice_Plus, 20);
    }

    public void VU_Text(){
        GetText("VU", TextName: "Vampirism", Price: 7, Category: 'M', Req_C: 20, HasSuffix: false);
    }

    public void VU_Upgrade(){
        Upgrade(Object: VU, Name: "VU", Price: 7, HasSuffix: false);

        V_Damage_2.SetActive(true); 
        if(SkillManager.CH_Mana>1){
            V_Heal_1.transform.Find("Button").GetComponent<Button>().interactable = true;
            SkillManager.Checklist_Add("V_Heal_1","Magic_Tier4");
        }
        V_Damage_1.transform.Find("Button").GetComponent<Button>().interactable = true;
        SkillManager.Checklist_Add("V_Damage_1","Magic_Tier4");
        SkillManager.ActiveSkillsManager.SkillsUnlockCheck();
        SkillManager.CheckAll();
    }

    public void V_Heal_1_Check(){
        Check(Object: V_Heal_1, Name: "V_Heal_1", SkillManager.Practice_Plus, 21);
    }

    public void V_Heal_1_Text(){
        GetText("V_Heal_1", SkillName: "V_Heal", TextName: "Vampirism Heal", Price: 6, Category: 'M', Req_C: 21, Format1: 15, HasSuffix: false);
    }

    public void V_Heal_1_Upgrade(){
        Upgrade(Object: V_Heal_1, Name: "V_Heal_1", SkillName: "V_Heal", Price: 6, IsBool: false, HasSuffix: false);

        if(SkillManager.V_Damage>0){
            V_Damage_2.transform.Find("Button").GetComponent<Button>().interactable = true;
            SkillManager.Checklist_Add("V_Damage_2","Magic_Tier4");
        }
        SkillManager.CheckAll();
    }

    public void V_Damage_1_Check(){
        Check(Object: V_Damage_1, Name: "V_Damage_1", SkillManager.Practice_Plus, 21);
    }

    public void V_Damage_1_Text(){
        GetText("V_Damage_1", SkillName: "V_Damage", TextName: "Vampirism Damage", Price: 5, Category: 'M', Req_C: 21, Format1: 300, HasSuffix: false);
    }

    public void V_Damage_1_Upgrade(){
        Upgrade(Object: V_Damage_1, Name: "V_Damage_1", SkillName: "V_Damage", Price: 5, IsBool: false, HasSuffix: false);

        if(SkillManager.V_Heal>0){
            V_Damage_2.transform.Find("Button").GetComponent<Button>().interactable = true;
            SkillManager.Checklist_Add("V_Damage_2","Magic_Tier4");
        }
        SkillManager.CheckAll();
    }

       public void V_Damage_2_Check(){
        Check(Object: V_Damage_2, Name: "V_Damage_2", SkillManager.Practice_Plus, 22);
    }

    public void V_Damage_2_Text(){
        GetText("V_Damage_2", SkillName: "V_Damage", TextName: "Vampirism Damage", Price: 7, Category: 'M', Req_C: 22, UpgValue: 1, Format1: 400, Req1: "Vampirism Damage", Req1Lvl: 1, HasSuffix: false);
    }

    public void V_Damage_2_Upgrade(){
        Upgrade(Object: V_Damage_2, Name: "V_Damage_2", SkillName: "V_Damage", Price: 7, IsBool: false, HasSuffix: false);
        SkillManager.CheckAll();
    }

    public void CH_Effect_EVChance_1_Check(){
        Check(Object: CH_Effect_EVChance_1, Name: "CH_Effect_EVChance_1", SkillManager.Practice_Plus, 20);
    }

    public void CH_Effect_EVChance_1_Text(){
        GetText("CH_Effect_EVChance_1", SkillName: "CH_Effect_EVChance", TextName: "Chaos Effect Avoid Chance", Price: 5, Category: 'M', Req_C: 20, Format1: 7, HasSuffix: false);
    }

    public void CH_Effect_EVChance_1_Upgrade(){
        Upgrade(Object: CH_Effect_EVChance_1, Name: "CH_Effect_EVChance_1", SkillName: "CH_Effect_EVChance", Price: 5, IsBool: false, HasSuffix: false);

        V_Heal_2.SetActive(true);
        CH_Effect_Damage_1.transform.Find("Button").GetComponent<Button>().interactable = true;
        SkillManager.Checklist_Add("CH_Effect_Damage_1","Magic_Tier4");
        if(SkillManager.CH_Cooldown>=2){
            CH_Effect_Duration_1.transform.Find("Button").GetComponent<Button>().interactable = true;
            SkillManager.Checklist_Add("CH_Effect_Duration_1","Magic_Tier4");
        }
        SkillManager.CheckAll();
    }

    public void CH_Effect_Damage_1_Check(){
        Check(Object: CH_Effect_Damage_1, Name: "CH_Effect_Damage_1", SkillManager.Practice_Plus, 21);
    }

    public void CH_Effect_Damage_1_Text(){
        GetText("CH_Effect_Damage_1", SkillName: "CH_Effect_Damage", TextName: "Chaos Effect Damage", Price: 4, Category: 'M', Req_C: 21, Format1: 1, HasSuffix: false);
    }

    public void CH_Effect_Damage_1_Upgrade(){
        Upgrade(Object: CH_Effect_Damage_1, Name: "CH_Effect_Damage_1", SkillName: "CH_Effect_Damage", Price: 4, IsBool: false, HasSuffix: false);

        if(SkillManager.CH_Effect_Duration == 1){
            V_Heal_2.transform.Find("Button").GetComponent<Button>().interactable = true;
            SkillManager.Checklist_Add("V_Heal_2","Magic_Tier4");
        }
        SkillManager.CheckAll();
    }

    public void CH_Effect_Duration_1_Check(){
        Check(Object: CH_Effect_Duration_1, Name: "CH_Effect_Duration_1", SkillManager.Practice_Plus, 21);
    }

    public void CH_Effect_Duration_1_Text(){
        GetText("CH_Effect_Duration_1", SkillName: "CH_Effect_Duration", TextName: "Chaos Effect Duration", Price: 5, Category: 'M', Req_C: 21, StringFormat: "2-6", HasSuffix: false);
    }

    public void CH_Effect_Duration_1_Upgrade(){
        Upgrade(Object: CH_Effect_Duration_1, Name: "CH_Effect_Duration_1", SkillName: "CH_Effect_Duration", Price: 5, IsBool: false, HasSuffix: false);

        if(SkillManager.CH_Effect_Damage ==1){
            V_Heal_2.transform.Find("Button").GetComponent<Button>().interactable = true;
            SkillManager.Checklist_Add("V_Heal_2","Magic_Tier4");
        }
        SkillManager.CheckAll();
    }

    public void V_Heal_2_Check(){
        Check(Object: V_Heal_2, Name: "V_Heal_2", SkillManager.V_Heal, 1);
    }

    public void V_Heal_2_Text(){
        GetText("V_Heal_2", SkillName: "V_Heal", TextName: "Vampirism Heal", Price: 7, UpgValue: 1, Format1: 20, Req1: "Vampirism Heal", Req1Lvl: 1, HasSuffix: false);
    }

    public void V_Heal_2_Upgrade(){
        Upgrade(Object: V_Heal_2, Name: "V_Heal_2", SkillName: "V_Heal", Price: 7, IsBool: false, HasSuffix: false);
        SkillManager.CheckAll();
    }

    public void MCost_2Perc_1_Check(){
        Check(Object: MCost_2Perc_1, Name: "MCost_2Perc_1", SkillManager.Practice_Plus, 20);
    }

    public void MCost_2Perc_1_Text(){
        GetText("MCost_2Perc_1", TextName: "Cheaper Spells", Price:6 , Category: 'M', Req_C: 20, Format1: 2);
    }

    public void MCost_2Perc_1_Upgrade(){
        Upgrade(Object: MCost_2Perc_1, Name: "MCost_2Perc_1", Price: 6, Invoke1:"ManaCost");

        V_Mana_1.transform.Find("Button").GetComponent<Button>().interactable = true;
        SkillManager.Checklist_Add("V_Mana_1","Magic_Tier4");
        V_EffectHeal_1.transform.Find("Button").GetComponent<Button>().interactable = true;
        SkillManager.Checklist_Add("V_EffectHeal_1","Magic_Tier4");
        Mana_20_4.transform.Find("Button").GetComponent<Button>().interactable = true;
        SkillManager.Checklist_Add("Mana_20_4","Magic_Tier4");
        EV_2_ACC_2_4.transform.Find("Button").GetComponent<Button>().interactable = true;
        SkillManager.Checklist_Add("EV_2_ACC_2_4","Magic_Tier4");
        UltimateUnlock.SetActive(true);
        SkillManager.CheckAll();
    }

    public void V_Mana_1_Check(){
        Check(Object: V_Mana_1, Name: "V_Mana_1", SkillManager.Practice_Plus, 21, Convert.ToInt32(SkillManager.VU), 1);
    }

    public void V_Mana_1_Text(){
        GetText("V_Mana_1", SkillName: "V_Mana", TextName: "Vampirism Mana", Price: 4, Category: 'M', Req_C: 21, Format1: 130, Req1: "Vampirism", NeedOtherUnlock: true, HasSuffix: false);
    }

    public void V_Mana_1_Upgrade(){
        Upgrade(Object: V_Mana_1, Name: "V_Mana_1", SkillName: "V_Mana", Price: 4, IsBool: false, HasSuffix: false);
        SkillManager.CheckAll();
    }

    public void V_EffectHeal_1_Check(){
        Check(Object: V_EffectHeal_1, Name: "V_EffectHeal_1", SkillManager.Practice_Plus, 21, Convert.ToInt32(SkillManager.VU), 1);
    }

    public void V_EffectHeal_1_Text(){
        GetText("V_EffectHeal_1", SkillName: "V_EffectHeal", TextName: "Vampirism Effect Heal", Price: 4, Category: 'M', Req_C: 21, Format1: 2, Req1: "Vampirism", NeedOtherUnlock: true, HasSuffix: false);
    }

    public void V_EffectHeal_1_Upgrade(){
        Upgrade(Object: V_EffectHeal_1, Name: "V_EffectHeal_1", SkillName: "V_EffectHeal", Price: 4, IsBool: false, HasSuffix: false);
        SkillManager.CheckAll();
    }

    public void Mana_20_4_Check(){
        Check(Object: Mana_20_4, Name: "Mana_20_4", SkillManager.Practice_Plus, 21);
    }

    public void Mana_20_4_Text(){
        GetText("Mana_20_4", TextName: "A Lot Of Mana", Price: 4, Category: 'M', Req_C: 21);
    }

    public void Mana_20_4_Upgrade(){
        Upgrade(Object: Mana_20_4, Name: "Mana_20_4", Price: 4, Invoke1:"Mana");

        if(SkillManager.EV_2_ACC_2_4_Magic_Tier4){
            UltimateUnlock.transform.Find("Button").GetComponent<Button>().interactable = true;
            UltimateUnlock.transform.Find("Glowing_Yellow").gameObject.SetActive(true);
            Magic_Tier5.HP_20_2.SetActive(true);
            Magic_Tier5.Mana_2Perc_2.SetActive(true);
            Magic_Tier5.DMG_Resistance_2_1.SetActive(true);
            Magic_Tier5.CH_Ultimate_HPPercent.SetActive(true);
            Magic_Tier5.CH_Ultimate_RandomDebuff.SetActive(true);
            Magic_Tier5.BS_Ultimate.SetActive(true);
            Magic_Tier5.V_Ultimate.SetActive(true);
        }
    }

    public void EV_2_ACC_2_4_Check(){
        Check(Object: EV_2_ACC_2_4, Name: "EV_2_ACC_2_4", SkillManager.Practice_Plus, 21);
    }

    public void EV_2_ACC_2_4_Text(){
        GetText("EV_2_ACC_2_4", TextName: "Universal Set", Price: 2, Category: 'M', Req_C: 21, Format1: 2);
    }

    public void EV_2_ACC_2_4_Upgrade(){
        Upgrade(Object: EV_2_ACC_2_4, Name: "EV_2_ACC_2_4", Price: 2, Invoke1:"Evasion", Invoke2:"Accuracy");

        if(SkillManager.Mana_20_4_Magic_Tier4){
            UltimateUnlock.transform.Find("Button").GetComponent<Button>().interactable = true;
            UltimateUnlock.transform.Find("Glowing_Yellow").gameObject.SetActive(true);
            Magic_Tier5.HP_20_2.SetActive(true);
            Magic_Tier5.Mana_2Perc_2.SetActive(true);
            Magic_Tier5.DMG_Resistance_2_1.SetActive(true);
            Magic_Tier5.CH_Ultimate_HPPercent.SetActive(true);
            Magic_Tier5.CH_Ultimate_RandomDebuff.SetActive(true);
            Magic_Tier5.BS_Ultimate.SetActive(true);
            Magic_Tier5.V_Ultimate.SetActive(true);
        }
        SkillManager.CheckAll();
    }

    public void UltimateUnlock_Text(){
        GetText("UltimateUnlock", TextName: "Ultimate Unlock", Price: 1, HasCheck: false);
    }

    public void UltimateUnlock_Upgrade(){
        Upgrade(Object: UltimateUnlock, Name: "UltimateUnlock", Price: 1);

        Magic_Tier5.HP_20_2.transform.Find("Button").GetComponent<Button>().interactable = true;
        Magic_Tier5.Mana_2Perc_2.transform.Find("Button").GetComponent<Button>().interactable = true;
        Magic_Tier5.DMG_Resistance_2_1.transform.Find("Button").GetComponent<Button>().interactable = true;
        Magic_Tier5.CH_Ultimate_HPPercent.transform.Find("Button").GetComponent<Button>().interactable = true;
        Magic_Tier5.CH_Ultimate_RandomDebuff.transform.Find("Button").GetComponent<Button>().interactable = true;
        Magic_Tier5.BS_Ultimate.transform.Find("Button").GetComponent<Button>().interactable = true;
        Magic_Tier5.V_Ultimate.transform.Find("Button").GetComponent<Button>().interactable = true;
        Magic_Tier5.HP_20_2.transform.Find("Glowing_Yellow").gameObject.SetActive(true);
        Magic_Tier5.Mana_2Perc_2.transform.Find("Glowing_Yellow").gameObject.SetActive(true);
        Magic_Tier5.DMG_Resistance_2_1.transform.Find("Glowing_Yellow").gameObject.SetActive(true);
        SkillManager.Checklist_Add("CH_Ultimate_HPPercent","Magic_Tier5");
        SkillManager.Checklist_Add("CH_Ultimate_RandomDebuff","Magic_Tier5");
        SkillManager.Checklist_Add("BS_Ultimate","Magic_Tier5");
        SkillManager.Checklist_Add("V_Ultimate","Magic_Tier5");
        Magic_Tier5.ManaOverdrain_Potion_3.SetActive(true);
        Magic_Tier5.MCost_2Perc_2.SetActive(true);
        Magic_Tier5.MCost_2Perc_3.SetActive(true);
        Magic_Tier5.Mana_20_5.SetActive(true);
        Magic_Tier5.Mana_20_8.SetActive(true);
        SkillManager.CheckAll();
    }
}