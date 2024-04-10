using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class New_Game : MonoBehaviour
{
    public bool IsLoad = false;
    public GameObject top;
    public GameObject bottom;
    public GameObject text_g;
    public GameObject loading;
    public GameObject menu;
    public GameObject menu_1;
    public GameObject menu_2;
    public GameObject menu_3;
    public GameObject menu_4;
    public GameObject menu_5, menu_6;
    public TextMeshProUGUI text;
    public Image img;
    public Sprite bg;
    public int i;
    public Game game;
    public StopWatch StopWatch;

    public void OnClick()
    {
        if(i == 100){
            i = 0;
            text_g.SetActive(true);
            Invoke("Load", 0.025f);
        }
        else Invoke("move",0.0025f);
    }

    public void move(){
        ++i;
        top.transform.Translate(0, 0.02f, 0);
        bottom.transform.Translate(0, 0.02f, 0);
        OnClick();
    }

    public void Load()
    {
        if(i<100)
        {   
            ++i;
            text.text = Language_Changer.Instance.GetText("Loading") + " " + i + "%";
            if(i == 99) Invoke("Load",0.15f);
            else Invoke("Load",0.008f);
        }   
        else mainmenu();
    }

    public void re_move(){
        ++i;
        top.transform.Translate(0, -0.02f, 0);
        bottom.transform.Translate(0, -0.02f, 0);
        if(i == 100){
            i = 0;
            loading.SetActive(false);
            Invoke("Menu_show", 0.1f);
        }
        else Invoke("re_move",0.005f);
    }
    
    public void Menu_show(){
        ++i;
        menu_1.transform.Translate(0, 0.03f, 0);
        menu_2.transform.Translate(0, 0.03f, 0);
        menu_3.transform.Translate(0, 0.03f, 0);
        menu_4.transform.Translate(0, 0.03f, 0);
        menu_5.transform.Translate(0, -0.03f, 0);
        menu_6.transform.Translate(0, -0.03f, 0);
        if(i < 100) Invoke("Menu_show", 0.005f);
        if(!IsLoad){
            if(i==100 && game.IsSpeedrunning){
                StopWatch.StartCounting();
            }
            if(i==100 && game.IsTesting){
                game.player.SkillPoints = 900;
            }
        }
        
    }

    public void mainmenu(){
        menu_1.transform.Translate(0, -3.0f, 0);
        menu_2.transform.Translate(0, -3.0f, 0);
        menu_3.transform.Translate(0, -3.0f, 0);
        menu_4.transform.Translate(0, -3.0f, 0);
        menu_5.transform.Translate(0, 3.0f, 0);
        menu_6.transform.Translate(0, 3.0f, 0);
        img.sprite = bg;
        i = 0;
        text_g.SetActive(false);
        menu.SetActive(true);
        menu_5.SetActive(true);
        re_move();
    }
}
