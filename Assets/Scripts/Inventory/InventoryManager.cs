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
    public Sprite Empty;
    public GameObject HatSlotEmpty, ChestplateSlotEmpty, BootsSlotEmpty, LeftHandSlotEmpty, RightHandSlotEmpty, Trinket1SlotEmpty, Trinket2SlotEmpty, InformationBackground;
    public int InvokeID;
    public TextMeshProUGUI Title, Description, DescriptionStats, DescriptionStats2, TitleProfile, DescriptionProfile, DescriptionStatsProfile, DescriptionStatsProfile2;
    public GameObject UpgradeButton, UpgradeButtonProfile, UnequipButton, Sell, Equip, Use, Choose, HatSlot, ChestplateSlot, BootsSlot, LeftHandSlot, RightHandSlot, Trinket1Slot, Trinket2Slot;
    public string Potion, ChooseType, InventorySlot; 

    public void Item_Sell(){
        player.MoneyAdd(player.Inventory[InvokeID].GetComponent<Item>().Price);
        Inventory_Remove(InvokeID);
        InformationBackground.SetActive(false);
        ShowSprites();
    }

    public void EquipButton(){
        Item CurrentSlotScript = player.Inventory[InvokeID].GetComponent<Item>();
        switch(CurrentSlotScript.Type){
            case "Hat":
                Item_Equip("Hat");
                break;
            case "Chestplate":
                Item_Equip("Chestplate");
                break;
            case "Boots":
                Item_Equip("Boots");
                break;
            case "Shield":
                Item_Equip("LeftHand");
                break;
            case "Weapon":
                if(CurrentSlotScript.Is2Handed){
                    Item_Equip("RightHand");
                    break;    
                }
                ChooseType = "Weapon";
                Choose.transform.Find("Image1").GetComponent<SpriteRenderer>().sprite = player.RightHand.GetComponent<SpriteRenderer>().sprite;
                Choose.transform.Find("Image2").GetComponent<SpriteRenderer>().sprite = player.LeftHand.GetComponent<SpriteRenderer>().sprite;
                InformationBackground.SetActive(false);
                ShowSprites();
                HideSprites2();
                Choose.SetActive(true);
                break;
            case "Trinket":
                ChooseType = "Trinket";
                Choose.transform.Find("Image1").GetComponent<SpriteRenderer>().sprite = player.Trinket1.GetComponent<SpriteRenderer>().sprite;
                Choose.transform.Find("Image2").GetComponent<SpriteRenderer>().sprite = player.Trinket2.GetComponent<SpriteRenderer>().sprite;
                InformationBackground.SetActive(false);
                ShowSprites();
                HideSprites2();
                Choose.SetActive(true);
                break;
        }
    }

    public void ChooseSlot(bool SecondSlot){
        if(ChooseType == "Weapon"){
            if(SecondSlot) Item_Equip("LeftHand");
            else Item_Equip("RightHand");
        }
        else{
            if(SecondSlot) Item_Equip("Trinket2");
            else Item_Equip("Trinket1");
        }
        Choose.SetActive(false);
        ShowSprites();
    }

    public void Item_Equip(string Slot){
        if(player.Inventory[InvokeID].GetComponent<Item>().Is2Handed == true && player.Inventory[44]!=null || player.Inventory[InvokeID].GetComponent<Item>().Id==-1) return;

        switch(Slot){
            case "Hat":
                if(player.Hat.GetComponent<Item>().Id != -1) player.Inventory[GetFreeSlot()] = player.Hat;
                else Destroy(player.Hat);
                player.Hat = player.Inventory[InvokeID];
                player.Hat.transform.SetParent(HatSlot.transform);
                player.Hat.transform.position = HatSlot.transform.position;
                HatSlot.transform.Find("Level_Text").GetComponent<TextMeshProUGUI>().text = Language_Changer.Instance.GetText("Lvl") + ": " + player.Hat.GetComponent<Item>().Level;
                HatSlot.GetComponent<InventorySlot_Profile>().Equipped = true;
                break;
            case "Chestplate":
                if(player.Chestplate.GetComponent<Item>().Id != -1) player.Inventory[GetFreeSlot()] = player.Chestplate;
                else Destroy(player.Chestplate);
                player.Chestplate = player.Inventory[InvokeID];
                player.Chestplate.transform.SetParent(ChestplateSlot.transform);
                player.Chestplate.transform.position = ChestplateSlot.transform.position;
                ChestplateSlot.transform.Find("Level_Text").GetComponent<TextMeshProUGUI>().text = Language_Changer.Instance.GetText("Lvl") + ": " + player.Chestplate.GetComponent<Item>().Level;
                ChestplateSlot.GetComponent<InventorySlot_Profile>().Equipped = true;
                break;
            case "Boots":
                if(player.Boots.GetComponent<Item>().Id != -1) player.Inventory[GetFreeSlot()] = player.Boots;
                else Destroy(player.Boots);
                player.Boots = player.Inventory[InvokeID];
                player.Boots.transform.SetParent(BootsSlot.transform);
                player.Boots.transform.position = BootsSlot.transform.position;
                BootsSlot.transform.Find("Level_Text").GetComponent<TextMeshProUGUI>().text = Language_Changer.Instance.GetText("Lvl") + ": " + player.Boots.GetComponent<Item>().Level;
                BootsSlot.GetComponent<InventorySlot_Profile>().Equipped = true;
                break;
            case "LeftHand":
                if(player.LeftHand.GetComponent<Item>().Id != -1) player.Inventory[GetFreeSlot()] = player.LeftHand;
                else Destroy(player.LeftHand);
                player.LeftHand = player.Inventory[InvokeID];
                player.LeftHand.transform.SetParent(LeftHandSlot.transform);
                player.LeftHand.transform.position = LeftHandSlot.transform.position;
                LeftHandSlot.transform.Find("Level_Text").GetComponent<TextMeshProUGUI>().text = Language_Changer.Instance.GetText("Lvl") + ": " + player.LeftHand.GetComponent<Item>().Level;
                LeftHandSlot.GetComponent<InventorySlot_Profile>().Equipped = true;
                break;
            case "RightHand":
                if(player.RightHand.GetComponent<Item>().Id != -1) player.Inventory[GetFreeSlot()] = player.RightHand;
                else Destroy(player.RightHand);
                player.RightHand = player.Inventory[InvokeID];
                player.RightHand.transform.SetParent(RightHandSlot.transform);
                player.RightHand.transform.position = RightHandSlot.transform.position;
                RightHandSlot.transform.Find("Level_Text").GetComponent<TextMeshProUGUI>().text = Language_Changer.Instance.GetText("Lvl") + ": " + player.RightHand.GetComponent<Item>().Level;
                RightHandSlot.GetComponent<InventorySlot_Profile>().Equipped = true;
                if(player.RightHand.GetComponent<Item>().Is2Handed){
                    LeftHandSlot.SetActive(false);
                    Inventory_Reorganise();
                    Item_Unequip("LeftHand");
                }
                break;
            case "Trinket1":
                if(player.Trinket1.GetComponent<Item>().Id != -1) player.Inventory[GetFreeSlot()] = player.Trinket1;
                else Destroy(player.Trinket1);
                player.Trinket1 = player.Inventory[InvokeID];
                player.Trinket1.transform.SetParent(Trinket1Slot.transform);
                player.Trinket1.transform.position = Trinket1Slot.transform.position;
                Trinket1Slot.transform.Find("Level_Text").GetComponent<TextMeshProUGUI>().text = Language_Changer.Instance.GetText("Lvl") + ": " + player.Trinket1.GetComponent<Item>().Level;
                Trinket1Slot.GetComponent<InventorySlot_Profile>().Equipped = true;
                break;
            case "Trinket2":
                if(player.Trinket2.GetComponent<Item>().Id != -1) player.Inventory[GetFreeSlot()] = player.Trinket2;
                else Destroy(player.Trinket2);
                player.Trinket2 = player.Inventory[InvokeID];
                player.Trinket2.transform.SetParent(Trinket2Slot.transform);
                player.Trinket2.transform.position = Trinket2Slot.transform.position;
                Trinket2Slot.transform.Find("Level_Text").GetComponent<TextMeshProUGUI>().text = Language_Changer.Instance.GetText("Lvl") + ": " + player.Trinket2.GetComponent<Item>().Level;
                Trinket2Slot.GetComponent<InventorySlot_Profile>().Equipped = true;
                break;
            default:
                break;
        }
        Inventory_Reorganise();
        InformationBackground.SetActive(false);
        ShowSprites();
        player.UpdateAllStats();
        player.HealthBar.Reset();
        player.ManaBar.Reset();
    }

    public void Item_Unequip(string Slot){
        if(player.Inventory[44]==null){
            switch(Slot){
                case "Hat":
                    player.Inventory[GetFreeSlot()] = player.Hat;
                    player.Hat = Instantiate(HatSlotEmpty, HatSlot.transform);
                    player.Hat.transform.position = HatSlot.transform.position;
                    HatSlot.transform.Find("Level_Text").GetComponent<TextMeshProUGUI>().text = "";
                    HatSlot.GetComponent<InventorySlot_Profile>().Equipped = false;
                    break;
                case "Chestplate":
                    player.Inventory[GetFreeSlot()] = player.Chestplate;
                    player.Chestplate = Instantiate(ChestplateSlotEmpty, ChestplateSlot.transform);
                    player.Chestplate.transform.position = ChestplateSlot.transform.position;
                    ChestplateSlot.transform.Find("Level_Text").GetComponent<TextMeshProUGUI>().text = "";
                    ChestplateSlot.GetComponent<InventorySlot_Profile>().Equipped = false;
                    break;
                case "Boots":
                    player.Inventory[GetFreeSlot()] = player.Boots;
                    player.Boots = Instantiate(BootsSlotEmpty, BootsSlot.transform);
                    player.Boots.transform.position = BootsSlot.transform.position;
                    BootsSlot.transform.Find("Level_Text").GetComponent<TextMeshProUGUI>().text = "";
                    BootsSlot.GetComponent<InventorySlot_Profile>().Equipped = false;
                    break;
                case "LeftHand":
                    player.Inventory[GetFreeSlot()] = player.LeftHand;
                    player.LeftHand = Instantiate(LeftHandSlotEmpty, LeftHandSlot.transform);
                    player.LeftHand.transform.position = LeftHandSlot.transform.position;
                    LeftHandSlot.transform.Find("Level_Text").GetComponent<TextMeshProUGUI>().text = "";
                    LeftHandSlot.GetComponent<InventorySlot_Profile>().Equipped = false;
                    break;
                case "RightHand":
                    player.Inventory[GetFreeSlot()] = player.RightHand;
                    player.RightHand = Instantiate(RightHandSlotEmpty, RightHandSlot.transform);
                    player.RightHand.transform.position = RightHandSlot.transform.position;
                    RightHandSlot.transform.Find("Level_Text").GetComponent<TextMeshProUGUI>().text = "";
                    RightHandSlot.GetComponent<InventorySlot_Profile>().Equipped = false;
                    LeftHandSlot.SetActive(true);
                    break;
                case "Trinket1":
                    player.Inventory[GetFreeSlot()] = player.Trinket1;
                    player.Trinket1 = Instantiate(Trinket1SlotEmpty, Trinket1Slot.transform);
                    player.Trinket1.transform.position = Trinket1Slot.transform.position;
                    Trinket1Slot.transform.Find("Level_Text").GetComponent<TextMeshProUGUI>().text = "";
                    Trinket1Slot.GetComponent<InventorySlot_Profile>().Equipped = false;
                    break;
                case "Trinket2":
                    player.Inventory[GetFreeSlot()] = player.Trinket2;
                    player.Trinket2 = Instantiate(Trinket2SlotEmpty, Trinket2Slot.transform);
                    player.Trinket2.transform.position = Trinket2Slot.transform.position;
                    Trinket2Slot.transform.Find("Level_Text").GetComponent<TextMeshProUGUI>().text = "";
                    Trinket2Slot.GetComponent<InventorySlot_Profile>().Equipped = false;
                    break;
                default:
                    break;
        }
        Inventory_Reorganise();
        player.UpdateAllStats();
        player.HealthBar.Reset();
        player.ManaBar.Reset();
        }
    }

    public void Inventory_Add(int Id, int Level, int EnchantmentId, bool AddFightSprite = false){
        bool IsConsumable = false;
        if(game.Items[Id].GetComponent<Item>().Type == "Potion" || game.Items[Id].GetComponent<Item>().Type == "Consumable") IsConsumable = true;
        if(IsConsumable){
            int FoundSlot = SearchForItem(Id);
            if(FoundSlot != -1) {
                player.Inventory[FoundSlot].GetComponent<Item>().Amount += Level;
                return;
            }
        }
        int Slot = GetFreeSlot();
        if(Slot!=-1){
            player.Inventory[Slot] = Instantiate(game.Items[Id], ItemSlots[Slot].transform);
            if(IsConsumable) player.Inventory[Slot].GetComponent<Item>().Amount = Level;
            else player.Inventory[Slot].GetComponent<Item>().LevelSet(Level);
            player.Inventory[Slot].GetComponent<Item>().EnchantmentId = EnchantmentId;
            if(AddFightSprite) Fight.Instance.EndBattleWindow.transform.Find("LootItem").GetComponent<SpriteRenderer>().sprite = player.Inventory[Slot].GetComponent<Image>().sprite;
            Inventory_ReloadAll();
            return;
        }
    }

    public int SearchForItem(int Id){
        for(int i = 0; i<45; ++i){
            if(player.Inventory[i] == null) return -1;
            else if(player.Inventory[i].GetComponent<Item>().Id == Id) return i;
        }
        return -1;
    }

    public int GetFreeSlot(){
        for(int i = 0; i<45; ++i) if(player.Inventory[i]==null) return i;
        return -1;
    }

    public void Inventory_Reorganise(){
        for(int i = 0; i<44; ++i){
            if(player.Inventory[i] == null){
                if(player.Inventory[i+1] == null) break;
                player.Inventory[i] = player.Inventory[i+1];
                player.Inventory[i+1] = null;
            }
        }
        Inventory_ReloadAll();
    }

    public void Inventory_ReloadAll(){
        for(int i = 0; i<45; ++i) ItemSlots[i].GetComponent<InventorySlot_Items>().SlotInformation_Update();
    }

    public void Inventory_Remove(int SlotID){
        Destroy(player.Inventory[SlotID]);
        player.Inventory[SlotID] = null;
        Inventory_Reorganise();
    }
    
    public void ButtonsActivate(Item CurrentSlot){
        if(CurrentSlot.Type!="Potion" &&  CurrentSlot.Type!="Consumable"){
            Use.SetActive(false);
            if(CurrentSlot.Id!=3){
                if(CurrentSlot.Level>=CurrentSlot.Tier*5)UpgradeButton.SetActive(false);
                else {
                    UpgradeButton.SetActive(true);
                    UpgradeButton.transform.Find("text").GetComponent<TextMeshProUGUI>().text = Language_Changer.Instance.GetText("Upgrade") + "\n" + CurrentSlot.GetUpgradePrice();
                if(CurrentSlot.CanUpgrade()) UpgradeButton.GetComponent<Button>().interactable = true;
                else UpgradeButton.GetComponent<Button>().interactable = false;
                }
            }
            else UpgradeButton.SetActive(false);
            Sell.SetActive(true);
            Sell.transform.Find("text").GetComponent<TextMeshProUGUI>().text = Language_Changer.Instance.GetText("Sell") + "\n" + CurrentSlot.GetSellPrice();
            Equip.SetActive(true);
        }
        else{
            if(CurrentSlot.Type=="Potion") Use.SetActive(true);
            else Use.SetActive(false);
            Sell.SetActive(false);
            Equip.SetActive(false);
            UpgradeButton.SetActive(false);
        }
    }

    public void Upgrade(bool Equipped){
        if(!Equipped){
            player.Inventory[InvokeID].GetComponent<Item>().Upgrade();
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
                if(i%5>=3) if(player.Inventory[i]!=null) player.Inventory[i].SetActive(false);
            }
            else if(i%5<2) if(player.Inventory[i]!=null) player.Inventory[i].SetActive(false);
        }
    }

    public void HideSprites2(){
        for(int i = 0; i<45; ++i){
            if((i%15>=6 && i%15<=8)||(i%15>=11 && i%15<=13)) if(player.Inventory[i]!=null) player.Inventory[i].SetActive(false);
        }
    }

    public void ShowSprites(){
        for(int i = 0; i<45; ++i)if(player.Inventory[i]!=null)player.Inventory[i].SetActive(true);
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
        string SlotText1 = "", SlotText2 = "";
        CurrentSlot.GetStats(ref SlotText1, ref SlotText2, true);
        DescriptionStats.text = SlotText1;
        DescriptionStats2.text = SlotText2;
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
            default:
                Debug.Log("Errored with: " + Slot);
                return null;
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
