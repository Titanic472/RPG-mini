using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class Evasion_Tier1 : SkillTreeSegment
{

    public GameObject EvasionMain, AvoidChance_2Perc_1, EV_1_ACC_1_1, HP_5_1, EV_3_1, WeaponSkillChance_5Perc_1, AtkSpeed_1_1, PHU, AvoidChance_3Perc_1, PH_Damage_1, PH_Cooldown_1, DMG_Resistance_1_1;
    public bool AvoidChance_2Perc_1_Checked, EV_1_ACC_1_1_Checked, HP_5_1_Checked, EV_3_1_Checked, WeaponSkillChance_5Perc_1_Checked, AtkSpeed_1_1_Checked, PHU_Checked, AvoidChance_3Perc_1_Checked, PH_Damage_1_Checked, PH_Cooldown_1_Checked;
    public Evasion_Tier2 Evasion_Tier2;

    void Awake(){
        Class = "Evasion_Tier1";
    }

    public void EvasionMain_Text(){
        GetText("EvasionMain", TextName: "Evasion", DescriptionName: "EvasionMain", Price: 1, Format1: player.Skills["BaseEvasion"], InfiniteUpgrade: true);
    }

    public void EvasionMain_Upgrade(){
        Upgrade(Object: EvasionMain, Name: "EvasionMain", Price:1, Invoke1:"Evasion", IsBool:false, MoreUpgrades:true, HasSuffix: false);

        if(SkillManager.EvasionMain==1){
            AvoidChance_2Perc_1.transform.Find("Button").GetComponent<Button>().interactable = true;
            SkillManager.Checklist_Add("AvoidChance_2Perc_1","Evasion_Tier1");
            HP_5_1.transform.Find("Button").GetComponent<Button>().interactable = true;
            SkillManager.Checklist_Add("HP_5_1","Evasion_Tier1");
            PHU.transform.Find("Button").GetComponent<Button>().interactable = true;
            SkillManager.Checklist_Add("PHU","Evasion_Tier1");
            AvoidChance_3Perc_1.SetActive(true);
            PH_Damage_1.SetActive(true);
            EV_3_1.SetActive(true);
            EV_1_ACC_1_1.SetActive(true);
            WeaponSkillChance_5Perc_1.SetActive(true);
        }
        SkillManager.CheckAll();
    }

    public void AvoidChance_2Perc_1_Check(){
        Check(Object: AvoidChance_2Perc_1, Name: "AvoidChance_2Perc_1", player.Skills["BaseEvasion"], 8);
    }

    public void AvoidChance_2Perc_1_Text(){
        GetText("AvoidChance_2Perc_1", TextName: "Avoid Chance", Price: 2, Category: 'E', Req_C: 8, Format1: 2, Format2: player.MaxAvoidChance);
    }

    public void AvoidChance_2Perc_1_Upgrade(){
        Upgrade(Object: AvoidChance_2Perc_1,Name: "AvoidChance_2Perc_1", Price:2, Invoke1:"MaxAvoidChance");

        EV_1_ACC_1_1.transform.Find("Button").GetComponent<Button>().interactable = true;
        SkillManager.Checklist_Add("EV_1_ACC_1_1","Evasion_Tier1");
        SkillManager.CheckAll();
    }

    public void EV_1_ACC_1_1_Check(){
        Check(Object: EV_1_ACC_1_1, Name: "EV_1_ACC_1_1", player.Skills["BaseEvasion"], 10);
    }

    public void EV_1_ACC_1_1_Text(){
        GetText("EV_1_ACC_1_1", TextName: "Universal Set", Price: 1, Category: 'E', Req_C: 10, Format1: 1);
    }

    public void EV_1_ACC_1_1_Upgrade(){
        Upgrade(Object: EV_1_ACC_1_1,Name: "EV_1_ACC_1_1", Price:1, Invoke1:"Evasion", Invoke2:"Accuracy");
        SkillManager.CheckAll();
    }

    public void HP_5_1_Check(){
        Check(Object: HP_5_1, Name: "HP_5_1", player.Skills["BaseEvasion"], 12);
    }

    public void HP_5_1_Text(){
        GetText("HP_5_1", TextName: "Additional Health", DescriptionName: "HP 5 Description", Price: 1, Category: 'E', Req_C: 12);
    }

    public void HP_5_1_Upgrade(){
        Upgrade(Object: HP_5_1,Name: "HP_5_1", Price:1, Invoke1:"Health");

        WeaponSkillChance_5Perc_1.transform.Find("Button").GetComponent<Button>().interactable = true;
        SkillManager.Checklist_Add("WeaponSkillChance_5Perc_1","Evasion_Tier1");
        EV_3_1.transform.Find("Button").GetComponent<Button>().interactable = true;
        SkillManager.Checklist_Add("EV_3_1","Evasion_Tier1");
        DMG_Resistance_1_1.SetActive(true);
        AtkSpeed_1_1.SetActive(true);
        SkillManager.CheckAll();
    }

    public void WeaponSkillChance_5Perc_1_Check(){
        Check(Object: WeaponSkillChance_5Perc_1, Name: "WeaponSkillChance_5Perc_1", player.Skills["BaseEvasion"], 18);
    }

    public void WeaponSkillChance_5Perc_1_Text(){
        GetText("WeaponSkillChance_5Perc_1", TextName: "Weapon Ability Chance", Price: 4, Category: 'E', Req_C: 18, Format1: 5);
    }

    public void WeaponSkillChance_5Perc_1_Upgrade(){
        Upgrade(Object: WeaponSkillChance_5Perc_1,Name: "WeaponSkillChance_5Perc_1", Price:4, Invoke1:"WeaponSkillChance");

        AtkSpeed_1_1.transform.Find("Button").GetComponent<Button>().interactable = true;
        SkillManager.Checklist_Add("AtkSpeed_1_1","Evasion_Tier1");
        SkillManager.CheckAll();
    }

    public void AtkSpeed_1_1_Check(){
        Check(Object: AtkSpeed_1_1, Name: "AtkSpeed_1_1", player.Skills["BaseEvasion"], 20);
    }

    public void AtkSpeed_1_1_Text(){
        GetText("AtkSpeed_1_1", TextName: "Faster Attacks", Price: 6, Category: 'E', Req_C: 20);
    }

    public void AtkSpeed_1_1_Upgrade(){
        Upgrade(Object: AtkSpeed_1_1,Name: "AtkSpeed_1_1", Price:6, Invoke1:"AttackSpeed");
    }

    public void EV_3_1_Check(){
        Check(Object: EV_3_1, Name: "EV_3_1", player.Skills["BaseEvasion"], 15);
    }

    public void EV_3_1_Text(){
        GetText("EV_3_1", TextName: "More Evasion", Price: 1, Category: 'E', Req_C: 15);
    }

    public void EV_3_1_Upgrade(){
        Upgrade(Object: EV_3_1,Name: "EV_3_1", Price:1, Invoke1:"Evasion");
        
        if(SkillManager.AvoidChance_3Perc_1_Evasion_Tier1){
            DMG_Resistance_1_1.transform.Find("Button").GetComponent<Button>().interactable = true;
            DMG_Resistance_1_1.transform.Find("Glowing_Yellow").gameObject.SetActive(true);
            Evasion_Tier2.Parrying_Unlock.SetActive(true);
        }
        SkillManager.CheckAll();
    }

    public void PHU_Check(){
        Check(Object: PHU, Name: "PHU", player.Skills["BaseEvasion"], 10);
    }

    public void PHU_Text(){
        GetText("PHU", TextName: "Precise Hit Unlock", Price: 5, Category: 'E', Req_C: 10, HasSuffix: false);
    }

    public void PHU_Upgrade(){
        Upgrade(Object: PHU,Name: "PHU", Price:5, HasSuffix: false);

        AvoidChance_3Perc_1.transform.Find("Button").GetComponent<Button>().interactable = true;
        SkillManager.Checklist_Add("AvoidChance_3Perc_1","Evasion_Tier1");
        PH_Damage_1.transform.Find("Button").GetComponent<Button>().interactable = true;
        SkillManager.Checklist_Add("PH_Damage_1","Evasion_Tier1");
        PH_Cooldown_1.SetActive(true);
        DMG_Resistance_1_1.SetActive(true);
        SkillManager.ActiveSkillsManager.SkillsUnlockCheck();
        SkillManager.CheckAll();
    }

    public void AvoidChance_3Perc_1_Check(){
        Check(Object: AvoidChance_3Perc_1, Name: "AvoidChance_3Perc_1", player.Skills["BaseEvasion"], 15);
    }

    public void AvoidChance_3Perc_1_Text(){
        GetText("AvoidChance_3Perc_1", TextName: "Avoid Chance", Price: 2, Category: 'E', Req_C: 15, Format1: 3, Format2: player.MaxAvoidChance);
    }

    public void AvoidChance_3Perc_1_Upgrade(){
        Upgrade(Object: AvoidChance_3Perc_1,Name: "AvoidChance_3Perc_1", Price:2, Invoke1:"MaxAvoidChance");
        
        if(SkillManager.EV_3_1_Evasion_Tier1){
            DMG_Resistance_1_1.transform.Find("Button").GetComponent<Button>().interactable = true;
            DMG_Resistance_1_1.transform.Find("Glowing_Yellow").gameObject.SetActive(true);
            Evasion_Tier2.Parrying_Unlock.SetActive(true);
        }

        SkillManager.CheckAll();
    }

    public void PH_Damage_1_Check(){
        Check(Object: PH_Damage_1, Name: "PH_Damage_1", player.Skills["BaseEvasion"], 15);
    }

    public void PH_Damage_1_Text(){
        GetText("PH_Damage_1", SkillName: "PH_Damage", TextName: "Precise Damage", Price: 3, Category: 'E', Req_C: 15, Format1: 25, HasSuffix: false);
    }

    public void PH_Damage_1_Upgrade(){
        Upgrade(Object: PH_Damage_1,Name: "PH_Damage_1", SkillName: "PH_Damage", Price:3, IsBool: false, HasSuffix: false);
       
        PH_Cooldown_1.transform.Find("Button").GetComponent<Button>().interactable = true;
        SkillManager.Checklist_Add("PH_Cooldown_1","Evasion_Tier1");
        SkillManager.CheckAll();
    }

    public void PH_Cooldown_1_Check(){
        Check(Object: PH_Cooldown_1, Name: "PH_Cooldown_1", player.Skills["BaseEvasion"], 20);
    }

    public void PH_Cooldown_1_Text(){
        GetText("PH_Cooldown_1", SkillName: "PH_Cooldown", TextName: "Precise Cooldown", Price: 3, Category: 'E', Req_C: 15, Format1: 7, HasSuffix: false);
    }

    public void PH_Cooldown_1_Upgrade(){
        Upgrade(Object: PH_Cooldown_1,Name: "PH_Cooldown_1", SkillName: "PH_Cooldown", Price:3, IsBool: false, HasSuffix: false);
        SkillManager.CheckAll();
    }

    public void DMG_Resistance_1_1_Text(){
        GetText("DMG_Resistance_1_1", TextName: "Damage Resistance", Price: 2, Format1: 1, HasCheck: false);
    }

    public void DMG_Resistance_1_1_Upgrade(){
        Upgrade(Object: DMG_Resistance_1_1,Name: "DMG_Resistance_1_1", Price:2, Invoke1:"DamageResistance");

        Evasion_Tier2.Parrying_Unlock.transform.Find("Button").GetComponent<Button>().interactable = true;
        SkillManager.Checklist_Add("Parrying_Unlock","Evasion_Tier2");
        Evasion_Tier2.DMG_Resistance_1_2.SetActive(true);
        Evasion_Tier2.AtkSpeed_1_2.SetActive(true);
        SkillManager.CheckAll();
    }
}
