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
    public Accuracy_Tier1 Accuracy_Tier1;
    public Accuracy_Tier2 Accuracy_Tier2;
    public Evasion_Tier1 Evasion_Tier1;
    public Evasion_Tier2 Evasion_Tier2;
    public Magic_Tier1 Magic_Tier1;
    public Magic_Tier2 Magic_Tier2;
    public Magic_Tier3 Magic_Tier3;
    public Magic_Tier4 Magic_Tier4;
    public Magic_Tier5 Magic_Tier5;
    public Camera MainCamera;
    public Player player;
    public Game game;
    public TextMeshProUGUI SkillPointsCount;
    //public GameObject Information_Skills_G, Button_Skills_G, Requirements_Skills_G, Title_Skills_G, X_G;
    public GameObject Information_Skills_BG;

    public int ChecklistItems = 0;
    public int EvasionMain, AccuracyMain, Practice_Plus;
    public bool HP_5_1_Magic_Tier1, MR_1_1_Magic_Tier1, BSU, EV_1_ACC_1_1_Magic_Tier1, M_1Perc_1_Magic_Tier1, Mana_10_1_Magic_Tier1, WeaponSkillChance_5Perc_1_Magic_Tier1, Mana_10_2_Magic_Tier1, MR_1_MCost_2Perc_Magic_Tier1, BS_Poison_AddDuration;
    public bool ManaOverdrain, HP_5_2_Magic_Tier2, Mana_10_3_Magic_Tier2, BS_UnlockWeakness, BS_NoEvasion, HP_10_1_Magic_Tier2, Mana_10_4_Magic_Tier2, EV_2_ACC_2_1_Magic_Tier2, MR_1_3_Magic_Tier2, AddSlot_Magic_Tier2, Mana_10_5_Magic_Tier2, MR_1_2_Magic_Tier2, EV_1_ACC_1_2_Magic_Tier2;
    public bool DMG_Resistance_1_1_Magic_Tier3, EV_2_ACC_2_2_Magic_Tier3, Mana_10_6_Magic_Tier3, MR_2_1_Magic_Tier3, CHU, Mana_20_1_Magic_Tier3, MCost_1Perc_1_Magic_Tier3, BS_Weakness_AddDuration, HP_15_1_Magic_Tier3, HP_5_3_Magic_Tier3, EV_1_ACC_1_3_Magic_Tier3, MR_1_4_Magic_Tier3, AtkSpeed_1_1_Magic_Tier3, HP_5_4_Magic_Tier3, Mana_20_2_Magic_Tier3, MR_1_5_Magic_Tier3, SkilledTree_1_Magic_Tier3;
    public bool CH_Effect, VU, MR_2_2_Magic_Tier4, Mana_20_3_Magic_Tier4, M_2Perc_1_Magic_Tier4, HP_10_2_Magic_Tier4, EV_2_ACC_2_3_Magic_Tier4, HP_15_2_Magic_Tier4, MR_2_3_Magic_Tier4, MCost_2Perc_1_Magic_Tier4, EV_2_ACC_2_4_Magic_Tier4, Mana_20_4_Magic_Tier4, UltimateUnlock_Magic_Tier4;
    public bool Mana_2Perc_2_Magic_Tier5, CH_Ultimate_RandomDebuff, BS_Ultimate, Mana_10_7_Magic_Tier5, MR_2_4_Magic_Tier5, Mana_20_7_Magic_Tier5, MCost_1Perc_2_Magic_Tier5, MR_2_6_Magic_Tier5, EV_5_ACC_5_2_Magic_Tier5, HP_20_1_Magic_Tier5, HPRegen_10_1_Magic_Tier5, DMG_Resistance_2_1_Magic_Tier5, MCost_2Perc_2_Magic_Tier5, V_Ultimate, Mana_20_5_Magic_Tier5, MR_2_5_Magic_Tier5, Mana_20_6_Magic_Tier5, EV_5_ACC_5_1_Magic_Tier5, HPRegen_20_1_Magic_Tier5, MCost_2Perc_3_Magic_Tier5, HP_20_2_Magic_Tier5, CH_Ultimate_HPPercent, Mana_20_8_Magic_Tier5, MR_2_7_Magic_Tier5, DMG_Resistance_2_2_Magic_Tier5, Mana_20_9_Magic_Tier5, HPRegen_20_2_Magic_Tier5;
    public bool PHU, AvoidChance_2Perc_1_Evasion_Tier1, EV_1_ACC_1_1_Evasion_Tier1, HP_5_1_Evasion_Tier1, EV_3_1_Evasion_Tier1, WeaponSkillChance_5Perc_1_Evasion_Tier1, AtkSpeed_1_1_Evasion_Tier1, AvoidChance_3Perc_1_Evasion_Tier1, DMG_Resistance_1_1_Evasion_Tier1;
    public bool Parrying_Unlock, DMG_Resistance_1_2_Evasion_Tier2, AvoidChance_5Perc_1_Evasion_Tier2, AvoidChance_5Perc_2_Evasion_Tier2, HP_5_2_Evasion_Tier2, AtkSpeed_1_2_Evasion_Tier2, HP_10_1_Evasion_Tier2, EV_3_2_Evasion_Tier2, EV_1_ACC_1_2_Evasion_Tier2, EV_2_ACC_2_1_Evasion_Tier2, AddSlot_Evasion_Tier2;
    public bool HP_5_1_Accuracy_Tier1, MaxCrit_5Perc_1_Accuracy_Tier1, BLU, ACC_3_1_Accuracy_Tier1, WeaponSkillChance_2Perc_1_Accuracy_Tier1, HP_5_2_Accuracy_Tier1, WeaponSkillChance_3Perc_1_Accuracy_Tier1, EV_1_ACC_1_1_Accuracy_Tier1, HP_5_3_Accuracy_Tier1, HP_1Perc_1_Accuracy_Tier1;
    public bool BrutalityStreak_Unlock, ACC_3_2_Accuracy_Tier2, MaxCrit_5Perc_2_Accuracy_Tier2, HP_10_1_Accuracy_Tier2, ACC_3_3_Accuracy_Tier2, HP_10_2_Accuracy_Tier2, MaxCrit_5Perc_3_Accuracy_Tier2, HP_1Perc_2_Accuracy_Tier2, EV_1_ACC_1_2_Accuracy_Tier2, HP_10_3_Accuracy_Tier2, EV_2_ACC_2_1_Accuracy_Tier2, AddSlot_Accuracy_Tier2;

    public int BS_Mana = 0, BS_Cooldown = 0, BS_Damage = 0, ManaOverdrain_Perc = 0, ManaOverdrain_Potion = 0, CH_Damage = 0, CH_Mana = 0, CH_Cooldown = 0, CH_Effect_EVChance = 0, CH_Effect_Damage = 0, CH_Effect_Duration = 0, V_Heal = 0, V_Damage = 0, V_EffectHeal = 0, V_Mana = 0;
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
        player.Skills["BaseEvasion"] = EvasionMain + Convert.ToInt32(EV_1_ACC_1_1_Magic_Tier1) + Convert.ToInt32(EV_1_ACC_1_2_Magic_Tier2) + Convert.ToInt32(EV_2_ACC_2_1_Magic_Tier2)*2 + Convert.ToInt32(EV_2_ACC_2_2_Magic_Tier3)*2 + Convert.ToInt32(EV_1_ACC_1_3_Magic_Tier3) + Convert.ToInt32(EV_2_ACC_2_3_Magic_Tier4)*2 + Convert.ToInt32(EV_2_ACC_2_4_Magic_Tier4)*2 + Convert.ToInt32(EV_5_ACC_5_1_Magic_Tier5)*5 + Convert.ToInt32(EV_5_ACC_5_2_Magic_Tier5)*5 + Convert.ToInt32(EV_3_1_Evasion_Tier1)*3 + Convert.ToInt32(EV_1_ACC_1_1_Evasion_Tier1) + Convert.ToInt32(EV_2_ACC_2_1_Evasion_Tier2)*2 + Convert.ToInt32(EV_3_2_Evasion_Tier2)*3 + Convert.ToInt32(EV_1_ACC_1_2_Evasion_Tier2) + Convert.ToInt32(EV_1_ACC_1_1_Accuracy_Tier1) + Convert.ToInt32(EV_1_ACC_1_2_Accuracy_Tier2) + Convert.ToInt32(EV_2_ACC_2_1_Accuracy_Tier2)*2;
         player.Evasion_reload();
    }

    public void Skilltree_Accuracy(){
        player.Skills["BaseAccuracy"] = AccuracyMain + Convert.ToInt32(EV_1_ACC_1_1_Magic_Tier1) + Convert.ToInt32(EV_1_ACC_1_2_Magic_Tier2) + Convert.ToInt32(EV_2_ACC_2_1_Magic_Tier2)*2 + Convert.ToInt32(EV_2_ACC_2_2_Magic_Tier3)*2 + Convert.ToInt32(EV_1_ACC_1_3_Magic_Tier3) + Convert.ToInt32(EV_2_ACC_2_3_Magic_Tier4)*2 + Convert.ToInt32(EV_2_ACC_2_4_Magic_Tier4)*2 + Convert.ToInt32(EV_5_ACC_5_1_Magic_Tier5)*5 + Convert.ToInt32(EV_5_ACC_5_2_Magic_Tier5)*5 + Convert.ToInt32(EV_1_ACC_1_1_Evasion_Tier1) + Convert.ToInt32(EV_2_ACC_2_1_Evasion_Tier2)*2 + Convert.ToInt32(EV_1_ACC_1_2_Evasion_Tier2) + Convert.ToInt32(ACC_3_1_Accuracy_Tier1)*3 + Convert.ToInt32(EV_1_ACC_1_1_Accuracy_Tier1) + Convert.ToInt32(ACC_3_2_Accuracy_Tier2)*3 + Convert.ToInt32(ACC_3_3_Accuracy_Tier2)*3 + Convert.ToInt32(EV_1_ACC_1_2_Accuracy_Tier2) + Convert.ToInt32(EV_2_ACC_2_1_Accuracy_Tier2)*2;
         player.Accuracy_reload();
    }

    public void Skilltree_Mana(){
        player.Skills["BaseMana"] = Practice_Plus*10 + Convert.ToInt32(Mana_10_1_Magic_Tier1)*10 + Convert.ToInt32(Mana_10_2_Magic_Tier1)*10 + Convert.ToInt32(Mana_10_3_Magic_Tier2)*10 + Convert.ToInt32(Mana_10_4_Magic_Tier2)*10 + Convert.ToInt32(Mana_10_5_Magic_Tier2)*10 + Convert.ToInt32(Mana_10_6_Magic_Tier3)*10 + Convert.ToInt32(Mana_20_1_Magic_Tier3)*20 + Convert.ToInt32(Mana_20_2_Magic_Tier3)*20 + Convert.ToInt32(Mana_20_3_Magic_Tier4)*20 + Convert.ToInt32(Mana_20_4_Magic_Tier4)*20 + Convert.ToInt32(Mana_10_7_Magic_Tier5)*10 + Convert.ToInt32(Mana_20_5_Magic_Tier5)*20 + Convert.ToInt32(Mana_20_6_Magic_Tier5)*20 + Convert.ToInt32(Mana_20_7_Magic_Tier5)*20 + Convert.ToInt32(Mana_20_8_Magic_Tier5)*20 + Convert.ToInt32(Mana_20_9_Magic_Tier5)*20;
        player.Mana_reload();
    }

    public void Skilltree_Health(){
        player.Skills["BaseHealth"] = Convert.ToInt32(HP_5_1_Magic_Tier1)*5 + Convert.ToInt32(HP_5_2_Magic_Tier2)*5 + Convert.ToInt32(HP_10_1_Magic_Tier2)*10 + Convert.ToInt32(HP_15_1_Magic_Tier3)*15 + Convert.ToInt32(HP_5_3_Magic_Tier3)*5 + Convert.ToInt32(HP_5_4_Magic_Tier3)*5 + Convert.ToInt32(HP_10_2_Magic_Tier4)*10 + Convert.ToInt32(HP_15_2_Magic_Tier4)*15 + Convert.ToInt32(HP_20_1_Magic_Tier5)*20 + Convert.ToInt32(HP_20_2_Magic_Tier5)*20 + Convert.ToInt32(HP_5_1_Evasion_Tier1)*5 + Convert.ToInt32(HP_5_2_Evasion_Tier2)*5 + Convert.ToInt32(HP_10_1_Evasion_Tier2)*10 + Convert.ToInt32(HP_5_1_Accuracy_Tier1)*5 + Convert.ToInt32(HP_5_2_Accuracy_Tier1)*5 + Convert.ToInt32(HP_5_3_Accuracy_Tier1)*5 + Convert.ToInt32(HP_10_1_Accuracy_Tier2)*10 + Convert.ToInt32(HP_10_2_Accuracy_Tier2)*10 + Convert.ToInt32(HP_10_3_Accuracy_Tier2)*10;
        player.Health_reload();
    }

    public void Skilltree_HealthRegen(){
        player.Skills["BaseHealthRegen"] = Convert.ToInt32(HPRegen_20_1_Magic_Tier5)*20 + Convert.ToInt32(HPRegen_20_2_Magic_Tier5)*20 + Convert.ToInt32(HPRegen_10_1_Magic_Tier5)*10;
        player.HealthRegen_reload();
    }

    public void Skilltree_ManaRegen(){
        player.Skills["BaseManaRegen"] = Convert.ToInt32(MR_1_1_Magic_Tier1) + Convert.ToInt32(MR_1_MCost_2Perc_Magic_Tier1) + Convert.ToInt32(MR_1_2_Magic_Tier2) + Convert.ToInt32(MR_1_3_Magic_Tier2) + Convert.ToInt32(MR_2_1_Magic_Tier3)*2 + Convert.ToInt32(MR_1_4_Magic_Tier3) + Convert.ToInt32(MR_1_5_Magic_Tier3) + Convert.ToInt32(MR_2_2_Magic_Tier4)*2 + Convert.ToInt32(MR_2_3_Magic_Tier4)*2 + Convert.ToInt32(MR_2_4_Magic_Tier5)*2 + Convert.ToInt32(MR_2_5_Magic_Tier5)*2 + Convert.ToInt32(MR_2_6_Magic_Tier5)*2 + Convert.ToInt32(MR_2_7_Magic_Tier5)*2;
        player.ManaRegen_reload();
    }

    public void Skilltree_ManaModifier(){
        player.BaseManaModifier = 1f + Convert.ToInt32(M_1Perc_1_Magic_Tier1)*0.01f + Convert.ToInt32(M_2Perc_1_Magic_Tier4)*0.02f + Convert.ToInt32(Mana_2Perc_2_Magic_Tier5)*0.02f;
        player.ManaModifier_reload();
    }

    public void Skilltree_ManaCost(){
        player.BaseManaCost = 1f - Convert.ToInt32(MR_1_MCost_2Perc_Magic_Tier1)*0.02f - Convert.ToInt32(MCost_1Perc_1_Magic_Tier3)*0.01f - Convert.ToInt32(MCost_2Perc_1_Magic_Tier4)*0.02f - Convert.ToInt32(MCost_2Perc_2_Magic_Tier5)*0.02f - Convert.ToInt32(MCost_2Perc_3_Magic_Tier5)*0.02f - Convert.ToInt32(MCost_1Perc_2_Magic_Tier5)*0.01f;
        player.ManaCost_reload();
    }

    public void Skilltree_HealthModifier(){
        player.BaseHealthModifier = 1f + Convert.ToInt32(HP_1Perc_1_Accuracy_Tier1)*0.01f + Convert.ToInt32(HP_1Perc_2_Accuracy_Tier2)*0.01f;
        player.HealthModifier_reload();
    }

    public void Skilltree_AttackSpeed(){
        player.BaseAttackSpeed = Convert.ToInt32(AtkSpeed_1_1_Magic_Tier3)*0.1f + Convert.ToInt32(AtkSpeed_1_1_Evasion_Tier1)*0.1f + Convert.ToInt32(AtkSpeed_1_2_Evasion_Tier2)*0.1f;
        player.AttackSpeed_reload();
    }

    public void Skilltree_DamageResistance(){
        player.BaseDamageResistance = DevTools.Instance.Resistance + Convert.ToInt32(DMG_Resistance_1_1_Magic_Tier3)*0.01f + Convert.ToInt32(DMG_Resistance_2_1_Magic_Tier5)*0.02f + Convert.ToInt32(DMG_Resistance_2_2_Magic_Tier5)*0.02f + Convert.ToInt32(DMG_Resistance_1_1_Evasion_Tier1)*0.01f + Convert.ToInt32(DMG_Resistance_1_2_Evasion_Tier2)*0.01f;
        player.DamageResistance_reload();
    }

    public void Skilltree_WeaponSkillChance(){
        player.Skills["WeaponSkillChance"] = 5 + Convert.ToInt32(WeaponSkillChance_5Perc_1_Magic_Tier1)*5 + Convert.ToInt32(WeaponSkillChance_5Perc_1_Evasion_Tier1)*5 + Convert.ToInt32(WeaponSkillChance_2Perc_1_Accuracy_Tier1)*2 + Convert.ToInt32(WeaponSkillChance_3Perc_1_Accuracy_Tier1)*3;
    }

    public void Skilltree_SkilledTree(){
        game.SkilledTreeChance = 0 + Convert.ToInt32(SkilledTree_1_Magic_Tier3);
    }

    public void Skilltree_MaxAvoidChance(){
        player.MaxAvoidChance = 40 + Convert.ToInt32(AvoidChance_2Perc_1_Evasion_Tier1)*2 + Convert.ToInt32(AvoidChance_3Perc_1_Evasion_Tier1)*3 + Convert.ToInt32(AvoidChance_5Perc_1_Evasion_Tier2)*5 + Convert.ToInt32(AvoidChance_5Perc_2_Evasion_Tier2)*5;
    }

    public void Skilltree_MaxCritChance(){
        player.MaxCritChance = 40 + Convert.ToInt32(MaxCrit_5Perc_1_Accuracy_Tier1)*5 + Convert.ToInt32(MaxCrit_5Perc_2_Accuracy_Tier2)*5 + Convert.ToInt32(MaxCrit_5Perc_3_Accuracy_Tier2)*5;
    }

    public void Skilltree_ActiveSkillsSlots(){
        ActiveSkillsManager.MaxSlots = 1 + Convert.ToInt32(AddSlot_Accuracy_Tier2) + Convert.ToInt32(AddSlot_Evasion_Tier2) + Convert.ToInt32(AddSlot_Magic_Tier2);
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
    
}
