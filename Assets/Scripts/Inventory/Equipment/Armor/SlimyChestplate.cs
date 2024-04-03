using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimyChestplate : Chestplate

{
    int XP = 0, NewLevelXP = 100;
    public override void OnEnemyKill(){
        if(Level==25) return;
        XP += 10;
        if(XP>=NewLevelXP){ 
            Upgrade();
        }
    }

    public override string GetDescription(){
        return string.Format(Language_Changer.Instance.GetText(Name + "_Description", "Items"), XP, NewLevelXP);
    }

    public override void LevelSet(int LevelToSet){
        Level = 1;
        for(int i = 1; i<LevelToSet; ++i) Upgrade(false);
    }

    public override void Upgrade(bool RemoveXP = true){
        if(RemoveXP)XP-=NewLevelXP;
        Price[1]+=100;
        if(Level < 5){
            Tier = 1;
            MinDefence += 1;
            MaxDefence += 2;
            NewLevelXP += 100;
            return;
        }
        if(Level < 10){
            Tier = 2;
            MinDefence += 2;
            MaxDefence += 3;
            Accuracy += 2;
            Evasion += 3;
            NewLevelXP += 120;
            return;
        }
        if(Level < 15){
            Tier = 3;
            MinDefence += 3;
            MaxDefence += 5;
            Accuracy += 4;
            Evasion += 6;
            NewLevelXP += 150;
            return;
        }
        if(Level < 20){
            Tier = 4;
            MinDefence += 5;
            MaxDefence += 8;
            Accuracy += 7;
            Evasion += 10;
            Mana += 15;
            DamageResistance += 1;
            NewLevelXP += 200;
            return;
        }
        if(Level < 25){
            Tier = 5;
            MinDefence += 10;
            MaxDefence += 14;
            Accuracy += 15;
            Evasion += 15;
            Mana += 35;
            DamageResistance += 2;
            NewLevelXP += 250;
            return;
        }
        ++Level;
        Player.Instance.UpdateAllStats();
    }

    public override void Save(ref int Index1, ref int Index2, ref int Index3){
        Index1 = Id;
        Index2 = Level;
        Index3 = NewLevelXP;
    }

    public override void Load(int Index2, int Index3){
        Level = Index2;
        NewLevelXP = Index3;
    }
}
