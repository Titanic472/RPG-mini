using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;
using TMPro;

public class ActiveSkillsManager : MonoBehaviour
{   
    public bool[,] SkillsList = new bool[9, 2];//0 - IsUnlocked, 1 - IsSelected
    public int[] ActiveSlots = new int [5];//[0] - slots used
    public int MaxSlots = 1;
    public Vector2[] ActiveSlotsPos = new Vector2[4];
    public GameObject[] ActiveSlotsGO  = new GameObject[3];
    public Vector2[] SelectedSlotsPos = new Vector2[9];
    public GameObject[] Slots = new GameObject[9];
    public Sprite[] SlotImages = new Sprite[9];
    public GameObject Button;
    public int SelectedSlotID;
    public bool Removing;
    public Sprite Empty;
    public TextMeshProUGUI Information, Title;
    public Skills SkillManager;

    void  Awake(){
        for(int i = 1; i<5; ++i) ActiveSlots[i] = -1;
    }

    public async void ObjectMove(GameObject WhatWeAreMoving, Vector2 StartPos, Vector2 FinalPos){
        Vector3 Move = new Vector3((FinalPos.x-StartPos.x)/50, (FinalPos.y - StartPos.y)/50, 0);
        for(int i = 1; i<=50; ++i){
            WhatWeAreMoving.transform.position += Move;
            await Task.Delay(2);
        }
    }

    public void SelectSkill(){
        if(Removing){
            ObjectMove(Slots[SelectedSlotID], ActiveSlotsPos[GetPosition(SelectedSlotID)], SelectedSlotsPos[SelectedSlotID]);
            Button.transform.Find("text").GetComponent<TextMeshProUGUI>().text = Language_Changer.Instance.GetText("Use");
            ActiveSkillRemove(SelectedSlotID);
            SkillsList[SelectedSlotID, 1] = false;
        }
        else{
            Button.transform.Find("text").GetComponent<TextMeshProUGUI>().text = Language_Changer.Instance.GetText("Remove");
            ObjectMove(Slots[SelectedSlotID], SelectedSlotsPos[SelectedSlotID], ActiveSlotsPos[ActiveSlots[0]]);
            ++ActiveSlots[0];
            ActiveSlots[ActiveSlots[0]] = SelectedSlotID;
            SkillsList[SelectedSlotID, 1] = true;
        }
        Removing = !Removing;
    }

    public void SkillsUnlockCheck(){
        if(SkillManager.PHU){
            SkillsList[0, 0] = true;
            Slots[0].transform.Find("Lock").gameObject.SetActive(false);
        }
        if(SkillManager.KDU){
            SkillsList[1, 0] = true;
            Slots[1].transform.Find("Lock").gameObject.SetActive(false);
        }
        if(SkillManager.DFU){
            SkillsList[2, 0] = true;
            Slots[2].transform.Find("Lock").gameObject.SetActive(false);
        }
        if(SkillManager.BLU){
            SkillsList[3, 0] = true;
            Slots[3].transform.Find("Lock").gameObject.SetActive(false);
        }
        if(SkillManager.BSU){
            SkillsList[6, 0] = true;
            Slots[6].transform.Find("Lock").gameObject.SetActive(false);
        }
        if(SkillManager.CHU){
            SkillsList[7, 0] = true;
            Slots[7].transform.Find("Lock").gameObject.SetActive(false);
        }
        if(SkillManager.VU){
            SkillsList[8, 0] = true;
            Slots[8].transform.Find("Lock").gameObject.SetActive(false);
        }
        
    }
    
