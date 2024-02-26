using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;
using TMPro;

public class SlimyArmor : MonoBehaviour
{   
    public Player player;
    public Game game;
    public InventoryManager InventoryManager;
    public Dictionary<string, int> Chestplate = new Dictionary<string, int>();
    public bool ChestplateOwned, ChestplateEquipped;

    void Awake(){
        Chestplate.Add("Level", 1);
        Chestplate.Add("Tier", 1);
        Chestplate.Add("MinDefence", 0);
        Chestplate.Add("MaxDefence", 3);
        Chestplate.Add("Accuracy", 0);
        Chestplate.Add("Evasion", 0);
        Chestplate.Add("Mana", 0);
        Chestplate.Add("DamageResistance", 0);
        Chestplate.Add("XP", 0);
        Chestplate.Add("NewLevelXP", 100);
    }

    public void Experience_Add(int amount){
        if(ChestplateEquipped)Experience_Add_Chestplate(amount);
    }

    public void Experience_Add_Chestplate(int amount){
        if(Chestplate["Level"]==25) return;
        Chestplate["XP"] += amount;
        if(Chestplate["XP"]>=Chestplate["NewLevelXP"]){ 
            Chestplate_Upgrade(); 
            InventoryManager.EquippedUpgrade("Chest");
        }
    }

    public void Chestplate_Sell(){
        Chestplate["Level"] = 1;
        Chestplate["Tier"] = 1;
        Chestplate["MinDefence"] = 0;
        Chestplate["MaxDefence"] = 3;
        Chestplate["Accuracy"] = 0;
        Chestplate["Evasion"] = 0;
        Chestplate["Mana"] = 0;
        Chestplate["DamageResistance"] = 0;
        Chestplate["XP"] = 0;
        Chestplate["NewLevelXP"] = 100;
        player.MoneyManager("Add", Chestplate["Level"]*100);
        ChestplateOwned = false;
    }

    public void Chestplate_Get(){
        game.ContText["Name"] = Language_Changer.Instance.GetText("Slimy_Chestplate");
        game.ContText["Description"] = Language_Changer.Instance.GetText("Slimy_Chestplate Description");
        game.ContText["Description"] += "\n\n" + Language_Changer.Instance.GetText("Experience") + ": " + Chestplate["XP"] + "/" + Chestplate["NewLevelXP"];
        game.ContText["Type"] = "Chestplate";
        game.Container["ID"] = 3;
        game.Container["Level"] = Chestplate["Level"];
        game.Container["Tier"] = Chestplate["Tier"];
        game.ContText["Type"] = "Chestplate";
        game.Container["MinDefence"] = Chestplate["MinDefence"];
        game.Container["MaxDefence"] = Chestplate["MaxDefence"];
        game.Container["Accuracy"] = Chestplate["Accuracy"];
        game.Container["Evasion"] = Chestplate["Evasion"];
        game.Container["Mana"] = Chestplate["Mana"];
        game.Container["DamageResistance"] = Chestplate["DamageResistance"];
        game.Container["Price"] = Chestplate["Level"]*100;
    }

    public void Chestplate_Upgrade(){
        ++Chestplate["Level"];
        Chestplate["XP"] -= Chestplate["NewLevelXP"];
        if(Chestplate["Level"] <5){
            Chestplate["Tier"] = 1;
            Chestplate["MinDefence"] += 1;
            Chestplate["MaxDefence"] += 2;
            Chestplate["Accuracy"] += 0;
            Chestplate["Evasion"] += 0;
            Chestplate["Mana"] += 0;
            Chestplate["DamageResistance"] += 0;
            Chestplate["NewLevelXP"] += 100;
            return;
        }
        if(Chestplate["Level"] <10){
            Chestplate["Tier"] = 2;
            Chestplate["MinDefence"] += 2;
            Chestplate["MaxDefence"] += 3;
            Chestplate["Accuracy"] += 2;
            Chestplate["Evasion"] += 3;
            Chestplate["Mana"] += 0;
            Chestplate["DamageResistance"] += 0;
            Chestplate["NewLevelXP"] += 120;
            return;
        }
        if(Chestplate["Level"] <15){
            Chestplate["Tier"] = 3;
            Chestplate["MinDefence"] += 3;
            Chestplate["MaxDefence"] += 5;
            Chestplate["Accuracy"] += 4;
            Chestplate["Evasion"] += 6;
            Chestplate["Mana"] += 0;
            Chestplate["DamageResistance"] += 0;
            Chestplate["NewLevelXP"] += 150;
            return;
        }
        if(Chestplate["Level"] <20){
            Chestplate["Tier"] = 4;
            Chestplate["MinDefence"] += 5;
            Chestplate["MaxDefence"] += 8;
            Chestplate["Accuracy"] += 7;
            Chestplate["Evasion"] += 10;
            Chestplate["Mana"] += 15;
            Chestplate["DamageResistance"] += 1;
            Chestplate["NewLevelXP"] += 200;
            return;
        }
        if(Chestplate["Level"] <25){
            Chestplate["Tier"] = 5;
            Chestplate["MinDefence"] += 10;
            Chestplate["MaxDefence"] += 14;
            Chestplate["Accuracy"] += 15;
            Chestplate["Evasion"] += 15;
            Chestplate["Mana"] += 35;
            Chestplate["DamageResistance"] += 2;
            Chestplate["NewLevelXP"] += 250;
            return;
        }
    }
}
