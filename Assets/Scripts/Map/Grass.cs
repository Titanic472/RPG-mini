using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grass : MonoBehaviour
{
    public int MinLevel, MaxLevel, Location, MaxID;

    public void StartFight(){
        //Fight.Instance.StartBattle(MinLevel, MaxLevel, Location, UnityEngine.Random.Range(0, MaxID+1), true);
        Fight.Instance.Mob_MapSprite = null;
        if(UnityEngine.Random.Range(0, 100)<25) Fight.Instance.StartBattle(Player.Instance.Level-2, Player.Instance.Level+2, Location, UnityEngine.Random.Range(0, MaxID+1), true);
    }
}
