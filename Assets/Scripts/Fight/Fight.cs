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
    public GameObject mob, MainMenu, EffectDescription, BlueSlime, BrownSlime, PinkSlime, Rat, Nettle, Milk, SkilledTree;
    public Mob MobScript;
    public Skills SkillManager;
    public HealthBar MobHealth;
    public Tooltip Tooltip;
    public TextMeshProUGUI MobText, MobDescriptionTitle, MobDescription, MobStats, MobStats2, MobStatsTitle, PassiveSkillsStats;
    public GameObject[] Buttons = new GameObject[16], PotionSlots = new GameObject[5], PlayerEffectImages = new GameObject[10], MobEffectImages = new GameObject[10], GameObjects = new GameObject[4];
    public GameObject EndBattleWindow, CoinsText, Mob_MapSprite, BG, ModeSwitch, ShieldingLevel;
    public EffectsManager EffectsManager;
    public int[] Potions = new int[5];
    public bool InBattle = false, AllEntitiesAlive;
    public StopWatch StopWatch;
    public ActiveSkills ActiveSkills;
    public static Fight Instance = null;
    public bool IsVampirismActive = false;
    public float VampirsmHealPerc;
    public Sprite[] ShieldingLevelImages = new Sprite[3];

    public Animator PlayerAnimator;

    void Awake(){
        PlayerAnimator = PlayerAnimator.GetComponent<Animator>();
        Instance = this;
    }

    public void PotionSlots_Reload(){
        for(int i = 0; i<5; ++i) PotionSlots[i].SetActive(false);
        int Slot = 0;
        for(int i = 0; i<45; ++i){
            if(player.Inventory[i] == null) break;
            if(player.Inventory[i].GetComponent<Item>().Type == "Potion"){
                PotionSlots[Slot].SetActive(true);
                PotionSlots[Slot].transform.Find("Image").GetComponent<Image>().sprite = player.Inventory[i].GetComponent<SpriteRenderer>().sprite;
                Potions[Slot] = i;
                ++Slot;
            }
        }
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

    public async void PlayerPotionUse(int SlotIndex){
        if(InBattle && (MobScript.Health==0 || player.Health == 0)) return;
        if(InBattle) ButtonsActivate(false);
        Item PotionScript = player.Inventory[Potions[SlotIndex]].GetComponent<Item>();
        PotionScript.Use();
        if(PotionScript.Amount==0){
            Destroy(player.Inventory[Potions[SlotIndex]]);
            player.Inventory[Potions[SlotIndex]] = null;
            InventoryManager.Inventory_Reorganise();
        }
        if(InBattle){
            PotionSlots_Reload();
            ReloadEffectImages();
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
        player.LeftHand.GetComponent<Item>().ShieldingLevel = 0;
        ShieldingLevel.GetComponent<Image>().sprite = InventoryManager.Empty;
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
        if(SkillManager.Parry_Unlock){
        switch(SkillManager.Parry_Chance){
            case 1:
                player.Parry_Chance = 2;
                break;
            case 2:
                player.Parry_Chance = 3;
                break;
            default:
                player.Parry_Chance = 1;
                break;
        }
        switch(SkillManager.Parry_Perc){
            case 1:
                player.Parry_RemovePercent = 0.9f;
                break;
            case 2:
                player.Parry_RemovePercent = 0.75f;
                break;
            default:
                player.Parry_RemovePercent = 1f;
                break;
        }
        switch(SkillManager.Parry_Damage){
            case 1:
                player.Parry_DamagePercent = 5;
                break;
            case 2:
                player.Parry_DamagePercent = 10;
                break;
            default:
                player.Parry_DamagePercent = 0;
                break;
        }}
        Mob_Create(MinLevel, MaxLevel, Location, MobID, AllowSkilledTree);
        PotionSlots_Reload();
        ReloadEffectImages();
        ReloadFightDescription();
        ReloadFightDescription("MobDescription");
        ReloadFightDescription("PassiveSkillsStats");
        ActiveSkills.ReloadActiveSkills();
        player.SpeedEnergy = 0;
        player.SpeedEnergyAdd();
        if(SkillManager.DoubleStaminaUnlock)player.SpeedEnergyAdd();
        player.BlockActive = false;
        player.LeftHand.GetComponent<Item>().ShieldingLevel = 0;
        player.DamageTaken = 0;
        player.DamageTakenByBuffs = 0;
        player.DamageBlockedByBuffs = 0;
        Buttons[1].transform.Find("Image").GetComponent<SpriteRenderer>().sprite = player.RightHand.GetComponent<SpriteRenderer>().sprite;
        Buttons[1].transform.Find("Image").GetComponent<Animator>().runtimeAnimatorController = player.RightHand.GetComponent<Animator>().runtimeAnimatorController;
        Buttons[0].transform.Find("Image").GetComponent<SpriteRenderer>().sprite = player.LeftHand.GetComponent<SpriteRenderer>().sprite;
        Buttons[0].transform.Find("Image").GetComponent<Animator>().runtimeAnimatorController = player.LeftHand.GetComponent<Animator>().runtimeAnimatorController;
        if(Game.MapMode){
            player.SpriteSwap();
            ModeSwitch.SetActive(false);
            BG.SetActive(true);
            gameObject.SetActive(true);
            GameObjects[0].SetActive(true);
            for(int i = 1; i<4;++i)GameObjects[i].SetActive(false);
        }
        StartCoroutine(player.HealthBar.HP_update());
    }

    public void Mob_Create(int MinLevel, int MaxLevel, int Location, int MobID, bool AllowSkilledTree){
        bool SkilledTreeCreated = false;
        if(AllowSkilledTree || MobID == 96){
            int Chance = UnityEngine.Random.Range(0, 100);
            if(Chance<=player.game.SkilledTreeChance || MobID == 96){
            mob = Instantiate(SkilledTree, new Vector3(transform.position.x + 4.7f, transform.position.y - 0.8f, 90f), Quaternion.identity, transform);
            MobScript = mob.GetComponent<SkilledTree>();
            MobScript.Name = "Skilled_Tree";
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
                            MobScript.Name = "Rat";
                            break;
                        case 1:
                            mob = Instantiate(Rat, new Vector3(transform.position.x + 4.7f, transform.position.y - 0.9f, 90f), Quaternion.identity, transform);
                            MobScript = mob.GetComponent<Rat>();
                            MobScript.Name = "Rat";
                            break;
                        case 2:
                            mob = Instantiate(BlueSlime, new Vector3(transform.position.x + 4.7f, transform.position.y - 1.24f, 90f), Quaternion.identity, transform);
                            MobScript = mob.GetComponent<BlueSlime>();
                            MobScript.Name = "Slime";
                            break;
                        case 3:
                            mob = Instantiate(PinkSlime, new Vector3(transform.position.x + 4.7f, transform.position.y - 1.24f, 90f), Quaternion.identity, transform);
                            MobScript = mob.GetComponent<PinkSlime>();
                            MobScript.Name = "Slime";
                            break;
                        case 4:
                            mob = Instantiate(BrownSlime, new Vector3(transform.position.x + 4.7f, transform.position.y - 1.24f, 90f), Quaternion.identity, transform);
                            MobScript = mob.GetComponent<BrownSlime>();
                            MobScript.Name = "Slime";
                            break;
                        case 5:
                            mob = Instantiate(Nettle, new Vector3(transform.position.x + 4.4f, transform.position.y - 0.8f, 90f), Quaternion.identity, transform);
                            MobScript = mob.GetComponent<Nettle>();
                            MobScript.Name = "Nettle";
                            break;
                        case 6:
                            mob = Instantiate(Milk, new Vector3(transform.position.x + 4.2f, transform.position.y - 0.9f, 90f), Quaternion.identity, transform);
                            MobScript = mob.GetComponent<Milk>();
                            MobScript.Name = "Milk";
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
        if(MobScript.Name == "Milk" || MobScript.Name == "Skilled_Tree") MobText.text = Language_Changer.Instance.GetText(MobScript.Name, "Mobs");
        else MobText.text = Language_Changer.Instance.GetText(MobScript.Name, "Mobs") + " " +  Language_Changer.Instance.GetText("Lvl") + " " + MobScript.Level; 
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
            Player.Instance.RightHand.GetComponent<Item>().OnPlayerDefeat();
            Player.Instance.LeftHand.GetComponent<Item>().OnPlayerDefeat();
            Player.Instance.Hat.GetComponent<Item>().OnPlayerDefeat();
            Player.Instance.Chestplate.GetComponent<Item>().OnPlayerDefeat();
            Player.Instance.Boots.GetComponent<Item>().OnPlayerDefeat();
            Player.Instance.Trinket1.GetComponent<Item>().OnPlayerDefeat();
            Player.Instance.Trinket2.GetComponent<Item>().OnPlayerDefeat();
            Game.EndGame();
        }
        else {
            Player.Instance.RightHand.GetComponent<Item>().OnEnemyKill();
            Player.Instance.LeftHand.GetComponent<Item>().OnEnemyKill();
            Player.Instance.Hat.GetComponent<Item>().OnEnemyKill();
            Player.Instance.Chestplate.GetComponent<Item>().OnEnemyKill();
            Player.Instance.Boots.GetComponent<Item>().OnEnemyKill();
            Player.Instance.Trinket1.GetComponent<Item>().OnEnemyKill();
            Player.Instance.Trinket2.GetComponent<Item>().OnEnemyKill();
            MobScript.LootGenerate();
        }
    }

    public void PlayerAttack(string Type){
        if(MobScript.Health==0 || player.Health == 0) return;
        ButtonsActivate(false);
        switch(Type){
            case "LeftHand":
                player.LeftHand.GetComponent<Item>().Use();
                break;
            case "RightHand":
                player.RightHand.GetComponent<Item>().Use();
                break;
            default:
                break;
        }
        if(MobScript.Health==0) return;

        ReloadFightDescription();
        ReloadFightDescription("PassiveSkillsStats");
        if(player.SpeedEnergy<1)NextTurn();
        else ButtonsActivate(true);
    }

    public async void NextTurn(){
        ButtonsActivate(false);
        await Task.Delay(350);
        if(MobScript.Health==0) return;
        MobScript.Attack();
        if(player.Health==0) return;
        Player.Instance.RightHand.GetComponent<Item>().OnNextTurn();
        Player.Instance.LeftHand.GetComponent<Item>().OnNextTurn();
        Player.Instance.Hat.GetComponent<Item>().OnNextTurn();
        Player.Instance.Chestplate.GetComponent<Item>().OnNextTurn();
        Player.Instance.Boots.GetComponent<Item>().OnNextTurn();
        Player.Instance.Trinket1.GetComponent<Item>().OnNextTurn();
        Player.Instance.Trinket2.GetComponent<Item>().OnNextTurn();
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
        ReloadFightDescription();
        ReloadFightDescription("PassiveSkillsStats");
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
    }

    public void ReloadFightDescription(string Description = "MobStats"){
        switch(Description){
            case "MobStats":
                MobStatsTitle.text = Language_Changer.Instance.GetText(MobScript.Name, "Mobs");
                MobStats.text = "";
                MobStats.text += "<sprite=\"Stats\" name=\"Damage\"> " + MobScript.Damage + "\n";
                MobStats.text += "<sprite=\"Stats\" name=\"Defence\"> " + MobScript.MinDefence + "-" + MobScript.MaxDefence + "\n";
                MobStats.text += "<sprite=\"Stats\" name=\"DamageResistance\"> " + MobScript.DamageResistance;
                MobStats2.text = "";
                MobStats2.text += "<sprite=\"Stats\" name=\"Accuracy\"> " + MobScript.Accuracy + "\n";
                MobStats2.text += "<sprite=\"Stats\" name=\"Evasion\"> " + MobScript.Evasion + "\n";
                break;
            case "MobDescription":
                MobDescriptionTitle.text = Language_Changer.Instance.GetText(MobScript.Name, "Mobs");
                MobDescription.text = Language_Changer.Instance.GetText(MobScript.Name + "_Description", "Mobs");
                break;
            case "PassiveSkillsStats":
                PassiveSkillsStats.text = "<sprite=\"PassiveSkills\" name=\"BrutalityStreak\"> " + (player.BrutalityStreak_AddDamageAll*100).ToString("0.00") + "%\n";
                PassiveSkillsStats.text += "<sprite=\"PassiveSkills\" name=\"Parry\"> " + player.Parry_ChanceAll.ToString("0.00") + "%\n";
                PassiveSkillsStats.text += "<sprite=\"PassiveSkills\" name=\"ManaOverdrain\"> " + player.ManaOverdrain.MovesLeft;
                break;
            default:
                Debug.Log("Invalid Description:" + Description);
                break;
        }
    }

    public void CreateEffectTooltip(int EffectSlotId){
        Entity Target;
        int DirectionModifier = 1;
        if(EffectSlotId/10==1){
            Target = MobScript;
            DirectionModifier = -1;
        }
        else Target = player;
        EffectSlotId = EffectSlotId%10;
        Tooltip.SetTextAndResize(Language_Changer.Instance.GetText("Id_" + Target.StatusEffects[EffectSlotId, 0], "Effects"), EffectsManager.GetDescription(EffectSlotId, Target), DirectionModifier);
    }

    public void ReloadShieldingLevelImage(){
        if(player.LeftHand.GetComponent<Item>().ShieldingLevel!=0)ShieldingLevel.GetComponent<Image>().sprite = ShieldingLevelImages[player.LeftHand.GetComponent<Item>().ShieldingLevel-1];
        else ShieldingLevel.GetComponent<Image>().sprite = InventoryManager.Empty;
    }
}