    public void GetDescription(int ID){
        string EffectDuration, Damage, UltimateDescription = "", ManaUsage, Cooldown;
        switch(ID){
            case 0:
                string WeaponSkillChance;
                switch(SkillManager.PH_Damage){
                    case 1:
                        Damage = "25";
                        break;
                    case 2:
                        Damage = "40";
                        break;
                    case 3:
                        Damage = "60";
                        break;
                    default:
                        Damage = "10";
                        break;
                }
                switch(SkillManager.PH_Cooldown){
                    case 1:
                        Cooldown = "5";
                        break;
                    case 2:
                        Cooldown = "6";
                        break;
                    case 3:
                        Cooldown = "7";
                        break;
                    default:
                        Cooldown = "8";
                        break;
                }
                switch(SkillManager.PH_WeaponSkillChance){
                    case 1:
                        WeaponSkillChance = "50";
                        break;
                    case 2:
                        WeaponSkillChance = "100";
                        break;
                    default:
                        WeaponSkillChance = "0";
                        break;
                }
                Information.text = string.Format(Language_Changer.Instance.GetText("Active_Skill_" + ID + "_Description", "ActiveSkills"), Damage, Cooldown, WeaponSkillChance);
                break;
            case 1:
                string Amount, NoStaminaUseChance, ExplosiveKnifeDesciption;
                switch(SkillManager.KD_Amount){
                    case 1:
                        Amount = "5";
                        break;
                    case 2:
                        Amount = "7";
                        break;
                    case 3:
                        Amount = "10";
                        break;
                    default:
                        Amount = "3";
                        break;
                }
                switch(SkillManager.KD_Damage){
                    case 1:
                        Damage = "100";
                        break;
                    case 2:
                        Damage = "150";
                        break;
                    default:
                        Damage = "50";
                        break;
                }
                switch(SkillManager.KD_Cooldown){
                    case 1:
                        Cooldown = "7";
                        break;
                    case 2:
                        Cooldown = "6";
                        break;
                    default:
                        Cooldown = "8";
                        break;
                }
                switch(SkillManager.KD_NoStaminaUse){
                    case 1:
                        NoStaminaUseChance = string.Format(Language_Changer.Instance.GetText("Active_Skill_1_Description_No_Stamina_Use_Chance", "ActiveSkills"), 10, 3);
                        break;
                    case 2:
                        NoStaminaUseChance = string.Format(Language_Changer.Instance.GetText("Active_Skill_1_Description_No_Stamina_Use_Chance", "ActiveSkills"), 20, 5);
                        break;
                    case 3:
                        NoStaminaUseChance = string.Format(Language_Changer.Instance.GetText("Active_Skill_1_Description_No_Stamina_Use_Chance", "ActiveSkills"), 33, 8);
                        break;
                    default:
                        NoStaminaUseChance = "";
                        break;
                }
                switch(SkillManager.KD_Explosive){
                    case 1:
                        ExplosiveKnifeDesciption = string.Format(Language_Changer.Instance.GetText("Active_Skill_1_Description_Explosive", "ActiveSkills"), "");
                        break;
                    case 2:
                        ExplosiveKnifeDesciption = string.Format(Language_Changer.Instance.GetText("Active_Skill_1_Description_Explosive", "ActiveSkills"), Language_Changer.Instance.GetText("Active_Skill_1_Description_Explosive_Debuff", "ActiveSkills"));
                        break;
                    default:
                        ExplosiveKnifeDesciption = "";
                        break;
                }
                string Debuffs = "", IgnoreAvoid =  "";
                if(SkillManager.KD_Bleeding || SkillManager.KD_Poison){
                    Debuffs = Language_Changer.Instance.GetText("Active_Skill_1_Description_Extra_Debuffs", "ActiveSkills");
                    if(SkillManager.KD_Bleeding){
                        if(!SkillManager.KD_Poison)Debuffs = string.Format(Debuffs, Language_Changer.Instance.GetText("Active_Skill_1_Description_Bleeding", "ActiveSkills"), "");
                    }
                    if(SkillManager.KD_Poison){
                        if(!SkillManager.KD_Bleeding)Debuffs =  string.Format(Debuffs, string.Format(Language_Changer.Instance.GetText("Active_Skill_1_Description_Poison", "ActiveSkills"), ""), "");
                        else Debuffs = string.Format(Debuffs, Language_Changer.Instance.GetText("Active_Skill_1_Description_Bleeding", "ActiveSkills"), string.Format(Language_Changer.Instance.GetText("Active_Skill_1_Description_Poison", "ActiveSkills"), Language_Changer.Instance.GetText("and")));
                }
                }
                if(!SkillManager.KD_IgnoreAvoid){
                    IgnoreAvoid = Language_Changer.Instance.GetText("Active_Skill_1_Description_Avoid", "ActiveSkills");
                }

                Information.text = string.Format(Language_Changer.Instance.GetText("Active_Skill_" + ID + "_Description", "ActiveSkills"), Amount, NoStaminaUseChance, IgnoreAvoid, Damage, ExplosiveKnifeDesciption, Debuffs, Cooldown);
                break;
            case 2:
                string Debuff_Description = "", DoubleEffect = "";
                switch(SkillManager.DF_EffectDuration){
                    case 1:
                        EffectDuration = "4";
                        Cooldown = "6";
                        break;
                    case 2:
                        EffectDuration = "5";
                        Cooldown = "7";
                        break;
                    case 3:
                        EffectDuration = "6";
                        Cooldown = "8";
                        break;
                    default:
                        EffectDuration = "3";
                        Cooldown = "5";
                        break;
                }
                if(SkillManager.DF_Debuff){
                    string Debuff_Percent, Debuff_Stamina, Debuff_Duration;
                    switch(SkillManager.DF_Debuff_Percent){
                        case 1:
                            Debuff_Percent = "8";
                            break;
                        case 2:
                            Debuff_Percent = "5";
                            break;
                        default:
                            Debuff_Percent = "10";
                            break;
                    }
                    switch(SkillManager.DF_Debuff_Stamina){
                        case 1:
                            Debuff_Stamina = "0.15";
                            break;
                        case 2:
                            Debuff_Stamina = "0.2";
                            break;
                        case 3:
                            Debuff_Stamina = "0.25";
                            break;
                        default:
                            Debuff_Stamina = "0.1";
                            break;
                    }
                    switch(SkillManager.DF_Debuff_Duration){
                        case 1:
                            Debuff_Duration = "5";
                            break;
                        case 2:
                            Debuff_Duration = "8";
                            break;
                        default:
                            Debuff_Duration = "3";
                            break;
                    }
                    Debuff_Description = string.Format(Language_Changer.Instance.GetText("Active_Skill_2_Description_Debuff", "ActiveSkills"), Debuff_Stamina, Debuff_Percent, Debuff_Duration);
                }
                if(SkillManager.DF_DoubleEffect){
                    DoubleEffect = Language_Changer.Instance.GetText("Active_Skill_2_Description_Double_Stamina", "ActiveSkills");
                }
                Information.text = string.Format(Language_Changer.Instance.GetText("Active_Skill_" + ID + "_Description", "ActiveSkills"), EffectDuration, DoubleEffect, Debuff_Description, Cooldown);
                break;
            case 3:
            string ReturnDamage, Chance;
                switch(SkillManager.BL_ReturnDamage){
                    case 1:
                        ReturnDamage = "25";
                        break;
                    case 2:
                        ReturnDamage = "35";
                        break;
                    case 3:
                        ReturnDamage = "50";
                        break;
                    default:
                        ReturnDamage = "20";
                        break;
                }
                switch(SkillManager.BL_Chance){
                    case 1:
                        Chance = "70";
                        break;
                    case 2:
                        Chance = "80";
                        break;
                    case 3:
                        Chance = "95";
                        break;
                    default:
                        Chance = "65";
                        break;
                }
                switch(SkillManager.BL_Cooldown){
                    case 1:
                        Cooldown = "5";
                        break;
                    case 2:
                        Cooldown = "4";
                        break;
                    default:
                        Cooldown = "6";
                        break;
                }
                Information.text = string.Format(Language_Changer.Instance.GetText("Active_Skill_" + ID + "_Description", "ActiveSkills"), ReturnDamage, Chance, Cooldown);
                break;
            case 6:
                string NoEvasion = "", PoisonDuration, DamageChance, Weakness = "";
                if(SkillManager.BS_NoEvasion) NoEvasion = Language_Changer.Instance.GetText("Active_Skill_6_Description_No_Evasion", "ActiveSkills");
                if(SkillManager.BS_Poison_AddDuration) PoisonDuration = "10";
                else PoisonDuration = "5";
                if(SkillManager.BS_Weakness >=1){
                    if(SkillManager.BS_Weakness == 2) Weakness = string.Format(Language_Changer.Instance.GetText("Active_Skill_6_Description_Weakness", "ActiveSkills"), 8);
                    else Weakness = string.Format(Language_Changer.Instance.GetText("Active_Skill_6_Description_Weakness", "ActiveSkills"), 5);
                }
                switch(SkillManager.BS_Damage){
                    case 1:
                        DamageChance = "20";
                        break;
                    case 2:
                        DamageChance = "30";
                        break;
                    case 3:
                        DamageChance = "50";
                        break;
                    default:
                        DamageChance = "10";
                        break;
                }
                switch(SkillManager.BS_Mana){
                    case 1:
                        ManaUsage = "40";
                        break;
                    case 2:
                        ManaUsage = "30";
                        break;
                    default:
                        ManaUsage = "50";
                        break;
                }
                switch(SkillManager.BS_Cooldown){
                    case 1:
                        Cooldown = "7";
                        break;
                    case 2:
                        Cooldown = "6";
                        break;
                    case 3:
                        Cooldown = "5";
                        break;
                    default:
                        Cooldown = "8";
                        break;
                }
                if(SkillManager.BS_Ultimate){
                    DamageChance = "100";
                    UltimateDescription = Language_Changer.Instance.GetText("Double") + " ";
                }
                Information.text = string.Format(Language_Changer.Instance.GetText("Active_Skill_6_Description", "ActiveSkills"), PoisonDuration, DamageChance, Cooldown, ManaUsage, Weakness, NoEvasion, UltimateDescription);
                break;
            case 7:
                switch(SkillManager.CH_Mana){
                    case 1:
                        ManaUsage = "220";
                        break;
                    case 2:
                        ManaUsage = "180";
                        break;
                    case 3:
                        ManaUsage = "150";
                        break;
                    default:
                        ManaUsage = "250";
                        break;
                }
                switch(SkillManager.CH_Cooldown){
                    case 1:
                        Cooldown = "6";
                        break;
                    case 2:
                        Cooldown = "5";
                        break;
                    default:
                        Cooldown = "7";
                        break;
                }
                if(!SkillManager.CH_Effect){
                    string HealthPercent;
                    switch(SkillManager.CH_Damage){
                        case 1:
                            HealthPercent = "2";
                            break;
                        case 2:
                            HealthPercent = "5";
                            break;
                        default:
                            HealthPercent = "1";
                            break;
                    }
                    Information.text = string.Format(Language_Changer.Instance.GetText("Active Skill 7 Description", "ActiveSkills"), HealthPercent, Cooldown, ManaUsage);
                }
                else{
                    string Max = "", EffectAvoidChance, DamagePercent;
                    switch(SkillManager.CH_Effect_Damage){
                        case 1:
                            DamagePercent = "1";
                            break;
                        case 2:
                            DamagePercent = "1.5";
                            break;
                        default:
                            DamagePercent = "0.5";
                            break;
                    }
                    switch(SkillManager.CH_Effect_EVChance){
                        case 1:
                            EffectAvoidChance = "7";
                            break;
                        case 2:
                            EffectAvoidChance = "5";
                            break;
                        default:
                            EffectAvoidChance = "9";
                            break;
                    }
                    switch(SkillManager.CH_Effect_Duration){
                        case 1:
                            EffectDuration = "2-6";
                            break;
                        case 2:
                            EffectDuration = "4-8";
                            break;
                        default:
                            EffectDuration = "1-5";
                            break;
                    }
                    if(SkillManager.CH_Ultimate_HPPercent) Max = Language_Changer.Instance.GetText("Max");
                    if(SkillManager.CH_Ultimate_RandomDebuff) UltimateDescription = Language_Changer.Instance.GetText("Active_Skill_7_Description_Ultimate", "ActiveSkills");
                    Information.text = string.Format(Language_Changer.Instance.GetText("Active_Skill_7_Description_Effect", "ActiveSkills"), DamagePercent, EffectAvoidChance, Cooldown, ManaUsage, Max, UltimateDescription, EffectDuration);
                }
                break;
            case 8:
                string Heal, EffectHeal = "";
                switch(SkillManager.V_Mana){
                    case 1:
                        ManaUsage = "130";
                        break;
                    case 2:
                        ManaUsage = "100";
                        break;
                    default:
                        ManaUsage = "150";
                        break;
                }
                switch(SkillManager.V_Heal){
                    case 1:
                        Heal = "15";
                        break;
                    case 2:
                        Heal = "20";
                        break;
                    case 3:
                        Heal = "30";
                        break;
                    default:
                        Heal = "10";
                        break;
                }
                switch(SkillManager.V_EffectHeal){
                    case 1:
                        EffectHeal = string.Format(Language_Changer.Instance.GetText("Active_Skill_8_Description_Effect", "ActiveSkills"), 2);
                        break;
                    case 2:
                        EffectHeal = string.Format(Language_Changer.Instance.GetText("Active_Skill_8_Description_Effect", "ActiveSkills"), 5);
                        break;
                    default:
                        break;
                }
                switch(SkillManager.V_Damage){
                    case 1:
                        Damage = "300";
                        break;
                    case 2:
                        Damage = "400";
                        break;
                    case 3:
                        Damage = "600";
                        break;
                    default:
                        Damage = "200";
                        break;
                }
                Cooldown = "6";
                if(SkillManager.V_Ultimate){
                    UltimateDescription = Language_Changer.Instance.GetText("Active_Skill_8_Description_Ultimate", "ActiveSkills");
                    EffectHeal = string.Format(Language_Changer.Instance.GetText("Active_Skill_8_Description_Effect", "ActiveSkills"), 10);    
                }
                Information.text = string.Format(Language_Changer.Instance.GetText("Active_Skill_8_Description", "ActiveSkills"), Damage, Heal, Cooldown, ManaUsage, EffectHeal, UltimateDescription);
                break;
            default:
                Information.text = "Wild Active skill will appear in new update";
                break;
        }
    }

