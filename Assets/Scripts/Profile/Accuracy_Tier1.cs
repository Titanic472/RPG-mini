using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class Accuracy_Tier1 : SkillTreeSegment
{
    public GameObject AccuracyMain, HP_5_1, MaxCrit_5Perc_1, BLU, BL_ReturnDamage_1, BL_Chance_1, ACC_3_1, WeaponSkillChance_2Perc_1, HP_5_2, WeaponSkillChance_3Perc_1, EV_1_ACC_1_1, HP_5_3, HP_1Perc_1;
    public bool HP_5_1_Checked, MaxCrit_5Perc_1_Checked, BLU_Checked, BL_ReturnDamage_1_Checked, BL_Chance_1_Checked, ACC_3_1_Checked, WeaponSkillChance_2Perc_1_Checked, HP_5_2_Checked, WeaponSkillChance_3Perc_1_Checked, EV_1_ACC_1_1_Checked, HP_5_3_Checked;
    public Accuracy_Tier2 Accuracy_Tier2;

    void Awake(){
        Class = "Accuracy_Tier1";
    } 
    
    public void AccuracyMain_Text(){
        GetText("AccuracyMain", TextName: "Accuracy", DescriptionName: "AccuracyMain", Price: 1, Format1: player.Skills["BaseAccuracy"], InfiniteUpgrade: true);
    }

    public void AccuracyMain_Upgrade(){
        Upgrade(Object: AccuracyMain, Name: "AccuracyMain", Price:1, Invoke1:"Accuracy", IsBool:false, MoreUpgrades:true, HasSuffix: false);

        if(SkillManager.AccuracyMain==1){
            MaxCrit_5Perc_1.transform.Find("Button").GetComponent<Button>().interactable = true;
            SkillManager.Checklist_Add("MaxCrit_5Perc_1","Accuracy_Tier1");
            HP_5_1.transform.Find("Button").GetComponent<Button>().interactable = true;
            SkillManager.Checklist_Add("HP_5_1","Accuracy_Tier1");
            WeaponSkillChance_2Perc_1.transform.Find("Button").GetComponent<Button>().interactable = true;
            SkillManager.Checklist_Add("WeaponSkillChance_2Perc_1","Accuracy_Tier1");
            BLU.SetActive(true);
            ACC_3_1.SetActive(true);
            EV_1_ACC_1_1.SetActive(true);
            HP_5_2.SetActive(true);
        }
        SkillManager.CheckAll();
    }

    public void MaxCrit_5Perc_1_Check(){
        Check(MaxCrit_5Perc_1, Name: "MaxCrit_5Perc_1", player.Skills["BaseAccuracy"], 8);
    }

    public void MaxCrit_5Perc_1_Text(){
        GetText("MaxCrit_5Perc_1", TextName: "Max Critical Strike Chance", Price:2, Category:'A', Req_C:8, Format1: 5, Format2:player.MaxCritChance);
    }

    public void MaxCrit_5Perc_1_Upgrade(){
        Upgrade(MaxCrit_5Perc_1, Name: "MaxCrit_5Perc_1", Price: 2, Invoke1: "MaxCritChance");
        
        BLU.transform.Find("Button").GetComponent<Button>().interactable = true;
        SkillManager.Checklist_Add("BLU","Accuracy_Tier1");
        BL_ReturnDamage_1.SetActive(true);
        BL_Chance_1.SetActive(true);
        SkillManager.CheckAll();
    }

    public void BLU_Check(){
        Check(Object: BLU, Name: "BLU", player.Skills["BaseAccuracy"], 10);
    }

    public void BLU_Text(){
        GetText("BLU", TextName: "Block Unlock", Price: 5, Category: 'A', Req_C: 10, HasSuffix: false);
    }

    public void BLU_Upgrade(){
        Upgrade(Object: BLU, Name: "BLU", Price:5, HasSuffix: false);

        BL_ReturnDamage_1.transform.Find("Button").GetComponent<Button>().interactable = true;
        SkillManager.Checklist_Add("BL_ReturnDamage_1","Accuracy_Tier1");
        BL_Chance_1.transform.Find("Button").GetComponent<Button>().interactable = true;
        SkillManager.Checklist_Add("BL_Chance_1","Accuracy_Tier1");
        if(SkillManager.HP_5_1_Accuracy_Tier1){
            ACC_3_1.transform.Find("Button").GetComponent<Button>().interactable = true;
            SkillManager.Checklist_Add("ACC_3_1","Accuracy_Tier1");
            HP_1Perc_1.SetActive(true);
        }
        SkillManager.ActiveSkillsManager.SkillsUnlockCheck();
        SkillManager.CheckAll();
    }

    public void BL_ReturnDamage_1_Check(){
        Check(Object: BL_ReturnDamage_1, Name: "BL_ReturnDamage_1", player.Skills["BaseAccuracy"], 15);
    }

    public void BL_ReturnDamage_1_Text(){
        GetText("BL_ReturnDamage_1", SkillName: "BL_ReturnDamage", TextName: "Strike Back", Price: 3, Category: 'A', Req_C: 15, Format1: 25, HasSuffix: false);
    }

    public void BL_ReturnDamage_1_Upgrade(){
        Upgrade(Object: BL_ReturnDamage_1,Name: "BL_ReturnDamage_1", SkillName: "BL_ReturnDamage", Price:3, IsBool: false, HasSuffix: false);
        SkillManager.CheckAll();
    }

    public void BL_Chance_1_Check(){
        Check(Object: BL_Chance_1, Name: "BL_Chance_1", player.Skills["BaseAccuracy"], 20);
    }

    public void BL_Chance_1_Text(){
        GetText("BL_Chance_1", SkillName: "BL_Chance", TextName: "Block Chance", Price: 3, Category: 'A', Req_C: 20, Format1: 70, HasSuffix: false);
    }

    public void BL_Chance_1_Upgrade(){
        Upgrade(Object: BL_Chance_1,Name: "BL_Chance_1", SkillName: "BL_Chance", Price:3, IsBool: false, HasSuffix: false);
        SkillManager.CheckAll();
    }

    public void ACC_3_1_Check(){
        Check(Object: ACC_3_1, Name: "ACC_3_1", player.Skills["BaseAccuracy"], 15);
    }

    public void ACC_3_1_Text(){
        GetText("ACC_3_1", TextName: "More Accuracy", Price: 1, Category: 'A', Req_C: 15);
    }

    public void ACC_3_1_Upgrade(){
        Upgrade(Object: ACC_3_1,Name: "ACC_3_1", Price:1, Invoke1:"Accuracy");

        if(SkillManager.EV_1_ACC_1_1_Accuracy_Tier1){
            HP_1Perc_1.transform.Find("Button").GetComponent<Button>().interactable = true;
            HP_1Perc_1.transform.Find("Glowing_Yellow").gameObject.SetActive(true);
            Accuracy_Tier2.BrutalityStreak_Unlock.SetActive(true);
        }
        SkillManager.CheckAll();
    }

    public void HP_5_1_Check(){
        Check(Object: HP_5_1, Name: "HP_5_1", player.Skills["BaseAccuracy"], 10);
    }

    public void HP_5_1_Text(){
        GetText("HP_5_1", TextName: "Additional Health", DescriptionName: "HP 5 Description", Price: 1, Category: 'A', Req_C: 10);
    }

    public void HP_5_1_Upgrade(){
        Upgrade(Object: HP_5_1,Name: "HP_5_1", Price:1, Invoke1:"Health");
        if(SkillManager.BLU){
            ACC_3_1.transform.Find("Button").GetComponent<Button>().interactable = true;
            SkillManager.Checklist_Add("ACC_3_1","Accuracy_Tier1");
            HP_1Perc_1.SetActive(true);
        }
        if(SkillManager.HP_5_2_Accuracy_Tier1){
            EV_1_ACC_1_1.transform.Find("Button").GetComponent<Button>().interactable = true;
            SkillManager.Checklist_Add("EV_1_ACC_1_1","Accuracy_Tier1");
            HP_1Perc_1.SetActive(true);
        }
        SkillManager.CheckAll();
    }

    public void WeaponSkillChance_2Perc_1_Check(){
        Check(Object: WeaponSkillChance_2Perc_1, Name: "WeaponSkillChance_2Perc_1", player.Skills["BaseAccuracy"], 8);
    }

    public void WeaponSkillChance_2Perc_1_Text(){
        GetText("WeaponSkillChance_2Perc_1", TextName: "Weapon Ability Chance", Price: 2, Category: 'A', Req_C: 8, Format1: 2);
    }

    public void WeaponSkillChance_2Perc_1_Upgrade(){
        Upgrade(Object: WeaponSkillChance_2Perc_1,Name: "WeaponSkillChance_2Perc_1", Price:2, Invoke1:"WeaponSkillChance");

        HP_5_2.transform.Find("Button").GetComponent<Button>().interactable = true;
        SkillManager.Checklist_Add("HP_5_2","Accuracy_Tier1");
        WeaponSkillChance_3Perc_1.SetActive(true);
        HP_5_3.SetActive(true);
        SkillManager.CheckAll();
    }

    public void HP_5_2_Check(){
        Check(Object: HP_5_2, Name: "HP_5_2", player.Skills["BaseAccuracy"], 12);
    }

    public void HP_5_2_Text(){
        GetText("HP_5_2", TextName: "Additional Health", DescriptionName: "HP 5 Description", Price: 1, Category: 'A', Req_C: 12);
    }

    public void HP_5_2_Upgrade(){
        Upgrade(Object: HP_5_2,Name: "HP_5_2", Price:1, Invoke1:"Health");

        HP_5_3.transform.Find("Button").GetComponent<Button>().interactable = true;
        SkillManager.Checklist_Add("HP_5_3","Accuracy_Tier1");
        WeaponSkillChance_3Perc_1.transform.Find("Button").GetComponent<Button>().interactable = true;
        SkillManager.Checklist_Add("WeaponSkillChance_3Perc_1","Accuracy_Tier1");
        if(SkillManager.HP_5_1_Accuracy_Tier1){
            EV_1_ACC_1_1.transform.Find("Button").GetComponent<Button>().interactable = true;
            SkillManager.Checklist_Add("EV_1_ACC_1_1","Accuracy_Tier1");
            HP_1Perc_1.SetActive(true);
        }
        SkillManager.CheckAll();
    }

    public void HP_5_3_Check(){
        Check(Object: HP_5_3, Name: "HP_5_3", player.Skills["BaseAccuracy"], 12);
    }

    public void HP_5_3_Text(){
        GetText("HP_5_3", TextName: "Additional Health", DescriptionName: "HP 5 Description", Price: 1, Category: 'A', Req_C: 15);
    }

    public void HP_5_3_Upgrade(){
        Upgrade(Object: HP_5_3,Name: "HP_5_3", Price:1, Invoke1:"Health");
    }

    public void WeaponSkillChance_3Perc_1_Check(){
        Check(Object: WeaponSkillChance_3Perc_1, Name: "WeaponSkillChance_3Perc_1", player.Skills["BaseAccuracy"], 18);
    }

    public void WeaponSkillChance_3Perc_1_Text(){
        GetText("WeaponSkillChance_3Perc_1", TextName: "Weapon Ability Chance", Price: 2, Category: 'A', Req_C: 18, Format1: 3);
    }

    public void WeaponSkillChance_3Perc_1_Upgrade(){
        Upgrade(Object: WeaponSkillChance_3Perc_1,Name: "WeaponSkillChance_3Perc_1", Price:2, Invoke1:"WeaponSkillChance");
        SkillManager.CheckAll();
    }

    public void EV_1_ACC_1_1_Check(){
        Check(Object: EV_1_ACC_1_1, Name: "EV_1_ACC_1_1", player.Skills["BaseAccuracy"], 15);
    }

    public void EV_1_ACC_1_1_Text(){
        GetText("EV_1_ACC_1_1", TextName: "Universal Set", Price: 1, Category: 'A', Req_C: 15, Format1: 1);
    }

    public void EV_1_ACC_1_1_Upgrade(){
        Upgrade(Object: EV_1_ACC_1_1,Name: "EV_1_ACC_1_1", Price:1, Invoke1:"Evasion", Invoke2:"Accuracy");

        if(SkillManager.ACC_3_1_Accuracy_Tier1){
            HP_1Perc_1.transform.Find("Button").GetComponent<Button>().interactable = true;
            HP_1Perc_1.transform.Find("Glowing_Yellow").gameObject.SetActive(true);
            Accuracy_Tier2.BrutalityStreak_Unlock.SetActive(true);
        }
        SkillManager.CheckAll();
    }

    public void HP_1Perc_1_Text(){
        GetText("HP_1Perc_1", TextName: "More Health", Price: 2, Format1: 1, HasCheck: false);
    }

    public void HP_1Perc_1_Upgrade(){
        Upgrade(Object: HP_1Perc_1,Name: "HP_1Perc_1", Price:2, Invoke1:"HealthModifier");

        Accuracy_Tier2.BrutalityStreak_Unlock.transform.Find("Button").GetComponent<Button>().interactable = true;
        SkillManager.Checklist_Add("BrutalityStreak_Unlock","Accuracy_Tier2");
        Accuracy_Tier2.ACC_3_2.SetActive(true);
        Accuracy_Tier2.HP_10_2.SetActive(true);

        SkillManager.CheckAll();
    }
}
