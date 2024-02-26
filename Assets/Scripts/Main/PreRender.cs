using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class PreRender : MonoBehaviour
{
    public GameObject Black, SpecialAttacks_SelectWindow, Skills, Inventory, Shop, Fight, LoadButton;
    
    void Start()
    {
        Black.SetActive(true);
        SpecialAttacks_SelectWindow.SetActive(true);
        SpecialAttacks_SelectWindow.SetActive(false);
        Skills.SetActive(true);
        Skills.SetActive(false);
        Inventory.SetActive(true);
        Inventory.transform.Find("Page_1").gameObject.SetActive(true);
        Inventory.transform.Find("Page_2").gameObject.SetActive(true);
        Inventory.transform.Find("Page_3").gameObject.SetActive(true);
        Inventory.transform.Find("Page_2").gameObject.SetActive(false);
        Inventory.transform.Find("Page_3").gameObject.SetActive(false);
        Inventory.SetActive(false);
        Shop.SetActive(true);
        Shop.SetActive(false);
        Fight.SetActive(true);
        Fight.SetActive(false);
        Black.SetActive(false);
        if(File.Exists(Application.persistentDataPath + "/save.json")) LoadButton.GetComponent<Button>().interactable = true;
        else LoadButton.GetComponent<Button>().interactable = false;
    }

}
