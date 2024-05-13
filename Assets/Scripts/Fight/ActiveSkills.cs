using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;
using System;

public class ActiveSkills : MonoBehaviour
{   
    public int[,] SlotsCooldowns = new int [4, 2];
    public Skills SkillManager;
    public ActiveSkillsManager ActiveSkillsManager;
    public Player player;
    public Mob mob;
    public Fight Fight;
    public GameObject[] FightSlots = new GameObject[4];

    public void Cooldown(){
        for(int i = 0; i<4; ++i){
            if(SlotsCooldowns[i, 0]>0)--SlotsCooldowns[i, 0];
            if(SlotsCooldowns[i, 0] == 0){
                FightSlots[i].transform.Find("Cooldown Image").GetComponent<Image>().fillAmount = 0f;
                FightSlots[i].GetComponent<Button>().interactable = true;
            }
            else FightSlots[i].transform.Find("Cooldown Image").GetComponent<Image>().fillAmount = (float)SlotsCooldowns[i, 0]/(float)SlotsCooldowns[i, 1];
        }
    }

    public void SetCooldown(int SlotID, int Amount){
        SlotsCooldowns[SlotID, 0] = Amount;
        SlotsCooldowns[SlotID, 1] = Amount;
        FightSlots[SlotID].transform.Find("Cooldown Image").GetComponent<Image>().fillAmount = 1;
        FightSlots[SlotID].GetComponent<Button>().interactable = false;
    }

    public void ReloadActiveSkills(){
        for(int i = 0; i<4; ++i){
            if(ActiveSkillsManager.ActiveSlots[i+1] != -1){
                FightSlots[i].SetActive(true);
                FightSlots[i].transform.Find("Image").GetComponent<Image>().sprite = ActiveSkillsManager.SlotImages[ActiveSkillsManager.ActiveSlots[i+1]];
            }
            else FightSlots[i].SetActive(false);
        }
    }

