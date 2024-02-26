using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class Magic_Tier3 : SkillTreeSegment
{
    public GameObject DMG_Resistance_1_1, EV_2_ACC_2_2, Mana_10_6, MR_2_1, CHU, Mana_20_1, CH_Damage_1, MCost_1Perc_1, BS_Weakness_AddDuration, HP_15_1, BS_Mana_2, ManaOverdrain_Potion_2, HP_5_3, EV_1_ACC_1_3, CH_Mana_1, MR_1_4, BS_Cooldown_3, ManaOverdrain_Perc_2, AtkSpeed_1_1, HP_5_4, BS_Damage_3, Mana_20_2, MR_1_5, CH_Cooldown_1, SkilledTree_1;
    public bool DMG_Resistance_1_1_Checked, EV_2_ACC_2_2_Checked, Mana_10_6_Checked, MR_2_1_Checked, CHU_Checked, Mana_20_1_Checked, CH_Damage_1_Checked, MCost_1Perc_1_Checked, BS_Weakness_AddDuration_Checked, HP_15_1_Checked, BS_Mana_2_Checked, ManaOverdrain_Potion_2_Checked, HP_5_3_Checked, EV_1_ACC_1_3_Checked, CH_Mana_1_Checked, MR_1_4_Checked, BS_Cooldown_3_Checked, ManaOverdrain_Perc_2_Checked, AtkSpeed_1_1_Checked, HP_5_4_Checked, BS_Damage_3_Checked, Mana_20_2_Checked, MR_1_5_Checked, CH_Cooldown_1_Checked;
    public Magic_Tier4 Magic_Tier4;

    void Awake(){
        Class = "Magic_Tier3";
    }

    public void DMG_Resistance_1_1_Check(){
        Check(Object: DMG_Resistance_1_1, Name: "DMG_Resistance_1_1", SkillManager.Practice_Plus, 11);
    }

    public void DMG_Resistance_1_1_Text(){
        GetText("DMG_Resistance_1_1", TextName: "Damage Resistance", Price: 2, Category: 'M', Req_C: 11, Format1: 1);
    }

    public void DMG_Resistance_1_1_Upgrade(){
        Upgrade(Object: DMG_Resistance_1_1, Name: "DMG_Resistance_1_1", Price: 2, Invoke1:"DamageResistance");

        EV_2_ACC_2_2.transform.Find("Button").GetComponent<Button>().interactable = true;
        SkillManager.Checklist_Add("EV_2_ACC_2_2","Magic_Tier3");
        CHU.transform.Find("Button").GetComponent<Button>().interactable = true;
        SkillManager.Checklist_Add("CHU","Magic_Tier3");
        MCost_1Perc_1.transform.Find("Button").GetComponent<Button>().interactable = true;
        SkillManager.Checklist_Add("MCost_1Perc_1","Magic_Tier3");
        BS_Mana_2.transform.Find("Button").GetComponent<Button>().interactable = true;
        SkillManager.Checklist_Add("BS_Mana_2","Magic_Tier3");
        HP_5_3.transform.Find("Button").GetComponent<Button>().interactable = true;
        SkillManager.Checklist_Add("HP_5_3","Magic_Tier3");
        MR_1_4.transform.Find("Button").GetComponent<Button>().interactable = true;
        SkillManager.Checklist_Add("MR_1_4","Magic_Tier3");
        AtkSpeed_1_1.transform.Find("Button").GetComponent<Button>().interactable = true;
        SkillManager.Checklist_Add("AtkSpeed_1_1","Magic_Tier3");
        Mana_20_2.transform.Find("Button").GetComponent<Button>().interactable = true;
        SkillManager.Checklist_Add("Mana_20_2","Magic_Tier3");
        Mana_10_6.SetActive(true);
        Mana_20_1.SetActive(true);
        BS_Weakness_AddDuration.SetActive(true);
        ManaOverdrain_Potion_2.SetActive(true);
        EV_1_ACC_1_3.SetActive(true);
        BS_Cooldown_3.SetActive(true);
        HP_5_4.SetActive(true);
        MR_1_5.SetActive(true);
        SkillManager.CheckAll();
    }

    public void EV_2_ACC_2_2_Check(){
        Check(Object: EV_2_ACC_2_2, Name: "EV_2_ACC_2_2", SkillManager.Practice_Plus, 13);
    }

    public void EV_2_ACC_2_2_Text(){
        GetText("EV_2_ACC_2_2", TextName: "Universal Set", Price: 2, Category: 'M', Req_C: 13, Format1: 2);
    }

    public void EV_2_ACC_2_2_Upgrade(){
        Upgrade(Object: EV_2_ACC_2_2, Name: "EV_2_ACC_2_2", Price: 2, Invoke1:"Evasion", Invoke2: "Accuracy");

        Mana_10_6.transform.Find("Button").GetComponent<Button>().interactable = true;
        SkillManager.Checklist_Add("Mana_10_6","Magic_Tier3");
        MR_2_1.SetActive(true);
        SkillManager.CheckAll();
    } 

    public void Mana_10_6_Check(){
        Check(Object: Mana_10_6, Name: "Mana_10_6", SkillManager.Practice_Plus, 14);
    }

    public void Mana_10_6_Text(){
        GetText("Mana_10_6", TextName: "More Mana", Price: 2, Category: 'M', Req_C: 14);
    }

    public void Mana_10_6_Upgrade(){
        Upgrade(Object: Mana_10_6, Name: "Mana_10_6", Price: 2, Invoke1:"Mana");

        BS_Damage_3.SetActive(true);
        MR_2_1.transform.Find("Button").GetComponent<Button>().interactable = true;
        SkillManager.Checklist_Add("MR_2_1","Magic_Tier3");
        SkilledTree_1.SetActive(true);
        SkillManager.CheckAll();
    }

    public void MR_2_1_Check(){
        Check(Object: MR_2_1, Name: "MR_2_1", SkillManager.Practice_Plus, 16);
    }

    public void MR_2_1_Text(){
        GetText("MR_2_1", TextName: "Mana Regeneration", Price: 6, Category: 'M', Req_C: 16, Format1: 2);
    }

    public void MR_2_1_Upgrade(){
        Upgrade(Object: MR_2_1, Name: "MR_2_1", Price: 6, Invoke1:"ManaRegen");

        if(SkillManager.BS_Damage>2){
            SkilledTree_1.transform.Find("Button").GetComponent<Button>().interactable = true;
            SkilledTree_1.transform.Find("Glowing_Yellow").gameObject.SetActive(true);
            Magic_Tier4.HP_10_2.SetActive(true);
            Magic_Tier4.MR_2_2.SetActive(true);
        }
    }

    public void CHU_Check(){
        Check(Object: CHU, Name: "CHU", SkillManager.Practice_Plus, 13);
    }

    public void CHU_Text(){
        GetText("CHU", TextName: "Chaos", Price: 5, Category: 'M', Req_C: 13, HasSuffix: false);
    }

    public void CHU_Upgrade(){
        Upgrade(Object: CHU, Name: "CHU", Price: 5, HasSuffix: false);

        Mana_20_1.transform.Find("Button").GetComponent<Button>().interactable = true;
        SkillManager.Checklist_Add("Mana_20_1","Magic_Tier3");
        CH_Damage_1.SetActive(true);
        SkillManager.ActiveSkillsManager.SkillsUnlockCheck();
        SkillManager.CheckAll();
    } 

    public void Mana_20_1_Check(){
        Check(Object: Mana_20_1, Name: "Mana_20_1", SkillManager.Practice_Plus, 14);
    }

    public void Mana_20_1_Text(){
        GetText("Mana_20_1", TextName: "A Lot Of Mana", Price: 4, Category: 'M', Req_C:14);
    }

    public void Mana_20_1_Upgrade(){
        Upgrade(Object: Mana_20_1, Name: "Mana_20_1", Price: 4, Invoke1:"Mana");

        CH_Damage_1.transform.Find("Button").GetComponent<Button>().interactable = true;
        SkillManager.Checklist_Add("CH_Damage_1","Magic_Tier3");
        SkillManager.CheckAll();

    }

    public void CH_Damage_1_Check(){
        Check(Object: CH_Damage_1, Name: "CH_Damage_1", SkillManager.Practice_Plus, 15);
    }

    public void CH_Damage_1_Text(){
        GetText("CH_Damage_1", SkillName: "CH_Damage", TextName: "Chaos Damage", Price: 4, Category: 'M', Req_C: 15, Format1: 2, HasSuffix: false);
    }

    public void CH_Damage_1_Upgrade(){
        Upgrade(Object: CH_Damage_1, Name: "CH_Damage_1", SkillName: "CH_Damage", Price: 4, IsBool: false, HasSuffix: false);
        SkillManager.CheckAll();
    }

    public void MCost_1Perc_1_Check(){
        Check(Object: MCost_1Perc_1, Name: "MCost_1Perc_1", SkillManager.Practice_Plus, 14);
    }

    public void MCost_1Perc_1_Text(){
        GetText("MCost_1Perc_1", TextName: "Cheaper Spells", Price: 4, Category: 'M', Req_C: 14, Format1: 1);
    }

    public void MCost_1Perc_1_Upgrade(){
        Upgrade(Object: MCost_1Perc_1, Name: "MCost_1Perc_1", Price: 4, Invoke1:"ManaCost");

        BS_Weakness_AddDuration.transform.Find("Button").GetComponent<Button>().interactable = true;
        SkillManager.Checklist_Add("BS_Weakness_AddDuration","Magic_Tier3");
        HP_15_1.SetActive(true);
        SkillManager.CheckAll();
    } 

    public void BS_Weakness_AddDuration_Check(){
        Check(Object: BS_Weakness_AddDuration, Name: "BS_Weakness_AddDuration", SkillManager.Practice_Plus, 15, Convert.ToInt32(SkillManager.BS_UnlockWeakness), 1);
    }

    public void BS_Weakness_AddDuration_Text(){
        GetText("BS_Weakness_AddDuration", TextName: "Stronger Weakness", Price: 4, Category: 'M', Req_C: 15, Req1: "More Effects", NeedOtherUnlock: true, HasSuffix: false);
    }

    public void BS_Weakness_AddDuration_Upgrade(){
        Upgrade(Object: BS_Weakness_AddDuration, Name: "BS_Weakness_AddDuration", Price: 4, HasSuffix: false);
        
        HP_15_1.transform.Find("Button").GetComponent<Button>().interactable = true;
        SkillManager.Checklist_Add("HP_15_1","Magic_Tier3");
        SkillManager.CheckAll();
    }

    public void HP_15_1_Check(){
        Check(Object: HP_15_1, Name: "HP_15_1", SkillManager.Practice_Plus, 16);
    }

    public void HP_15_1_Text(){
        GetText("HP_15_1", TextName: "Additional Health", DescriptionName: "HP 15 Description", Price: 2, Category: 'M', Req_C: 16);
    }

    public void HP_15_1_Upgrade(){
        Upgrade(Object: HP_15_1, Name: "HP_15_1", Price: 2, Invoke1:"Health");
    }

    public void BS_Mana_2_Check(){
        Check(Object: BS_Mana_2, Name: "BS_Mana_2", SkillManager.Practice_Plus, 14, SkillManager.BS_Mana, 1);
    }

    public void BS_Mana_2_Text(){
        GetText("BS_Mana_2", SkillName: "BS_Mana", TextName: "Beginner Mana", Price: 5, Category: 'M', Req_C: 14, UpgValue: 1, Format1: 30, Req1: "Beginner Mana", Req1Lvl: 1, HasSuffix: false);
    }

    public void BS_Mana_2_Upgrade(){
        Upgrade(Object: BS_Mana_2, Name: "BS_Mana_2", SkillName: "BS_Mana", Price: 5, IsBool: false, HasSuffix: false);
        
        ManaOverdrain_Potion_2.transform.Find("Button").GetComponent<Button>().interactable = true;
        SkillManager.Checklist_Add("ManaOverdrain_Potion_2","Magic_Tier3");
        SkillManager.CheckAll();
    } 

    public void ManaOverdrain_Potion_2_Check(){
        Check(Object: ManaOverdrain_Potion_2, Name: "ManaOverdrain_Potion_2", SkillManager.Practice_Plus, 17, SkillManager.ManaOverdrain_Potion, 1);
    }

    public void ManaOverdrain_Potion_2_Text(){
        GetText("ManaOverdrain_Potion_2", SkillName: "ManaOverdrain_Potion", TextName: "Mana Overdrain Potion", Price: 6, Category: 'M', Req_C: 17, UpgValue: 1, Format1: 2, Req1: "Mana Overdrain Potion", Req1Lvl: 1, HasSuffix: false);
        Information_Skills.text = string.Format(Language_Changer.Instance.GetText("Mana_Overdrain_Potion_Description"), 2);
    }

    public void ManaOverdrain_Potion_2_Upgrade(){
        Upgrade(Object: ManaOverdrain_Potion_2, Name: "ManaOverdrain_Potion_2", SkillName: "ManaOverdrain_Potion", Price: 6, IsBool: false, HasSuffix: false);
    }

    public void HP_5_3_Check(){
        Check(Object: HP_5_3, Name: "HP_5_3", SkillManager.Practice_Plus, 12);
    }

    public void HP_5_3_Text(){
        GetText("HP_5_3", TextName: "Additional Health", DescriptionName: "HP 5 Description", Price: 1, Category: 'M', Req_C: 12);
    }

    public void HP_5_3_Upgrade(){
        Upgrade(Object: HP_5_3, Name: "HP_5_3", Price: 1, Invoke1:"Health");

        EV_1_ACC_1_3.transform.Find("Button").GetComponent<Button>().interactable = true;
        SkillManager.Checklist_Add("EV_1_ACC_1_3","Magic_Tier3");
        CH_Mana_1.SetActive(true);
        SkillManager.CheckAll();
    } 

    public void EV_1_ACC_1_3_Check(){
        Check(Object: EV_1_ACC_1_3, Name: "EV_1_ACC_1_3", SkillManager.Practice_Plus, 14);
    }

    public void EV_1_ACC_1_3_Text(){
        GetText("EV_1_ACC_1_3", TextName: "Universal Set", Price: 1, Category: 'M', Req_C: 14, Format1: 1);
    }

    public void EV_1_ACC_1_3_Upgrade(){
        Upgrade(Object: EV_1_ACC_1_3, Name: "EV_1_ACC_1_3", Price: 1, Invoke1:"Evasion", Invoke2:"Accuracy");

        CH_Mana_1.transform.Find("Button").GetComponent<Button>().interactable = true;
        SkillManager.Checklist_Add("CH_Mana_1","Magic_Tier3");
        SkillManager.CheckAll();
    }

    public void CH_Mana_1_Check(){
        Check(Object: CH_Mana_1, Name: "CH_Mana_1", SkillManager.Practice_Plus, 16, Convert.ToInt32(SkillManager.CHU), 1);
    }

    public void CH_Mana_1_Text(){
        GetText("CH_Mana_1", SkillName: "CH_Mana", TextName: "Chaos Mana", Price:4 , Category: 'M', Req_C: 16, Format1: 220, Req1: "Chaos", NeedOtherUnlock: true, HasSuffix: false);
    }

    public void CH_Mana_1_Upgrade(){
        Upgrade(Object: CH_Mana_1, Name: "CH_Mana_1", SkillName: "CH_Mana", Price: 4, IsBool: false, HasSuffix: false);
        SkillManager.CheckAll();
    }

    public void MR_1_4_Check(){
        Check(Object: MR_1_4, Name: "MR_1_4", SkillManager.Practice_Plus, 12);
    }

    public void MR_1_4_Text(){
        GetText("MR_1_4", TextName: "Mana Regeneration", Price: 4, Category: 'M', Req_C: 12, Format1: 1);
    }

    public void MR_1_4_Upgrade(){
        Upgrade(Object: MR_1_4, Name: "MR_1_4", Price: 4, Invoke1:"ManaRegen");

        BS_Cooldown_3.transform.Find("Button").GetComponent<Button>().interactable = true;
        SkillManager.Checklist_Add("BS_Cooldown_3","Magic_Tier3");
        ManaOverdrain_Perc_2.SetActive(true);
        SkillManager.CheckAll();
    } 

    public void BS_Cooldown_3_Check(){
        Check(Object: BS_Cooldown_3, Name: "BS_Cooldown_3", SkillManager.Practice_Plus, 13, SkillManager.BS_Cooldown, 2);
    }

    public void BS_Cooldown_3_Text(){
        GetText("BS_Cooldown_3", SkillName: "BS_Cooldown", TextName: "Beginner Cooldown", Price: 4, Category: 'M', Req_C: 13, UpgValue: 2, Format1: 5, Req1: "Beginner Cooldown", Req1Lvl: 2, HasSuffix: false);
    }

    public void BS_Cooldown_3_Upgrade(){
        Upgrade(Object: BS_Cooldown_3, Name: "BS_Cooldown_3", SkillName: "BS_Cooldown", Price: 4, IsBool: false, HasSuffix: false);

        ManaOverdrain_Perc_2.transform.Find("Button").GetComponent<Button>().interactable = true;
        SkillManager.Checklist_Add("ManaOverdrain_Perc_2","Magic_Tier3");
        SkillManager.CheckAll();
    }

    public void ManaOverdrain_Perc_2_Check(){
        Check(Object: ManaOverdrain_Perc_2, Name: "ManaOverdrain_Perc_2", SkillManager.Practice_Plus, 14, SkillManager.ManaOverdrain_Perc, 1);
    }

    public void ManaOverdrain_Perc_2_Text(){
        GetText("ManaOverdrain_Perc_2", SkillName: "ManaOverdrain_Perc", TextName: "Mana Overdrain Percent", Price: 3, Category: 'M', Req_C: 14, UpgValue: 1, Format1: 20, Req1: "Mana Overdrain Percent", Req1Lvl: 1, HasSuffix: false);
    }

    public void ManaOverdrain_Perc_2_Upgrade(){
        Upgrade(Object: ManaOverdrain_Perc_2, Name: "ManaOverdrain_Perc_2", SkillName: "ManaOverdrain_Perc", Price: 3, IsBool: false, HasSuffix: false);
        SkillManager.CheckAll();
    }

    public void AtkSpeed_1_1_Check(){
        Check(Object: AtkSpeed_1_1, Name: "AtkSpeed_1_1", SkillManager.Practice_Plus, 12);
    }

    public void AtkSpeed_1_1_Text(){
        GetText("AtkSpeed_1_1", TextName: "Faster Attacks", Price: 6, Category: 'M', Req_C: 12);
    }

    public void AtkSpeed_1_1_Upgrade(){
        Upgrade(Object: AtkSpeed_1_1, Name: "AtkSpeed_1_1", Price: 6, Invoke1:"AttackSpeed");

        HP_5_4.transform.Find("Button").GetComponent<Button>().interactable = true;
        SkillManager.Checklist_Add("HP_5_4","Magic_Tier3");
        BS_Damage_3.SetActive(true);
        SkillManager.CheckAll();
    } 

    public void HP_5_4_Check(){
        Check(Object: HP_5_4, Name: "HP_5_4", SkillManager.Practice_Plus, 13);
    }

    public void HP_5_4_Text(){
        GetText("HP_5_4", TextName: "Additional Health", DescriptionName: "HP 5 Description", Price: 1, Category: 'M', Req_C: 13);
    }

    public void HP_5_4_Upgrade(){
        Upgrade(Object: HP_5_4, Name: "HP_5_4", Price: 1, Invoke1:"Health");

        MR_2_1.SetActive(true);
        BS_Damage_3.transform.Find("Button").GetComponent<Button>().interactable = true;
        SkillManager.Checklist_Add("BS_Damage_3","Magic_Tier3");
        SkilledTree_1.SetActive(true);
        SkillManager.CheckAll();
    }

    public void BS_Damage_3_Check(){
        Check(Object: BS_Damage_3, Name: "BS_Damage_3", SkillManager.Practice_Plus, 15, SkillManager.BS_Damage, 2);
    }

    public void BS_Damage_3_Text(){
        GetText("BS_Damage_3", SkillName: "BS_Damage", TextName: "Beginner Damage", Price: 4, Category: 'M', Req_C: 15, UpgValue: 2, Format1: 50, Req1: "Beginner Damage", Req1Lvl: 2, HasSuffix: false);
    }

    public void BS_Damage_3_Upgrade(){
        Upgrade(Object: BS_Damage_3, Name: "BS_Damage_3", SkillName: "BS_Damage", Price: 4, IsBool: false, HasSuffix: false);
        
        if(SkillManager.MR_2_1_Magic_Tier3){
            SkilledTree_1.transform.Find("Button").GetComponent<Button>().interactable = true;
            SkilledTree_1.transform.Find("Glowing_Yellow").gameObject.SetActive(true);
            Magic_Tier4.HP_10_2.SetActive(true);
            Magic_Tier4.MR_2_2.SetActive(true);
        }
        SkillManager.CheckAll();
    }
    
    public void Mana_20_2_Check(){
        Check(Object: Mana_20_2, Name: "Mana_20_2", SkillManager.Practice_Plus, 13);
    }

    public void Mana_20_2_Text(){
        GetText("Mana_20_2", TextName: "A Lot Of Mana", Price: 5, Category: 'M', Req_C: 13);
    }

    public void Mana_20_2_Upgrade(){
        Upgrade(Object: Mana_20_2, Name: "Mana_20_2", Price: 5, Invoke1:"Mana");

        MR_1_5.transform.Find("Button").GetComponent<Button>().interactable = true;
        SkillManager.Checklist_Add("MR_1_5","Magic_Tier3");
        CH_Cooldown_1.SetActive(true);
        SkillManager.CheckAll();
    } 

    public void MR_1_5_Check(){
        Check(Object: MR_1_5, Name: "MR_1_5", SkillManager.Practice_Plus, 15);
    }

    public void MR_1_5_Text(){
        GetText("MR_1_5", TextName: "Mana Regeneration", Price: 3, Category: 'M', Req_C: 15, Format1: 1);
    }

    public void MR_1_5_Upgrade(){
        Upgrade(Object: MR_1_5, Name: "MR_1_5", Price: 3, Invoke1:"Mana");

        CH_Cooldown_1.transform.Find("Button").GetComponent<Button>().interactable = true;
        SkillManager.Checklist_Add("CH_Cooldown_1","Magic_Tier3");
        SkillManager.CheckAll();
    }

    public void CH_Cooldown_1_Check(){
        Check(Object: CH_Cooldown_1, Name: "CH_Cooldown_1", SkillManager.Practice_Plus, 17, Convert.ToInt32(SkillManager.CHU) + 0, 1);
    }

    public void CH_Cooldown_1_Text(){
        GetText("CH_Cooldown_1", SkillName: "CH_Cooldown", TextName: "Chaos Cooldown", Price: 5, Category: 'M', Req_C: 17, Format1: 6, Req1: "Chaos", NeedOtherUnlock: true, HasSuffix: false);
    }

    public void CH_Cooldown_1_Upgrade(){
        Upgrade(Object: CH_Cooldown_1, Name: "CH_Cooldown_1", SkillName: "CH_Cooldown", Price: 5, IsBool: false, HasSuffix: false);
        SkillManager.CheckAll();
    }

    public void SkilledTree_1_Text(){
        GetText("SkilledTree_1", TextName: "Skilled Tree Chance", Price: 2, HasCheck: false);
    }

    public void SkilledTree_1_Upgrade(){
        Upgrade(Object: SkilledTree_1, Name: "SkilledTree_1", Price: 2, Invoke1:"SkilledTree");
        
        Magic_Tier4.HP_10_2.transform.Find("Button").GetComponent<Button>().interactable = true;
        SkillManager.Checklist_Add("HP_10_2","Magic_Tier4");
        Magic_Tier4.MR_2_2.transform.Find("Button").GetComponent<Button>().interactable = true;
        SkillManager.Checklist_Add("MR_2_2","Magic_Tier4");
        Magic_Tier4.Mana_20_3.SetActive(true);
        Magic_Tier4.M_2Perc_1.SetActive(true);
        Magic_Tier4.HP_15_2.SetActive(true);
        Magic_Tier4.EV_2_ACC_2_3.SetActive(true);
        SkillManager.CheckAll();
    }
}
