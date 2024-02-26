using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;
using TMPro;

public class ActiveSkillsManager : MonoBehaviour
{   
    public bool[,] SkillsList = new bool[9, 2];//0 - IsUnlocked, 1 - IsSelected
    public int[] ActiveSlots = new int [5];//[0] - slots used
    public int MaxSlots = 1;
    public Vector2[] ActiveSlotsPos = new Vector2[4];
    public GameObject[] ActiveSlotsGO  = new GameObject[3];
    public Vector2[] SelectedSlotsPos = new Vector2[9];
    public GameObject[] Slots = new GameObject[9];
    public Sprite[] SlotImages = new Sprite[9];
    public GameObject Button;
    public int SelectedSlotID;
    public bool Removing;
    public Sprite Empty;
    public TextMeshProUGUI Information, Title;
    public Skills SkillManager;

    void  Awake(){
        for(int i = 1; i<5; ++i) ActiveSlots[i] = -1;
    }

    public async void ObjectMove(GameObject WhatWeAreMoving, Vector2 StartPos, Vector2 FinalPos){
        Vector3 Move = new Vector3((FinalPos.x-StartPos.x)/100, (FinalPos.y - StartPos.y)/100, 0);
        for(int i = 1; i<=100; ++i){
            WhatWeAreMoving.transform.position += Move;
            await Task.Delay(2);
        }
    }

    public void SelectSkill(){
        if(Removing){
            ObjectMove(Slots[SelectedSlotID], ActiveSlotsPos[GetPosition(SelectedSlotID)], SelectedSlotsPos[SelectedSlotID]);
            Button.transform.Find("text").GetComponent<TextMeshProUGUI>().text = Language_Changer.Instance.GetText("Use");
            ActiveSkillRemove(SelectedSlotID);
            SkillsList[SelectedSlotID, 1] = false;
        }
        else{
            Button.transform.Find("text").GetComponent<TextMeshProUGUI>().text = Language_Changer.Instance.GetText("Remove");
            ObjectMove(Slots[SelectedSlotID], SelectedSlotsPos[SelectedSlotID], ActiveSlotsPos[ActiveSlots[0]]);
            ++ActiveSlots[0];
            ActiveSlots[ActiveSlots[0]] = SelectedSlotID;
            SkillsList[SelectedSlotID, 1] = true;
        }
        Removing = !Removing;
    }

    public void SkillsUnlockCheck(){
        if(SkillManager.PHU){
            SkillsList[0, 0] = true;
            Slots[0].GetComponent<Image>().sprite = SlotImages[0];
        }
        if(SkillManager.BLU){
            SkillsList[3, 0] = true;
            Slots[3].GetComponent<Image>().sprite = SlotImages[3];
        }
        if(SkillManager.BSU){
            SkillsList[6, 0] = true;
            Slots[6].GetComponent<Image>().sprite = SlotImages[6];
        }
        if(SkillManager.CHU){
            SkillsList[7, 0] = true;
            Slots[7].GetComponent<Image>().sprite = SlotImages[7];
        }
        if(SkillManager.VU){
            SkillsList[8, 0] = true;
            Slots[8].GetComponent<Image>().sprite = SlotImages[8];
        }
        
    }
    
