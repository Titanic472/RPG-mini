using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class ManaOverdrain : MonoBehaviour
{
    public Player player;
    public int MovesLeft;
    
    public void Check(){
        if(MovesLeft>0){
            gameObject.SetActive(true);
            transform.Find("Mana_Overdrain_text").GetComponent<TextMeshProUGUI>().text = MovesLeft + "";
        }
    }
    public void Add(int Amount){
        player.Overdrained = true;
        MovesLeft = Amount;
        gameObject.SetActive(true);
        transform.Find("Mana_Overdrain_text").GetComponent<TextMeshProUGUI>().text = MovesLeft + "";
    }

    public void Remove(int Amount = 1){
        MovesLeft-=Amount;
        if(MovesLeft<0)MovesLeft=0;
        if(player.Overdrained && MovesLeft==0){
            gameObject.SetActive(false);
            player.Overdrained = false;
        }
        else transform.Find("Mana_Overdrain_text").GetComponent<TextMeshProUGUI>().text = MovesLeft + "";
    }
}
