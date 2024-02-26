using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class HealthBar : MonoBehaviour
{
    public Language_Changer Lang;
    public Entity Target;
    public Image Healthbar;
    public Image Damage;
    public Image Regeneration;
    public TextMeshProUGUI text;
    public bool IsRegenerating, IsGettingDamage;
    
    public void Restart(){
        Healthbar.fillAmount = 1f;
        Regeneration.fillAmount = 1f;
        Damage.fillAmount = 1f;
        text.text = Language_Changer.Instance.GetText("HP") + " " + Target.MaxHealth + "/" + Target.MaxHealth;
    }

    public void Reset(){
        Healthbar.fillAmount = (float)Target.Health/(float)Target.MaxHealth;
        Regeneration.fillAmount = (float)Target.Health/(float)Target.MaxHealth;
        Damage.fillAmount = (float)Target.Health/(float)Target.MaxHealth;
        text.text = Language_Changer.Instance.GetText("HP") + " " + Target.Health + "/" + Target.MaxHealth;
    }

    public IEnumerator HP_update(){
        float a = Target.Health, b = Target.MaxHealth, add = 0, HP, PrevFill;
        text.text = Language_Changer.Instance.GetText("HP") + " " + Target.Health + "/" + Target.MaxHealth;
        HP = a/b;
        PrevFill = Regeneration.fillAmount;
        add = (PrevFill - HP)/50;
        if(HP<PrevFill){//Get Damage
            while(IsRegenerating) yield return new WaitForSeconds(0.01f);
            IsGettingDamage = true;
            PrevFill = Damage.fillAmount;
            Healthbar.fillAmount = HP;
            Regeneration.fillAmount = HP;
            yield return new WaitForSeconds(0.2f);
            for(int i = 0; i<50; ++i){
            Damage.fillAmount = Damage.fillAmount - add;
            yield return new WaitForSeconds(0.003f);
            }
            IsGettingDamage = false;
            //Damage.fillAmount = HP;
        }
        else {
            if(HP!=PrevFill){//Regenerate
                while(IsGettingDamage) yield return new WaitForSeconds(0.01f);
                IsRegenerating = true;
                PrevFill = Healthbar.fillAmount;
                Regeneration.fillAmount = HP;
                Damage.fillAmount = HP;
                for(int i = 0; i<50; ++i){
                Healthbar.fillAmount = Healthbar.fillAmount - add;
                yield return new WaitForSeconds(0.004f);
                }
                IsRegenerating = false;
            }
        //Healthbar.fillAmount = HP;
        }
    }
}
