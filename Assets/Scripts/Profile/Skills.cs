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
    public Accuracy Accuracy;
    public Evasion Evasion;
    public Sorcery Sorcery;
    public Universal Universal;
    // public Shadow Shadow;
    public Camera MainCamera;
    public Player player;
    public Game game;
    public TextMeshProUGUI SkillPointsCount, BranchName, BranchInformationText0, BranchInformationText1, BranchInformationText2, BranchInformationText3, BranchInformationText4, BranchInformationText5, BranchInformationText6;
    //public GameObject Information_Skills_G, Button_Skills_G, Requirements_Skills_G, Title_Skills_G, X_G;
    public Image BranchImage0, BranchImage1, InformationWindowSkillImage;
    public Sprite AccuracySprite, EvasionSprite, SorcerySprite, UniversalSprite;
    public GameObject Information_Skills_BG;
    //public int ChecklistItems = 0;
    public int EvasionMain, AccuracyMain, PracticePlus;
    public bool EnemyInfoUnlock, EnemyStatsUnlock, PassiveSkillsInfoUnlock;
    public bool BSU, CHU, CH_Effect, VU, ManaOverdrain, BS_Poison_AddDuration, BS_NoEvasion, BS_Ultimate, CH_Ultimate_RandomDebuff, CH_Ultimate_HPPercent, V_Ultimate;
    public bool PHU, Parry_Unlock, DoubleStaminaUnlock, KDU, KD_Bleeding, KD_Poison, KD_IgnoreAvoid, DFU, DF_Debuff, DF_DoubleEffect;
    public bool BLU, BrutalityStreak_Unlock, BrutalityStreak_SpecialAttacksTrigger;
    public int Shield_MagicDef_2Perc_1, Shield_MagicDef_2Perc_2, Shield_DmgReturn_1Perc_1, Shield_DmgReturn_1Perc_2, DMGCapOverdamage_Unlock;
    public int Shield_NoStaminaUsage_5Perc, Shield_DamageBoost_3Perc;
    public int Shield_ParryChance_1Perc, Shield_DMGResistance_1Perc_1, Shield_DMGResistance_2Perc_1, Shield_AvoidChance1Perc_1, Shield_AvoidChance2Perc_1;
    public int MR_1_1_Sorcery, Mana_10_1_Sorcery, Mana_10_2_Sorcery, Mana_1Perc_1_Sorcery, Mana_2Perc_1_Sorcery, HP_5_1_Sorcery, MR_1_2_Sorcery, ManaUsage_1Perc_1_Sorcery, MR_2_1_Sorcery, DMG_Resistance_1_1_Sorcery, Mana_10_3_Sorcery, ManaUsage_1Perc_2_Sorcery, Mana_2Perc_2_Sorcery, Mana_20_1_Sorcery, ManaUsage_1Perc_3_Sorcery, Mana_3Perc_1_Sorcery, Mana_2Perc_3_Sorcery, ManaUsage_3Perc_1_Sorcery, HP_10_1_Sorcery, ManaUsage_1Perc_4_Sorcery, MR_2_2_Sorcery, HP_10_2_Sorcery, MR_3_1_Sorcery, MR_3_2_Sorcery, HP_10_3_Sorcery, ManaUsage_3Perc_2_Sorcery, MR_3_3_Sorcery, HP_15_1_Sorcery, DMG_Resistance_1_2_Sorcery; 
    public int DMG_2_1_Accuracy, DMG_1Perc_1_Accuracy, HP_1Perc_1_Accuracy, EV_4_ACC_4_1_Accuracy, HP_25_1_Accuracy, DMG_2Perc_1_Accuracy, HP_2Perc_1_Accuracy, DMG_4_1_Accuracy, DMG_4_2_Accuracy, DMG_2Perc_2_Accuracy, DMG_5_1_Accuracy, EV_10_ACC_10_1_Accuracy, HP_30_1_Accuracy, EV_10_ACC_10_2_Accuracy, EV_6_ACC_6_1_Accuracy, DMG_5_2_Accuracy, DMG_5Perc_1_Accuracy, HP_5Perc_1_Accuracy, CritChance_2Perc_1_Accuracy, ACC_10_1_Accuracy, CritDamage_5Perc_1_Accuracy, CritChance_2Perc_2_Accuracy, CritChance_2Perc_3_Accuracy, CritDamage_5Perc_2_Accuracy, HP_30_2_Accuracy, HP_2Perc_2_Accuracy, CritChance_4Perc_1_Accuracy, HP_25_2_Accuracy, CritDamage_10Perc_1_Accuracy, ACC_10_3_Accuracy, CritDamage_10Perc_2_Accuracy, CritDamage_20Perc_1_Accuracy, ACC_10_4_Accuracy, HP_40_1_Accuracy, ACC_10_2_Accuracy, EV_10_ACC_10_3_Accuracy;
    public int AvoidChance_1Perc_1_Evasion, EV_4_1_Evasion, AvoidChance_1Perc_2_Evasion, HP_10_1_Evasion, DMG_Resistance_1Perc_1_Evasion, AvoidChance_2Perc_1_Evasion, AvoidChance_2Perc_2_Evasion, EV_8_1_Evasion, HP_15_1_Evasion, AvoidChance_2Perc_3_Evasion, EV_10_1_Evasion, DMG_Resistance_1Perc_2_Evasion, EV_8_2_Evasion, EV_10_2_Evasion, HP_10_2_Evasion, StaminaRegen_1_1_Evasion, MaxStamina_1_1_Evasion, EV_6_ACC_6_1_Evasion, StaminaRegen_1_2_Evasion, HP_10_3_Evasion, MaxStamina_1_2_Evasion, EV_4_ACC_4_1_Evasion, StaminaRegen_1_3_Evasion, HP_15_2_Evasion, EV_10_ACC_10_1_Evasion, MaxStamina_1_3_Evasion, StaminaRegen_2_1_Evasion, EV_10_ACC_10_2_Evasion, MaxStamina_1_4_Evasion, DMG_resistance_1Perc_3_Evasion, EV_10_ACC_10_3_Evasion;
    public int HPRegen, AddActveSkillSlot, ShieldStacking, SkilledTree_1Perc_Universal, StaminaRegen_1_1_Universal, EV_1_ACC_1_1_Universal, EV_2_ACC_2_1_Universal, EV_4_ACC_4_1_Universal, EV_5_ACC_5_1_Universal, EV_8_ACC_8_1_Universal, DMG_Resistance_1_1_Universal, DMG_Resistance_1_2_Universal, WeaponSkillChance_1Perc_1_Universal, WeaponSkillChance_2Perc_1_Universal, HP_2Perc_1_Universal, HP_3Perc_1_Universal;
    public int BS_Mana = 0, BS_Cooldown = 0, BS_Damage = 0, BS_Weakness = 0, ManaOverdrain_Perc = 0, ManaOverdrain_Potion = 0, CH_Damage = 0, CH_Mana = 0, CH_Cooldown = 0, CH_Effect_EVChance = 0, CH_Effect_Damage = 0, CH_Effect_Duration = 0, V_Heal = 0, V_Damage = 0, V_EffectHeal = 0, V_Mana = 0;
    public int PH_Cooldown = 0, PH_Damage = 0, PH_WeaponSkillChance = 0, Parry_Chance = 0, Parry_Damage = 0, Parry_Perc = 0, KD_Amount = 0, KD_Damage = 0, KD_Cooldown = 0, KD_NoStaminaUse = 0, KD_Explosive = 0, DF_EffectDuration = 0, DF_Debuff_Percent = 0, DF_Debuff_Stamina = 0, DF_Debuff_Duration = 0;
    public int BL_ReturnDamage = 0, BL_Chance = 0, BL_Cooldown = 0, BrutalityStreak_EnergySave = 0, BrutalityStreak_AvoidChance = 0, DMGCapOverdamage_10Perc_1 = 0, DMGCapOverdamage_10Perc_2 = 0;
    //public string[,] Checklist = new string[2,50]; 
    public string InvokeMethod, InvokeClass; 
    public float Shield_MagicDefence = 0, Shield_DamageReturn = 0, Shield_NoStaminaUsageChance = 0, Shield_DamageBoost = 0, DMGCapOverdamage = 1.5f, Crit_Damage = 0.5f, DamageModifier = 1f, Shield_DamageResistance = 0, Shield_AvoidChance = 0;
    //public bool IsChecked;
    public static Skills Instance;

    void Awake(){
        Instance = this;
    }
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
        int AllEvasionMain;
        if(EvasionMain == 0) AllEvasionMain = 0;
        else if(EvasionMain<5) AllEvasionMain = (EvasionMain-1)*4 + 2;
        else if(EvasionMain<15) AllEvasionMain =  (EvasionMain-5)*6 + 18;
        else if(EvasionMain<24) AllEvasionMain = (EvasionMain-15)*8 + 78;
        else AllEvasionMain = (EvasionMain-24)*10 + 150;
        player.Skills["BaseEvasion"] = AllEvasionMain + EV_4_ACC_4_1_Accuracy*4 + EV_6_ACC_6_1_Accuracy*6 + EV_10_ACC_10_1_Accuracy*10 + EV_10_ACC_10_2_Accuracy*10 + EV_10_ACC_10_3_Accuracy*10 + EV_4_1_Evasion*4 + EV_8_1_Evasion*8 + EV_8_2_Evasion*8 + EV_10_1_Evasion*10 + EV_10_2_Evasion*10 + EV_4_ACC_4_1_Evasion*4 + EV_6_ACC_6_1_Evasion*6 + EV_10_ACC_10_1_Evasion*10 + EV_10_ACC_10_2_Evasion*10 + EV_10_ACC_10_3_Evasion*10 + EV_1_ACC_1_1_Universal + EV_2_ACC_2_1_Universal*2 + EV_4_ACC_4_1_Universal*4 + EV_5_ACC_5_1_Universal*5 + EV_8_ACC_8_1_Universal*8;
        player.UpdateAllStats();
    }

    public void Skilltree_Accuracy(){
        int AllAccuracyMain = 0;
        if(AccuracyMain == 0) AllAccuracyMain = 0;
        else if(AccuracyMain<5) AllAccuracyMain = (AccuracyMain-1)*4 + 2;
        else if(AccuracyMain<15) AllAccuracyMain =  (AccuracyMain-5)*6 + 18;
        else if(AccuracyMain<24) AllAccuracyMain = (AccuracyMain-15)*8 + 78;
        else AllAccuracyMain = (AccuracyMain-24)*10 + 150;
        player.Skills["BaseAccuracy"] = AllAccuracyMain + ACC_10_1_Accuracy*10 + ACC_10_2_Accuracy*10 + ACC_10_3_Accuracy*10 + ACC_10_4_Accuracy*10 + EV_4_ACC_4_1_Accuracy*4 + EV_6_ACC_6_1_Accuracy*6 + EV_10_ACC_10_1_Accuracy*10 + EV_10_ACC_10_2_Accuracy*10 + EV_10_ACC_10_3_Accuracy*10 + EV_4_ACC_4_1_Evasion*4 + EV_6_ACC_6_1_Evasion*6 + EV_10_ACC_10_1_Evasion*10 + EV_10_ACC_10_2_Evasion*10 + EV_10_ACC_10_3_Evasion*10 + EV_1_ACC_1_1_Universal + EV_2_ACC_2_1_Universal*2 + EV_4_ACC_4_1_Universal*4 + EV_5_ACC_5_1_Universal*5 + EV_8_ACC_8_1_Universal*8;
        player.UpdateAllStats();
    }

    public void Skilltree_Mana(){
        player.Skills["BaseMana"] = PracticePlus*10 + Mana_10_1_Sorcery*10 + Mana_10_2_Sorcery*10 + Mana_10_3_Sorcery*10 + Mana_20_1_Sorcery*20;
        player.UpdateAllStats();
    }

    public void Skilltree_Health(){
        player.Skills["BaseHealth"] = HP_5_1_Sorcery*5 + HP_10_1_Sorcery*10 + HP_10_2_Sorcery*10 + HP_10_3_Sorcery*10 + HP_15_1_Sorcery*15 + HP_25_1_Accuracy*25 + HP_25_2_Accuracy*25 + HP_30_1_Accuracy*30 + HP_30_2_Accuracy*30 + HP_40_1_Accuracy*40 + HP_10_1_Evasion*10 + HP_15_1_Evasion*15 + HP_10_2_Evasion*10 + HP_10_3_Evasion*10 + HP_15_2_Evasion*15;
        player.UpdateAllStats();
    }

    public void Skilltree_HealthRegen(){
        int AllHPRegen;
        if(HPRegen == 0) AllHPRegen = 0;
        else if(HPRegen<5) AllHPRegen = (HPRegen-1)*4 + 2;
        else if(HPRegen<15) AllHPRegen =  (HPRegen-5)*6 + 18;
        else if(HPRegen<24) AllHPRegen = (HPRegen-15)*8 + 78;
        else AllHPRegen = (HPRegen-24)*10 + 150;
        player.Skills["BaseHealthRegen"] = AllHPRegen;
        player.UpdateAllStats();
    }

    public void Skilltree_ManaRegen(){
        player.Skills["BaseManaRegen"] = MR_1_1_Sorcery + MR_1_2_Sorcery + MR_2_1_Sorcery*2 + MR_2_2_Sorcery*2 + MR_3_1_Sorcery*3 + MR_3_2_Sorcery*3 + MR_3_3_Sorcery*3;
        player.UpdateAllStats();
    }

    public void Skilltree_ManaModifier(){
        player.BaseManaModifier = 1f+(Mana_2Perc_1_Sorcery*2 + Mana_2Perc_2_Sorcery*2 + Mana_2Perc_3_Sorcery*2 + Mana_1Perc_1_Sorcery + Mana_3Perc_1_Sorcery*3)/100f;
        player.UpdateAllStats();
    }

    public void Skilltree_ManaCost(){
        player.BaseManaCost = 1f-(ManaUsage_1Perc_1_Sorcery + ManaUsage_1Perc_2_Sorcery + ManaUsage_1Perc_3_Sorcery + ManaUsage_3Perc_1_Sorcery*3 + ManaUsage_1Perc_4_Sorcery + ManaUsage_3Perc_2_Sorcery*3)/100f;
        player.UpdateAllStats();
    }

    public void Skilltree_HealthModifier(){
        player.BaseHealthModifier = 1f + (HP_1Perc_1_Accuracy + HP_2Perc_1_Accuracy*2 + HP_2Perc_2_Accuracy*2 + HP_5Perc_1_Accuracy*5 + HP_2Perc_1_Universal*2 + HP_3Perc_1_Universal*3)/100f;
        player.UpdateAllStats();
    }

    public void Skilltree_AttackSpeed(){
        player.BaseAttackSpeed = 0 + (StaminaRegen_1_1_Evasion + StaminaRegen_1_2_Evasion + StaminaRegen_1_3_Evasion + StaminaRegen_2_1_Evasion*2 + StaminaRegen_1_1_Universal)/10f;
        player.UpdateAllStats();
    }

    public void Skilltree_DamageResistance(){
        player.BaseDamageResistance = (DevTools.Instance.Resistance + DMG_Resistance_1_1_Sorcery + DMG_Resistance_1_2_Sorcery + DMG_Resistance_1Perc_1_Evasion + DMG_Resistance_1Perc_2_Evasion + DMG_resistance_1Perc_3_Evasion + DMG_Resistance_1_1_Universal + DMG_Resistance_1_2_Universal)/100f;
        player.UpdateAllStats();
    }

    public void Skilltree_WeaponSkillChance(){
        player.Skills["WeaponSkillChance"] = 5 + WeaponSkillChance_1Perc_1_Universal + WeaponSkillChance_2Perc_1_Universal*2;
    }

    public void Skilltree_SkilledTree(){
        game.SkilledTreeChance = 0 + SkilledTree_1Perc_Universal;
    }

    public void Skilltree_MaxAvoidChance(){
        player.MaxAvoidChance = 25 + AvoidChance_1Perc_1_Evasion + AvoidChance_1Perc_2_Evasion + AvoidChance_2Perc_1_Evasion*2 + AvoidChance_2Perc_2_Evasion*2 + AvoidChance_2Perc_3_Evasion*2;
    }

    public void Skilltree_MaxCritChance(){
        player.MaxCritChance = 25 + CritChance_2Perc_1_Accuracy*2 + CritChance_2Perc_2_Accuracy*2 + CritChance_2Perc_3_Accuracy*2 + CritChance_4Perc_1_Accuracy*4;
    }

    public void Skilltree_ActiveSkillsSlots(){
        ActiveSkillsManager.MaxSlots = 1 + AddActveSkillSlot;
        ActiveSkillsManager.ReloadImages();
    }

    public void Skilltree_Shield(){
        Shield_MagicDefence = (Shield_MagicDef_2Perc_1*2 + Shield_MagicDef_2Perc_2*2)/100f;
        Shield_DamageReturn = (Shield_DmgReturn_1Perc_1 + Shield_DmgReturn_1Perc_2)/100f;
        Shield_NoStaminaUsageChance = Shield_NoStaminaUsage_5Perc*0.05f;
        Shield_DamageBoost = Shield_DamageBoost_3Perc*0.03f;
        Shield_DamageResistance = (Shield_DMGResistance_1Perc_1 + Shield_DMGResistance_2Perc_1*2)/100f;
        Shield_AvoidChance = (Shield_AvoidChance1Perc_1 + Shield_AvoidChance2Perc_1*2)/100f;
    }

    public void Skilltree_Damage(){
        player.BaseDamage = player.Level + 1 + DMG_2_1_Accuracy*2 + DMG_4_1_Accuracy*4 + DMG_4_2_Accuracy*4 + DMG_5_1_Accuracy*5 + DMG_5_2_Accuracy*5;
    }

    public void Skilltree_DamageModifier(){
        DamageModifier = 1f + (DMG_1Perc_1_Accuracy + DMG_2Perc_1_Accuracy*2 + DMG_2Perc_2_Accuracy*2 + DMG_5Perc_1_Accuracy*5)/100f;
        player.UpdateAllStats();
    }
    
    public void Skilltree_CritDamage(){
        Crit_Damage = 0.5f + (CritDamage_5Perc_1_Accuracy*5 + CritDamage_5Perc_2_Accuracy*5 + CritDamage_10Perc_1_Accuracy*10 + CritDamage_10Perc_2_Accuracy*10 + CritDamage_20Perc_1_Accuracy*20)/100f;
    }
    
    public void Skilltree_DMGCapOverdamage(){
        DMGCapOverdamage = 1.5f + (DMGCapOverdamage_10Perc_1*10 + DMGCapOverdamage_10Perc_2*10)/100f;
    }

    public void Skilltree_MaxStamina(){
        player.speedEnergy.AddMoreSlots();
        //MaxStamina_1_1_Evasion, MaxStamina_1_2_Evasion, MaxStamina_1_3_Evasion, MaxStamina_1_4_Evasion
        ++player.MaxSpeedEnergy;
    }
    /*public void Checklist_Add(string a, string b){
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
    }*/

    public void ChangeBranch(string BranchNameToSet){
        switch(BranchNameToSet){
            case "Sorcery":
                BranchName.text = Language_Changer.Instance.GetText("Sorcery", "Skills");
                BranchInformationText0.text  = "<sprite=\"Skills\" name=\"Upgrades\">" + Sorcery.CurrentSegmentUpgrades;
                BranchInformationText1.text  = "<sprite=\"Skills\" name=\"Mana\">" + player.Skills["BaseMana"];
                BranchInformationText2.text  = "<sprite=\"Skills\" name=\"ManaRegen\">" + player.Skills["BaseManaRegen"];
                BranchInformationText3.text  = "<sprite=\"Skills\" name=\"ManaUsage\">" + player.BaseManaCost*100 + "%";
                BranchInformationText4.text  = "<sprite=\"Skills\" name=\"Mana2\">" + player.BaseManaModifier*100 + "%";
                BranchInformationText5.text  = "<sprite=\"Skills\" name=\"Health\">" + (HP_5_1_Sorcery*5 + HP_10_1_Sorcery*10 + HP_10_2_Sorcery*10 + HP_10_3_Sorcery*10 + HP_15_1_Sorcery*15);
                BranchInformationText6.text  = "<sprite=\"Skills\" name=\"DamageResistance\">" + (DMG_Resistance_1_1_Sorcery + DMG_Resistance_1_2_Sorcery) + "%";
                BranchImage0.sprite = SorcerySprite;
                BranchImage1.sprite = SorcerySprite;
                break;
            case "Accuracy":
                BranchName.text = Language_Changer.Instance.GetText("Accuracy", "Skills");
                BranchInformationText0.text  = "<sprite=\"Skills\" name=\"Upgrades\">" + Accuracy.CurrentSegmentUpgrades;
                BranchInformationText1.text  = "<sprite=\"Skills\" name=\"Accuracy\">" + player.Skills["BaseAccuracy"];
                BranchInformationText2.text  = "<sprite=\"Skills\" name=\"CritChance\">" + player.MaxCritChance + "%";
                BranchInformationText3.text  = "<sprite=\"Skills\" name=\"Damage\">" + (DMG_2_1_Accuracy*2 + DMG_4_1_Accuracy*4 + DMG_4_2_Accuracy*4 + DMG_5_1_Accuracy*5 + DMG_5_2_Accuracy*5);
                BranchInformationText4.text  = "<sprite=\"Skills\" name=\"DamagePercentBoost\">" + DamageModifier*100 + "%";
                BranchInformationText5.text  = "<sprite=\"Skills\" name=\"Health\">" + (HP_25_1_Accuracy*25 + HP_25_2_Accuracy*25 + HP_30_1_Accuracy*30 + HP_30_2_Accuracy*30 + HP_40_1_Accuracy*40);
                BranchInformationText6.text  = "<sprite=\"Skills\" name=\"HealthPercentBoost\">" + player.BaseHealthModifier*100 + "%";
                BranchImage0.sprite = AccuracySprite;
                BranchImage1.sprite = AccuracySprite;
                break;
            case "Evasion":
                BranchName.text = Language_Changer.Instance.GetText("Evasion", "Skills");
                BranchInformationText0.text  = "<sprite=\"Skills\" name=\"Upgrades\">" + Evasion.CurrentSegmentUpgrades;
                BranchInformationText1.text  = "<sprite=\"Skills\" name=\"Evasion\">" + player.Skills["BaseEvasion"];
                BranchInformationText2.text  = "<sprite=\"Skills\" name=\"AvoidChance\">" + player.MaxAvoidChance + "%";
                BranchInformationText3.text  = "<sprite=\"Skills\" name=\"Stamina\">" + (MaxStamina_1_1_Evasion + MaxStamina_1_2_Evasion + MaxStamina_1_3_Evasion + MaxStamina_1_4_Evasion);
                BranchInformationText4.text  = "<sprite=\"Skills\" name=\"StaminaRegen\">" + player.BaseAttackSpeed;
                BranchInformationText5.text  = "<sprite=\"Skills\" name=\"DamageResistance\">" + (DMG_Resistance_1Perc_1_Evasion + DMG_Resistance_1Perc_2_Evasion + DMG_resistance_1Perc_3_Evasion) + "%";
                BranchInformationText6.text  = "<sprite=\"Skills\" name=\"Health\">" + (HP_10_1_Evasion*10 + HP_15_1_Evasion*15 + HP_10_2_Evasion*10 + HP_10_3_Evasion*10 + HP_15_2_Evasion*15);
                BranchImage0.sprite = EvasionSprite;
                BranchImage1.sprite = EvasionSprite;
                break;
            case "Universal":
                Universal.AllUpgrades = Sorcery.CurrentSegmentUpgrades + Evasion.CurrentSegmentUpgrades + Accuracy.CurrentSegmentUpgrades;
                BranchName.text = Language_Changer.Instance.GetText("Universal_Upgrades", "Skills");
                BranchInformationText0.text  = "<sprite=\"Skills\" name=\"Upgrades\">" + Universal.AllUpgrades;
                BranchInformationText1.text  = "<sprite=\"Skills\" name=\"UpgradesAccuracy\">" + Accuracy.CurrentSegmentUpgrades;
                BranchInformationText2.text  = "<sprite=\"Skills\" name=\"UpgradesEvasion\">" + Evasion.CurrentSegmentUpgrades;
                BranchInformationText3.text  = "<sprite=\"Skills\" name=\"UpgradesSorcery\">" + Sorcery.CurrentSegmentUpgrades;
                BranchInformationText4.text  = "<sprite=\"Skills\" name=\"SkilledTree\">" + (game.SkilledTreeChance+1) + "%";
                BranchInformationText5.text  = "<sprite=\"Skills\" name=\"EnchantTriggerChance\">" + player.Skills["WeaponSkillChance"] + "%";
                BranchInformationText6.text  = "<sprite=\"Skills\" name=\"HealthRegen\">" + player.Skills["BaseHealthRegen"];
                BranchImage0.sprite = UniversalSprite;
                BranchImage1.sprite = UniversalSprite;
                break;
            default:
                BranchName.text = "ERROR";
                break;
        }
    }
    
}
