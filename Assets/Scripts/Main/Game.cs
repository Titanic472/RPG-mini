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
    public Player player;
    public TextMeshProUGUI Information_Profile, FullscreenText, FullscreenText1;
    public Toggle FullscreenToggle, FullscreenToggle1;
    public bool[] BossesDefeated = new bool[10];
    public GameObject[] Items = new GameObject[15];
    public Sprite[] Item_Sprites = new Sprite[9], Potion_Sprites = new Sprite[5], Effects_Sprites = new Sprite[11];
    public int SkilledTreeChance = 0, ResolutionMode = 0;
    public bool IsHardcore = false, IsSpeedrunning = false, IsTesting = false, MapMode = false, IsFullscreen = true;
    public GameObject DeathWindow, PlayerSprite, Devtools;
    public static Game Instance;
    bool ValuesChanging = false;

    void Start(){
        Instance = this;
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
        Information_Profile.text = Language_Changer.Instance.GetText("Level") + ": " + player.Level + "\n" + Language_Changer.Instance.GetText("Experience") + ": " + XPAmount + "/" + NewLevelXPAmount + "\n\n" + "<sprite=\"Stats\" name=\"Damage\"> " + player.BaseDamage + " + " + player.RightHand.GetComponent<Item>().Damage;
        if(player.LeftHand.GetComponent<Item>().Type=="Shield")Information_Profile.text += "/" + "<sprite=\"Stats\" name=\"Defence\"> " + player.LeftHand.GetComponent<Item>().DamageReduction;
        else Information_Profile.text += "/" + player.LeftHand.GetComponent<Item>().Damage;
        Information_Profile.text += "\n" + "<sprite=\"Stats\" name=\"Speed\"> " + player.AttackSpeed + "\n"  + "<sprite=\"Stats\" name=\"Defence\"> " + (player.Hat.GetComponent<Item>().MinDefence + player.Chestplate.GetComponent<Item>().MinDefence + player.Boots.GetComponent<Item>().MinDefence) + "-" + (player.Hat.GetComponent<Item>().MaxDefence + player.Chestplate.GetComponent<Item>().MaxDefence + player.Boots.GetComponent<Item>().MaxDefence) + "\n" + "<sprite=\"Stats\" name=\"Accuracy\"> " + player.Accuracy + "\n" + "<sprite=\"Stats\" name=\"Evasion\"> " + player.Evasion + "\n" + "<sprite=\"Stats\" name=\"DamageResistance\"> " + Convert.ToInt32(player.DamageResistance*100) + "%" + "\n" + "<sprite=\"Stats\" name=\"HealthRegen\"> " + player.HealthRegen;   
    }

    public void ChangeHardcore(){
        IsHardcore = !IsHardcore;
    }

    public void ChangeSpeedrun(){
        IsSpeedrunning = !IsSpeedrunning;
    }

    public void ChangeTest(){
        IsTesting = !IsTesting;
        Devtools.SetActive(IsTesting);
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
