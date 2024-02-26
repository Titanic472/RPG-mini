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

    public void Check(GameObject Object, string Name, int Case1, int CheckVal1, int Case2 = 0, int CheckVal2 = 0, int Case3 = 0, int CheckVal3 = 0, int Case4 = 0, int CheckVal4 = 0){
        if(Case1>=CheckVal1 && Case2>=CheckVal2 && Case3>=CheckVal3 && Case4>=CheckVal4){
            Object.transform.Find("Glowing_Yellow").gameObject.SetActive(true); 
            SkillManager.IsChecked = true;
            Type Type_InvClass = Type.GetType(Class);
            FieldInfo IsChecked = Type_InvClass.GetField(Name + "_Checked"); 
            IsChecked.SetValue(this , true);
        }
    }

    public void GetText(string Name, string SkillName = "", string TextName = "", string DescriptionName = "", int Price = 1, char Category = ' ',  int Req_C = 0, int UpgValue = 0, float Format1 = -1, float Format2 = -1, float Format3 = -1, string StringFormat = "", string Req1 = "", int Req1Lvl = 1, string Req2 = "", int Req2Lvl = 1, string Req3 = "", int Req3Lvl = 1, string Req4 = "", int Req4Lvl = 1, bool InfiniteUpgrade = false, bool HasCheck = true, bool  HasSuffix = true, bool NeedOtherUnlock = false){
        if(DescriptionName == "") DescriptionName = TextName + " Description";
        if(SkillName == "") SkillName = Name;
        if(Format1 == -1) Information_Skills.text = Language_Changer.Instance.GetText(DescriptionName);
        else if(Format2 == -1) Information_Skills.text = string.Format(Language_Changer.Instance.GetText(DescriptionName), Format1);
        else if(Format3 == -1) Information_Skills.text = string.Format(Language_Changer.Instance.GetText(DescriptionName), Format1, Format2);
        else Information_Skills.text = string.Format(Language_Changer.Instance.GetText(DescriptionName), Format1, Format2, Format3);
        if(StringFormat != "") Information_Skills.text = string.Format(Language_Changer.Instance.GetText(DescriptionName), StringFormat);
        Title_Skills.text = Language_Changer.Instance.GetText(TextName);
        
        string Formatter_Req = "", Formatter_Price = "";
        if(Req_C%10 >= 2 && Req_C%10 <= 4)  Formatter_Req = "s";
        else if(Req_C%10 >= 5 || Req_C%10 == 0)  Formatter_Req = "s 5";
        if(Price%10 >= 2 && Price%10 <= 4)  Formatter_Price = "s";
        else if(Price%10 >= 5 || Price%10 == 0)  Formatter_Price = "s 5";

        Requirements_Skills.text = "";
        if(Category == 'A') Requirements_Skills.text += "· " + Req_C + " " + Language_Changer.Instance.GetText("Accuracy_Point" + Formatter_Req) + "\n";
        else if(Category == 'E') Requirements_Skills.text += "· " + Req_C + " " + Language_Changer.Instance.GetText("Evasion_Point" + Formatter_Req) + "\n";
        else if(Category == 'M') Requirements_Skills.text += "· " + Language_Changer.Instance.GetText("Lvl") + " " + Req_C + " " + Language_Changer.Instance.GetText("Practice_Plus") + "\n";

        if(Req1 != ""){
            if(!NeedOtherUnlock) Requirements_Skills.text += "· " + Language_Changer.Instance.GetText("Lvl") + " " + Req1Lvl + " " + Language_Changer.Instance.GetText(Req1) + "\n";
            else Requirements_Skills.text += "· " + Language_Changer.Instance.GetText("Unlocked") + " " + Language_Changer.Instance.GetText(Req1) + "\n";
        }
        if(Req2 != "") Requirements_Skills.text += "· " + Language_Changer.Instance.GetText("Lvl") + " " + Req2Lvl + " " + Language_Changer.Instance.GetText(Req2) + "\n";
        if(Req3 != "") Requirements_Skills.text += "· " + Language_Changer.Instance.GetText("Lvl") + " " + Req3Lvl + " " + Language_Changer.Instance.GetText(Req3) + "\n";
        if(Req4 != "") Requirements_Skills.text += "· " + Language_Changer.Instance.GetText("Lvl") + " " + Req4Lvl + " " + Language_Changer.Instance.GetText(Req4);
        Button_Skills.text = Price + " " +  Language_Changer.Instance.GetText("Skill_Point" + Formatter_Price);
        Type Type_SkillM = SkillManager.GetType(); 
        Type Type_InvClass = Type.GetType(Class);
        FieldInfo IsUpgraded;
        if(HasSuffix) IsUpgraded = Type_SkillM.GetField(SkillName + "_" + Class);
        else IsUpgraded = Type_SkillM.GetField(SkillName);
        FieldInfo IsChecked = Type_InvClass.GetField(Name + "_Checked"); 
        if(!InfiniteUpgrade){
            if((HasCheck && player.SkillPoints>=Price && Convert.ToInt32(IsUpgraded.GetValue(SkillManager))==UpgValue && (bool)IsChecked.GetValue(this)) || (!HasCheck && player.SkillPoints>=Price && Convert.ToInt32(IsUpgraded.GetValue(SkillManager))==UpgValue)) SkillsUpgradeButton.interactable = true;
            else SkillsUpgradeButton.interactable = false;
            if(Convert.ToInt32(IsUpgraded.GetValue(SkillManager))>UpgValue) Button_Skills.text = Language_Changer.Instance.GetText("Fully_Upgraded");
        }
        else if(player.SkillPoints>=Price)SkillsUpgradeButton.interactable = true;
        else SkillsUpgradeButton.interactable = false;
        SkillManager.InvokeClass = Class;
        SkillManager.InvokeMethod = Name;
        Information_Skills_BG.SetActive(true);
    }

    public void Upgrade(GameObject Object, string Name, string SkillName = "", int Price = 1, string Invoke1 = "", string Invoke2 = "", bool IsBool = true, bool MoreUpgrades = false, bool HasSuffix = true){
        if(SkillName == "") SkillName = Name;
        if(HasSuffix) SkillName += "_" + Class;
        player.SkillPoints-=Price;
        Type Type_SkillM = SkillManager.GetType();
        FieldInfo UpgradeVariable = Type_SkillM.GetField(SkillName);
        if(IsBool){
            UpgradeVariable.SetValue(SkillManager , true);
            Object.transform.Find("Glowing_Yellow").gameObject.SetActive(false);
            Object.transform.Find("Glowing_Gold").gameObject.SetActive(true);
            Object.transform.Find("Level_Text").GetComponent<TextMeshProUGUI>().text = "Max";
        }
        else{
            UpgradeVariable.SetValue(SkillManager, (int)UpgradeVariable.GetValue(SkillManager)+1);
            if(!MoreUpgrades){
                Object.transform.Find("Glowing_Yellow").gameObject.SetActive(false);
                Object.transform.Find("Glowing_Gold").gameObject.SetActive(true);
                Object.transform.Find("Level_Text").GetComponent<TextMeshProUGUI>().text = "Max";
            }
            else {
                Object.transform.Find("Glowing_Yellow").gameObject.SetActive(false);
                Object.transform.Find("Glowing_Blue").gameObject.SetActive(true);
                Object.transform.Find("Level_Text").GetComponent<TextMeshProUGUI>().text = (int)UpgradeVariable.GetValue(SkillManager) + "";
            }
        }
        Invoke(Name + "_Text", 0f);

        
        SkillManager.SkillPointsCount_Update();
        if(Invoke1!=""){
            MethodInfo method = Type_SkillM.GetMethod("Skilltree_" + Invoke1);
            method.Invoke(SkillManager, null);
        } 
        if(Invoke2!=""){
            MethodInfo method = Type_SkillM.GetMethod("Skilltree_" + Invoke2);
            method.Invoke(SkillManager, null);
        }
    }
}