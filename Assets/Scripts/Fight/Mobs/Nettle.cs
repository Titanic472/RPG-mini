using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;
using TMPro;

public class Nettle : Mob
{   
    
    public override void Attack(){
        StandardAttack();
    }

    public override void LootGenerate(){
        Fight.EndBattle();
        int Chance = UnityEngine.Random.Range(0, 100);
        if(Chance<5){
            Fight.EndBattleWindow.transform.Find("LootItem").GetComponent<SpriteRenderer>().sprite = player.game.Item_Sprites[1];
            Fight.InventoryManager.Inventory_Add(1, 1, -1);
        }
        else if(Chance>=5 && Chance <10){
            Fight.EndBattleWindow.transform.Find("LootItem").GetComponent<SpriteRenderer>().sprite = player.game.Item_Sprites[0];
            Fight.InventoryManager.Inventory_Add(0, 1, -1);
        }
        else Fight.EndBattleWindow.transform.Find("LootItem").GetComponent<SpriteRenderer>().sprite = Fight.InventoryManager.Empty;
    }

}
