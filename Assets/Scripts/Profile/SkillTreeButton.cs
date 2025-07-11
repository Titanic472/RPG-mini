using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Reflection;
using UnityEngine.UI;


public class SkillTreeButton : SkillTreeSegment
{
    public bool hasSuffix = true, hasCheck = true, isActiveSkill = false;
    public int previousButtonLevelToUnlock = 0, level = 0, maxUpgrades = 5;
    public int[] upgradePrices = new int[5], allUpgradesCountToUnlockUpgrades = new int[5];
    public string textName;
    public string[] invokes = new string[2];
    public GameObject[] childsConnected = new GameObject[4];
    public float[] format1 = new float[5], format2 = new float[5], format3 = new float[5];//text formatter for every level
    public string[] stringFormat = new string[5];
    public bool[] customFormats = new bool[4];
    public GameObject extraCheckObject = null;
    public int extraCheckLevel = 0;
    public bool ignoreChildLoad = false;//for buttons that are connected to other buttons twice

    protected void GetCustomFormats()
    {
        if (customFormats[0])
        {
            format1[0] = format1[1] = format1[2] = format1[3] = format1[4] = CustomSkillsTextFormatter.GetText(gameObject.name, 1);
        }
        if (customFormats[1])
        {
            format2[0] = format2[1] = format2[2] = format2[3] = format2[4] = CustomSkillsTextFormatter.GetText(gameObject.name, 2);
        }
        if (customFormats[2])
        {
            format3[0] = format3[1] = format3[2] = format3[3] = format3[4] = CustomSkillsTextFormatter.GetText(gameObject.name, 3);
        }
    }
    private void CheckUpgrade()
    {
        CheckUpgradeSingle(gameObject, gameObject.name, Lvl: level, CheckValLvl1: allUpgradesCountToUnlockUpgrades[0], CheckValLvl2: allUpgradesCountToUnlockUpgrades[1], CheckValLvl3: allUpgradesCountToUnlockUpgrades[2], CheckValLvl4: allUpgradesCountToUnlockUpgrades[3], CheckValLvl5: allUpgradesCountToUnlockUpgrades[4]);
    }

    public virtual void OnClick()
    {
        GetCustomFormats();
        GetText(Object: gameObject, Name: gameObject.name, TextName: textName, MaxUpgradesCount: maxUpgrades, Price1: upgradePrices[0], Price2: upgradePrices[1], Price3: upgradePrices[2], Price4: upgradePrices[3], Price5: upgradePrices[4], Format1: format1[Math.Min(maxUpgrades - 1, level)], Format2: format2[Math.Min(maxUpgrades - 1, level)], Format3: format3[Math.Min(maxUpgrades - 1, level)], StringFormat: stringFormat[Math.Min(maxUpgrades - 1, level)], HasCheck: hasCheck, HasSuffix: hasSuffix);
    }

    public virtual void UpgradeClick()
    {
        bool isBool = false;
        if (maxUpgrades == 1) isBool = true;
        int[] checkValues = new int[4];
        for (int i = 0; i < 4; ++i)
        {
            if (childsConnected[i] != null)
            {
                checkValues[i] = childsConnected[i].GetComponent<SkillTreeButton>().previousButtonLevelToUnlock;
            }
            else checkValues[i] = -1;
        }
        if (extraCheckObject != null && extraCheckLevel > extraCheckObject.GetComponent<SkillTreeButton>().level)
        {
            checkValues[0] = 6;
        }

        Upgrade(Object: gameObject, Name: gameObject.name, Price1: upgradePrices[0], Price2: upgradePrices[1], Price3: upgradePrices[2], Price4: upgradePrices[3], Price5: upgradePrices[4], Invoke1: invokes[0], Invoke2: invokes[1], IsBool: isBool, MaxUpgradesCount: maxUpgrades, HasSuffix: hasSuffix, SetInteractable1: childsConnected[0], CheckVal1: checkValues[0], SetInteractable2: childsConnected[1], CheckVal2: checkValues[1], SetInteractable3: childsConnected[2], CheckVal3: checkValues[2], SetInteractable4: childsConnected[3], CheckVal4: checkValues[3]);
        if (isActiveSkill) SkillManager.ActiveSkillsManager.SkillsUnlockCheck();
        ++level;
        if (maxUpgrades == 1 && childsConnected.Length > 4)
        {
            for (int i = 4; i < childsConnected.Length; ++i)
            {
                childsConnected[i].GetComponent<Button>().interactable = true;
            }
        }
    }

    public void Save()
    {
        string name = gameObject.name;
        if (hasSuffix) name += "_" + branchName;
        SaveManager.Instance.Data.skillTree.Add(new SkillTreeEntry(name, level, GetComponent<Button>().IsInteractable()));
        //Debug.Log("Saved: " + gameObject.name);
        for (int i = 0; i < childsConnected.Length; ++i)
        {
            if (childsConnected[i] != null)
            {
                childsConnected[i].GetComponent<SkillTreeButton>().Save();
            }
            else break;
        }
    }

    public void Load()
    {
        if (maxUpgrades != 0)
        {
            string name = gameObject.name;
            if (hasSuffix) name += "_" + branchName;
            SkillTreeEntry entry = SaveManager.Instance.Data.skillTree.Find(x => x.name == name);
            level = entry.level;
            GetComponent<Button>().interactable = entry.buttonState;
            if (maxUpgrades > 0) transform.Find("UpgradeProgress").GetComponent<Image>().fillAmount = (float)level / (float)maxUpgrades;
            Type Type_SkillManager = typeof(Skills);
            FieldInfo SkillsVariable = Type_SkillManager.GetField(name);
            if (maxUpgrades == 1)
            {
                SkillsVariable.SetValue(SkillManager, Convert.ToBoolean(level));
            }
            else
            {
                SkillsVariable.SetValue(SkillManager, (int)level);
            }
            //Debug.Log("Loaded: " + gameObject.name);
        }
        //else Debug.LogWarning("Ignored: " + gameObject.name);
        if(ignoreChildLoad) return;
        for (int i = 0; i < childsConnected.Length; ++i)
        {
            if (childsConnected[i] != null)
            {
                childsConnected[i].GetComponent<SkillTreeButton>().Load();
            }
            else break;
        }
    }
    
}
