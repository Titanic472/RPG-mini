using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;
using TMPro;

public class InventoryManager : MonoBehaviour
{   
    public Player player;
    public Game game;
    public GameObject[] ItemSlots = new GameObject[45];
    public Sprite Empty, HeadSlotEmpty, ChestSlotEmpty, LegsSlotEmpty, LeftHandSlotEmpty, RightHandSlotEmpty, Ring1SlotEmpty, Ring2SlotEmpty;
    public GameObject InformationBackground;
    public int InvokeID;
    public TextMeshProUGUI Title, Description, DescriptionStats, DescriptionStats2, TitleProfile, DescriptionProfile, DescriptionStatsProfile, DescriptionStatsProfile2;
    public RuntimeAnimatorController SlimyChestplate;
    public GameObject UpgradeButton, UpgradeButtonProfile, UnequipButton, Sell, Equip, Use, Choose, HeadSlot, ChestSlot, LegsSlot, LeftHandSlot, RightHandSlot, Ring1Slot, Ring2Slot;
    public string Potion, ChooseType, InventorySlot; 

    public void Item_Sell(){
        if(player.Inventory[InvokeID*3] == 3) game.SlimyArmor.Chestplate_Sell();
        else player.MoneyManager("Add", game.Container["Price"]/3, game.Container["PriceModifier"]);
        Inventory_Remove(InvokeID);
        InformationBackground.SetActive(false);
        ShowSprites();
    }

    public void EquipButton(){
        switch(game.ContText["Type"]){
            case "Hat":
                Item_Equip("Head");
                break;
            case "Chestplate":
                Item_Equip("Chest");
                break;
            case "Boots":
                Item_Equip("Legs");
                break;
            case "Weapon":
                if(game.Container["Is2Handed"]==1)Item_Equip("RightHand");
                ChooseType = "Weapon";
                Choose.transform.Find("Image1").GetComponent<SpriteRenderer>().sprite = RightHandSlot.transform.Find("Image").GetComponent<SpriteRenderer>().sprite;
                Choose.transform.Find("Image2").GetComponent<SpriteRenderer>().sprite = LeftHandSlot.transform.Find("Image").GetComponent<SpriteRenderer>().sprite;
                InformationBackground.SetActive(false);
                ShowSprites();
                HideSprites2();
                Choose.SetActive(true);
                break;
            case "Ring":
                ChooseType = "Ring";
                Choose.transform.Find("Image1").GetComponent<SpriteRenderer>().sprite = Ring1Slot.transform.Find("Image").GetComponent<SpriteRenderer>().sprite;
                Choose.transform.Find("Image2").GetComponent<SpriteRenderer>().sprite = Ring2Slot.transform.Find("Image").GetComponent<SpriteRenderer>().sprite;
                InformationBackground.SetActive(false);
                ShowSprites();
                HideSprites2();
                Choose.SetActive(true);
                break;
        }
    }

    public void ChooseSlot(bool SecondSlot){
        if(ChooseType == "Weapon"){
            if(SecondSlot) Item_Equip("LeftHand", true);
            else Item_Equip("RightHand", true);
        }
        else{
            if(SecondSlot) Item_Equip("Ring2", true);
            else Item_Equip("Ring1", true);
        }
        Choose.SetActive(false);
        ShowSprites();
    }

