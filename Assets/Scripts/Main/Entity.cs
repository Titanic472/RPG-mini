using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public int Health, MaxHealth, HealthRegen, Mana, MaxMana, ManaRegen, Level, BuffsDefence, BuffsAvoidChance, MaxBuffsDamage = -1, DamageTaken, DamageTakenByBuffs, DamageBlockedByBuffs;
    public float BuffsDamageModifier = 1, BuffsDamageTakenModifier = 1;
    public int[,] StatusEffects = new int[10,5];//0 - id, 1 - duration, 2 - start duration, 3 - type, 4 - type2
    public GameObject SelfSprite;
    public HealthBar HealthBar;
    public Fight Fight;
    public Mana ManaBar;

    public void TriggerDamage(int Amount){
        if(MaxBuffsDamage >=0 && Amount > MaxBuffsDamage) Amount = MaxBuffsDamage;
        if(Health-Amount<=0){
            SelfSprite.GetComponent<F_Text_Creator>().CreateText_Red(Health + "");
            Health = 0;
            Fight.TriggerDeath();
        }
        else {
            Health -= Amount;
            SelfSprite.GetComponent<F_Text_Creator>().CreateText_Red(Amount + "");
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
