using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class SpeedEnergy : MonoBehaviour
{
    public GameObject[] GreenSprites = new GameObject[20], EmptySprites = new GameObject[18];
    int LastIndex = 3;
    public GameObject LastSprite;

    public void AddMoreSlots(){
        LastSprite.transform.position = new Vector3(LastSprite.transform.position.x+0.32f, LastSprite.transform.position.y, LastSprite.transform.position.z);
        EmptySprites[LastIndex].SetActive(true);
        ++LastIndex;
    }

    public void Reorganise(){
        for(int i = 0; i<=Player.Instance.MaxSpeedEnergy-1; ++i)GreenSprites[i].SetActive(false);
        GreenSprites[19].SetActive(false);
        for(float i = 0; i<=Player.Instance.SpeedEnergy-1 && i!=Player.Instance.MaxSpeedEnergy; ++i){
            GreenSprites[(int)i].SetActive(true);
        }
        if(Player.Instance.SpeedEnergy == Player.Instance.MaxSpeedEnergy)GreenSprites[19].SetActive(true);
        if(Fight.Instance.InBattle){
            Item LeftHand, RightHand;
            LeftHand = Player.Instance.LeftHand.GetComponent<Item>();
            RightHand = Player.Instance.RightHand.GetComponent<Item>();
            if(RightHand.EnergyUsage <= Player.Instance.SpeedEnergy) for(int i = 0; i < RightHand.EnergyUsage; ++i) Fight.Instance.HandsStaminaUsage[i].sprite = Fight.Instance.StaminaLevelImages[0];
            else for(int i = 0; i < RightHand.EnergyUsage; ++i) Fight.Instance.HandsStaminaUsage[i].sprite = Fight.Instance.StaminaLevelImages[1];
            if(LeftHand.EnergyUsage <= Player.Instance.SpeedEnergy) for(int i = 0; i < LeftHand.EnergyUsage; ++i) Fight.Instance.HandsStaminaUsage[i+3].sprite = Fight.Instance.StaminaLevelImages[0];
            else for(int i = 0; i < LeftHand.EnergyUsage; ++i) Fight.Instance.HandsStaminaUsage[i+3].sprite = Fight.Instance.StaminaLevelImages[1];
        }
    }

}
