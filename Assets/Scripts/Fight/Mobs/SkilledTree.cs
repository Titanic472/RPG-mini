using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;
using TMPro;

public class SkilledTree : Mob
{   
    
    public override void Attack(){
        StandardAttack();
    }
 
    public override void LootGenerate(){
        Fight.EndBattleWindow.transform.Find("LootItem").GetComponent<SpriteRenderer>().sprite = Fight.InventoryManager.Empty;
        Fight.EndBattle();
        int Reward = UnityEngine.Random.Range(2, 5);
        player.SkillPoints += Convert.ToInt32(Reward); 
        Fight.EndBattleWindow.transform.Find("Experience").GetComponent<TextMeshProUGUI>().text = Reward + " " + Language_Changer.Instance.GetText("Skill_Points");
        player.SkillManager.SkillPointsCount_Update();
    }

    public override async void GetDamage(int Amount, bool AllowArmor = true, bool IsCrit = false){
        if(IsCrit)Amount = 2;
        else Amount = 1;
        if(IsCrit) GetComponent<F_Text_Creator>().CreateText_Red(Amount +" Crit!");
        else GetComponent<F_Text_Creator>().CreateText_Red(Amount +"");
        Health -= Amount;
        if(Health<0) Health = 0;
        StartCoroutine(HealthBar.HP_update());
        if(Health==0){
            await Task.Delay(500);
            Fight.TriggerDeath();
        }
    }
}
