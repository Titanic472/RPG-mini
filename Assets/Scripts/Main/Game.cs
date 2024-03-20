using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class Game : MonoBehaviour
{
    public Fight Fight;
    public SlimyArmor SlimyArmor;
    public Player player;
    public TextMeshProUGUI Information_Profile, FullscreenText, FullscreenText1;
    public Toggle FullscreenToggle, FullscreenToggle1;
    public bool[] BossesDefeated = new bool[10];
    public Sprite[] Item_Sprites = new Sprite[9], Potion_Sprites = new Sprite[5], Effects_Sprites = new Sprite[11];
    public Dictionary<string, int> Container = new Dictionary<string, int>();
    public Dictionary<string, string> ContText = new Dictionary<string, string>();
    public int SkilledTreeChance = 0, ResolutionMode = 0;
    public bool IsHardcore = false, IsSpeedrunning = false, IsTesting = false, MapMode = false, IsFullscreen = true;
    public GameObject DeathWindow, PlayerSprite;
    public static Game Instance;
    bool ValuesChanging = false;

    void Start(){
        Instance = this;
        ContText.Add("Name", "");//Container.Add("", 0);
        ContText.Add("Description", "");
        ContText.Add("Stats", "");
        ContText.Add("Type", "");
        Container.Add("ID", -1);
        Container.Add("Level", 0);
        Container.Add("Tier", 0);
        Container.Add("MinDefence", 0);
        Container.Add("UpgradeMinDefence", 0);
        Container.Add("MaxDefence", 0);
        Container.Add("UpgradeMaxDefence", 0);
        Container.Add("Accuracy", 0);
        Container.Add("UpgradeAccuracy", 0);
        Container.Add("Evasion", 0);
        Container.Add("UpgradeEvasion", 0);
        Container.Add("Mana", 0);
        Container.Add("ManaUsage", 0);
        Container.Add("UpgradeManaUsage", 0);
        Container.Add("UpgradeMana", 0);
        Container.Add("DamageReduction", 0);
        Container.Add("UpgradeDamageReduction", 0);
        Container.Add("DamageResistance", 0);
        Container.Add("UpgradeDamageResistance", 0);
        Container.Add("Damage", 0);
        Container.Add("UpgradeDamage", 0);
        Container.Add("Speed", 0);
        Container.Add("UpgradeSpeed", 0);
        Container.Add("Is2Handed", 0);
        Container.Add("AdditionalDamage", 0);
        Container.Add("UpgradeAdditionalDamage", 0);
        Container.Add("DamageModifier", 0);
        Container.Add("UpgradeDamageModifier", 0);
        Container.Add("DefenceModifier", 0);
        Container.Add("UpgradeDefenceModifier", 0);
        Container.Add("ExperienceModifier", 0);
        Container.Add("UpgradeExperienceModifier", 0);
        Container.Add("HealthModifier", 0);
        Container.Add("UpgradeHealthModifier", 0);
        Container.Add("Health", 0);
        Container.Add("UpgradeHealth", 0);
        Container.Add("SpeedModifier", 0);
        Container.Add("UpgradeSpeedModifier", 0);
        Container.Add("ManaModifier", 0);
        Container.Add("UpgradeManaModifier", 0);
        Container.Add("ManaRegen", 0);
        Container.Add("UpgradeManaRegen", 0);
        Container.Add("HealthRegen", 0);
        Container.Add("UpgradeHealthRegen", 0);
        Container.Add("ManaCost", 0);
        Container.Add("UpgradeManaCost", 0);
        Container.Add("Price", 0);
        Container.Add("UpgradeModifier", 0);
        Container.Add("PriceModifier", 1);
    }

    public void Information_Update_Profile()
    {   
        string XPAmount, NewLevelXPAmount;
        if(player.Experience[0]<=1){
            XPAmount = player.Experience[player.Experience[0]] + player.TextFormat(player.Experience[0]);
        }
        else{
        if(player.Experience[player.Experience[0]-1]>=100 || player.Experience[player.Experience[0]-1]==0) XPAmount = player.Experience[player.Experience[0]] + "." + player.Experience[player.Experience[0]-1] + player.TextFormat(player.Experience[0]);
            else if(player.Experience[player.Experience[0]-1]>=10) XPAmount = player.Experience[player.Experience[0]] + ".0" + player.Experience[player.Experience[0]-1] + player.TextFormat(player.Experience[0]);
            else XPAmount = player.Experience[player.Experience[0]] + ".00" + player.Experience[player.Experience[0]-1] + player.TextFormat(player.Experience[0]);
        }
        if(player.NewLevelXP[0]<=1){
            NewLevelXPAmount = player.NewLevelXP[player.NewLevelXP[0]] + player.TextFormat(player.NewLevelXP[0]);
            }
        else{
            if(player.NewLevelXP[player.NewLevelXP[0]-1]>=100 || player.NewLevelXP[player.NewLevelXP[0]-1]==0) NewLevelXPAmount = player.NewLevelXP[player.NewLevelXP[0]] + "." + player.NewLevelXP[player.NewLevelXP[0]-1] + player.TextFormat(player.NewLevelXP[0]);
            else if(player.NewLevelXP[player.NewLevelXP[0]-1]>=10) NewLevelXPAmount = player.NewLevelXP[player.NewLevelXP[0]] + ".0" + player.NewLevelXP[player.NewLevelXP[0]-1] + player.TextFormat(player.NewLevelXP[0]);
            else NewLevelXPAmount = player.NewLevelXP[player.NewLevelXP[0]] + ".00" + player.NewLevelXP[player.NewLevelXP[0]-1] + player.TextFormat(player.NewLevelXP[0]);
        }
        Information_Profile.text = Language_Changer.Instance.GetText("Level") + ": " + player.Level + "\n" + Language_Changer.Instance.GetText("Experience") + ": " + XPAmount + "/" + NewLevelXPAmount + "\n\n" + "<sprite=\"Stats\" name=\"Damage\"> " + player.RightHandDamage + "/" + player.LeftHandDamage + "\n" + "<sprite=\"Stats\" name=\"Speed\"> " + player.AttackSpeed + "\n"  + "<sprite=\"Stats\" name=\"Defence\"> " + player.MinDefence + "-" + player.MaxDefence + "\n" + "<sprite=\"Stats\" name=\"Accuracy\"> " + player.Skills["Accuracy"] + "\n" + "<sprite=\"Stats\" name=\"Evasion\"> " + player.Skills["Evasion"] + "\n" + "<sprite=\"Stats\" name=\"DamageResistance\"> " + player.DamageResistance + "%" + "\n" + "<sprite=\"Stats\" name=\"HealthRegen\"> " + player.HealthRegen;   
    }

    public void GetItemById(int Id, int Level){
        ContainerReset();
        Container["Level"] = Level;
        Container["ID"] = Id;
        switch(Id){
            case 0://Stick
                ContainerLoad(Name:Language_Changer.Instance.GetText("Stick"), Description: Language_Changer.Instance.GetText("Stick_Description"), Type:"Weapon", Tier:1, Damage:1, UpgradeDamage:1, Speed:1, UpgradeSpeed:0, Price:100, UpgradeModifier:50);
                Upgrade(1, Level);
                ContText["Stats"] = string.Format(ContText["Stats"], Container["Damage"]);
                break;
            case 1://Nettle Band
                ContainerLoad(Name:Language_Changer.Instance.GetText("Nettle_Band"), Description: Language_Changer.Instance.GetText("Nettle_Band_Description"), Type:"Hat", Tier:1, MinDefence:0, UpgradeMinDefence:1, MaxDefence:3, UpgradeMaxDefence:2, Price:200, UpgradeModifier:35);
                Upgrade(1, Level);
                ContText["Stats"] = string.Format(ContText["Stats"], Container["MinDefence"], Container["MaxDefence"]);
                break;
            case 2://Rat Slippers
                ContainerLoad(Name:Language_Changer.Instance.GetText("Rat_Slippers"), Description: Language_Changer.Instance.GetText("Rat_Slippers_Description"), Type:"Boots", Tier:1, MinDefence:0, UpgradeMinDefence:1, MaxDefence:3, UpgradeMaxDefence:2, Price:200, UpgradeModifier:35);
                Upgrade(1, Level);
                ContText["Stats"] = string.Format(ContText["Stats"], Container["MinDefence"], Container["MaxDefence"]);
                break;
            case 3://Slimy Chestplate
                SlimyArmor.Chestplate_Get();
                break;
            case 4://Decayed Broadsword
                ContainerLoad(Name:Language_Changer.Instance.GetText("Decayed_Broadsword"), Description: Language_Changer.Instance.GetText("Decayed_Broadsword_Description"), Type:"Weapon", Tier:1, Damage:3, UpgradeDamage:2, Speed:1, UpgradeSpeed:0, Price:300, UpgradeModifier:20);
                Upgrade(1, Level);
                ContText["Stats"] = string.Format(ContText["Stats"], Container["Damage"]);
                break;
            case 5://Old Torn Hood
                ContainerLoad(Name:Language_Changer.Instance.GetText("Old_Torn_Hood"), Description: Language_Changer.Instance.GetText("Old_Torn_Hood_Description"), Type:"Hat", Tier:1, MinDefence:2, UpgradeMinDefence:1, MaxDefence:5, UpgradeMaxDefence:3, Price:500, UpgradeModifier:45);
                Upgrade(1, Level);
                ContText["Stats"] = string.Format(ContText["Stats"], Container["MinDefence"], Container["MaxDefence"]);
                break;
            case 6://Cope Vest
                ContainerLoad(Name:Language_Changer.Instance.GetText("Cope_Vest"), Description: Language_Changer.Instance.GetText("Cope_Vest_Description"), Type:"Chestplate", Tier:1, MinDefence:2, UpgradeMinDefence:1, MaxDefence:5, UpgradeMaxDefence:3, Price:500, UpgradeModifier:45);
                Upgrade(1, Level);
                ContText["Stats"] = string.Format(ContText["Stats"], Container["MinDefence"], Container["MaxDefence"]);
                break;
            case 7://Well Worn Jeans
                ContainerLoad(Name:Language_Changer.Instance.GetText("Well_Worn_Jeans"), Description: Language_Changer.Instance.GetText("Well_Worn_Jeans_Description"), Type:"Boots", Tier:1, MinDefence:2, UpgradeMinDefence:1, MaxDefence:5, UpgradeMaxDefence:3, Price:500, UpgradeModifier:45);
                Upgrade(1, Level);
                ContText["Stats"] = string.Format(ContText["Stats"], Container["MinDefence"], Container["MaxDefence"]);
                break;
            case 8://Scimitar
                ContainerLoad(Name:Language_Changer.Instance.GetText("Scimitar"), Description: Language_Changer.Instance.GetText("Scimitar_Description"), Type:"Weapon", Tier:1, Damage:10, UpgradeDamage:3, Speed:1, UpgradeSpeed:0, Price:450, UpgradeModifier:10, UpgradeAccuracy:1, UpgradeEvasion:1);
                Upgrade(1, Level);
                ContText["Stats"] = string.Format(ContText["Stats"], Container["Damage"]);
                break;
            default:
                break;
        }
        
    }

    public void ContainerLoad(string Name = "", string Description = "", string Type = "", int PriceModifier = 1, int DamageResistance = 0, int UpgradeDamageResistance = 0, int Tier = 0, int ManaUsage = 0, int UpgradeManaUsage = 0 , int MinDefence = 0, int UpgradeMinDefence = 0, int MaxDefence = 0, int UpgradeMaxDefence = 0, int Accuracy = 0, int UpgradeAccuracy = 0, int Evasion = 0, int UpgradeEvasion = 0, int Mana = 0, int UpgradeMana = 0, int DamageReduction = 0, int UpgradeDamageReduction = 0, int Damage = 0, int UpgradeDamage = 0, int Speed = 0, int UpgradeSpeed = 0, int Is2Handed = 0, int AdditionalDamage = 0, int UpgradeAdditionalDamage = 0, int DefenceModifier = 100, int UpgradeDefenceModifier = 0, int DamageModifier = 100, int UpgradeDamageModifier = 0, int ExperienceModifier = 100, int UpgradeExperienceModifier = 0, int HealthModifier = 100, int UpgradeHealthModifier = 0, int Health = 0, int UpgradeHealth = 0, int SpeedModifier = 100, int UpgradeSpeedModifier = 0, int ManaModifier = 100, int UpgradeManaModifier = 0, int ManaRegen = 0, int UpgradeManaRegen = 0, int HealthRegen = 0, int UpgradeHealthRegen = 0, int ManaCost = 100, int UpgradeManaCost = 0, int Price = 0, int UpgradeModifier = 0){
        ContText["Name"] = Name;
        ContText["Description"] = Description;
        ContText["Type"] = Type;
        Container["Tier"] = Tier;
        Container["MinDefence"] = MinDefence;
        Container["UpgradeMinDefence"] = UpgradeMinDefence;
        Container["MaxDefence"] = MaxDefence;
        Container["UpgradeMaxDefence"] = UpgradeMaxDefence;
        Container["Accuracy"] = Accuracy;
        Container["UpgradeAccuracy"] = UpgradeAccuracy;
        Container["Evasion"] = Evasion;
        Container["UpgradeEvasion"] = UpgradeEvasion;
        Container["Mana"] = Mana;
        Container["ManaUsage"] = ManaUsage;
        Container["UpgradeManaUsage"] = UpgradeManaUsage;
        Container["UpgradeMana"] = UpgradeMana;
        Container["DamageReduction"] = DamageReduction;
        Container["UpgradeDamageReduction"] = UpgradeDamageReduction;
        Container["DamageResistance"] = DamageResistance;
        Container["UpgradeDamageResistance"] = UpgradeDamageResistance;
        Container["Damage"] = Damage;
        Container["UpgradeDamage"] = UpgradeDamage;
        Container["Speed"] = Speed;
        Container["UpgradeSpeed"] = UpgradeSpeed;
        Container["Is2Handed"] = Is2Handed;
        Container["AdditionalDamage"] = AdditionalDamage;
        Container["UpgradeAdditionalDamage"] = UpgradeAdditionalDamage;
        Container["DamageModifier"] = DamageModifier;
        Container["UpgradeDamageModifier"] = UpgradeDamageModifier;
        Container["DefenceModifier"] = DefenceModifier;
        Container["UpgradeDefenceModifier"] = UpgradeDefenceModifier;
        Container["ExperienceModifier"] = ExperienceModifier;
        Container["UpgradeExperienceModifier"] = UpgradeExperienceModifier;
        Container["HealthModifier"] = HealthModifier;
        Container["UpgradeHealthModifier"] = UpgradeHealthModifier;
        Container["Health"] = Health;
        Container["UpgradeHealth"] = UpgradeHealth;
        Container["SpeedModifier"] = SpeedModifier;
        Container["UpgradeSpeedModifier"] = UpgradeSpeedModifier;
        Container["ManaModifier"] = ManaModifier;
        Container["UpgradeManaModifier"] = UpgradeManaModifier;
        Container["ManaRegen"] = ManaRegen;
        Container["UpgradeManaRegen"] = UpgradeManaRegen;
        Container["HealthRegen"] = HealthRegen;
        Container["UpgradeHealthRegen"] = UpgradeHealthRegen;
        Container["ManaCost"] = ManaCost;
        Container["UpgradeManaCost"] = UpgradeManaCost;
        Container["Price"] = Price;
        Container["UpgradeModifier"] = UpgradeModifier;
        Container["PriceModifier"] = PriceModifier;
    }

    public void ContainerReset(){
        ContText["Name"] = "";
        ContText["Description"] = "";
        ContText["Stats"] = "";
        ContText["Type"] = "";
        Container["ID"] = -1;
        Container["Level"] = 0;
        Container["Tier"] = 0;
        Container["MinDefence"] = 0;
        Container["UpgradeMinDefence"] = 0;
        Container["MaxDefence"] = 0;
        Container["UpgradeMaxDefence"] = 0;
        Container["Accuracy"] = 0;
        Container["UpgradeAccuracy"] = 0;
        Container["Evasion"] = 0;
        Container["UpgradeEvasion"] = 0;
        Container["Mana"] = 0;
        Container["ManaUsage"] = 0;
        Container["UpgradeManaUsage"] = 0;
        Container["UpgradeMana"] = 0;
        Container["DamageReduction"] = 0;
        Container["UpgradeDamageReduction"] = 0;
        Container["DamageResistance"] = 0;
        Container["UpgradeDamageResistance"] = 0;
        Container["Damage"] = 0;
        Container["UpgradeDamage"] = 0;
        Container["Speed"] = 0;
        Container["UpgradeSpeed"] = 0;
        Container["Is2Handed"] = 0;
        Container["AdditionalDamage"] = 0;
        Container["UpgradeAdditionalDamage"] = 0;
        Container["DamageModifier"] = 0;
        Container["UpgradeDamageModifier"] = 0;
        Container["DefenceModifier"] = 0;
        Container["UpgradeDefenceModifier"] = 0;
        Container["ExperienceModifier"] = 0;
        Container["UpgradeExperienceModifier"] = 0;
        Container["HealthModifier"] = 0;
        Container["UpgradeHealthModifier"] = 0;
        Container["Health"] = 0;
        Container["UpgradeHealth"] = 0;
        Container["SpeedModifier"] = 0;
        Container["UpgradeSpeedModifier"] = 0;
        Container["ManaModifier"] = 0;
        Container["UpgradeManaModifier"] = 0;
        Container["ManaRegen"] = 0;
        Container["UpgradeManaRegen"] = 0;
        Container["HealthRegen"] = 0;
        Container["UpgradeHealthRegen"] = 0;
        Container["ManaCost"] = 0;
        Container["UpgradeManaCost"] = 0;
        Container["Price"] = 0;
        Container["UpgradeModifier"] = 0;
        Container["PriceModifier"] = 1;
    }

    public void Upgrade(int Level, int LevelToUpgrade){
        if(Level == LevelToUpgrade) return;
        int Upgrades = LevelToUpgrade-Level;
        int AllUpgrades = Upgrades + Convert.ToInt32(LevelToUpgrade/(6-Container["Tier"])) - Convert.ToInt32(Level/(6-Container["Tier"]));
        if(ContText["Type"] == "Hat" || ContText["Type"] == "Chestplate" || ContText["Type"] == "Boots"){
            Container["MinDefence"] += Container["UpgradeMinDefence"]*AllUpgrades;
            Container["MaxDefence"] += Container["UpgradeMaxDefence"]*AllUpgrades;
            Container["Mana"] += Container["UpgradeMana"]*AllUpgrades;
            Container["DamageResistance"] += Container["UpgradeDamageResistance"]*AllUpgrades;
        }
        if(ContText["Type"] == "Shield") Container["DamageReduction"] += Container["UpgradeDamageReduction"]*AllUpgrades;;
        if(ContText["Type"] == "Weapon"){
            Container["Damage"] += Container["UpgradeDamage"]*AllUpgrades;
            Container["Speed"] += Container["UpgradeSpeed"]*AllUpgrades;
            Container["ManaUsage"] += Container["UpgradeManaUsage"]*AllUpgrades;
        }
        if(ContText["Type"] == "Ring"){
            Container["AdditionalDamage"] += Container["UpgradeAdditionalDamage"]*AllUpgrades;
            Container["DamageModifier"] += Container["UpgradeDamageModifier"]*AllUpgrades;
            Container["DefenceModifier"] += Container["UpgradeDefenceModifier"]*AllUpgrades;
            Container["ExperienceModifier"] += Container["UpgradeExperienceModifier"]*AllUpgrades;
            Container["HealthModifier"] += Container["UpgradeHealthModifier"]*AllUpgrades;
            Container["Health"] += Container["UpgradeHealth"]*AllUpgrades;
            Container["SpeedModifier"] += Container["UpgradeSpeedModifier"]*AllUpgrades;
            Container["ManaModifier"] += Container["UpgradeManaModifier"]*AllUpgrades;
            Container["ManaRegen"] += Container["UpgradeManaRegen"]*AllUpgrades;
            Container["HealthRegen"] += Container["UpgradeHealthRegen"]*AllUpgrades;
            Container["ManaCost"] += Container["UpgradeManaCost"]*AllUpgrades;
            Container["Mana"] += Container["UpgradeMana"]*AllUpgrades;
            Container["DamageResistance"] += Container["UpgradeDamageResistance"]*AllUpgrades;
        }
        for(int i = Level; i<LevelToUpgrade; ++i) Container["Price"] += Container["Price"]*Container["UpgradeModifier"]/100;
        Container["Accuracy"] += Container["UpgradeAccuracy"]*AllUpgrades;
        Container["Evasion"] += Container["UpgradeEvasion"]*AllUpgrades;
        Container["Level"] = LevelToUpgrade;
    }

    public void ChangeHardcore(){
        IsHardcore = !IsHardcore;
    }

    public void ChangeSpeedrun(){
        IsSpeedrunning = !IsSpeedrunning;
    }

    public void ChangeTest(){
        IsTesting = !IsTesting;
    }

    public void ChangeMapMode(){
        MapMode = !MapMode;
        if(!MapMode)PlayerSprite.GetComponent<Player_MapSprite>().Camera.transform.position = new Vector3(-4.0654f, 0.9602f, -10);
        else {
            PlayerSprite.GetComponent<Player_MapSprite>().Boundaries_Update();
            PlayerSprite.GetComponent<Player_MapSprite>().Camera_Move();
        }
    }

    public void ChangeFullscreen(bool Is2){
        if(ValuesChanging) return;
        ValuesChanging = true;
        IsFullscreen = !IsFullscreen;
        if(Is2)FullscreenToggle.isOn = IsFullscreen;
        else FullscreenToggle1.isOn = IsFullscreen;
        if(!IsFullscreen){
            RescaleScreen();
        }
        else {
            Screen.SetResolution(1920, 1080, FullScreenMode.FullScreenWindow);   
            FullscreenText.text = Language_Changer.Instance.GetText("Fullscreen");
            FullscreenText1.text = Language_Changer.Instance.GetText("Fullscreen");
        }
        ValuesChanging = false;
    }

    public void RescaleScreen(){
        switch(ResolutionMode){
            case 1:
                FullscreenText.text = Language_Changer.Instance.GetText("Windowed") + " 1280x720";
                FullscreenText1.text = Language_Changer.Instance.GetText("Windowed") + " 1280x720";
                Screen.SetResolution(1280, 720, false);
                break;
            case 2:
                FullscreenText.text = Language_Changer.Instance.GetText("Windowed") + " 854x480";
                FullscreenText1.text = Language_Changer.Instance.GetText("Windowed") + " 854x480";
                Screen.SetResolution(854, 480, false);
                break;
            case 3:
                FullscreenText.text = Language_Changer.Instance.GetText("Windowed") + " 640x360";
                FullscreenText1.text = Language_Changer.Instance.GetText("Windowed") + " 640x360";
                Screen.SetResolution(640, 360, false);
                break;
            default:
                FullscreenText.text = Language_Changer.Instance.GetText("Windowed") + " 1600x900";
                FullscreenText1.text = Language_Changer.Instance.GetText("Windowed") + " 1600x900";
                Screen.SetResolution(1600, 900, false);
                break;
        }
    }

    public void ChangeResolutionMode(){
        if(IsFullscreen)return;
        if(ResolutionMode<3) ++ResolutionMode;
        else ResolutionMode = 0;
        RescaleScreen();
    }

    public void EndGame(){
        Fight.ButtonsActivate(false);
        DeathWindow.SetActive(true);
        if(IsHardcore){
            File.Delete(Application.persistentDataPath + "/save.json");
            //DeathWindow.transform.Find("Text").GetComponent<TextMeshProUGUI>.text = "You Died";
            DeathWindow.transform.Find("Respawn").gameObject.SetActive(false);
            DeathWindow.transform.Find("Quit").gameObject.SetActive(true);
        }
        else {
            for(int i = 0; i<10; ++i) for(int j = 0; j<5;++j) player.StatusEffects[i, j] = -1;
            DeathWindow.transform.Find("Respawn").gameObject.SetActive(true);
            DeathWindow.transform.Find("Quit").gameObject.SetActive(false);
        }
    }
}
