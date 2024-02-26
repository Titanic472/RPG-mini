using System.IO;
using UnityEngine;

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
        Save.LoadPlayer();
        Save.LoadActiveSkills();
        Save.Player.ManaOverdrain.Check();
        Game.GetItemById(Data.intPlayerItems[0], Data.intPlayerItems[1]);
        InventoryManager.Item_Equip("Head", false);
        Game.GetItemById(Data.intPlayerItems[2], Data.intPlayerItems[3]);
        InventoryManager.Item_Equip("Chest", false);
        Game.GetItemById(Data.intPlayerItems[4], Data.intPlayerItems[5]);
        InventoryManager.Item_Equip("Legs", false);
        Game.GetItemById(Data.intPlayerItems[6], Data.intPlayerItems[7]);
        Game.Container["EnchantId"] = Data.intPlayerItems[8];
        InventoryManager.Item_Equip("RightHand", false);
        Game.GetItemById(Data.intPlayerItems[9], Data.intPlayerItems[10]);
        Game.Container["EnchantId"] = Data.intPlayerItems[11];
        InventoryManager.Item_Equip("LeftHand", false);
        Game.GetItemById(Data.intPlayerItems[12], Data.intPlayerItems[13]);
        InventoryManager.Item_Equip("Ring1", false);
        Game.GetItemById(Data.intPlayerItems[14], Data.intPlayerItems[15]);
        InventoryManager.Item_Equip("Ring2", false);
        Save.Player.UpdateStats();
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