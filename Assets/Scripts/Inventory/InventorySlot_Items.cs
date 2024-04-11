using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class InventorySlot_Items : MonoBehaviour
{
    public InventoryManager InventoryManager;
    public Game game;
    public int ID;
    public GameObject self;
    void Awake(){//string.Format("{}");
        InventoryManager.ItemSlots[ID] = self;
    }

    public void SlotInformation_Update(){
        if(Player.Instance.Inventory[ID]!=null){
            Item CurrentSlotScript = Player.Instance.Inventory[ID].GetComponent<Item>();
            if(CurrentSlotScript.Type!="Potion" &&  CurrentSlotScript.Type!="Consumable") transform.Find("Level_Text").GetComponent<TextMeshProUGUI>().text = Language_Changer.Instance.GetText("Lvl") + ": " + CurrentSlotScript.Level;
            else transform.Find("Level_Text").GetComponent<TextMeshProUGUI>().text = CurrentSlotScript.Amount + "";
        }
        else transform.Find("Level_Text").GetComponent<TextMeshProUGUI>().text = "";
        if(Player.Instance.Inventory[ID] != null){
            Player.Instance.Inventory[ID].transform.SetParent(transform);
            Player.Instance.Inventory[ID].transform.position = transform.position;
        }
    }

    public void OnClick(){
        if(Player.Instance.Inventory[ID] == null) return;
        Item CurrentSlotScript = Player.Instance.Inventory[ID].GetComponent<Item>();
        InventoryManager.Choose.SetActive(false);
        InventoryManager.InvokeID = ID;
        InventoryManager.Title.text = Language_Changer.Instance.GetText(CurrentSlotScript.Name, "Items");
        InventoryManager.Description.text = CurrentSlotScript.GetDescription();
        string SlotText1 = "", SlotText2 = "";
        CurrentSlotScript.GetStats(ref SlotText1, ref SlotText2, true);
        InventoryManager.DescriptionStats.text = SlotText1;
        InventoryManager.DescriptionStats2.text = SlotText2;
        if(ID%5<3)InventoryManager.InformationBackground.transform.position = new Vector3(0f, 1.4f, 89);
        else InventoryManager.InformationBackground.transform.position = new Vector3(-8f, 1.4f, 89);
        InventoryManager.ButtonsActivate(CurrentSlotScript);
        InventoryManager.ShowSprites();
        InventoryManager.HideSprites();
        InventoryManager.InformationBackground.SetActive(true);
    }
}
