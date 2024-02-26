using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class Magic_Tier2 : SkillTreeSegment
{
    public GameObject ManaOverdrain_Unlock, ManaOverdrain_Perc_1, HP_5_2, Mana_10_3, BS_Cooldown_2, BS_UnlockWeakness, BS_Damage_2, BS_NoEvasion, HP_10_1, Mana_10_4, EV_2_ACC_2_1, MR_1_3, AddSlot, Mana_10_5, MR_1_2, EV_1_ACC_1_2, ManaOverdrain_Potion_1;
    public bool ManaOverdrain_Unlock_Checked, ManaOverdrain_Perc_1_Checked, BS_Cooldown_2_Checked, BS_UnlockWeakness_Checked, BS_Damage_2_Checked, BS_NoEvasion_Checked, HP_10_1_Checked, Mana_10_4_Checked, EV_2_ACC_2_1_Checked, MR_1_3_Checked, Mana_10_5_Checked, MR_1_2_Checked, EV_1_ACC_1_2_Checked, ManaOverdrain_Potion_1_Checked;
    public Magic_Tier3 Magic_Tier3;

    void Awake(){
        Class = "Magic_Tier2";
    }

    public void ManaOverdrain_Unlock_Check(){
        Check(Object: ManaOverdrain_Unlock, Name: "ManaOverdrain_Unlock", SkillManager.Practice_Plus, 7);
    }

    public void ManaOverdrain_Unlock_Text(){
        GetText("ManaOverdrain_Unlock", SkillName: "ManaOverdrain", TextName: "Mana Overdrain", Price: 2, Category: 'M', Req_C: 7, HasSuffix: false);
    }

    public void ManaOverdrain_Unlock_Upgrade(){
        Upgrade(Object: ManaOverdrain_Unlock,SkillName: "ManaOverdrain", Name: "ManaOverdrain_Unlock", Price: 2, HasSuffix: false);
        
        ManaOverdrain_Perc_1.transform.Find("Button").GetComponent<Button>().interactable = true;
        SkillManager.Checklist_Add("ManaOverdrain_Perc_1","Magic_Tier2");
        HP_10_1.transform.Find("Button").GetComponent<Button>().interactable = true;
        SkillManager.Checklist_Add("HP_10_1","Magic_Tier2");
        Mana_10_5.transform.Find("Button").GetComponent<Button>().interactable = true;
        SkillManager.Checklist_Add("Mana_10_5","Magic_Tier2");
        BS_Cooldown_2.transform.Find("Button").GetComponent<Button>().interactable = true;
        SkillManager.Checklist_Add("BS_Cooldown_2","Magic_Tier2");
        HP_5_2.SetActive(true);
        Mana_10_3.SetActive(true);
        Mana_10_4.SetActive(true);
        MR_1_2.SetActive(true);
        BS_Damage_2.SetActive(true);
        BS_UnlockWeakness.SetActive(true);
        BS_NoEvasion.SetActive(true);
        SkillManager.CheckAll();
    }

    public void ManaOverdrain_Perc_1_Check(){
        Check(Object: ManaOverdrain_Perc_1, Name: "ManaOverdrain_Perc_1", SkillManager.Practice_Plus, 9);
    }

    public void ManaOverdrain_Perc_1_Text(){
        GetText("ManaOverdrain_Perc_1", SkillName: "ManaOverdrain_Perc", TextName: "Mana Overdrain Percent", Price: 2, Category: 'M', Req_C: 9, Format1: 15, HasSuffix: false);
    }

    public void ManaOverdrain_Perc_1_Upgrade(){
        Upgrade(Object: ManaOverdrain_Perc_1,Name: "ManaOverdrain_Perc_1", SkillName: "ManaOverdrain_Perc", Price: 2, IsBool: false, HasSuffix: false);
        
        HP_5_2.transform.Find("Button").GetComponent<Button>().interactable = true;
        HP_5_2.transform.Find("Glowing_Yellow").gameObject.SetActive(true);
        Mana_10_3.transform.Find("Button").GetComponent<Button>().interactable = true;
        Mana_10_3.transform.Find("Glowing_Yellow").gameObject.SetActive(true);
        SkillManager.CheckAll();
    }

    public void HP_5_2_Text(){
        GetText("HP_5_2", TextName: "Additional Health", DescriptionName: "HP 5 Description", Price: 1, HasCheck: false);
    }

    public void HP_5_2_Upgrade(){
        Upgrade(Object: HP_5_2,Name: "HP_5_2", Price: 1, Invoke1:"Health");
    }

    public void Mana_10_3_Text(){
        GetText("Mana_10_3", TextName: "More Mana", Price: 3, HasCheck: false);
    }

    public void Mana_10_3_Upgrade(){
        Upgrade(Object: Mana_10_3,Name: "Mana_10_3", Price: 3, Invoke1:"Mana");
    }

    public void BS_Cooldown_2_Check(){
        Check(Object: BS_Cooldown_2, Name: "BS_Cooldown_2", SkillManager.Practice_Plus, 8, SkillManager.BS_Cooldown, 1);
    }

    public void BS_Cooldown_2_Text(){
        GetText("BS_Cooldown_2", SkillName: "BS_Cooldown", TextName: "Beginner Cooldown", Price: 3, Category: 'M', Req_C: 8, UpgValue: 1, Format1: 6, Req1: "Beginner Cooldown", Req1Lvl: 1, HasSuffix: false);
    }

    public void BS_Cooldown_2_Upgrade(){
        Upgrade(Object: BS_Cooldown_2, Name: "BS_Cooldown_2", SkillName: "BS_Cooldown", Price: 3, IsBool: false, HasSuffix: false);

        BS_Damage_2.transform.Find("Button").GetComponent<Button>().interactable = true;
        SkillManager.Checklist_Add("BS_Damage_2","Magic_Tier2");
        BS_UnlockWeakness.transform.Find("Button").GetComponent<Button>().interactable = true;
        SkillManager.Checklist_Add("BS_UnlockWeakness","Magic_Tier2");
        BS_NoEvasion.transform.Find("Button").GetComponent<Button>().interactable = true;
        SkillManager.Checklist_Add("BS_NoEvasion","Magic_Tier2");
        SkillManager.CheckAll();
    }

    public void BS_Damage_2_Check(){
        Check(Object: BS_Damage_2, Name: "BS_Damage_2", SkillManager.Practice_Plus, 10, SkillManager.BS_Damage, 1);
    }

    public void BS_Damage_2_Text(){
        GetText("BS_Damage_2", SkillName: "BS_Damage", TextName: "Beginner Damage", Price: 4, Category: 'M', Req_C: 10, UpgValue: 1, Format1: 30, Req1: "Beginner Damage", Req1Lvl: 1, HasSuffix: false);
    }

    public void BS_Damage_2_Upgrade(){
        Upgrade(Object: BS_Damage_2,Name: "BS_Damage_2", SkillName: "BS_Damage", Price: 4, IsBool: false, HasSuffix: false);
        SkillManager.CheckAll();
    }

    public void BS_UnlockWeakness_Check(){
        Check(Object: BS_UnlockWeakness, Name: "BS_UnlockWeakness", SkillManager.Practice_Plus, 10);
    }

    public void BS_UnlockWeakness_Text(){
        GetText("BS_UnlockWeakness", TextName: "More Effects", Price: 5, Category: 'M', Req_C: 10, HasSuffix: false);
    }

    public void BS_UnlockWeakness_Upgrade(){
        Upgrade(Object: BS_UnlockWeakness,Name: "BS_UnlockWeakness", Price: 5, HasSuffix: false);
    }

    public void BS_NoEvasion_Check(){
        Check(Object: BS_NoEvasion, Name: "BS_NoEvasion", SkillManager.Practice_Plus, 11);
    }

    public void BS_NoEvasion_Text(){
        GetText("BS_NoEvasion", TextName: "Perfect Accuracy", Price:4 , Category: 'M', Req_C: 11, HasSuffix: false);
    }

    public void BS_NoEvasion_Upgrade(){
        Upgrade(Object: BS_NoEvasion,Name: "BS_NoEvasion", Price: 4, HasSuffix: false);
        SkillManager.CheckAll();
    }

    public void HP_10_1_Check(){
        Check(Object: HP_10_1, Name: "HP_10_1", SkillManager.Practice_Plus, 9);
    }

    public void HP_10_1_Text(){
        GetText("HP_10_1", TextName: "Additional Health", DescriptionName: "HP 10 Description", Price: 3, Category: 'M', Req_C: 9);
    }

    public void HP_10_1_Upgrade(){
        Upgrade(Object: HP_10_1,Name: "HP_10_1", Price: 3, Invoke1:"Health");

        Mana_10_4.transform.Find("Button").GetComponent<Button>().interactable = true;
        SkillManager.Checklist_Add("Mana_10_4","Magic_Tier2");
        MR_1_2.SetActive(true);
        AddSlot.SetActive(true);
        EV_2_ACC_2_1.SetActive(true);
        MR_1_3.SetActive(true);
        SkillManager.CheckAll();

    }

    public void Mana_10_4_Check(){
        Check(Object: Mana_10_4, Name: "Mana_10_4", SkillManager.Practice_Plus, 10);
    }

    public void Mana_10_4_Text(){
        GetText("Mana_10_4", TextName: "More Mana", Price: 3, Category: 'M', Req_C: 10);
    }

    public void Mana_10_4_Upgrade(){
        Upgrade(Object: Mana_10_4,Name: "Mana_10_4", Price: 3, Invoke1:"Mana");
        
        if(SkillManager.MR_1_2_Magic_Tier2){
            AddSlot.transform.Find("Button").GetComponent<Button>().interactable = true;
            AddSlot.transform.Find("Glowing_Yellow").gameObject.SetActive(true);
            Magic_Tier3.DMG_Resistance_1_1.SetActive(true);
        }
        MR_1_3.transform.Find("Button").GetComponent<Button>().interactable = true;
        SkillManager.Checklist_Add("MR_1_3","Magic_Tier2");
        EV_2_ACC_2_1.transform.Find("Button").GetComponent<Button>().interactable = true;
        SkillManager.Checklist_Add("EV_2_ACC_2_1","Magic_Tier2");
        SkillManager.CheckAll();
    }

    public void EV_2_ACC_2_1_Check(){
        Check(Object: EV_2_ACC_2_1, Name: "EV_2_ACC_2_1", SkillManager.Practice_Plus, 11);
    }

    public void EV_2_ACC_2_1_Text(){
        GetText("EV_2_ACC_2_1", TextName: "Universal Set", Price: 2, Category: 'M', Req_C: 11, Format1: 2);
    }

    public void EV_2_ACC_2_1_Upgrade(){
        Upgrade(Object: EV_2_ACC_2_1,Name: "EV_2_ACC_2_1", Price: 2, Invoke1:"Evasion", Invoke2:"Accuracy");
        SkillManager.CheckAll();
    }

    public void MR_1_3_Check(){
        Check(Object: MR_1_3, Name: "MR_1_3", SkillManager.Practice_Plus, 10);
    }

    public void MR_1_3_Text(){
        GetText("MR_1_3", TextName: "Mana Regeneration", Price: 4, Category: 'M', Req_C: 10, Format1: 1);
    }

    public void MR_1_3_Upgrade(){
        Upgrade(Object: MR_1_3,Name: "MR_1_3", Price: 4, Invoke1:"ManaRegen");
    }

    public void Mana_10_5_Check(){
        Check(Object: Mana_10_5, Name: "Mana_10_5", SkillManager.Practice_Plus, 8);
    }

    public void Mana_10_5_Text(){
        GetText("Mana_10_5", TextName: "More Mana", Price: 3, Category: 'M', Req_C: 8);
    }

    public void Mana_10_5_Upgrade(){
        Upgrade(Object: Mana_10_5,Name: "Mana_10_5", Price: 3, Invoke1:"Mana");

        MR_1_2.transform.Find("Button").GetComponent<Button>().interactable = true;
        SkillManager.Checklist_Add("MR_1_2","Magic_Tier2");
        AddSlot.SetActive(true);
        EV_1_ACC_1_2.SetActive(true);
        Mana_10_4.SetActive(true);
        ManaOverdrain_Potion_1.SetActive(true);
        SkillManager.CheckAll();
    }

    public void MR_1_2_Check(){
        Check(Object: MR_1_2, Name: "MR_1_2", SkillManager.Practice_Plus, 9);
    }

    public void MR_1_2_Text(){
        GetText("MR_1_2", TextName: "Mana Regeneration", Price: 5, Category: 'M', Req_C: 9, Format1: 1);
    }

    public void MR_1_2_Upgrade(){
        Upgrade(Object: MR_1_2,Name: "MR_1_2", Price: 5, Invoke1:"ManaRegen");

        if(SkillManager.Mana_10_4_Magic_Tier2){
            AddSlot.transform.Find("Button").GetComponent<Button>().interactable = true;
            AddSlot.transform.Find("Glowing_Yellow").gameObject.SetActive(true);
            Magic_Tier3.DMG_Resistance_1_1.SetActive(true);
        }
        EV_1_ACC_1_2.transform.Find("Button").GetComponent<Button>().interactable = true;
        SkillManager.Checklist_Add("EV_1_ACC_1_2","Magic_Tier2");
        ManaOverdrain_Potion_1.transform.Find("Button").GetComponent<Button>().interactable = true;
        SkillManager.Checklist_Add("ManaOverdrain_Potion_1","Magic_Tier2");
        SkillManager.CheckAll();
    }

    public void EV_1_ACC_1_2_Check(){
        Check(Object: EV_1_ACC_1_2, Name: "EV_1_ACC_1_2", SkillManager.Practice_Plus, 9);
    }

    public void EV_1_ACC_1_2_Text(){
        GetText("EV_1_ACC_1_2", TextName: "Universal Set", Price: 1, Category: 'M', Req_C: 9, Format1: 1);
    }

    public void EV_1_ACC_1_2_Upgrade(){
        Upgrade(Object: EV_1_ACC_1_2,Name: "EV_1_ACC_1_2", Price: 1, Invoke1:"Evasion", Invoke2:"Accuracy");
        SkillManager.CheckAll();
    }

    public void ManaOverdrain_Potion_1_Check(){
        Check(Object: ManaOverdrain_Potion_1, Name: "ManaOverdrain_Potion_1", SkillManager.Practice_Plus, 12);
    }

    public void ManaOverdrain_Potion_1_Text(){
        GetText("ManaOverdrain_Potion_1", SkillName: "ManaOverdrain_Potion", TextName: "Mana Overdrain Potion", Price: 4, Category: 'M', Req_C: 12, Format1: 1, HasSuffix: false);
    }

    public void ManaOverdrain_Potion_1_Upgrade(){
        Upgrade(Object: ManaOverdrain_Potion_1,Name: "ManaOverdrain_Potion_1", SkillName: "ManaOverdrain_Potion", Price: 4, IsBool: false, HasSuffix: false);
        SkillManager.CheckAll();
    }

    public void AddSlot_Text(){
        GetText("AddSlot", TextName: "Additional Slot", Price: 5, HasCheck: false);
    }

    public void AddSlot_Upgrade(){
        Upgrade(Object: AddSlot,Name: "AddSlot", Price:5, Invoke1:"ActiveSkillsSlots");

        Magic_Tier3.DMG_Resistance_1_1.transform.Find("Button").GetComponent<Button>().interactable = true;
        SkillManager.Checklist_Add("DMG_Resistance_1_1","Magic_Tier3");
        Magic_Tier3.EV_2_ACC_2_2.SetActive(true);
        Magic_Tier3.CHU.SetActive(true);
        Magic_Tier3.MCost_1Perc_1.SetActive(true);
        Magic_Tier3.BS_Mana_2.SetActive(true);
        Magic_Tier3.HP_5_3.SetActive(true);
        Magic_Tier3.MR_1_4.SetActive(true);
        Magic_Tier3.AtkSpeed_1_1.SetActive(true);
        Magic_Tier3.Mana_20_2.SetActive(true);
        SkillManager.CheckAll();
    }

}