    public void Item_Equip(string Slot, bool Unequip = true){
        if(game.Container["Is2Handed"] == 1 && player.Inventory[57]!=-1 || game.Container["ID"]==-1) return;
        //Debug.Log(game.Container["Level"]);
        if(Unequip){
            player.Inventory[InvokeID*3] = -1;
            player.Inventory[InvokeID*3+1] = -1;
            player.Inventory[InvokeID*3+2] = -1;
            Inventory_Reorganise();
            if(Unequip)Item_Unequip(Slot);
            InformationBackground.SetActive(false);
            ShowSprites();
        }
        switch(Slot){
            case "Head":
                player.Head["ID"] = game.Container["ID"];
                player.Head["Level"] = game.Container["Level"];
                player.Head["Tier"] = game.Container["Tier"];
                player.Head["MinDefence"] = game.Container["MinDefence"];
                player.Head["MaxDefence"] = game.Container["MaxDefence"];
                player.Head["Accuracy"] = game.Container["Accuracy"];
                player.Head["Evasion"] = game.Container["Evasion"];
                player.Head["Mana"] = game.Container["Mana"];
                player.Head["DamageResistance"] = game.Container["DamageResistance"];
                HeadSlot.transform.Find("Image").GetComponent<SpriteRenderer>().sprite = game.Item_Sprites[game.Container["ID"]];
                HeadSlot.transform.Find("Level_Text").GetComponent<TextMeshProUGUI>().text = Language_Changer.Instance.GetText("Lvl") + ": " + game.Container["Level"];
                HeadSlot.GetComponent<InventorySlot_Profile>().Equipped = true;
                break;
            case "Chest":
                player.Chest["ID"] = game.Container["ID"];
                player.Chest["Level"] = game.Container["Level"];
                player.Chest["Tier"] = game.Container["Tier"];
                player.Chest["MinDefence"] = game.Container["MinDefence"];
                player.Chest["MaxDefence"] = game.Container["MaxDefence"];
                player.Chest["Accuracy"] = game.Container["Accuracy"];
                player.Chest["Evasion"] = game.Container["Evasion"];
                player.Chest["Mana"] = game.Container["Mana"];
                player.Chest["DamageResistance"] = game.Container["DamageResistance"];
                if(game.Container["ID"]==3) {
                    ChestSlot.transform.Find("Image").GetComponent<Animator>().runtimeAnimatorController = SlimyChestplate;
                    if( game.Container["ID"] == 3) game.SlimyArmor.ChestplateEquipped = true; 
                }
                else ChestSlot.transform.Find("Image").GetComponent<Animator>().runtimeAnimatorController = null;
                ChestSlot.transform.Find("Image").GetComponent<SpriteRenderer>().sprite = game.Item_Sprites[game.Container["ID"]];
                ChestSlot.transform.Find("Level_Text").GetComponent<TextMeshProUGUI>().text = Language_Changer.Instance.GetText("Lvl") + ": " + game.Container["Level"];
                ChestSlot.GetComponent<InventorySlot_Profile>().Equipped = true;
                break;
            case "Legs":
                player.Legs["ID"] = game.Container["ID"];
                player.Legs["Level"] = game.Container["Level"];
                player.Legs["Tier"] = game.Container["Tier"];
                player.Legs["MinDefence"] = game.Container["MinDefence"];
                player.Legs["MaxDefence"] = game.Container["MaxDefence"];
                player.Legs["Accuracy"] = game.Container["Accuracy"];
                player.Legs["Evasion"] = game.Container["Evasion"];
                player.Legs["Mana"] = game.Container["Mana"];
                player.Legs["DamageResistance"] = game.Container["DamageResistance"];
                LegsSlot.transform.Find("Image").GetComponent<SpriteRenderer>().sprite = game.Item_Sprites[game.Container["ID"]];
                LegsSlot.transform.Find("Level_Text").GetComponent<TextMeshProUGUI>().text = Language_Changer.Instance.GetText("Lvl") + ": " + game.Container["Level"];
                LegsSlot.GetComponent<InventorySlot_Profile>().Equipped = true;
                break;
            case "LeftHand":
                player.LeftHand["Damage"] = game.Container["Damage"];
                player.LeftHand["Speed"] = game.Container["Speed"];
                player.LeftHand["ID"] = game.Container["ID"];
                player.LeftHand["Level"] = game.Container["Level"];
                player.LeftHand["Tier"] = game.Container["Tier"];
                player.LeftHand["Accuracy"] = game.Container["Accuracy"];
                player.LeftHand["Evasion"] = game.Container["Evasion"];
                player.LeftHand["ManaUsage"] = game.Container["ManaUsage"];
                player.LeftHand["EnchantId"] = game.Container["EnchantId"];
                LeftHandSlot.transform.Find("Image").GetComponent<SpriteRenderer>().sprite = game.Item_Sprites[game.Container["ID"]];
                LeftHandSlot.transform.Find("Level_Text").GetComponent<TextMeshProUGUI>().text = Language_Changer.Instance.GetText("Lvl") + ": " + game.Container["Level"];
                LeftHandSlot.GetComponent<InventorySlot_Profile>().Equipped = true;
                break;
            case "RightHand":
                player.RightHand["Damage"] = game.Container["Damage"];
                player.RightHand["Speed"] = game.Container["Speed"];
                player.RightHand["ID"] = game.Container["ID"];
                player.RightHand["Level"] = game.Container["Level"];
                player.RightHand["Tier"] = game.Container["Tier"];
                player.RightHand["Is2Handed"] = game.Container["Is2Handed"];
                player.RightHand["Accuracy"] = game.Container["Accuracy"];
                player.RightHand["Evasion"] = game.Container["Evasion"];
                player.RightHand["ManaUsage"] = game.Container["ManaUsage"];
                player.RightHand["EnchantId"] = game.Container["EnchantId"];
                RightHandSlot.transform.Find("Image").GetComponent<SpriteRenderer>().sprite = game.Item_Sprites[game.Container["ID"]];
                RightHandSlot.transform.Find("Level_Text").GetComponent<TextMeshProUGUI>().text = Language_Changer.Instance.GetText("Lvl") + ": " + game.Container["Level"];
                RightHandSlot.GetComponent<InventorySlot_Profile>().Equipped = true;
                if(game.Container["Is2Handed"] == 1){
                    player.LeftHand["IsActive"] = 0;
                    Item_Unequip("LeftHand");
                }
                break;
            case "Ring1":
                player.Ring1["AdditionalDamage"] = game.Container["AdditionalDamage"];
                player.Ring1["DamageModifier"] = game.Container["DamageModifier"];
                player.Ring1["DefenceModifier"] = game.Container["DefenceModifier"];
                player.Ring1["ExperienceModifier"] = game.Container["ExperienceModifier"];
                player.Ring1["ID"] = game.Container["ID"];
                player.Ring1["Level"] = game.Container["Level"];
                player.Ring1["Tier"] = game.Container["Tier"];
                player.Ring1["Health"] = game.Container["Health"];
                player.Ring1["HealthModifier"] = game.Container["HealthModifier"];
                player.Ring1["SpeedModifier"] = game.Container["SpeedModifier"];
                player.Ring1["Accuracy"] = game.Container["Accuracy"];
                player.Ring1["Evasion"] = game.Container["Evasion"];
                player.Ring1["Mana"] = game.Container["Mana"];
                player.Ring1["ManaModifier"] = game.Container["ManaModifier"];
                player.Ring1["ManaRegen"] = game.Container["ManaRegen"];
                player.Ring1["HealthRegen"] = game.Container["HealthRegen"];
                player.Ring1["ManaCost"] = game.Container["ManaCost"];
                player.Ring1["DamageResistance"] = game.Container["DamageResistance"];
                Ring1Slot.transform.Find("Image").GetComponent<SpriteRenderer>().sprite = game.Item_Sprites[game.Container["ID"]];
                Ring1Slot.transform.Find("Level_Text").GetComponent<TextMeshProUGUI>().text = Language_Changer.Instance.GetText("Lvl") + ": " + game.Container["Level"];
                Ring1Slot.GetComponent<InventorySlot_Profile>().Equipped = true;
                break;
            case "Ring2":
                player.Ring2["AdditionalDamage"] = game.Container["AdditionalDamage"];
                player.Ring2["DamageModifier"] = game.Container["DamageModifier"];
                player.Ring2["DefenceModifier"] = game.Container["DefenceModifier"];
                player.Ring2["ExperienceModifier"] = game.Container["ExperienceModifier"];
                player.Ring2["ID"] = game.Container["ID"];
                player.Ring2["Level"] = game.Container["Level"];
                player.Ring2["Tier"] = game.Container["Tier"];
                player.Ring2["Health"] = game.Container["Health"];
                player.Ring2["HealthModifier"] = game.Container["HealthModifier"];
                player.Ring2["SpeedModifier"] = game.Container["SpeedModifier"];
                player.Ring2["Accuracy"] = game.Container["Accuracy"];
                player.Ring2["Evasion"] = game.Container["Evasion"];
                player.Ring2["Mana"] = game.Container["Mana"];
                player.Ring2["ManaModifier"] = game.Container["ManaModifier"];
                player.Ring2["ManaRegen"] = game.Container["ManaRegen"];
                player.Ring2["HealthRegen"] = game.Container["HealthRegen"];
                player.Ring2["ManaCost"] = game.Container["ManaCost"];
                player.Ring2["DamageResistance"] = game.Container["DamageResistance"];
                Ring2Slot.transform.Find("Image").GetComponent<SpriteRenderer>().sprite = game.Item_Sprites[game.Container["ID"]];
                Ring2Slot.transform.Find("Level_Text").GetComponent<TextMeshProUGUI>().text = Language_Changer.Instance.GetText("Lvl") + ": " + game.Container["Level"];
                Ring2Slot.GetComponent<InventorySlot_Profile>().Equipped = true;
                break;
            default:
                break;
        }
        player.UpdateModifiers();
        player.UpdateAllStats();
        player.HealthBar.Reset();
        player.ManaBar.Reset();
    }

