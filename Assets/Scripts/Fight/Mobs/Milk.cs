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
        float AttackDamage = Damage*1.5f*BuffsDamageModifier;
        player.GetDamage(Convert.ToInt32(Math.Floor(AttackDamage)), true, false);
    }

    public override void LootGenerate(){
        Fight.EndBattle();
        if(!player.game.BossesDefeated[0]){
            Fight.InventoryManager.Inventory_Add(8, 1, -1, true);
            player.game.BossesDefeated[0] = true;
            player.speedEnergy.AddMoreSlots();
            ++player.MaxSpeedEnergy;
        }
        else Fight.EndBattleWindow.transform.Find("LootItem").GetComponent<SpriteRenderer>().sprite = Fight.InventoryManager.Empty;
        XPReward = player.NewLevelXP;
        
        /*int Chance = UnityEngine.Random.Range(0, 100);
        if(Chance<5){*/
    }
}
