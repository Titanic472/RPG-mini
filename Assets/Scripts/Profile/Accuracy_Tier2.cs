using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class Accuracy_Tier2 : SkillTreeSegment
{
    public GameObject BrutalityStreak_Unlock, ACC_3_2, BL_Chance_2, BL_ReturnDamage_2, MaxCrit_5Perc_2, HP_10_1, ACC_3_3, BrutalityStreak_EnergySave_1, BrutalityStreak_AvoidChance_1, HP_10_2, MaxCrit_5Perc_3, BL_Cooldown_1, HP_1Perc_2, EV_1_ACC_1_2, HP_10_3, EV_2_ACC_2_1, AddSlot;
    public bool BrutalityStreak_Unlock_Checked, ACC_3_2_Checked, BL_Chance_2_Checked, BL_ReturnDamage_2_Checked, MaxCrit_5Perc_2_Checked, HP_10_1_Checked, ACC_3_3_Checked, BrutalityStreak_EnergySave_1_Checked, BrutalityStreak_AvoidChance_1_Checked, HP_10_2_Checked, MaxCrit_5Perc_3_Checked, BL_Cooldown_1_Checked, HP_1Perc_2_Checked, EV_1_ACC_1_2_Checked, HP_10_3_Checked, EV_2_ACC_2_1_Checked;
    
    void Awake(){
        Class = "Accuracy_Tier2";
    }

    public void BrutalityStreak_Unlock_Check(){
        Check(Object: BrutalityStreak_Unlock, Name: "BrutalityStreak_Unlock", player.Skills["BaseAccuracy"], 20);
    }

    public void BrutalityStreak_Unlock_Text(){
        GetText("BrutalityStreak_Unlock", TextName: "Brutality Streak Unlock", Price: 4, Category: 'A', Req_C: 20, HasSuffix: false);
    }

    public void BrutalityStreak_Unlock_Upgrade(){
        Upgrade(Object: BrutalityStreak_Unlock,Name: "BrutalityStreak_Unlock", Price:4, HasSuffix: false);

        ACC_3_2.transform.Find("Button").GetComponent<Button>().interactable = true;
        SkillManager.Checklist_Add("ACC_3_2","Accuracy_Tier2");
        HP_10_2.transform.Find("Button").GetComponent<Button>().interactable = true;
        SkillManager.Checklist_Add("HP_10_2","Accuracy_Tier2");
        MaxCrit_5Perc_3.SetActive(true);
        HP_1Perc_2.SetActive(true);
        BL_Chance_2.SetActive(true);
        MaxCrit_5Perc_2.SetActive(true);
        SkillManager.CheckAll();
    }

    public void ACC_3_2_Check(){
        Check(Object: ACC_3_2, Name: "ACC_3_2", player.Skills["BaseAccuracy"], 27);
    }

    public void ACC_3_2_Text(){
        GetText("ACC_3_2", TextName: "More Accuracy", Price: 1, Category: 'A', Req_C: 27);
    }

    public void ACC_3_2_Upgrade(){
        Upgrade(Object: ACC_3_2,Name: "ACC_3_2", Price:1, Invoke1:"Accuracy");

        MaxCrit_5Perc_2.transform.Find("Button").GetComponent<Button>().interactable = true;
        SkillManager.Checklist_Add("MaxCrit_5Perc_2","Accuracy_Tier2");
        BL_Chance_2.transform.Find("Button").GetComponent<Button>().interactable = true;
        SkillManager.Checklist_Add("BL_Chance_2","Accuracy_Tier2");
        BL_ReturnDamage_2.SetActive(true);
        HP_10_1.SetActive(true);
        BrutalityStreak_AvoidChance_1.SetActive(true);
        SkillManager.CheckAll();
    }

    public void BL_Chance_2_Check(){
        Check(Object: BL_Chance_2, Name: "BL_Chance_2", player.Skills["BaseAccuracy"], 30, SkillManager.BL_Chance, 1);
    }

    public void BL_Chance_2_Text(){
        GetText("BL_Chance_2", SkillName: "BL_Chance", TextName: "Block Chance", Price: 4, Category: 'A', Req_C: 30, UpgValue: 1, Format1: 80, Req1: Language_Changer.Instance.GetText("Block_Chance"), Req1Lvl: 1, HasSuffix: false);
    }

    public void BL_Chance_2_Upgrade(){
        Upgrade(Object: BL_Chance_2,Name: "BL_Chance_2", SkillName: "BL_Chance", Price:4, IsBool: false, HasSuffix: false);

        BL_ReturnDamage_2.transform.Find("Button").GetComponent<Button>().interactable = true;
        SkillManager.Checklist_Add("BL_ReturnDamage_2","Accuracy_Tier2");
        SkillManager.CheckAll();
    }

    public void BL_ReturnDamage_2_Check(){
        Check(Object: BL_ReturnDamage_2, Name: "BL_ReturnDamage_2", player.Skills["BaseAccuracy"], 35, SkillManager.BL_ReturnDamage, 1);
    }

    public void BL_ReturnDamage_2_Text(){
        GetText("BL_ReturnDamage_2", SkillName: "BL_ReturnDamage", TextName: "Strike Back", Price: 2, Category: 'A', Req_C: 35, UpgValue: 1, Format1: 35, Req1: Language_Changer.Instance.GetText("Strike_Back"), Req1Lvl: 1, HasSuffix: false);
    }

    public void BL_ReturnDamage_2_Upgrade(){
        Upgrade(Object: BL_ReturnDamage_2,Name: "BL_ReturnDamage_2", SkillName: "BL_ReturnDamage", Price:6, IsBool: false, HasSuffix: false);
        SkillManager.CheckAll();
    }

    public void MaxCrit_5Perc_2_Check(){
        Check(Object: MaxCrit_5Perc_2, Name: "MaxCrit_5Perc_2", player.Skills["BaseAccuracy"], 30);
    }

    public void MaxCrit_5Perc_2_Text(){
        GetText("MaxCrit_5Perc_2", TextName: "Max Critical Strike Chance", Price: 3, Category: 'A', Req_C: 30, Format1: 5, Format2: player.MaxCritChance);
    }

    public void MaxCrit_5Perc_2_Upgrade(){
        Upgrade(Object: MaxCrit_5Perc_2,Name: "MaxCrit_5Perc_2", Price:3, Invoke1:"MaxCritChance");
        
        HP_10_1.transform.Find("Button").GetComponent<Button>().interactable = true;
        SkillManager.Checklist_Add("HP_10_1","Accuracy_Tier2");
        if(SkillManager.HP_1Perc_2_Accuracy_Tier2){
            BrutalityStreak_AvoidChance_1.transform.Find("Button").GetComponent<Button>().interactable = true;
            SkillManager.Checklist_Add("BrutalityStreak_AvoidChance_1","Accuracy_Tier2");
        }
        ACC_3_3.SetActive(true);
        AddSlot.SetActive(true);
        EV_1_ACC_1_2.SetActive(true);
        SkillManager.CheckAll();
    }

    public void HP_10_1_Check(){
        Check(Object: HP_10_1, Name: "HP_10_1", player.Skills["BaseAccuracy"], 35);
    }

    public void HP_10_1_Text(){
        GetText("HP_10_1", TextName: "Additional Health", DescriptionName: "HP 10 Description", Price: 2, Category: 'A', Req_C: 35);
    }

    public void HP_10_1_Upgrade(){
        Upgrade(Object: HP_10_1,Name: "HP_10_1", Price:2, Invoke1:"Health");

        if(SkillManager.EV_1_ACC_1_2_Accuracy_Tier2){
            AddSlot.transform.Find("Button").GetComponent<Button>().interactable = true;
            AddSlot.transform.Find("Glowing_Yellow").gameObject.SetActive(true);
        }
        ACC_3_3.transform.Find("Button").GetComponent<Button>().interactable = true;
        SkillManager.Checklist_Add("ACC_3_3","Accuracy_Tier2");
        BrutalityStreak_EnergySave_1.SetActive(true);;
        SkillManager.CheckAll();
    }

    public void ACC_3_3_Check(){
        Check(Object: ACC_3_3, Name: "ACC_3_3", player.Skills["BaseAccuracy"], 38);
    }

    public void ACC_3_3_Text(){
        GetText("ACC_3_3", TextName: "More Accuracy", Price: 1, Category: 'A', Req_C: 38);
    }

    public void ACC_3_3_Upgrade(){
        Upgrade(Object: ACC_3_3,Name: "ACC_3_3", Price:1, Invoke1:"Accuracy");
        
        BrutalityStreak_EnergySave_1.transform.Find("Button").GetComponent<Button>().interactable = true;
        SkillManager.Checklist_Add("BrutalityStreak_EnergySave_1","Accuracy_Tier2");
        SkillManager.CheckAll();
    }

    public void BrutalityStreak_EnergySave_1_Check(){
        Check(Object: BrutalityStreak_EnergySave_1, Name: "BrutalityStreak_EnergySave_1", player.Skills["BaseAccuracy"], 40);
    }

    public void BrutalityStreak_EnergySave_1_Text(){
        GetText("BrutalityStreak_EnergySave_1", SkillName: "BrutalityStreak_EnergySave", TextName: "Energy Saving", Price: 5, Category: 'A', Req_C: 40, Format1: 2, HasSuffix: false);
    }

    public void BrutalityStreak_EnergySave_1_Upgrade(){
        Upgrade(Object: BrutalityStreak_EnergySave_1,Name: "BrutalityStreak_EnergySave_1", SkillName: "BrutalityStreak_EnergySave", Price:5, IsBool: false, HasSuffix: false);
        SkillManager.CheckAll();
    }

    public void BrutalityStreak_AvoidChance_1_Check(){
        Check(Object: BrutalityStreak_AvoidChance_1, Name: "BrutalityStreak_AvoidChance_1", player.Skills["BaseAccuracy"], 45);
    }

    public void BrutalityStreak_AvoidChance_1_Text(){
        GetText("BrutalityStreak_AvoidChance_1", SkillName: "BrutalityStreak_AvoidChance", TextName: "Brutality Streak Mob Avoid Chance", Price: 6, Category: 'A', Req_C: 45, Format1: 7, HasSuffix: false);
    }

    public void BrutalityStreak_AvoidChance_1_Upgrade(){
        Upgrade(Object: BrutalityStreak_AvoidChance_1,Name: "BrutalityStreak_AvoidChance_1", SkillName: "BrutalityStreak_AvoidChance", Price:6, IsBool: false, HasSuffix: false);
        SkillManager.CheckAll();
    }

    public void HP_10_2_Check(){
        Check(Object: HP_10_2, Name: "HP_10_2", player.Skills["BaseAccuracy"], 25);
    }

    public void HP_10_2_Text(){
        GetText("HP_10_2", TextName: "Additional Health", DescriptionName: "HP 10 Description", Price: 2, Category: 'A', Req_C: 25);
    }

    public void HP_10_2_Upgrade(){
        Upgrade(Object: HP_10_2,Name: "HP_10_2", Price:2, Invoke1:"Health");
       
        MaxCrit_5Perc_3.transform.Find("Button").GetComponent<Button>().interactable = true;
        SkillManager.Checklist_Add("MaxCrit_5Perc_3","Accuracy_Tier2");
        HP_1Perc_2.transform.Find("Button").GetComponent<Button>().interactable = true;
        SkillManager.Checklist_Add("HP_1Perc_2","Accuracy_Tier2");
        BrutalityStreak_AvoidChance_1.SetActive(true);
        BL_Cooldown_1.SetActive(true);
        EV_1_ACC_1_2.SetActive(true);
        SkillManager.CheckAll();
    }

    public void MaxCrit_5Perc_3_Check(){
        Check(Object: MaxCrit_5Perc_3, Name: "MaxCrit_5Perc_3", player.Skills["BaseAccuracy"], 28);
    }

    public void MaxCrit_5Perc_3_Text(){
        GetText("MaxCrit_5Perc_3", TextName: "Max Critical Strike Chance", Price: 3, Category: 'A', Req_C: 28, Format1: 5, Format2: player.MaxCritChance);
    }

    public void MaxCrit_5Perc_3_Upgrade(){
        Upgrade(Object: MaxCrit_5Perc_3,Name: "MaxCrit_5Perc_3", Price:3, Invoke1:"MaxCritChance");
        
        BL_Cooldown_1.transform.Find("Button").GetComponent<Button>().interactable = true;
        SkillManager.Checklist_Add("BL_Cooldown_1","Accuracy_Tier2");
        SkillManager.CheckAll();
    }

    public void BL_Cooldown_1_Check(){
        Check(Object: BL_Cooldown_1, Name: "BL_Cooldown_1", player.Skills["BaseAccuracy"], 32);
    }

    public void BL_Cooldown_1_Text(){
        GetText("BL_Cooldown_1", SkillName: "BL_Cooldown", TextName: "Block Cooldown", Price: 5, Category: 'A', Req_C: 32, Format1: 5, HasSuffix: false);
    }

    public void BL_Cooldown_1_Upgrade(){
        Upgrade(Object: BL_Cooldown_1,Name: "BL_Cooldown_1", SkillName: "BL_Cooldown", Price:5, IsBool: false, HasSuffix: false);
        SkillManager.CheckAll();
    }

    public void HP_1Perc_2_Check(){
        Check(Object: HP_1Perc_2, Name: "HP_1Perc_2", player.Skills["BaseAccuracy"], 30);
    }

    public void HP_1Perc_2_Text(){
        GetText("HP_1Perc_2", TextName: "More Health", Price: 2, Category: 'A', Req_C: 30, Format1: 1);
    }

    public void HP_1Perc_2_Upgrade(){
        Upgrade(Object: HP_1Perc_2,Name: "HP_1Perc_2", Price:2, Invoke1:"HealthModifier");

        if(SkillManager.MaxCrit_5Perc_2_Accuracy_Tier2){
            BrutalityStreak_AvoidChance_1.transform.Find("Button").GetComponent<Button>().interactable = true;
            SkillManager.Checklist_Add("BrutalityStreak_AvoidChance_1","Accuracy_Tier2");
        }
        EV_1_ACC_1_2.transform.Find("Button").GetComponent<Button>().interactable = true;
        SkillManager.Checklist_Add("EV_1_ACC_1_2","Accuracy_Tier2");
        HP_10_3.SetActive(true);
        AddSlot.SetActive(true);
        HP_10_1.SetActive(true);
        SkillManager.CheckAll();
    }

    public void EV_1_ACC_1_2_Check(){
        Check(Object: EV_1_ACC_1_2, Name: "EV_1_ACC_1_2", player.Skills["BaseAccuracy"], 35);
    }

    public void EV_1_ACC_1_2_Text(){
        GetText("EV_1_ACC_1_2", TextName: "Universal Set", Price: 1, Category: 'A', Req_C: 35, Format1: 1);
    }

    public void EV_1_ACC_1_2_Upgrade(){
        Upgrade(Object: EV_1_ACC_1_2,Name: "EV_1_ACC_1_2", Price:1, Invoke1:"Evasion", Invoke2:"Accuracy");

        if(SkillManager.HP_10_1_Accuracy_Tier2){
            AddSlot.transform.Find("Button").GetComponent<Button>().interactable = true;
            AddSlot.transform.Find("Glowing_Yellow").gameObject.SetActive(true);
        }
        HP_10_3.transform.Find("Button").GetComponent<Button>().interactable = true;
        SkillManager.Checklist_Add("HP_10_3","Accuracy_Tier2");
        EV_2_ACC_2_1.SetActive(true);
        SkillManager.CheckAll();
    }

    public void HP_10_3_Check(){
        Check(Object: HP_10_3, Name: "HP_10_3", player.Skills["BaseAccuracy"],38 );
    }

    public void HP_10_3_Text(){
        GetText("HP_10_3", TextName: "Additional Health", DescriptionName: "HP 10 Description", Price: 2, Category: 'A', Req_C: 38);
    }

    public void HP_10_3_Upgrade(){
        Upgrade(Object: HP_10_3,Name: "HP_10_3", Price:2, Invoke1:"Health");
    
        EV_2_ACC_2_1.transform.Find("Button").GetComponent<Button>().interactable = true;
        SkillManager.Checklist_Add("EV_2_ACC_2_1","Accuracy_Tier2");
        SkillManager.CheckAll();
    }

    public void EV_2_ACC_2_1_Check(){
        Check(Object: EV_2_ACC_2_1, Name: "EV_2_ACC_2_1", player.Skills["BaseAccuracy"], 40);
    }

    public void EV_2_ACC_2_1_Text(){
        GetText("EV_2_ACC_2_1", TextName: "Universal Set", Price: 2, Category: 'A', Req_C: 40, Format1: 2);
    }

    public void EV_2_ACC_2_1_Upgrade(){
        Upgrade(Object: EV_2_ACC_2_1,Name: "EV_2_ACC_2_1", Price:2, Invoke1:"Evasion", Invoke2:"Accuracy");
        SkillManager.CheckAll();
    }

    public void AddSlot_Text(){
        GetText("AddSlot", TextName: "Additional Slot", Price: 5, HasCheck: false);
    }

    public void AddSlot_Upgrade(){
        Upgrade(Object: AddSlot,Name: "AddSlot", Price:5, Invoke1:"ActiveSkillsSlots");
        SkillManager.CheckAll();
    }
}