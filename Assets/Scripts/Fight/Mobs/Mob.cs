using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;
using TMPro;

public class Mob : Entity
{   
    public Player player;
    public int[] XPReward = new int[25];
    public int MinCoins, MaxCoins, LevelHPBoost, Damage, Evasion, Accuracy, MaxDefence, MinDefence, MaxAvoidChance, MaxCritChance;
    public float DamageResistance, XPLevelModifier, LevelDamage, LevelMaxDefence, LevelMinDefence, LevelAccuracy, LevelEvasion, ActiveSkillsAddDamage;
    
    public void Mob_Load(){
        if(Level<0) Level = 0; 
        for(int i = 0; i<Level; ++i){
            MaxHealth += LevelHPBoost;
            if(XPReward[0]==0)continue;
            int Add = 0, Add1 = 0;
            for(int j = 24; j>0; --j){
                if(j>1) Add1 = Convert.ToInt32(Math.Floor(XPReward[j]*(1f+XPLevelModifier)*1000f))%1000;
                XPReward[j] = Convert.ToInt32(Math.Floor(XPReward[j]*(1f+XPLevelModifier))) + Add;
                Add = Add1;
                while(XPReward[j]>=1000 && j!=24){
                    ++XPReward[j+1];
                    XPReward[j]-=1000;
                    if(j+1>XPReward[0])XPReward[0] = j+1;
                }
            }
        }
        Health = MaxHealth;
        Accuracy += Convert.ToInt32(LevelAccuracy*Level);
        Evasion += Convert.ToInt32(LevelEvasion*Level);
        Damage += Convert.ToInt32(LevelDamage*Level);
        MaxDefence += Convert.ToInt32(LevelMaxDefence*Level);
        MinDefence += Convert.ToInt32(LevelMinDefence*Level);
        for(int i = 0; i<10; ++i) for(int j = 0; j<5;++j) StatusEffects[i, j] = -1;
        HealthBar.Target = this;
        player.mob = this;
        Fight.ActiveSkills.mob = this;
        HealthBar.Restart();
    }

    public virtual void Attack(){}

    public virtual void LootGenerate(){}

    public void Heal(int Condition = 0, int ConditionValue = 0){
        float Modifier = 1;
        if(Fight.EffectsManager.GetEffect(10, this)){
            if(Health > MaxHealth/2 || Condition < ConditionValue)player.TriggerHeal(Convert.ToInt32((float)(MaxHealth-Health)*0.2f));
            else player.TriggerHeal(Convert.ToInt32((float)MaxHealth*0.1f));
            Modifier=0.8f;
            }
            if(Fight.EffectsManager.GetEffect(9, this))Modifier*=0.5f;
        if(MaxHealth - Health > Convert.ToInt32((float)MaxHealth/2*Modifier) && Condition >= ConditionValue){
            SelfSprite.GetComponent<F_Text_Creator>().CreateText_Green(Convert.ToInt32((float)MaxHealth/2*Modifier) + "");
            Health += Convert.ToInt32((float)MaxHealth/2*Modifier);
        }
        else{
            SelfSprite.GetComponent<F_Text_Creator>().CreateText_Green(MaxHealth - Health + "");
            Health = MaxHealth;
        }
        StartCoroutine(HealthBar.HP_update());
    }

    public void TriggerEffects(){
        Fight.EffectsManager.TriggerEffects(2, this);
        if(player.Health==0) return;
        Fight.EffectsManager.TriggerEffects(3, player);
        if(player.Health==0){
            Fight.Game.EndGame();
            return;
        }
    }

    public bool CheckPlayerAvoid(){
        if(player.Parry())player.SelfSprite.GetComponent<F_Text_Creator>().CreateText_Red(Language_Changer.Instance.GetText("Parried"));
        else if(player.Avoid()) player.SelfSprite.GetComponent<F_Text_Creator>().CreateText_Red(Language_Changer.Instance.GetText("Avoided"));
        else return false;
        return true;
    }

    public void StandardAttack(){
        bool Avoided = CheckPlayerAvoid();
        if(!Avoided){
            int AttackDamage = Damage;
            AttackDamage = Convert.ToInt32(Math.Ceiling(AttackDamage*BuffsDamageModifier));
            bool IsCrit = Crit();
            AttackDamage += AttackDamage*Convert.ToInt32(IsCrit);
            player.GetDamage(AttackDamage, true, IsCrit);
            TriggerEffects();
        }
        else Fight.EffectsManager.TriggerEffects(4, player);
    }

    public bool Crit(){
        int Chance = UnityEngine.Random.Range(0, 100);
        if(Chance<Math.Min(MaxCritChance, Accuracy-player.Skills["Evasion"])) return true;
        else return false;
    }

    public bool Avoid(){
        if(ActiveSkillsAddDamage > 0) return false;
        int Chance = UnityEngine.Random.Range(0, 100);
        if(Chance<player.BrutalityStreak_MobAvoidChance) return true;
        else Chance = UnityEngine.Random.Range(0, 100);
        if(Chance<Math.Min(MaxAvoidChance, Evasion-player.Skills["Accuracy"])) return true;
        else Chance = UnityEngine.Random.Range(1, 101);
        if(Chance<BuffsAvoidChance) return true;
        else return false;
    }

    public virtual async void GetDamage(int Amount, bool AllowArmor = true, bool IsCrit = false){
        Amount += Convert.ToInt32(Math.Ceiling(Amount*ActiveSkillsAddDamage));
        Amount = Convert.ToInt32(Math.Floor(Amount*BuffsDamageTakenModifier));
        Amount = Convert.ToInt32(Math.Floor(Amount-Amount*DamageResistance));
        if(AllowArmor){
            int Defence = UnityEngine.Random.Range(MinDefence, MaxDefence+1);
            Amount -= Defence;
            if(Amount > 0){
                Amount -= BuffsDefence;
                if(Amount >= 0)DamageBlockedByBuffs += BuffsDefence;
                else DamageBlockedByBuffs += BuffsDefence+Amount;
            }
        }
        if(Amount<0) Amount = 0;
        if(IsCrit) GetComponent<F_Text_Creator>().CreateText_Red(Amount +" Crit!");
        else GetComponent<F_Text_Creator>().CreateText_Red(Amount +"");
        Health -= Amount;
        DamageTaken += Amount;
        if(Health<0) Health = 0;
        StartCoroutine(HealthBar.HP_update());
        ActiveSkillsAddDamage = 0;//Change to if() when Precise hit Ultimate added
        if(Health==0){
            await Task.Delay(500);
            Fight.TriggerDeath();
        }
    }

}