    public void Item_Unequip(string Slot){
        if(player.Inventory[87]==-1){
            switch(Slot){
                case "Head":
                    Inventory_Add(player.Head["ID"],player.Head["Level"],-1);
                    player.Head["ID"] = -1;
                    player.Head["Level"] = 0;
                    player.Head["Tier"] = 0;
                    player.Head["MinDefence"] = 0;
                    player.Head["MaxDefence"] = 0;
                    player.Head["Accuracy"] = 0;
                    player.Head["Evasion"] = 0;
                    player.Head["Mana"] = 0;
                    player.Head["DamageResistance"] = 0;
                    HeadSlot.transform.Find("Image").GetComponent<SpriteRenderer>().sprite = HeadSlotEmpty;
                    HeadSlot.transform.Find("Level_Text").GetComponent<TextMeshProUGUI>().text = "";
                    HeadSlot.GetComponent<InventorySlot_Profile>().Equipped = false;
                    break;
                case "Chest":
                    Inventory_Add(player.Chest["ID"],player.Chest["Level"],-1);
                    if(player.Chest["ID"] == 3) game.SlimyArmor.ChestplateEquipped = false;
                    player.Chest["ID"] = -1;
                    player.Chest["Level"] = 0;
                    player.Chest["Tier"] = 0;
                    player.Chest["MinDefence"] = 0;
                    player.Chest["MaxDefence"] = 0;
                    player.Chest["Accuracy"] = 0;
                    player.Chest["Evasion"] = 0;
                    player.Chest["Mana"] = 0;
                    player.Chest["DamageResistance"] = 0;
                    ChestSlot.transform.Find("Image").GetComponent<Animator>().runtimeAnimatorController = null;
                    ChestSlot.transform.Find("Image").GetComponent<SpriteRenderer>().sprite = ChestSlotEmpty;
                    ChestSlot.transform.Find("Level_Text").GetComponent<TextMeshProUGUI>().text = "";
                    ChestSlot.GetComponent<InventorySlot_Profile>().Equipped = false;
                    break;
                case "Legs":
                    Inventory_Add(player.Legs["ID"],player.Legs["Level"],-1);
                    player.Legs["ID"] = -1;
                    player.Legs["Level"] = 0;
                    player.Legs["Tier"] = 0;
                    player.Legs["MinDefence"] = 0;
                    player.Legs["MaxDefence"] = 0;
                    player.Legs["Accuracy"] = 0;
                    player.Legs["Evasion"] = 0;
                    player.Legs["Mana"] = 0;
                    player.Legs["DamageResistance"] = 0;
                    LegsSlot.transform.Find("Image").GetComponent<SpriteRenderer>().sprite = LegsSlotEmpty;
                    LegsSlot.transform.Find("Level_Text").GetComponent<TextMeshProUGUI>().text = "";
                    LegsSlot.GetComponent<InventorySlot_Profile>().Equipped = false;
                    break;
                case "LeftHand":
                    Inventory_Add(player.LeftHand["ID"],player.LeftHand["Level"],player.LeftHand["EnchantId"]);
                    player.LeftHand["Damage"] = 0;
                    player.LeftHand["Speed"] = 1;
                    player.LeftHand["ID"] = -1;
                    player.LeftHand["Level"] = 0;
                    player.LeftHand["Tier"] = 0;
                    player.LeftHand["Accuracy"] = 0;
                    player.LeftHand["Evasion"] = 0;
                    player.LeftHand["ManaUsage"] = 0;
                    player.LeftHand["EnchantId"] = -1;
                    LeftHandSlot.transform.Find("Image").GetComponent<SpriteRenderer>().sprite = LeftHandSlotEmpty;
                    LeftHandSlot.transform.Find("Level_Text").GetComponent<TextMeshProUGUI>().text = "";
                    LeftHandSlot.GetComponent<InventorySlot_Profile>().Equipped = false;
                    break;
                case "RightHand":
                    Inventory_Add(player.RightHand["ID"],player.RightHand["Level"],player.RightHand["EnchantId"]);
                    player.RightHand["Damage"] = 0;
                    player.RightHand["Speed"] = 1;
                    player.RightHand["ID"] = -1;
                    player.RightHand["Level"] = 0;
                    player.RightHand["Tier"] = 0;
                    player.RightHand["Is2Handed"] = 0;
                    player.RightHand["Accuracy"] = 0;
                    player.RightHand["Evasion"] = 0;
                    player.RightHand["ManaUsage"] = 0;
                    player.RightHand["EnchantId"] = -1;
                    player.LeftHand["IsActive"] = 1;
                    RightHandSlot.transform.Find("Image").GetComponent<SpriteRenderer>().sprite = RightHandSlotEmpty;
                    RightHandSlot.transform.Find("Level_Text").GetComponent<TextMeshProUGUI>().text = "";
                    RightHandSlot.GetComponent<InventorySlot_Profile>().Equipped = false;
                    break;
                case "Ring1":
                    Inventory_Add(player.Ring1["ID"],player.Ring1["Level"],-1);
                    player.Ring1["AdditionalDamage"] = 0;
                    player.Ring1["DamageModifier"] = 100;
                    player.Ring1["DefenceModifier"] = 100;
                    player.Ring1["ExperienceModifier"] = 100;
                    player.Ring1["ID"] = -1;
                    player.Ring1["Level"] = 0;
                    player.Ring1["Tier"] = 0;
                    player.Ring1["Health"] = 0;
                    player.Ring1["HealthModifier"] = 100;
                    player.Ring1["SpeedModifier"] = 100;
                    player.Ring1["Accuracy"] = 0;
                    player.Ring1["Evasion"] = 0;
                    player.Ring1["Mana"] = 0;
                    player.Ring1["ManaModifier"] = 100;
                    player.Ring1["ManaRegen"] = 0;
                    player.Ring1["HealthRegen"] = 0;
                    player.Ring1["ManaCost"] = 100;
                    player.Ring1["DamageResistance"] = 0;
                    Ring1Slot.transform.Find("Image").GetComponent<SpriteRenderer>().sprite = Ring1SlotEmpty;
                    Ring1Slot.transform.Find("Level_Text").GetComponent<TextMeshProUGUI>().text = "";
                    Ring1Slot.GetComponent<InventorySlot_Profile>().Equipped = false;
                    break;
                case "Ring2":
                    Inventory_Add(player.Ring2["ID"],player.Ring2["Level"],-1);
                    player.Ring2["AdditionalDamage"] = 0;
                    player.Ring2["DamageModifier"] = 100;
                    player.Ring2["DefenceModifier"] = 100;
                    player.Ring2["ExperienceModifier"] = 100;
                    player.Ring2["ID"] = -1;
                    player.Ring2["Level"] = 0;
                    player.Ring2["Tier"] = 0;
                    player.Ring2["Health"] = 0;
                    player.Ring2["HealthModifier"] = 100;
                    player.Ring2["SpeedModifier"] = 100;
                    player.Ring2["Accuracy"] = 0;
                    player.Ring2["Evasion"] = 0;
                    player.Ring2["Mana"] = 0;
                    player.Ring2["ManaModifier"] = 100;
                    player.Ring2["ManaRegen"] = 0;
                    player.Ring2["HealthRegen"] = 0;
                    player.Ring2["ManaCost"] = 100;
                    player.Ring2["DamageResistance"] = 0;
                    Ring2Slot.transform.Find("Image").GetComponent<SpriteRenderer>().sprite = Ring2SlotEmpty;
                    Ring2Slot.transform.Find("Level_Text").GetComponent<TextMeshProUGUI>().text = "";
                    Ring2Slot.GetComponent<InventorySlot_Profile>().Equipped = false;
                    break;
                default:
                    break;
        }
        player.UpdateModifiers();
        player.UpdateAllStats();
        player.HealthBar.Reset();
        player.ManaBar.Reset();
        }
    }

