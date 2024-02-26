using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;
using TMPro;

public class PinkSlime : Mob
{   
    
    public override void Attack(){
        StandardAttack();
    }

    public override void LootGenerate(){
        Fight.EndBattle();
        int Chance = UnityEngine.Random.Range(0, 100);
        if(Chance<5){
            if(!Fight.SlimyArmor.ChestplateOwned){
                Fight.EndBattleWindow.transform.Find("LootItem").GetComponent<SpriteRenderer>().sprite = player.game.Item_Sprites[3];
                Fight.InventoryManager.Inventory_Add(3, 1, -1);
                Fight.SlimyArmor.ChestplateOwned = true;
            }
            else {
                Fight.SlimyArmor.Experience_Add_Chestplate(50);
                Fight.EndBattleWindow.transform.Find("LootItem").GetComponent<SpriteRenderer>().sprite = Fight.InventoryManager.Empty;
            }
        }
        else Fight.EndBattleWindow.transform.Find("LootItem").GetComponent<SpriteRenderer>().sprite = Fight.InventoryManager.Empty;
    }

}
