using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationManager : MonoBehaviour
{
    public GameObject[] Locations = new GameObject[2], Bounds = new GameObject[2];
    public GameObject RespawnMapBoundaries;
    private GameObject CurrentLocation; 
    public string RespawnLocation, Location;
    public static LocationManager Instance;
    public Vector2 RespawnPosition, SavePosition;

    void Start(){
        Instance = this;
        if(CurrentLocation == null)CurrentLocation = Locations[0];
    }   

    public void ChangeLocation(){
        switch(Location){
            case "PlainsTest1":
                CurrentLocation.SetActive(false);
                Locations[0].SetActive(true);
                CurrentLocation = Locations[0];
                Game.Instance.PlayerSprite.GetComponent<Player_MapSprite>().Boundaries = Bounds[0];
                break;  
            case "PlainsTest2":
                CurrentLocation.SetActive(false);
                Locations[1].SetActive(true);
                CurrentLocation = Locations[1];
                Game.Instance.PlayerSprite.GetComponent<Player_MapSprite>().Boundaries = Bounds[1];
                break; 
            default:
                break;
        }
        Game.Instance.PlayerSprite.GetComponent<Player_MapSprite>().Boundaries_Update();
        Game.Instance.PlayerSprite.GetComponent<Player_MapSprite>().Camera_Move();
        SaveManager.Instance.SaveAll();
    } 
}
