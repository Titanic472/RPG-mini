using System.Collections;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class Fight : MonoBehaviour
{
    public SaveManager SaveManager;
    public Player player;
    public Game Game;
    public InventoryManager InventoryManager;
    public GameObject mob, MainMenu, BlueSlime, BrownSlime, PinkSlime, Rat, Nettle, Milk, SkilledTree;
    public Mob MobScript;
    public Skills SkillManager;
    public HealthBar MobHealth;
    public TextMeshProUGUI MobText;
    public GameObject[] Buttons = new GameObject[16], PotionSlots = new GameObject[5], PlayerEffectImages = new GameObject[10], MobEffectImages = new GameObject[10], GameObjects = new GameObject[4];
    public GameObject EndBattleWindow, CoinsText, Mob_MapSprite, BG, ModeSwitch;
    public SlimyArmor SlimyArmor;
    public EffectsManager EffectsManager;
    public int[] Potions = new int[5];
    public bool InBattle = false, AllEntitiesAlive;
    public StopWatch StopWatch;
    public ActiveSkills ActiveSkills;
    public static Fight Instance = null;
    public bool IsVampirismActive = false;
    public float VampirsmHealPerc;

    void Awake(){
        Instance = this;
    }

    public void PotionSlots_Reload(){
        for(int i = 0; i<5; ++i) PotionSlots[i].SetActive(false);
        int Slot = 0;
        if(player.Inventory_Consumables["Healing Potion"]>0){
            PotionSlotActivate(ref Slot, 0);
        }
        if(player.Inventory_Consumables["Mana Potion"]>0){
            PotionSlotActivate(ref Slot, 1);
        }
        if(player.Inventory_Consumables["Health Regeneration Potion"]>0){
            PotionSlotActivate(ref Slot, 2);
        }
        if(player.Inventory_Consumables["Mana Regeneration Potion"]>0){
            PotionSlotActivate(ref Slot, 3);
        }
        if(player.Inventory_Consumables["Ironskin Potion"]>0){
            PotionSlotActivate(ref Slot, 4);
        }
    }

    public void PotionSlotActivate(ref int Slot, int PotionID){
            PotionSlots[Slot].SetActive(true);
            PotionSlots[Slot].transform.Find("Image").GetComponent<Image>().sprite = Game.Potion_Sprites[PotionID];
            Potions[Slot] = PotionID;
            ++Slot;
    }

    public void ReloadEffectImages(){
        for(int i = 0; i<10; ++i){
            if(player.StatusEffects[i, 0] != -1){
                PlayerEffectImages[i].SetActive(true);
                PlayerEffectImages[i].transform.Find("Image").GetComponent<Image>().sprite = Game.Effects_Sprites[player.StatusEffects[i, 0]];
                PlayerEffectImages[i].transform.Find("BGImage").GetComponent<Image>().sprite = Game.Effects_Sprites[player.StatusEffects[i, 0]];
                PlayerEffectImages[i].transform.Find("Image").GetComponent<Image>().fillAmount = (float)player.StatusEffects[i, 1]/(float)player.StatusEffects[i, 2];
            }
            else {
                PlayerEffectImages[i].SetActive(false);
            }
            if(MobScript.StatusEffects[i, 0] != -1 && MobScript.Health>0){
                MobEffectImages[i].SetActive(true);
                MobEffectImages[i].transform.Find("Image").GetComponent<Image>().sprite = Game.Effects_Sprites[MobScript.StatusEffects[i, 0]];
                MobEffectImages[i].transform.Find("BGImage").GetComponent<Image>().sprite = Game.Effects_Sprites[MobScript.StatusEffects[i, 0]];
                MobEffectImages[i].transform.Find("Image").GetComponent<Image>().fillAmount = (float)MobScript.StatusEffects[i, 1]/(float)MobScript.StatusEffects[i, 2];
            }
            else {
                MobEffectImages[i].SetActive(false);
            }
        }
    }

    public async void PlayerPotionUse(int ID){
        if(InBattle)ID = Potions[ID];
        if(InBattle && (MobScript.Health==0 || player.Health == 0)) return;
        if(InBattle) ButtonsActivate(false);
        switch(ID){
            case 0:
                if(player.Health == player.MaxHealth){
                    player.SpeedEnergy+=1;
                    break;
                }
                float Modifier = 1;
                if(EffectsManager.GetEffect(10, player)){
                    if(player.Health > player.MaxHealth/2)MobScript.TriggerHeal(Convert.ToInt32((float)(player.MaxHealth-player.Health)*0.2f));
                    else MobScript.TriggerHeal(Convert.ToInt32((float)player.MaxHealth*0.1f));
                    Modifier=0.8f;
                }
                if(EffectsManager.GetEffect(9, player))Modifier*=0.5f;
                if(player.MaxHealth - player.Health > Convert.ToInt32((float)player.MaxHealth/2*Modifier)) player.SelfSprite.GetComponent<F_Text_Creator>().CreateText_Green(Convert.ToInt32((float)player.MaxHealth/2*Modifier) + "");
                else player.SelfSprite.GetComponent<F_Text_Creator>().CreateText_Green(player.MaxHealth - player.Health + "");
                player.Heal(Modifier);
                if(player.SpeedEnergy<2){
                    if(InBattle)PotionSlots_Reload();
                    await Task.Delay(350);
                }
                break;
            case 1:
                if(player.Mana == player.MaxMana){
                    player.SpeedEnergy+=1;
                    break;
                }
                player.ManaRestore();
                if(player.SpeedEnergy<2){
                    if(InBattle)PotionSlots_Reload();
                    await Task.Delay(350);
                }
                break;
            case 2:
                --player.Inventory_Consumables["Health Regeneration Potion"];
                EffectsManager.Add(0, 5, player);
                break;
            case 3:
                --player.Inventory_Consumables["Mana Regeneration Potion"];
                EffectsManager.Add(1, 5, player);
                break;
            case 4:
                --player.Inventory_Consumables["Ironskin Potion"];
                EffectsManager.Add(2, 8, player);
                EffectsManager.TriggerEffects(0, player);
                break;
            default:
                break;
        }
        if(InBattle){
            PotionSlots_Reload();
            ReloadEffectImages();
            player.SpeedEnergyRemove(1);
            await Task.Delay(100);
            if(player.SpeedEnergy<1)NextTurn();
            else ButtonsActivate(true);
        }
    }

    public void GenerateRandomMob(){
        int Chance;
        if(player.Level>=20){
            Chance = UnityEngine.Random.Range(0, 10);
            if(Chance==9){
                StartBattle(1, 1, 1, 6, false);
                return;
            }
        }
        if(player.Level>=3){
            Chance = UnityEngine.Random.Range(0, 3);
            if(Chance == 2){
                StartBattle(player.Level-2, player.Level+2, 1, 5);
                return;
            }
        }
        Chance = UnityEngine.Random.Range(0, 2);
        if(Chance == 1) StartBattle(player.Level-2, player.Level+2, 1, UnityEngine.Random.Range(2, 5));
        else StartBattle(player.Level-2, player.Level+2, 1, UnityEngine.Random.Range(0, 2));
    }

    public void StartBattle(int MinLevel, int MaxLevel, int Location, int MobID, bool AllowSkilledTree = true){
        AllEntitiesAlive = true;
        InBattle = true;
        player.BrutalityStreak_MobAvoidChance = 0;
        player.BrutalityStreak_AddDamage = 0;
        EffectsManager.TriggerEffects(0, player);
        if(SkillManager.BrutalityStreak_Unlock){
        switch(SkillManager.BrutalityStreak_AvoidChance){
            case 1:
                player.BrutalityStreak_MobAvoidChance = 7;
                break;
            case 2:
                player.BrutalityStreak_MobAvoidChance = 5;
                break;
            default:
                player.BrutalityStreak_MobAvoidChance = 8;
                break;
        }
        switch(SkillManager.BrutalityStreak_EnergySave){
            case 1:
                player.BrutalityStreak_AddDamage = 0.02f;
                break;
            case 2:
                player.BrutalityStreak_AddDamage = 0.03f;
                break;
            case 3:
                player.BrutalityStreak_AddDamage = 0.04f;
                break;
            default:
                player.BrutalityStreak_AddDamage = 0.01f;
                break;
        }}
        if(SkillManager.Parrying_Unlock){
        switch(SkillManager.Parrying_Chance){
            case 1:
                player.Parrying_Chance = 2;
                break;
            case 2:
                player.Parrying_Chance = 3;
                break;
            default:
                player.Parrying_Chance = 1;
                break;
        }
        switch(SkillManager.Parrying_Perc){
            case 1:
                player.Parrying_RemovePercent = 0.9f;
                break;
            case 2:
                player.Parrying_RemovePercent = 0.75f;
                break;
            default:
                player.Parrying_RemovePercent = 1f;
                break;
        }
        switch(SkillManager.Parrying_Damage){
            case 1:
                player.Parrying_DamagePercent = 5;
                break;
            case 2:
                player.Parrying_DamagePercent = 10;
                break;
            default:
                player.Parrying_DamagePercent = 0;
                break;
        }}
        Mob_Create(MinLevel, MaxLevel, Location, MobID, AllowSkilledTree);
        PotionSlots_Reload();
        ReloadEffectImages();
        ActiveSkills.ReloadActiveSkills();
        player.SpeedEnergy = 0;
        player.SpeedEnergyAdd();
        player.BlockActive = false;
        player.DamageTaken = 0;
        player.DamageTakenByBuffs = 0;
        player.DamageBlockedByBuffs = 0;
        Buttons[1].transform.Find("Image").GetComponent<SpriteRenderer>().sprite = InventoryManager.RightHandSlot.transform.Find("Image").GetComponent<SpriteRenderer>().sprite;
        Buttons[1].transform.Find("Image").GetComponent<Animator>().runtimeAnimatorController = InventoryManager.RightHandSlot.transform.Find("Image").GetComponent<Animator>().runtimeAnimatorController;
        Buttons[0].transform.Find("Image").GetComponent<SpriteRenderer>().sprite = InventoryManager.LeftHandSlot.transform.Find("Image").GetComponent<SpriteRenderer>().sprite;
        Buttons[0].transform.Find("Image").GetComponent<Animator>().runtimeAnimatorController = InventoryManager.LeftHandSlot.transform.Find("Image").GetComponent<Animator>().runtimeAnimatorController;
        if(Game.MapMode){
            player.SpriteSwap();
            ModeSwitch.SetActive(false);
            BG.SetActive(true);
            gameObject.SetActive(true);
            GameObjects[0].SetActive(true);
            for(int i = 1; i<4;++i)GameObjects[i].SetActive(false);
        }
    }

    public void Mob_Create(int MinLevel, int MaxLevel, int Location, int MobID, bool AllowSkilledTree){
        string Name = "";
        bool SkilledTreeCreated = false;
        if(AllowSkilledTree || MobID == 96){
            int Chance = UnityEngine.Random.Range(0, 100);
            if(Chance<=player.game.SkilledTreeChance || MobID == 96){
            mob = Instantiate(SkilledTree, new Vector3(transform.position.x + 4.7f, transform.position.y - 0.8f, 90f), Quaternion.identity, transform);
            MobScript = mob.GetComponent<SkilledTree>();
            Name = Language_Changer.Instance.GetText("Skilled_Tree");
            SkilledTreeCreated = true;
            }
        }
        if(!SkilledTreeCreated){
            switch(Location){
                case 1://0-1 - Rat, 2-4 - Slime, 5 - Nettle, 6 - Milk
                    switch(MobID){
                        case 0:
                            mob = Instantiate(Rat, new Vector3(transform.position.x + 4.7f, transform.position.y - 0.9f, 90f), Quaternion.identity, transform);
                            MobScript = mob.GetComponent<Rat>();
                            Name = Language_Changer.Instance.GetText("Rat");
                            break;
                        case 1:
                            mob = Instantiate(Rat, new Vector3(transform.position.x + 4.7f, transform.position.y - 0.9f, 90f), Quaternion.identity, transform);
                            MobScript = mob.GetComponent<Rat>();
                            Name = Language_Changer.Instance.GetText("Rat");
                            break;
                        case 2:
                            mob = Instantiate(BlueSlime, new Vector3(transform.position.x + 4.7f, transform.position.y - 1.24f, 90f), Quaternion.identity, transform);
                            MobScript = mob.GetComponent<BlueSlime>();
                            Name = Language_Changer.Instance.GetText("Slime");
                            break;
                        case 3:
                            mob = Instantiate(PinkSlime, new Vector3(transform.position.x + 4.7f, transform.position.y - 1.24f, 90f), Quaternion.identity, transform);
                            MobScript = mob.GetComponent<PinkSlime>();
                            Name = Language_Changer.Instance.GetText("Slime");
                            break;
                        case 4:
                            mob = Instantiate(BrownSlime, new Vector3(transform.position.x + 4.7f, transform.position.y - 1.24f, 90f), Quaternion.identity, transform);
                            MobScript = mob.GetComponent<BrownSlime>();
                            Name = Language_Changer.Instance.GetText("Slime");
                            break;
                        case 5:
                            mob = Instantiate(Nettle, new Vector3(transform.position.x + 4.4f, transform.position.y - 0.8f, 90f), Quaternion.identity, transform);
                            MobScript = mob.GetComponent<Nettle>();
                            Name = Language_Changer.Instance.GetText("Nettle");
                            break;
                        case 6:
                            mob = Instantiate(Milk, new Vector3(transform.position.x + 4.2f, transform.position.y - 0.9f, 90f), Quaternion.identity, transform);
                            MobScript = mob.GetComponent<Milk>();
                            Name = Language_Changer.Instance.GetText("Milk");
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }
        }
        MobScript.Level = UnityEngine.Random.Range(MinLevel, MaxLevel+1);
        MobScript.player = player;
        MobScript.HealthBar = MobHealth;
        MobScript.Fight = this;
        MobScript.Mob_Load();
        MobScript.SelfSprite = mob;
        if(Name == Language_Changer.Instance.GetText("Milk") || Name == Language_Changer.Instance.GetText("Skilled_Tree")) MobText.text = Name;
        else MobText.text = Name + " " +  Language_Changer.Instance.GetText("Lvl") + " " + MobScript.Level; 
    }
    
    public void Clear(){
        Destroy(mob);
        InBattle = false;
        gameObject.SetActive(false);
        if(!Game.MapMode)MainMenu.SetActive(true);
        else {
            player.SpriteSwap();
            BG.SetActive(false);
            ModeSwitch.SetActive(true);
            GameObjects[0].SetActive(false);
            for(int i = 1; i<4;++i)GameObjects[i].SetActive(true);
        }
        SaveManager.SaveAll();
    }

    public void TriggerDeath(){
        if(AllEntitiesAlive == false) return;
        AllEntitiesAlive = false;
        if(player.Health==0){
            Game.EndGame();
        }
        else {
            MobScript.LootGenerate();
        }
    }

    public void PlayerAttack(string Type){
        if(MobScript.Health==0 || player.Health == 0) return;
        ButtonsActivate(false);
        bool Avoided = MobScript.Avoid();
        if(Avoided)MobScript.GetComponent<F_Text_Creator>().CreateText_Red(Language_Changer.Instance.GetText("Avoided"));
        switch(Type){
            case "LeftHand":
                player.LeftHandAttack(Avoided);
                break;
            case "RightHand":
                player.RightHandAttack(Avoided);
                break;
            default:
                break;
        }
        if(!Avoided){
            EffectsManager.TriggerEffects(2, player);
            EffectsManager.TriggerEffects(3, MobScript);
            if(MobScript.Health==0) return;
        }
        else EffectsManager.TriggerEffects(4, MobScript);
        if(player.SpeedEnergy<1)NextTurn();
        else ButtonsActivate(true);
    }

    public async void NextTurn(){
        ButtonsActivate(false);
        await Task.Delay(350);
        if(MobScript.Health==0) return;
        MobScript.Attack();
        if(player.Health==0) return;
        await Task.Delay(350);
        EffectsManager.TriggerEffects(1, player);
        EffectsManager.TriggerEffects(1, MobScript);
        await Task.Delay(350);
        if(MobScript.Health==0 || player.Health==0) return;
        player.Health_Regenerate();
        player.Mana_Regenerate();
        EffectsManager.Duration_Remove(MobScript);
        EffectsManager.TriggerEffects(0, MobScript);
        EffectsManager.Duration_Remove(player);
        EffectsManager.TriggerEffects(0, player);
        ReloadEffectImages();
        StartCoroutine(player.HealthBar.HP_update());
        await Task.Delay(150);
        if(IsVampirismActive)TriggerVampirism();
        await Task.Delay(200);
        ActiveSkills.Cooldown();
        ButtonsActivate(true);
        player.ManaOverdrain.Remove();
        player.BlockActive = false;
        player.DamageTaken = 0;
        player.DamageTakenByBuffs = 0;
        player.DamageBlockedByBuffs = 0;
        MobScript.DamageTaken = 0;
        MobScript.DamageBlockedByBuffs = 0;
        player.SpeedEnergyAdd();
    }

    public void TriggerVampirism(){
        IsVampirismActive = false;
        player.TriggerHeal((int)Math.Ceiling(MobScript.DamageTakenByBuffs * VampirsmHealPerc));
        StartCoroutine(player.HealthBar.HP_update());
    }

    public void ButtonsActivate(bool State){
        for(int i =0; i<16; ++i) {
            if(!(i>=2 && i<=5 && ActiveSkills.SlotsCooldowns[i-2, 0]>0)) Buttons[i].GetComponent<Button>().interactable = State;
        }
    }

    public void RunAway(){
        int Chance = UnityEngine.Random.Range(0, 10);
        if(Chance<6-(player.Level-MobScript.Level) || player.Level-MobScript.Level>3){
            CoinsText.SetActive(true);
            Clear();
        }
        else NextTurn();
    }

    public void EndBattle(){
        ButtonsActivate(false);
        if(Mob_MapSprite!=null){
            Destroy(Mob_MapSprite);
            Mob_MapSprite = null;
        }
        Game.PlayerSprite.GetComponent<Player_MapSprite>().MovesMade = 0;
        EffectsManager.TriggerEffects(1, player);
        EffectsManager.Duration_Remove(player);
        EffectsManager.TriggerEffects(0, player);
        ReloadEffectImages();
        int Money = UnityEngine.Random.Range(MobScript.MinCoins, MobScript.MaxCoins+1);
        player.MoneyManager("Add", Money, 1);
        EndBattleWindow.transform.Find("Money").GetComponent<TextMeshProUGUI>().text = "<sprite=\"C-coin\" name=\"Coin\"> " + Money;
        player.Experience_Add(MobScript.XPReward);
        string XPAmount;
        if(MobScript.XPReward[0]<=1){
            XPAmount = MobScript.XPReward[MobScript.XPReward[0]] + player.TextFormat(MobScript.XPReward[0]);
        }
        else{
        if(MobScript.XPReward[MobScript.XPReward[0]-1]>=100 || MobScript.XPReward[MobScript.XPReward[0]-1]==0) XPAmount = MobScript.XPReward[MobScript.XPReward[0]] + "." + MobScript.XPReward[MobScript.XPReward[0]-1] + player.TextFormat(MobScript.XPReward[0]);
            else if(MobScript.XPReward[MobScript.XPReward[0]-1]>=10) XPAmount = MobScript.XPReward[MobScript.XPReward[0]] + ".0" + MobScript.XPReward[MobScript.XPReward[0]-1] + player.TextFormat(MobScript.XPReward[0]);
            else XPAmount = MobScript.XPReward[MobScript.XPReward[0]] + ".00" + MobScript.XPReward[MobScript.XPReward[0]-1] + player.TextFormat(MobScript.XPReward[0]);
        }
        EndBattleWindow.transform.Find("Experience").GetComponent<TextMeshProUGUI>().text = "XP: " + XPAmount;
        EndBattleWindow.SetActive(true);
        SlimyArmor.Experience_Add(10);
    }
}
