using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System;
using System.Threading.Tasks;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class SkillTreeSegment : MonoBehaviour
{
    public Skills SkillManager;
    public Player player;
    public Button SkillsUpgradeButton;
    public TextMeshProUGUI Information_Skills, Button_Skills, Requirements_Skills, Title_Skills;
    public GameObject Information_Skills_BG;
    public string Class;
    bool CanBeUpgraded = false, WaitUntilChecked = false;
    public int CurrentSegmentUpgrades = 0;

    /*public void Check(GameObject Object, int Case1, int CheckVal1, int Case2 = 0, int CheckVal2 = 0, int Case3 = 0, int CheckVal3 = 0){
        if(Case1>=CheckVal1 && Case2>=CheckVal2 && Case3>=CheckVal3){
            Object.GetComponent<Button>().interactable = true;
            SkillManager.IsChecked = true;
            // Type Type_InvokeClass = Type.GetType(Class); or GetType();
            // FieldInfo IsChecked = Type_InvokeClass.GetField(Name + "_Checked"); //Searches for and changes bool "IsChecked" variable of current object
            // IsChecked.SetValue(this , true);
        }
    }*/

    public void CheckUpgrade(GameObject Object, string Name, int Case1, int CheckVal1 = 0, int Case2 = 0, int CheckVal2 = 0, int Case3 = 0, int CheckVal3 = 0, int Case4 = 0, int CheckVal4 = 0, string DescriptionKey = "", bool SplittedDescription = false){//if Splitted Description is set to false DescriptionKey cannot be empty, DescriptionKey supports only single checks
        string Description = "";
        if(SplittedDescription && CheckVal1 != 0) Description = Language_Changer.Instance.GetText(Name + "_CheckDescription", "Skills");
        else if(CheckVal1 == 0) {
            Description = Language_Changer.Instance.GetText(Class + "AllUpgrades", "Skills") + "\n";
        }
        else Description = Language_Changer.Instance.GetText(DescriptionKey, "Skills");
        if(Case1>=CheckVal1){
            Description = string.Format(Description, "<sprite=\"Checkmarks\" name=\"CheckmarkGreen\">", CheckVal1);
        }
        else Description = string.Format(Description, "<sprite=\"Checkmarks\" name=\"CheckmarkRed\">", CheckVal1);
        if(Case2>=CheckVal2 && Case2!=0){
            Description += string.Format(Language_Changer.Instance.GetText(Name + "_CheckDescription1", "Skills"), "<sprite=\"Checkmarks\" name=\"CheckmarkGreen\">", CheckVal2);
        }
        else Description += string.Format(Language_Changer.Instance.GetText(Name + "_CheckDescription1", "Skills"), "<sprite=\"Checkmarks\" name=\"CheckmarkRed\">", CheckVal2);
        if(Case3>=CheckVal3 && Case3!=0){
            Description += string.Format(Language_Changer.Instance.GetText(Name + "_CheckDescription2", "Skills"), "<sprite=\"Checkmarks\" name=\"CheckmarkGreen\">", CheckVal3);
        }
        else Description += string.Format(Language_Changer.Instance.GetText(Name + "_CheckDescription2", "Skills"), "<sprite=\"Checkmarks\" name=\"CheckmarkRed\">", CheckVal3);
        if(Case4>=CheckVal4 && Case4!=0){
            Description += string.Format(Language_Changer.Instance.GetText(Name + "_CheckDescription3", "Skills"), "<sprite=\"Checkmarks\" name=\"CheckmarkGreen\">", CheckVal4);
        }
        else Description += string.Format(Language_Changer.Instance.GetText(Name + "_CheckDescription3", "Skills"), "<sprite=\"Checkmarks\" name=\"CheckmarkRed\">", CheckVal4);
        Requirements_Skills.text = Description;
        if(Case1>=CheckVal1 && Case2>=CheckVal2 && Case3>=CheckVal3 && Case4>=CheckVal4){
            CanBeUpgraded = true;
        }
        else CanBeUpgraded = false;
    }

    public void CheckUpgradeSingle(GameObject Object, string Name, int Lvl, int CheckValLvl1 = 0, int CheckValLvl2 = 0, int CheckValLvl3 = 0, int CheckValLvl4 = 0){
        string Description = Language_Changer.Instance.GetText(Class + "AllUpgrades", "Skills") + "\n";
        CanBeUpgraded = false;
        switch(Lvl){
            case 0:
                if(CurrentSegmentUpgrades>=CheckValLvl1){
                    Description = string.Format(Description, "<sprite=\"Checkmarks\" name=\"CheckmarkGreen\">", CheckValLvl1);
                    CanBeUpgraded = true;
                }
                else Description = string.Format(Description, "<sprite=\"Checkmarks\" name=\"CheckmarkRed\">", CheckValLvl1);
                break;
            case 1:
                if(CurrentSegmentUpgrades>=CheckValLvl2){
                    Description = string.Format(Description, "<sprite=\"Checkmarks\" name=\"CheckmarkGreen\">", CheckValLvl2);
                    CanBeUpgraded = true;
                }
                else Description = string.Format(Description, "<sprite=\"Checkmarks\" name=\"CheckmarkRed\">", CheckValLvl2);
                break;
            case 2:
                if(CurrentSegmentUpgrades>=CheckValLvl3){
                    Description = string.Format(Description, "<sprite=\"Checkmarks\" name=\"CheckmarkGreen\">", CheckValLvl3);
                    CanBeUpgraded = true;
                }
                else Description = string.Format(Description, "<sprite=\"Checkmarks\" name=\"CheckmarkRed\">", CheckValLvl3);
                break;
            case 3:
                if(CurrentSegmentUpgrades>=CheckValLvl4){
                    Description = string.Format(Description, "<sprite=\"Checkmarks\" name=\"CheckmarkGreen\">", CheckValLvl4);
                    CanBeUpgraded = true;
                }
                else Description = string.Format(Description, "<sprite=\"Checkmarks\" name=\"CheckmarkRed\">", CheckValLvl4);
                break;
            default:
                break;
        }
        Requirements_Skills.text = Description;
        WaitUntilChecked = false;//Yes, no very good idea, but works
    }

    public async void GetText(GameObject Object, string Name, string SkillName = "", string TextName = "", int MaxUpgradesCount = 5, int Price1 = 1, int Price2 = -1, int Price3 = -1, int Price4 = -1, int Price5 = -1, float Format1 = -1, float Format2 = -1, float Format3 = -1, string StringFormat = "", bool HasCheck = true, bool HasSuffix = true){
        string DescriptionName = TextName + "_Description";
        if(SkillName == "") SkillName = Name;
        if(HasSuffix) SkillName += "_" + Class;
        if(Format1 == -1) Information_Skills.text = Language_Changer.Instance.GetText(DescriptionName, "Skills");
        else if(Format2 == -1) Information_Skills.text = string.Format(Language_Changer.Instance.GetText(DescriptionName, "Skills"), Format1);
        else if(Format3 == -1) Information_Skills.text = string.Format(Language_Changer.Instance.GetText(DescriptionName, "Skills"), Format1, Format2);
        else Information_Skills.text = string.Format(Language_Changer.Instance.GetText(DescriptionName, "Skills"), Format1, Format2, Format3);
        if(StringFormat != "") Information_Skills.text = string.Format(Language_Changer.Instance.GetText(DescriptionName, "Skills"), StringFormat);
        Title_Skills.text = Language_Changer.Instance.GetText(TextName, "Skills");
        
        Type Type_SkillManager = SkillManager.GetType(); 
        FieldInfo IsUpgraded = Type_SkillManager.GetField(SkillName);
        int UpgradesCount = Convert.ToInt32(IsUpgraded.GetValue(SkillManager));
        SkillManager.InformationWindowSkillImage.sprite = Object.transform.Find("Image").GetComponent<Image>().sprite;
        
        WaitUntilChecked = true;
        if(HasCheck && MaxUpgradesCount>UpgradesCount){
            Invoke(Name + "_CheckUpgrade", 0f);
            while(WaitUntilChecked)await Task.Delay(50);
        }
        else Requirements_Skills.text = "";

        int Price = Price1;
        if(MaxUpgradesCount>1 && MaxUpgradesCount<=5){
            switch(UpgradesCount){
                case 1:
                    if(Price2 != -1) Price = Price2;
                    break;
                case 2:
                    if(Price3 != -1) Price = Price3;
                    break;
                case 3:
                    if(Price4 != -1) Price = Price4;
                    break;
                case 4:
                    if(Price5 != -1) Price = Price5;
                    break;
                default:  
                    break;
            }
        }
        string Formatter_Price = "";
        if(Price%10 >= 2 && Price%10 <= 4)  Formatter_Price = "s";
        else if(Price%10 >= 5 || Price%10 == 0)  Formatter_Price = "s 5";

        if(Price!=0) Button_Skills.text = Price + " " +  Language_Changer.Instance.GetText("Skill_Point" + Formatter_Price, "Skills");
        else Button_Skills.text = Language_Changer.Instance.GetText("Free");

        if((HasCheck && player.SkillPoints>=Price && UpgradesCount < MaxUpgradesCount && CanBeUpgraded) || (!HasCheck && player.SkillPoints>=Price && (UpgradesCount < MaxUpgradesCount || MaxUpgradesCount == -1))) SkillsUpgradeButton.interactable = true;
        else SkillsUpgradeButton.interactable = false;
        if(UpgradesCount >= MaxUpgradesCount) Button_Skills.text = Language_Changer.Instance.GetText("Fully_Upgraded");
        SkillManager.InvokeClass = Class;
        SkillManager.InvokeMethod = Name;
        Information_Skills_BG.SetActive(true);
    }

    public void Upgrade(GameObject Object, string Name, string SkillName = "", int Price1 = 1, int Price2 = -1, int Price3 = -1, int Price4 = -1, int Price5 = -1, string Invoke1 = "", bool IsBool = false, int MaxUpgradesCount = 5, bool HasSuffix = true, GameObject SetInteractable1 = null, int CheckVal1 = -1, GameObject SetInteractable2 = null, int CheckVal2 = -1, GameObject SetInteractable3 = null, int CheckVal3 = -1, GameObject SetInteractable4 = null, int CheckVal4 = -1){
        if(SkillName == "") SkillName = Name;
        if(HasSuffix) SkillName += "_" + Class;

        Type Type_SkillManager = SkillManager.GetType(); 
        FieldInfo UpgradeVariable = Type_SkillManager.GetField(SkillName);
        int UpgradesCount = Convert.ToInt32(UpgradeVariable.GetValue(SkillManager));

        int Price = Price1;
        if(MaxUpgradesCount>1){
            switch(Convert.ToInt32(UpgradeVariable.GetValue(SkillManager))){
                case 1:
                    if(Price2 != -1) Price = Price2;
                    break;
                case 2:
                    if(Price3 != -1) Price = Price3;
                    break;
                case 3:
                    if(Price4 != -1) Price = Price4;
                    break;
                case 4:
                    if(Price5 != -1) Price = Price5;
                    break;
                default:
                    break;
            }
        }

        player.SkillPoints -= Price;
        ++CurrentSegmentUpgrades;
        if(IsBool){
            UpgradeVariable.SetValue(SkillManager , true);
            Object.transform.Find("UpgradeProgress").GetComponent<Image>().fillAmount = 1f;
        }
        else{
            UpgradeVariable.SetValue(SkillManager, (int)UpgradeVariable.GetValue(SkillManager) + 1);
            if(MaxUpgradesCount>0)Object.transform.Find("UpgradeProgress").GetComponent<Image>().fillAmount = (float) Convert.ToDouble(UpgradeVariable.GetValue(SkillManager))/(float)MaxUpgradesCount;
        }
        Invoke(Name + "_Text", 0f);

        
        SkillManager.SkillPointsCount_Update();
        if(Invoke1!=""){
            MethodInfo method = Type_SkillManager.GetMethod("Skilltree_" + Invoke1);
            method.Invoke(SkillManager, null);
        } 
        /*if(Invoke2!=""){
            MethodInfo method = Type_SkillManager.GetMethod("Skilltree_" + Invoke2);
            method.Invoke(SkillManager, null);
        }*/
        if(CheckVal1>0 && Convert.ToInt32(UpgradeVariable.GetValue(SkillManager))>=CheckVal1)SetInteractable1.GetComponent<Button>().interactable = true;
        if(CheckVal2>0 && Convert.ToInt32(UpgradeVariable.GetValue(SkillManager))>=CheckVal2)SetInteractable2.GetComponent<Button>().interactable = true;
        if(CheckVal3>0 && Convert.ToInt32(UpgradeVariable.GetValue(SkillManager))>=CheckVal3)SetInteractable3.GetComponent<Button>().interactable = true;
        if(CheckVal4>0 && Convert.ToInt32(UpgradeVariable.GetValue(SkillManager))>=CheckVal4)SetInteractable4.GetComponent<Button>().interactable = true;
        SkillManager.ChangeBranch(Class);
    }
}