    public void ActiveSkillRemove(int ID){
        for(int i = 1; i<=ActiveSlots[0]; i++){
            if(ID==ActiveSlots[i]){
                ActiveSlots[i]=-1;
                for(int j = 1; j<ActiveSlots[0]; ++j){
                    if(ActiveSlots[j]==-1){
                        ActiveSlots[j] = ActiveSlots[j+1];
                        ActiveSlots[j+1] = -1;
                        ObjectMove(Slots[ActiveSlots[j]], ActiveSlotsPos[j], ActiveSlotsPos[j-1]);
                    }
                }
                --ActiveSlots[0];
            }
        }
    }

    public int GetPosition(int ID){
        for(int i = 1; i<=ActiveSlots[0]; ++i) if(ID==ActiveSlots[i]) return i-1;
        return 0;
    }

    public void ReloadDescription(){
        Information.alignment = TextAlignmentOptions.Capline;
        Information.text = Language_Changer.Instance.GetText("Active_Skills_Default", "ActiveSkills");
        Title.text = "";
    }

    public void ReloadImages(){
        if(MaxSlots >=2) ActiveSlotsGO[0].GetComponent<Image>().sprite = Empty;
        if(MaxSlots >=3) ActiveSlotsGO[1].GetComponent<Image>().sprite = Empty;
        if(MaxSlots ==4) ActiveSlotsGO[2].GetComponent<Image>().sprite = Empty;
    }

}
