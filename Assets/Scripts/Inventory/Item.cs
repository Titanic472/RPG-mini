using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public string Name, Type;
    public int Id = -1, Tier = 0, Level = 0, Amount = 0, EnchantmentId = -1;
    public int[] UpgradePrice = new int[15], Price = new int[15], LevelPriceAdd = new int[15];
    public float LevelPriceModifier = 1f;
    public int EnergyUsage = 1, UpgradeEnergyUsage, MinDefence, UpgradeMinDefence, MaxDefence, UpgradeMaxDefence, Accuracy, UpgradeAccuracy, Evasion, UpgradeEvasion, Mana, UpgradeMana, ManaUsage, UpgradeManaUsage, DamageReduction, UpgradeDamageReduction, Damage, UpgradeDamage, Health, UpgradeHealth, ManaRegen, UpgradeManaRegen, HealthRegen, UpgradeHealthRegen, ManaCost, UpgradeManaCost, ShieldingLevel;
    public float DamageModifier = 1f, UpgradeDamageModifier, DefenceModifier = 1f, UpgradeDefenceModifier, ExperienceModifier = 1f, UpgradeExperienceModifier, HealthModifier = 1f, UpgradeHealthModifier, SpeedModifier = 1f, UpgradeSpeedModifier, ManaModifier = 1f, UpgradeManaModifier, DamageResistance, UpgradeDamageResistance;
    public bool Is2Handed = false, CanBeUsedOutsideBattle = false;
    int StatsCount = 0;

    public virtual void Use(ref int Argument){}

    public virtual void Use(){}

    public virtual void LevelSet(int LevelToSet){//Used only after loading inventory
        CreateUpgradePrice();
        Level = 1;
        for(int i = 1; i<LevelToSet; ++i) Upgrade(false);
    }

    public void CreateUpgradePrice(){
        for(int i = 0; i<15; ++i)UpgradePrice[i] = Price[i];
        for(int i = 1; i<15; ++i)Price[i] = Price[i]/3;
        IncreaseUpgradePrice();
    }

    public virtual void Upgrade(bool UseMoney = true){
        ++Level;
        int AdditionalUpgrade = 0;
        if(Level%(6-Tier)==0) AdditionalUpgrade = 1;
        for(int i = 1; i<15; ++i){
            Price[i] += Convert.ToInt32(UpgradePrice[i]/3f);
            if(i<14)Price[i] += Convert.ToInt32((UpgradePrice[i+1]*1000/3f)%1000);
            if(Price[i]>=1000){
                Price[i+1] += Price[i]/1000;
                Price[i] = Price[i]%1000;
            }
            if(Price[0]<i && Price[i]>0) Price[0] = i;
        }
        if(UseMoney)Player.Instance.MoneyRemove(UpgradePrice);

        EnergyUsage += UpgradeEnergyUsage*(1+AdditionalUpgrade);
        MinDefence += UpgradeMinDefence*(1+AdditionalUpgrade);
        MaxDefence += UpgradeMaxDefence*(1+AdditionalUpgrade);
        Mana += UpgradeMana*(1+AdditionalUpgrade);
        DamageResistance += UpgradeDamageResistance*(1+AdditionalUpgrade);
        DamageReduction += UpgradeDamageReduction*(1+AdditionalUpgrade);
        Damage += UpgradeDamage*(1+AdditionalUpgrade);
        ManaUsage += UpgradeManaUsage*(1+AdditionalUpgrade);
        DamageModifier += UpgradeDamageModifier*(1+AdditionalUpgrade);
        DefenceModifier += UpgradeDefenceModifier*(1+AdditionalUpgrade);
        ExperienceModifier += UpgradeExperienceModifier*(1+AdditionalUpgrade);
        HealthModifier += UpgradeHealthModifier*(1+AdditionalUpgrade);
        Health += UpgradeHealth*(1+AdditionalUpgrade);
        SpeedModifier += UpgradeSpeedModifier*(1+AdditionalUpgrade);
        ManaModifier += UpgradeManaModifier*(1+AdditionalUpgrade);
        ManaRegen += UpgradeManaRegen*(1+AdditionalUpgrade);
        HealthRegen += UpgradeHealthRegen*(1+AdditionalUpgrade);
        ManaCost += UpgradeManaCost*(1+AdditionalUpgrade);
        Accuracy += UpgradeAccuracy*(1+AdditionalUpgrade);
        Evasion += UpgradeEvasion*(1+AdditionalUpgrade);

        if(Tier*5>Level){//Calculate upgrade price for next level if level limit not reached
            IncreaseUpgradePrice();
        }
        Player.Instance.UpdateAllStats();
    }

    private void IncreaseUpgradePrice(){
        int Cont = 0;
        for(int i = 1; i<15; ++i){
            float NewPrice = (UpgradePrice[i] + LevelPriceAdd[i]) * LevelPriceModifier;
            UpgradePrice[i] = Convert.ToInt32(NewPrice);
            UpgradePrice[i] += Cont;
            Cont = 0;
            if(i>1){
                UpgradePrice[i-1] += Convert.ToInt32(NewPrice*1000)%1000;
                if(UpgradePrice[i-1]>=1000){
                UpgradePrice[i] += UpgradePrice[i-1]/1000;
                UpgradePrice[i-1] = UpgradePrice[i-1]%1000;
                }
            }
            if(UpgradePrice[i]>=1000){
                Cont = UpgradePrice[i]/1000;
                UpgradePrice[i] = UpgradePrice[i]%1000;
            }
            if(UpgradePrice[0]<i && UpgradePrice[i]>0) UpgradePrice[0] = i;
        }
    }

    public bool CanUpgrade(){
        if(Player.Instance.Money[0]>UpgradePrice[0])return true;
        for(int i = Player.Instance.Money[0]; i>0; --i){
            if(Player.Instance.Money[i]>UpgradePrice[i]) return true;
            else if(Player.Instance.Money[i]<UpgradePrice[i])return false;
        }
        if(Player.Instance.Money[1]==UpgradePrice[1]) return true;
        else return false;
    }

    public virtual string GetUpgradePrice(){
        string PriceText = UpgradePrice[UpgradePrice[0]] + "";
        if(UpgradePrice[0]>1){
            if(UpgradePrice[UpgradePrice[0]-1]>=100 || UpgradePrice[UpgradePrice[0]-1]==0){
                PriceText += ".";
            }
            else if(UpgradePrice[UpgradePrice[0]-1]>=10){
                PriceText += ".0";
            }
            else{
                PriceText += ".00";
            }
            PriceText += UpgradePrice[UpgradePrice[0]-1];
        }
        PriceText += Player.Instance.TextFormat(UpgradePrice[0]) + "<sprite=\"C-coin\" name=\"Coin\">";
        return PriceText;
    }

    public virtual string GetSellPrice(){
        string PriceText = Price[Price[0]] + "";
        if(Price[0]>1){
            if(Price[Price[0]-1]>=100 || Price[Price[0]-1]==0){
                PriceText += ".";
            }
            else if(Price[Price[0]-1]>=10){
                PriceText += ".0";
            }
            else{
                PriceText += ".00";
            }
            PriceText += Price[Price[0]-1];
        }
        PriceText += Player.Instance.TextFormat(Price[0]) + "<sprite=\"C-coin\" name=\"Coin\">";
        return PriceText;
    }

    public virtual string GetDescription(){
        return Language_Changer.Instance.GetText(Name + "_Description", "Items");
    }

    public virtual void GetStats(ref string Stats1, ref string Stats2, bool UpgradeInformation = false){
        if(Level >= Tier*5)UpgradeInformation = false;
        StatsCount = 0;
        Stats1 = "";
        Stats2 = "";
        int AdditionalUpgrade = 1;
        if((Level+1)%(6-Tier)==0) AdditionalUpgrade = 2;
        if(MaxDefence!=0)StatsTextSet(MinDefence, UpgradeMinDefence*AdditionalUpgrade, "Defence", ref Stats1, ref Stats2, UpgradeInformation, "-" + MaxDefence, "-" + (MaxDefence+UpgradeMaxDefence*AdditionalUpgrade));
        if(DamageReduction!=0)StatsTextSet(DamageReduction, UpgradeDamageReduction*AdditionalUpgrade, "Defence", ref Stats1, ref Stats2, UpgradeInformation);
        if(Damage!=0)StatsTextSet(Damage, UpgradeDamage*AdditionalUpgrade, "Damage", ref Stats1, ref Stats2, UpgradeInformation);
        if(ManaUsage!=0)StatsTextSet(ManaUsage, UpgradeManaUsage*AdditionalUpgrade, "Mana", ref Stats1, ref Stats2, UpgradeInformation);
        if(DamageResistance!=0)StatsTextSet(DamageResistance, UpgradeDamageResistance*AdditionalUpgrade, "DamageResistance", ref Stats1, ref Stats2, UpgradeInformation);
        if(DamageModifier!=1f)StatsTextSet(DamageModifier, UpgradeDamageModifier*AdditionalUpgrade, "Damage", ref Stats1, ref Stats2, UpgradeInformation);
        if(DefenceModifier!=1f)StatsTextSet(DefenceModifier, UpgradeDefenceModifier*AdditionalUpgrade, "Defence", ref Stats1, ref Stats2, UpgradeInformation);
        if(ExperienceModifier!=1f)StatsTextSet(ExperienceModifier, UpgradeExperienceModifier*AdditionalUpgrade, "Arrow", ref Stats1, ref Stats2, UpgradeInformation);
        if(HealthModifier!=1f)StatsTextSet(HealthModifier, UpgradeHealthModifier*AdditionalUpgrade, "Health", ref Stats1, ref Stats2, UpgradeInformation);
        if(Health!=0)StatsTextSet(Health, UpgradeHealth*AdditionalUpgrade, "Health", ref Stats1, ref Stats2, UpgradeInformation);
        if(SpeedModifier!=1f)StatsTextSet(SpeedModifier, UpgradeSpeedModifier*AdditionalUpgrade, "Speed", ref Stats1, ref Stats2, UpgradeInformation);
        if(Mana!=0)StatsTextSet(Mana, UpgradeMana*AdditionalUpgrade, "Mana", ref Stats1, ref Stats2, UpgradeInformation);
        if(ManaModifier!=1f)StatsTextSet(ManaModifier, UpgradeManaModifier*AdditionalUpgrade, "Mana", ref Stats1, ref Stats2, UpgradeInformation);
        if(ManaRegen!=0)StatsTextSet(ManaRegen, UpgradeManaRegen*AdditionalUpgrade, "Mana", ref Stats1, ref Stats2, UpgradeInformation);
        if(HealthRegen!=0)StatsTextSet(HealthRegen, UpgradeHealthRegen*AdditionalUpgrade, "HealthRegen", ref Stats1, ref Stats2, UpgradeInformation);
        if(ManaCost!=0)StatsTextSet(ManaCost, UpgradeManaCost*AdditionalUpgrade, "Mana", ref Stats1, ref Stats2, UpgradeInformation);
        if(Accuracy!=0)StatsTextSet(Accuracy, UpgradeAccuracy*AdditionalUpgrade, "Accuracy", ref Stats1, ref Stats2, UpgradeInformation);
        if(Evasion!=0)StatsTextSet(Evasion, UpgradeEvasion*AdditionalUpgrade, "Evasion", ref Stats1, ref Stats2, UpgradeInformation);
    }

    public void StatsTextSet(float Stats, float UpgradeStats, string ImageName, ref string StatsText, ref string StatsText2, bool UpgradeInformation){
        if(StatsCount<3){
            StatsText += "\n<sprite=\"Stats\" name=\"" + ImageName + "\">" + Convert.ToInt32(Stats*100) + "%";
            if(UpgradeInformation) StatsText += "<sprite=\"Stats\" name=\"Arrow\">" + Convert.ToInt32((Stats + UpgradeStats)*100) + "%";
        }
        else{
            StatsText2 += "\n<sprite=\"Stats\" name=\"" + ImageName + "\">" + Convert.ToInt32(Stats*100) + "%";
            if(UpgradeInformation) StatsText2 += "<sprite=\"Stats\" name=\"Arrow\">" + Convert.ToInt32((Stats + UpgradeStats)*100) + "%";
        }
        ++StatsCount;
    }

    public void StatsTextSet(int Stats, int UpgradeStats, string ImageName, ref string StatsText, ref string StatsText2, bool UpgradeInformation, string AddStats = "", string AddUpgradeStats = ""){
        if(StatsCount<3){
            StatsText += "\n<sprite=\"Stats\" name=\"" + ImageName + "\">" + Stats + AddStats;
            if(UpgradeInformation) StatsText += "<sprite=\"Stats\" name=\"Arrow\">" + (Stats + UpgradeStats) + AddUpgradeStats;
        }
        else{
            StatsText2 += "\n<sprite=\"Stats\" name=\"" + ImageName + "\">" + Stats + AddStats;
            if(UpgradeInformation) StatsText2 += "<sprite=\"Stats\" name=\"Arrow\">" + (Stats + UpgradeStats) + AddUpgradeStats;
        }
        ++StatsCount;
    }

    public virtual void OnAttack(){}

    public virtual void OnReceiveDamage(ref int Argument){}

    public virtual void AfterReceiveDamage(){}

    public virtual void OnPotionUse(){}

    public virtual void OnItemUse(){}//Finish after adding items

    public virtual void OnEnemyKill(){}

    public virtual void OnPlayerDefeat(){}

    public virtual void OnActiveSkillUse(){}

    public virtual void OnNextTurn(){}

    public virtual void OnCrit(){}

    public virtual void OnAvoid(){}

    public virtual void Save(ref int Index1, ref int Index2, ref int Index3){
        Index1 = Id;
        if(Type == "Potion" || Type == "Consumable")Index2 = Amount;
        else Index2 = Level;
        Index3 = EnchantmentId;
    }

    public virtual void Load(int Index2, int Index3){
        if(Type == "Potion" || Type == "Consumable")Amount = Index2;
        else LevelSet(Index2);
        EnchantmentId = Index3;
    }
}
