using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ActiveSkillButton : MonoBehaviour
{
    public ActiveSkillsManager ActiveSkillsManager;
    public int SlotID;
    public TextMeshProUGUI Title;
    public GameObject Button, Self;
    public Language_Changer Lang;

    void Awake(){
        ActiveSkillsManager.Slots[SlotID] = Self;
    }

    public void OnClick(){
        Title.text = Language_Changer.Instance.GetText("Active_Skill_" + SlotID, "ActiveSkills");
        if(!ActiveSkillsManager.SkillsList[SlotID, 0]){
            ActiveSkillsManager.Information.alignment = TextAlignmentOptions.Capline;
            ActiveSkillsManager.Information.text = Language_Changer.Instance.GetText("Unlock_At_Skill_Tree", "ActiveSkills");
            Button.SetActive(false);
        }
        else{
            ActiveSkillsManager.Information.alignment = TextAlignmentOptions.TopLeft;
            ActiveSkillsManager.GetDescription(SlotID);
            Button.SetActive(true);
            ActiveSkillsManager.SelectedSlotID = SlotID;
            if(ActiveSkillsManager.SkillsList[SlotID, 1]){
                Button.GetComponent<Button>().interactable = true;
                ActiveSkillsManager.Removing = true;
                Button.transform.Find("text").GetComponent<TextMeshProUGUI>().text = Language_Changer.Instance.GetText("Remove");
            }
            else{
                ActiveSkillsManager.Removing = false;
                Button.transform.Find("text").GetComponent<TextMeshProUGUI>().text = Language_Changer.Instance.GetText("Use");
                if(ActiveSkillsManager.MaxSlots==ActiveSkillsManager.ActiveSlots[0]) Button.GetComponent<Button>().interactable = false;
                else Button.GetComponent<Button>().interactable = true;
            }
        }
    }
}
