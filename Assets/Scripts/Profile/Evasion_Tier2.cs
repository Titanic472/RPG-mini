using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class Evasion_Tier2 : SkillTreeSegment
{
    public GameObject Parrying_Unlock, DMG_Resistance_1_2, AvoidChance_5Perc_1, AvoidChance_5Perc_2, Parrying_Chance_1, HP_5_2, Parrying_Damage_1, AtkSpeed_1_2, HP_10_1, PH_Damage_2, PH_WeaponSkillChance_1, PH_Cooldown_2, EV_3_2, EV_1_ACC_1_2, EV_2_ACC_2_1, AddSlot;
    public bool Parrying_Unlock_Checked, DMG_Resistance_1_2_Checked, AvoidChance_5Perc_1_Checked, AvoidChance_5Perc_2_Checked, Parrying_Chance_1_Checked, HP_5_2_Checked, Parrying_Damage_1_Checked, AtkSpeed_1_2_Checked, HP_10_1_Checked, PH_Damage_2_Checked, PH_WeaponSkillChance_1_Checked, PH_Cooldown_2_Checked, EV_3_2_Checked, EV_1_ACC_1_2_Checked, EV_2_ACC_2_1_Checked, AddSlot_Checked;

    void Awake(){
        Class = "Evasion_Tier2";
    }

    public void Parrying_Unlock_Check(){
        Check(Object: Parrying_Unlock, Name: "Parrying_Unlock", player.Skills["BaseEvasion"], 17);
    }

    public void Parrying_Unlock_Text(){
        GetText("Parrying_Unlock", TextName: "Parrying Unlock", Price: 4, Category: 'E', Req_C: 17, HasSuffix: false);
    }

    public void Parrying_Unlock_Upgrade(){
        Upgrade(Object: Parrying_Unlock,Name: "Parrying_Unlock", Price: 4, HasSuffix: false);

        DMG_Resistance_1_2.transform.Find("Button").GetComponent<Button>().interactable = true;
        SkillManager.Checklist_Add("DMG_Resistance_1_2","Evasion_Tier2");
        AtkSpeed_1_2.transform.Find("Button").GetComponent<Button>().interactable = true;
        SkillManager.Checklist_Add("AtkSpeed_1_2","Evasion_Tier2");
        HP_10_1.SetActive(true);
        AvoidChance_5Perc_2.SetActive(true);
        AvoidChance_5Perc_1.SetActive(true);
        SkillManager.CheckAll();
    }

    public void DMG_Resistance_1_2_Check(){
        Check(Object: DMG_Resistance_1_2, Name: "DMG_Resistance_1_2", player.Skills["BaseEvasion"], 20);
    }

    public void DMG_Resistance_1_2_Text(){
        GetText("DMG_Resistance_1_2", TextName: "Damage Resistance", Price: 3, Category: 'E', Req_C: 20, Format1: 1);
    }

    public void DMG_Resistance_1_2_Upgrade(){
        Upgrade(Object: DMG_Resistance_1_2,Name: "DMG_Resistance_1_2", Price: 3, Invoke1:"DamageResistance");

        AvoidChance_5Perc_1.transform.Find("Button").GetComponent<Button>().interactable = true;
        SkillManager.Checklist_Add("AvoidChance_5Perc_1","Evasion_Tier2");
        AvoidChance_5Perc_2.transform.Find("Button").GetComponent<Button>().interactable = true;
        SkillManager.Checklist_Add("AvoidChance_5Perc_2","Evasion_Tier2");
        HP_5_2.SetActive(true);
        Parrying_Chance_1.SetActive(true);
        SkillManager.CheckAll();
    }

    public void AvoidChance_5Perc_2_Check(){
        Check(Object: AvoidChance_5Perc_2, Name: "AvoidChance_5Perc_2", player.Skills["BaseEvasion"], 22);
    }

    public void AvoidChance_5Perc_2_Text(){
        GetText("AvoidChance_5Perc_2", TextName: "Avoid Chance", Price: 4, Category: 'E', Req_C: 22, Format1: 5, Format2: player.MaxAvoidChance);
    }

    public void AvoidChance_5Perc_2_Upgrade(){
        Upgrade(Object: AvoidChance_5Perc_2,Name: "AvoidChance_5Perc_2", Price: 4, Invoke1:"MaxAvoidChance");
        
        Parrying_Chance_1.transform.Find("Button").GetComponent<Button>().interactable = true;
        SkillManager.Checklist_Add("Parrying_Chance_1","Evasion_Tier2");
        SkillManager.CheckAll();
    }

    public void Parrying_Chance_1_Check(){
        Check(Object: Parrying_Chance_1, Name: "Parrying_Chance_1", player.Skills["BaseEvasion"], 25);
    }

    public void Parrying_Chance_1_Text(){
        GetText("Parrying_Chance_1", SkillName: "Parrying_Chance", TextName: "Parrying Chance", Price: 3, Category: 'E', Req_C: 25, Format1: 2, HasSuffix: false);
    }

    public void Parrying_Chance_1_Upgrade(){
        Upgrade(Object: Parrying_Chance_1,Name: "Parrying_Chance_1", SkillName: "Parrying_Chance", Price: 3, IsBool: false, HasSuffix: false);
        SkillManager.CheckAll();
    }

    public void AvoidChance_5Perc_1_Check(){
        Check(Object: AvoidChance_5Perc_1, Name: "AvoidChance_5Perc_1", player.Skills["BaseEvasion"], 25);
    }

    public void AvoidChance_5Perc_1_Text(){
        GetText("AvoidChance_5Perc_1", TextName: "Avoid Chance", Price: 3, Category: 'E', Req_C: 25, Format1: 5, Format2: player.MaxAvoidChance);
    }

    public void AvoidChance_5Perc_1_Upgrade(){
        Upgrade(Object: AvoidChance_5Perc_1,Name: "AvoidChance_5Perc_1", Price: 3, Invoke1:"MaxAvoidChance");

        HP_5_2.transform.Find("Button").GetComponent<Button>().interactable = true;
        SkillManager.Checklist_Add("HP_5_2","Evasion_Tier2");
        Parrying_Damage_1.SetActive(true);
        AddSlot.SetActive(true);
        if(!SkillManager.EV_1_ACC_1_2_Evasion_Tier2)AddSlot.transform.Find("EV_2_ACC_2_1-AddSlot").gameObject.SetActive(false);

        SkillManager.CheckAll();
    }

    public void HP_5_2_Check(){
        Check(Object: HP_5_2, Name: "HP_5_2", player.Skills["BaseEvasion"], 30);
    }

    public void HP_5_2_Text(){
        GetText("HP_5_2", TextName: "Additional Health", DescriptionName: "HP 5 Description", Price: 1, Category: 'E', Req_C: 30);
    }

    public void HP_5_2_Upgrade(){
        Upgrade(Object: HP_5_2,Name: "HP_5_2", Price: 1, Invoke1:"Health");
        
        AddSlot.transform.Find("EV_2_ACC_2_1-AddSlot").gameObject.SetActive(true);
        EV_2_ACC_2_1.SetActive(true);
        AddSlot.transform.Find("HP_5_2-AddSlot").gameObject.SetActive(true);
        if(!SkillManager.EV_3_2_Evasion_Tier2)EV_2_ACC_2_1.transform.Find("EV_1_ACC_1_2-EV_2_ACC_2_1").gameObject.SetActive(false);
        if(SkillManager.EV_2_ACC_2_1_Evasion_Tier2){
            AddSlot.transform.Find("Button").GetComponent<Button>().interactable = true;
            AddSlot.transform.Find("Glowing_Yellow").gameObject.SetActive(true);
        }
        Parrying_Damage_1.transform.Find("Button").GetComponent<Button>().interactable = true;
        SkillManager.Checklist_Add("Parrying_Damage_1","Evasion_Tier2");
        SkillManager.CheckAll();
    }

    public void Parrying_Damage_1_Check(){
        Check(Object: Parrying_Damage_1, Name: "Parrying_Damage_1", player.Skills["BaseEvasion"], 40);
    }

    public void Parrying_Damage_1_Text(){
        GetText("Parrying_Damage_1", SkillName: "Parrying_Damage", TextName: "Painful Parrying", Price: 4, Category: 'E', Req_C: 40, Format1: 5, HasSuffix: false);
    }

    public void Parrying_Damage_1_Upgrade(){
        Upgrade(Object: Parrying_Damage_1,Name: "Parrying_Damage_1", SkillName: "Parrying_Damage", Price: 4, IsBool: false, HasSuffix: false);
        SkillManager.CheckAll();
    }

    public void AtkSpeed_1_2_Check(){
        Check(Object: AtkSpeed_1_2, Name: "AtkSpeed_1_2", player.Skills["BaseEvasion"], 18);
    }

    public void AtkSpeed_1_2_Text(){
        GetText("AtkSpeed_1_2", TextName: "Faster Attacks", Price: 6, Category: 'E', Req_C: 18);
    }

    public void AtkSpeed_1_2_Upgrade(){
        Upgrade(Object: AtkSpeed_1_2,Name: "AtkSpeed_1_2", Price:6, Invoke1:"AttackSpeed");
        
        HP_10_1.transform.Find("Button").GetComponent<Button>().interactable = true;
        SkillManager.Checklist_Add("HP_10_1","Evasion_Tier2");
        PH_Damage_2.SetActive(true);
        EV_3_2.SetActive(true);
        SkillManager.CheckAll();
    }

    public void HP_10_1_Check(){
        Check(Object: HP_10_1, Name: "HP_10_1", player.Skills["BaseEvasion"], 20);
    }

    public void HP_10_1_Text(){
        GetText("HP_10_1", TextName: "Additional Health", DescriptionName: "HP 10 Description", Price: 2, Category: 'E', Req_C: 20);
    }

    public void HP_10_1_Upgrade(){
        Upgrade(Object: HP_10_1,Name: "HP_10_1", Price: 2, Invoke1:"Health");

        PH_Damage_2.transform.Find("Button").GetComponent<Button>().interactable = true;
        SkillManager.Checklist_Add("PH_Damage_2","Evasion_Tier2");
        EV_3_2.transform.Find("Button").GetComponent<Button>().interactable = true;
        SkillManager.Checklist_Add("EV_3_2","Evasion_Tier2");
        PH_WeaponSkillChance_1.SetActive(true);
        EV_1_ACC_1_2.SetActive(true);
        SkillManager.CheckAll();
    }

    public void PH_Damage_2_Check(){
        Check(Object: PH_Damage_2, Name: "PH_Damage_2", player.Skills["BaseEvasion"], 25, SkillManager.PH_Damage, 1);
    }

    public void PH_Damage_2_Text(){
        GetText("PH_Damage_2", SkillName: "PH_Damage", TextName: "Precise Damage", Price: 4, Category: 'E', Req_C: 25, UpgValue: 1, Format1: 15, Req1: Language_Changer.Instance.GetText("Precise_Damage"), Req1Lvl: 1, HasSuffix: false);
    }

    public void PH_Damage_2_Upgrade(){
        Upgrade(Object: PH_Damage_2,Name: "PH_Damage_2", SkillName: "PH_Damage", Price: 4, IsBool: false, HasSuffix: false);
        
        PH_WeaponSkillChance_1.transform.Find("Button").GetComponent<Button>().interactable = true;
        SkillManager.Checklist_Add("PH_WeaponSkillChance_1","Evasion_Tier2");
        PH_Cooldown_2.SetActive(true);
        SkillManager.CheckAll();
    }

    public void PH_WeaponSkillChance_1_Check(){
        Check(Object: PH_WeaponSkillChance_1, Name: "PH_WeaponSkillChance_1", player.Skills["BaseEvasion"], 30);
    }

    public void PH_WeaponSkillChance_1_Text(){
        GetText("PH_WeaponSkillChance_1", SkillName: "PH_WeaponSkillChance", TextName: "Precise Enchants", Price: 6, Category: 'E', Req_C: 30, Format1: 50, HasSuffix: false);
    }

    public void PH_WeaponSkillChance_1_Upgrade(){
        Upgrade(Object: PH_WeaponSkillChance_1,Name: "PH_WeaponSkillChance_1", SkillName: "PH_WeaponSkillChance", Price: 6, IsBool: false, HasSuffix: false);
        
        PH_Cooldown_2.transform.Find("Button").GetComponent<Button>().interactable = true;
        SkillManager.Checklist_Add("PH_Cooldown_2","Evasion_Tier2");
        SkillManager.CheckAll();
    }

    public void PH_Cooldown_2_Check(){
        Check(Object: PH_Cooldown_2, Name: "PH_Cooldown_2", player.Skills["BaseEvasion"], 35, SkillManager.PH_Cooldown, 1);
    }

    public void PH_Cooldown_2_Text(){
        GetText("PH_Cooldown_2", SkillName: "PH_Cooldown", TextName: "Precise Cooldown", Price: 5, Category: 'E', Req_C: 35, UpgValue: 1, Format1: 7, Req1: Language_Changer.Instance.GetText("Precise_Cooldown"), Req1Lvl: 1, HasSuffix: false);
    }

    public void PH_Cooldown_2_Upgrade(){
        Upgrade(Object: PH_Cooldown_2 ,Name: "PH_Cooldown_2", SkillName: "PH_Cooldown", Price: 5, IsBool: false, HasSuffix: false);
        SkillManager.CheckAll();
    }

    public void EV_3_2_Check(){
        Check(Object: EV_3_2, Name: "EV_3_2", player.Skills["BaseEvasion"], 22);
    }

    public void EV_3_2_Text(){
        GetText("EV_3_2", TextName: "More Evasion", Price: 1, Category: 'E', Req_C: 22);
    }

    public void EV_3_2_Upgrade(){
        Upgrade(Object: EV_3_2,Name: "EV_3_2", Price: 1, Invoke1:"Evasion");

        EV_1_ACC_1_2.transform.Find("Button").GetComponent<Button>().interactable = true;
        SkillManager.Checklist_Add("EV_1_ACC_1_2","Evasion_Tier2");
        EV_2_ACC_2_1.transform.Find("EV_1_ACC_1_2-EV_2_ACC_2_1").gameObject.SetActive(true);
        EV_2_ACC_2_1.SetActive(true);
        SkillManager.CheckAll();
    }

public void EV_1_ACC_1_2_Check(){
    Check(Object: EV_1_ACC_1_2, Name: "EV_1_ACC_1_2", player.Skills["BaseEvasion"], 28);
    }

    public void EV_1_ACC_1_2_Text(){
        GetText("EV_1_ACC_1_2", TextName: "Universal Set", Price: 1, Category: 'E', Req_C: 28, Format1: 1);
    }

    public void EV_1_ACC_1_2_Upgrade(){
        Upgrade(Object: EV_1_ACC_1_2,Name: "EV_1_ACC_1_2", Price:1, Invoke1:"Evasion", Invoke2:"Accuracy");
        
        EV_2_ACC_2_1.transform.Find("Button").GetComponent<Button>().interactable = true;
        SkillManager.Checklist_Add("EV_2_ACC_2_1","Evasion_Tier2");
        AddSlot.SetActive(true);
        AddSlot.transform.Find("EV_2_ACC_2_1-AddSlot").gameObject.SetActive(true);
        if(!SkillManager.AvoidChance_5Perc_1_Evasion_Tier2)AddSlot.transform.Find("HP_5_2-AddSlot").gameObject.SetActive(false);
        SkillManager.CheckAll();
    }

    public void EV_2_ACC_2_1_Check(){
        Check(Object: EV_2_ACC_2_1, Name: "EV_2_ACC_2_1", player.Skills["BaseEvasion"], 35);
    }

    public void EV_2_ACC_2_1_Text(){
        GetText("EV_2_ACC_2_1", TextName: "Universal Set", Price: 2, Category: 'E', Req_C: 35, Format1: 2);
    }

    public void EV_2_ACC_2_1_Upgrade(){
        Upgrade(Object: EV_2_ACC_2_1,Name: "EV_2_ACC_2_1", Price:2, Invoke1:"Evasion", Invoke2:"Accuracy");

        HP_5_2.SetActive(true);
        AddSlot.transform.Find("HP_5_2-AddSlot").gameObject.SetActive(true);
        if(SkillManager.HP_5_2_Evasion_Tier2){
            AddSlot.transform.Find("Button").GetComponent<Button>().interactable = true;
            AddSlot.transform.Find("Glowing_Yellow").gameObject.SetActive(true);
        }
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