using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{

    [SerializeField]
    private PlayerManager playerManager;
    public PlayerManager PlayerManager { get { return this.playerManager; } }


    private void Update()
    {
            
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
}
