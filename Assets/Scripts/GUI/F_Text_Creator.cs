using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class F_Text_Creator : MonoBehaviour
{
    public GameObject FlyingText_Red, FlyingText_Green, FlyingText_Yellow, Canvas, FlyingText_Red_Map, FlyingText_Green_Map;
    
    public void CreateText_Red(string T){
        GameObject text;
        //if(!Fight.Instance.InBattle) text = Instantiate(FlyingText_Red_Map, new Vector3(transform.position.x - Canvas.transform.position.x - 5.4f, transform.position.y - Canvas.transform.position.y, transform.position.z), Quaternion.identity, Canvas.transform);
        text = Instantiate(FlyingText_Red, transform.position, Quaternion.identity, transform);
        text.GetComponent<TextMeshProUGUI>().text = T;
    }

    public void CreateText_Green(string T){
        GameObject text;
        //if(!Fight.Instance.InBattle) text = Instantiate(FlyingText_Green_Map, new Vector3(transform.position.x - Canvas.transform.position.x - 5.4f, transform.position.y - Canvas.transform.position.y, transform.position.z), Quaternion.identity, Canvas.transform);
        text = Instantiate(FlyingText_Green, transform.position, Quaternion.identity, transform);
        text.GetComponent<TextMeshProUGUI>().text = T;
    }

    public void CreateText_Yellow(string T){
        GameObject text = Instantiate(FlyingText_Yellow, transform.position, Quaternion.identity, transform);
        text.GetComponent<TextMeshProUGUI>().text = T;
    }
}