    public void TriggerActiveSkill(int SlotID){
        if(mob.Health==0 || player.Health == 0) return;
        int ID = ActiveSkillsManager.ActiveSlots[SlotID], CooldownTime = 0, ManaUsage = 0;
        switch(ID){
            case 0:
                switch(SkillManager.PH_Cooldown){
                    case 1:
                        CooldownTime = 5;
                        break;
                    case 2:
                        CooldownTime = 6;
                        break;
                    case 3:
                        CooldownTime = 7;
                        break;
                    default:
                        CooldownTime = 8;
                    break;
                }
                switch(SkillManager.PH_Damage){
                    case 1:
                        mob.ActiveSkillsAddDamage = 0.25f;
                        break;
                    case 2:
                        mob.ActiveSkillsAddDamage = 0.40f;
                        break;
                    case 3:
                        mob.ActiveSkillsAddDamage = 0.60f;
                        break;
                    default:
                        mob.ActiveSkillsAddDamage = 0.10f;
                    break;
                }
                break;
            case 3:
                player.BlockActive = true;
                switch(SkillManager.BL_Cooldown){
                    case 1:
                        CooldownTime = 5;
                        break;
                    case 2:
                        CooldownTime = 4;
                        break;
                    default:
                        CooldownTime = 6;
                        break;
                }
                break;
            case 6:
                switch(SkillManager.BS_Mana){
                    case 1:
                        ManaUsage = 40;
                        break;
                    case 2:
                        ManaUsage = 30;
                        break;
                    default:
                        ManaUsage = 50;
                        break;
                }
                ManaUsage = (int)(ManaUsage*player.ManaCost);
                if(player.Mana>=ManaUsage || (SkillManager.ManaOverdrain && !player.Overdrained)){
                    switch(SkillManager.BS_Cooldown){
                        case 1:
                            CooldownTime = 7;
                            break;
                        case 2:
                            CooldownTime = 6;
                            break;
                        case 3:
                            CooldownTime = 5;
                            break;
                        default:
                            CooldownTime = 8;
                            break;
                    }
                    player.Mana_Use(ManaUsage);
                    int Damage = player.BaseDamage, Chance;
                    switch(SkillManager.BS_Damage){
                        case 1:
                            Chance = 20;
                            break;
                        case 2:
                            Chance = 30;
                            break;
                        case 3:
                            Chance = 50;
                            break;
                        default:
                            Chance = 0;
                            break;
                    }
                    if(SkillManager.BS_Ultimate){
                        Damage*=2;
                        Chance = 100;
                    }
                    if(SkillManager.BS_Poison_AddDuration) Fight.EffectsManager.Add(4, 10, mob);
                    else Fight.EffectsManager.Add(4, 5, mob);
                    if(SkillManager.BS_Weakness == 2) Fight.EffectsManager.Add(6, 8, mob);
                    else if(SkillManager.BS_Weakness == 1) Fight.EffectsManager.Add(6, 5, mob);
                    Fight.ReloadEffectImages();
                    Fight.EffectsManager.TriggerEffects(0, mob);
                    if(Chance>UnityEngine.Random.Range(0, 100)){
                        if(SkillManager.BS_NoEvasion) mob.GetDamage(Damage, false);
                        else{
                            bool Avoided = mob.Avoid();
                            if(Avoided)mob.GetComponent<F_Text_Creator>().CreateText_Red(Language_Changer.Instance.GetText("Avoided"));
                            else mob.GetDamage(Damage, false);
                        }
                    }
                    player.SpeedEnergyRemove(1);
                    Fight.NextTurn();
                }
                break;
            case 7:
                switch(SkillManager.CH_Mana){
                    case 1:
                        ManaUsage = 220;
                        break;
                    case 2:
                        ManaUsage = 180;
                        break;
                    case 3:
                        ManaUsage = 150;
                        break;
                    default:
                        ManaUsage = 250;
                        break;
                }
                ManaUsage = (int)Math.Floor(ManaUsage*player.ManaCost);
                if(player.Mana>=ManaUsage || (SkillManager.ManaOverdrain && !player.Overdrained)){
                    switch(SkillManager.CH_Cooldown){
                        case 1:
                            CooldownTime = 6;
                            break;
                        case 2:
                            CooldownTime = 5;
                            break;
                        default:
                            CooldownTime = 7;
                            break;
                    }
                    player.Mana_Use(ManaUsage);
                    float Damage;
                    if(!SkillManager.CH_Effect){
                        switch(SkillManager.CH_Damage){
                            case 1:
                                Damage = 0.02f;
                                break;
                            case 2:
                                Damage = 0.05f;
                                break;
                            default:
                                Damage = 0.01f;
                                break;
                        }
                        mob.GetDamage(player.BaseDamage + Convert.ToInt32(Math.Ceiling(Damage*mob.Health)), false);
                    }
                    else{
                        if(SkillManager.CH_Ultimate_RandomDebuff){
                            switch(UnityEngine.Random.Range(0, 3)){
                                case 0:
                                    if(UnityEngine.Random.Range(0, 25)==0) Fight.EffectsManager.Add(4, UnityEngine.Random.Range(15, 200), mob);
                                    else Fight.EffectsManager.Add(4, UnityEngine.Random.Range(5, 15), mob);
                                    break;
                                case 1:
                                    Fight.EffectsManager.Add(5, UnityEngine.Random.Range(2, 8), mob);
                                    break;
                                case 2:
                                    Fight.EffectsManager.Add(6, UnityEngine.Random.Range(2, 12), mob);
                                    Fight.EffectsManager.TriggerEffects(0, mob);
                                    break;
                                default:
                                    break;
                            }
                        }
                        switch(SkillManager.CH_Effect_Duration){
                            case 1:
                                Fight.EffectsManager.Add(7, UnityEngine.Random.Range(2, 7), mob);
                                break;
                            case 2:
                                Fight.EffectsManager.Add(7, UnityEngine.Random.Range(4, 9), mob);
                                break;
                            default:
                                Fight.EffectsManager.Add(7, UnityEngine.Random.Range(1, 6), mob);
                                break;
                        }
                        Fight.ReloadEffectImages();
                    }
                    player.SpeedEnergyRemove(1);
                    Fight.NextTurn();
                }
                break;
            case 8:
                switch(SkillManager.V_Mana){
                    case 1:
                        ManaUsage = 130;
                        break;
                    case 2:
                        ManaUsage = 100;
                        break;
                    default:
                        ManaUsage = 150;
                        break;
                }
                ManaUsage = (int)Math.Floor(ManaUsage*player.ManaCost);
                if(player.Mana>=ManaUsage || (SkillManager.ManaOverdrain && !player.Overdrained)){
                    CooldownTime = 6;
                    player.Mana_Use(ManaUsage);
                    float EffectHealPercent = 0;
                    switch(SkillManager.V_EffectHeal){
                        case 1:
                            EffectHealPercent = 0.02f;
                            break;
                        case 2:
                            EffectHealPercent = 0.05f;
                            break;
                        default:
                            break;
                    }
                    if(SkillManager.V_Ultimate){
                        Fight.EffectsManager.Add(5, 5, mob);
                        Fight.ReloadEffectImages();
                        EffectHealPercent = 0.1f;
                    }
                    if(EffectHealPercent>0){
                        Fight.IsVampirismActive = true;
                        Fight.VampirsmHealPerc = EffectHealPercent;
                    }
                    int Damage;
                    switch(SkillManager.V_Damage){
                        case 1:
                            Damage = 3;
                            break;
                        case 2:
                            Damage = 4;
                            break;
                        case 3:
                            Damage = 6;
                            break;
                        default:
                            Damage = 2;
                            break;
                    }
                    Damage *=player.BaseDamage;
                    mob.GetDamage(Damage, true);
                    switch(SkillManager.V_Heal){
                        case 1:
                            Damage = Convert.ToInt32(Math.Ceiling((float)Damage*0.15f));
                            break;
                        case 2:
                            Damage = Convert.ToInt32(Math.Ceiling((float)Damage*0.20f));
                            break;
                        case 3:
                            Damage = Convert.ToInt32(Math.Ceiling((float)Damage*0.30f));
                            break;
                        default:
                            Damage = Convert.ToInt32(Math.Ceiling((float)Damage*0.10f));
                            break;
                    }
                    player.TriggerHeal(Damage);
                    player.SpeedEnergyRemove(1);
                    Fight.NextTurn();
                }
                break;
            default:
                break;
        }
        if(CooldownTime>0)SetCooldown(SlotID-1, CooldownTime);
        player.RightHand.GetComponent<Item>().OnActiveSkillUse();
        player.LeftHand.GetComponent<Item>().OnActiveSkillUse();
        player.Hat.GetComponent<Item>().OnActiveSkillUse();
        player.Chestplate.GetComponent<Item>().OnActiveSkillUse();
        player.Boots.GetComponent<Item>().OnActiveSkillUse();
        player.Trinket1.GetComponent<Item>().OnActiveSkillUse();
        player.Trinket2.GetComponent<Item>().OnActiveSkillUse();
    }
}
