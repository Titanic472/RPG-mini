using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob_MapSprite : MonoBehaviour
{   
    public int ID, MinLevel, MaxLevel, Location;
    
    public void StartFight(){
        Fight.Instance.Mob_MapSprite = gameObject;
        Fight.Instance.StartBattle(MinLevel, MaxLevel, Location, ID, false);
    }
}
