using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public string Type, Name;
    public int ID, Amount;

    public void OnCollide(){
        switch(Type){
            case "Potion":
                if(Player.Instance.Inventory[44]==null || Fight.Instance.InventoryManager.SearchForItem(ID)!=-1){
                    Fight.Instance.InventoryManager.Inventory_Add(ID, Amount, -1);
                }
                break;
            case "Item":
                if(Player.Instance.Inventory[44]==null){
                    Fight.Instance.InventoryManager.Inventory_Add(ID, 1, -1);
                }
                break;
            default:
                break;
        }
        Destroy(transform.gameObject);
    }
}
