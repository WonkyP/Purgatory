using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectIdentifier : MonoBehaviour
{
    // Enums
    public enum TypeOfInventoryItems { Equipment, Attacks, Weapons }
    public enum TypeOfItem { Helmets, Arms, Chests, Legs, WeaponAttacks, SpellAttacks, OneHandedWeapons, TwoHandedWeapons }
    private enum ItemState { Selected, Deselected }

    [SerializeField]
    private TypeOfInventoryItems inventoryItem;
    public TypeOfInventoryItems InventoryItem { get { return this.inventoryItem; } }

    [SerializeField]
    private TypeOfItem item;
    public TypeOfItem Item { get { return this.item; } }

    // To know if the object has been selected or not
    private ItemState itemState = ItemState.Deselected;

    [SerializeField]
    private int objectId;
    public int ObjectId { get { return this.objectId; } }

    // I need it public to let the script know I'm referring to that specific inventory
    [SerializeField]
    private Inventory inventory;

    [SerializeField]
    private InventoryManager inventoryManager;

    // Items
    string itemType;
    
    Helmet helmet;

    Arm arm;

    Chest chest;

    Leg leg;

    Weapon_Attack attack;

    OneHandedWeapon oneHandedWeapon;

    TwoHandedWeapon twoHandedWeapon;

    public void EquipmentSelected()
    {
        itemType = item.ToString();

        if (itemType == TypeOfItem.Helmets.ToString())
        {
            helmet = inventory.InventoryExtensions.FindHelmet(objectId);
            inventoryManager.updatePlayerHelmet(helmet);
        }
        else if (itemType == TypeOfItem.Arms.ToString())
        {
            arm = inventory.InventoryExtensions.FindArm(objectId);
            inventoryManager.updatePlayerArm(arm);
        }
        else if (itemType == TypeOfItem.Chests.ToString())
        {
            chest = inventory.InventoryExtensions.FindChest(objectId);
            inventoryManager.updatePlayerChest(chest);
        }
        else if (itemType == TypeOfItem.Legs.ToString())
        {
            leg = inventory.InventoryExtensions.FindLeg(objectId);
            inventoryManager.updatePlayerLeg(leg);
        }                          
    }

    public void AttackSelected()
    {
        itemType = item.ToString();

        attack = inventory.InventoryExtensions.FindWeaponAttack(objectId);

        if (itemState == ItemState.Deselected)
        {
            if (itemType == TypeOfItem.WeaponAttacks.ToString())
            {
                //attack = inventory.InventoryExtensions.FindWeaponAttack(objectId);
                inventoryManager.updatePlayerComboSet(inventoryManager.PlayerManager.CurrentComboSet1, attack);
            }

            itemState = ItemState.Selected;

            GetComponent<Image>().color = Color.magenta;
        }
        else
        {
            inventoryManager.PlayerManager.ComboSystem.removeAttackFromCombo(inventoryManager.PlayerManager.CurrentComboSet1, attack);
            itemState = ItemState.Deselected;

            GetComponent<Image>().color = Color.white;
        }
  
    }

    public void WeaponSelected()
    {
        itemType = item.ToString();

        if (itemType == TypeOfItem.OneHandedWeapons.ToString())
        {
            oneHandedWeapon = inventory.InventoryExtensions.FindOneHandedWeapon(objectId);
            inventoryManager.updatePlayerOneHandedWeapon(oneHandedWeapon);
        }
        else if (itemType == TypeOfItem.TwoHandedWeapons.ToString())
        {
            twoHandedWeapon = inventory.InventoryExtensions.FindTwoHandedWeapon(objectId);
            inventoryManager.updatePlayerTwoHandedWeapon(twoHandedWeapon);
        }
    }

}