    public void Inventory_Add(int ID, int Level, int EnchantId){
        for(int i = 0; i<45; ++i){
            if(player.Inventory[i*3]==-1){
                player.Inventory[i*3] = ID;
                player.Inventory[i*3+1] = Level;
                player.Inventory[i*3+2] = EnchantId;
                Inventory_ReloadAll();
                return;
            }
        }
    }

    public void Inventory_Reorganise(){
        for(int i = 0; i<44; ++i){
            if(player.Inventory[i*3]==-1){
                if(player.Inventory[i*3+3]==-1) break;
                player.Inventory[i*3] = player.Inventory[i*3+3];
                player.Inventory[i*3+3] = -1;
                player.Inventory[i*3+1] = player.Inventory[i*3+4];
                player.Inventory[i*3+4] = -1;
                player.Inventory[i*3+2] = player.Inventory[i*3+5];
                player.Inventory[i*3+5] = -1;
            }
        }
        Inventory_ReloadAll();
    }

    public void Inventory_ReloadAll(){
        for(int i = 0; i<45; ++i) ItemSlots[i].GetComponent<InventorySlot_Items>().SlotInformation_Update();
    }

    public void Inventory_Remove(int SlotID){
        player.Inventory[SlotID] = null;
        Inventory_Reorganise();
    }
    
