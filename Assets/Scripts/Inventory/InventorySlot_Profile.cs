using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class InventorySlot_Profile : MonoBehaviour
{
    public string Slot;
    public InventoryManager InventoryManager;
    public GameObject InformationBackground, InformationWindow;
    public bool Equipped;

    public void OnClick(){
        if(!Equipped) return;
        InventoryManager.GetDescription(Slot);
        InformationBackground.SetActive(false);
        InformationWindow.SetActive(true);
    }
}
