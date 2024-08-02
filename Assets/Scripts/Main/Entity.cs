using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public Game game; 
    public int BaseHealth, Health, MaxHealth, BaseHealthRegen, HealthRegen, Evasion, Accuracy, BaseEvasion, BaseAccuracy, BaseMana, Mana, MaxMana, BaseManaRegen, ManaRegen, Level, BuffsDefence, BuffsAvoidChance, MaxBuffsDamage = -1, DamageTaken, DamageTakenByBuffs, DamageBlockedByBuffs;
    public float BuffsDamageModifier = 1, BuffsDamageTakenModifier = 1, MagicDefence = 0f, BuffsEvasionModifier = 1f, BuffsAccuracyModifier = 1f;
    public int BuffsEvasion = 0, BuffsAccuracy = 0;
    public int[,] StatusEffects = new int[10,5];//0 - id, 1 - duration, 2 - start duration, 3 - type, 4 - type2
    public GameObject SelfSprite;
    public HealthBar HealthBar;
    public Fight Fight;
    public Mana ManaBar;

    public virtual void UpdateAllStats(){
        Evasion = Convert.ToInt32(Math.Floor((BaseEvasion + BuffsEvasion)*BuffsEvasionModifier));
        Accuracy = Convert.ToInt32(Math.Floor((BaseAccuracy + BuffsAccuracy)*BuffsAccuracyModifier));
        HealthRegen = BaseHealthRegen;
    }
    public void TriggerDamage(int Amount){
        if(MaxBuffsDamage >=0 && Amount > MaxBuffsDamage) Amount = MaxBuffsDamage;
        Debug.Log("Amount: " + Amount);
        if(Health-Amount<=0){
            SelfSprite.GetComponent<F_Text_Creator>().CreateText_Red(Health + "");
            Debug.Log(Health + "");
            Health = 0;
            if(Fight.InBattle) Fight.TriggerDeath();
            else game.EndGame();
        }
        else {
            Health -= Amount;
            SelfSprite.GetComponent<F_Text_Creator>().CreateText_Red(Amount + "");
            Debug.Log(Amount + "");
        }
        DamageTakenByBuffs += Amount;
        StartCoroutine(HealthBar.HP_update());
    }

    public void TriggerHeal(int Amount){
        if(Health+Amount>MaxHealth){
            SelfSprite.GetComponent<F_Text_Creator>().CreateText_Green(MaxHealth-Health + "");
            Health = MaxHealth;
        }
        else {
            Health += Amount;
            SelfSprite.GetComponent<F_Text_Creator>().CreateText_Green(Amount + "");
        }
        StartCoroutine(HealthBar.HP_update());
    }
}