    public void ButtonsActivate(string key){
        if(key == "Item"){
        Use.SetActive(false);
        if(game.Container["ID"]!=3){
            if(player.Inventory[InvokeID*3+1]>=game.Container["Tier"]*5)UpgradeButton.SetActive(false);
            else {UpgradeButton.SetActive(true);
            UpgradeButton.transform.Find("text").GetComponent<TextMeshProUGUI>().text = Language_Changer.Instance.GetText("Upgrade") + "\n" + Convert.ToInt32(game.Container["Price"]*(game.Container["UpgradeModifier"]/100f+1));
            if(Convert.ToInt32(game.Container["Price"]*(game.Container["UpgradeModifier"]/100f+1))<=player.Money[game.Container["PriceModifier"]]+player.Money[game.Container["PriceModifier"]+1]*1000 || player.Money[0]>game.Container["PriceModifier"]+1) UpgradeButton.GetComponent<Button>().interactable = true;
            else UpgradeButton.GetComponent<Button>().interactable = false;
            }
            Sell.transform.Find("text").GetComponent<TextMeshProUGUI>().text = Language_Changer.Instance.GetText("Sell") + "\n" + game.Container["Price"]/3 + player.TextFormat(game.Container["PriceModifier"]);
        }
        else UpgradeButton.SetActive(false);
        Sell.SetActive(true);
        if(game.Container["ID"]==3)Sell.transform.Find("text").GetComponent<TextMeshProUGUI>().text = Language_Changer.Instance.GetText("Sell") + "\n" + game.Container["Price"];
        Equip.SetActive(true);
        return;
        }
        if(key == "Potion"){
            if(player.Inventory_Consumables[Potion]>0) Use.SetActive(true);
            else Use.SetActive(false);
            Sell.SetActive(false);
            Equip.SetActive(false);
            UpgradeButton.SetActive(false);
        }
    }

