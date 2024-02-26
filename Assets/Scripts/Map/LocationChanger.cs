using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class LocationChanger : MonoBehaviour
{
    public Vector2 Position;
    public string LocationToChange;
    public GameObject Boundaries;

    public async void Location_Change(){
        await Task.Delay(400);
        Game.Instance.PlayerSprite.transform.position = new Vector3(Position.x, Position.y, 0);
        LocationManager.Instance.SavePosition = new Vector2(Position.x, Position.y);
        LocationManager.Instance.Location = LocationToChange;
        LocationManager.Instance.ChangeLocation();
    }
}
