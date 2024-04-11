using System.Collections;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class EffectsManager : MonoBehaviour
{   
    public Fight Fight;
    public Skills SkillManager;
    int LastBuffsDefence;

    public string GetDescription(int SlotId, Entity Target){
        int Duration = Target.StatusEffects[SlotId, 1];
        switch(Target.StatusEffects[SlotId, 0]){
            case 0:
                return string.Format(Language_Changer.Instance.GetText("Id_0_Description", "Effects"), Duration, Duration*5+"%");
            case 1:
                return string.Format(Language_Changer.Instance.GetText("Id_1_Description", "Effects"), Duration, Duration*5+"%");
            case 2:
                return string.Format(Language_Changer.Instance.GetText("Id_2_Description", "Effects"), Duration, Duration + 5);
            case 4:
                return string.Format(Language_Changer.Instance.GetText("Id_4_Description", "Effects"), Duration, Duration*2);
            case 5:
                return string.Format(Language_Changer.Instance.GetText("Id_5_Description", "Effects"), Duration, Duration+"%");
            case 7:
                string Max = "";
                float DamagePercent;
                int EffectAvoidChance;
                    switch(Player.Instance.SkillManager.CH_Effect_Damage){
                        case 1:
                            DamagePercent = 1f;
                            break;
                        case 2:
                            DamagePercent = 1.5f;
                            break;
                        default:
                            DamagePercent = 0.5f;
                            break;
                    }
                switch(Player.Instance.SkillManager.CH_Effect_EVChance){
                    case 1:
                        EffectAvoidChance = 7;
                        break;
                    case 2:
                        EffectAvoidChance = 5;
                        break;
                    default:
                        EffectAvoidChance = 9;
                        break;
                    }    
                    if(Player.Instance.SkillManager.CH_Ultimate_HPPercent) Max = Language_Changer.Instance.GetText("Max");
                return string.Format(Language_Changer.Instance.GetText("Id_7_Description", "Effects"), Duration, DamagePercent*Duration, EffectAvoidChance*Duration, Max);
            default:
                return string.Format(Language_Changer.Instance.GetText("Id_" + Target.StatusEffects[SlotId, 0] + "_Description", "Effects"), Duration);
        }
    }

    public void Add(int ID, int Duration, Entity Target){
        int Type, Type2, IsStackable;
        GetInformation(ID, out Type, out Type2, out IsStackable);
        int Min = Target.StatusEffects[0, 1], MinSlot = 0, Slot = 0;
        for(; Slot<10; ++Slot){
            if(Target.StatusEffects[Slot, 0] == -1 || Target.StatusEffects[Slot, 0] == ID) break;
            if(Target.StatusEffects[Slot, 1]<Min){
                Min = Target.StatusEffects[Slot, 1];
                MinSlot = Slot;
            }
        }
        if(Target.StatusEffects[9, 0] != -1 && Target.StatusEffects[Slot, 0] != ID) Slot = MinSlot;
        if(IsStackable != 1 && Target.StatusEffects[Slot, 1]>Duration) return;
        if(Target.StatusEffects[Slot, 0] != ID || IsStackable != 1){
            Target.StatusEffects[Slot, 0] = ID;
            Target.StatusEffects[Slot, 1] = Duration;
            Target.StatusEffects[Slot, 2] = Duration;
            Target.StatusEffects[Slot, 3] = Type;
            Target.StatusEffects[Slot, 4] = Type2;
        }
        else{
            Target.StatusEffects[Slot, 1] += Duration;
            Target.StatusEffects[Slot, 2] = Target.StatusEffects[Slot, 1];//Inv lvl txt update
        }
    }

    public void AddLimited(int Id, int Amount, int Limit, Entity Target){
        for(int i = 0; i<10; ++i){
            if(Target.StatusEffects[i, 0] == -1) Add(Id, Math.Min(Amount, Limit), Target);
            if(Target.StatusEffects[i, 0] == Id){
                if(Target.StatusEffects[i, 1] + Amount <= Limit) Add(Id, Amount, Target);
                else if(Limit - Target.StatusEffects[i, 1] > 0) Add(Id, Limit - Target.StatusEffects[i, 1], Target);
            }
        }
    }

    public void Remove(int SlotId, Entity Target){
        for(int i = 0; i<5;++i) Target.StatusEffects[SlotId, i] = -1;
        Reorganise(Target);
    }

    public void GetInformation(int ID, out int Type, out int Type2, out int IsStackable){
        Type2 = -1;
        switch(ID){
            case 0:
                Type = 1;
                IsStackable = 0;
                break;
            case 1:
                Type = 1;
                IsStackable = 0;
                break;
            case 2:
                Type = 0;
                IsStackable = 0;
                break;
            case 3:
                Type = 0;
                IsStackable = 0;
                break;
            case 4:
                Type = 1;
                IsStackable = 1;
                break;
            case 5:
                Type = 1;
                IsStackable = 1;
                break;
            case 6:
                Type = 0;
                IsStackable = 1;
                break;
            case 7:
                Type = 3;
                Type2 = 0;
                IsStackable = 1;
                break;
            case 8:
                Type = 5;
                Type2 = 0;
                IsStackable = 1;
                break;
            case 9:
                Type = 5;
                IsStackable = 1;
                break;
            case 10:
                Type = 5;
                IsStackable = 1;
                break;
            default:
                Type = -1;
                IsStackable = -1;
                Debug.Log("ERR - Effects.GetInformation, with ID " + ID);
                break;
        }
    }

    public void Reorganise(Entity Target){
        for(int i = 0; i<9; ++i){
            if(Target.StatusEffects[i, 0]==-1){
                if(Target.StatusEffects[i+1, 0]==-1) break;
                Target.StatusEffects[i, 0]= Target.StatusEffects[i+1, 0];
                Target.StatusEffects[i, 1]= Target.StatusEffects[i+1, 1];
                Target.StatusEffects[i, 2]= Target.StatusEffects[i+1, 2];
                Target.StatusEffects[i, 3]= Target.StatusEffects[i+1, 3];
                Target.StatusEffects[i, 4]= Target.StatusEffects[i+1, 4];
                Target.StatusEffects[i+1, 0] = -1;
                Target.StatusEffects[i+1, 1] = -1;
                Target.StatusEffects[i+1, 2] = -1;
                Target.StatusEffects[i+1, 3] = -1;
                Target.StatusEffects[i+1, 4] = -1;
            }
        }
        if(Fight.InBattle)Fight.ReloadEffectImages();
    }

    public void ResetStats(Entity Target){
        LastBuffsDefence = Target.BuffsDefence;
        Target.BuffsDefence = 0;
        Target.BuffsDamageModifier = 1;
        Target.BuffsDamageTakenModifier = 1;
        Target.BuffsAvoidChance = 0;
    }

    public void Duration_Remove(Entity Target, bool AllowImagesReload = true){
        for(int i = 0; i<10; ++i){
            if(Target.StatusEffects[i, 1] == -1) break;
            --Target.StatusEffects[i, 1];
            if(Target.StatusEffects[i, 1] == 0){
            Remove(i, Target);
            --i;
            }
        }
        if(AllowImagesReload)Fight.ReloadEffectImages();
    }

    public bool GetEffect(int EffectId, Entity Target){
        for(int i = 0; i<10; ++i){
            if(Target.StatusEffects[i, 0] == -1) break; 
            if(Target.StatusEffects[i, 0] == EffectId)return true;
        }
        return false;
    }

    public async void TriggerEffects(int Type, Entity Target){
        if(Type == 0) ResetStats(Target);
        for(int i = 0; i<10; ++i){
            if(Target.StatusEffects[i, 0] == -1) break; 
            if(Target.StatusEffects[i, 3] == Type || Target.StatusEffects[i, 4] == Type){
                if(Type >= 1)await Task.Delay(250);
                Effect_Trigger(i, Type, Target);
            }
        }
    }

    public void Effect_Trigger(int EffectSlot, int Type, Entity Target){
        int Amount;
        switch(Target.StatusEffects[EffectSlot, 0]){
            case 0:
                Amount = Convert.ToInt32(Math.Ceiling((float)Target.MaxHealth/20f*Target.StatusEffects[EffectSlot, 1]));
                Target.TriggerHeal(Amount);
                break;
            case 1:
                if(Fight.player.Overdrained) break;
                Target.Mana += Convert.ToInt32(Math.Ceiling((float)Target.MaxMana/20f*Target.StatusEffects[EffectSlot, 1]));
                if(Target.Mana>Target.MaxMana)Target.Mana = Target.MaxMana;
                StartCoroutine(Target.ManaBar.Mana_update());
                break;
            case 2:
                Target.BuffsDefence += 5 + Target.StatusEffects[EffectSlot, 1];
                break;
            case 3:
                Target.BuffsDamageModifier *= 1.2f;
                break;
            case 4:
                Amount = Target.StatusEffects[EffectSlot, 1]*2;
                Target.TriggerDamage(Amount);
                break;
            case 5:
                Amount = Convert.ToInt32(Math.Ceiling((float)Target.Health*(float)Target.StatusEffects[EffectSlot, 1]/100));
                Target.TriggerDamage(Amount);
                break;
            case 6:
                Target.BuffsDamageModifier *= 0.7f;
                break;
            case 7:
                if(Type == 0){
                    int AvoidChance;
                    switch(SkillManager.CH_Effect_EVChance){
                        case 1:
                            AvoidChance = 7;
                            break;
                        case 2:
                            AvoidChance = 5;
                            break;
                        default:
                            AvoidChance = 9;
                            break;
                    }
                    Target.BuffsAvoidChance = AvoidChance * Target.StatusEffects[EffectSlot, 1];
                }
                else {
                    float PercentDamage;
                    switch(SkillManager.CH_Effect_Damage){
                        case 1:
                            PercentDamage = 1f;
                            break;
                        case 2:
                            PercentDamage = 1.5f;
                            break;
                        default:
                            PercentDamage = 0.5f;
                            break;
                    }
                    PercentDamage*=Target.StatusEffects[EffectSlot, 1];
                    if(SkillManager.CH_Ultimate_HPPercent) PercentDamage*= (float)Target.MaxHealth/100;
                    else PercentDamage*= (float)Target.Health/100;
                    Target.TriggerDamage((int)PercentDamage);
                }
                break;
            case 8:
                if(Type == 0){
                    if(Target.DamageTaken>0 && Target.StatusEffects[EffectSlot, 3] != 5){
                        Remove(EffectSlot, Target);
                        return;
                    }
                    else if(LastBuffsDefence - Target.StatusEffects[EffectSlot, 1]<Target.DamageBlockedByBuffs && Target.StatusEffects[EffectSlot, 3] != 5)Target.StatusEffects[EffectSlot, 1] -= Target.DamageBlockedByBuffs - (LastBuffsDefence - Target.StatusEffects[EffectSlot, 1]);
                    int AddAmount;
                    if(Convert.ToInt32(Math.Ceiling(Target.StatusEffects[EffectSlot, 1]*1.1f))<Target.MaxHealth*2) AddAmount = Convert.ToInt32(Math.Ceiling(Target.StatusEffects[EffectSlot, 1]*0.1f));
                    else AddAmount = Target.MaxHealth*2-Target.StatusEffects[EffectSlot, 1];
                    Add(8, AddAmount, Target);
                    Target.StatusEffects[EffectSlot, 3] = 4;
                }
                else{
                    int AddAmount;
                    if(Convert.ToInt32(Math.Ceiling(Target.StatusEffects[EffectSlot, 1]*1.2f))<Target.MaxHealth*2) AddAmount = Convert.ToInt32(Math.Ceiling(Target.StatusEffects[EffectSlot, 1]*0.2f));
                    else AddAmount = Target.MaxHealth*2-Target.StatusEffects[EffectSlot, 1];
                    Add(8, AddAmount, Target);
                }
                Target.BuffsDefence += Target.StatusEffects[EffectSlot, 1];
                break;
            default:
                break;
        }
    }

}//effects: 0 - HPRegen, 1 - ManaRegen, 2 - Ironskin, 3 - Strength, 4 - Poison, 5 - Bleeding, 6 - Weakness, 7 - Chaos, 8 - Energy Shield, 9 - Healing Weakness, 10 - Healing Vampirism
//Type: 0 - passive(only changes variable values), 1 - Active, 2 - After Attack, 3 - After Getting Damage, 4 - After Avoid, 5 - Custom Implementation
