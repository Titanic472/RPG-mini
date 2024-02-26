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
                Player.Instance.Inventory_Consumables[Name] += Amount;
                break;
            case "Item":
                if(Player.Instance.Inventory_Items[87]==-1){
                    Fight.Instance.InventoryManager.Inventory_Add(ID, 1, -1);
                }
                break;
            default:
                break;
        }
        Destroy(transform.gameObject);
    }
}
