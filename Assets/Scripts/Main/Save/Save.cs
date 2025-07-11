using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Save : MonoBehaviour
{
    public Data Data;
    public Player Player;
    public Skills Skills;
    public ActiveSkillsManager ActiveSkillsManager;
    public Game Game;
    public SkillTreeButton[] skillTreeRootNodes = new SkillTreeButton[4];

    public void SavePlayer()
    {
        //Debug.Log("Save started: Player");
        //int
        for (int i = 0; i < 25; ++i) Data.intPlayerXP[i] = Player.Experience[i];
        for (int i = 25; i < 50; ++i) Data.intPlayerXP[i] = Player.NewLevelXP[i - 25];
        Data.intPlayer[0] = Player.Health;
        Data.intPlayer[1] = Player.MaxHealth;
        Data.intPlayer[2] = Player.HealthRegen;
        Data.intPlayer[3] = Player.Mana;
        Data.intPlayer[4] = Player.MaxMana;
        Data.intPlayer[5] = Player.ManaRegen;
        Data.intPlayer[6] = Player.Level;
        Data.intPlayer[7] = Player.LevelHPBoost;
        Data.intPlayer[8] = Player.BaseDamage;
        Data.intPlayer[9] = Player.SkillPoints;
        Data.intPlayer[10] = Player.MaxAvoidChance;
        Data.intPlayer[11] = Player.MaxCritChance;
        Data.intPlayer[12] = Player.MaxSpeedEnergy;
        Data.intPlayer[13] = Player.Mana;
        Data.intPlayer[14] = Player.Evasion;
        Data.intPlayer[15] = Player.Accuracy;
        Data.intPlayer[16] = Player.BaseMana;
        Data.intPlayer[17] = Player.BaseEvasion;
        Data.intPlayer[18] = Player.BaseAccuracy;
        Data.intPlayer[19] = Player.BaseHealth;
        Data.intPlayer[20] = Player.BaseHealthRegen;
        Data.intPlayer[21] = Player.BaseManaRegen;
        Data.intPlayer[22] = Player.Skills["WeaponSkillChance"];
        // Data.intPlayer[23] = Player.Inventory_Consumables["Healing_Potion"];
        // Data.intPlayer[25] = Player.Inventory_Consumables["Mana_Potion"];
        // Data.intPlayer[26] = Player.Inventory_Consumables["Health_Regeneration_Potion"];
        // Data.intPlayer[27] = Player.Inventory_Consumables["Mana_Regeneration_Potion"];
        // Data.intPlayer[28] = Player.Inventory_Consumables["Ironskin_Potion"];
        for (int i = 29; i < 79; ++i)
        {
            for (int j = 0; j < 10; ++j)
            {
                for (int k = 0; k < 5; ++k) Data.intPlayer[i] = Player.StatusEffects[j, k];
            }
        }
        for (int i = 79; i < 94; ++i) Data.intPlayer[i] = Player.Money[i - 79];
        for (int i = 94; i < 229; i += 3)
        {
            if (Player.Inventory[(i - 94) / 3] != null) Player.Inventory[(i - 94) / 3].GetComponent<Item>().Save(ref Data.intPlayer[i], ref Data.intPlayer[i + 1], ref Data.intPlayer[i + 2]);
            else Data.intPlayer[i] = -1;
        }
        //Overdrain
        Data.intPlayer[229] = Player.ManaOverdrain.MovesLeft;
        Data.boolPlayer = Player.Overdrained;
        //float
        Data.floatPlayer[0] = Player.HealthModifier;
        Data.floatPlayer[1] = Player.ManaModifier;
        Data.floatPlayer[2] = Player.DamageModifier;
        Data.floatPlayer[3] = Player.DefenceModifier;
        Data.floatPlayer[4] = Player.ExperienceModifier;
        Data.floatPlayer[5] = Player.SpeedModifier;
        Data.floatPlayer[6] = Player.BaseHealthModifier;
        Data.floatPlayer[7] = Player.BaseManaModifier;
        Data.floatPlayer[8] = Player.BaseManaCost;
        Data.floatPlayer[9] = Player.ManaCost;
        Data.floatPlayer[10] = Player.BaseAttackSpeed;
        Data.floatPlayer[11] = Player.AttackSpeed;
        Data.floatPlayer[12] = Player.DamageResistance;
        Data.floatPlayer[13] = Player.BaseDamageResistance;
        Data.floatPlayer[14] = Player.BrutalityStreak_AddDamageAll;
        Data.floatPlayer[15] = Player.Parry_ChanceAll;
        //Equipment Items
        {
            int i = 0;
            Player.Hat.GetComponent<Item>().Save(ref Data.intPlayerItems[i], ref Data.intPlayerItems[i + 1], ref Data.intPlayerItems[i + 2]);
            i += 3;
            Player.Chestplate.GetComponent<Item>().Save(ref Data.intPlayerItems[i], ref Data.intPlayerItems[i + 1], ref Data.intPlayerItems[i + 2]);
            i += 3;
            Player.Boots.GetComponent<Item>().Save(ref Data.intPlayerItems[i], ref Data.intPlayerItems[i + 1], ref Data.intPlayerItems[i + 2]);
            i += 3;
            Player.RightHand.GetComponent<Item>().Save(ref Data.intPlayerItems[i], ref Data.intPlayerItems[i + 1], ref Data.intPlayerItems[i + 2]);
            i += 3;
            Player.LeftHand.GetComponent<Item>().Save(ref Data.intPlayerItems[i], ref Data.intPlayerItems[i + 1], ref Data.intPlayerItems[i + 2]);
            i += 3;
            Player.Trinket1.GetComponent<Item>().Save(ref Data.intPlayerItems[i], ref Data.intPlayerItems[i + 1], ref Data.intPlayerItems[i + 2]);
            i += 3;
            Player.Trinket2.GetComponent<Item>().Save(ref Data.intPlayerItems[i], ref Data.intPlayerItems[i + 1], ref Data.intPlayerItems[i + 2]);
        }
        //Debug.Log("Saved: Player");
    }

    public void SaveActiveSkills(){
        //Debug.Log("Save started: Active Skills");
        for(int i = 0; i<9; ++i)Data.ActiveSkills[i] = ActiveSkillsManager.SkillsList[i, 0]; 
        Data.intActiveSkills[0] = ActiveSkillsManager.ActiveSlots[1];
        Data.intActiveSkills[1] = ActiveSkillsManager.ActiveSlots[2];
        Data.intActiveSkills[2] = ActiveSkillsManager.ActiveSlots[3];
        Data.intActiveSkills[3] = ActiveSkillsManager.ActiveSlots[4];
        //Debug.Log("Saved: Active Skills");
    }

    public void SaveGame(){
        //Debug.Log("Save started: Game");
        Data.IsHardcore = Game.IsHardcore;
        Data.intGame[0] = Game.SkilledTreeChance;
        for(int i = 0; i<10; ++i)Data.boolGame[i] = Game.BossesDefeated[i]; 
        //Debug.Log("Saved: Game");
    }

    public void SaveMap(){
        Data.stringMap[0] = LocationManager.Instance.RespawnLocation;
        Data.stringMap[1] = LocationManager.Instance.Location;
        Data.floatMapPositions[0] = LocationManager.Instance.RespawnPosition.x;
        Data.floatMapPositions[1] = LocationManager.Instance.RespawnPosition.y;
        Data.floatMapPositions[2] = LocationManager.Instance.SavePosition.x;
        Data.floatMapPositions[3] = LocationManager.Instance.SavePosition.y;
    }

    public void SaveSkillTree()
    {
        //Debug.Log("Save started: Skill Tree");
        for (int i = 0; i < skillTreeRootNodes.Length; ++i)
        {
            skillTreeRootNodes[i].Save();
        }
        Data.intSkillTree[0] = Skills.AccuracyUpgrades;
        Data.intSkillTree[1] = Skills.EvasionUpgrades; 
        Data.intSkillTree[2] = Skills.SorceryUpgrades;
        Data.intSkillTree[3] = Skills.UniversalUpgrades;
        //Debug.Log("Saved: Skill Tree");
    }

    public void LoadPlayer(){
        //Debug.Log("Load started: Player");
        //int
        for(int i = 0; i<25; ++i)Player.Experience[i] = Data.intPlayerXP[i];
        for(int i = 25; i<50; ++i)Player.NewLevelXP[i-25] = Data.intPlayerXP[i];
        Player.Health = Data.intPlayer[0];
        Player.MaxHealth = Data.intPlayer[1];
        Player.HealthRegen = Data.intPlayer[2];
        Player.Mana = Data.intPlayer[3];
        Player.MaxMana = Data.intPlayer[4];
        Player.ManaRegen = Data.intPlayer[5];
        Player.Level = Data.intPlayer[6];
        Player.LevelHPBoost = Data.intPlayer[7];
        Player.BaseDamage = Data.intPlayer[8];
        Player.SkillPoints = Data.intPlayer[9];
        Player.MaxAvoidChance = Data.intPlayer[10];
        Player.MaxCritChance = Data.intPlayer[11];
        Player.MaxSpeedEnergy = Data.intPlayer[12];
        Player.Mana = Data.intPlayer[13];
        Player.Evasion = Data.intPlayer[14];
        Player.Accuracy = Data.intPlayer[15];
        Player.BaseMana = Data.intPlayer[16];
        Player.BaseEvasion = Data.intPlayer[17];
        Player.BaseAccuracy = Data.intPlayer[18];
        Player.BaseHealth = Data.intPlayer[19];
        Player.BaseHealthRegen = Data.intPlayer[20];
        Player.BaseManaRegen = Data.intPlayer[21];
        Player.Skills["WeaponSkillChance"] = Data.intPlayer[22];
        for(int i = 29; i<79; ++i){
            for(int j = 0; j<10; ++j){
                for(int k = 0; k<5; ++k)Player.StatusEffects[j,k] = Data.intPlayer[i];
            }
        }
        for(int i = 79; i<94; ++i)Player.Money[i-79] = Data.intPlayer[i];
        for(int i = 94; i<229; i+=3) {
            if(Data.intPlayer[i] != -1){
                Player.Inventory[(i-94)/3] = Instantiate(Game.Items[Data.intPlayer[i]]);
                Player.Inventory[(i-94)/3].GetComponent<Item>().Load(Data.intPlayer[i+1], Data.intPlayer[i+2]);
            }
        }
        //Overdrain
        Player.ManaOverdrain.MovesLeft = Data.intPlayer[229];
        Player.Overdrained = Data.boolPlayer;
        //float
        //float
        Player.HealthModifier = Data.floatPlayer[0];
        Player.ManaModifier = Data.floatPlayer[1];
        Player.DamageModifier = Data.floatPlayer[2];
        Player.DefenceModifier = Data.floatPlayer[3];
        Player.ExperienceModifier = Data.floatPlayer[4];
        Player.SpeedModifier = Data.floatPlayer[5];
        Player.BaseHealthModifier = Data.floatPlayer[6];
        Player.BaseManaModifier = Data.floatPlayer[7];
        Player.BaseManaCost = Data.floatPlayer[8];
        Player.ManaCost = Data.floatPlayer[9];
        Player.BaseAttackSpeed = Data.floatPlayer[10];
        Player.AttackSpeed = Data.floatPlayer[11];
        Player.DamageResistance = Data.floatPlayer[12];
        Player.BaseDamageResistance = Data.floatPlayer[13];
        Player.BrutalityStreak_AddDamageAll = Data.floatPlayer[14];
        Player.Parry_ChanceAll = Data.floatPlayer[15];
        //Debug.Log("Loaded: Player");
    }

    public void LoadActiveSkills(){
        //Debug.Log("Load started: Active Skills");
        for(int i = 0; i<9; ++i)ActiveSkillsManager.SkillsList[i, 0] = Data.ActiveSkills[i]; 
        //Debug.Log("Loaded: Active skills");
    }

    public void LoadGame(){
        //Debug.Log("Load started: Game");
        Game.IsHardcore = Data.IsHardcore;
        Game.SkilledTreeChance = Data.intGame[0];
        for(int i = 0; i<10; ++i)Game.BossesDefeated[i] = Data.boolGame[i]; 
        //Debug.Log("Loaded: Game");
    }

    public void LoadMap(){
        LocationManager.Instance.RespawnLocation = Data.stringMap[0];
        LocationManager.Instance.Location = Data.stringMap[1];
        LocationManager.Instance.RespawnPosition = new Vector2(Data.floatMapPositions[0], Data.floatMapPositions[1]);
        LocationManager.Instance.SavePosition = new Vector2(Data.floatMapPositions[2], Data.floatMapPositions[3]);
        Game.PlayerSprite.transform.position = new Vector3(Data.floatMapPositions[2], Data.floatMapPositions[3], 0);
    }

    public void LoadSkillTree()
    {
        //Debug.Log("Load started: Skill Tree");
        for (int i = 0; i < skillTreeRootNodes.Length; ++i)
        {
            skillTreeRootNodes[i].Load();
        }
        Skills.AccuracyUpgrades = Data.intSkillTree[0];
        Skills.EvasionUpgrades = Data.intSkillTree[1];
        Skills.SorceryUpgrades = Data.intSkillTree[2];
        Skills.UniversalUpgrades = Data.intSkillTree[3];
        //Debug.Log("Loaded: Skill Tree");
    }
}