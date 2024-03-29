using System.Collections;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class Player : Entity
{
    public TextMeshProUGUI Money_Text, Money_Text2;
    public Experience ExperienceBar;
    public Skills SkillManager;
    public Mob mob;
    public Game game; 
    public SpeedEnergy speedEnergy;
    public ManaOverdrain ManaOverdrain;
    public GameObject SelfSprite2;
    public int LevelHPBoost, RightHandDamage, LeftHandDamage, BaseDamage, MaxDefence, MinDefence, SkillPoints, MaxAvoidChance, MaxCritChance, DamageReduction, MaxSpeedEnergy, BrutalityStreak_MobAvoidChance, Parrying_Chance, Parrying_DamagePercent;//Damage Reduction - shield
    public int[] Money = new int[15], Experience = new int[25], NewLevelXP = new int[25]; //0 - max id
    public int[] Inventory_Items = new int[90];//0 - id, 1 - lvl, 2 - enchants
    public float[] CollectedData = new float[2];
    public float HealthModifier, ManaModifier, DamageModifier, DefenceModifier, ExperienceModifier, SpeedModifier, BaseHealthModifier, BaseManaModifier, BaseManaCost, ManaCost, BaseAttackSpeed, AttackSpeed, DamageResistance, BaseDamageResistance, PriceModifier, SpeedEnergy, BrutalityStreak_AddDamage, BrutalityStreak_AddDamageAll, Parrying_RemovePercent, Parrying_ChanceAll;
    public bool BlockActive = false, Overdrained = false;
    public Dictionary<string, int> Skills = new Dictionary<string, int>();
    public Dictionary<string, int> Head = new Dictionary<string, int>();
    public Dictionary<string, int> Chest = new Dictionary<string, int>();
    public Dictionary<string, int> Legs = new Dictionary<string, int>();
    public Dictionary<string, int> LeftHand = new Dictionary<string, int>();
    public Dictionary<string, int> RightHand = new Dictionary<string, int>();
    public Dictionary<string, int> Ring1 = new Dictionary<string, int>();
    public Dictionary<string, int> Ring2 = new Dictionary<string, int>();
    public Dictionary<string, int> Inventory_Consumables = new Dictionary<string, int>();
    public GameObject Hat, Chestplate, Boots, LeftHandWeapon, RightHandWeapon, Trinket1, Trinket2;
    public static Player Instance;


    void Start(){
     Instance = this;
     HealthModifier = 1.0f;
     ManaModifier = 1.0f;
     HealthRegen = 0;
     ManaRegen = 0;
     BaseHealthModifier = 1;
     BaseManaModifier = 1;
     BaseManaCost = 1;
     ManaCost = 1;
     DamageModifier = 1.0f;
     DefenceModifier = 1.0f;
     ExperienceModifier = 1.0f;
     SpeedModifier = 1.0f;
     Health = 20;
     MaxHealth = 20;
     Mana = 0;
     MaxMana = 0;
     Level = 0;
     LevelHPBoost = 5;
     RightHandDamage = 1;
     LeftHandDamage = 1;
     BaseDamage = 1;
     Experience[0] = 1;
     NewLevelXP[0] = 1;
     NewLevelXP[1] = 100;
     MaxDefence = 0;
     MinDefence = 0;
     BaseAttackSpeed = 0;
     AttackSpeed = 1.0f;
     SkillPoints = 1;
     DamageResistance = 0;
     BaseDamageResistance = 0;
     MaxAvoidChance = 40;
     MaxCritChance = 40;
     Money[0] = 1;
     DamageReduction = 0;
     MaxSpeedEnergy = 5;
     BuffsDamageModifier = 1; 
     BuffsDamageTakenModifier = 1;
     Parrying_RemovePercent = 1;

     for(int i = 0; i<90; ++i)Inventory_Items[i] = -1;
     for(int i = 0; i<10; ++i) for(int j = 0; j<5;++j) StatusEffects[i, j] = -1;

     Skills.Add("Mana", 0);
     Skills.Add("Evasion", 0);
     Skills.Add("Accuracy", 0);
     Skills.Add("BaseMana", 0);
     Skills.Add("BaseEvasion", 0);
     Skills.Add("BaseAccuracy", 0);
     Skills.Add("BaseHealth", 0);
     Skills.Add("BaseHealthRegen", 0);
     Skills.Add("BaseManaRegen", 0);
     Skills.Add("WeaponSkillChance", 5);
     
     Head.Add("ID", -1);
     Head.Add("Level", 0);
     Head.Add("Tier", 0);
     Head.Add("MinDefence", 0);
     Head.Add("MaxDefence", 0);
     Head.Add("Accuracy", 0);
     Head.Add("Evasion", 0);
     Head.Add("Mana", 0);
     Head.Add("DamageResistance", 0);

     Chest.Add("ID", -1);
     Chest.Add("Level", 0);
     Chest.Add("Tier", 0);
     Chest.Add("MinDefence", 0);
     Chest.Add("MaxDefence", 0);
     Chest.Add("Accuracy", 0);
     Chest.Add("Evasion", 0);
     Chest.Add("Mana", 0);
     Chest.Add("DamageResistance", 0);

     Legs.Add("ID", -1);
     Legs.Add("Level", 0);
     Legs.Add("Tier", 0);
     Legs.Add("MinDefence", 0);
     Legs.Add("MaxDefence", 0);
     Legs.Add("Accuracy", 0);
     Legs.Add("Evasion", 0);
     Legs.Add("Mana", 0);
     Legs.Add("DamageResistance", 0);
     
     RightHand.Add("Damage", 0);
     RightHand.Add("Speed", 1);
     RightHand.Add("ID", -1);
     RightHand.Add("Level", 0);
     RightHand.Add("Tier", 0);
     RightHand.Add("Is2Handed", 0);
     RightHand.Add("Accuracy", 0);
     RightHand.Add("Evasion", 0);
     RightHand.Add("ManaUsage", 0);
     RightHand.Add("EnchantId", -1);

     LeftHand.Add("Damage", 0);
     LeftHand.Add("DamageReduction", 0);
     LeftHand.Add("Speed", 1);
     LeftHand.Add("ID", -1);
     LeftHand.Add("Level", 0);
     LeftHand.Add("Tier", 0);
     LeftHand.Add("IsActive", 1);
     LeftHand.Add("Accuracy", 0);
     LeftHand.Add("Evasion", 0);
     LeftHand.Add("ManaUsage", 0);
     LeftHand.Add("EnchantId", -1);

     Ring1.Add("AdditionalDamage", 0);
     Ring1.Add("DamageModifier", 100);
     Ring1.Add("DefenceModifier", 100);
     Ring1.Add("ExperienceModifier", 100);
     Ring1.Add("ID", -1);
     Ring1.Add("Level", 0);
     Ring1.Add("Tier", 0);
     Ring1.Add("Health", 0);
     Ring1.Add("HealthModifier", 100);
     Ring1.Add("SpeedModifier", 100);
     Ring1.Add("Accuracy", 0);
     Ring1.Add("Evasion", 0);
     Ring1.Add("Mana", 0);
     Ring1.Add("ManaModifier", 100);
     Ring1.Add("ManaRegen", 0);
     Ring1.Add("HealthRegen", 0);
     Ring1.Add("ManaCost", 100);
     Ring1.Add("DamageResistance", 0);

     Ring2.Add("AdditionalDamage", 0);
     Ring2.Add("DamageModifier", 100);
     Ring2.Add("DefenceModifier", 100);
     Ring2.Add("ExperienceModifier", 100);
     Ring2.Add("ID", -1);
     Ring2.Add("Level", 0);
     Ring2.Add("Tier", 0);
     Ring2.Add("Health", 0);
     Ring2.Add("HealthModifier", 100);
     Ring2.Add("SpeedModifier", 100);
     Ring2.Add("Accuracy", 0);
     Ring2.Add("Evasion", 0);
     Ring2.Add("Mana", 0);
     Ring2.Add("ManaModifier", 100);
     Ring2.Add("ManaRegen", 0);
     Ring2.Add("HealthRegen", 0);
     Ring2.Add("ManaCost", 100);
     Ring2.Add("DamageResistance", 0);

     Inventory_Consumables.Add("Healing_Potion", 1);
     Inventory_Consumables.Add("Mana_Potion", 0);
     Inventory_Consumables.Add("Health_Regeneration_Potion", 0);
     Inventory_Consumables.Add("Mana_Regeneration_Potion", 0);
     Inventory_Consumables.Add("Ironskin_Potion", 0);
    }

    public void SpriteSwap(){
        (SelfSprite, SelfSprite2) = (SelfSprite2, SelfSprite);
    }

    public void UpdateModifiers(){
     HealthModifier = BaseHealthModifier * ((Ring1["HealthModifier"] + Ring2["HealthModifier"])/2f*0.01f);
     ManaModifier = BaseManaModifier * ((Ring1["ManaModifier"] + Ring2["ManaModifier"])/2f*0.01f);
     ManaCost = BaseManaCost * ((Ring1["ManaCost"] + Ring2["ManaCost"])/2f*0.01f);
     DamageModifier = (Ring1["DamageModifier"] + Ring2["DamageModifier"])/2f*0.01f;
     DefenceModifier = (Ring1["DefenceModifier"] + Ring2["DefenceModifier"])/2f*0.01f;
     ExperienceModifier = (Ring1["ExperienceModifier"] + Ring2["ExperienceModifier"])/2f*0.01f;
     SpeedModifier = Ring1["SpeedModifier"] * Ring2["SpeedModifier"];
     DamageResistance = BaseDamageResistance + Ring1["DamageResistance"]*0.01f + Ring2["DamageResistance"]*0.01f + Head["DamageResistance"]*0.01f + Chest["DamageResistance"]*0.01f + Legs["DamageResistance"]*0.01f;
    }

    public void UpdateStats(){
     Skills["Mana"] = Ring1["Mana"] + Ring2["Mana"] + Chest["Mana"] + Head["Mana"] + Legs["Mana"];
     Skills["Evasion"] = Skills["BaseEvasion"] + Ring1["Evasion"] + Ring2["Evasion"] + Chest["Evasion"] + Head["Evasion"] + Legs["Evasion"] + LeftHand["Evasion"] + RightHand["Evasion"];
     Skills["Accuracy"] = Skills["BaseAccuracy"] + Ring1["Accuracy"] + Ring2["Accuracy"] + Chest["Accuracy"] + Head["Accuracy"] + Legs["Accuracy"] + LeftHand["Accuracy"] + RightHand["Accuracy"];
     ManaRegen = Skills["BaseManaRegen"] + Ring1["ManaRegen"] + Ring2["ManaRegen"];
     HealthRegen = Skills["BaseHealthRegen"] + Ring1["HealthRegen"] + Ring2["HealthRegen"];
     MaxHealth = DevTools.Instance.Health + Convert.ToInt32(Math.Ceiling(HealthModifier*(20f+Level*LevelHPBoost+Skills["BaseHealth"])));
     MaxMana = Convert.ToInt32(Math.Ceiling(ManaModifier*(Skills["Mana"] + Skills["BaseMana"])));
     AttackSpeed = (BaseAttackSpeed+1)*SpeedModifier;
     RightHandDamage = Convert.ToInt32(Math.Ceiling(DamageModifier*(BaseDamage+RightHand["Damage"]+Ring1["AdditionalDamage"] + Ring2["AdditionalDamage"])));
     LeftHandDamage = Convert.ToInt32(Math.Ceiling(DamageModifier*(BaseDamage+LeftHand["Damage"]+Ring1["AdditionalDamage"] + Ring2["AdditionalDamage"])));
     MinDefence = Convert.ToInt32(Math.Ceiling(DefenceModifier*(Head["MinDefence"] + Legs["MinDefence"] + Chest["MinDefence"])));
     MaxDefence = Convert.ToInt32(Math.Ceiling(DefenceModifier*(Head["MaxDefence"] + Legs["MaxDefence"] + Chest["MaxDefence"])));
    }

    public void Evasion_reload(){
        Skills["Evasion"] = Skills["BaseEvasion"] + Ring1["Evasion"] + Ring2["Evasion"] + Chest["Evasion"] + Head["Evasion"] + Legs["Evasion"] + LeftHand["Evasion"] + RightHand["Evasion"];
    }

    public void Accuracy_reload(){
        Skills["Accuracy"] = Skills["BaseAccuracy"] + Ring1["Accuracy"] + Ring2["Accuracy"] + Chest["Accuracy"] + Head["Accuracy"] + Legs["Accuracy"] + LeftHand["Accuracy"] + RightHand["Accuracy"];
    }

    public void Mana_reload(){
        Skills["Mana"] = Ring1["Mana"] + Ring2["Mana"] + Chest["Mana"] + Head["Mana"] + Legs["Mana"];
        MaxMana = Convert.ToInt32(Math.Ceiling(ManaModifier*(Skills["Mana"] + Skills["BaseMana"])));
        StartCoroutine(ManaBar.Mana_update());
    }

    public void Health_reload(){
        MaxHealth = Convert.ToInt32(Math.Ceiling(HealthModifier*(20f+Level*LevelHPBoost+Skills["BaseHealth"])));
        StartCoroutine(HealthBar.HP_update());
    }

    public void HealthRegen_reload(){
        HealthRegen = Skills["BaseHealthRegen"] + Ring1["HealthRegen"] + Ring2["HealthRegen"];
    }

    public void ManaRegen_reload(){
        ManaRegen = Skills["BaseManaRegen"] + Ring1["ManaRegen"] + Ring2["ManaRegen"];
    }

    public void ManaModifier_reload(){
        ManaModifier = BaseManaModifier * Ring1["ManaModifier"]*0.01f * Ring2["ManaModifier"]*0.01f;
        Mana_reload();
    }

    public void ManaCost_reload(){
        ManaCost = BaseManaCost * Ring1["ManaCost"]*0.01f * Ring2["ManaCost"]*0.01f;
    }

    public void HealthModifier_reload(){
        HealthModifier = BaseHealthModifier * Ring1["HealthModifier"]*0.01f * Ring2["HealthModifier"]*0.01f;
        Health_reload();
    }

    public void AttackSpeed_reload(){
        AttackSpeed = (BaseAttackSpeed+1)*SpeedModifier;
    }

    public void DamageResistance_reload(){
        DamageResistance = BaseDamageResistance + Ring1["DamageResistance"]*0.01f + Ring2["DamageResistance"]*0.01f;
    }

    public void Heal(float Modifier = 1f){
        if(Health != MaxHealth) --Inventory_Consumables["Healing_Potion"];
        CollectedData[0] = CollectedData[0]+((float)Health/(float)MaxHealth-CollectedData[0])/++CollectedData[1];
        if(!Fight.InBattle){
            if(Fight.EffectsManager.GetEffect(10, this))Modifier*=0.8f;
            if(Fight.EffectsManager.GetEffect(9, this))Modifier*=0.5f;
        }
        if(MaxHealth - Health > Convert.ToInt32((float)MaxHealth/2*Modifier)){
            Health += Convert.ToInt32((float)MaxHealth/2*Modifier); 
        }
        else{
            Health = MaxHealth;
        }
        StartCoroutine(HealthBar.HP_update());
    }

    public void ManaRestore(){
        if(!Overdrained){
            if(Mana != MaxMana) --Inventory_Consumables["Mana_Potion"];
            if(Mana < MaxMana/2){
                Mana+=MaxMana/2; 
            }
            else{
                Mana = MaxMana;
            }
        }
        else {
            switch(SkillManager.ManaOverdrain_Potion){
                case 1:
                    ManaOverdrain.Remove(1);
                    break;
                case 2:
                    ManaOverdrain.Remove(2);
                    break;
                case 3:
                    ManaOverdrain.Remove(3);
                    break;
                default:
                    break;
            }
        }
        StartCoroutine(ManaBar.Mana_update());
    }

    public void Health_Regenerate(){
        if(HealthRegen==0 || Health == MaxHealth) return;
        if(Health+HealthRegen>MaxHealth)SelfSprite.GetComponent<F_Text_Creator>().CreateText_Green(MaxHealth-Health + "");
        else SelfSprite.GetComponent<F_Text_Creator>().CreateText_Green(HealthRegen + "");
        Health += HealthRegen;
        if(Health>MaxHealth) Health = MaxHealth;
    }

    public void Mana_Regenerate(){
        if(ManaRegen!=0 && !Overdrained){
        Mana += ManaRegen;
        if(Mana>MaxMana) Mana = MaxMana;
        StartCoroutine(ManaBar.Mana_update());
        }
    }

    public void Mana_Use(int Amount){
        Mana -= Amount;
        if(Mana<0){
            float Percent = 0;
            switch(SkillManager.ManaOverdrain_Perc){
                case 1:
                    Percent = 15f;
                    break;
                case 2:
                    Percent = 20f;
                    break;
                case 3:
                    Percent = 25f;
                    break;
                default:
                    Percent = 10f;
                    break;
            }
            ManaOverdrain.Add(Convert.ToInt32(Math.Ceiling(((float)Mana*(-1)/(float)MaxMana*100f)/Percent)));
            Mana = 0;
        }
        StartCoroutine(ManaBar.Mana_update());
    }

    public void MoneyRemove(int[] Amount){
        for(int i = 1; i<15;++i)Money[i]-=Amount[i];
        Money_Reorganise(1);
    }

    public void MoneyManager(string key, int Amount = 0, int Modifier = 1){
        if(key == "Add"){
            Money[Modifier] += Amount;
            Money_Reorganise(Modifier);
        }
        if(key == "Remove"){
            Money[Modifier] -= Amount;
            Money_Reorganise(Modifier);
        }
        if(key == "Update"){
            if(Money[0]<=1){
                Money_Text.text = Money[Money[0]] + TextFormat(Money[0]);
                Money_Text2.text = Money[Money[0]] + TextFormat(Money[0]) + "<sprite=\"C-coin\" name=\"Coin\">";
            }
            else{
                if(Money[Money[0]-1]>=100 || Money[Money[0]-1]==0){
                    Money_Text.text = Money[Money[0]] + "." + Money[Money[0]-1] + TextFormat(Money[0]);
                    Money_Text2.text = Money[Money[0]] + "." + Money[Money[0]-1] + TextFormat(Money[0]) + "<sprite=\"C-coin\" name=\"Coin\">";
                }
                else if(Money[Money[0]-1]>=10){
                    Money_Text.text = Money[Money[0]] + ".0" + Money[Money[0]-1] + TextFormat(Money[0]);
                    Money_Text2.text = Money[Money[0]] + ".0" + Money[Money[0]-1] + TextFormat(Money[0]) + "<sprite=\"C-coin\" name=\"Coin\">";
                }
                else{
                    Money_Text.text = Money[Money[0]] + ".00" + Money[Money[0]-1] + TextFormat(Money[0]);
                    Money_Text2.text = Money[Money[0]] + ".00" + Money[Money[0]-1] + TextFormat(Money[0]) + "<sprite=\"C-coin\" name=\"Coin\">";
                }
            }
        }
    }

    public string TextFormat(int Modifier){
        switch(Modifier){
                case 0:
                    return "";
                case 1:
                    return "";
                case 2:
                    return "K";
                case 3:
                    return "M";
                case 4:
                    return "B";
                case 5:
                    return "T";
                case 6:
                    return "Qa";
                case 7:
                    return "Qi";
                case 8:
                    return "Sx";
                case 9:
                    return "Sp";
                case 10:
                    return "Oc";
                case 11:
                    return "No";
                case 12:
                    return "Dc";
                case 13:
                    return "Ud";
                case 14:
                    return "Dd";
                case 15:
                    return "Td";
                case 16:
                    return "Qad";
                case 17:
                    return "Qid";
                case 18:
                    return "Sxd";
                case 19:
                    return "Spd";
                case 20:
                    return "Ocd";
                case 21:
                    return "Nod";
                case 22:
                    return "Vg";
                case 23:
                    return "Uvg";
                default:
                    return "Inf";
            }
    }

    public void Money_Reorganise(int Modifier){
        List_Reorganise(ref Money, Modifier);
        MoneyManager("Update");
    }

    public void Experience_Add(int[] amount, bool IsNewLevel = false){
        if(!IsNewLevel){
            if(Experience[0]<amount[0])Experience[0]=amount[0];
            for(int i = 1; i<25; ++i)Experience[i] += Convert.ToInt32(Math.Floor(ExperienceModifier * amount[i]));
        }
        List_Reorganise(ref Experience, 1, 0, 24);
        StartCoroutine(ExperienceBar.XP_update(IsNewLevel));
        for(int i = NewLevelXP[0];i>0;){
            if(Experience[i]>NewLevelXP[i] || Experience[i]==NewLevelXP[i] && i == 1 || Experience[0]>NewLevelXP[0]){
                Invoke("NewLevel",0.5f);
                break;
            }
            else if(Experience[i]==NewLevelXP[i]) --i;
            else return;
        }
    }

    public void NewLevel(){
        BaseDamage += 1;
        SkillPoints += 2;
        ++Level;
        UpdateStats();
        Health = MaxHealth;
        StartCoroutine(HealthBar.HP_update());
        for(int i = 1; i<25; ++i)Experience[i] -= NewLevelXP[i];
        int Add = 0, Add1 = 0;
        for(int i = 24; i>0; --i){
            if(i>1) Add1 = Convert.ToInt32(Math.Floor(NewLevelXP[i]*1.2f*1000f))%1000;
            NewLevelXP[i] = Convert.ToInt32(Math.Floor(NewLevelXP[i]*1.2f)) + Add;
            Add = Add1;
        }
        SkillManager.SkillPointsCount_Update();
        SaveManager.Instance.SaveAll();
        List_Reorganise(ref Experience, 1, Experience[0], 24);
        List_Reorganise(ref NewLevelXP, 1, NewLevelXP[0], 24);
        Experience_Add(new int[25], IsNewLevel:true);
    }

    public void List_Reorganise(ref int[] List, int Modifier, int MaxModifier = 0, int MaxAllowedModifier = 14){
        if(List[Modifier]>0 && List[0]<Modifier)List[0] = Modifier;
        if(Modifier==MaxAllowedModifier)return;
        if(List[Modifier] >=1000){
            List[Modifier + 1] = Convert.ToInt32(List[Modifier]/1000);
            List[Modifier] = List[Modifier]%1000;
            if(Modifier+1>List[0]) List[0] = Modifier+1;
        }
        if(List[0]>Modifier && List[Modifier+1]>=1000) List_Reorganise(ref List, Modifier+1, MaxModifier, MaxAllowedModifier);
        if(List[Modifier] < 0){
            List[Modifier + 1] -= Convert.ToInt32((List[Modifier]+1)/1000+1);
            List[Modifier] += 1000*Convert.ToInt32((List[Modifier]+1)/1000+1);
        }
        if(List[0]>Modifier && List[Modifier + 1]<=0) List_Reorganise(ref List, Modifier+1, MaxModifier, MaxAllowedModifier);
        if(List[Modifier] > 0 && Modifier>List[0]) List[0] = Modifier;
        if(Modifier == List[0] && List[Modifier] == 0){
            List[0] = Modifier-1;
            if(Modifier-1 > 1) List_Reorganise(ref List, Modifier-1, MaxModifier, MaxAllowedModifier);
        }
        if(Modifier<MaxModifier || List[MaxModifier]>0) List_Reorganise(ref List, Modifier+1, MaxModifier, MaxAllowedModifier);
    }

    public void Respawn(){
        for(int i = 1; i<15;++i)Experience[i] = 0;
        Experience[0] = 1;
        StartCoroutine(ExperienceBar.XP_update(false));
        Health = MaxHealth;
        StartCoroutine(HealthBar.HP_update());
        Mana = MaxMana;
        StartCoroutine(ManaBar.Mana_update());
        ManaOverdrain.Remove(99);
        game.PlayerSprite.transform.position = new Vector3(LocationManager.Instance.RespawnPosition.x, LocationManager.Instance.RespawnPosition.y, 0);
        LocationManager.Instance.SavePosition = new Vector2(LocationManager.Instance.RespawnPosition.x, LocationManager.Instance.RespawnPosition.y);
        LocationManager.Instance.Location = LocationManager.Instance.RespawnLocation;
        LocationManager.Instance.ChangeLocation();
    }

    public void SpeedEnergyAdd(){
        if(AttackSpeed+SpeedEnergy<MaxSpeedEnergy)SpeedEnergy += AttackSpeed;
        else SpeedEnergy = MaxSpeedEnergy;
        speedEnergy.Reorganise();
    }

    public void SpeedEnergyRemove(int Amount){
        SpeedEnergy -= Amount;
        speedEnergy.Reorganise();
    }

    public bool Crit(){
        int Chance = UnityEngine.Random.Range(0, 100);
        if(Chance<Math.Min(MaxCritChance, Skills["Accuracy"]-mob.Evasion)) return true;
        else return false;
    }

    public bool Avoid(){
        int Chance = UnityEngine.Random.Range(0, 100);
        if(Chance<Math.Min(MaxAvoidChance, Skills["Evasion"]-mob.Accuracy)) return true;
        else Chance = UnityEngine.Random.Range(1, 101);
        if(Chance<BuffsAvoidChance) return true;
        else return false;
    }

    public async void GetDamage(int Amount, bool AllowArmor = true, bool IsCrit = false, bool ReloadHP = true){
        bool AllowText = true;
        if(BlockActive){
            int Chance = 0;
            float ReturnDamage = 0;
            switch(SkillManager.BL_Chance){
                case 1:
                    Chance = 70;
                    break;
                case 2:
                    Chance = 80;
                    break;
                case 3:
                    Chance = 95;
                    break;
                default:
                    Chance = 65;
                    break;
            }
            switch(SkillManager.BL_ReturnDamage){
                case 1:
                    ReturnDamage = 0.25f;
                    break;
                case 2:
                    ReturnDamage = 0.35f;
                    break;
                case 3:
                    ReturnDamage = 0.50f;
                    break;
                default:
                    ReturnDamage = 0.20f;
                    break;
            }
            if(Chance > UnityEngine.Random.Range(0, 100)){
                mob.GetDamage(Convert.ToInt32(Math.Ceiling((float)Amount*ReturnDamage)));
                Amount = 0;
                AllowText = false;
                SelfSprite.GetComponent<F_Text_Creator>().CreateText_Red(Language_Changer.Instance.GetText("Blocked"));
            }
        }
        Parrying_ChanceAll += Parrying_Chance;
        Amount = Convert.ToInt32(Math.Floor(Amount*BuffsDamageTakenModifier));
        Amount = Convert.ToInt32(Math.Floor(Amount-Amount*DamageResistance));
        if(AllowArmor){
            if(Amount > 0){
                Amount -= BuffsDefence;
                if(Amount >= 0)DamageBlockedByBuffs += BuffsDefence;
                else DamageBlockedByBuffs += BuffsDefence+Amount;
            }//Uncomment
            /*
            RightHand.OnReceiveDamage(Amount);//For Special Weapons
            LeftHand.OnReceiveDamage(Amount);//Shield
            Hat.OnReceiveDamage(Amount);
            Chestplate.OnReceiveDamage(Amount);
            Boots.OnReceiveDamage(Amount);
            Ring1.OnReceiveDamage(Amount);
            Ring2.OnReceiveDamage(Amount);
            */
            int Defence = UnityEngine.Random.Range(MinDefence, MaxDefence+1);
            Amount -= Defence;
        }
        Amount -= DamageReduction;
        if(Amount<0){
            Amount = 0;
            ReloadHP = false;
        }
        Parrying_ChanceAll += Amount/(float)MaxHealth*Parrying_DamagePercent;
        if(IsCrit && AllowText)SelfSprite.GetComponent<F_Text_Creator>().CreateText_Red(Amount +" Crit!");
        else if(AllowText)SelfSprite.GetComponent<F_Text_Creator>().CreateText_Red(Amount +"");
        Health -= Amount;
        DamageTaken += Amount;
        if(Health<0) Health = 0;
        if(ReloadHP)StartCoroutine(HealthBar.HP_update());
        if(Health==0){
            await Task.Delay(1000);
            game.EndGame();
        }
    }

    public void LeftHandAttack(bool Avoided){
        if(!Avoided){
            int AttackDamage = LeftHandDamage;
            AttackDamage = Convert.ToInt32(Math.Ceiling(AttackDamage*BuffsDamageModifier));
            AttackDamage += Convert.ToInt32(AttackDamage*BrutalityStreak_AddDamageAll);
            BrutalityStreak_AddDamageAll+=BrutalityStreak_AddDamage;
            bool IsCrit = Crit();
            AttackDamage += AttackDamage*Convert.ToInt32(IsCrit);
            mob.GetDamage(AttackDamage, true, IsCrit);
        }
        else BrutalityStreak_AddDamageAll = 0;
        SpeedEnergyRemove(LeftHand["Speed"]);
    }

    public void RightHandAttack(bool Avoided){
        if(!Avoided){
            int AttackDamage = RightHandDamage;
            AttackDamage = Convert.ToInt32(Math.Ceiling(AttackDamage*BuffsDamageModifier));
            AttackDamage += Convert.ToInt32(AttackDamage*BrutalityStreak_AddDamageAll);
            BrutalityStreak_AddDamageAll+=BrutalityStreak_AddDamage;
            bool IsCrit = Crit();
            AttackDamage += AttackDamage*Convert.ToInt32(IsCrit);
            mob.GetDamage(AttackDamage, true, IsCrit);
        }
        else BrutalityStreak_AddDamageAll = 0;
        SpeedEnergyRemove(RightHand["Speed"]);
    }

    public bool Parry(){
        int Chance = UnityEngine.Random.Range(0, 100);
        if(Chance<Parrying_ChanceAll){
            Parrying_ChanceAll -= Parrying_ChanceAll*Parrying_RemovePercent;
            return true;
        }
        else return false;
    }
}