    public void Upgrade(bool Equipped){
        player.MoneyManager("Remove", Convert.ToInt32(game.Container["Price"]*(game.Container["UpgradeModifier"]/100f+1)), game.Container["PriceModifier"]);
        game.Upgrade(game.Container["Level"], game.Container["Level"]+1);
        if(!Equipped){
            ++player.Inventory[InvokeID*3+1];
            Inventory_ReloadAll();
            ItemSlots[InvokeID].GetComponent<InventorySlot_Items>().OnClick();
        }
    }

    public void EquippedUpgrade(string Slot){
        Item CurrentSlot = GetProfileSlot(Slot);
        CurrentSlot.Upgrade();
    }

    public void HideSprites(string Type = ""){
        for(int i = 0; i<45; ++i){
            if(InvokeID%5<3){
                if(i%5>=3) ItemSlots[i].transform.Find("Image").gameObject.SetActive(false);
            }
            else if(i%5<2) ItemSlots[i].transform.Find("Image").gameObject.SetActive(false);
        }
    }

    public void HideSprites2(){
        for(int i = 0; i<45; ++i){
            if((i%15>=6 && i%15<=8)||(i%15>=11 && i%15<=13)) ItemSlots[i].transform.Find("Image").gameObject.SetActive(false);
        }
    }

