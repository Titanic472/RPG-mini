using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System;
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
    bool CanBeUpgraded = false;
    int CurrentSegmentUpgrades = 0;

    public void Check(GameObject Object, string Name, int Case1, int CheckVal1, int Case2 = 0, int CheckVal2 = 0, int Case3 = 0, int CheckVal3 = 0){
        if(Case1>=CheckVal1 && Case2>=CheckVal2 && Case3>=CheckVal3){
            Object.GetComponent<Button>().interactable = true;
            SkillManager.IsChecked = true;
            // Type Type_InvokeClass = Type.GetType(Class); or GetType();
            // FieldInfo IsChecked = Type_InvokeClass.GetField(Name + "_Checked"); //Searches for and changes bool "IsChecked" variable of current object
            // IsChecked.SetValue(this , true);
        }
    }

    public void CheckUpgrade(GameObject Object, string Name, int Case1, int CheckVal1, int Case2 = 0, int CheckVal2 = 0, int Case3 = 0, int CheckVal3 = 0, int Case4 = 0, int CheckVal4 = 0, string DescriptionKey = "", bool SplittedDescription = false, char Category = ' '){//if Splitted Description is set to false DescriptionKey cannot be empty, DescriptionKey supports only single checks
        string Description = "";
        if(SplittedDescription && Category == ' ') Description = Language_Changer.Instance.GetText(Name + "_CheckDescription", "Skills");
        else if(Category != ' ') {
            if(Category == 'A') Description = Language_Changer.Instance.GetText("AccuracyAllUpgrades", "Skills") + "\n";
            else if(Category == 'E') Description = Language_Changer.Instance.GetText("EvasionAllUpgrades", "Skills") + "\n";
            else if(Category == 'S') Description = Language_Changer.Instance.GetText("SorceryAllUpgrades", "Skills") + "\n";
        }
        else Description = Language_Changer.Instance.GetText(DescriptionKey, "Skills");
        if(Case1>=CheckVal1){
            Description = string.Format(Description, "<sprite=\"Checkmarks\" name=\"CheckmarkGreen\">", Case1);
        }
        else Description = string.Format(Description, "<sprite=\"Checkmarks\" name=\"CheckmarkRed\">", Case1);
        if(Case2>=CheckVal2 && Case2!=0){
            Description += string.Format(Language_Changer.Instance.GetText(Name + "_CheckDescription1", "Skills"), "<sprite=\"Checkmarks\" name=\"CheckmarkGreen\">", Case2);
        }
        else Description += string.Format(Language_Changer.Instance.GetText(Name + "_CheckDescription1", "Skills"), "<sprite=\"Checkmarks\" name=\"CheckmarkRed\">", Case2);
        if(Case3>=CheckVal3 && Case3!=0){
            Description += string.Format(Language_Changer.Instance.GetText(Name + "_CheckDescription2", "Skills"), "<sprite=\"Checkmarks\" name=\"CheckmarkGreen\">", Case3);
        }
        else Description += string.Format(Language_Changer.Instance.GetText(Name + "_CheckDescription2", "Skills"), "<sprite=\"Checkmarks\" name=\"CheckmarkRed\">", Case3);
        if(Case4>=CheckVal4 && Case4!=0){
            Description += string.Format(Language_Changer.Instance.GetText(Name + "_CheckDescription3", "Skills"), "<sprite=\"Checkmarks\" name=\"CheckmarkGreen\">", Case4);
        }
        else Description += string.Format(Language_Changer.Instance.GetText(Name + "_CheckDescription3", "Skills"), "<sprite=\"Checkmarks\" name=\"CheckmarkRed\">", Case4);
        Requirements_Skills.text = Description;
        if(Case1>=CheckVal1 && Case2>=CheckVal2 && Case3>=CheckVal3 && Case4>=CheckVal4){
            CanBeUpgraded = true;
        }
        else CanBeUpgraded = false;
    }

    public void GetText(GameObject Object, string Name, string SkillName = "", string TextName = "", string DescriptionName = "", int MaxUpgradesCount = 5, int Price1 = 1, int Price2 = -1, int Price3 = -1, int Price4 = -1, int Price5 = -1, float Format1 = -1, float Format2 = -1, float Format3 = -1, string StringFormat = "", bool HasCheck = true, bool HasSuffix = true){
        if(DescriptionName == "") DescriptionName = TextName + "_Description";
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
        if(HasCheck)Invoke(Name + "_CheckUpgrade", 0f);
        else Requirements_Skills.text = "";

        SkillManager.InformationWindowSkillImage.sprite = Object.transform.Find("Image").GetComponent<Image>().sprite;

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
                    Debug.Log(UpgradesCount);
                    break;
            }
        }
        
        string Formatter_Price = "";
        if(Price%10 >= 2 && Price%10 <= 4)  Formatter_Price = "s";
        else if(Price%10 >= 5 || Price%10 == 0)  Formatter_Price = "s 5";

        if(Price!=0) Button_Skills.text = Price + " " +  Language_Changer.Instance.GetText("Skill_Point" + Formatter_Price, "Skills");
        else Button_Skills.text = Language_Changer.Instance.GetText("Free");

        if(MaxUpgradesCount>0){
            if((HasCheck && player.SkillPoints>=Price && UpgradesCount < MaxUpgradesCount && CanBeUpgraded) || (!HasCheck && player.SkillPoints>=Price && UpgradesCount < MaxUpgradesCount)) SkillsUpgradeButton.interactable = true;
            else SkillsUpgradeButton.interactable = false;
            if(UpgradesCount >= MaxUpgradesCount) Button_Skills.text = Language_Changer.Instance.GetText("Fully_Upgraded");
        }
        else if(player.SkillPoints>=Price)SkillsUpgradeButton.interactable = true;
        else SkillsUpgradeButton.interactable = false;
        SkillManager.InvokeClass = Class;
        SkillManager.InvokeMethod = Name;
        Information_Skills_BG.SetActive(true);
    }

    public void Upgrade(GameObject Object, string Name, string SkillName = "", int Price1 = 1, int Price2 = -1, int Price3 = -1, int Price4 = -1, int Price5 = -1, string Invoke1 = "", string Invoke2 = "", bool IsBool = true, int MaxUpgradesCount = 5, bool HasSuffix = true){
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
                    Debug.Log(UpgradesCount + " Upgrade Method");
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
            Object.transform.Find("UpgradeProgress").GetComponent<Image>().fillAmount = (float) Convert.ToDouble(UpgradeVariable.GetValue(SkillManager))/(float)MaxUpgradesCount;
        }
        Invoke(Name + "_Text", 0f);

        
        SkillManager.SkillPointsCount_Update();
        if(Invoke1!=""){
            MethodInfo method = Type_SkillManager.GetMethod("Skilltree_" + Invoke1);
            method.Invoke(SkillManager, null);
        } 
        if(Invoke2!=""){
            MethodInfo method = Type_SkillManager.GetMethod("Skilltree_" + Invoke2);
            method.Invoke(SkillManager, null);
        }
    }
}