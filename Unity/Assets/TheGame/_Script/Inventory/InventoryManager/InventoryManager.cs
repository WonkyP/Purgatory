using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{

    [SerializeField]
    private PlayerManager playerManager;
    public PlayerManager PlayerManager { get { return this.playerManager; } }

    // List of strings to store the card names
    private List<string> cardNames = new List<string>();
    public List<string> CardNames { get { return this.cardNames; } }

    // List of texts to update the gui
    [SerializeField]
    private List<Text> comboSetNames1;
    public List<Text> ComboSetNames1 { get { return this.comboSetNames1; } }

    // List of texts to update the gui
    [SerializeField]
    private List<Text> comboSetNames2;
    public List<Text> ComboSetNames2 { get { return this.comboSetNames2; } }

    // Default objects for empty fields in inventory
    private Helmet defaultHelmet = new Helmet("Default", -1);
    private Arm defaultArm = new Arm("Default", -1);
    private Chest defaultChest = new Chest("Default", -1);
    private Leg defaultLeg = new Leg("Default", -1);
    private OneHandedWeapon defaultOneHandedWeapon = new OneHandedWeapon("Default", -1);
    private TwoHandedWeapon defaultTwoHandedWeapon = new TwoHandedWeapon("Default", -1);

    private void Start()
    {
        emptyPlayerCombos();
    }

    // Method to update player's helmet
    public void updatePlayerHelmet(Helmet h)
    {
        playerManager.CurrentHelmet = h;
    }

    // Method to update player's arm
    public void updatePlayerArm(Arm a)
    {
        playerManager.CurrentArm = a;
    }

    // Method to update player's chest
    public void updatePlayerChest(Chest c)
    {
        playerManager.CurrentChest = c;
    }

    // Method to update player's leg
    public void updatePlayerLeg(Leg l)
    {
        playerManager.CurrentLeg = l;
    }

    // Method to update player's oneHandedWeapon
    public void updatePlayerOneHandedWeapon(OneHandedWeapon w)
    {
        playerManager.CurrentOneHandedWeapon = w;
    }

    // Method to update player's twoHandedWeapon
    public void updatePlayerTwoHandedWeapon(TwoHandedWeapon w)
    {
        playerManager.CurrentTwoHandedWeapon = w;
    }

    // Method to add one attack to a comboSet
    public void updatePlayerComboSet(List<Weapon_Attack> currentComboSet, Weapon_Attack a)
    {
        playerManager.ComboSystem.addAttackToCombo(currentComboSet, a);
    }

    // Method to set the player helmet to a default one
    public void PlayerHelmetToDefault()
    {
        playerManager.CurrentHelmet = defaultHelmet;
    }

    // Method to set the player arm to a default one
    public void PlayerArmToDefault()
    {
        playerManager.CurrentArm = defaultArm;
    }

    // Method to set the player chest to a default one
    public void PlayerChestToDefault()
    {
        playerManager.CurrentChest = defaultChest;
    }

    // Method to set the player leg to a default one
    public void PlayerLegToDefault()
    {
        playerManager.CurrentLeg = defaultLeg;
    }

    // Method to set the player one handed weapon to a default one
    public void PlayerOneHandedWeaponToDefault()
    {
        playerManager.CurrentOneHandedWeapon = defaultOneHandedWeapon;
    }

    // Method to set the player two handed weapon to a default one
    public void PlayerTwoHandedWeaponToDefault()
    {
        playerManager.CurrentTwoHandedWeapon = defaultTwoHandedWeapon;
    }

    // Method to restart all the attacks the player has equiped before
    public void emptyPlayerCombos()
    {
        cardNames.Clear();
        playerManager.ComboSystem.emptyCombos(playerManager.CurrentComboSet1, playerManager.ComboSet1);
        playerManager.ComboSystem.emptyCombos(playerManager.CurrentComboSet2, playerManager.ComboSet2);
    }
}
