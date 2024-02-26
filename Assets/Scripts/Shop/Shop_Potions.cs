using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class Shop_Potions : MonoBehaviour
{
    public Player player;
    public int Price, PriceModifier = 1;
    public string Name;

    /*public void SlotInformation_Update(){
        transform.Find("Level_Text").GetComponent<TextMeshProUGUI>().text = player.Inventory_Consumables[Name] + "";
    }*/

    public void OnClick(){
        if(player.Money[PriceModifier]>=Price || player.Money[0]>PriceModifier){
            GetComponent<F_Text_Creator>().CreateText_Yellow("+1");
            player.MoneyManager("Remove", Price, PriceModifier);
            ++player.Inventory_Consumables[Name];
        }
    }
}
