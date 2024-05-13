using System;
using System.Reflection;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class Skills : MonoBehaviour
{
    //public Image Button1, Close, Background;
    public ActiveSkillsManager ActiveSkillsManager;
    // public Accuracy Accuracy;
    // public Evasion Evasion;
    public Sorcery Sorcery;
    public Camera MainCamera;
    public Player player;
    public Game game;
    public TextMeshProUGUI SkillPointsCount, BranchName, BranchInformationText0, BranchInformationText1, BranchInformationText2, BranchInformationText3, BranchInformationText4, BranchInformationText5, BranchInformationText6;
    //public GameObject Information_Skills_G, Button_Skills_G, Requirements_Skills_G, Title_Skills_G, X_G;
    public Image BranchImage0, BranchImage1, InformationWindowSkillImage;
    public Sprite AccuracySprite, EvasionSprite, SorcerySprite, UniversalSprite;
    public GameObject Information_Skills_BG;
    public int ChecklistItems = 0;
    public int EvasionMain, AccuracyMain, PracticePlus;
    public bool BSU, CHU, CH_Effect, VU, ManaOverdrain, BS_Poison_AddDuration, BS_NoEvasion, BS_Ultimate, CH_Ultimate_RandomDebuff, CH_Ultimate_HPPercent, V_Ultimate;
    public bool PHU, Parrying_Unlock;
    public bool BLU, BrutalityStreak_Unlock;
    public int MR_1_1_Sorcery, Mana_10_1_Sorcery, Shield_MagicDef_2Perc_1_Sorcery, Shield_MagicDef_2Perc_2_Sorcery, Shield_DmgReturn_1Perc_1_Sorcery, Shield_DmgReturn_1Perc_2_Sorcery, Mana_10_2_Sorcery, Mana_1Perc_1_Sorcery, Mana_2Perc_1_Sorcery, HP_5_1_Sorcery, MR_1_2_Sorcery, ManaUsage_1Perc_1_Sorcery, MR_2_1_Sorcery, DMG_Resistance_1_1_Sorcery, Mana_10_3_Sorcery, ManaUsage_1Perc_2_Sorcery, Mana_2Perc_2_Sorcery, Mana_20_1_Sorcery, ManaUsage_1Perc_3_Sorcery, Mana_3Perc_1_Sorcery, Mana_2Perc_3_Sorcery, ManaUsage_3Perc_1_Sorcery, HP_10_1_Sorcery, ManaUsage_1Perc_4_Sorcery, MR_2_2_Sorcery, HP_10_2_Sorcery, MR_3_1_Sorcery, MR_3_2_Sorcery, HP_10_3_Sorcery, ManaUsage_3Perc_2_Sorcery, MR_3_3_Sorcery, HP_15_1_Sorcery, DMG_Resistance_1_2_Sorcery; 
    /*public bool HP_5_1_Magic_Tier1, MR_1_1_Magic_Tier1, EV_1_ACC_1_1_Magic_Tier1, M_1Perc_1_Magic_Tier1, Mana_10_1_Magic_Tier1, WeaponSkillChance_5Perc_1_Magic_Tier1, Mana_10_2_Magic_Tier1, MR_1_MCost_2Perc_Magic_Tier1, ;
    public bool ManaOverdrain, HP_5_2_Magic_Tier2, Mana_10_3_Magic_Tier2, HP_10_1_Magic_Tier2, Mana_10_4_Magic_Tier2, EV_2_ACC_2_1_Magic_Tier2, MR_1_3_Magic_Tier2, AddSlot_Magic_Tier2, Mana_10_5_Magic_Tier2, MR_1_2_Magic_Tier2, EV_1_ACC_1_2_Magic_Tier2;
    public bool DMG_Resistance_1_1_Magic_Tier3, EV_2_ACC_2_2_Magic_Tier3, Mana_10_6_Magic_Tier3, MR_2_1_Magic_Tier3, Mana_20_1_Magic_Tier3, MCost_1Perc_1_Magic_Tier3, HP_15_1_Magic_Tier3, HP_5_3_Magic_Tier3, EV_1_ACC_1_3_Magic_Tier3, MR_1_4_Magic_Tier3, AtkSpeed_1_1_Magic_Tier3, HP_5_4_Magic_Tier3, Mana_20_2_Magic_Tier3, MR_1_5_Magic_Tier3, SkilledTree_1_Magic_Tier3;
    public bool MR_2_2_Magic_Tier4, Mana_20_3_Magic_Tier4, M_2Perc_1_Magic_Tier4, HP_10_2_Magic_Tier4, EV_2_ACC_2_3_Magic_Tier4, HP_15_2_Magic_Tier4, MR_2_3_Magic_Tier4, MCost_2Perc_1_Magic_Tier4, EV_2_ACC_2_4_Magic_Tier4, Mana_20_4_Magic_Tier4, UltimateUnlock_Magic_Tier4;
    public bool Mana_2Perc_2_Magic_Tier5, Mana_10_7_Magic_Tier5, MR_2_4_Magic_Tier5, Mana_20_7_Magic_Tier5, MCost_1Perc_2_Magic_Tier5, MR_2_6_Magic_Tier5, EV_5_ACC_5_2_Magic_Tier5, HP_20_1_Magic_Tier5, HPRegen_10_1_Magic_Tier5, DMG_Resistance_2_1_Magic_Tier5, MCost_2Perc_2_Magic_Tier5, Mana_20_5_Magic_Tier5, MR_2_5_Magic_Tier5, Mana_20_6_Magic_Tier5, EV_5_ACC_5_1_Magic_Tier5, HPRegen_20_1_Magic_Tier5, MCost_2Perc_3_Magic_Tier5, HP_20_2_Magic_Tier5, Mana_20_8_Magic_Tier5, MR_2_7_Magic_Tier5, DMG_Resistance_2_2_Magic_Tier5, Mana_20_9_Magic_Tier5, HPRegen_20_2_Magic_Tier5;
    public bool , AvoidChance_2Perc_1_Evasion_Tier1, EV_1_ACC_1_1_Evasion_Tier1, HP_5_1_Evasion_Tier1, EV_3_1_Evasion_Tier1, WeaponSkillChance_5Perc_1_Evasion_Tier1, AtkSpeed_1_1_Evasion_Tier1, AvoidChance_3Perc_1_Evasion_Tier1, DMG_Resistance_1_1_Evasion_Tier1;
    public bool , DMG_Resistance_1_2_Evasion_Tier2, AvoidChance_5Perc_1_Evasion_Tier2, AvoidChance_5Perc_2_Evasion_Tier2, HP_5_2_Evasion_Tier2, AtkSpeed_1_2_Evasion_Tier2, HP_10_1_Evasion_Tier2, EV_3_2_Evasion_Tier2, EV_1_ACC_1_2_Evasion_Tier2, EV_2_ACC_2_1_Evasion_Tier2, AddSlot_Evasion_Tier2;
    public bool HP_5_1_Accuracy_Tier1, MaxCrit_5Perc_1_Accuracy_Tier1, ACC_3_1_Accuracy_Tier1, WeaponSkillChance_2Perc_1_Accuracy_Tier1, HP_5_2_Accuracy_Tier1, WeaponSkillChance_3Perc_1_Accuracy_Tier1, EV_1_ACC_1_1_Accuracy_Tier1, HP_5_3_Accuracy_Tier1, HP_1Perc_1_Accuracy_Tier1;
    public bool , ACC_3_2_Accuracy_Tier2, MaxCrit_5Perc_2_Accuracy_Tier2, HP_10_1_Accuracy_Tier2, ACC_3_3_Accuracy_Tier2, HP_10_2_Accuracy_Tier2, MaxCrit_5Perc_3_Accuracy_Tier2, HP_1Perc_2_Accuracy_Tier2, EV_1_ACC_1_2_Accuracy_Tier2, HP_10_3_Accuracy_Tier2, EV_2_ACC_2_1_Accuracy_Tier2, AddSlot_Accuracy_Tier2;
*/
    public int BS_Mana = 0, BS_Cooldown = 0, BS_Damage = 0, BS_Weakness = 0, ManaOverdrain_Perc = 0, ManaOverdrain_Potion = 0, CH_Damage = 0, CH_Mana = 0, CH_Cooldown = 0, CH_Effect_EVChance = 0, CH_Effect_Damage = 0, CH_Effect_Duration = 0, V_Heal = 0, V_Damage = 0, V_EffectHeal = 0, V_Mana = 0;
    public int PH_Cooldown = 0, PH_Damage = 0, PH_WeaponSkillChance = 0, Parrying_Chance = 0, Parrying_Damage = 0, Parrying_Perc = 0;
    public int BL_ReturnDamage = 0, BL_Chance = 0, BL_Cooldown = 0, BrutalityStreak_EnergySave = 0, BrutalityStreak_AvoidChance = 0;
    public string[,] Checklist = new string[2,50]; 
    public string InvokeMethod, InvokeClass; 
    public bool IsChecked;

    public void Upgradebutton_click(){
        Type type = Type.GetType(InvokeClass);
        object obj = FindObjectOfType(type);
        MethodInfo method = type.GetMethod(InvokeMethod + "_Upgrade");
        method.Invoke(obj, null);
    }

    public void SkillPointsCount_Update(){
        SkillPointsCount.text = player.SkillPoints + "";
    }

    public void Skills_BG_Move(){
        Vector2 MousePos = Input.mousePosition;
        Vector2 MovePos = MainCamera.ScreenToWorldPoint(MousePos);
        //Debug.Log(MousePos);
        //Debug.Log(MovePos);
        if(MovePos.y >=0.7 && MovePos.x >=-0.5) Information_Skills_BG.transform.position = MovePos+new Vector2(-2.8f, -2.3f);
        else if(MovePos.y >=0.7) Information_Skills_BG.transform.position = MovePos+new Vector2(2.8f, -2.3f);
        else if(MovePos.x >=-0.5) Information_Skills_BG.transform.position = MovePos+new Vector2(-2.5f, 2.7f);
        else Information_Skills_BG.transform.position = MovePos+new Vector2(2.8f, 2.7f);
    }
    //Convert.ToInt32()
    //adding stats from skill tree
    public void Skilltree_Evasion(){
        player.Skills["BaseEvasion"] = EvasionMain;// + Convert.ToInt32(EV_1_ACC_1_1_Magic_Tier1) + Convert.ToInt32(EV_1_ACC_1_2_Magic_Tier2) + Convert.ToInt32(EV_2_ACC_2_1_Magic_Tier2)*2 + Convert.ToInt32(EV_2_ACC_2_2_Magic_Tier3)*2 + Convert.ToInt32(EV_1_ACC_1_3_Magic_Tier3) + Convert.ToInt32(EV_2_ACC_2_3_Magic_Tier4)*2 + Convert.ToInt32(EV_2_ACC_2_4_Magic_Tier4)*2 + Convert.ToInt32(EV_5_ACC_5_1_Magic_Tier5)*5 + Convert.ToInt32(EV_5_ACC_5_2_Magic_Tier5)*5 + Convert.ToInt32(EV_3_1_Evasion_Tier1)*3 + Convert.ToInt32(EV_1_ACC_1_1_Evasion_Tier1) + Convert.ToInt32(EV_2_ACC_2_1_Evasion_Tier2)*2 + Convert.ToInt32(EV_3_2_Evasion_Tier2)*3 + Convert.ToInt32(EV_1_ACC_1_2_Evasion_Tier2) + Convert.ToInt32(EV_1_ACC_1_1_Accuracy_Tier1) + Convert.ToInt32(EV_1_ACC_1_2_Accuracy_Tier2) + Convert.ToInt32(EV_2_ACC_2_1_Accuracy_Tier2)*2;
        player.UpdateAllStats();
    }

    public void Skilltree_Accuracy(){
        player.Skills["BaseAccuracy"] = AccuracyMain;
        player.UpdateAllStats();
    }

    public void Skilltree_Mana(){
        player.Skills["BaseMana"] = PracticePlus*10;
        player.UpdateAllStats();
    }

    public void Skilltree_Health(){
        player.Skills["BaseHealth"] = 0;
        player.UpdateAllStats();
    }

    public void Skilltree_HealthRegen(){
        player.Skills["BaseHealthRegen"] = 0;
        player.UpdateAllStats();
    }

    public void Skilltree_ManaRegen(){
        player.Skills["BaseManaRegen"] = 0;
        player.UpdateAllStats();
    }

    public void Skilltree_ManaModifier(){
        player.BaseManaModifier = 1f;
        player.UpdateAllStats();
    }

    public void Skilltree_ManaCost(){
        player.BaseManaCost = 1f;
        player.UpdateAllStats();
    }

    public void Skilltree_HealthModifier(){
        player.BaseHealthModifier = 1f;
        player.UpdateAllStats();
    }

    public void Skilltree_AttackSpeed(){
        player.BaseAttackSpeed = 0;
        player.UpdateAllStats();
    }

    public void Skilltree_DamageResistance(){
        player.BaseDamageResistance = DevTools.Instance.Resistance;
        player.UpdateAllStats();
    }

    public void Skilltree_WeaponSkillChance(){
        player.Skills["WeaponSkillChance"] = 5;
    }

    public void Skilltree_SkilledTree(){
        game.SkilledTreeChance = 0;
    }

    public void Skilltree_MaxAvoidChance(){
        player.MaxAvoidChance = 25;
    }

    public void Skilltree_MaxCritChance(){
        player.MaxCritChance = 25;
    }

    public void Skilltree_ActiveSkillsSlots(){
        ActiveSkillsManager.MaxSlots = 1;
        ActiveSkillsManager.ReloadImages();
    }

    public void Checklist_Add(string a, string b){
        Checklist[0, ChecklistItems] = a;
        Checklist[1, ChecklistItems] = b;
        ++ChecklistItems;
    } 

    public void Checklist_Remove(int index){
        Checklist[0, index] = "";
        Checklist[1, index] = "";
        for(int i = index;i<ChecklistItems-1;++i){
            (Checklist[0, i], Checklist[0, i+1]) = (Checklist[0, i+1], Checklist[0, i]);
            (Checklist[1, i], Checklist[1, i+1]) = (Checklist[1, i+1], Checklist[1, i]);
        }
        --ChecklistItems;
    } 

    public void CheckAll(){
        for(int i = 0; i<ChecklistItems; ++i){
            IsChecked = false;
            Type type = Type.GetType(Checklist[1, i]);
            //Debug.Log(Checklist[1, i]);
            object obj = FindObjectOfType(type);
            MethodInfo method = type.GetMethod(Checklist[0, i] + "_Check");
            //Debug.Log(Checklist[0, i]);
            method.Invoke(obj, null);
            if(IsChecked){
                Checklist_Remove(i);
                --i;
            }
        }
    }

    public void ChangeBranch(string BranchNameToSet){
        switch(BranchNameToSet){
            case "Sorcery":
                BranchName.text = Language_Changer.Instance.GetText("Sorcery", "Skills");
                BranchInformationText0.text  = "<sprite=\"Skills\" name=\"Upgrades\">";
                BranchInformationText1.text  = "<sprite=\"Skills\" name=\"Mana\">";
                BranchInformationText2.text  = "<sprite=\"Skills\" name=\"ManaRegen\">";
                BranchInformationText3.text  = "<sprite=\"Skills\" name=\"ManaUsage\">";
                BranchInformationText4.text  = "<sprite=\"Skills\" name=\"ManaPercentBoost\">";
                BranchInformationText5.text  = "<sprite=\"Skills\" name=\"Health\">";
                BranchInformationText6.text  = "<sprite=\"Skills\" name=\"DamageResistance\">";
                BranchImage0.sprite = SorcerySprite;
                BranchImage1.sprite = SorcerySprite;
                break;
            case "Accuracy":
                BranchName.text = Language_Changer.Instance.GetText("Accuracy", "Skills");
                BranchInformationText0.text  = "<sprite=\"Skills\" name=\"Upgrades\">";
                BranchInformationText1.text  = "<sprite=\"Skills\" name=\"Accuracy\">";
                BranchInformationText2.text  = "<sprite=\"Skills\" name=\"CritChance\">";
                BranchInformationText3.text  = "<sprite=\"Skills\" name=\"Damage\">";
                BranchInformationText4.text  = "<sprite=\"Skills\" name=\"DamagePercentBoost\">";
                BranchInformationText5.text  = "<sprite=\"Skills\" name=\"Health\">";
                BranchInformationText6.text  = "<sprite=\"Skills\" name=\"HealthPercentBoost\">";
                BranchImage0.sprite = AccuracySprite;
                BranchImage1.sprite = AccuracySprite;
                break;
            case "Evasion":
                BranchName.text = Language_Changer.Instance.GetText("Evasion", "Skills");
                BranchInformationText0.text  = "<sprite=\"Skills\" name=\"Upgrades\">";
                BranchInformationText1.text  = "<sprite=\"Skills\" name=\"Evasion\">";
                BranchInformationText2.text  = "<sprite=\"Skills\" name=\"AvoidChance\">";
                BranchInformationText3.text  = "<sprite=\"Skills\" name=\"Stamina\">";
                BranchInformationText4.text  = "<sprite=\"Skills\" name=\"StaminaRegen\">";
                BranchInformationText5.text  = "<sprite=\"Skills\" name=\"DamageResistance\">";
                BranchInformationText6.text  = "<sprite=\"Skills\" name=\"Health\">";
                BranchImage0.sprite = EvasionSprite;
                BranchImage1.sprite = EvasionSprite;
                break;
            case "Universal":
                BranchName.text = Language_Changer.Instance.GetText("Universal_Upgrades", "Skills");
                BranchInformationText0.text  = "<sprite=\"Skills\" name=\"Upgrades\">";
                BranchInformationText1.text  = "<sprite=\"Skills\" name=\"UpgradesAccuracy\">";
                BranchInformationText2.text  = "<sprite=\"Skills\" name=\"UpgradesEvasion\">";
                BranchInformationText3.text  = "<sprite=\"Skills\" name=\"UpgradesSorcery\">";
                BranchInformationText4.text  = "<sprite=\"Skills\" name=\"SkilledTree\">";
                BranchInformationText5.text  = "<sprite=\"Skills\" name=\"EnchantTriggerChance\">";
                BranchInformationText6.text  = "<sprite=\"Skills\" name=\"HealthRegen\">";
                BranchImage0.sprite = UniversalSprite;
                BranchImage1.sprite = UniversalSprite;
                break;
            default:
                BranchName.text = "ERROR";
                break;
        }
    }
    
}
