using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;
using TMPro;

public class Milk : Mob
{   
    int Heals = 3;

    public override void Attack(){
        float Chance = UnityEngine.Random.Range(0, 100);
        if(Chance<(100f-((float)Health/(float)MaxHealth*100f)-(3-Heals)*10f-20) && Heals > 0){
            Heal(Heals, 2);
            --Heals;
        }
        else if(Chance<20f && Heals <=1) PowerfulAttack();
        else StandardAttack();
    }

    public void PowerfulAttack(){
        bool Avoided = CheckPlayerAvoid();
        if(!Avoided){
            float AttackDamage = Damage*1.5f*BuffsDamageModifier;
            player.GetDamage(Convert.ToInt32(Math.Floor(AttackDamage)), true, false);
            TriggerEffects();
        }
        else Fight.EffectsManager.TriggerEffects(4, player);
    }

    public override void LootGenerate(){
        if(!player.game.BossesDefeated[0]){
            Fight.InventoryManager.Inventory_Add(8, 1, -1, true);
            player.game.BossesDefeated[0] = true;
            player.speedEnergy.AddMoreSlots();
            ++player.MaxSpeedEnergy;
        }
        else Fight.EndBattleWindow.transform.Find("LootItem").GetComponent<SpriteRenderer>().sprite = Fight.InventoryManager.Empty;
        XPReward = player.NewLevelXP;
        Fight.EndBattle();
        /*int Chance = UnityEngine.Random.Range(0, 100);
        if(Chance<5){*/
    }

    public override async void GetDamage(int Amount, bool AllowArmor = true, bool IsCrit = false){
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
        if(Amount>40) Amount = 40;
        if(IsCrit) GetComponent<F_Text_Creator>().CreateText_Red(Amount +" Crit!");
        else GetComponent<F_Text_Creator>().CreateText_Red(Amount +"");
        Health -= Amount;
        if(Health<0) Health = 0;
        StartCoroutine(HealthBar.HP_update());
        ActiveSkillsAddDamage = 0;//Change to if() when Precise hit Ultimate added
        if(Health==0){
            Fight.StopWatch.StopCounting();
            await Task.Delay(500);
            Fight.TriggerDeath();
        }
    }
}
