using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
    }

}
