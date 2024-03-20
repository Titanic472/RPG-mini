using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using UnityEngine;
using TMPro;

public class Language_Changer : MonoBehaviour
{
    public TextMeshProUGUI Return1, Return2, Return3, Return4, Return5, Return6, Shop, Music, Hardcore, Lang, Lang2, Inventory, Fight, Profile, Stats, Skills, Abilities, Sam, Use, Unequip, Equip, YouDied, Quit, Respawn, BattleEnded, Attack, Potions, Items, RunAway, BackToGame, SaveAndQuit, PassiveSkillsTitle;
    private int i = 0;
	public static Language_Changer Instance;
	private string Language = "EN";
	private XmlDocument XmlDoc;
	private string CurrentBranch = "";

    void Start(){
		Instance = this;
		LoadLanguage();
		LanguageUpdate();
    }

    public void Lang_Change(){
        if(i<2)++i;
        else i = 0;
        switch (i){
            case 0:
				Language = "EN";
                break;
            case 1:
				Language = "PL";
                break;
            case 2:
                Language = "UA";
                break;
            default:
                break;
        }
		LoadLanguage();
		LanguageUpdate();
    }

	private void LoadLanguage(string Branch = "Common"){
		TextAsset XmlFile;
		string FilePath = "Languages/" + Language + "/" + Branch;
		XmlFile = Resources.Load<TextAsset>(FilePath);

        if (XmlFile != null){
            XmlDoc = new XmlDocument();
            XmlDoc.LoadXml(XmlFile.text);
			CurrentBranch = Branch;
        }
        else Debug.LogError("XML file not found: " + FilePath + "\nWell, problems... Again\n" + "Branch: " + Branch);
	}

	public string GetText(string Key, string Branch = "Common"){
		if(CurrentBranch!=Branch) LoadLanguage(Branch);
		Key = Key.Replace(' ', '_');
        if (XmlDoc != null){
            XmlNode node = XmlDoc.SelectSingleNode("/texts/" + Key);
            if (node != null) return node.InnerText;
            else{
                Debug.LogError("Key not found in XML: " + Key);
                return Key;
            }
        }
        else{
            Debug.LogError("XML document is not loaded.");
            return "XML document is not loaded.";
        }
    }

    public void LanguageUpdate(){
		Return1.text = GetText("Return");
		Return2.text = GetText("Return");
		Return3.text = GetText("Return");
		Return4.text = GetText("Return");
		Return5.text = GetText("Return");
		Return6.text = GetText("Return");
		Shop.text = GetText("Shop");
		Music.text = GetText("Music");
		Hardcore.text = GetText("Hardcore");
		Lang.text = GetText("Lang");
		Lang2.text = GetText("Lang");
		Inventory.text = GetText("Inventory");
		Fight.text = GetText("Fight");
		Profile.text = GetText("Profile");
		Stats.text = GetText("Stats");
		Skills.text = GetText("Skills");
		Abilities.text = GetText("Abilities");
		Sam.text = GetText("This_Is_Sam");
		Use.text = GetText("Use");
		Unequip.text = GetText("Take_off");
		Equip.text = GetText("Equip");
		YouDied.text = GetText("You_Died");
		Quit.text = GetText("Quit");
		Respawn.text = GetText("Respawn");
		BattleEnded.text = GetText("Battle_Ended");
		BackToGame.text = GetText("Back_to_Game");
		SaveAndQuit.text = GetText("Save_and_Quit");
		PassiveSkillsTitle.text = GetText("Passive_Skills");
		Player.Instance.HealthBar.Reset();
     	Player.Instance.ManaBar.Reset();
    }
}
