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
    public int LevelHPBoost, BaseDamage, SkillPoints, MaxAvoidChance, MaxCritChance, DamageReduction, MaxSpeedEnergy, BrutalityStreak_MobAvoidChance, Parrying_Chance, Parrying_DamagePercent;//Damage Reduction - shield
    public int[] Money = new int[15], Experience = new int[25], NewLevelXP = new int[25]; //0 - max id
    public GameObject[] Inventory = new GameObject[45];
    public float[] CollectedData = new float[2];
    public float HealthModifier, ManaModifier, DamageModifier, DefenceModifier, ExperienceModifier, SpeedModifier, BaseHealthModifier, BaseManaModifier, BaseManaCost, ManaCost, BaseAttackSpeed, AttackSpeed, DamageResistance, BaseDamageResistance, PriceModifier, SpeedEnergy, BrutalityStreak_AddDamage, BrutalityStreak_AddDamageAll, Parrying_RemovePercent, Parrying_ChanceAll;
    public bool BlockActive = false, Overdrained = false;
    public Dictionary<string, int> Skills = new Dictionary<string, int>();
    public GameObject Hat, Chestplate, Boots, LeftHand, RightHand, Trinket1, Trinket2;
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
     BaseDamage = 1;
     Experience[0] = 1;
     NewLevelXP[0] = 1;
     NewLevelXP[1] = 100;
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
    }

    public void SpriteSwap(){
        (SelfSprite, SelfSprite2) = (SelfSprite2, SelfSprite);
    }

    public void UpdateAllStats(){
        //Modifiers
        HealthModifier = BaseHealthModifier * Hat.GetComponent<Item>().HealthModifier*Chestplate.GetComponent<Item>().HealthModifier*Boots.GetComponent<Item>().HealthModifier*LeftHand.GetComponent<Item>().HealthModifier*RightHand.GetComponent<Item>().HealthModifier*Trinket1.GetComponent<Item>().HealthModifier*Trinket2.GetComponent<Item>().HealthModifier;
        ManaModifier = BaseManaModifier * Hat.GetComponent<Item>().ManaModifier*Chestplate.GetComponent<Item>().ManaModifier*Boots.GetComponent<Item>().ManaModifier*LeftHand.GetComponent<Item>().ManaModifier*RightHand.GetComponent<Item>().ManaModifier*Trinket1.GetComponent<Item>().ManaModifier*Trinket2.GetComponent<Item>().ManaModifier;
        ManaCost = BaseManaCost * Hat.GetComponent<Item>().ManaCost*Chestplate.GetComponent<Item>().ManaCost*Boots.GetComponent<Item>().ManaCost*LeftHand.GetComponent<Item>().ManaCost*RightHand.GetComponent<Item>().ManaCost*Trinket1.GetComponent<Item>().ManaCost*Trinket2.GetComponent<Item>().ManaCost;
        DamageModifier = Hat.GetComponent<Item>().DamageModifier * Chestplate.GetComponent<Item>().DamageModifier * Boots.GetComponent<Item>().DamageModifier * LeftHand.GetComponent<Item>().DamageModifier * RightHand.GetComponent<Item>().DamageModifier * Trinket1.GetComponent<Item>().DamageModifier * Trinket2.GetComponent<Item>().DamageModifier;
        DefenceModifier = Hat.GetComponent<Item>().DefenceModifier * Chestplate.GetComponent<Item>().DefenceModifier * Boots.GetComponent<Item>().DefenceModifier * LeftHand.GetComponent<Item>().DefenceModifier * RightHand.GetComponent<Item>().DefenceModifier * Trinket1.GetComponent<Item>().DefenceModifier * Trinket2.GetComponent<Item>().DefenceModifier;
        ExperienceModifier = Hat.GetComponent<Item>().ExperienceModifier * Chestplate.GetComponent<Item>().ExperienceModifier * Boots.GetComponent<Item>().ExperienceModifier * LeftHand.GetComponent<Item>().ExperienceModifier * RightHand.GetComponent<Item>().ExperienceModifier * Trinket1.GetComponent<Item>().ExperienceModifier * Trinket2.GetComponent<Item>().ExperienceModifier;
        SpeedModifier = Hat.GetComponent<Item>().SpeedModifier * Chestplate.GetComponent<Item>().SpeedModifier * Boots.GetComponent<Item>().SpeedModifier * LeftHand.GetComponent<Item>().SpeedModifier * RightHand.GetComponent<Item>().SpeedModifier * Trinket1.GetComponent<Item>().SpeedModifier * Trinket2.GetComponent<Item>().SpeedModifier;
        //Other Stats
        DamageResistance = BaseDamageResistance + Hat.GetComponent<Item>().DamageResistance + Chestplate.GetComponent<Item>().DamageResistance + Boots.GetComponent<Item>().DamageResistance + LeftHand.GetComponent<Item>().DamageResistance + RightHand.GetComponent<Item>().DamageResistance + Trinket1.GetComponent<Item>().DamageResistance + Trinket2.GetComponent<Item>().DamageResistance;
        Skills["Mana"] = Hat.GetComponent<Item>().Mana + Chestplate.GetComponent<Item>().Mana + Boots.GetComponent<Item>().Mana + LeftHand.GetComponent<Item>().Mana + RightHand.GetComponent<Item>().Mana + Trinket1.GetComponent<Item>().Mana + Trinket2.GetComponent<Item>().Mana;
        Skills["Evasion"] = Skills["BaseEvasion"] + Hat.GetComponent<Item>().Evasion + Chestplate.GetComponent<Item>().Evasion + Boots.GetComponent<Item>().Evasion + LeftHand.GetComponent<Item>().Evasion + RightHand.GetComponent<Item>().Evasion + Trinket1.GetComponent<Item>().Evasion + Trinket2.GetComponent<Item>().Evasion;
        Skills["Accuracy"] = Skills["BaseAccuracy"] + Hat.GetComponent<Item>().Accuracy + Chestplate.GetComponent<Item>().Accuracy + Boots.GetComponent<Item>().Accuracy + LeftHand.GetComponent<Item>().Accuracy + RightHand.GetComponent<Item>().Accuracy + Trinket1.GetComponent<Item>().Accuracy + Trinket2.GetComponent<Item>().Accuracy;
        ManaRegen = Skills["BaseManaRegen"] + Hat.GetComponent<Item>().ManaRegen + Chestplate.GetComponent<Item>().ManaRegen + Boots.GetComponent<Item>().ManaRegen + LeftHand.GetComponent<Item>().ManaRegen + RightHand.GetComponent<Item>().ManaRegen + Trinket1.GetComponent<Item>().ManaRegen + Trinket2.GetComponent<Item>().ManaRegen;
        HealthRegen = Skills["BaseHealthRegen"] + Hat.GetComponent<Item>().HealthRegen + Chestplate.GetComponent<Item>().HealthRegen + Boots.GetComponent<Item>().HealthRegen + LeftHand.GetComponent<Item>().HealthRegen + RightHand.GetComponent<Item>().HealthRegen + Trinket1.GetComponent<Item>().HealthRegen + Trinket2.GetComponent<Item>().HealthRegen;
        MaxHealth = DevTools.Instance.Health + Convert.ToInt32(Math.Ceiling(HealthModifier*(20f+Level*LevelHPBoost+Skills["BaseHealth"])));
        MaxMana = Convert.ToInt32(Math.Ceiling(ManaModifier*(Skills["Mana"] + Skills["BaseMana"])));
        AttackSpeed = (BaseAttackSpeed+1)*SpeedModifier;
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
        UpdateAllStats();
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
            }
            RightHand.GetComponent<Item>().OnReceiveDamage(ref Amount);//For Special Weapons
            LeftHand.GetComponent<Item>().OnReceiveDamage(ref Amount);//Shield
            Hat.GetComponent<Item>().OnReceiveDamage(ref Amount);
            Chestplate.GetComponent<Item>().OnReceiveDamage(ref Amount);
            Boots.GetComponent<Item>().OnReceiveDamage(ref Amount);
            Trinket1.GetComponent<Item>().OnReceiveDamage(ref Amount);
            Trinket2.GetComponent<Item>().OnReceiveDamage(ref Amount);
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

    public bool Parry(){
        int Chance = UnityEngine.Random.Range(0, 100);
        if(Chance<Parrying_ChanceAll){
            Parrying_ChanceAll -= Parrying_ChanceAll*Parrying_RemovePercent;
            return true;
        }
        else return false;
    }
}
