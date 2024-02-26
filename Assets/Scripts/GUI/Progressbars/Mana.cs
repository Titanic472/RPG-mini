using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class Mana : MonoBehaviour
{
    public Language_Changer Lang;
    public Player player;
    public Image Manabar;
    public TextMeshProUGUI text;
    float MANA, PrevFill;
    public float add = 0;
    
    public void Reset(){
        if(player.MaxMana == 0){
            Manabar.fillAmount = 0f;
            return;
        }
        Manabar.fillAmount = (float)player.Mana/(float)player.MaxMana;
        text.text = Language_Changer.Instance.GetText("Mana") + " " + player.Mana + "/" + player.MaxMana;
    }
    public IEnumerator Mana_update(){
        if(player.MaxMana == 0){
            Manabar.fillAmount = 0f;
            yield break;
        }
        float a = player.Mana, b = player.MaxMana;
        text.text = Language_Changer.Instance.GetText("Mana") + " " + player.Mana + "/" + player.MaxMana;
        MANA = a/b;
        PrevFill = Manabar.fillAmount;
        add = (MANA - PrevFill)/50;
        for(int i = 0; i<50; ++i){
            Manabar.fillAmount = Manabar.fillAmount + add;
            yield return new WaitForSeconds(0.003f);
        }
        Manabar.fillAmount = MANA;
    }

    
}
