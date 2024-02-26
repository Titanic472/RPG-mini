using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class Shop_Items : MonoBehaviour
{
    public Player player;
    public InventoryManager InventoryManager;
    public int Price, PriceModifier = 1, ID;

    public void OnClick(){
        if((player.Money[PriceModifier]>=Price || player.Money[0]>PriceModifier) && player.Inventory_Items[87]==-1){
            GetComponent<F_Text_Creator>().CreateText_Yellow("+1");
            player.MoneyManager("Remove", Price, PriceModifier);
            InventoryManager.Inventory_Add(ID, 1, -1);
        }
    }
}
