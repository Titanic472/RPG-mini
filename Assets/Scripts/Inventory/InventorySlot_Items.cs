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

    public void SlotInformation_Update()
    {
     if(Player.Instance.Inventory_Items[ID*3]>=0) transform.Find("Level_Text").GetComponent<TextMeshProUGUI>().text = Language_Changer.Instance.GetText("Lvl") + ": " + Player.Instance.Inventory_Items[ID*3+1];
     else transform.Find("Level_Text").GetComponent<TextMeshProUGUI>().text = "";
     if(Player.Instance.Inventory_Items[ID*3]==3){
        transform.Find("Image").GetComponent<Animator>().runtimeAnimatorController = InventoryManager.SlimyChestplate;
        transform.Find("Level_Text").GetComponent<TextMeshProUGUI>().text = Language_Changer.Instance.GetText("Lvl") + ": " + game.SlimyArmor.Chestplate["Level"];
     }
     else transform.Find("Image").GetComponent<Animator>().runtimeAnimatorController = null;
     if(Player.Instance.Inventory_Items[ID*3]>=0)transform.Find("Image").GetComponent<SpriteRenderer>().sprite = game.Item_Sprites[Player.Instance.Inventory_Items[ID*3]];
     else transform.Find("Image").GetComponent<SpriteRenderer>().sprite = InventoryManager.Empty;
     
    }

    public void OnClick(){
        InventoryManager.Choose.SetActive(false);
        if(Player.Instance.Inventory_Items[ID*3]==-1) return;
        InventoryManager.InvokeID = ID;
        game.GetItemById(Player.Instance.Inventory_Items[ID*3], Player.Instance.Inventory_Items[ID*3+1]);
        game.Container["EnchantId"] = Player.Instance.Inventory_Items[ID*3+2];
        InventoryManager.Title.text = game.ContText["Name"];
        InventoryManager.Description.text = game.ContText["Description"];
        InventoryManager.GetStats();
        if(ID%5<3)InventoryManager.InformationBackground.transform.position = new Vector3(0f, 1.4f, 89);
        else InventoryManager.InformationBackground.transform.position = new Vector3(-8f, 1.4f, 89);
        InventoryManager.ButtonsActivate("Item");
        InventoryManager.ShowSprites();
        InventoryManager.HideSprites();
        InventoryManager.InformationBackground.SetActive(true);
    }
}
