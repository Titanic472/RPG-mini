using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine.UI;
using UnityEngine;

public class Experience : MonoBehaviour
{
    public Player player;
    public Image XPbar;
    public float XP, PrevFill;
    public int i;
    public float add = 0;
    bool IsRunning;
    
    public IEnumerator XP_update(bool IsNewLevel){
        while(IsRunning){
            yield return new WaitForSeconds(0.005f);
        }
        IsRunning = true;
        if(IsNewLevel) XPbar.fillAmount = 0;
        i = 0;
        float a, b;
        a = player.Experience[player.NewLevelXP[0]];
        b = player.NewLevelXP[player.NewLevelXP[0]];
        if(player.NewLevelXP[0]>1){
            a = a*1000 + player.Experience[player.NewLevelXP[0]-1];
            b = b*1000 + player.NewLevelXP[player.NewLevelXP[0]-1];
        }
        XP = a/b;
        if(XP>1) XP = 1;
        PrevFill = XPbar.fillAmount;
        add = (XP - PrevFill)/50;
        for(int i = 0; i<50; ++i){
            XPbar.fillAmount = XPbar.fillAmount + add;
            yield return new WaitForSeconds(0.003f);
        }
        XPbar.fillAmount = XP;
        IsRunning = false;
    }
}
