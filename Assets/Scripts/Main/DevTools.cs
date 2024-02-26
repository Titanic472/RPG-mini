using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevTools : MonoBehaviour
{   
    public static DevTools Instance;
    public int Resistance = 0, Health = 0;

    void Start(){
        Instance = this;
    }

    public void UseDevTool(int Id){
        switch(Id){
            case 0:
                Health += 9999;
                Player.Instance.UpdateStats();
                Player.Instance.Health = Player.Instance.MaxHealth;
                StartCoroutine(Player.Instance.HealthBar.HP_update());
                break;
            case 1:
                Resistance = 100;
                Player.Instance.BaseDamageResistance += 100;
                Player.Instance.DamageResistance_reload();
                break;
            case 2:
                Player.Instance.BaseDamage += 999;
                Player.Instance.UpdateStats();
                break;
            case 3:
                Player.Instance.MoneyManager("Add", 999, 5);
                break;
            case 4:
                int[] XP = new int[25];
                XP[0] = 4;
                XP[4] = 1;
                Player.Instance.Experience_Add(XP);
                break;
            case 5:
                Player.Instance.SkillPoints += 499;
                break;
            case 6:
                break;
            case 7:
                break;
            case 8:
                break;
        }
    }
}