    public void GetDescription(int ID){
        int a, b, c, d;
        string e = "", f = "", g = ""; 
        float h;
        switch(ID){
            case 0:
                switch(SkillManager.PH_Damage){
                    case 1:
                        a = 25;
                        break;
                    case 2:
                        a = 40;
                        break;
                    case 3:
                        a = 60;
                        break;
                    default:
                        a = 10;
                        break;
                }
                switch(SkillManager.PH_Cooldown){
                    case 1:
                        b = 5;
                        break;
                    case 2:
                        b = 6;
                        break;
                    case 3:
                        b = 7;
                        break;
                    default:
                        b = 8;
                        break;
                }
                switch(SkillManager.PH_WeaponSkillChance){
                    case 1:
                        c = 50;
                        break;
                    case 2:
                        c = 100;
                        break;
                    default:
                        c = 0;
                        break;
                }
                Information.text = string.Format(Language_Changer.Instance.GetText("Active_Skill_" + ID + "_Description"), a, b, c);
                break;
            case 3:
                switch(SkillManager.BL_ReturnDamage){
                    case 1:
                        a = 25;
                        break;
                    case 2:
                        a = 35;
                        break;
                    case 3:
                        a = 50;
                        break;
                    default:
                        a = 20;
                        break;
                }
                switch(SkillManager.BL_Chance){
                    case 1:
                        b = 70;
                        break;
                    case 2:
                        b = 80;
                        break;
                    case 3:
                        b = 95;
                        break;
                    default:
                        b = 65;
                        break;
                }
                switch(SkillManager.BL_Cooldown){
                    case 1:
                        c = 5;
                        break;
                    case 2:
                        c = 4;
                        break;
                    default:
                        c = 6;
                        break;
                }
                Information.text = string.Format(Language_Changer.Instance.GetText("Active_Skill_" + ID + "_Description"), a, b, c);
                break;
            case 6:
                if(SkillManager.BS_NoEvasion) f = Language_Changer.Instance.GetText("Active_Skill_6_Description_No_Evasion");
                if(SkillManager.BS_Poison_AddDuration) a = 10;
                else a = 5;
                if(SkillManager.BS_UnlockWeakness){
                    if(SkillManager.BS_Weakness_AddDuration) e = string.Format(Language_Changer.Instance.GetText("Active_Skill_6_Description_Weakness"), 8);
                    else e = string.Format(Language_Changer.Instance.GetText("Active_Skill_6_Description_Weakness"), 5);
                }
                switch(SkillManager.BS_Damage){
                    case 1:
                        b = 20;
                        break;
                    case 2:
                        b = 30;
                        break;
                    case 3:
                        b = 50;
                        break;
                    default:
                        b = 0;
                        break;
                }
                switch(SkillManager.BS_Mana){
                    case 1:
                        d = 40;
                        break;
                    case 2:
                        d = 30;
                        break;
                    default:
                        d = 50;
                        break;
                }
                switch(SkillManager.BS_Cooldown){
                    case 1:
                        c = 7;
                        break;
                    case 2:
                        c = 6;
                        break;
                    case 3:
                        c = 5;
                        break;
                    default:
                        c = 8;
                        break;
                }
                if(SkillManager.BS_Ultimate){
                    b = 100;
                    g = Language_Changer.Instance.GetText("Double") + " ";
                }
                Information.text = string.Format(Language_Changer.Instance.GetText("Active_Skill_6_Description"), a, b, c, d, e, f, g);
                break;
            case 7:
                switch(SkillManager.CH_Mana){
                    case 1:
                        d = 220;
                        break;
                    case 2:
                        d = 180;
                        break;
                    case 3:
                        d = 150;
                        break;
                    default:
                        d = 250;
                        break;
                }
                switch(SkillManager.CH_Cooldown){
                    case 1:
                        c = 6;
                        break;
                    case 2:
                        c = 5;
                        break;
                    default:
                        c = 7;
                        break;
                }
                if(!SkillManager.CH_Effect){
                    switch(SkillManager.CH_Damage){
                        case 1:
                            a = 2;
                            break;
                        case 2:
                            a = 5;
                            break;
                        default:
                            a = 1;
                            break;
                    }
                    Information.text = string.Format(Language_Changer.Instance.GetText("Active Skill 7 Description"), a, c, d);
                }
                else{
                    switch(SkillManager.CH_Effect_Damage){
                        case 1:
                            h = 1f;
                            break;
                        case 2:
                            h = 1.5f;
                            break;
                        default:
                            h = 0.5f;
                            break;
                    }
                    switch(SkillManager.CH_Effect_EVChance){
                        case 1:
                            b = 7;
                            break;
                        case 2:
                            b = 5;
                            break;
                        default:
                            b = 9;
                            break;
                    }
                    switch(SkillManager.CH_Effect_Duration){
                        case 1:
                            g = "2-6";
                            break;
                        case 2:
                            g = "4-8";
                            break;
                        default:
                            g = "1-5";
                            break;
                    }
                    if(SkillManager.CH_Ultimate_HPPercent) e = Language_Changer.Instance.GetText("Max");
                    if(SkillManager.CH_Ultimate_RandomDebuff) f = Language_Changer.Instance.GetText("Active_Skill_7_Description_Ultimate");
                    Information.text = string.Format(Language_Changer.Instance.GetText("Active_Skill_7_Description_Effect"), h, b, c, d, e, f, g);
                }
                break;
            case 8:
                switch(SkillManager.V_Mana){
                    case 1:
                        d = 130;
                        break;
                    case 2:
                        d = 100;
                        break;
                    default:
                        d = 150;
                        break;
                }
                switch(SkillManager.V_Heal){
                    case 1:
                        b = 15;
                        break;
                    case 2:
                        b = 20;
                        break;
                    case 3:
                        b = 30;
                        break;
                    default:
                        b = 10;
                        break;
                }
                switch(SkillManager.V_EffectHeal){
                    case 1:
                        e = string.Format(Language_Changer.Instance.GetText("Active_Skill_8_Description_Effect"), 2);
                        break;
                    case 2:
                        e = string.Format(Language_Changer.Instance.GetText("Active_Skill_8_Description_Effect"), 5);
                        break;
                    default:
                        break;
                }
                switch(SkillManager.V_Damage){
                    case 1:
                        a = 300;
                        break;
                    case 2:
                        a = 400;
                        break;
                    case 3:
                        a = 600;
                        break;
                    default:
                        a = 200;
                        break;
                }
                c = 6;
                if(SkillManager.V_Ultimate){
                    f = Language_Changer.Instance.GetText("Active_Skill_8_Description_Ultimate");
                    e = string.Format(Language_Changer.Instance.GetText("Active_Skill_8_Description_Effect"), 10);    
                }
                Information.text = string.Format(Language_Changer.Instance.GetText("Active_Skill_8_Description"), a, b, c, d, e, f);
                break;
            default:
                Information.text = "Something Went Wrong, Please Report This";
                break;
        }
    }

    public void ActiveSkillRemove(int ID){
        for(int i = 1; i<=ActiveSlots[0]; i++){
            if(ID==ActiveSlots[i]){
                ActiveSlots[i]=-1;
                for(int j = 1; j<ActiveSlots[0]; ++j){
                    if(ActiveSlots[j]==-1){
                        ActiveSlots[j] = ActiveSlots[j+1];
                        ActiveSlots[j+1] = -1;
                        ObjectMove(Slots[ActiveSlots[j]], ActiveSlotsPos[j], ActiveSlotsPos[j-1]);
                    }
                }
                --ActiveSlots[0];
            }
        }
    }

    public int GetPosition(int ID){
        for(int i = 1; i<=ActiveSlots[0]; ++i) if(ID==ActiveSlots[i]) return i-1;
        return 0;
    }

    public void ReloadDescription(){
        Information.text = Language_Changer.Instance.GetText("Active_Skills_Default");
        Title.text = "";
    }

    public void ReloadImages(){
        if(MaxSlots >=2) ActiveSlotsGO[0].GetComponent<Image>().sprite = Empty;
        if(MaxSlots >=3) ActiveSlotsGO[1].GetComponent<Image>().sprite = Empty;
        if(MaxSlots ==4) ActiveSlotsGO[2].GetComponent<Image>().sprite = Empty;
    }

}
