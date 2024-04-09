using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class Shop_Items : MonoBehaviour
{
    public Player player;
    public InventoryManager InventoryManager;
    public GameObject SelledItem;

    void Awake(){
        Item CurrentSlotScript = SelledItem.GetComponent<Item>();
        gameObject.transform.Find("Level_Text").GetComponent<Text>().text = CurrentSlotScript.GetSellPrice();
        CurrentSlotScript.UpgradePrice = CurrentSlotScript.Price;
    }
    public void OnClick(){
        if(SelledItem.GetComponent<Item>().CanUpgrade() && player.Inventory[44] == null){
            GetComponent<F_Text_Creator>().CreateText_Yellow("+1");
            
            player.MoneyRemove(SelledItem.GetComponent<Item>().Price);
            InventoryManager.Inventory_Add(SelledItem.GetComponent<Item>().Id, 1, -1);
        }
    }
}
