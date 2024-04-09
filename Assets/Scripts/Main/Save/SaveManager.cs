using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class SaveManager : MonoBehaviour
{
    public Data Data = new Data();
    public Save Save;
    public InventoryManager InventoryManager;
    public Game Game;
    public static SaveManager Instance;

    void Awake(){
        Instance = this;
    }

    public void SaveData(){
        string filePath = Application.persistentDataPath + "/save.json";
        string jsonData = JsonUtility.ToJson(Data);
        File.WriteAllText(filePath, jsonData);
    }
    public void LoadData(){
        string filePath = Application.persistentDataPath + "/save.json";
        if (File.Exists(filePath)){
            string jsonData = File.ReadAllText(filePath);
            Data = JsonUtility.FromJson<Data>(jsonData);
        }
        else{
            Debug.LogWarning("File not found: " + filePath);
        }
    }

    public void LoadAll(){
        LoadData();
        Save.Data = Data;
        Save.LoadGame();
        {
            InventoryManager.InvokeID = 0;
            int i = 0;
            Save.Player.Inventory[0] = Instantiate(Game.Items[Data.intPlayerItems[i]]);
            Save.Player.Inventory[0].GetComponent<Item>().Load(Data.intPlayerItems[i+1], Data.intPlayerItems[i+2]);
            InventoryManager.Item_Equip("Hat");
            i+=3;
            Save.Player.Inventory[0] = Instantiate(Game.Items[Data.intPlayerItems[i]]);
            Save.Player.Inventory[0].GetComponent<Item>().Load(Data.intPlayerItems[i+1], Data.intPlayerItems[i+2]);
            InventoryManager.Item_Equip("Chestplate");
            i+=3;
            Save.Player.Inventory[0] = Instantiate(Game.Items[Data.intPlayerItems[i]]);
            Save.Player.Inventory[0].GetComponent<Item>().Load(Data.intPlayerItems[i+1], Data.intPlayerItems[i+2]);
            InventoryManager.Item_Equip("Boots");
            i+=3;
            Save.Player.Inventory[0] = Instantiate(Game.Items[Data.intPlayerItems[i]]);
            Save.Player.Inventory[0].GetComponent<Item>().Load(Data.intPlayerItems[i+1], Data.intPlayerItems[i+2]);
            InventoryManager.Item_Equip("RightHand");
            i+=3;
            Save.Player.Inventory[0] = Instantiate(Game.Items[Data.intPlayerItems[i]]);
            Save.Player.Inventory[0].GetComponent<Item>().Load(Data.intPlayerItems[i+1], Data.intPlayerItems[i+2]);
            InventoryManager.Item_Equip("LeftHand");
            i+=3;
            Save.Player.Inventory[0] = Instantiate(Game.Items[Data.intPlayerItems[i]]);
            Save.Player.Inventory[0].GetComponent<Item>().Load(Data.intPlayerItems[i+1], Data.intPlayerItems[i+2]);
            InventoryManager.Item_Equip("Trinket1");
            i+=3;
            Save.Player.Inventory[0] = Instantiate(Game.Items[Data.intPlayerItems[i]]);
            Save.Player.Inventory[0].GetComponent<Item>().Load(Data.intPlayerItems[i+1], Data.intPlayerItems[i+2]);
            InventoryManager.Item_Equip("Trinket2");
        }
        Save.LoadPlayer();
        Save.LoadActiveSkills();
        Save.Player.ManaOverdrain.Check();
        Save.Player.UpdateAllStats();
        StartCoroutine(Save.Player.ExperienceBar.XP_update(false));
        StartCoroutine(Save.Player.HealthBar.HP_update());
        StartCoroutine(Save.Player.ManaBar.Mana_update());
        Save.Player.MoneyManager("Update");
        for(int i = 5; i<Save.Player.MaxSpeedEnergy;++i)Save.Player.speedEnergy.AddMoreSlots();
        Save.Skills.SkillPointsCount_Update();
        Save.LoadSkillTree();
        Save.Skills.Skilltree_ActiveSkillsSlots();
        Save.ActiveSkillsManager.SkillsUnlockCheck();
        Save.LoadMap();
        LocationManager.Instance.ChangeLocation();
    }

    public void SaveAll(){
        Save.Data = Data;
        Save.SaveGame();
        Save.SavePlayer();
        Save.SaveActiveSkills();
        Save.SaveMap();
        Save.SaveSkillTree();
        SaveData();
    }
}