using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class Magic_Tier1 : SkillTreeSegment
{
    public GameObject Practice_Plus, HP_5_1, MR_1_1, EV_1_ACC_1_1, M_1Perc_1, Mana_10_1, WeaponSkillChance_5Perc_1, Mana_10_2, MR_1_MCost_2Perc, BS_Mana_1, BS_Cooldown_1, BS_Damage_1, BS_Poison_AddDuration, BSU;
    public bool HP_5_1_Checked, BSU_Checked, MR_1_1_Checked, M_1Perc_1_Checked, Mana_10_1_Checked, WeaponSkillChance_5Perc_1_Checked, Mana_10_2_Checked, BS_Mana_1_Checked, BS_Cooldown_1_Checked, BS_Damage_1_Checked, BS_Poison_AddDuration_Checked;
    public Magic_Tier2 Magic_Tier2;
    int SkillsUpgradeCost = 1;
    
    void Awake(){
        Class = "Magic_Tier1";
    }

    public void Practice_Plus_Text(){
        SkillsUpgradeCost = 1;
        if(SkillManager.Practice_Plus>=1) SkillsUpgradeCost = 2;
        if(SkillManager.Practice_Plus>=5) SkillsUpgradeCost = 3;
        if(SkillManager.Practice_Plus>=15) SkillsUpgradeCost = 4;
        if(SkillManager.Practice_Plus==24) SkillsUpgradeCost = 5;
        if(SkillManager.Practice_Plus<25) GetText("Practice_Plus", TextName: "Practice Plus", Price: SkillsUpgradeCost, InfiniteUpgrade: true);
        else GetText("Practice_Plus", TextName: "Practice Plus", Price: SkillsUpgradeCost, HasCheck: false, HasSuffix: false);
    }

    public void Practice_Plus_Upgrade(){
        Upgrade(Object: Practice_Plus,Name: "Practice_Plus", Price: SkillsUpgradeCost, Invoke1:"Mana", IsBool:false, MoreUpgrades:true, HasSuffix: false);
        if(SkillManager.Practice_Plus==1){
            SkillManager.Checklist_Add("HP_5_1","Magic_Tier1");
            HP_5_1.transform.Find("Button").GetComponent<Button>().interactable = true;
            SkillManager.Checklist_Add("MR_1_1","Magic_Tier1");
            MR_1_1.transform.Find("Button").GetComponent<Button>().interactable = true;
            SkillManager.Checklist_Add("BSU","Magic_Tier1");
            BSU.transform.Find("Button").GetComponent<Button>().interactable = true;

            EV_1_ACC_1_1.SetActive(true);
            Mana_10_1.SetActive(true);
            WeaponSkillChance_5Perc_1.SetActive(true);
            MR_1_MCost_2Perc.SetActive(true);
            BS_Mana_1.SetActive(true);
            BS_Cooldown_1.SetActive(true);
            BS_Damage_1.SetActive(true);
            BS_Poison_AddDuration.SetActive(true);
        }
        if(SkillManager.Practice_Plus==25){
            Practice_Plus.transform.Find("Glowing_Blue").gameObject.SetActive(false);
            Practice_Plus.transform.Find("Glowing_Gold").gameObject.SetActive(true);
        }
        SkillManager.CheckAll();
    }

    public void HP_5_1_Check(){
        Check(Object: HP_5_1, Name: "HP_5_1", SkillManager.Practice_Plus, 3);
    }

    public void HP_5_1_Text(){
        GetText("HP_5_1", TextName: "Additional Health", DescriptionName: "HP 5 Description", Price: 1, Category: 'M', Req_C: 3);
    }

    public void HP_5_1_Upgrade(){
        Upgrade(Object: HP_5_1,Name: "HP_5_1", Price: 1, Invoke1:"Health");

        EV_1_ACC_1_1.transform.Find("Glowing_Yellow").gameObject.SetActive(true);
        EV_1_ACC_1_1.transform.Find("Button").GetComponent<Button>().interactable = true;
        if(SkillManager.MR_1_1_Magic_Tier1){
            SkillManager.Checklist_Add("WeaponSkillChance_5Perc_1","Magic_Tier1");
            WeaponSkillChance_5Perc_1.transform.Find("Button").GetComponent<Button>().interactable = true;
        }
        M_1Perc_1.SetActive(true);
        SkillManager.CheckAll();
    }

    public void MR_1_1_Check(){
        Check(Object: MR_1_1, Name: "MR_1_1", SkillManager.Practice_Plus, 5);
    }

    public void MR_1_1_Text(){
        GetText("MR_1_1", TextName: "Mana Regeneration", Price: 3, Category: 'M', Req_C: 5, Format1: 1);
    }

    public void MR_1_1_Upgrade(){
        Upgrade(Object: MR_1_1,Name: "MR_1_1", Price: 3, Invoke1:"ManaRegen");

        if(SkillManager.HP_5_1_Magic_Tier1){
            SkillManager.Checklist_Add("WeaponSkillChance_5Perc_1","Magic_Tier1");
            WeaponSkillChance_5Perc_1.transform.Find("Button").GetComponent<Button>().interactable = true;
        }
        SkillManager.Checklist_Add("Mana_10_1","Magic_Tier1");
        Mana_10_1.transform.Find("Button").GetComponent<Button>().interactable = true;
        Mana_10_2.SetActive(true);
        SkillManager.CheckAll();
    }

    public void BSU_Check(){
        Check(Object: BSU, Name: "BSU", SkillManager.Practice_Plus, 5);
    }

    public void BSU_Text(){
        GetText("BSU", TextName: "Beginner Spell", Price: 5, Category: 'M', Req_C: 5, HasSuffix: false);
    }

    public void BSU_Upgrade(){
        Upgrade(Object: BSU,Name: "BSU", Price: 5, HasSuffix: false);
        
        if(SkillManager.Mana_10_1_Magic_Tier1){
            MR_1_MCost_2Perc.transform.Find("Button").GetComponent<Button>().interactable = true;
            MR_1_MCost_2Perc.transform.Find("Glowing_Yellow").gameObject.SetActive(true);
            Magic_Tier2.ManaOverdrain_Unlock.SetActive(true);
        }
        SkillManager.Checklist_Add("BS_Mana_1","Magic_Tier1");
        BS_Mana_1.transform.Find("Button").GetComponent<Button>().interactable = true;
        SkillManager.Checklist_Add("BS_Cooldown_1","Magic_Tier1");
        BS_Cooldown_1.transform.Find("Button").GetComponent<Button>().interactable = true;
        SkillManager.Checklist_Add("BS_Damage_1","Magic_Tier1");
        BS_Damage_1.transform.Find("Button").GetComponent<Button>().interactable = true;
        SkillManager.Checklist_Add("BS_Poison_AddDuration","Magic_Tier1");
        BS_Poison_AddDuration.transform.Find("Button").GetComponent<Button>().interactable = true;
        SkillManager.ActiveSkillsManager.SkillsUnlockCheck();
        SkillManager.CheckAll();
    }

    public void EV_1_ACC_1_1_Text(){
        GetText("EV_1_ACC_1_1", TextName: "Universal Set", Price: 1, Format1: 1, HasCheck: false);
    }

    public void EV_1_ACC_1_1_Upgrade(){
        Upgrade(Object: EV_1_ACC_1_1,Name: "EV_1_ACC_1_1", Price: 1, Invoke1:"Evasion", Invoke2: "Accuracy");

        SkillManager.Checklist_Add("M_1Perc_1","Magic_Tier1");
        M_1Perc_1.transform.Find("Button").GetComponent<Button>().interactable = true;
        SkillManager.CheckAll();
    }

    public void M_1Perc_1_Check(){
        Check(Object: M_1Perc_1, Name: "M_1Perc_1", SkillManager.Practice_Plus, 10);
    }

    public void M_1Perc_1_Text(){
        GetText("M_1Perc_1", TextName: "Even More Mana", Price: 2, Category: 'M', Req_C: 10, Format1: 1);
    }

    public void M_1Perc_1_Upgrade(){
        Upgrade(Object: M_1Perc_1,Name: "M_1Perc_1", Price: 2, Invoke1:"ManaModifier");
    }

    public void WeaponSkillChance_5Perc_1_Check(){
        Check(Object: WeaponSkillChance_5Perc_1, Name: "WeaponSkillChance_5Perc_1", SkillManager.Practice_Plus, 6);
    }

    public void WeaponSkillChance_5Perc_1_Text(){
        GetText("WeaponSkillChance_5Perc_1", TextName: "Weapon Ability Chance", Price: 4, Category: 'M', Req_C: 6, Format1: 5);
    }

    public void WeaponSkillChance_5Perc_1_Upgrade(){
        Upgrade(Object: WeaponSkillChance_5Perc_1,Name: "WeaponSkillChance_5Perc_1", Price: 4, Invoke1:"WeaponSkillChance");
        
        if(SkillManager.Mana_10_1_Magic_Tier1){
            SkillManager.Checklist_Add("Mana_10_2","Magic_Tier1");
            Mana_10_2.transform.Find("Button").GetComponent<Button>().interactable = true;
        }
        SkillManager.CheckAll();
    }

    public void Mana_10_1_Check(){
        Check(Object: Mana_10_1, Name: "Mana_10_1", SkillManager.Practice_Plus, 6);
    }

    public void Mana_10_1_Text(){
        GetText("Mana_10_1", TextName: "More Mana", Price: 2, Category: 'M', Req_C: 6);
    }

    public void Mana_10_1_Upgrade(){
        Upgrade(Object: Mana_10_1,Name: "Mana_10_1", Price: 2, Invoke1:"Mana");

        if(SkillManager.WeaponSkillChance_5Perc_1_Magic_Tier1){
            SkillManager.Checklist_Add("Mana_10_2","Magic_Tier1");
            Mana_10_2.transform.Find("Button").GetComponent<Button>().interactable = true;
        }
        if(SkillManager.BSU){
            MR_1_MCost_2Perc.transform.Find("Button").GetComponent<Button>().interactable = true;
            MR_1_MCost_2Perc.transform.Find("Glowing_Yellow").gameObject.SetActive(true);
            Magic_Tier2.ManaOverdrain_Unlock.SetActive(true);
        }
        SkillManager.CheckAll();
    }

    public void Mana_10_2_Check(){
        Check(Object: Mana_10_2, Name: "Mana_10_2", SkillManager.Practice_Plus, 9);
        if(SkillManager.Practice_Plus>=9){
            Mana_10_2.transform.Find("Glowing_Yellow").gameObject.SetActive(true);
            SkillManager.IsChecked = true;
            Mana_10_2_Checked = true;
        }
    }

    public void Mana_10_2_Text(){
        GetText("Mana_10_2", TextName: "More Mana", Price: 3, Category: 'M', Req_C: 9);
    }

    public void Mana_10_2_Upgrade(){
        Upgrade(Object: Mana_10_2,Name: "Mana_10_2", Price: 3, Invoke1:"Mana");
    }

    public void MR_1_MCost_2Perc_Text(){
        GetText("MR_1_MCost_2Perc", TextName: "Now Not A Beginner", Price: 4, HasCheck: false);
    }

    public void MR_1_MCost_2Perc_Upgrade(){
        Upgrade(Object: MR_1_MCost_2Perc,Name: "MR_1_MCost_2Perc", Price: 4, Invoke1:"ManaRegen", Invoke2: "ManaCost");

        SkillManager.Checklist_Add("ManaOverdrain_Unlock","Magic_Tier2");
        Magic_Tier2.ManaOverdrain_Unlock.transform.Find("Button").GetComponent<Button>().interactable = true;
        Magic_Tier2.ManaOverdrain_Perc_1.SetActive(true);
        Magic_Tier2.HP_10_1.SetActive(true);
        Magic_Tier2.Mana_10_5.SetActive(true);
        Magic_Tier2.BS_Cooldown_2.SetActive(true);
        SkillManager.CheckAll();
    }


    public void BS_Mana_1_Check(){
        Check(Object: BS_Mana_1, Name: "BS_Mana_1", SkillManager.Practice_Plus, 6);
    }

    public void BS_Mana_1_Text(){
        GetText("BS_Mana_1", SkillName: "BS_Mana", TextName: "Beginner Mana", Price: 5, Category: 'M', Req_C: 6, Format1: 40, HasSuffix: false);
    }

    public void BS_Mana_1_Upgrade(){
        Upgrade(Object: BS_Mana_1,Name: "BS_Mana_1", SkillName: "BS_Mana", Price: 5, IsBool: false, HasSuffix: false);
        SkillManager.CheckAll();
    }
    
    public void BS_Cooldown_1_Check(){
        Check(Object: BS_Cooldown_1, Name: "BS_Cooldown_1", SkillManager.Practice_Plus, 6);
    }

    public void BS_Cooldown_1_Text(){
        GetText("BS_Cooldown_1", SkillName: "BS_Cooldown", TextName: "Beginner Cooldown", Price: 3, Category: 'M', Req_C: 6, Format1: 7, HasSuffix: false);
    }

    public void BS_Cooldown_1_Upgrade(){
        Upgrade(Object: BS_Cooldown_1,Name: "BS_Cooldown_1", SkillName: "BS_Cooldown", Price: 3, IsBool: false, HasSuffix: false);
        SkillManager.CheckAll();
    }

    public void BS_Damage_1_Check(){
        Check(Object: BS_Damage_1, Name: "BS_Damage_1", SkillManager.Practice_Plus, 7);
    }

    public void BS_Damage_1_Text(){
        GetText("BS_Damage_1", SkillName: "BS_Damage", TextName: "Beginner Damage", Price: 4, Category: 'M', Req_C: 7, Format1: 20, HasSuffix: false);
    }

    public void BS_Damage_1_Upgrade(){
        Upgrade(Object: BS_Damage_1,Name: "BS_Damage_1", SkillName: "BS_Damage", Price: 4, IsBool: false, HasSuffix: false);
        SkillManager.CheckAll();
    }
    
    public void BS_Poison_AddDuration_Check(){
        Check(Object: BS_Poison_AddDuration, Name: "BS_Poison_AddDuration", SkillManager.Practice_Plus, 6);
    }

    public void BS_Poison_AddDuration_Text(){
        GetText("BS_Poison_AddDuration", TextName: "Deadlier Poison", Price: 3, Category: 'M', Req_C: 6, HasSuffix: false);
    }

    public void BS_Poison_AddDuration_Upgrade(){
        Upgrade(Object: BS_Poison_AddDuration, Name: "BS_Poison_AddDuration", Price: 3, HasSuffix: false);
        SkillManager.CheckAll();
    }
}
