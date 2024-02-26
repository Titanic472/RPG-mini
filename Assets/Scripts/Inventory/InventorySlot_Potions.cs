using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class InventorySlot_Potions : MonoBehaviour
{
    public InventoryManager InventoryManager;
    public Game game;
    public int ID;
    public string Name;
    public GameObject self;

    void Awake(){//string.Format("{}");
        InventoryManager.PotionSlots[ID] = self;
    }

    public void SlotInformation_Update(){
        transform.Find("Level_Text").GetComponent<TextMeshProUGUI>().text = Player.Instance.Inventory_Consumables[Name] + "";
    }

    public void OnClick(){
        InventoryManager.Potion = Name;
        InventoryManager.InvokeID = ID;
        InventoryManager.ButtonsActivate("Potion");
        InventoryManager.Title.text = Language_Changer.Instance.GetText(Name);
        InventoryManager.Description.text = Language_Changer.Instance.GetText(Name + "_Description");
        InventoryManager.DescriptionStats.text = "";
        InventoryManager.DescriptionStats2.text = "";
        if(ID%5<3)InventoryManager.InformationBackground.transform.position = new Vector3(0f, 1.4f, 89);
        else InventoryManager.InformationBackground.transform.position = new Vector3(-8f, 1.4f, 89);
        InventoryManager.InformationBackground.SetActive(true);
    }
}