    public void ShowSprites(){
        for(int i = 0; i<45; ++i)ItemSlots[i].transform.Find("Image").gameObject.SetActive(true);
    }

    public void GetDescription(string Slot){
        InventorySlot = Slot;
        UpgradeButtonProfile.SetActive(true);
        Item CurrentSlot = GetProfileSlot(Slot);      
        if(CurrentSlot.Level>=CurrentSlot.Tier*5) UpgradeButtonProfile.SetActive(false);

        UpgradeButtonProfile.transform.Find("text").GetComponent<TextMeshProUGUI>().text = Language_Changer.Instance.GetText("Upgrade") + "\n" + CurrentSlot.GetUpgradePrice();
        if(CurrentSlot.CanUpgrade()) UpgradeButtonProfile.GetComponent<Button>().interactable = true;
        else UpgradeButtonProfile.GetComponent<Button>().interactable = false;
        TitleProfile.text = Language_Changer.Instance.GetText(CurrentSlot.Name, "Items");
        DescriptionProfile.text = CurrentSlot.GetDescription();
        player.Inventory[SlotId].GetComponent<Item>().GetStats(ref DescriptionStatsProfile.text, ref DescriptionStatsProfile2.text, true);
    }

    public Item GetProfileSlot(string Slot){
        switch(Slot){
            case "Hat":
                return player.Hat.GetComponent<Item>();
            case "Chestplate":
                return player.Chestplate.GetComponent<Item>();
            case "Boots":
                return player.Boots.GetComponent<Item>();
            case "LeftHand":
                return player.LeftHand.GetComponent<Item>();
            case "RightHand":
                return player.RightHand.GetComponent<Item>();
            case "Trinket1":
                return player.Trinket1.GetComponent<Item>();
            case "Trinket2":
                return player.Trinket2.GetComponent<Item>();
        }
    }

    public void UnequipButton_Use(){
        Item_Unequip(InventorySlot);
    }

    public void UpgradeButton_Use(){
        EquippedUpgrade(InventorySlot);
        GetDescription(InventorySlot);
    }
}
